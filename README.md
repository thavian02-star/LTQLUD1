# ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN

**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (.NET 10.0 Windows Forms) + Microsoft SQL Server 2022 (Docker)  
**Kho lưu trữ (Repository):** [https://github.com/thavian02-star/LTQLUD1.git](https://github.com/thavian02-star/LTQLUD1.git)

---

## 🏛️ KIẾN TRÚC PHẦN MỀM (PACKAGE-BY-FEATURE / VERTICAL SLICES)

Hệ thống được tổ chức theo kiến trúc **Package-by-Feature (Vertical Slice Architecture)** trên nền tảng **3 lớp (3-Tier)**:
- **Core / Infrastructure:** Chứa các lớp nền tảng dùng chung:
  - `KetNoiCSDL`: Quản lý `SqlConnection`, thực thi câu lệnh SQL với `SqlParameter` chống SQL Injection.
  - `MaHoaMD5`: Hàm băm mật khẩu tài khoản người dùng chuẩn MD5.
  - `Session`: Lưu trữ thông tin tài khoản đang đăng nhập và nạp danh sách quyền (RBAC).
  - `PhanQuyenHelper`: Tự động duyệt và áp dụng quyền lên toàn bộ control trên Form theo mã `Q_Tag`.
- **Features (Các phân hệ chức năng khép kín):** Mỗi màn hình được gom trọn gói gồm Form (GUI), Quy tắc nghiệp vụ (BUS), Truy vấn dữ liệu (DAO) và Thực thể dữ liệu (DTO):
  - `Auth`: Đăng nhập & Đổi mật khẩu.
  - `BanAn_GoiMon`: Sơ đồ bàn ăn, chọn món, chuyển/gộp bàn, in hóa đơn.
  - `ThucDon`: Quản lý món ăn, nhóm món, cảnh báo hết hàng.
  - `NhaBep`: Hàng đợi chế biến món ăn theo thời gian thực (FIFO).
  - `NhanSu`: Tuyển dụng, hồ sơ nhân sự, kỹ năng vi tính và cấp phát đồng phục/dụng cụ.
  - `ChamCong_LichLam`: Phân ca làm việc, chấm công & duyệt công.
  - `BaoCao_ThongKe`: Thống kê doanh thu, số ca làm việc, lượng khách.
- **Database Server:** 18 bảng chuẩn hóa trên Microsoft SQL Server 2022 Express chạy bằng Docker container.

> 📖 **Xem chi tiết:** [Tài liệu Kiến trúc Hệ thống](docs/KIEN_TRUC_HE_THONG.md) | [Ma trận Phân quyền RBAC](docs/MA_TRAN_PHAN_QUYEN.md) | [Đặc tả Cơ sở Dữ liệu](docs/DATABASE_SCHEMA.md)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
DAQLUD1/
│
├── Quanlyquanan/                # Mã nguồn ứng dụng VB.NET Windows Forms (.NET 10.0)
│   ├── Core/                    # Nền tảng dùng chung (Database, Security, Helpers)
│   │   ├── Database/            # KetNoiCSDL.vb (Quản lý SqlConnection & ExecuteQuery)
│   │   ├── Security/            # MaHoaMD5.vb, Session.vb (Quản lý phiên đăng nhập & RBAC)
│   │   └── Helpers/             # PhanQuyenHelper.vb (Tự động quét Tag trên Form)
│   │
│   ├── Features/                # Gom trọn gói theo từng màn hình / phân hệ
│   │   ├── Auth/                # Đăng nhập & Đổi mật khẩu
│   │   ├── BanAn_GoiMon/        # Sơ đồ bàn, gọi món & in hóa đơn
│   │   ├── ThucDon/             # Quản lý thực đơn món ăn & danh mục
│   │   ├── NhaBep/              # Hàng đợi chế biến món của Bếp
│   │   ├── NhanSu/              # Quản lý hồ sơ nhân viên, vi tính, dụng cụ
│   │   ├── ChamCong_LichLam/    # Xếp ca làm việc & Chấm công
│   │   └── BaoCao_ThongKe/      # Báo cáo doanh thu & thống kê
│   │
│   ├── Form1.vb                 # Giao diện khởi động mặc định
│   ├── Quanlyquanan.slnx        # Solution file định dạng XML mới
│   └── Quanlyquanan.vbproj      # Cấu hình project VB.NET SDK-style
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
│   ├── KIEN_TRUC_HE_THONG.md    # Tài liệu đặc tả kiến trúc Package-by-Feature & luồng dữ liệu
│   ├── MA_TRAN_PHAN_QUYEN.md    # Bảng ma trận phân quyền 4 vai trò & mã Q_Tag
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
