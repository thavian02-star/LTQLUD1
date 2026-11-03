-- ==============================================================
-- CƠ SỞ DỮ LIỆU: HỆ THỐNG QUẢN LÝ QUÁN ĂN
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- ==============================================================
-- !!! QUY TẮC BẮT BUỘC DÀNH CHO DEVELOPER & AGENT !!!
-- 1. BẢO TOÀN DỮ LIỆU (IDEMPOTENCY / DATA PERSISTENCE):
--    - TUYỆT ĐỐI KHÔNG sử dụng lệnh `DROP TABLE ...` trước khi tạo bảng.
--    - File script này được cấu hình tự động chạy mỗi khi Docker container khởi động.
--      Nếu sử dụng `DROP TABLE`, toàn bộ dữ liệu người dùng đã nhập sẽ bị XÓA SẠCH!
--    - BẮT BUỘC luôn luôn sử dụng cấu trúc phòng vệ sau cho mọi bảng mới:
--        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TenBang')
--        BEGIN
--            CREATE TABLE TenBang ( ... );
--        END
--        GO
-- 2. NẠP DỮ LIỆU MẪU (SEED / MOCK DATA):
--    - Khi viết lệnh INSERT dữ liệu mẫu, luôn bọc trong điều kiện kiểm tra bảng rỗng:
--        IF NOT EXISTS (SELECT 1 FROM TenBang)
--        BEGIN
--            INSERT INTO TenBang (...) VALUES (...);
--        END
--        GO
--      Tránh việc nhân đôi dữ liệu (duplicate) mỗi lần Docker khởi động lại.
-- 3. HỖ TRỢ TIẾNG VIỆT UNICODE:
--    - Sử dụng kiểu dữ liệu NVARCHAR cho các cột có chứa tiếng Việt có dấu.
--    - Khi INSERT/UPDATE chuỗi tiếng Việt, BẮT BUỘC có tiền tố N, ví dụ: N'Nguyễn Văn A'.
-- ==============================================================

-- 1. Tạo Database nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyQuanAnDB')
BEGIN
    CREATE DATABASE [QuanLyQuanAnDB];
END
GO

USE [QuanLyQuanAnDB];
GO

-- 2. Bảng NhanVien (An toàn: Không xóa bảng cũ nếu đã tồn tại)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhanVien')
BEGIN
    CREATE TABLE NhanVien (
        nv_ma INT IDENTITY(1,1) PRIMARY KEY,
        nv_ten NVARCHAR(100) NOT NULL,
        nv_dia_chi NVARCHAR(255),
        nv_gioi_tinh BIT DEFAULT 1,
        nv_xoa BIT DEFAULT 0
    );
END
GO

-- 3. Bảng TaiKhoan (An toàn: Không xóa bảng cũ nếu đã tồn tại)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaiKhoan')
BEGIN
    CREATE TABLE TaiKhoan (
        tk_ma INT IDENTITY(1,1) PRIMARY KEY,
        tk_tai_khoan NVARCHAR(50) NOT NULL UNIQUE,
        tk_mat_khau NVARCHAR(255) NOT NULL,
        tk_xoa BIT DEFAULT 0
    );
END
GO

-- 4. Bảng KhuVuc (An toàn: Không xóa bảng cũ nếu đã tồn tại)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhuVuc')
BEGIN
    CREATE TABLE KhuVuc (
        kv_ma INT IDENTITY(1,1) PRIMARY KEY,
        kv_code NVARCHAR(50) NULL,
        kv_ten NVARCHAR(100) NOT NULL,
        kv_mo_ta NVARCHAR(255) NULL,
        kv_xoa BIT DEFAULT 0 -- Sử dụng kiểu BIT đại diện cho Yes/No (0 hoặc 1)
    );
END
GO

-- ==============================================================
-- DỌN DẸP BẢNG CŨ (MIGRATION / CLEANUP):
-- Nếu hệ thống từng tạo bảng SanPham hoặc LoaiSanPham, xóa an toàn
-- bằng cách gỡ các khóa ngoại trước, sau đó xóa bảng con SanPham rồi đến LoaiSanPham.
-- ==============================================================
IF OBJECT_ID('FK_ChiTietPhieuNhap_SanPham', 'F') IS NOT NULL
    ALTER TABLE ChiTietPhieuNhap DROP CONSTRAINT FK_ChiTietPhieuNhap_SanPham;
GO

IF OBJECT_ID('FK_ChiTietPhieuXuat_SanPham', 'F') IS NOT NULL
    ALTER TABLE ChiTietPhieuXuat DROP CONSTRAINT FK_ChiTietPhieuXuat_SanPham;
GO

IF OBJECT_ID('FK_TonKho_SanPham', 'F') IS NOT NULL
    ALTER TABLE TonKho DROP CONSTRAINT FK_TonKho_SanPham;
