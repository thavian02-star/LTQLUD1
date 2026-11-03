# ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN

**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (Windows Forms) + Microsoft SQL Server 2022 (Docker)  
**Kho lưu trữ (Repository):** [https://github.com/thavian02-star/LTQLUD1.git](https://github.com/thavian02-star/LTQLUD1.git)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
DAQLUD1/
│
├── database/                    # Tài nguyên Cơ sở dữ liệu SQL Server
│   └── docker-mssql/            # Cấu hình Docker Microsoft SQL Server 2022
│       ├── Dockerfile           # Khởi tạo image SQL Server Express
│       ├── docker-compose.yml   # Cấu hình dịch vụ Docker
│       ├── start-db.bat         # File click chạy nhanh SQL Server
│       ├── create-database.sql  # Script tạo Database rỗng QuanLyQuanAnDB
│       ├── entrypoint.sh        # Khởi động dịch vụ SQL Server
│       └── run-initialization.sh# Tự động nạp CSDL khi container khởi động
│
├── docs/                        # Tài liệu dự án
│   ├── Đồ án - Quan ly quan an 3.pdf  # Đề bài yêu cầu của giảng viên
│   └── CHECKLIST_DO_AN.md       # Kế hoạch chi tiết các giai đoạn hoàn thành đồ án
│
├── src/                         # Mã nguồn ứng dụng Visual Basic .NET Windows Forms
│   └── .gitkeep
│
├── .gitignore                   # Loại trừ file rác, file tạm và build artifacts
└── README.md                    # Hướng dẫn tổng quan dự án
```

---

## 🚀 HƯỚNG DẪN KHỞI CHẠY SQL SERVER (DOCKER)

1. Mở **Docker Desktop**.
2. Nhấp đúp chuột vào file: `database/docker-mssql/start-db.bat`
3. Đợi khoảng 10–15 giây để SQL Server hoàn tất tạo database rỗng `QuanLyQuanAnDB`.

### Thông tin kết nối:
- **Server:** `localhost,1433`
- **Database:** `QuanLyQuanAnDB`
- **User:** `sa`
- **Password:** `password123!`
- **Công cụ xem & quản trị:** DBeaver, Azure Data Studio hoặc SSMS.
