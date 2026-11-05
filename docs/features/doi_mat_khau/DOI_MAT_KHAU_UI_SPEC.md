# ĐẶC TẢ GIAO DIỆN MÀN HÌNH ĐỔI MẬT KHẨU (UI / UX SPECIFICATION)

**Tên Form:** `frmDoiMatKhau`  
**Package / Namespace:** `Quanlyquanan.Features.Auth`  
**Kế thừa:** `System.Windows.Forms.Form`  
**File Mockup tham chiếu:** [`frmDoiMatKhau_mockup.html`](frmDoiMatKhau_mockup.html)  

---

## 1. THÔNG SỐ CỬA SỔ FORM (FORM PROPERTIES)

| Thuộc tính | Giá trị thiết lập | Mục đích |
| :--- | :--- | :--- |
| `Text` | `Đổi Mật Khẩu - Quản Lý Quán Ăn` | Tiêu đề thanh tiêu đề Windows |
| `FormBorderStyle` | `FixedDialog` | Khóa kéo dãn kích thước, tạo cảm giác popup gọn gàng |
| `StartPosition` | `CenterParent` | Luôn hiển thị chính giữa cửa sổ `frmMain` |
| `ClientSize` | `480, 420` | Tỷ lệ chuẩn cho form 3 trường nhập liệu |
| `MaximizeBox` | `False` | Ẩn nút phóng to toàn màn hình |
| `MinimizeBox` | `False` | Ẩn nút thu nhỏ |
| `ShowInTaskbar` | `False` | Không tạo thêm icon riêng dưới thanh Taskbar của Windows |
| `AcceptButton` | `btnLuu` | Nhấn phím `Enter` tự động kích hoạt Lưu |
| `CancelButton` | `btnHuy` | Nhấn phím `Esc` tự động đóng/hủy form |
| `Font` | `Segoe UI, 9pt` | Đồng bộ font hệ thống hiện đại |
| `BackColor` | `Color.White` | Nền trắng sạch sẽ, trang nhã |

---

## 2. BỐ CỤC KHÔNG GIAN (LAYOUT ARCHITECTURE)

Form được chia làm 3 khu vực chính theo chiều dọc (`DockStyle`):

```
┌────────────────────────────────────────────────────────┐
│  pnlHeader (Dock = Top, Height = 70px)                 │
│  [🔐] ĐỔI MẬT KHẨU TÀI KHOẢN                           │
│       Nhập mật khẩu hiện tại và tạo mật khẩu mới       │
├────────────────────────────────────────────────────────┤
│  pnlBody (Dock = Fill, Padding = 20px)                 │
│                                                        │
│  [👤 chuquan (Nguyễn Hoàng Nam)]   [ CHỦ QUÁN ]        │
│                                                        │
│  [⚠️ Thông báo lỗi nếu có...]                         │
│                                                        │
│  Mật khẩu cũ (hiện tại) *                              │
│  [••••••••••••••••••••••••]                            │
│                                                        │
│  Mật khẩu mới *                                        │
│  [••••••••••••••••••••••••]                            │
│  ─── Độ mạnh: [Trung bình] (≥ 6 ký tự)                 │
│                                                        │
│  Xác nhận mật khẩu mới *                               │
│  [••••••••••••••••••••••••]                            │
│                                                        │
│  [x] Hiển thị tất cả mật khẩu                          │
│                                                        │
├────────────────────────────────────────────────────────┤
│  pnlFooter (Dock = Bottom, Height = 56px)              │
│                          [❌ Hủy Bỏ]  [💾 Lưu Mới]     │
└────────────────────────────────────────────────────────┘
```

---

## 3. DANH SÁCH CONTROL & THÔNG SỐ CHI TIẾT

### 3.1. Vùng Header (`pnlHeader`)
- **`pnlHeader`**: `BackColor = #2980B9`, `ForeColor = White`, `Height = 70`.
- **`lblHeaderIcon`**: Text `🔐` hoặc icon khóa, Font `20pt`.
- **`lblHeaderTitle`**: Text `ĐỔI MẬT KHẨU TÀI KHOẢN`, Font `Segoe UI, 11pt, Bold`.
- **`lblHeaderSubtitle`**: Text `Nhập mật khẩu hiện tại và tạo mật khẩu mới để bảo mật`, Font `Segoe UI, 8.5pt`, Color `#D6EAF8`.

### 3.2. Vùng Thân Form (`pnlBody`)
- **`pnlUserInfo`**: Panel thông tin người dùng:
  - `lblCurrentAccount`: Hiển thị `chuquan (Nguyễn Hoàng Nam)`, Font `Segoe UI, 9pt, Bold`.
  - `lblCurrentRole`: Huy hiệu vai trò bo tròn (Badge), Background theo vai trò (Chủ quán: `#F39C12`, Quản lý: `#9B59B6`, Phục vụ: `#2ECC71`, Nhà bếp: `#E67E22`).
