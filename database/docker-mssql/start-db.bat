@echo off
title Khoi chay SQL Server 2022 Docker...
cd /d "%~dp0"
echo Dang kiem tra va khoi chay SQL Server Docker...
docker-compose down 2>nul
docker-compose up -d --build
echo.
echo ==============================================================
echo SQL Server dang khoi dong o cong 1433...
echo Database : QuanLyQuanAnDB
echo User     : sa
echo Password : password123!
echo Doi khoang 10-15 giay de SQL Server nap xong Database mau.
echo ==============================================================
pause
