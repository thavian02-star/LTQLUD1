# KẾ HOẠCH SPRINT: PHÂN HỆ ĐĂNG NHẬP (AUTH SPRINT PLAN)

**Dự án:** Hệ thống Quản lý Quán ăn (VB.NET WinForms - .NET 10.0)  
**Phân hệ:** `Features/Auth/` (Xác thực & Quản lý phiên)  
**Tài liệu tham chiếu:** [`KIEN_TRUC_HE_THONG.md`](KIEN_TRUC_HE_THONG.md) & [`MA_TRAN_PHAN_QUYEN.md`](MA_TRAN_PHAN_QUYEN.md)  

---

## 1. MỤC TIÊU SPRINT & ĐIỀU KIỆN HOÀN THÀNH (DEFINITION OF DONE)

- **Mục tiêu:** Xây dựng hoàn chỉnh luồng đăng nhập khép kín từ Giao diện (GUI) $\rightarrow$ Nghiệp vụ kiểm tra (BUS) $\rightarrow$ Truy vấn CSDL SQL Server (DAO) $\rightarrow$ Nạp phiên làm việc toàn cục (`Session`).
- **Thư mục triển khai:** `Quanlyquanan/Features/Auth/`
- **Tiêu chuẩn nghiệm thu (DoD):**
  1. Người dùng có thể nhập Tên đăng nhập và Mật khẩu.
  2. Bắt lỗi bỏ trống ô, lỗi sai tài khoản/mật khẩu với thông báo rõ ràng.
  3. Mật khẩu được băm một chiều bằng `MD5` trước khi so sánh với CSDL.
  4. Xác thực thành công với 4 vai trò mẫu: `chuquan`, `quanly`, `phucvu1`, `nhabep1` (mật khẩu mặc định: `123456`).
  5. Nạp chính xác thông tin nhân viên, vai trò và danh sách mã quyền `Q_Tag` vào lớp `Session`.
  6. Sau khi đăng nhập thành công, tự động chuyển tiếp tới màn hình chính và phân quyền động.

---

## 2. QUY TRÌNH 5 BƯỚC TRIỂN KHAI CHI TIẾT (STEP-BY-STEP)

```
┌────────────────────────────────────────────────────────────────────────┐
│                        LỘ TRÌNH 5 BƯỚC THỰC HIỆN                       │
│                                                                        │
│   Bước 1: DTO   ──►  Bước 2: DAO   ──►  Bước 3: BUS   ──►  Bước 4: GUI │
│  (Thực thể)         (Truy vấn DB)      (Nghiệp vụ)        (Giao diện)  │
│                                                                  │     │
│                                           Bước 5: Test & Đấu nối ◄─────┘
└────────────────────────────────────────────────────────────────────────┘
```

### BƯỚC 1: Xây dựng tầng DTO (Data Transfer Object) — `TaiKhoanDTO.vb`
- **Vị trí file:** `Quanlyquanan/Features/Auth/TaiKhoanDTO.vb`
- **Mục đích:** Đóng gói thông tin người dùng sau khi xác thực thành công.
- **Cấu trúc thuộc tính:**
  ```vbnet
  Public Class TaiKhoanDTO
      Public Property MaTaiKhoan As Integer      ' TK_Ma
      Public Property TenDangNhap As String      ' TK_TenDangNhap
      Public Property MaVaiTro As Integer        ' VT_Ma (1: Chủ quán, 2: Quản lý, 3: Phục vụ, 4: Bếp)
      Public Property TenVaiTro As String        ' VT_Ten
      Public Property MaNhanVien As Integer      ' NV_Ma
      Public Property HoTenNhanVien As String    ' NV_HoTen
  End Class
  ```

---

