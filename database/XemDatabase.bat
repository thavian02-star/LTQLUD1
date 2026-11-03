@echo off
title Dang mo Database QuanLyQuanAn...
cd /d "%~dp0"
start "" "%SystemRoot%\SysWOW64\WindowsPowerShell\v1.0\powershell.exe" -ExecutionPolicy Bypass -WindowStyle Hidden -File "%~dp0scripts\viewer.ps1"
exit
