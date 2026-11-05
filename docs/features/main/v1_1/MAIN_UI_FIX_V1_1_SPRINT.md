# KẾ HOẠCH SPRINT & ĐẶC TẢ KỸ THUẬT: SỬA LỖI GIAO DIỆN & TỐI ƯU BỐ CỤC `frmMain` (VERSION v1.1)

**Dự án:** Hệ thống Quản lý Quán ăn (VB.NET Windows Forms - .NET 10.0)  
**Phân hệ:** `Features/Main/` (`frmMain.Designer.vb`, `frmMain.vb`)  
**Phiên bản thiết kế:** `v1.1` (Nâng cấp từ `v1.0`)  
**Bản Mockup HTML tương tác (v1.1):** [`frmMain_mockup_v1_1.html`](frmMain_mockup_v1_1.html) *(Có công cụ chuyển đổi qua lại giữa `v1.0 Bug`, `v1.1 Fix` và `Split View Before/After`)*  
**Tài liệu gốc (v1.0):** [`MAIN_DASHBOARD.md`](../MAIN_DASHBOARD.md) & [`MAIN_UI_VA_PHAN_QUYEN.md`](../MAIN_UI_VA_PHAN_QUYEN.md)

---

## 1. PHÂN TÍCH NGUYÊN NHÂN GỐC RỄ TỪ ẢNH CHỤP NGHIỆM THU CỦA PO (ROOT CAUSE ANALYSIS)

Khi chạy thực tế màn hình `frmMain` ở chế độ toàn màn hình (`WindowState = Maximized`), Product Owner (PO) đã phát hiện **2 lỗi hiển thị UI/UX tại khu vực hàng dưới (`pnlDashboardRow`)**:

