-- ==============================================================
-- CƠ SỞ DỮ LIỆU: HỆ THỐNG QUẢN LÝ QUÁN ĂN
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- Thiết kế theo: GIAI ĐOẠN 2 - Mục 2.1 (18 bảng chia làm 5 nhóm nghiệp vụ)
-- ==============================================================
-- !!! QUY TẮC BẮT BUỘC DÀNH CHO DEVELOPER & AGENT !!!
-- 1. BẢO TOÀN DỮ LIỆU (IDEMPOTENCY / DATA PERSISTENCE):
--    - TUYỆT ĐỐI KHÔNG sử dụng lệnh `DROP TABLE ...` trực tiếp trước từng bảng.
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

-- ==============================================================
-- [CHẾ ĐỘ THIẾT KẾ / DEVELOPMENT RESET]
-- Tự động gỡ bỏ toàn bộ khóa ngoại và xóa sạch tất cả các bảng hiện có
-- để khởi tạo lại cấu trúc mới nhất mà không cần viết script migrate thủ công.
-- >>> LƯU Ý: XÓA HOẶC COMMENT KHỐI NÀY KHI ĐÃ THIẾT KẾ ỔN ĐỊNH <<<
-- ==============================================================
DECLARE @dropConstraintsSql NVARCHAR(MAX) = N'';
SELECT @dropConstraintsSql += N'ALTER TABLE ' + QUOTENAME(OBJECT_SCHEMA_NAME(parent_object_id)) + '.' + QUOTENAME(OBJECT_NAME(parent_object_id)) + 
                              N' DROP CONSTRAINT ' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.foreign_keys;
IF LEN(@dropConstraintsSql) > 0
    EXEC sp_executesql @dropConstraintsSql;

DECLARE @dropTablesSql NVARCHAR(MAX) = N'';
SELECT @dropTablesSql += N'DROP TABLE ' + QUOTENAME(SCHEMA_NAME(schema_id)) + '.' + QUOTENAME(name) + ';' + CHAR(13)
FROM sys.tables
WHERE is_ms_shipped = 0;
IF LEN(@dropTablesSql) > 0
    EXEC sp_executesql @dropTablesSql;
GO

-- ==============================================================
-- NHÓM 1: BẢNG PHÂN QUYỀN & TÀI KHOẢN (RBAC - 5 BẢNG)
-- ==============================================================

-- 1.1. Bảng TaiKhoan (Quản lý tài khoản đăng nhập, mật khẩu băm MD5)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaiKhoan')
BEGIN
    CREATE TABLE TaiKhoan (
        TK_Ma INT IDENTITY(1,1) PRIMARY KEY,
        TK_TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
        TK_MatKhau NVARCHAR(255) NOT NULL,
        TK_Xoa BIT DEFAULT 0
    );
END
GO

-- 1.2. Bảng VaiTro (Chủ quán, Quản lý, Nhân viên phục vụ, Nhà bếp / Pha chế)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'VaiTro')
BEGIN
    CREATE TABLE VaiTro (
        VT_Ma INT IDENTITY(1,1) PRIMARY KEY,
        VT_Ten NVARCHAR(50) NOT NULL,
        VT_Xoa BIT DEFAULT 0
    );
END
GO

-- 1.3. Bảng Quyen (Ánh xạ Q_Tag vào thuộc tính Tag của Button/Menu trên WinForms)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Quyen')
BEGIN
    CREATE TABLE Quyen (
        Q_Ma INT IDENTITY(1,1) PRIMARY KEY,
        Q_Ten NVARCHAR(100) NOT NULL,
        Q_Tag NVARCHAR(50) NOT NULL,
        Q_Xoa BIT DEFAULT 0
    );
END
GO

-- 1.4. Bảng TaiKhoan_VaiTro (Bảng trung gian gán vai trò cho tài khoản)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaiKhoan_VaiTro')
BEGIN
    CREATE TABLE TaiKhoan_VaiTro (
        TKVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
        TKVT_TaiKhoan INT NOT NULL,
        TKVT_VaiTro INT NOT NULL,
        TKVT_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_TaiKhoanVaiTro_TaiKhoan FOREIGN KEY (TKVT_TaiKhoan) REFERENCES TaiKhoan(TK_Ma),
        CONSTRAINT FK_TaiKhoanVaiTro_VaiTro FOREIGN KEY (TKVT_VaiTro) REFERENCES VaiTro(VT_Ma)
    );