### BƯỚC 2: Xây dựng tầng DAO (Data Access Object) — `TaiKhoanDAO.vb`
- **Vị trí file:** `Quanlyquanan/Features/Auth/TaiKhoanDAO.vb`
- **Mục đích:** Tương tác trực tiếp với Microsoft SQL Server 2022 qua `KetNoiCSDL`.
- **Nhiệm vụ cụ thể (2 hàm cốt lõi):**
  1. `KiemTraDangNhap(tenDangNhap As String, matKhauMD5 As String) As TaiKhoanDTO`:
     - Câu lệnh SQL (sử dụng Parameter để chống SQL Injection):
       ```sql
       SELECT tk.TK_Ma, tk.TK_TenDangNhap, vt.VT_Ma, vt.VT_Ten, nv.NV_Ma, nv.NV_HoTen
       FROM TaiKhoan tk
       INNER JOIN TaiKhoan_VaiTro tkvt ON tk.TK_Ma = tkvt.TKVT_TaiKhoan AND tkvt.TKVT_Xoa = 0
       INNER JOIN VaiTro vt ON tkvt.TKVT_VaiTro = vt.VT_Ma AND vt.VT_Xoa = 0
       LEFT JOIN NhanVien nv ON tk.TK_Ma = nv.NV_MaTaiKhoan AND nv.NV_Xoa = 0
       WHERE tk.TK_TenDangNhap = @TenDangNhap 
         AND tk.TK_MatKhau = @MatKhau 
         AND tk.TK_Xoa = 0
       ```
     - Nếu tìm thấy dòng dữ liệu $\rightarrow$ Ánh xạ vào `TaiKhoanDTO` và trả về. Nếu không $\rightarrow$ Trả về `Nothing`.
  2. `LayDanhSachQuyen(maVaiTro As Integer) As List(Of String)`:
     - Câu lệnh SQL:
       ```sql
       SELECT q.Q_Tag
       FROM VaiTro_Quyen vtq
       INNER JOIN Quyen q ON vtq.VTQ_Quyen = q.Q_Ma AND q.Q_Xoa = 0
       WHERE vtq.VTQ_VaiTro = @MaVaiTro AND vtq.VTQ_Xoa = 0
       ```
     - Trả về danh sách chuỗi các mã quyền (ví dụ: `POS_SO_DO_BAN`, `CQ_BAO_CAO_THONG_KE`...).

---

### BƯỚC 3: Xây dựng tầng Nghiệp vụ BUS (Business Logic) — `AuthBUS.vb`
- **Vị trí file:** `Quanlyquanan/Features/Auth/AuthBUS.vb`
- **Mục đích:** Xử lý toàn bộ logic kiểm tra hợp lệ, mã hóa mật khẩu và nạp phiên làm việc.
- **Quy trình xử lý của phương thức `DangNhap(tenDangNhap, matKhauRaw, ByRef thongBaoLoi) As Boolean`:**
  1. **Validation:**
     - Nếu `String.IsNullOrWhiteSpace(tenDangNhap)` $\rightarrow$ Gán `thongBaoLoi = "Vui lòng nhập tên đăng nhập!"`, trả về `False`.
     - Nếu `String.IsNullOrWhiteSpace(matKhauRaw)` $\rightarrow$ Gán `thongBaoLoi = "Vui lòng nhập mật khẩu!"`, trả về `False`.
  2. **Băm mật khẩu:**
     - Gọi `Dim matKhauMD5 As String = MaHoaMD5.BamMD5(matKhauRaw.Trim())`.
  3. **Gọi DAO xác thực:**
     - Gọi `TaiKhoanDAO.KiemTraDangNhap(tenDangNhap.Trim(), matKhauMD5)`.
     - Nếu kết quả là `Nothing` $\rightarrow$ Gán `thongBaoLoi = "Tên đăng nhập hoặc mật khẩu không chính xác!"`, trả về `False`.
  4. **Khởi tạo Session toàn cục:**
     - Nạp dữ liệu vào `Core.Security.Session`:
       - `Session.MaTaiKhoan = dto.MaTaiKhoan`
       - `Session.TenDangNhap = dto.TenDangNhap`
       - `Session.MaVaiTro = dto.MaVaiTro`
       - `Session.TenVaiTro = dto.TenVaiTro`
       - `Session.MaNhanVien = dto.MaNhanVien`
       - `Session.HoTenNhanVien = dto.HoTenNhanVien`
       - `Session.DanhSachQuyen = TaiKhoanDAO.LayDanhSachQuyen(dto.MaVaiTro)`
     - Trả về `True`.

---