### 🔴 Lỗi 1 (`BUG-MAIN-01`): Tiêu đề `"🔔 Hoạt Động Gần Đây"` đè khuất 2 dòng đầu của danh sách (`"Hải Sản"`, `"Lúc Lắc (Bàn 02)"`)
- **Hiện tượng trên UI:** Ngay sát bên phải chữ `"🔔 Hoạt Động Gần Đây"` xuất hiện lấp ló chữ `"Hải Sản"` và dòng dưới là `"Lúc Lắc (Bàn 02)"`, mất toàn bộ phần đầu câu `"• [16:48] Bàn 05 gọi thêm 2 Lẩu "` và `"• [16:42] Bếp báo xong món Bò "`.
- **Nguyên nhân kỹ thuật trong [`frmMain.Designer.vb` (dòng 535–568)](../../../Quanlyquanan/Features/Main/frmMain.Designer.vb#L535-L568):**
  ```vbnet
  ' HIỆN TẠI (v1.0 BUG - NGƯỢC THỨ TỰ Z-ORDER):
  pnlActivity.Controls.Add(lblActivityHeader) ' Index 0 (Dock = Top, AutoSize = True, Size = 166x31)
  pnlActivity.Controls.Add(lstActivity)       ' Index 1 (Dock = Fill, Location = Point(16, 16))
  ```
  - Trong Windows Forms, trình quản lý bố cục (`LayoutEngine`) tính toán `Dock` từ **cuối danh sách (`Index` cao)** về **đầu danh sách (`Index 0`)**:
    1. `lstActivity` (`Index 1`, `Dock = DockStyle.Fill`) được tính toán **TRƯỚC** nên tràn lên chiếm toàn bộ diện tích `pnlActivity` bắt đầu từ đỉnh `Point(16, 16)`.
    2. `lblActivityHeader` (`Index 0`, `Dock = DockStyle.Top`, `AutoSize = True`) được tính toán **SAU** và có Z-Order nằm **đè lên trên (`BringToFront`)** góc trái trên `(16, 16)` với kích thước `166 × 31 px`.
    3. Miếng nhãn trắng `166 × 31 px` này che khuất mất `166px` đầu tiên của dòng 1 và dòng 2 trong `lstActivity`, chỉ để lộ phần đuôi câu!

### 🔴 Lỗi 2 (`BUG-MAIN-02`): Khoảng trống trắng dư thừa lớn ở bên phải khung `"🔔 Hoạt Động Gần Đây"` & dính sát 2 khung
- **Hiện tượng trên UI:** Khung `🔔 Hoạt Động Gần Đây` bị kéo giãn rất rộng sang bên phải với hơn nửa khung là khoảng trắng trống rỗng, đồng thời mép trái của `pnlActivity` dính sát vào `pnlQuickActions` (`0px` khoảng cách).
- **Nguyên nhân kỹ thuật trong [`frmMain.Designer.vb` (dòng 521–580)](../../../Quanlyquanan/Features/Main/frmMain.Designer.vb#L521-L580):**
  - `pnlDashboardRow` đang là một `Panel` thường:
    - Cột trái `pnlQuickActions` đặt `Dock = DockStyle.Left` với chiều rộng cố định **`565px`**.
    - Cột phải `pnlActivity` đặt `Dock = DockStyle.Fill` (nằm sát ngay tọa độ `X = 565`, không có khoảng cách ngăn cách giữa 2 thẻ trắng).
  - Khi cửa sổ `frmMain` phóng to toàn màn hình (`1920×1080`), cột trái giữ nguyên `565px`, còn **toàn bộ phần chiều ngang dư ra (~1.050px)** dồn hết vào `pnlActivity`, làm khung bên phải rộng bất thường so với độ dài dòng chữ (`~290px`).

---

## 2. QUY TRÌNH 5 BƯỚC TRIỂN KHAI BẢN CẬP NHẬT `frmMain v1.1`

```
┌──────────────────────────────────────────────────────────────────────────────────┐
│                     LỘ TRÌNH 5 BƯỚC SPRINT FRMMAIN v1.1                          │
│                                                                                  │
│  Bước 1: Đặc tả & Mockup v1.1 ──► Bước 2: Sửa Designer.vb ──► Bước 3: Rà soát VB │
│  (PO Review Before/After)         (Z-Order & Grid 60:40)      (frmMain & RBAC)   │
│                                                                      │           │
│                            Bước 5: Release Report ◄── Bước 4: Test Tọa độ & RBAC │
│                            (Cập nhật tài liệu)        (Automated Layout Verify)  │
└──────────────────────────────────────────────────────────────────────────────────┘
```

---

### BƯỚC 1: Đặc tả Giải pháp UI/UX `v1.1` & Trình PO Duyệt Mockup
- **File Mockup tương tác:** [`frmMain_mockup_v1_1.html`](frmMain_mockup_v1_1.html)
- **Đặc tả chi tiết 2 thay đổi trong `v1.1`:**

#### 1.1. Chuẩn hóa Z-Order và Header của `pnlActivity` (Khắc phục `BUG-MAIN-01`)
| Thuộc tính / Cấu trúc | Trạng thái cũ (`v1.0 Bug`) | Thiết kế mới (`v1.1 Fix`) | Tác dụng kỹ thuật |
| :--- | :--- | :--- | :--- |
| Thứ tự `pnlActivity.Controls` | `[0] lblActivityHeader`<br/>`[1] lstActivity` | **`[0] lstActivity`** (`Dock = Fill`)<br/>**`[1] lblActivityHeader`** (`Dock = Top`) | WinForms tính toán `lblActivityHeader` (`Dock = Top`) trước, sau đó `lstActivity` (`Dock = Fill`) tự động bắt đầu từ `Y = 48` (nằm hoàn toàn bên dưới tiêu đề). |
| `lblActivityHeader.AutoSize` | `True` (`Size = 166, 31`) | **`False`** (`Dock = Top`, `Height = 32`) | Tiêu đề trải đều hết chiều ngang đỉnh `pnlActivity`, không bao giờ co hẹp góc trái. |
| `lblQuickHeader.AutoSize` | `True` (`Size = 213, 31`) | **`False`** (`Dock = Top`, `Height = 32`) | Đồng bộ chiều cao tiêu đề `32px` giữa cả 2 khung trái và phải. |
| `lstActivity.Location` | `New Point(16, 16)` (Bị đè) | **`New Point(16, 48)`** | Bắt đầu ngay dưới đáy của `lblActivityHeader` (`16 + 32 = 48`), hiển thị nguyên vẹn 100% cả 5 dòng. |

#### 1.2. Chuyển `pnlDashboardRow` sang `TableLayoutPanel` tỉ lệ `60% : 40%` (Khắc phục `BUG-MAIN-02`)
```
┌────────────────────────────── pnlDashboardRow (TableLayoutPanel - Dock: Fill) ──────────────────────────────┐
│  Column 0: 60% (SizeType.Percent)                        │  Column 1: 40% (SizeType.Percent)                │
│ ┌──────────────────────────────────────────────────────┐ │ ┌──────────────────────────────────────────────┐ │
│ │ pnlQuickActions (Dock: Fill, Margin: 0, 0, 8, 0)     │ │ │ pnlActivity (Dock: Fill, Margin: 8, 0, 0, 0) │ │
│ │ ┌──────────────────────────────────────────────────┐ │ │ │ ┌──────────────────────────────────────────┐ │ │
│ │ │ lblQuickHeader (Dock: Top, Height: 32px)         │ │ │ │ │ lblActivityHeader (Dock: Top, Height: 32)│ │ │
│ │ │ ⚡ Thao Tác Nghiệp Vụ Nhanh                      │ │ │ │ │ 🔔 Hoạt Động Gần Đây                     │ │ │
│ │ └──────────────────────────────────────────────────┘ │ │ │ └──────────────────────────────────────────┘ │ │
│ │ ┌──────────────────────────────────────────────────┐ │ │ │ ┌──────────────────────────────────────────┐ │ │
│ │ │ tlpQuickButtons (Dock: Fill, 3 cột × 2 hàng)     │ │ │ │ │ lstActivity (Dock: Fill, Y = 48px)       │ │ │
│ │ │ [🍽️ Sơ Đồ Bàn]  [🍳 Nhà Bếp]   [⏱️ Chấm Công]    │ │ │ │ │ • [16:48] Bàn 05 gọi thêm 2 Lẩu Hải Sản  │ │ │
│ │ │ [🕒 Duyệt Công] [🍲 Thực Đơn]  [📈 Báo Cáo]      │ │ │ │ │ • [16:42] Bếp báo xong món Bò Lúc Lắc... │ │ │
│ │ └──────────────────────────────────────────────────┘ │ │ │ └──────────────────────────────────────────┘ │ │
│ └──────────────────────────────────────────────────────┘ │ └──────────────────────────────────────────────┘ │
└──────────────────────────────────────────────────────────┴──────────────────────────────────────────────────┘
```

| Thành phần | Trạng thái cũ (`v1.0 Bug`) | Thiết kế mới (`v1.1 Fix`) | Tác dụng trên màn hình Maximized (`1920px`) |
| :--- | :--- | :--- | :--- |
| `pnlDashboardRow` | `System.Windows.Forms.Panel` | **`System.Windows.Forms.TableLayoutPanel`** (`2 cột × 1 hàng`) | Chia bố cục theo tỉ lệ phần trăm tự động co giãn theo mọi độ phân giải màn hình. |
| Cột 0 (`pnlQuickActions`) | `Dock = Left`, `Width = 565px` (Cố định) | **`ColumnStyle(Percent, 60F)`**, `Dock = Fill`, `Margin = (0, 0, 8, 0)` | 6 nút thao tác nhanh tự động mở rộng chiếm `60%` không gian, dễ bấm và cân đối. |
| Cột 1 (`pnlActivity`) | `Dock = Fill`, `Location = (565, 15)` (Dính sát) | **`ColumnStyle(Percent, 40F)`**, `Dock = Fill`, `Margin = (8, 0, 0, 0)` | Khung Hoạt động gần đây chiếm `40%` gọn gàng, cách khung trái đúng `16px` (`8 + 8`), xóa bỏ khoảng trắng dư thừa bên phải. |

---

### BƯỚC 2: Cập nhật Giao diện `frmMain.Designer.vb` (Chờ PO duyệt Bước 1)
- **File thực hiện:** `Quanlyquanan/Features/Main/frmMain.Designer.vb`
- **Nội dung thay đổi:**
  1. Đổi kiểu của `pnlDashboardRow` thành `TableLayoutPanel` (2 cột: `60%` và `40%`, 1 hàng: `100%`).
  2. Cấu hình `pnlQuickActions` vào ô `(0, 0)` với `Dock = DockStyle.Fill`, `Margin = New Padding(0, 0, 8, 0)`.
  3. Cấu hình `pnlActivity` vào ô `(1, 0)` với `Dock = DockStyle.Fill`, `Margin = New Padding(8, 0, 0, 0)`.
  4. Đảo thứ tự `pnlActivity.Controls.Add(lstActivity)` lên trước `pnlActivity.Controls.Add(lblActivityHeader)` và đặt `lblActivityHeader.AutoSize = False`, `Size = New Size(377, 32)`.

---

### BƯỚC 3: Rà soát Logic `frmMain.vb` & Đệ quy Phân quyền `PhanQuyenHelper.vb`
- Kiểm tra hàm `PhanQuyenHelper.DuyetControls(parent)` đảm bảo đệ quy xuyên qua `TableLayoutPanel` (`pnlDashboardRow` $\rightarrow$ `pnlQuickActions` $\rightarrow$ `tlpQuickButtons`) hoạt động chính xác 100%.

---

### BƯỚC 4: Kiểm thử Tự động Tọa độ Giao diện & Đa Vai trò (Automated Layout & RBAC Verification) — **ĐẠT 74/74 (100%)**
- Đã thực thi bộ kiểm thử tự động `RbacVerifier` kết nối trực tiếp CSDL Docker SQL Server (`172.20.218.246:1433`):
  1. **Phần 1 — Kiểm thử Tọa độ Hình học & Bố cục `frmMain v1.1` (10/10 PASS):**
     - `L-01`: `pnlDashboardRow` là `TableLayoutPanel` (`Cols = 2, Rows = 1`) — **PASS**.
     - `L-02`: `ColumnStyles` chuẩn tỉ lệ `Col0 = 60%` (`pnlQuickActions`) : `Col1 = 40%` (`pnlActivity`) — **PASS**.
     - `L-03`: Z-Order trong `pnlActivity.Controls` chuẩn (`lstActivity.Index = 0`, `lblActivityHeader.Index = 1`) — **PASS**.
     - `L-04`: `lblActivityHeader.AutoSize = False`, `Size = 350×32 px` — **PASS**.
     - `L-05`: `lblQuickHeader.AutoSize = False`, `Size = 544×32 px` — **PASS**.
     - `L-06` (`BUG-MAIN-01 FIX`): `lblActivityHeader.Bottom = 48px`, `lstActivity.Top = 48px` (`lstActivity.Top >= lblActivityHeader.Bottom` — tuyệt đối không đè chữ) — **PASS**.
     - `L-07`: Ở độ phân giải chuẩn (`1280×750`), `QuickWidth = 576px`, `ActivityWidth = 382px`, khoảng cách `Gap = 16px` — **PASS**.
     - `L-08` (`BUG-MAIN-02 FIX`): Ở độ phân giải Full HD (`1920×1080`), `QuickWidth = 960px` (tự co giãn `> 800px`, không khóa cứng `565px`), `ActivityWidth = 638px`, `Gap = 16px`, `lstTop = 48px` — **PASS**.
     - `L-09`: `lstActivity.SelectedIndex = -1` khi nạp Form (không bị bôi xanh dòng mặc định) — **PASS**.
     - `L-10`: Hàm `GhiNhatKyHoatDong()` chèn sự kiện mới lên đầu danh sách (`Items[0]`) và giữ `SelectedIndex = -1` — **PASS**.
  2. **Phần 2 — Kiểm thử Đệ quy Phân quyền RBAC Đa Vai trò (64/64 PASS):**
     - Đạt `16/16` tiêu chí cho từng vai trò (`chuquan`, `quanly`, `phucvu1`, `nhabep1`).

---

### BƯỚC 5: Cập nhật Tài liệu & Release Report
- Cập nhật trạng thái hoàn thành trong [`MAIN_UI_FIX_V1_1_SPRINT.md`](MAIN_UI_FIX_V1_1_SPRINT.md), [`MAIN_DASHBOARD.md`](../MAIN_DASHBOARD.md) và Release Report.

---

## 3. CHECKLIST TIẾN ĐỘ SPRINT `frmMain v1.1`

- [x] **Bước 1:** Phân tích nguyên nhân gốc rễ, lập kế hoạch Sprint `v1.1` và tạo Mockup tương tác [`frmMain_mockup_v1_1.html`](frmMain_mockup_v1_1.html) *(Đã được PO duyệt)*.
- [x] **Bước 2:** Cập nhật `frmMain.Designer.vb` (Sửa Z-Order `pnlActivity` & chuyển `pnlDashboardRow` sang `TableLayoutPanel` 60% : 40%).
- [x] **Bước 3:** Rà soát tương thích `frmMain.vb` & `PhanQuyenHelper.vb`.
- [x] **Bước 4:** Chạy kiểm thử tự động Tọa độ UI (Anti-Overlap & Responsive 60:40) + 64/64 RBAC Test Cases — **Kết quả: 74/74 ĐẠT (100%)**.
- [x] **Bước 5:** Commit code và tạo Release Report [`report_0_2_2.html`](../../../release_report/report_0_2_2.html).
