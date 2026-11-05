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
