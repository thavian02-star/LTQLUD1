-- ==============================================================
-- CƠ SỞ DỮ LIỆU: HỆ THỐNG QUẢN LÝ QUÁN ĂN (LẬP TRÌNH ỨNG DỤNG QUẢN LÝ 1)
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- ==============================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyQuanAnDB')
BEGIN
    CREATE DATABASE [QuanLyQuanAnDB];
END
GO

USE [QuanLyQuanAnDB];
GO

-- 1. BẢNG PHÂN QUYỀN & TÀI KHOẢN (RBAC)
IF OBJECT_ID('VaiTro_Quyen', 'U') IS NOT NULL DROP TABLE VaiTro_Quyen;
IF OBJECT_ID('TaiKhoan_VaiTro', 'U') IS NOT NULL DROP TABLE TaiKhoan_VaiTro;
IF OBJECT_ID('Quyen', 'U') IS NOT NULL DROP TABLE Quyen;
IF OBJECT_ID('VaiTro', 'U') IS NOT NULL DROP TABLE VaiTro;
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('MonAn', 'U') IS NOT NULL DROP TABLE MonAn;
IF OBJECT_ID('DanhMuc', 'U') IS NOT NULL DROP TABLE DanhMuc;
IF OBJECT_ID('Ban', 'U') IS NOT NULL DROP TABLE Ban;
IF OBJECT_ID('ChamCong', 'U') IS NOT NULL DROP TABLE ChamCong;
IF OBJECT_ID('LichLamViec', 'U') IS NOT NULL DROP TABLE LichLamViec;
IF OBJECT_ID('CaLamViec', 'U') IS NOT NULL DROP TABLE CaLamViec;
IF OBJECT_ID('NhanVien_DungCu', 'U') IS NOT NULL DROP TABLE NhanVien_DungCu;
IF OBJECT_ID('DungCuTrangPhuc', 'U') IS NOT NULL DROP TABLE DungCuTrangPhuc;
IF OBJECT_ID('NhanVien_ViTinh', 'U') IS NOT NULL DROP TABLE NhanVien_ViTinh;
IF OBJECT_ID('TrinhDoViTinh', 'U') IS NOT NULL DROP TABLE TrinhDoViTinh;
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;
GO

-- Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    TK_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TK_TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    TK_MatKhau NVARCHAR(100) NOT NULL, -- MD5 băm: 123456 -> E10ADC3949BA59ABBE56E057F20F883E
    TK_Xoa BIT DEFAULT 0
);
GO

-- Bảng Vai Trò (Chủ quán, Quản lý, Phục vụ, Nhà bếp/Pha chế)
CREATE TABLE VaiTro (
    VT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    VT_Ten NVARCHAR(50) NOT NULL,
    VT_Xoa BIT DEFAULT 0
);
GO

-- Bảng Quyền (Ánh xạ Q_Tag trực tiếp vào Tag của Control trên WinForms VB.NET)
CREATE TABLE Quyen (
    Q_Ma INT IDENTITY(1,1) PRIMARY KEY,
    Q_Ten NVARCHAR(100) NOT NULL,
    Q_Tag NVARCHAR(50) NOT NULL,
    Q_Xoa BIT DEFAULT 0
);
GO

-- Bảng Tài Khoản - Vai Trò
CREATE TABLE TaiKhoan_VaiTro (
    TKVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TKVT_TaiKhoan INT NOT NULL FOREIGN KEY REFERENCES TaiKhoan(TK_Ma),
    TKVT_VaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(VT_Ma),
    TKVT_Xoa BIT DEFAULT 0
);
GO

-- Bảng Vai Trò - Quyền
CREATE TABLE VaiTro_Quyen (
    VTQ_Ma INT IDENTITY(1,1) PRIMARY KEY,
    VTQ_VaiTro INT NOT NULL FOREIGN KEY REFERENCES VaiTro(VT_Ma),
    VTQ_Quyen INT NOT NULL FOREIGN KEY REFERENCES Quyen(Q_Ma),
    VTQ_Xoa BIT DEFAULT 0
);
GO

