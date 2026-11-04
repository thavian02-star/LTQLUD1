# TÀI LIỆU KỸ THUẬT: ĐẶC TẢ BỐ CỤC GIAO DIỆN & MA TRẬN PHÂN QUYỀN (STEP 1: MAIN UI & RBAC SPECIFICATION)

**Dự án:** Hệ thống Quản lý Quán ăn (VB.NET Windows Forms - .NET 10.0)  
**Phân hệ:** `Features/Main/` (`frmMain.vb`)  
**Tài liệu tham chiếu:** [`MAIN_DASHBOARD.md`](MAIN_DASHBOARD.md), [`MA_TRAN_PHAN_QUYEN.md`](../../MA_TRAN_PHAN_QUYEN.md), [`KIEN_TRUC_HE_THONG.md`](../../KIEN_TRUC_HE_THONG.md)  
**Bản Mockup HTML tương tác:** [`frmMain_mockup.html`](frmMain_mockup.html)

---

## 1. MỤC TIÊU CỦA BƯỚC 1

1. **Chuẩn hóa toàn bộ cấu trúc phân tầng Control (Hierarchy Layout):** Phân chia rõ ràng 4 khu vực: Top Bar (Header), Sidebar điều hướng, Vùng làm việc trung tâm (Content Workspace), và Thanh trạng thái (Status Bar).
2. **Xác lập Ma trận mã quyền `Tag` (RBAC Tag Matrix):** Ánh xạ từng Button điều hướng với bảng `Quyen` trong SQL Server để lớp [`PhanQuyenHelper.vb`](../../Quanlyquanan/Core/Helpers/PhanQuyenHelper.vb) tự động nhận diện và khóa/ẩn menu theo vai trò người dùng.
3. **Đặc tả cơ chế nhúng Form con (Child Form Docking):** Cơ chế mở các màn hình nghiệp vụ con trực tiếp bên trong `pnlContent` mà không mở cửa sổ pop-up rời rạc.

---

## 2. BẢN VẼ SƠ ĐỒ BỐ CỤC KHUNG CỬA SỔ (`frmMain`)

