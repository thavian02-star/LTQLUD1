-- ==============================================================
-- TÀI LIỆU THAM KHẢO TOÀN BỘ CẤU TRÚC BẢNG & DỮ LIỆU MẪU
-- Bạn có thể copy từng đoạn CREATE TABLE dưới đây vào DBeaver
-- để tạo từng bảng và quan sát theo ý muốn.
-- ==============================================================

USE [QuanLyQuanAnDB];
GO

-- ==============================================================
-- BƯỚC 1: NHÓM TÀI KHOẢN & PHÂN QUYỀN (RBAC)
-- ==============================================================

-- 1. Bảng Tài Khoản (Đăng nhập, lưu mật khẩu MD5)
CREATE TABLE TaiKhoan (
    TK_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TK_TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    TK_MatKhau NVARCHAR(100) NOT NULL,
    TK_Xoa BIT DEFAULT 0
);
GO

-- 2. Bảng Vai Trò (Chủ quán, Quản lý, Phục vụ, Nhà bếp)
CREATE TABLE VaiTro (
    VT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    VT_Ten NVARCHAR(50) NOT NULL,
    VT_Xoa BIT DEFAULT 0
);
GO

-- 3. Bảng Quyền (Q_Tag gắn với thuộc tính Tag của Control trên WinForms VB.NET)
CREATE TABLE Quyen (
    Q_Ma INT IDENTITY(1,1) PRIMARY KEY,
    Q_Ten NVARCHAR(100) NOT NULL,
    Q_Tag NVARCHAR(50) NOT NULL,
    Q_Xoa BIT DEFAULT 0
);
GO

-- 4. Bảng liên kết Tài Khoản - Vai Trò
CREATE TABLE TaiKhoan_VaiTro (
    TKVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TKVT_TaiKhoan INT NOT NULL FOREIGN KEY REFERENCES TaiKhoan(TK_Ma),
    TKVT_VaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(VT_Ma),
    TKVT_Xoa BIT DEFAULT 0
);
GO

-- 5. Bảng liên kết Vai Trò - Quyền
CREATE TABLE VaiTro_Quyen (
    VTQ_Ma INT IDENTITY(1,1) PRIMARY KEY,
    VTQ_VaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(VT_Ma),
    VTQ_Quyen INT NOT NULL FOREIGN KEY REFERENCES Quyen(Q_Ma),
    VTQ_Xoa BIT DEFAULT 0
);
GO

-- ==============================================================
-- BƯỚC 2: NHÓM NHÂN SỰ & TUYỂN DỤNG
-- ==============================================================

-- 6. Bảng Trình Độ Vi Tính (Word, Excel, Cài phần mềm, Khác...)
CREATE TABLE TrinhDoViTinh (
    TDVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TDVT_Ten NVARCHAR(50) NOT NULL,
    TDVT_Xoa BIT DEFAULT 0
);
GO

-- 7. Bảng Dụng Cụ / Trang Phục của quán
CREATE TABLE DungCuTrangPhuc (
    DC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    DC_Ten NVARCHAR(100) NOT NULL,
    DC_SoLuongTong INT DEFAULT 0,
    DC_GhiChu NVARCHAR(255),
    DC_Xoa BIT DEFAULT 0
);
GO

-- 8. Bảng Nhân Viên (đầy đủ các trường nghiệp vụ theo đề bài)
CREATE TABLE NhanVien (
    NV_Ma INT IDENTITY(1,1) PRIMARY KEY,
    NV_HoTen NVARCHAR(100) NOT NULL,
    NV_GioiTinh NVARCHAR(10),
    NV_NgaySinh DATE,
    NV_ViTri NVARCHAR(50) NOT NULL,
    NV_DienThoai NVARCHAR(20),
    NV_DiaChi NVARCHAR(255),
    NV_CMND NVARCHAR(20),
    NV_NgayBatDauLam DATE,
    NV_MaTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(TK_Ma),
    NV_TrangThai NVARCHAR(30) DEFAULT N'Đang làm việc',
    NV_Xoa BIT DEFAULT 0
);
GO

-- 9. Bảng Nhân Viên - Trình Độ Vi Tính (quan hệ N-N)
CREATE TABLE NhanVien_ViTinh (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NV_Ma INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    TDVT_Ma INT NOT NULL FOREIGN KEY REFERENCES TrinhDoViTinh(TDVT_Ma)
);
GO

-- 10. Bảng Nhân Viên - Dụng Cụ (cấp phát & thu hồi trang phục khi nghỉ việc)
CREATE TABLE NhanVien_DungCu (
    MP_Ma INT IDENTITY(1,1) PRIMARY KEY,
    NV_Ma INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    DC_Ma INT NOT NULL FOREIGN KEY REFERENCES DungCuTrangPhuc(DC_Ma),
    SoLuong INT DEFAULT 1,
    NgayNhan DATE,
    DaTra BIT DEFAULT 0,
    NgayTra DATE,
    GhiChu NVARCHAR(255)
);
GO