### BƯỚC 4: Thiết kế Giao diện WinForms (GUI) — `frmDangNhap`
- **Vị trí file:** `Quanlyquanan/Features/Auth/` (gồm `frmDangNhap.vb`, `frmDangNhap.Designer.vb`, `frmDangNhap.resx`).
- **Bố cục giao diện & Danh sách Controls:**
  | Tên Control | Loại Control | Thuộc tính quan trọng | Chức năng |
  | :--- | :--- | :--- | :--- |
  | `txtTenDangNhap` | `TextBox` | `MaxLength = 50` | Nhập tài khoản đăng nhập |
  | `txtMatKhau` | `TextBox` | `UseSystemPasswordChar = True` | Nhập mật khẩu bí mật |
  | `chkHienMatKhau` | `CheckBox` | `Text = "Hiện mật khẩu"` | Đổi `UseSystemPasswordChar` |
  | `btnDangNhap` | `Button` | `Text = "Đăng Nhập"`, gán làm `Form.AcceptButton` | Bấm hoặc nhấn `Enter` để đăng nhập |
  | `btnThoat` | `Button` | `Text = "Thoát"`, gán làm `Form.CancelButton` | Bấm hoặc nhấn `ESC` để thoát app |
  | `lblThongBaoLoi` | `Label` | `ForeColor = Red`, `Text = ""` | Hiển thị lỗi cảnh báo màu đỏ |
- **Các hàm xử lý sự kiện (Event Handlers):**
  - `btnDangNhap_Click`: Gọi `AuthBUS.DangNhap`. Nếu thành công: mở `frmMain` và ẩn Form đăng nhập (`Me.Hide()`).
  - `chkHienMatKhau_CheckedChanged`: Chuyển đổi giữa chế độ che mật khẩu (`●●●●`) và xem rõ văn bản.
  - `btnThoat_Click`: Xác nhận thoát và đóng ứng dụng (`Application.Exit()`).

---

### BƯỚC 5: Cấu hình Khởi động & Kịch bản Kiểm thử (Testing)
- **Cấu hình:** Đặt `frmDangNhap` làm Form khởi động ban đầu của ứng dụng trong file cấu hình `My Project/Application.myapp`.
- **Bảng kịch bản kiểm thử (Test Matrix):**

| Mã Test | Kịch bản kiểm thử | Dữ liệu kiểm thử | Kết quả mong đợi |
| :---: | :--- | :--- | :--- |
| **TC01** | Bỏ trống Tên đăng nhập | Username: `""`, Pass: `"123456"` | Hiện lỗi: *"Vui lòng nhập tên đăng nhập!"* |
| **TC02** | Bỏ trống Mật khẩu | Username: `"chuquan"`, Pass: `""` | Hiện lỗi: *"Vui lòng nhập mật khẩu!"* |
| **TC03** | Nhập sai mật khẩu | Username: `"chuquan"`, Pass: `"sai_pass"` | Hiện lỗi: *"Tên đăng nhập hoặc mật khẩu không chính xác!"* |
| **TC04** | Đăng nhập Chủ quán | Username: `"chuquan"`, Pass: `"123456"` | Đăng nhập thành công, `Session.MaVaiTro = 1`, sở hữu 12 quyền |
| **TC05** | Đăng nhập Quản lý | Username: `"quanly"`, Pass: `"123456"` | Đăng nhập thành công, `Session.MaVaiTro = 2`, có quyền duyệt công |
| **TC06** | Đăng nhập Phục vụ | Username: `"phucvu1"`, Pass: `"123456"` | Đăng nhập thành công, `Session.MaVaiTro = 3`, chỉ có quyền POS |
| **TC07** | Đăng nhập Nhà bếp | Username: `"nhabep1"`, Pass: `"123456"` | Đăng nhập thành công, `Session.MaVaiTro = 4`, chỉ có quyền xem bếp |
| **TC08** | Phím tắt bàn phím | Nhấn `Enter` khi đang ở ô mật khẩu | Tự động kích hoạt nút Đăng Nhập |
| **TC09** | Bật/tắt xem mật khẩu | Nhấp chọn checkbox `Hiện mật khẩu` | Mật khẩu chuyển đổi giữa dạng ký tự ẩn và rõ |
