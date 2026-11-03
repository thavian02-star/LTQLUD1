#!/bin/bash
# Vong lap cho toi da 120 giay cho den khi SQL Server thuc su san sang nhan ket noi
echo "Bat dau tien trinh khoi tao co so du lieu..."
for i in {1..60}; do
    /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P password123! -C -Q "SELECT 1" > /dev/null 2>&1
    if [ $? -eq 0 ]; then
        echo "SQL Server da san sang! Dang chay file create-database.sql..."
        /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P password123! -d master -i /usr/src/app/create-database.sql -C
        echo "Khoi tao CSDL QuanLyQuanAnDB hoan tat!"
        break
    fi
    echo "Dang cho SQL Server khoi dong... ($i/60)"
    sleep 2
done
