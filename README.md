# ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN

**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (.NET 10.0 Windows Forms) + Microsoft SQL Server 2022 (Docker)  
**Kho lưu trữ (Repository):** [https://github.com/thavian02-star/LTQLUD1.git](https://github.com/thavian02-star/LTQLUD1.git)

---

## 🏛️ KIẾN TRÚC PHẦN MỀM (3-TIER ARCHITECTURE)

Hệ thống được thiết kế theo mô hình **3 lớp (3-Tier)** chuẩn:
- **Presentation Layer (GUI):** Xây dựng bằng Windows Forms trên .NET 10.0 (`Quanlyquanan`). Cung cấp giao diện trực quan cho 4 vai trò: *Chủ quán*, *Quản lý*, *Nhân viên phục vụ*, *Nhà bếp/Pha chế*.
- **Business Logic Layer (BUS):** Tiếp nhận dữ liệu từ GUI, kiểm tra tính hợp lệ (Validation) và áp dụng các luật nghiệp vụ (gọi món, đổi/gộp bàn, tính tiền, kiểm tra quyền hạn RBAC).
- **Data Access Layer (DAO / DTO):** Quản lý kết nối CSDL, thực thi truy vấn an toàn (chống SQL Injection), chuyển đổi dữ liệu thành các đối tượng DTO.
- **Database Server:** Hệ thống 18 bảng chuẩn hóa trên Microsoft SQL Server 2022 Express chạy bằng Docker container.

> 📖 **Xem chi tiết:** [Tài liệu Kiến trúc Hệ thống](docs/KIEN_TRUC_HE_THONG.md) & [Đặc tả Cơ sở Dữ liệu](docs/DATABASE_SCHEMA.md)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
DAQLUD1/
│
├── Quanlyquanan/                # Mã nguồn ứng dụng VB.NET Windows Forms (.NET 10.0)
│   ├── ApplicationEvents.vb     # Sự kiện vòng đời ứng dụng
│   ├── Form1.vb                 # Giao diện khởi động
│   ├── Quanlyquanan.slnx        # Solution file
│   └── Quanlyquanan.vbproj      # Cấu hình project VB.NET
│
├── database/                    # Tài nguyên Cơ sở dữ liệu Microsoft SQL Server 2022
│   └── docker-mssql/            # Môi trường Docker SQL Server Express
│       ├── Dockerfile           # Khởi tạo image SQL Server Express
│       ├── docker-compose.yml   # Cấu hình dịch vụ Docker MSSQL
│       ├── start-db.bat         # File 1-click khởi chạy SQL Server
│       ├── create-database.sql  # Script tạo 18 bảng CSDL QuanLyQuanAnDB
│       ├── seed-data.sql        # Nạp dữ liệu mẫu thực tế (chống trùng lặp)
│       ├── entrypoint.sh        # Khởi động dịch vụ SQL Server
│       └── run-initialization.sh# Tự động nạp CSDL & Seed data khi container khởi động
│
├── docs/                        # Tài liệu dự án
│   ├── Đồ án - Quan ly quan an 3.pdf  # Đề bài yêu cầu của giảng viên
│   ├── CHECKLIST_DO_AN.md       # Kế hoạch & tiến độ hoàn thành các giai đoạn đồ án
│   ├── KIEN_TRUC_HE_THONG.md    # Tài liệu đặc tả kiến trúc 3 lớp & luồng dữ liệu
│   ├── DATABASE_SCHEMA.md       # Đặc tả cấu trúc 18 bảng dữ liệu SQL Server
│   └── review/                  # Báo cáo đánh giá và rà soát kỹ thuật
│
├── .gitignore                   # Loại trừ file rác, file tạm và build artifacts
└── README.md                    # Hướng dẫn tổng quan dự án
```

---

## 🚀 HƯỚNG DẪN KHỞI CHẠY SQL SERVER (DOCKER)

1. Mở **Docker Desktop**.
2. Nhấp đúp chuột vào file: `database/docker-mssql/start-db.bat`
3. Đợi khoảng 10–15 giây để SQL Server hoàn tất tạo database `QuanLyQuanAnDB` và tự động nạp dữ liệu mẫu `seed-data.sql`.

### Thông tin kết nối:
- **Server:** `localhost,1433`
- **Database:** `QuanLyQuanAnDB`
- **User:** `sa`
- **Password:** `password123!`
- **Công cụ xem & quản trị:** DBeaver, Azure Data Studio hoặc SSMS.
