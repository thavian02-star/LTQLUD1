# TÀI LIỆU CẤU TRÚC CƠ SỞ DỮ LIỆU MICROSOFT ACCESS (.MDB)
**Dự án:** Quản lý Quán ăn (Lập trình ứng dụng quản lý 1 - VB.NET)  
**Tập tin CSDL:** `QuanLyQuanAn.mdb`  
**Chuỗi kết nối trong VB.NET:**
```vbnet
Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\QuanLyQuanAn.mdb;"
' Hoặc dùng đường dẫn tuyệt đối:
' Dim connStr As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\wmwar\OneDrive\Desktop\DAQLUD1\QuanLyQuanAn.mdb;"
```

---

## 1. Bảng `NhanVien` (Quản lý hồ sơ nhân sự)
Lưu trữ thông tin tiếp nhận hồ sơ tuyển dụng và trạng thái làm việc/nghỉ việc theo đúng yêu cầu trang 1 & 2 của đề bài.

| Tên cột | Kiểu dữ liệu | Ý nghĩa | Ghi chú |
| :--- | :--- | :--- | :--- |
| **`MaNV`** | AUTOINCREMENT | Mã nhân viên (Khóa chính) | Tự tăng (Primary Key) |
| **`HoTen`** | TEXT(100) | Họ và tên nhân viên | Bắt buộc |
| **`GioiTinh`** | TEXT(10) | Giới tính | Nam / Nữ |
| **`NgaySinh`** | DATETIME | Ngày tháng năm sinh | |
| **`ViTri`** | TEXT(50) | Vị trí dự tuyển / làm việc | Phục vụ, Pha chế, Quản lý, Tiếp tân, Chủ quán |
| **`DienThoai`** | TEXT(20) | Số điện thoại liên lạc | |
| **`DiaChi`** | TEXT(255) | Địa chỉ thường trú/tạm trú | |
| **`CMND`** | TEXT(20) | Số CMND / CCCD | |
| **`NgayBatDauLam`** | DATETIME | Thời gian bắt đầu làm việc | |
| **`TenDangNhap`** | TEXT(50) | Tên đăng nhập phần mềm | Dùng cho `frmDangNhap` |
| **`MatKhau`** | TEXT(100) | Mật khẩu tài khoản | Hỗ trợ chức năng *Đổi mật khẩu* |
| **`TrangThai`** | TEXT(30) | Trạng thái nhân sự | `Đang làm việc` hoặc `Đã nghỉ việc` |
| **`DaXoa`** | YESNO | Đánh dấu xóa mềm | Mặc định `FALSE` (0: còn, -1: đã xóa) |

---

## 2. Bảng `TrinhDoViTinh` (Danh mục trình độ vi tính)
Đề bài quy định: *"Trình độ vi tính: có các lựa chọn sau (Word, Excel, Cài phần mềm, Khác) => danh sách này có thể thay đổi."*

| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| **`MaTD`** | AUTOINCREMENT | Mã trình độ (Khóa chính) |
| **`TenTrinhDo`** | TEXT(50) | Tên kỹ năng (`Word`, `Excel`, `Cài phần mềm`, `Khác`...) |
| **`DaXoa`** | YESNO | Đánh dấu xóa |

---

## 3. Bảng `NhanVien_ViTinh` (Bảng trung gian N - N)
Một nhân viên có thể có một hoặc nhiều kỹ năng vi tính khác nhau.

| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| **`ID`** | AUTOINCREMENT | Khóa chính tự tăng |
| **`MaNV`** | INT | Khóa ngoại tham chiếu `NhanVien(MaNV)` |
| **`MaTD`** | INT | Khóa ngoại tham chiếu `TrinhDoViTinh(MaTD)` |

---

## 4. Bảng `DungCuTrangPhuc` (Danh mục đồng phục & dụng cụ)
Đề bài quy định: *"Dụng cụ/trang phục nhận từ quán. Nhân viên nghỉ việc: đổi trạng thái, xóa lịch, trả trang phục/dụng cụ."*

| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| **`MaDC`** | AUTOINCREMENT | Mã dụng cụ/trang phục (Khóa chính) |
| **`TenDungCu`** | TEXT(100) | Tên đồ dùng (`Áo đồng phục`, `Tạp dề`, `Thẻ nhân viên`...) |
| **`SoLuongTong`** | INT | Tổng số lượng trong kho của quán |
| **`GhiChu`** | TEXT(255) | Ghi chú quy cách (size, màu sắc...) |
| **`DaXoa`** | YESNO | Đánh dấu xóa |

---

## 5. Bảng `NhanVien_DungCu` (Quản lý cấp phát & thu hồi)
Lưu chi tiết trang phục/dụng cụ từng nhân viên nhận khi vào làm và ngày trả lại khi nghỉ việc.

| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| **`MaPhieu`** | AUTOINCREMENT | Mã phiếu cấp phát (Khóa chính) |
| **`MaNV`** | INT | Khóa ngoại tham chiếu `NhanVien(MaNV)` |
| **`MaDC`** | INT | Khóa ngoại tham chiếu `DungCuTrangPhuc(MaDC)` |
| **`SoLuong`** | INT | Số lượng đã nhận |
| **`NgayNhan`** | DATETIME | Ngày nhận dụng cụ |
| **`DaTra`** | YESNO | Trạng thái đã trả (TRUE khi nghỉ việc) |
| **`NgayTra`** | DATETIME | Ngày trả lại cho quán |
| **`GhiChu`** | TEXT(255) | Tình trạng đồ khi trả |

---

## 6. Bảng `CaLamViec` (Danh mục ca & khung giờ)
Đề bài quy định: *"ngày chia 3 ca: 8g-13g, 12g-17g, 17g-22g hoặc 2 ca cố định 9h-16h, 16h-22h => số ca trong ngày và thời gian có thể thay đổi. Tính lương nhân viên phụ thuộc vào tổng số ca làm việc trong tháng."*

| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| **`MaCa`** | AUTOINCREMENT | Mã ca làm việc (Khóa chính) |
| **`TenCa`** | TEXT(50) | Tên ca (`Ca sáng`, `Ca chiều`, `Ca tối`...) |
| **`GioBatDau`** | TEXT(10) | Giờ bắt đầu (VD: `08:00`) |
| **`GioKetThuc`** | TEXT(10) | Giờ kết thúc (VD: `13:00`) |
| **`LuongMoiCa`** | DOUBLE | Mức lương cho 1 ca làm việc (để nhân với tổng số ca) |
| **`DaXoa`** | YESNO | Đánh dấu xóa |

---

## 7. Tài khoản mẫu có sẵn trong CSDL:
- **Chủ quán:** `chuquan` / `123456`
- **Nhân viên quản lý:** `quanly` / `123456`
- **Nhân viên phục vụ:** `phucvu` / `123456`
- **Nhân viên pha chế/bếp:** `nhabep` / `123456`
