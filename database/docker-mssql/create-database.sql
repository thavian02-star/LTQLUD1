CREATE DATABASE [dbtest]
COLLATE Latin1_General_100_CI_AS_SC_UTF8;
GO

USE [dbtest];
GO

CREATE TABLE NhaSanXuat (
    NSX_Ma INT NOT NULL IDENTITY,
    NSX_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    NSX_MoTa nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    NSX_Xoa BIT DEFAULT 0,
    PRIMARY KEY (NSX_Ma)
);
GO

CREATE TABLE DanhMuc (
    DM_Ma INT NOT NULL IDENTITY,
    DM_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    DM_MoTa nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    DM_Xoa BIT DEFAULT 0,
    PRIMARY KEY (DM_Ma)
);
GO

CREATE TABLE SanPham (
    SP_Ma INT NOT NULL IDENTITY,
    SP_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    SP_MoTa nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    SP_DanhMuc INT NOT NULL,
    SP_NhaSanXuat INT,
    SP_GiaNhap INT, 
    SP_GiaBan INT,
    SP_Xoa BIT DEFAULT 0,
    PRIMARY KEY (SP_Ma),
    FOREIGN KEY (SP_DanhMuc) REFERENCES DanhMuc(DM_Ma),
    FOREIGN KEY (SP_NhaSanXuat) REFERENCES NhaSanXuat(NSX_Ma)
);
GO

CREATE TABLE TaiKhoan (
    TK_Ma INT NOT NULL IDENTITY,
    TK_TenDangNhap nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    TK_MatKhau nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    TK_Xoa BIT DEFAULT 0,
    PRIMARY KEY (TK_Ma)
);
GO

CREATE TABLE NguoiDung (
    ND_Ma INT NOT NULL IDENTITY,
    ND_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    ND_DiaChi nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    ND_MaTaiKhoan INT,
    ND_Xoa BIT DEFAULT 0,
    PRIMARY KEY (ND_Ma),
    FOREIGN KEY (ND_MaTaiKhoan) REFERENCES TaiKhoan(TK_Ma)
);
GO

CREATE TABLE VaiTro (
    VT_Ma INT NOT NULL IDENTITY,
    VT_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    VT_Xoa BIT DEFAULT 0,
    PRIMARY KEY (VT_Ma)
);
GO

CREATE TABLE Quyen (
    Q_Ma INT NOT NULL IDENTITY,
    Q_Ten nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Q_Tag nvarchar(max) COLLATE Latin1_General_100_CI_AS_SC_UTF8,
    Q_Xoa BIT DEFAULT 0,
    PRIMARY KEY (Q_Ma)
);
GO

CREATE TABLE TaiKhoan_VaiTro (
    NDVT_Ma INT NOT NULL IDENTITY,
    NDVT_TaiKhoan INT NOT NULL,
    NDVT_VaiTro INT NOT NULL,
    NDVT_Xoa BIT DEFAULT 0,
    PRIMARY KEY (NDVT_Ma),
    FOREIGN KEY (NDVT_TaiKhoan) REFERENCES TaiKhoan(TK_Ma),
    FOREIGN KEY (NDVT_VaiTro) REFERENCES VaiTro(VT_Ma)
);
GO

CREATE TABLE VaiTro_Quyen (
    VTQ_Ma INT NOT NULL IDENTITY,
    VTQ_VaiTro INT NOT NULL,
    VTQ_Quyen INT NOT NULL,
    VTQ_Xoa BIT DEFAULT 0,
    PRIMARY KEY (VTQ_Ma),
    FOREIGN KEY (VTQ_VaiTro) REFERENCES VaiTro(VT_Ma),
    FOREIGN KEY (VTQ_Quyen) REFERENCES Quyen(Q_Ma)
);
GO

INSERT INTO [NhaSanXuat] (NSX_Ten, NSX_MoTa)
VALUES 
('Pepsico', ''),
('Cocacola', ''),
('Acecook', ''),
('Vina Acecook', ''); 
GO

INSERT INTO [DanhMuc] (DM_Ten, DM_MoTa)
VALUES 
('Nước ngọt', 'Các loại nước ngọt'),
('Mì gói', 'Các loại mì'); 
GO

INSERT INTO [SanPham] (SP_Ten, SP_MoTa, SP_DanhMuc, SP_NhaSanXuat, SP_GiaNhap, SP_GiaBan)
VALUES 
('Pepsi', '...', 1, 1, 8000, 10000),
('Coca', '...', 1, 2, 8000, 10000),
('Mì Hảo Hảo', '...', 2, 3, 5000, 7000),
('Mì Omachi', '...', 2, 4, 5000, 7000);
GO

-- Mat khau la: 123456
INSERT INTO [TaiKhoan] (TK_TenDangNhap, TK_MatKhau)
VALUES 
('tpl123', 'E10ADC3949BA59ABBE56E057F20F883E'),
('admin', 'E10ADC3949BA59ABBE56E057F20F883E');
GO

INSERT INTO [NguoiDung] (ND_Ten, ND_DiaChi, ND_MaTaiKhoan)
VALUES 
('tpl', 'hcm', 1),
('admin', 'hcm', 2);
GO

INSERT INTO [VaiTro] (VT_Ten)
VALUES 
('Nhân viên kinh doanh'),
('Quản trị viên'),
('Trưởng phòng kinh doanh');
GO

INSERT INTO [Quyen] (Q_Ten, Q_Tag)
VALUES 
('Danh mục - Xem', 'MHDanhMuc'),
('Danh mục - Thêm', 'MHDanhMuc'),
('Danh mục - Sửa', 'MHDanhMuc'),
('Danh mục - Xóa', 'MHDanhMuc'),
('Sản phẩm - Xem', 'MHSanPham'),
('Sản phẩm - Thêm', 'MHSanPham'),
('Sản phẩm - Sửa', 'MHSanPham'),
('Sản phẩm - Xóa', 'MHSanPham'),
('Người dùng - Xem', 'MHNguoiDung'),
('Người dùng - Thêm', 'MHNguoiDung'),
('Người dùng - Sửa', 'MHNguoiDung'),
('Người dùng - Xóa', 'MHNguoiDung'),
('DS đơn hàng - Duyệt', 'MHDSDonHang');
GO

INSERT INTO [TaiKhoan_VaiTro] (NDVT_TaiKhoan, NDVT_VaiTro)
VALUES 
(1, 1),
(2, 2);
GO

INSERT INTO [VaiTro_Quyen] (VTQ_VaiTro, VTQ_Quyen)
VALUES 
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(2, 3),
(2, 4),
(2, 9),
(2, 10),
(2, 11),
(2, 12),
(3, 5);
GO