- **`lblThongBaoLoi`**:
  - `BackColor = #FEF2F2`, `ForeColor = #991B1B`, `Border = 1px solid #FECDD3`.
  - Mặc định: `Visible = False`.
- **`txtMatKhauCu`**:
  - `UseSystemPasswordChar = True`.
  - Label: `Mật khẩu cũ (hiện tại) *`.
- **`txtMatKhauMoi`**:
  - `UseSystemPasswordChar = True`.
  - Label: `Mật khẩu mới *`.
- **`txtXacNhanMoi`**:
  - `UseSystemPasswordChar = True`.
  - Label: `Xác nhận mật khẩu mới *`.
- **`chkHienMatKhau`**:
  - Text: `Hiển thị mật khẩu`.
  - Khi tick chọn: Đổi đồng thời `UseSystemPasswordChar = False` cho cả 3 ô nhập.

### 3.3. Vùng Nút Thao Tác (`pnlFooter`)
- **`pnlFooter`**: `BackColor = #F8FAFC`, `Height = 56`, có viền trên `1px solid #E2E8F0`.
- **`btnLuu`**:
  - Text: `💾  Lưu Mật Khẩu`.
  - `BackColor = #2980B9`, `ForeColor = White`, `FlatStyle = Flat`.
  - Kích thước: `140, 36`.
- **`btnHuy`**:
  - Text: `❌  Hủy Bỏ`.
  - `BackColor = #E2E8F0`, `ForeColor = #475569`, `FlatStyle = Flat`.
  - Kích thước: `100, 36`.

---

## 4. MA TRẬN PHÍM TẮT & TRẢI NGHIỆM NGƯỜI DÙNG (UX)

| Thao tác | Phím tắt | Hành vi hệ thống |
| :--- | :---: | :--- |
| Mở form | — | Con trỏ chuột tự động focus vào ô `txtMatKhauCu` |
| Di chuyển giữa các ô | `Tab` / `Shift+Tab` | Tuần tự: Mật khẩu cũ ➔ Mật khẩu mới ➔ Xác nhận ➔ Checkbox ➔ Nút Lưu ➔ Nút Hủy |
| Lưu thay đổi | `Enter` | Kích hoạt sự kiện của nút `btnLuu` (qua `AcceptButton`) |
| Hủy bỏ & Thoát | `Esc` | Kích hoạt sự kiện của nút `btnHuy` (qua `CancelButton`), đóng form an toàn |
| Đổi thành công | — | Hiện `MessageBox` thông báo, đóng dialog với `DialogResult = OK` |

---

## 5. MA TRẬN TRẠNG THÁI KIỂM SOÁT LỖI (ERROR HANDLING MATRIX)

Hệ thống bắt lỗi theo mô hình nhiều lớp (Client-side validation tại GUI trước, sau đó tới Business validation tại `AuthBUS`, cuối cùng là Data Access exception handling):

| STT | Kịch bản / Trạng thái | Điều kiện kích hoạt | Thông điệp hiển thị trên `lblThongBaoLoi` | Hành vi UI & Focus |
| :---: | :--- | :--- | :--- | :--- |
| **ERR-01** | Chưa nhập mật khẩu cũ | `txtMatKhauCu.Text.Trim() = ""` | `⚠️ Vui lòng nhập mật khẩu cũ (hiện tại)!` | Focus vào `txtMatKhauCu`, hiện nhãn lỗi đỏ |
| **ERR-02** | Chưa nhập mật khẩu mới | `txtMatKhauMoi.Text.Trim() = ""` | `⚠️ Vui lòng nhập mật khẩu mới!` | Focus vào `txtMatKhauMoi`, hiện nhãn lỗi đỏ |
| **ERR-03** | Mật khẩu mới quá ngắn | `txtMatKhauMoi.Text.Length < 6` | `⚠️ Mật khẩu mới phải có ít nhất 6 ký tự!` | Focus vào `txtMatKhauMoi`, bôi đen toàn bộ text |
| **ERR-04** | Trùng mật khẩu cũ | `txtMatKhauMoi.Text = txtMatKhauCu.Text` | `⚠️ Mật khẩu mới không được trùng với mật khẩu cũ!` | Focus vào `txtMatKhauMoi`, bôi đen toàn bộ text |
| **ERR-05** | Xác nhận không khớp | `txtXacNhanMoi.Text <> txtMatKhauMoi.Text` | `⚠️ Mật khẩu mới và xác nhận mật khẩu không khớp!` | Focus vào `txtXacNhanMoi`, bôi đen toàn bộ text |
| **ERR-06** | Mật khẩu cũ không đúng | `TaiKhoanDAO.KiemTraDangNhap(...) = Nothing` | `⚠️ Mật khẩu cũ không chính xác!` | Focus vào `txtMatKhauCu`, bôi đen `txtMatKhauCu` |
| **ERR-07** | Mất kết nối CSDL Docker | SqlException (Timeout, Network down) | `⚠️ Không thể kết nối CSDL SQL Server Docker!` | Hiện nhãn lỗi, ghi log bắt lỗi trong khối `Try...Catch` |
| **ERR-08** | Lỗi cập nhật CSDL | `TaiKhoanDAO.DoiMatKhau(...) = False` | `⚠️ Có lỗi xảy ra khi cập nhật mật khẩu vào CSDL!` | Hiện nhãn lỗi, giữ nguyên nội dung để người dùng thử lại |
| **SUCCESS** | Đổi mật khẩu thành công | `TaiKhoanDAO.DoiMatKhau(...) = True` | `✅ Đổi mật khẩu thành công!` | Hiện `MessageBox.Show`, đặt `DialogResult = OK`, đóng Form |

