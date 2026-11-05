# KẾ HOẠCH SPRINT: PHÂN HỆ ĐỔI MẬT KHẨU (PASSWORD CHANGE SPRINT PLAN)

**Dự án:** Hệ thống Quản lý Quán ăn (VB.NET Windows Forms .NET 10.0 + SQL Server Docker)  
**Phân hệ:** `Features/Auth/` (Chức năng Cá nhân & Bảo mật tài khoản)  
**Tài liệu tham chiếu:** [`CHECKLIST_DO_AN.md`](../../CHECKLIST_DO_AN.md) (Mục 3.2), [`DATABASE_SCHEMA.md`](../../DATABASE_SCHEMA.md)  
**Mockup giao diện tương tác:** [`frmDoiMatKhau_mockup.html`](frmDoiMatKhau_mockup.html)  

---

## 1. MỤC TIÊU SPRINT & ĐIỀU KIỆN HOÀN THÀNH (DEFINITION OF DONE - DoD)

- **Mục tiêu:** Xây dựng màn hình popup đổi mật khẩu (`frmDoiMatKhau`) cho phép bất kỳ nhân viên nào đang đăng nhập vào hệ thống (Chủ quán, Quản lý, Phục vụ, Nhà bếp) có thể chủ động cập nhật mật khẩu mới của mình, tự động kiểm tra bảo mật và băm MD5 ghi xuống SQL Server Docker.
- **Vị trí file triển khai trong Solution:**
  - `Quanlyquanan/Features/Auth/frmDoiMatKhau.vb`
  - `Quanlyquanan/Features/Auth/frmDoiMatKhau.Designer.vb`
  - `Quanlyquanan/Features/Auth/frmDoiMatKhau.resx`
- **Tiêu chuẩn nghiệm thu (DoD):**
  1. **Hiển thị thông tin phiên:** Hiển thị rõ tên tài khoản và vai trò đang đăng nhập từ `Session` (Read-only, không cho sửa).
  2. **Giao diện Modal chuẩn:** Cửa sổ `FixedDialog`, kích thước `480 x 420 px`, mở chính giữa Form cha (`StartPosition = CenterParent`), có nút đóng [X], nút Lưu và nút Hủy.
  3. **Quy tắc kiểm tra hợp lệ (Validation):**
     - Mật khẩu cũ không được để trống và phải khớp với CSDL hiện tại.
     - Mật khẩu mới không được để trống và phải có ít nhất 6 ký tự (`length >= 6`).
     - Mật khẩu mới không được trùng với mật khẩu cũ.
     - Xác nhận mật khẩu mới phải khớp 100% với mật khẩu mới.
  4. **Bảo mật:**
     - Mặc định ẩn mật khẩu (`UseSystemPasswordChar = True`).
     - Có checkbox / nút toggle để hiển thị/ẩn mật khẩu khi cần kiểm tra.
     - Mật khẩu mới được băm MD5 một chiều trước khi gửi tới CSDL (`MaHoaMD5.BamMD5(...)`).
  5. **Tận dụng kiến trúc 3 lớp đã có:** Gọi trực tiếp hàm nghiệp vụ `AuthBUS.DoiMatKhau(...)` và `TaiKhoanDAO.DoiMatKhau(...)` đã viết sẵn.
  6. **Đấu nối điều hướng từ `frmMain`:** Khi click `btnDoiMatKhau` trên Sidebar của `frmMain`, hiển thị hộp thoại `frmDoiMatKhau.ShowDialog(Me)`.
  7. **Dọn dẹp bộ nhớ RAM:** Toàn bộ các ô nhập mật khẩu được xóa sạch (`Clear()`) sau khi đóng form hoặc khi đổi thành công.
  8. **Kiểm thử nghiệm thu:** Kiểm thử đổi mật khẩu thành công trên cả 4 vai trò và xác nhận đăng xuất rồi đăng nhập lại bằng mật khẩu mới thành công trên CSDL.

---

## 2. QUY TRÌNH 5 BƯỚC TRIỂN KHAI CHI TIẾT (STEP-BY-STEP)

```
┌────────────────────────────────────────────────────────────────────────┐
│                        LỘ TRÌNH 5 BƯỚC THỰC HIỆN                       │
│                                                                        │
│   Bước 1: Đặc tả UI ──► Bước 2: Thiết kế GUI ──► Bước 3: Logic & Check │
│   (UI Spec & Mockup)    (Designer.vb & resx)     (AuthBUS & Form.vb)   │
│                                                        │               │
│                                 Bước 5: Test & Commit ◄── Bước 4: Nối  │
│                                 (Nghiệm thu 4 vai trò)   (frmMain Click│
└────────────────────────────────────────────────────────────────────────┘
```

---

### BƯỚC 1: Đặc tả Bố cục Giao diện & Trạng thái Kiểm soát lỗi
- **File tài liệu:** `docs/features/doi_mat_khau/DOI_MAT_KHAU_UI_SPEC.md`
- **File mockup:** `docs/features/doi_mat_khau/frmDoiMatKhau_mockup.html`
- **Nội dung:**
  - Quy định chuẩn màu nhận diện: Header xanh `#2980B9`, Nút Lưu xanh dương `#2980B9`, Nút Hủy `#95A5A6`.
  - Đặc tả 3 trường nhập liệu: `txtMatKhauCu`, `txtMatKhauMoi`, `txtXacNhanMoi`.
  - Thanh đo độ mạnh mật khẩu trực quan (Password Strength: Yếu / Trung bình / Mạnh).
  - Khối nhãn lỗi `lblThongBaoLoi` màu đỏ viền hồng `#FECDD3`.