```
┌────────────────────────────────────────────────────────────────────────────────────────────────────────┐
│ [1. WIN TITLEBAR] 🍽️ Hệ Thống Quản Lý Quán Ăn - [Màn Hình Chính - frmMain]                ─   □   ✕   │
├────────────────────────────────────────────────────────────────────────────────────────────────────────┤
│ [2. TOPBAR - pnlHeader (Dock: Top, Height: 65, BackColor: #2980B9)]                                    │
│ 🏪 HỆ THỐNG QUẢN LÝ QUÁN ĂN       🕒 17:00:00        👤 Nguyễn Văn Chủ Quán   [CHỦ QUÁN]   🚪 ĐĂNG XUẤT│
│    Phân hệ điều hành tập trung        04/11/2026         (lblUserName)       (lblUserRole) (btnDangXuat)│
├─────────────────────────┬──────────────────────────────────────────────────────────────────────────────┤
│ [3. pnlSidebar]         │ [4. VÙNG LÀM VIỆC NỘI DUNG - pnlContent (Dock: Fill, BackColor: #F4F6F9)]     │
│ (Dock: Left, Width: 250)│                                                                              │
│                         │ ┌──────────────────────────────────────────────────────────────────────────┐ │
│ -- BÁN HÀNG & PHỤC VỤ --│ │ 👋 Xin chào: Nguyễn Văn Chủ Quán!                                        │ │
│ [btnSoDoBan]            │ └──────────────────────────────────────────────────────────────────────────┘ │
│  🍽️ Sơ Đồ Bàn Ăn        │ ┌──────────────┬──────────────┬──────────────┬─────────────────────────────┐ │
│ [btnNhaBep]             │ │ 🪑 8/20 Bàn   │ 🍜 5 Chờ nấu  │ 👨‍🍳 6 Trong ca│ 💰 4.850.000 đ Doanh thu     │ │
│  🍳 Nhà Bếp & Pha Chế   │ └──────────────┴──────────────┴──────────────┴─────────────────────────────┘ │
│                         │ ┌────────────────────────────────────────┬─────────────────────────────────┐ │
│ -- QUẢN LÝ & VẬN HÀNH --│ │ ⚡ THAO TÁC NGHIỆP VỤ NHANH            │ 🔔 HOẠT ĐỘNG GẦN ĐÂY            │ │
│ [btnDuyetChamCong]      │ │ [Đặt bàn]    [Xem bếp]    [Vào ca]     │ • Bàn 05: Gọi 2 lẩu (16:48)     │ │
│  🕒 Duyệt Chấm Công     │ │ [Duyệt công] [Thực đơn]   [Báo cáo]    │ • Bếp: Báo xong Bàn 02 (16:42)  │ │
│ [btnQuanLyNhanSu]       │ └────────────────────────────────────────┴─────────────────────────────────┘ │
│  👥 Quản Lý Nhân Sự     │                                                                              │
│ [btnQuanLyThucDon]      │  ==> KHI CLICK NÚT TRÊN SIDEBAR:                                             │
│  📋 Thực Đơn & Bàn Ghế  │      pnlContent.Controls.Clear()                                             │
│ [btnBaoCao]             │      childForm.TopLevel = False; childForm.Dock = DockStyle.Fill            │
│  📊 Báo Cáo Doanh Thu   │      pnlContent.Controls.Add(childForm); childForm.Show()                    │
│                         │                                                                              │
│ -- CÁ NHÂN & CÀI ĐẶT ---│                                                                              │
│ [btnChamCongCaNhan]     │                                                                              │
│  ⏱️ Chấm Công Của Tôi   │                                                                              │
│ [btnDoiMatKhau]         │                                                                              │
│  🔑 Đổi Mật Khẩu        │                                                                              │
├─────────────────────────┴──────────────────────────────────────────────────────────────────────────────┤
│ [5. appStatusStrip (Dock: Bottom, Height: 28, BackColor: #2C3E50)]                                     │
│ 🟢 CSDL: Microsoft SQL Server 2022 (Docker) - 172.20.218.246:1433  |  Phiên: TK_001 (chuquan) | v1.0.0 │
└────────────────────────────────────────────────────────────────────────────────────────────────────────┘
```

---

## 3. BẢNG ĐẶC TẢ CHI TIẾT TỪNG THÀNH PHẦN (CONTROL SPECIFICATIONS)

### 3.1. Cấu hình Cửa sổ Form (`frmMain`)
| Thuộc tính | Giá trị thiết lập | Mục đích kỹ thuật |
| :--- | :--- | :--- |
| `Name` | `frmMain` | Tên định danh Form trong Namespace `Features.Main`. |
| `Text` | `Hệ Thống Quản Lý Quán Ăn - [Màn Hình Chính]` | Tiêu đề thanh tiêu đề Windows Taskbar. |
| `WindowState` | `FormWindowState.Maximized` | Mặc định mở rộng toàn màn hình để nhân viên thao tác thuận tiện. |
| `MinimumSize` | `1150, 700` | Ngăn chặn việc thu nhỏ cửa sổ làm vỡ bố cục. |
| `StartPosition` | `FormStartPosition.CenterScreen` | Căn giữa màn hình khi khởi động. |
| `Font` | `Segoe UI, 9.5pt` | Font chữ chuẩn đồng bộ với `frmDangNhap`. |
| `BackColor` | `Color.FromArgb(244, 246, 249)` (`#F4F6F9`) | Màu nền xám sáng nhẹ, dịu mắt cho ca làm việc dài. |

---