---

## 6. BẢNG THÔNG SỐ TỌA ĐỘ VÀ TABINDEX (DESIGNER SPECS)

Bảng thông số chi tiết hỗ trợ triển khai chuẩn từng pixel trong file `frmDoiMatKhau.Designer.vb`:

| Tên Control (`Name`) | Loại Control (`Type`) | Tọa độ (`Location`) | Kích thước (`Size`) | `TabIndex` | Thuộc tính đặc biệt |
| :--- | :--- | :---: | :---: | :---: | :--- |
| `pnlHeader` | `Panel` | `0, 0` | `480, 70` | — | `Dock = Top`, `BackColor = #2980B9` |
| `lblHeaderIcon` | `Label` | `16, 12` | `46, 46` | — | `Font = 20pt`, Text: `🔐` |
| `lblHeaderTitle` | `Label` | `70, 15` | `380, 22` | — | `Font = 11pt, Bold`, Text: `ĐỔI MẬT KHẨU TÀI KHOẢN` |
| `lblHeaderSubtitle` | `Label` | `70, 39` | `380, 18` | — | `Font = 8.5pt`, Color: `#D6EAF8` |
| `pnlBody` | `Panel` | `0, 70` | `480, 294` | — | `Dock = Fill`, `Padding = 20, 15, 20, 10` |
| `pnlUserInfo` | `Panel` | `24, 12` | `432, 38` | — | `BackColor = #F1F5F9`, `BorderStyle = FixedSingle` |
| `lblCurrentAccount` | `Label` | `10, 9` | `300, 20` | — | `Font = 9pt, Bold`, Text: `👤 ...` |
| `lblCurrentRole` | `Label` | `320, 7` | `100, 22` | — | `TextAlign = MiddleCenter`, Badge màu |
| `lblThongBaoLoi` | `Label` | `24, 56` | `432, 28` | — | `Visible = False`, `BackColor = #FEF2F2` |
| `lblMatKhauCu` | `Label` | `24, 90` | `432, 18` | — | Text: `Mật khẩu cũ (hiện tại) *` |
| `txtMatKhauCu` | `TextBox` | `24, 110` | `432, 28` | `0` | `UseSystemPasswordChar = True` |
| `lblMatKhauMoi` | `Label` | `24, 146` | `432, 18` | — | Text: `Mật khẩu mới * (≥ 6 ký tự)` |
| `txtMatKhauMoi` | `TextBox` | `24, 166` | `432, 28` | `1` | `UseSystemPasswordChar = True` |
| `lblXacNhanMoi` | `Label` | `24, 202` | `432, 18` | — | Text: `Xác nhận mật khẩu mới *` |
| `txtXacNhanMoi` | `TextBox` | `24, 222` | `432, 28` | `2` | `UseSystemPasswordChar = True` |
| `chkHienMatKhau` | `CheckBox` | `24, 258` | `260, 22` | `3` | Text: `Hiển thị tất cả mật khẩu` |
| `pnlFooter` | `Panel` | `0, 364` | `480, 56` | — | `Dock = Bottom`, `BackColor = #F8FAFC` |
| `btnHuy` | `Button` | `224, 10` | `110, 36` | `5` | `BackColor = #E2E8F0`, Text: `❌ Hủy Bỏ` |
| `btnLuu` | `Button` | `344, 10` | `120, 36` | `4` | `BackColor = #2980B9`, Text: `💾 Lưu Mật Khẩu` |

---

## 7. CƠ CHẾ DỌN DẸP BỘ NHỚ RAM BẢO MẬT (SECURITY CLEAN-UP)

1. **Khi nạp Form (`Load`):**
   - Xóa trống 3 ô `TextBox`.
   - Ẩn `lblThongBaoLoi`.
   - Focus ngay vào `txtMatKhauCu`.
2. **Khi đóng Form (`FormClosing` / `FormClosed`):**
   - Gọi lệnh `txtMatKhauCu.Clear()`, `txtMatKhauMoi.Clear()`, `txtXacNhanMoi.Clear()`.
   - Đảm bảo mật khẩu dạng thô (plaintext) không lưu lại trong bất kỳ biến hay thuộc tính nào của Form.

