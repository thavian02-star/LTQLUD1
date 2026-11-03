-- ==============================================================
-- CƠ SỞ DỮ LIỆU: HỆ THỐNG QUẢN LÝ QUÁN ĂN
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- ==============================================================

-- 1. Tạo Database nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyQuanAnDB')
BEGIN
    CREATE DATABASE [QuanLyQuanAnDB];
END
GO

USE [QuanLyQuanAnDB];
GO

-- 2. Bảng NhanVien
IF OBJECT_ID('NhanVien', 'U') IS NOT NULL DROP TABLE NhanVien;
GO

CREATE TABLE NhanVien (
    nv_ma INT IDENTITY(1,1) PRIMARY KEY,
    nv_ten NVARCHAR(100) NOT NULL,
    nv_dia_chi NVARCHAR(255),
    nv_gioi_tinh BIT DEFAULT 1,
    nv_xoa BIT DEFAULT 0
);
GO

-- 3. Bảng TaiKhoan
IF OBJECT_ID('TaiKhoan', 'U') IS NOT NULL DROP TABLE TaiKhoan;
GO

CREATE TABLE TaiKhoan (
    tk_ma INT IDENTITY(1,1) PRIMARY KEY,
    tk_tai_khoan NVARCHAR(50) NOT NULL UNIQUE,
    tk_mat_khau NVARCHAR(255) NOT NULL,
    tk_xoa BIT DEFAULT 0
);
GO