---

### BƯỚC 2: Thiết kế Giao diện `frmDoiMatKhau.Designer.vb`
- **Tạo các file:**
  - `Quanlyquanan/Features/Auth/frmDoiMatKhau.Designer.vb`
  - `Quanlyquanan/Features/Auth/frmDoiMatKhau.resx`
- **Thông số kỹ thuật Form:**
  - `FormBorderStyle`: `FixedDialog` (không cho kéo dãn kích thước).
  - `MaximizeBox`: `False`, `MinimizeBox`: `False`, `ShowInTaskbar`: `False`.
  - `StartPosition`: `CenterParent` (canh giữa cửa sổ `frmMain`).
  - `Size`: `480, 430`.
  - `AcceptButton`: `btnLuu` (cho phép nhấn phím `Enter` để lưu).
  - `CancelButton`: `btnHuy` (cho phép nhấn phím `Esc` để hủy).

---

### BƯỚC 3: Xây dựng Tầng Logic & Xử lý Sự kiện (`frmDoiMatKhau.vb`)
- **Tạo file:** `Quanlyquanan/Features/Auth/frmDoiMatKhau.vb`
- **Phương thức xử lý:**
  1. `frmDoiMatKhau_Load`:
     - Nạp thông tin tài khoản hiện tại từ `Session`: `lblCurrentAccount.Text = Session.TenDangNhap & " (" & Session.HoTenNhanVien & ")"`.
     - Hiển thị badge vai trò `lblCurrentRole.Text = Session.TenVaiTro.ToUpper()`.
     - Xóa trống 3 ô mật khẩu và ẩn nhãn lỗi. Focus sẵn vào `txtMatKhauCu`.
  2. `chkHienMatKhau_CheckedChanged`:
     - Nếu checked: Cả 3 ô set `UseSystemPasswordChar = False`.
     - Nếu unchecked: Cả 3 ô set `UseSystemPasswordChar = True`.
  3. `btnLuu_Click`:
     - Kiểm tra các ràng buộc đầu vào.
     - Gọi `AuthBUS.DoiMatKhau(txtMatKhauCu.Text, txtMatKhauMoi.Text, txtXacNhanMoi.Text, thongBaoLoi)`.
     - Nếu thành công: Hiển thị `MessageBox.Show("Đổi mật khẩu thành công!", ...)`, đặt `Me.DialogResult = DialogResult.OK` và đóng form.
     - Nếu thất bại: Hiển thị thông báo lên `lblThongBaoLoi` và chọn/focus vào ô nhập lỗi.
  4. `btnHuy_Click`:
     - Đặt `Me.DialogResult = DialogResult.Cancel` và gọi `Me.Close()`.
  5. `frmDoiMatKhau_FormClosed`:
     - Xóa sạch text của 3 TextBox trong bộ nhớ RAM (`txtMatKhauCu.Clear()`, `txtMatKhauMoi.Clear()`, `txtXacNhanMoi.Clear()`).

---

### BƯỚC 4: Đấu nối Sự kiện từ `frmMain.vb`
- **Cập nhật file:** `Quanlyquanan/Features/Main/frmMain.vb`
- **Xử lý sự kiện click:**
  ```vbnet
  Private Sub btnDoiMatKhau_Click(sender As Object, e As EventArgs) Handles btnDoiMatKhau.Click
      Using fDoiMK As New Features.Auth.frmDoiMatKhau()
          fDoiMK.ShowDialog(Me)
      End Using
  End Sub
  ```

---

### BƯỚC 5: Kiểm thử Nghiệm thu & Ghi nhận Git Commit
- **Kịch bản kiểm thử:**
  1. Đăng nhập bằng `chuquan` (mật khẩu `123456`).
  2. Mở hộp thoại Đổi mật khẩu từ Sidebar.
  3. Test các trường hợp lỗi: để trống, mật khẩu cũ sai, mật khẩu mới < 6 ký tự, xác nhận không khớp, mật khẩu mới trùng mật khẩu cũ.
  4. Đổi mật khẩu mới sang `Abc@123456`.
  5. Đăng xuất khỏi hệ thống.
  6. Đăng nhập lại bằng mật khẩu cũ (`123456`) $\rightarrow$ Báo sai.
  7. Đăng nhập lại bằng mật khẩu mới (`Abc@123456`) $\rightarrow$ Thành công!
  8. Trả lại mật khẩu mẫu `123456` để bảo đảm tính toàn vẹn của dữ liệu seed test.
- **Commit Git:** Tuân thủ quy tắc 2 phần:
  - `1. CHI TIET CACH LAM STEP-BY-STEP`
  - `2. KIEN THUC QUAN TRONG CAN NHO`

---

## 3. CHECKLIST THEO DÕI TIẾN ĐỘ SPRINT

- [x] **Bước 1:** PO duyệt Bản đặc tả UI (`DOI_MAT_KHAU_UI_SPEC.md`) và Mockup HTML (`frmDoiMatKhau_mockup.html`).
- [x] **Bước 2:** Tạo file thiết kế `frmDoiMatKhau.Designer.vb` và `frmDoiMatKhau.resx` — Đã biên dịch thành công (0 Warning, 0 Error).
- [x] **Bước 3:** Viết code xử lý logic `frmDoiMatKhau.vb` (Validation, hiển thị mật khẩu, gọi BUS) — Đã hoàn thành & build thành công.
- [ ] **Bước 4:** Đấu nối sự kiện mở form từ `btnDoiMatKhau` trên `frmMain`.
- [ ] **Bước 5:** Kiểm thử thực tế trên CSDL Docker và commit code theo quy chuẩn.
