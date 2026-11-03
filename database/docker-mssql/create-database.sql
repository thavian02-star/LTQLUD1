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
