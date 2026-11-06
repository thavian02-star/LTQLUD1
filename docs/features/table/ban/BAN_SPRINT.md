# 📋 TÀI LIỆU ĐẶC TẢ KỸ THUẬT & SPRINT PLAN: QUẢN LÝ BÀN ĂN (`frmBan` v1.0)

> **Phân hệ:** Quản lý Bàn Ăn & Không Gian (`Features/Table`)  
> **Màn hình ưu tiên:** Màn hình 5 / 5 thuộc [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md)  
> **Phiên bản mục tiêu:** `v0.2.7`  
> **Bảng CSDL chính:** `Ban` (Liên kết khóa ngoại từ `HoaDon.HD_MaBan`)  
> **Phân quyền RBAC:** Quyền cấu hình Bàn ghế dành cho `Chủ quán` & `Quản lý` (`CQ_QUAN_LY_BAN`); nhân viên Phục vụ/Nhà bếp chỉ có quyền xem trạng thái bàn.

---

## 1. MỤC TIÊU NGHIỆP VỤ (BUSINESS GOALS)

Màn hình **Quản lý Danh sách Bàn Ăn (`frmBan`)** là nơi cấu hình toàn bộ không gian chỗ ngồi của quán ăn theo từng khu vực (*Tầng trệt, Lầu 1 (Máy lạnh), Phòng VIP Máy lạnh, Sân vườn thoáng mát...*). Đây là thực thể cốt lõi cho phân hệ Bán hàng & Gọi món (POS):
1. **Sơ đồ bàn thời gian thực (Real-time Table Matrix):** Phản ánh tức thời tình trạng bàn: *Trống (0)*, *Có khách (1)*, *Đang đợi món (2)*, *Món đã xong (3)*.
2. **Khóa liên kết Hóa đơn (`HoaDon.HD_MaBan`):** Mỗi phiên phục vụ tại bàn gắn với một hóa đơn đang mở (`HD_TrangThai = 0`).
3. **Quản lý sức chứa tối đa:** Xác định số khách tối đa cho mỗi bàn (2, 4, 6, 8, 10, 12 chỗ) để nhân viên xếp bàn phù hợp với số lượng khách đoàn.

### Các chức năng cốt lõi của `frmBan` v1.0:
- **Hiển thị trực quan Danh sách Bàn ăn:**
  - Hiển thị đầy đủ: `Mã bàn` (`B_Ma`), `Số thứ tự` (`B_SoThuTu`), `Tên bàn` (`B_TenBan`), `Khu vực` (`B_KhuVuc`), `Sức chứa tối đa` (`B_SoNguoiToiDa`), `Trạng thái bàn` (kèm badge màu sắc trực quan) và `Hóa đơn hiện tại` (nếu bàn đang phục vụ).
- **4 Thẻ Thống kê nhanh (KPI Cards):**
  1. **Tổng số bàn hoạt động:** Số lượng bàn trong quán (`12 bàn`).
  2. **Bàn đang trống:** Số bàn sẵn sàng đón khách (`10 bàn`).
  3. **Bàn đang phục vụ:** Số bàn có khách / đang đợi món / món đã xong (`2 bàn`).
  4. **Tổng sức chứa khách:** Tổng số chỗ ngồi phục vụ tối đa (`72 chỗ`).
- **Bộ lọc đa chiều & Tìm kiếm nhanh:**
  - Lọc theo **Khu vực bàn** (*Tất cả khu vực*, *Tầng trệt*, *Lầu 1 (Máy lạnh)*, *Phòng VIP Máy lạnh*, *Sân vườn thoáng mát*).
  - Lọc theo **Trạng thái bàn** (*Tất cả*, *Trống*, *Có khách*, *Đang đợi món*, *Món đã xong*).
  - Tìm kiếm theo từ khóa: Số thứ tự, tên bàn hoặc khu vực.
- **Thao tác Thêm / Sửa / Xóa mềm (`B_Xoa = 1`) & Khôi phục thông minh:**
  - Kiểm tra ràng buộc: `B_SoThuTu > 0` và duy nhất, `B_TenBan` không để trống (`<= 50` ký tự), `B_KhuVuc` không để trống, `B_SoNguoiToiDa > 0`.
  - **Bảo vệ toàn vẹn bàn đang phục vụ:** Không cho phép xóa bàn đang có khách (`B_TrangThai <> 0`) hoặc đang có hóa đơn chưa thanh toán (`HD_TrangThai = 0`).
  - **Khôi phục bàn đã xóa mềm (Soft-Delete Recovery):** Nếu thêm mới bàn có số thứ tự trùng với bàn đã xóa mềm trước đó (`B_Xoa = 1`), hệ thống tự động khôi phục và cập nhật thông tin mới.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & TRUY VẤN SQL (`Ban`)