### 3.2. Thanh Header (`pnlHeader`)
- **Vị trí & Màu sắc:** `Dock = DockStyle.Top`, `Height = 65`, `BackColor = Color.FromArgb(41, 128, 185)` (`#2980B9`).
- **Các Control con bên trong:**
  1. **Khối Logo & Tiêu đề (Bên trái):**
     - `lblBrandIcon`: Icon quán ăn 🏪 (Font 20pt).
     - `lblBrandTitle`: *"HỆ THỐNG QUẢN LÝ QUÁN ĂN"* (Font 13pt Bold, chữ trắng).
     - `lblBrandSubtitle`: *"PHÂN HỆ ĐIỀU HÀNH & BÁN HÀNG TẬP TRUNG"* (Font 8.5pt, `#D6EAF8`).
  2. **Đồng hồ thời gian thực (`lblClock`):**
     - Gắn với `Timer` (chu kỳ 1000ms): Hiển thị dạng `HH:mm:ss - Thứ X, dd/MM/yyyy`.
     - Nền bo góc trong suốt: `rgba(0,0,0,0.2)`.
  3. **Khối thông tin người dùng (`pnlUserInfo`):**
     - `lblAvatar`: Viết tắt 2 chữ cái đầu của họ tên hoặc vai trò (ví dụ: `CQ`, `QL`, `PV`), nền tròn màu trắng.
     - `lblUserName`: Lấy động từ `Session.HoTenNhanVien` (Font 9.5pt Bold, chữ trắng).
     - `lblUserRole`: Lấy động từ `Session.TenVaiTro` (gắn badge màu: Chủ quán - Cam/Vàng, Quản lý - Tím, Phục vụ - Xanh lá, Bếp - Cam đỏ).
  4. **Nút Đăng xuất (`btnDangXuat`):**
     - `Text = "🚪 ĐĂNG XUẤT"`, `BackColor = Color.FromArgb(231, 76, 60)` (`#E74C3C`).
     - Khi bấm: Hỏi xác nhận $\rightarrow$ Gọi `Session.Clear()` $\rightarrow$ Đóng `frmMain` $\rightarrow$ Hiện lại `frmDangNhap`.

---

### 3.3. Thanh Menu Điều Hướng Trái (`pnlSidebar`)
- **Vị trí & Màu sắc:** `Dock = DockStyle.Left`, `Width = 250`, `BackColor = Color.FromArgb(44, 62, 80)` (`#2C3E50`).
- **Đặc điểm nút bấm:**
  - `FlatStyle = FlatStyle.Flat`, `FlatAppearance.BorderSize = 0`.
  - `Height = 44px`, `TextAlign = ContentAlignment.MiddleLeft`, `Padding = New Padding(15, 0, 0, 0)`.
  - Màu chữ bình thường: `#ECF0F1`, khi rê chuột (Hover): `#34495E`, khi được chọn (Active): `#1A5276` có vạch biên trái xanh dương `#3498DB`.

---

## 4. MA TRẬN ÁNH XẠ MÃ QUYỀN (`TAG MATRIX`) CHO SIDEBAR

Để lớp [`PhanQuyenHelper.vb`](../../Quanlyquanan/Core/Helpers/PhanQuyenHelper.vb) tự động điều khiển hiển thị (chỉ gọi 1 dòng `PhanQuyenHelper.PhanQuyenForm(Me)` tại `frmMain_Load`), toàn bộ các nút điều hướng trên Sidebar được gán mã `Tag` chính xác theo bảng sau:

