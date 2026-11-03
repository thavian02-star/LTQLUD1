-- ==============================================================
-- CƠ SỞ DỮ LIỆU RỖNG: HỆ THỐNG QUẢN LÝ QUÁN ĂN
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- ==============================================================

-- 1. Tạo Database rỗng nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyQuanAnDB')
BEGIN
    CREATE DATABASE [QuanLyQuanAnDB];
END
GO

-- 2. Chọn Database để sẵn sàng thực hiện tạo từng bảng
USE [QuanLyQuanAnDB];
GO