-- 2. BẢNG NHÂN SỰ & TUYỂN DỤNG
CREATE TABLE TrinhDoViTinh (
    TDVT_Ma INT IDENTITY(1,1) PRIMARY KEY,
    TDVT_Ten NVARCHAR(50) NOT NULL,
    TDVT_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE DungCuTrangPhuc (
    DC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    DC_Ten NVARCHAR(100) NOT NULL,
    DC_SoLuongTong INT DEFAULT 0,
    DC_GhiChu NVARCHAR(255),
    DC_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE NhanVien (
    NV_Ma INT IDENTITY(1,1) PRIMARY KEY,
    NV_HoTen NVARCHAR(100) NOT NULL,
    NV_GioiTinh NVARCHAR(10),
    NV_NgaySinh DATE,
    NV_ViTri NVARCHAR(50) NOT NULL, -- Nhân viên phục vụ, Nhân viên pha chế, Nhân viên quản lý, Nhân viên tiếp tân, Chủ quán
    NV_DienThoai NVARCHAR(20),
    NV_DiaChi NVARCHAR(255),
    NV_CMND NVARCHAR(20),
    NV_NgayBatDauLam DATE,
    NV_MaTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(TK_Ma),
    NV_TrangThai NVARCHAR(30) DEFAULT N'Đang làm việc', -- Đang làm việc / Đã nghỉ việc
    NV_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE NhanVien_ViTinh (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    NV_Ma INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    TDVT_Ma INT NOT NULL FOREIGN KEY REFERENCES TrinhDoViTinh(TDVT_Ma)
);
GO

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

-- 3. BẢNG CA LÀM VIỆC, XẾP LỊCH & CHẤM CÔNG
CREATE TABLE CaLamViec (
    CA_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CA_Ten NVARCHAR(50) NOT NULL,
    CA_GioBatDau NVARCHAR(10),
    CA_GioKetThuc NVARCHAR(10),
    CA_LuongMoiCa DECIMAL(18,2) DEFAULT 0,
    CA_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE LichLamViec (
    LLV_Ma INT IDENTITY(1,1) PRIMARY KEY,
    LLV_MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    LLV_MaCa INT NOT NULL FOREIGN KEY REFERENCES CaLamViec(CA_Ma),
    LLV_NgayLam DATE NOT NULL,
    LLV_TrangThai NVARCHAR(30) DEFAULT N'Chờ làm việc',
    LLV_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE ChamCong (
    CC_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CC_MaLich INT FOREIGN KEY REFERENCES LichLamViec(LLV_Ma),
    CC_MaNV INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    CC_GioBatDau DATETIME,
    CC_GioKetThuc DATETIME,
    CC_DaDuyet BIT DEFAULT 0, -- Quản lý bấm duyệt chấm công
    CC_Xoa BIT DEFAULT 0
);
GO

-- 4. BẢNG BÀN ĂN & THỰC ĐƠN
CREATE TABLE Ban (
    B_Ma INT IDENTITY(1,1) PRIMARY KEY,
    B_SoThuTu INT NOT NULL UNIQUE,
    B_TenBan NVARCHAR(50) NOT NULL,
    B_SoNguoiToiDa INT DEFAULT 4,
    B_TrangThai INT DEFAULT 0, -- 0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong
    B_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE DanhMuc (
    DM_Ma INT IDENTITY(1,1) PRIMARY KEY,
    DM_Ten NVARCHAR(100) NOT NULL,
    DM_MoTa NVARCHAR(255),
    DM_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE MonAn (
    MA_Ma INT IDENTITY(1,1) PRIMARY KEY,
    MA_Ten NVARCHAR(100) NOT NULL,
    MA_DanhMuc INT NOT NULL FOREIGN KEY REFERENCES DanhMuc(DM_Ma),
    MA_DonGia DECIMAL(18,2) NOT NULL,
    MA_HetMon BIT DEFAULT 0, -- Báo hết món khi khách đặt
    MA_MoTa NVARCHAR(255),
    MA_Xoa BIT DEFAULT 0
);
GO

-- 5. BẢNG PHỤC VỤ, ĐẶT MÓN (ORDER) & HÓA ĐƠN
CREATE TABLE HoaDon (
    HD_Ma INT IDENTITY(1,1) PRIMARY KEY,
    HD_MaBan INT NOT NULL FOREIGN KEY REFERENCES Ban(B_Ma),
    HD_MaNVPhucVu INT NOT NULL FOREIGN KEY REFERENCES NhanVien(NV_Ma),
    HD_SoLuongKhach INT DEFAULT 1,
    HD_ThoiGianVao DATETIME DEFAULT GETDATE(),
    HD_ThoiGianThanhToan DATETIME,
    HD_TongTien DECIMAL(18,2) DEFAULT 0,
    HD_TrangThai INT DEFAULT 0, -- 0: Đang phục vụ, 1: Đã thanh toán, 2: Đã chuyển/gộp
    HD_Xoa BIT DEFAULT 0
);
GO

CREATE TABLE ChiTietHoaDon (
    CTHD_Ma INT IDENTITY(1,1) PRIMARY KEY,
    CTHD_MaHoaDon INT NOT NULL FOREIGN KEY REFERENCES HoaDon(HD_Ma),
    CTHD_MaMonAn INT NOT NULL FOREIGN KEY REFERENCES MonAn(MA_Ma),
    CTHD_SoLuong INT NOT NULL DEFAULT 1,
    CTHD_DonGia DECIMAL(18,2) NOT NULL,
    CTHD_GhiChu NVARCHAR(255),
    CTHD_ThoiGianGoi DATETIME DEFAULT GETDATE(),
    CTHD_TrangThaiMon INT DEFAULT 0, -- 0: Chờ thực hiện (nhà bếp thấy), 1: Đã nấu xong, 2: Đã mang ra, 3: Đã hủy
    CTHD_Xoa BIT DEFAULT 0
);
GO

-- ==============================================================
-- NẠP DỮ LIỆU MẪU (SEED DATA)
-- ==============================================================

-- 1. Tài khoản (Mật khẩu mặc định: 123456 - Hash MD5: E10ADC3949BA59ABBE56E057F20F883E)
INSERT INTO TaiKhoan (TK_TenDangNhap, TK_MatKhau) VALUES
('chuquan', 'E10ADC3949BA59ABBE56E057F20F883E'),
('quanly', 'E10ADC3949BA59ABBE56E057F20F883E'),
('phucvu', 'E10ADC3949BA59ABBE56E057F20F883E'),
('nhabep', 'E10ADC3949BA59ABBE56E057F20F883E');
GO

-- 2. Vai trò
INSERT INTO VaiTro (VT_Ten) VALUES
(N'Chủ quán'),
(N'Quản lý'),
(N'Nhân viên phục vụ'),
(N'Nhà bếp / Pha chế');
GO

-- 3. Quyền hạn ứng dụng vào WinForms
INSERT INTO Quyen (Q_Ten, Q_Tag) VALUES
(N'Sơ đồ bàn & Gọi món', 'MHSoDoBan'),
(N'Đổi món / Hủy món', 'MHDoiMon'),
(N'Chuyển bàn & Gộp bàn', 'MHChuyenGopBan'),
(N'Tính tiền & In hóa đơn', 'MHThanhToan'),
(N'Hàng đợi Nhà bếp', 'MHNhaBep'),
(N'Quản lý Nhân viên', 'MHNhanVien'),
(N'Quản lý Bàn ghế', 'MHBanGhe'),
(N'Quản lý Thực đơn', 'MHThucDon'),
(N'Quản lý Lịch làm việc', 'MHLichLamViec'),
(N'Duyệt chấm công', 'MHDuyetChamCong'),
(N'Báo cáo Doanh thu', 'MHBaoCaoDoanhThu'),
(N'Báo cáo Lượng khách & Số ca', 'MHBaoCaoKhachCa');
GO

-- Gán vai trò cho tài khoản
INSERT INTO TaiKhoan_VaiTro (TKVT_TaiKhoan, TKVT_VaiTro) VALUES
(1, 1), -- chuquan -> Chủ quán
(2, 2), -- quanly -> Quản lý
(3, 3), -- phucvu -> Phục vụ
(4, 4); -- nhabep -> Nhà bếp
GO

-- Gán quyền cho vai trò
-- Chủ quán: Full quyền
INSERT INTO VaiTro_Quyen (VTQ_VaiTro, VTQ_Quyen)
SELECT 1, Q_Ma FROM Quyen;

-- Quản lý: Quyền phục vụ + Quản lý lịch + Duyệt công + Xem báo cáo
INSERT INTO VaiTro_Quyen (VTQ_VaiTro, VTQ_Quyen) VALUES
(2, 1), (2, 2), (2, 3), (2, 4), (2, 9), (2, 10), (2, 11), (2, 12);

-- Phục vụ: Sơ đồ bàn, gọi món, đổi/hủy món, chuyển/gộp bàn, tính tiền
INSERT INTO VaiTro_Quyen (VTQ_VaiTro, VTQ_Quyen) VALUES
(3, 1), (3, 2), (3, 3), (3, 4);

-- Nhà bếp: Hàng đợi bếp
INSERT INTO VaiTro_Quyen (VTQ_VaiTro, VTQ_Quyen) VALUES
(4, 5);
GO

-- 4. Trình độ vi tính (danh sách có thể thay đổi theo đề bài)
INSERT INTO TrinhDoViTinh (TDVT_Ten) VALUES
(N'Word'),
(N'Excel'),
(N'Cài phần mềm'),
(N'Khác');
GO

-- 5. Dụng cụ / Trang phục nhận từ quán
INSERT INTO DungCuTrangPhuc (DC_Ten, DC_SoLuongTong, DC_GhiChu) VALUES
(N'Áo đồng phục quán', 50, N'Size M, L, XL'),
(N'Tạp dề phục vụ', 30, N'Màu đen chống nước'),
(N'Thẻ nhân viên', 50, N'Thẻ từ chấm công');
GO

-- 6. Nhân viên mẫu
INSERT INTO NhanVien (NV_HoTen, NV_GioiTinh, NV_NgaySinh, NV_ViTri, NV_DienThoai, NV_DiaChi, NV_CMND, NV_NgayBatDauLam, NV_MaTaiKhoan, NV_TrangThai) VALUES
(N'Nguyễn Văn Chủ', N'Nam', '1985-05-15', N'Chủ quán', '0901234567', N'TP. Hồ Chí Minh', '079085001234', '2024-01-01', 1, N'Đang làm việc'),
(N'Trần Thị Quản Lý', N'Nữ', '1992-08-20', N'Nhân viên quản lý', '0912345678', N'TP. Hồ Chí Minh', '079192005678', '2024-02-01', 2, N'Đang làm việc'),
(N'Lê Văn Phục Vụ', N'Nam', '2002-11-10', N'Nhân viên phục vụ', '0987654321', N'TP. Hồ Chí Minh', '079202009876', '2024-06-15', 3, N'Đang làm việc'),
(N'Phạm Văn Bếp', N'Nam', '1995-03-25', N'Nhân viên pha chế', '0933445566', N'TP. Hồ Chí Minh', '079195004321', '2024-03-01', 4, N'Đang làm việc');
GO

-- Gán kỹ năng vi tính cho nhân viên
INSERT INTO NhanVien_ViTinh (NV_Ma, TDVT_Ma) VALUES
(1, 1), (1, 2), -- Chủ quán: Word, Excel
(2, 1), (2, 2), -- Quản lý: Word, Excel
(3, 4);         -- Phục vụ: Khác
GO

-- Cấp phát dụng cụ mẫu cho nhân viên phục vụ
INSERT INTO NhanVien_DungCu (NV_Ma, DC_Ma, SoLuong, NgayNhan, DaTra) VALUES
(3, 1, 2, '2024-06-15', 0),
(3, 2, 1, '2024-06-15', 0),
(3, 3, 1, '2024-06-15', 0);
GO

-- 7. Ca làm việc (3 ca linh hoạt theo đề bài)
INSERT INTO CaLamViec (CA_Ten, CA_GioBatDau, CA_GioKetThuc, CA_LuongMoiCa) VALUES
(N'Ca sáng', '08:00', '13:00', 150000),
(N'Ca chiều', '12:00', '17:00', 150000),
(N'Ca tối', '17:00', '22:00', 170000);
GO

-- 8. Bàn ăn mẫu (10 bàn)
INSERT INTO Ban (B_SoThuTu, B_TenBan, B_SoNguoiToiDa, B_TrangThai) VALUES
(1, N'Bàn 01', 4, 0),
(2, N'Bàn 02', 4, 0),
(3, N'Bàn 03', 2, 0),
(4, N'Bàn 04', 6, 0),
(5, N'Bàn 05', 8, 0),
(6, N'Bàn 06', 4, 0),
(7, N'Bàn 07', 4, 0),
(8, N'Bàn 08', 2, 0),
(9, N'Bàn 09', 10, 0),
(10, N'Bàn 10', 4, 0);
GO

-- 9. Danh mục & Món ăn
INSERT INTO DanhMuc (DM_Ten, DM_MoTa) VALUES
(N'Món khai vị', N'Các món khai vị nhẹ nhàng'),
(N'Món chính', N'Các món chính đậm đà'),
(N'Nước uống', N'Nước ngọt và trà');
GO

INSERT INTO MonAn (MA_Ten, MA_DanhMuc, MA_DonGia, MA_HetMon, MA_MoTa) VALUES
(N'Khoai tây chiên', 1, 35000, 0, N'Giòn rụm kèm tương cà'),
(N'Salad cá ngừ', 1, 45000, 0, N'Rau tươi sốt mè rang'),
(N'Bò bít tết sốt tiêu đen', 2, 120000, 0, N'Bò mềm ăn kèm bánh mì'),
(N'Cơm chiên hải sản', 2, 65000, 0, N'Cơm hạt vàng kèm tôm mực'),
(N'Mì Ý bò bằm sốt cà', 2, 70000, 0, N'Sốt cà chua nguyên chất'),
(N'Trà đào cam sả', 3, 30000, 0, N'Nước uống thanh mát'),
(N'Coca Cola', 3, 15000, 0, N'Lon 330ml'),
(N'Pepsi không calo', 3, 15000, 0, N'Lon 330ml');
GO
