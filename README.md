# ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN

**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (Windows Forms) + Microsoft SQL Server 2022 (Docker)  
**Kho lưu trữ (Repository):** [https://github.com/thavian02-star/LTQLUD1.git](https://github.com/thavian02-star/LTQLUD1.git)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
DAQLUD1/
│
├── database/                    # Toàn bộ tài nguyên Cơ sở dữ liệu SQL Server
│   └── docker-mssql/            # Cấu hình Docker Microsoft SQL Server 2022
│       ├── Dockerfile           # Khởi tạo image SQL Server Express
│       ├── docker-compose.yml   # Cấu hình chạy dịch vụ 1 lệnh
│       ├── start-db.bat         # File click chạy nhanh SQL Server
│       ├── create-database.sql  # Script tạo toàn bộ bảng & nạp dữ liệu mẫu
│       ├── entrypoint.sh        # Khởi động dịch vụ SQL Server
│       └── run-initialization.sh# Tự động nạp CSDL khi container khởi động
│
├── docs/                        # Tài liệu phân tích và thiết kế phần mềm
│   ├── Đồ án - Quan ly quan an 3.pdf  # Đề bài yêu cầu của giảng viên
│   ├── CHECKLIST_DO_AN.md       # Kế hoạch chi tiết các giai đoạn hoàn thành đồ án
│   └── DATABASE_SCHEMA.md       # Đặc tả chi tiết cấu trúc các bảng CSDL SQL Server
│
├── src/                         # Mã nguồn ứng dụng Visual Basic .NET Windows Forms
│   └── .gitkeep
│
├── .gitignore                   # Loại trừ file rác, file tạm và build artifacts
└── README.md                    # Hướng dẫn tổng quan dự án
```

---

## 🚀 HƯỚNG DẪN KHỞI CHẠY SQL SERVER (DOCKER)

1. Đảm bảo máy tính đã bật **Docker Desktop**.
2. Chạy file `database/docker-mssql/start-db.bat`  
   *(Hoặc gõ lệnh trong terminal)*:
   ```powershell
   cd database/docker-mssql
   docker-compose up -d --build
   ```
3. Đợi khoảng 10–15 giây để SQL Server hoàn tất nạp database mẫu.

### Thông tin kết nối:
- **Server:** `localhost,1433`
- **Database:** `QuanLyQuanAnDB`
- **User:** `sa`
- **Password:** `password123!`
- **Công cụ xem & quản trị khuyên dùng:** DBeaver, Azure Data Studio hoặc SSMS.

---

## 🔑 KẾT NỐI DATABASE TRONG VB.NET

Sử dụng thư viện `System.Data.SqlClient`:

```vbnet
Imports System.Data.SqlClient

Public Module DatabaseHelper
    Public ReadOnly ConnectionString As String =
        "Server=localhost,1433;Database=QuanLyQuanAnDB;User Id=sa;Password=password123!;TrustServerCertificate=True;"

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function
End Module
```

### Tài khoản đăng nhập thử nghiệm (Mật khẩu: `123456`):
| Tài khoản | Vai trò | Chức năng chính |
| :--- | :--- | :--- |
| `chuquan` | Chủ quán | Full quyền hệ thống, xem tất cả báo cáo |
| `quanly` | Quản lý | Xếp lịch, duyệt chấm công, hỗ trợ phục vụ |
| `phucvu` | Nhân viên phục vụ | Xem bàn, đặt/đổi/hủy món, chuyển/gộp bàn, tính tiền |
| `nhabep` | Nhà bếp / Pha chế | Xem hàng đợi món, cập nhật nấu xong |
