# TÀI LIỆU CẤU TRÚC CƠ SỞ DỮ LIỆU (SQL SERVER 2022 DOCKER)
**Dự án:** Hệ thống Quản lý Quán ăn (Lập trình ứng dụng quản lý 1 - VB.NET)  
**Hệ quản trị CSDL:** Microsoft SQL Server 2022 Express (Docker)  
**Database:** `QuanLyQuanAnDB`  
**Chuỗi kết nối trong VB.NET:**
```vbnet
Dim connStr As String = "Server=localhost,1433;Database=QuanLyQuanAnDB;User Id=sa;Password=password123!;TrustServerCertificate=True;"
```

---

## 1. TỔNG QUAN 18 BẢNG THEO 5 PHÂN HỆ

| Phân hệ | Số bảng | Danh sách bảng |
| :--- | :---: | :--- |
| **1. Phân quyền & Tài khoản (RBAC)** | 5 | `TaiKhoan`, `VaiTro`, `Quyen`, `TaiKhoan_VaiTro`, `VaiTro_Quyen` |
| **2. Hồ sơ nhân sự & Dụng cụ** | 5 | `NhanVien`, `TrinhDoViTinh`, `NhanVien_ViTinh`, `DungCuTrangPhuc`, `NhanVien_DungCu` |
| **3. Ca làm việc & Chấm công** | 3 | `CaLamViec`, `LichLamViec`, `ChamCong` |
| **4. Bàn ăn & Thực đơn** | 3 | `Ban`, `DanhMuc`, `MonAn` |
| **5. Phục vụ, Gọi món & Hóa đơn** | 2 | `HoaDon`, `ChiTietHoaDon` |

---

## 2. CHI TIẾT CÁC BẢNG DỮ LIỆU

### Nhóm 1: Phân quyền & Tài khoản (RBAC)

#### 1. Bảng `TaiKhoan` (Tài khoản người dùng)
| Tên cột | Kiểu dữ liệu | Ràng buộc | Ý nghĩa |
| :--- | :--- | :--- | :--- |
| `TK_Ma` | INT IDENTITY(1,1) | PRIMARY KEY | Mã tài khoản tự tăng |
| `TK_TenDangNhap` | NVARCHAR(50) | NOT NULL UNIQUE | Tên đăng nhập |
| `TK_MatKhau` | NVARCHAR(100) | NOT NULL | Mật khẩu (băm MD5) |
| `TK_Xoa` | BIT | DEFAULT 0 | Đánh dấu xóa mềm |

#### 2. Bảng `VaiTro` (Danh mục vai trò)
- Các vai trò mặc định: `Chủ quán`, `Quản lý`, `Nhân viên phục vụ`, `Nhà bếp / Pha chế`.

#### 3. Bảng `Quyen` (Danh mục quyền chức năng)
- `Q_Tag` tương ứng với thuộc tính `Tag` trên Form Control WinForms để tự động bật/tắt quyền.

#### 4. Bảng `TaiKhoan_VaiTro` & `VaiTro_Quyen`
- Bảng trung gian giải quyết quan hệ N-N giữa Tài khoản - Vai trò và Vai trò - Quyền.

---

### Nhóm 2: Hồ sơ nhân sự & Dụng cụ

#### 5. Bảng `NhanVien`
| Tên cột | Kiểu dữ liệu | Ý nghĩa |
| :--- | :--- | :--- |
| `NV_Ma` | INT IDENTITY(1,1) | Khóa chính |
| `NV_HoTen` | NVARCHAR(100) | Họ tên nhân viên |
| `NV_GioiTinh` | NVARCHAR(10) | Giới tính (Nam/Nữ) |
| `NV_NgaySinh` | DATE | Ngày sinh |
| `NV_ViTri` | NVARCHAR(50) | Vị trí làm việc |
| `NV_DienThoai` | NVARCHAR(20) | Số điện thoại |
| `NV_DiaChi` | NVARCHAR(255) | Địa chỉ |
| `NV_CMND` | NVARCHAR(20) | CMND / CCCD |
| `NV_NgayBatDauLam`| DATE | Ngày vào làm |
| `NV_NgayThoiViec` | DATE | Ngày nghỉ việc |
| `NV_TrinhDoHocVan`| NVARCHAR(100) | Trình độ học vấn |
| `NV_NgoaiNgu` | NVARCHAR(200) | Trình độ ngoại ngữ |
| `NV_MaTaiKhoan` | INT | FK -> `TaiKhoan(TK_Ma)` |
| `NV_TrangThai` | NVARCHAR(30) | `Dang lam viec` / `Da nghi viec` |
| `NV_Xoa` | BIT | Đánh dấu xóa mềm |

#### 6. Bảng `TrinhDoViTinh` & `NhanVien_ViTinh`
- Quản lý các kỹ năng vi tính (`Word`, `Excel`, `Cài phần mềm`, `Khác`...) cho từng nhân viên.

#### 7. Bảng `DungCuTrangPhuc` & `NhanVien_DungCu`
- Quản lý danh mục và lịch sử cấp phát dụng cụ, đồng phục khi nhận việc và thu hồi khi nhân viên nghỉ việc.

---

### Nhóm 3: Ca làm việc & Chấm công

#### 8. Bảng `CaLamViec`
- Cố định 2 ca chính: Ca Sáng (`08:00:00` - `15:00:00`) và Ca Chiều Tối (`15:00:00` - `22:00:00`).
- Cột `CA_GioBatDau`, `CA_GioKetThuc` kiểu `TIME(0)` giúp tính toán chính xác số giờ làm và tiền lương.

#### 9. Bảng `LichLamViec`
- Quản lý trực tiếp xếp ca theo ngày cho nhân viên (`LLV_MaNV`, `LLV_MaCa`, `LLV_NgayLam`).

#### 10. Bảng `ChamCong`
- Lưu thời gian thực tế check-in/check-out (`CC_GioBatDau`, `CC_GioKetThuc`), cờ duyệt của quản lý (`CC_DaDuyet`, `CC_NguoiDuyet`).

---

### Nhóm 4: Bàn ăn & Thực đơn

#### 11. Bảng `Ban`
- Lưu số bàn, tên bàn, khu vực (Tầng trệt, VIP...), số khách tối đa và trạng thái (0: Trống, 1: Có khách, 2: Đặt trước).

#### 12. Bảng `DanhMuc` & `MonAn`
- Danh mục nhóm món (Món chính, Khai vị, Nước uống...).
- Bảng món ăn có trường `MA_HetMon` (BIT) để cảnh báo tức thì cho nhân viên phục vụ khi hết nguyên liệu.

---

### Nhóm 5: Phục vụ, Gọi món & Hóa đơn

#### 13. Bảng `HoaDon`
- `HD_MaBan`: Bàn đang phục vụ.
- `HD_MaNVPhucVu`: Nhân viên phục vụ phụ trách (dùng tính doanh số).
- `HD_MaHoaDonGop`: Khóa ngoại tự tham chiếu hỗ trợ nghiệp vụ gộp bàn / tách hóa đơn.
- `HD_PhuongThucThanhToan`: `Tien mat`, `Chuyen khoan`, `QR Code`.
- `HD_TongTien`, `HD_TrangThai` (0: Chưa thanh toán, 1: Đã thanh toán).

#### 14. Bảng `ChiTietHoaDon`
- Chi tiết từng món gọi của bàn: số lượng, đơn giá tại thời điểm gọi, ghi chú đặc biệt cho bếp (ít cay, không đường...), và `CTHD_TrangThaiMon` (0: Chờ nấu, 1: Đang nấu, 2: Đã nấu xong, 3: Đã mang lên bàn).
