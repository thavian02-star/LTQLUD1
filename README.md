# ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN

**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (Windows Forms) + Microsoft Access (`.mdb`) / Microsoft SQL Server  
**Kho lưu trữ (Repository):** [https://github.com/thavian02-star/LTQLUD1.git](https://github.com/thavian02-star/LTQLUD1.git)

---

## 📁 CẤU TRÚC THƯ MỤC DỰ ÁN

```text
DAQLUD1/
│
├── database/                    # Toàn bộ tài nguyên Cơ sở dữ liệu
│   ├── QuanLyQuanAn.mdb         # File CSDL Microsoft Access chính (chứa bảng Nhân Viên, Ca Làm, ...)
│   ├── scripts/                 # Kịch bản sinh và bảo trì CSDL
│   │   └── create_access_db.ps1 # Script tự động khởi tạo database Access sạch kèm dữ liệu mẫu
│   └── docker-mssql/            # Cấu hình Docker Microsoft SQL Server 2022 (tùy chọn mở rộng)
│       ├── Dockerfile
│       ├── create-database.sql
│       ├── entrypoint.sh
│       └── run-initialization.sh
│
├── docs/                        # Tài liệu phân tích và thiết kế phần mềm
│   ├── Đồ án - Quan ly quan an 3.pdf  # Đề bài yêu cầu của giảng viên
│   ├── CHECKLIST_DO_AN.md       # Bảng kế hoạch chi tiết 5 giai đoạn hoàn thành đồ án
│   └── DATABASE_SCHEMA.md       # Đặc tả chi tiết cấu trúc các bảng CSDL
│
├── src/                         # Mã nguồn ứng dụng Visual Basic .NET Windows Forms
│   └── .gitkeep
│
├── .gitignore                   # Loại trừ file rác, file tạm và build artifacts
└── README.md                    # Hướng dẫn tổng quan dự án
```

---

## 🎯 CÁC QUY TRÌNH NGHIỆP VỤ CHÍNH

1. **Quy trình Phục vụ Khách hàng:**
   - Chọn bàn $\rightarrow$ Đặt món / Nước uống $\rightarrow$ Báo bếp chế biến $\rightarrow$ Bếp báo hoàn thành $\rightarrow$ Mang ra cho khách $\rightarrow$ Hỗ trợ Đổi món / Hủy món / Chuyển bàn / Gộp bàn $\rightarrow$ Tính tiền và in hóa đơn.
2. **Quy trình Quản lý Nhân sự & Lương:**
   - Tiếp nhận hồ sơ: Thông tin cá nhân, vị trí tuyển dụng, nhiều trình độ vi tính (*Word, Excel, Cài phần mềm...*).
   - Cấp phát đồng phục / trang phục quán.
   - Xếp lịch làm việc theo ca/tuần/tháng $\rightarrow$ Chấm công & Quản lý duyệt công $\rightarrow$ Tính lương theo tổng số ca làm.
   - Nghiệp vụ nghỉ việc: Đổi trạng thái, xóa lịch tương lai, xác nhận thu hồi dụng cụ/trang phục.
3. **Báo cáo & Thống kê dành cho Chủ quán:**
   - Doanh thu theo Tháng / Quý / Năm.
   - Thống kê lượng khách theo ca, theo nhân viên phục vụ, theo từng bàn.
   - Thống kê món ăn/nước uống bán chạy.
   - Thống kê số ca và bảng lương nhân viên.

---

## 🔑 KẾT NỐI DATABASE TRONG VB.NET

Sử dụng thư viện `System.Data.OleDb`:

```vbnet
Imports System.Data.OleDb

Public Module DatabaseHelper
    ' Kết nối với file database/QuanLyQuanAn.mdb
    Public ReadOnly ConnectionString As String =
        "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\..\..\..\database\QuanLyQuanAn.mdb;"

    Public Function GetConnection() As OleDbConnection
        Return New OleDbConnection(ConnectionString)
    End Function
End Module
```

### Tài khoản đăng nhập thử nghiệm:
| Tài khoản | Mật khẩu | Vị trí / Vai trò |
| :--- | :--- | :--- |
| `chuquan` | `123456` | Chủ quán |
| `quanly` | `123456` | Nhân viên quản lý |
| `phucvu` | `123456` | Nhân viên phục vụ |
| `nhabep` | `123456` | Nhân viên pha chế / bếp |