### 2.1. Cấu trúc bảng `Ban` (Từ [`create-database.sql`](../../../../database/docker-mssql/create-database.sql))
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `B_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã định danh tự tăng của bàn ăn |
| `B_SoThuTu` | `INT` | `NOT NULL UNIQUE` | Số thứ tự bàn (1, 2, 3...) |
| `B_TenBan` | `NVARCHAR(50)` | `NOT NULL` | Tên hiển thị (VD: *Bàn 01*, *Bàn 09 (VIP 1)*) |
| `B_KhuVuc` | `NVARCHAR(50)` | `DEFAULT N'Tầng trệt'` | Khu vực đặt bàn (*Tầng trệt*, *Lầu 1*, *Phòng VIP*...) |
| `B_SoNguoiToiDa` | `INT` | `DEFAULT 4, CHECK (> 0)` | Sức chứa số người tối đa |
| `B_TrangThai` | `INT` | `DEFAULT 0` | 0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong |
| `B_Xoa` | `BIT` | `DEFAULT 0` | Cờ xóa mềm (0: Hoạt động, 1: Đã xóa) |

### 2.2. Dữ liệu mẫu chuẩn (Từ [`seed-data.sql`](../../../../database/docker-mssql/seed-data.sql))
| `B_Ma` | `B_SoThuTu` | `B_TenBan` | `B_KhuVuc` | Sức chứa | Trạng thái | Ghi chú phục vụ |
| :---: | :---: | :--- | :--- | :---: | :--- | :--- |
| `1` | `1` | `Bàn 01` | `Tầng trệt` | `2 người` | `0: Trống` | Bàn 2 chỗ cạnh cửa |
| `2` | `2` | `Bàn 02` | `Tầng trệt` | `4 người` | `2: Đang đợi món` | Hóa đơn #5 đang nấu món |
| `3` | `3` | `Bàn 03` | `Tầng trệt` | `4 người` | `3: Món đã xong` | Hóa đơn #6 chờ bưng ra |
| `4` | `4` | `Bàn 04` | `Tầng trệt` | `4 người` | `0: Trống` | Sẵn sàng đón khách |
| `5` | `5` | `Bàn 05` | `Tầng trệt` | `6 người` | `0: Trống` | Bàn dài gia đình |
| `6` | `6` | `Bàn 06` | `Lầu 1 (Máy lạnh)` | `4 người` | `0: Trống` | Phòng máy lạnh lầu 1 |
| `7` | `7` | `Bàn 07` | `Lầu 1 (Máy lạnh)` | `6 người` | `0: Trống` | Phòng máy lạnh lầu 1 |
| `8` | `8` | `Bàn 08` | `Lầu 1 (Máy lạnh)` | `8 người` | `0: Trống` | Bàn tiệc lầu 1 |
| `9` | `9` | `Bàn 09 (VIP 1)` | `Phòng VIP Máy lạnh` | `10 người` | `0: Trống` | Phòng VIP tiệc sinh nhật |
| `10` | `10` | `Bàn 10 (VIP 2)` | `Phòng VIP Máy lạnh` | `12 người` | `0: Trống` | Phòng VIP hội nghị gia đình |
| `11` | `11` | `Bàn 11` | `Sân vườn thoáng mát` | `4 người` | `0: Trống` | Bàn ngoài trời |
| `12` | `12` | `Bàn 12` | `Sân vườn thoáng mát` | `8 người` | `0: Trống` | Bàn ngoài trời gia đình |

---

## 3. THIẾT KẾ GIAO DIỆN & BỐ CỤC (UI/UX GEOMETRY SPEC)

- **Kích thước Form:** `ClientSize = New Size(1120, 680)`, `MinimumSize = New Size(1020, 640)`, `StartPosition = CenterParent`.
- **Tầng 1 — Header (`pnlHeader`, `Dock = Top, Height = 68px`):**
  - Nền Navy chuẩn `rgb(26, 82, 118)`.
  - Tiêu đề `lblTitle`: `"🪑 QUẢN LÝ DANH SÁCH BÀN ĂN"` + Phụ đề `lblSubtitle`: `"Danh mục chuẩn (5/5) • Thiết lập số thứ tự, khu vực, sức chứa và quản lý trạng thái bàn phục vụ"`.
  - Nút `btnDong` (`"✖ Đóng"`, `Anchor = Top Or Right`).
- **Tầng 2 — KPI Cards (`tlpKpiRow`, `Dock = Top, Height = 78px`, 4 cột `25%`):**
  - `pnlKpiTongBan`: **TỔNG SỐ BÀN** (`12 bàn`).
  - `pnlKpiBanTrong`: **BÀN ĐANG TRỐNG** (`10 bàn`).
  - `pnlKpiDangPhucVu`: **BÀN ĐANG PHỤC VỤ** (`2 bàn`).
  - `pnlKpiSucChua`: **TỔNG SỨC CHỨA** (`72 chỗ ngồi`).
- **Tầng 3 — Nội dung chính (`tlpMainContent`, `Dock = Fill`, 2 cột `38% : 62%`):**
  - **Cột Trái (`pnlFormCard` - 38%):**
    - Tiêu đề `"📝 THÔNG TIN CHI TIẾT BÀN"` + Badge trạng thái (`"CHẾ ĐỘ: THÊM MỚI"` / `"CHẾ ĐỘ: CẬP NHẬT"` / `"CHẾ ĐỘ: CHỈ XEM"`).
    - Hộp thông báo trạng thái `lblThongBao`.
    - `txtMaBan` (`ReadOnly = True`, tự động sinh).
    - `nudSoThuTu` (`NumericUpDown`, `Minimum = 1, Maximum = 999`, kiểm tra duy nhất).
    - `txtTenBan` (`MaxLength = 50`, bắt buộc).
    - `cboKhuVuc` (`ComboBox`, nạp các khu vực chuẩn, hỗ trợ nhập khu vực mới).
    - `nudSoNguoiToiDa` (`NumericUpDown`, `Minimum = 1, Maximum = 50, Value = 4`).
    - `cboTrangThai` (`ComboBox`, nạp 4 trạng thái: *0: Trống*, *1: Có khách*, *2: Đang đợi món*, *3: Món đã xong*).
    - Badge hiển thị Hóa đơn đang gắn (`pnlHoaDonBadge`).
    - Cụm 4 nút CRUD (`tlpButtons`, `Dock = Bottom, Height = 80px`, lưới `2x2`): `➕ Thêm bàn mới`, `💾 Lưu cập nhật`, `🗑️ Xóa bàn`, `🔄 Làm mới`.
  - **Cột Phải (`pnlGridCard` - 62%):**
    - `lblGridTitle` (`Dock = Top`).
    - `pnlFilterBar` (`Dock = Top, Height = 48px`, chứa `cboLocKhuVuc`, `cboLocTrangThai`, `txtTimKiem`, `btnTaiLai`).
    - `dgvBan` (`Dock = Fill`, 7 cột: `Mã bàn`, `STT`, `Tên bàn`, `Khu vực`, `Sức chứa`, `Trạng thái`, `Hóa đơn phục vụ`).

---

## 4. CHECKLIST 5 BƯỚC THỰC HIỆN SPRINT (`frmBan`)

- [x] **Bước 1: Đặc tả Kỹ thuật & Interactive Mockup HTML (`docs/features/table/ban/`)**
  - [x] Tạo tài liệu đặc tả [`BAN_SPRINT.md`](BAN_SPRINT.md).
  - [x] Tạo file Mockup tương tác [`frmBan_mockup_v1_0.html`](frmBan_mockup_v1_0.html) với 5 kịch bản mô phỏng trực quan.
- [x] **Bước 2: Thiết kế Giao diện WinForms (`Quanlyquanan/Features/Table/frmBan.Designer.vb`)**
  - [x] Thiết kế 3 tầng + Split-Layout 38:62 chống cắt chữ / chống đè control ở cả kích thước Minimum và FullHD.
- [x] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmBan.vb`)**
  - [x] Tạo `BanDTO.vb`, `BanDAO.vb`, `BanBUS.vb` và hoàn thiện sự kiện trong `frmBan.vb`.
- [x] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (`BanVerifier`)**
  - [x] Tích hợp mở `frmBan` từ `frmMain` và thực thi bộ kiểm thử tự động toàn diện 26/26 tiêu chí (Layout + Filter + CRUD + FK Protection + RBAC) đạt 100% PASS.
- [x] **Bước 5: Báo cáo Phát hành (`docs/release_report/report_0_2_7.html`), Đồng bộ 2 Checklist & Git Tag `v0.2.7`**
  - [x] Xuất bản báo cáo phát hành trực quan `report_0_2_7.html` và tích hợp thanh điều hướng 8 phiên bản.
  - [x] Đánh dấu hoàn thành `[x]` Màn hình 5 trên `CHECKLIST_UU_TIEN_DANH_MUC.md` & Mục 3.5 Quản lý Bàn ghế trên `CHECKLIST_DO_AN.md`.
  - [x] Gắn Git Tag `v0.2.7`.