END
GO

-- 1.5. Bảng VaiTro_Quyen (Bảng trung gian phân quyền chức năng cho từng vai trò)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'VaiTro_Quyen')
BEGIN
    CREATE TABLE VaiTro_Quyen (
        VTQ_Ma INT IDENTITY(1,1) PRIMARY KEY,
        VTQ_VaiTro INT NOT NULL,
        VTQ_Quyen INT NOT NULL,
        VTQ_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_VaiTroQuyen_VaiTro FOREIGN KEY (VTQ_VaiTro) REFERENCES VaiTro(VT_Ma),
        CONSTRAINT FK_VaiTroQuyen_Quyen FOREIGN KEY (VTQ_Quyen) REFERENCES Quyen(Q_Ma)
    );
END
GO

-- ==============================================================
-- NHÓM 2: BẢNG NHÂN SỰ & TUYỂN DỤNG (5 BẢNG)
-- ==============================================================

-- 2.1. Bảng NhanVien (Hồ sơ nhân sự, vị trí dự tuyển, trạng thái làm việc/nghỉ việc)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhanVien')
BEGIN
    CREATE TABLE NhanVien (
        NV_Ma INT IDENTITY(1,1) PRIMARY KEY,
        NV_HoTen NVARCHAR(100) NOT NULL,
        NV_GioiTinh BIT DEFAULT 1, -- 1: Nam, 0: Nữ
        NV_NgaySinh DATE NULL,
        NV_ViTri NVARCHAR(50) NOT NULL, -- Phục vụ, Pha chế, Quản lý, Tiếp tân, Chủ quán
        NV_DienThoai NVARCHAR(20) NULL,
        NV_DiaChi NVARCHAR(255) NULL,
        NV_CMND NVARCHAR(20) NULL,
        NV_NgayBatDauLam DATE DEFAULT GETDATE(),
        NV_MaTaiKhoan INT NULL,
        NV_TrangThai NVARCHAR(30) DEFAULT N'Đang làm việc', -- Đang làm việc / Đã nghỉ việc
        NV_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_NhanVien_TaiKhoan FOREIGN KEY (NV_MaTaiKhoan) REFERENCES TaiKhoan(TK_Ma)
    );
END
GO

-- 2.2. Bảng TrinhDoViTinh (Word, Excel, Cài phần mềm, Khác - danh sách có thể thay đổi)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TrinhDoViTinh')
BEGIN
    CREATE TABLE TrinhDoViTinh (
        TDVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
        TDVT_Ten NVARCHAR(50) NOT NULL,
        TDVT_Xoa BIT DEFAULT 0
    );
END
GO

-- 2.3. Bảng NhanVien_ViTinh (Bảng trung gian lưu nhiều kỹ năng vi tính của nhân viên)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhanVien_ViTinh')
BEGIN
    CREATE TABLE NhanVien_ViTinh (
        ID INT IDENTITY(1,1) PRIMARY KEY,
        NV_Ma INT NOT NULL,
        TDVT_Ma INT NOT NULL,
        CONSTRAINT FK_NhanVienViTinh_NhanVien FOREIGN KEY (NV_Ma) REFERENCES NhanVien(NV_Ma),
        CONSTRAINT FK_NhanVienViTinh_TrinhDoViTinh FOREIGN KEY (TDVT_Ma) REFERENCES TrinhDoViTinh(TDVT_Ma)
    );
END
GO

-- 2.4. Bảng DungCuTrangPhuc (Danh mục đồng phục & dụng cụ của quán)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DungCuTrangPhuc')
BEGIN
    CREATE TABLE DungCuTrangPhuc (
        DC_Ma INT IDENTITY(1,1) PRIMARY KEY,
        DC_Ten NVARCHAR(100) NOT NULL,
        DC_SoLuongTong INT DEFAULT 0,
        DC_GhiChu NVARCHAR(255) NULL,
        DC_Xoa BIT DEFAULT 0
    );