GO

IF OBJECT_ID('FK_SanPham_LoaiSanPham', 'F') IS NOT NULL
    ALTER TABLE SanPham DROP CONSTRAINT FK_SanPham_LoaiSanPham;
GO

IF OBJECT_ID('SanPham', 'U') IS NOT NULL
    DROP TABLE SanPham;
GO

IF OBJECT_ID('LoaiSanPham', 'U') IS NOT NULL
    DROP TABLE LoaiSanPham;
GO

-- 5. Bảng DanhMuc (Bảng cha - Phân loại danh mục món ăn)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DanhMuc')
BEGIN
    CREATE TABLE DanhMuc (
        dm_ma INT IDENTITY(1,1) PRIMARY KEY,
        dm_code NVARCHAR(50) NULL,
        dm_ten NVARCHAR(100) NOT NULL,
        dm_mo_ta NVARCHAR(255) NULL,
        dm_xoa BIT DEFAULT 0
    );
END
GO

-- 6. Bảng MonAn (Bảng con - Tham chiếu khóa ngoại tới DanhMuc)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MonAn')
BEGIN
    CREATE TABLE MonAn (
        ma_ma INT IDENTITY(1,1) PRIMARY KEY,
        ma_code NVARCHAR(50) NULL,
        ma_ten NVARCHAR(150) NOT NULL,
        ma_mo_ta NVARCHAR(500) NULL,
        ma_loai INT NOT NULL,
        ma_gia DECIMAL(18, 2) DEFAULT 0, -- Chuyển sang dạng số thực để dễ tính toán
        ma_xoa BIT DEFAULT 0,
        CONSTRAINT FK_MonAn_DanhMuc FOREIGN KEY (ma_loai) REFERENCES DanhMuc(dm_ma)
    );
END
GO

-- 7. Bảng NhaCungCap (Quản lý thông tin nhà cung cấp)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhaCungCap')
BEGIN
    CREATE TABLE NhaCungCap (
        ncc_ma INT IDENTITY(1,1) PRIMARY KEY,
        ncc_code NVARCHAR(50) NULL,
        ncc_ten NVARCHAR(150) NOT NULL,
        ncc_dia_chi NVARCHAR(255) NULL,
        ncc_dien_thoai NVARCHAR(20) NULL,
        ncc_ghi_chu NVARCHAR(500) NULL,
        ncc_xoa BIT DEFAULT 0
    );
END
GO

-- 8. Bảng KhachHang (Quản lý khách hàng mua hàng)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'KhachHang')
BEGIN
    CREATE TABLE KhachHang (
        kh_ma INT IDENTITY(1,1) PRIMARY KEY,
        kh_code NVARCHAR(50) NULL,
        kh_ten NVARCHAR(150) NOT NULL,
        kh_dia_chi NVARCHAR(255) NULL,
        kh_dien_thoai NVARCHAR(20) NULL,
        kh_email NVARCHAR(100) NULL,
        kh_xoa BIT DEFAULT 0
    );
END
GO

-- 9. Bảng PhieuNhap (Bảng cha - Quản lý thông tin chung các đợt nhập hàng)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PhieuNhap')
BEGIN
    CREATE TABLE PhieuNhap (
        pn_ma INT IDENTITY(1,1) PRIMARY KEY,
        pn_code NVARCHAR(50) NULL,
        pn_ngay DATETIME DEFAULT GETDATE(),
        pn_tong_san_pham INT DEFAULT 0,
        pn_tong_tien DECIMAL(18, 2) DEFAULT 0,
        pn_ghi_chu NVARCHAR(500) NULL,
        pn_nha_cung_cap INT NOT NULL,
        pn_nhan_vien INT NOT NULL,
        pn_xoa BIT DEFAULT 0,
        CONSTRAINT FK_PhieuNhap_NhaCungCap FOREIGN KEY (pn_nha_cung_cap) REFERENCES NhaCungCap(ncc_ma),
        CONSTRAINT FK_PhieuNhap_NhanVien FOREIGN KEY (pn_nhan_vien) REFERENCES NhanVien(nv_ma)
    );
END
GO

-- 10. Bảng ChiTietPhieuNhap (Bảng con - Chi tiết món ăn/sản phẩm trong phiếu nhập)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChiTietPhieuNhap')
BEGIN
    CREATE TABLE ChiTietPhieuNhap (
        ctpn_ma INT IDENTITY(1,1) PRIMARY KEY,
        ctpn_phieu_nhap INT NOT NULL,
        ctpn_mon_an INT NOT NULL,
        ctpn_so_luong INT NOT NULL DEFAULT 0,
        ctpn_gia_nhap DECIMAL(18, 2) DEFAULT 0,
        ctpn_thanh_tien DECIMAL(18, 2) DEFAULT 0,
        ctpn_xoa BIT DEFAULT 0,
        CONSTRAINT FK_ChiTietPhieuNhap_PhieuNhap FOREIGN KEY (ctpn_phieu_nhap) REFERENCES PhieuNhap(pn_ma),
        CONSTRAINT FK_ChiTietPhieuNhap_MonAn FOREIGN KEY (ctpn_mon_an) REFERENCES MonAn(ma_ma)
    );