-- ==============================================================
-- BƯỚC 3: NHÓM CA LÀM, LỊCH LÀM VIỆC & CHẤM CÔNG
-- ==============================================================

-- 11. Bảng Ca Làm Việc (cấu hình linh hoạt các ca & mức lương ca)
CREATE TABLE CaLamViec (
    CA_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CA_Ten NVARCHAR(50) NOT NULL,
    CA_GioBatDau NVARCHAR(10),
    CA_GioKetThuc NVARCHAR(10),
    CA_LuongMoiCa DECIMAL(18,2) DEFAULT 0,
    CA_Xoa BIT DEFAULT 0
);
GO

-- 12. Bảng Lịch Làm Việc (xếp lịch theo tuần/tháng)
CREATE TABLE LichLamViec (
    LLV_Ma INT IDENTITY(1,1) PRIMARY KEY,
    LLV_MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    LLV_MaCa INT NOT NULL FOREIGN KEY REFERENCES CaLamViec(CA_Ma),
    LLV_NgayLam DATE NOT NULL,
    LLV_TrangThai NVARCHAR(30) DEFAULT N'Chờ làm việc',
    LLV_Xoa BIT DEFAULT 0
);
GO

-- 13. Bảng Chấm Công (Check-in, Check-out, Quản lý duyệt)
CREATE TABLE ChamCong (
    CC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CC_MaLich INT FOREIGN KEY REFERENCES LichLamViec(LLV_Ma),
    CC_MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    CC_GioBatDau DATETIME,
    CC_GioKetThuc DATETIME,
    CC_DaDuyet BIT DEFAULT 0,
    CC_Xoa BIT DEFAULT 0
);
GO

-- ==============================================================
-- BƯỚC 4: NHÓM BÀN ĂN & THỰC ĐƠN
-- ==============================================================

-- 14. Bảng Bàn Ăn (4 trạng thái: Trống, Có khách, Đang đợi món, Món đã xong)
CREATE TABLE Ban (
    B_Ma INT IDENTITY(1,1) PRIMARY KEY,
    B_SoThuTu INT NOT NULL UNIQUE,
    B_TenBan NVARCHAR(50) NOT NULL,
    B_SoNguoiToiDa INT DEFAULT 4,
    B_TrangThai INT DEFAULT 0,
    B_Xoa BIT DEFAULT 0
);
GO

-- 15. Bảng Danh Mục Món (Món khai vị, Món chính, Nước uống...)
CREATE TABLE DanhMuc (
    DM_Ma INT IDENTITY(1,1) PRIMARY KEY,
    DM_Ten NVARCHAR(100) NOT NULL,
    DM_MoTa NVARCHAR(255),
    DM_Xoa BIT DEFAULT 0
);
GO

-- 16. Bảng Món Ăn (có cờ MA_HetMon báo hết món khi khách đặt)
CREATE TABLE MonAn (
    MA_Ma INT IDENTITY(1,1) PRIMARY KEY,
    MA_Ten NVARCHAR(100) NOT NULL,
    MA_DanhMuc INT NOT NULL FOREIGN KEY REFERENCES DanhMuc(DM_Ma),
    MA_DonGia DECIMAL(18,2) NOT NULL,
    MA_HetMon BIT DEFAULT 0,
    MA_MoTa NVARCHAR(255),
    MA_Xoa BIT DEFAULT 0
);
GO

-- ==============================================================
-- BƯỚC 5: NHÓM PHỤC VỤ, ĐẶT MÓN & HÓA ĐƠN
-- ==============================================================

-- 17. Bảng Hóa Đơn (hỗ trợ chuyển bàn, gộp bàn)
CREATE TABLE HoaDon (
    HD_Ma INT IDENTITY(1,1) PRIMARY KEY,
    HD_MaBan INT NOT NULL FOREIGN KEY REFERENCES Ban(B_Ma),
    HD_MaNVPhucVu INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    HD_SoLuongKhach INT DEFAULT 1,
    HD_ThoiGianVao DATETIME DEFAULT GETDATE(),
    HD_ThoiGianThanhToan DATETIME,
    HD_TongTien DECIMAL(18,2) DEFAULT 0,
    HD_TrangThai INT DEFAULT 0,
    HD_Xoa BIT DEFAULT 0
);
GO

-- 18. Bảng Chi Tiết Hóa Đơn / Đặt Món (hàng đợi nhà bếp xem theo thời gian)
CREATE TABLE ChiTietHoaDon (
    CTHD_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CTHD_MaHoaDon INT NOT NULL FOREIGN KEY REFERENCES HoaDon(HD_Ma),
    CTHD_MaMonAn INT NOT NULL FOREIGN KEY REFERENCES MonAn(MA_Ma),
    CTHD_SoLuong INT NOT NULL DEFAULT 1,
    CTHD_DonGia DECIMAL(18,2) NOT NULL,
    CTHD_GhiChu NVARCHAR(255),
    CTHD_ThoiGianGoi DATETIME DEFAULT GETDATE(),
    CTHD_TrangThaiMon INT DEFAULT 0,
    CTHD_Xoa BIT DEFAULT 0
);
GO