END
GO

-- 2.5. Bảng NhanVien_DungCu (Quản lý cấp phát và thu hồi trang phục khi nghỉ việc)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'NhanVien_DungCu')
BEGIN
    CREATE TABLE NhanVien_DungCu (
        MP_Ma INT IDENTITY(1,1) PRIMARY KEY,
        NV_Ma INT NOT NULL,
        DC_Ma INT NOT NULL,
        SoLuong INT DEFAULT 1,
        NgayNhan DATE DEFAULT GETDATE(),
        DaTra BIT DEFAULT 0, -- 0: Đang giữ, 1: Đã hoàn trả khi nghỉ việc
        NgayTra DATE NULL,
        GhiChu NVARCHAR(255) NULL,
        CONSTRAINT FK_NhanVienDungCu_NhanVien FOREIGN KEY (NV_Ma) REFERENCES NhanVien(NV_Ma),
        CONSTRAINT FK_NhanVienDungCu_DungCuTrangPhuc FOREIGN KEY (DC_Ma) REFERENCES DungCuTrangPhuc(DC_Ma)
    );
END
GO

-- ==============================================================
-- NHÓM 3: BẢNG CA LÀM VIỆC, XẾP LỊCH & CHẤM CÔNG (3 BẢNG)
-- ==============================================================

-- 3.1. Bảng CaLamViec (Danh sách ca, khung giờ linh hoạt & mức lương mỗi ca)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CaLamViec')
BEGIN
    CREATE TABLE CaLamViec (
        CA_Ma INT IDENTITY(1,1) PRIMARY KEY,
        CA_Ten NVARCHAR(50) NOT NULL,
        CA_GioBatDau NVARCHAR(10) NOT NULL,
        CA_GioKetThuc NVARCHAR(10) NOT NULL,
        CA_LuongMoiCa DECIMAL(18, 2) DEFAULT 0,
        CA_Xoa BIT DEFAULT 0
    );
END
GO

-- 3.2. Bảng LichLamViec (Xếp lịch làm việc theo tuần/tháng cho nhân viên)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LichLamViec')
BEGIN
    CREATE TABLE LichLamViec (
        LLV_Ma INT IDENTITY(1,1) PRIMARY KEY,
        LLV_MaNV INT NOT NULL,
        LLV_MaCa INT NOT NULL,
        LLV_NgayLam DATE NOT NULL,
        LLV_TrangThai NVARCHAR(30) DEFAULT N'Đã xếp lịch',
        LLV_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_LichLamViec_NhanVien FOREIGN KEY (LLV_MaNV) REFERENCES NhanVien(NV_Ma),
        CONSTRAINT FK_LichLamViec_CaLamViec FOREIGN KEY (LLV_MaCa) REFERENCES CaLamViec(CA_Ma)
    );
END
GO

-- 3.3. Bảng ChamCong (Ghi nhận giờ làm & Quản lý bấm duyệt chấm công để tính lương)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChamCong')
BEGIN
    CREATE TABLE ChamCong (
        CC_Ma INT IDENTITY(1,1) PRIMARY KEY,
        CC_MaLich INT NULL,
        CC_MaNV INT NOT NULL,
        CC_GioBatDau DATETIME NULL,
        CC_GioKetThuc DATETIME NULL,
        CC_DaDuyet BIT DEFAULT 0, -- 0: Chờ duyệt, 1: Quản lý đã duyệt
        CC_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_ChamCong_LichLamViec FOREIGN KEY (CC_MaLich) REFERENCES LichLamViec(LLV_Ma),
        CONSTRAINT FK_ChamCong_NhanVien FOREIGN KEY (CC_MaNV) REFERENCES NhanVien(NV_Ma)
    );
END
GO

-- ==============================================================
-- NHÓM 4: BẢNG BÀN ĂN & THỰC ĐƠN (3 BẢNG)
-- ==============================================================