| STT | Tên Control (`Name`) | Text hiển thị | Mã phân quyền (`Tag`) | 👑 Chủ quán | 👔 Quản lý | 🍽️ Phục vụ | 🍳 Nhà bếp |
| :---: | :--- | :--- | :--- | :---: | :---: | :---: | :---: |
| **1** | `btnSoDoBan` | 🍽️ Sơ Đồ Bàn Ăn | `POS_SO_DO_BAN` | ✅ Hiện | ✅ Hiện | ✅ Hiện | ❌ Ẩn/Khóa |
| **2** | `btnNhaBep` | 🍳 Nhà Bếp & Pha Chế | `B_XEM_MON_CHE_BIEN` | ✅ Hiện | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa | ✅ Hiện |
| **3** | `btnDuyetChamCong` | 🕒 Duyệt Chấm Công | `QL_DUYET_CHAM_CONG` | ✅ Hiện | ✅ Hiện | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa |
| **4** | `btnQuanLyNhanSu` | 👥 Quản Lý Nhân Sự | `CQ_QUAN_LY_NHAN_VIEN` | ✅ Hiện | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa |
| **5** | `btnQuanLyThucDon` | 📋 Thực Đơn & Bàn Ghế | `CQ_QUAN_LY_THUC_DON` | ✅ Hiện | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa |
| **6** | `btnBaoCao` | 📊 Báo Cáo Doanh Thu | `CQ_BAO_CAO_THONG_KE` | ✅ Hiện | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa | ❌ Ẩn/Khóa |
| **7** | `btnChamCongCaNhan`| ⏱️ Chấm Công Của Tôi | `CHUNG_CHAM_CONG_CA_NHAN`| ✅ Hiện | ✅ Hiện | ✅ Hiện | ✅ Hiện |
| **8** | `btnDoiMatKhau` | 🔑 Đổi Mật Khẩu | `CHUNG_DOI_MAT_KHAU` | ✅ Hiện | ✅ Hiện | ✅ Hiện | ✅ Hiện |

> [!NOTE]
> - Các nút mục 7 và 8 là chức năng chung của mọi nhân viên (`CHUNG_...`), tất cả các vai trò khi đăng nhập đều có quyền sử dụng.
> - Nếu một nút có `Tag` mà vai trò hiện tại **không sở hữu** mã quyền đó trong `Session.DanhSachQuyen`:
>   - [`PhanQuyenHelper.vb`](../../Quanlyquanan/Core/Helpers/PhanQuyenHelper.vb) sẽ tự động đặt `Visible = False` (hoặc `Enabled = False`), giúp giao diện tự co giãn gọn gàng và bảo mật tuyệt đối.

---

## 5. ĐẶC TẢ CƠ CHẾ NHÚNG FORM CON VÀO `pnlContent` (CHILD FORM EMBEDDING)

Để mang lại trải nghiệm phần mềm liền mạch như Single Page Application (SPA), các màn hình chức năng con (như `frmSoDoBan`, `frmNhaBep`, `frmNhanVien`) sẽ được nhúng trực tiếp vào bên trong `pnlContent` của `frmMain`:

```vbnet
''' <summary>
''' Biến lưu trữ Form con đang hiển thị hiện tại để giải phóng bộ nhớ khi đổi tab
''' </summary>
Private currentChildForm As Form = Nothing

''' <summary>
''' Phương thức nhúng Form con toàn phần vào pnlContent của frmMain
''' </summary>
Public Sub MoFormCon(childForm As Form)
    ' 1. Đóng và giải phóng tài nguyên Form con cũ (nếu có)
    If currentChildForm IsNot Nothing Then
        currentChildForm.Close()
        currentChildForm.Dispose()
    End If

    ' 2. Thiết lập thuộc tính để Form trở thành Control nhúng
    currentChildForm = childForm
    childForm.TopLevel = False
    childForm.FormBorderStyle = FormBorderStyle.None
    childForm.Dock = DockStyle.Fill

    ' 3. Đưa vào Panel trung tâm và hiển thị
    pnlContent.Controls.Clear()
    pnlContent.Controls.Add(childForm)
    pnlContent.Tag = childForm
    childForm.BringToFront()
    childForm.Show()
End Sub
```

---

## 6. KẾT LUẬN & CHUYỂN BƯỚC

Đặc tả bố cục và ma trận `Tag` của **Bước 1** đã sẵn sàng. Toàn bộ thông số kích thước, màu sắc và định danh Control đã được chốt và khớp hoàn toàn với bản mockup HTML.

👉 **Bước tiếp theo:** Tiến hành tạo file mã nguồn giao diện **[`frmMain.Designer.vb`](../../Quanlyquanan/Features/Main/frmMain.Designer.vb)** và file tài nguyên **`frmMain.resx`** (Bước 2).