END
GO

-- 11. Bảng PhieuXuat (Bảng cha - Quản lý thông tin chung đợt xuất/bán hàng)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PhieuXuat')
BEGIN
    CREATE TABLE PhieuXuat (
        px_ma INT IDENTITY(1,1) PRIMARY KEY,
        px_code NVARCHAR(50) NULL,
        px_ngay DATETIME DEFAULT GETDATE(),
        px_tong_san_pham INT DEFAULT 0,
        px_tong_tien DECIMAL(18, 2) DEFAULT 0,
        px_ghi_chu NVARCHAR(500) NULL,
        px_khach_hang INT NOT NULL,
        px_nhan_vien INT NOT NULL,
        px_xoa BIT DEFAULT 0,
        CONSTRAINT FK_PhieuXuat_KhachHang FOREIGN KEY (px_khach_hang) REFERENCES KhachHang(kh_ma),
        CONSTRAINT FK_PhieuXuat_NhanVien FOREIGN KEY (px_nhan_vien) REFERENCES NhanVien(nv_ma)
    );
END
GO

-- 12. Bảng ChiTietPhieuXuat (Bảng con - Chi tiết món ăn trong phiếu xuất)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChiTietPhieuXuat')
BEGIN
    CREATE TABLE ChiTietPhieuXuat (
        ctpx_ma INT IDENTITY(1,1) PRIMARY KEY,
        ctpx_phieu_xuat INT NOT NULL,
        ctpx_mon_an INT NOT NULL,
        ctpx_so_luong INT NOT NULL DEFAULT 0,
        ctpx_gia_xuat DECIMAL(18, 2) DEFAULT 0,
        ctpx_thanh_tien DECIMAL(18, 2) DEFAULT 0,
        ctpx_xoa BIT DEFAULT 0,
        CONSTRAINT FK_ChiTietPhieuXuat_PhieuXuat FOREIGN KEY (ctpx_phieu_xuat) REFERENCES PhieuXuat(px_ma),
        CONSTRAINT FK_ChiTietPhieuXuat_MonAn FOREIGN KEY (ctpx_mon_an) REFERENCES MonAn(ma_ma)
    );
END
GO

-- 13. Bảng TonKho (Quản lý số lượng tồn kho theo món ăn và khu vực)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TonKho')
BEGIN
    CREATE TABLE TonKho (
        tk_ma INT IDENTITY(1,1) PRIMARY KEY,
        tk_mon_an INT NOT NULL,
        tk_khu_vuc INT NOT NULL,
        tk_so_luong_ton INT NOT NULL DEFAULT 0,
        tk_ngay_cap_nhat DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_TonKho_MonAn FOREIGN KEY (tk_mon_an) REFERENCES MonAn(ma_ma),
        CONSTRAINT FK_TonKho_KhuVuc FOREIGN KEY (tk_khu_vuc) REFERENCES KhuVuc(kv_ma)
    );
END
GO

-- 14. Bảng PhanQuyen (Quản lý các nhóm vai trò/quyền hạn hệ thống)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PhanQuyen')
BEGIN
    CREATE TABLE PhanQuyen (
        pq_ma INT IDENTITY(1,1) PRIMARY KEY,
        pq_ten NVARCHAR(100) NOT NULL,
        pq_mo_ta NVARCHAR(255) NULL
    );
END
GO

-- 15. Bảng ChiTietPhanQuyen (Phân quyền chi tiết cho từng tài khoản)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChiTietPhanQuyen')
BEGIN
    CREATE TABLE ChiTietPhanQuyen (
        ctpq_ma INT IDENTITY(1,1) PRIMARY KEY,
        ctpq_phan_quyen INT NOT NULL,
        ctpq_tai_khoan INT NOT NULL,
        ctpq_xem BIT DEFAULT 0,
        ctpq_them BIT DEFAULT 0,
        ctpq_sua BIT DEFAULT 0,
        ctpq_xoa BIT DEFAULT 0,
        CONSTRAINT FK_ChiTietPhanQuyen_PhanQuyen FOREIGN KEY (ctpq_phan_quyen) REFERENCES PhanQuyen(pq_ma),
        CONSTRAINT FK_ChiTietPhanQuyen_TaiKhoan FOREIGN KEY (ctpq_tai_khoan) REFERENCES TaiKhoan(tk_ma)
    );
END
GO