-- 4.1. Bảng Ban (Số thứ tự bàn, số người tối đa, 4 trạng thái bàn)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Ban')
BEGIN
    CREATE TABLE Ban (
        B_Ma INT IDENTITY(1,1) PRIMARY KEY,
        B_SoThuTu INT NOT NULL UNIQUE,
        B_TenBan NVARCHAR(50) NOT NULL,
        B_SoNguoiToiDa INT NOT NULL DEFAULT 4,
        B_TrangThai INT DEFAULT 0, -- 0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong
        B_Xoa BIT DEFAULT 0
    );
END
GO

-- 4.2. Bảng DanhMuc (Phân loại món ăn / nước uống)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'DanhMuc')
BEGIN
    CREATE TABLE DanhMuc (
        DM_Ma INT IDENTITY(1,1) PRIMARY KEY,
        DM_Ten NVARCHAR(100) NOT NULL,
        DM_MoTa NVARCHAR(255) NULL,
        DM_Xoa BIT DEFAULT 0
    );
END
GO

-- 4.3. Bảng MonAn (Thông tin món ăn/nước uống, giá bán & cờ báo hết món)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'MonAn')
BEGIN
    CREATE TABLE MonAn (
        MA_Ma INT IDENTITY(1,1) PRIMARY KEY,
        MA_Ten NVARCHAR(100) NOT NULL,
        MA_DanhMuc INT NOT NULL,
        MA_DonGia DECIMAL(18, 2) NOT NULL DEFAULT 0,
        MA_HetMon BIT DEFAULT 0, -- 0: Còn món, 1: Hết món
        MA_MoTa NVARCHAR(255) NULL,
        MA_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_MonAn_DanhMuc FOREIGN KEY (MA_DanhMuc) REFERENCES DanhMuc(DM_Ma)
    );
END
GO

-- ==============================================================
-- NHÓM 5: BẢNG PHỤC VỤ, GỌI MÓN & HÓA ĐƠN (2 BẢNG)
-- ==============================================================

-- 5.1. Bảng HoaDon (Quản lý phiên phục vụ tại bàn, chuyển bàn, gộp bàn, thanh toán)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HoaDon')
BEGIN
    CREATE TABLE HoaDon (
        HD_Ma INT IDENTITY(1,1) PRIMARY KEY,
        HD_MaBan INT NOT NULL,
        HD_MaNVPhucVu INT NOT NULL,
        HD_SoLuongKhach INT NOT NULL DEFAULT 1,
        HD_ThoiGianVao DATETIME DEFAULT GETDATE(),
        HD_ThoiGianThanhToan DATETIME NULL,
        HD_TongTien DECIMAL(18, 2) DEFAULT 0,
        HD_TrangThai INT DEFAULT 0, -- 0: Đang phục vụ, 1: Đã thanh toán, 2: Đã gộp/hủy
        HD_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_HoaDon_Ban FOREIGN KEY (HD_MaBan) REFERENCES Ban(B_Ma),
        CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (HD_MaNVPhucVu) REFERENCES NhanVien(NV_Ma)
    );
END
GO

-- 5.2. Bảng ChiTietHoaDon (Từng lần gọi món, thứ tự thời gian chuyển xuống bếp & trạng thái món)
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ChiTietHoaDon')
BEGIN
    CREATE TABLE ChiTietHoaDon (
        CTHD_Ma INT IDENTITY(1,1) PRIMARY KEY,
        CTHD_MaHoaDon INT NOT NULL,
        CTHD_MaMonAn INT NOT NULL,
        CTHD_SoLuong INT NOT NULL DEFAULT 1,
        CTHD_DonGia DECIMAL(18, 2) NOT NULL DEFAULT 0,
        CTHD_GhiChu NVARCHAR(255) NULL,
        CTHD_ThoiGianGoi DATETIME DEFAULT GETDATE(),
        CTHD_TrangThaiMon INT DEFAULT 0, -- 0: Chờ thực hiện, 1: Đã nấu xong, 2: Đã mang ra, 3: Đã hủy
        CTHD_Xoa BIT DEFAULT 0,
        CONSTRAINT FK_ChiTietHoaDon_HoaDon FOREIGN KEY (CTHD_MaHoaDon) REFERENCES HoaDon(HD_Ma),
        CONSTRAINT FK_ChiTietHoaDon_MonAn FOREIGN KEY (CTHD_MaMonAn) REFERENCES MonAn(MA_Ma)
    );
END
GO
