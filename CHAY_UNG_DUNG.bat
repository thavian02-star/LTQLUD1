@echo off
chcp 65001 >nul
title HỆ THỐNG QUẢN LÝ QUÁN ĂN - WINFORMS .NET 10
cd /d "%~dp0"
echo ========================================================
echo   ĐANG KHỞI CHẠY HỆ THỐNG QUẢN LÝ QUÁN ĂN (WINFORMS)
echo ========================================================
echo.
echo [Mẹo đăng nhập Demo]:
echo   - Tài khoản: admin (hoặc chuquan)
echo   - Mật khẩu : 123456
echo.
dotnet run --project Quanlyquanan\Quanlyquanan.vbproj
pause
