# 📋 TÀI LIỆU ĐẶC TẢ KỸ THUẬT & SPRINT PLAN: QUẢN LÝ KHU VỰC BÀN (`frmKhuVuc` v1.0)

> **Phân hệ:** Quản lý Sơ đồ Bàn & Khu vực (`Features/Table`)  
> **Màn hình ưu tiên:** Màn hình 4 / 5 thuộc [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md)  
> **Phiên bản mục tiêu:** `v0.2.6`  
> **Bảng CSDL chính:** `KhuVuc` (Liên kết đồng bộ trực tiếp với `Ban.B_KhuVuc`)  
> **Phân quyền RBAC:** `CQ_QUAN_LY_BAN` (Chủ quán & Quản lý toàn quyền Thêm/Sửa/Xóa; Phục vụ & Nhà bếp chỉ xem hoặc không thao tác cấu hình).

---

## 1. MỤC TIÊU NGHIỆP VỤ (BUSINESS GOALS)

Màn hình **Quản lý Khu vực bàn ăn (`frmKhuVuc`)** đóng vai trò thiết lập và phân loại không gian phục vụ của quán ăn (*Tầng trệt, Lầu 1 (Máy lạnh), Phòng VIP Máy lạnh, Sân vườn thoáng mát...*). Đây là phân loại cốt lõi làm tiền đề cho:
1. **Màn hình Quản lý Bàn (`frmBan` - MH 5/5):** Bàn ăn được phân bố theo từng Khu vực; ComboBox chọn khu vực trên form bàn ăn được nạp trực tiếp từ danh sách khu vực hoạt động.
2. **Sơ đồ bàn & Gọi món (`frmSoDoBan`):** Nhân viên phục vụ lọc và xem trạng thái bàn ăn (Trống, Đang phục vụ, Đang đợi món) theo từng khu vực trực quan.
3. **Báo cáo doanh thu theo không gian:** Giúp chủ quán nhận biết khu vực nào đạt hiệu suất khai thác cao nhất (VD: Phòng VIP hay Sân vườn).

### Các chức năng cốt lõi của `frmKhuVuc` v1.0:
- **Hiển thị trực quan Danh sách Khu vực:**
  - Hiển thị: `Mã KV` (`KV_Ma`), `Tên khu vực` (`KV_Ten`), `Mô tả không gian` (`KV_MoTa`), `Số bàn hiện có` (đếm bàn thực tế từ bảng `Ban`), `Tổng chỗ ngồi` (tổng sức chứa khách từ `SUM(Ban.B_SoNguoiToiDa)`).
- **3 Thẻ Thống kê nhanh (KPI Cards):**
  1. **Tổng số khu vực hoạt động:** Số lượng khu vực đang cấu hình (`KV_Xoa = 0`).
  2. **Tổng số bàn đã bố trí:** Tổng số bàn ăn thuộc tất cả các khu vực (`12 bàn`).
  3. **Tổng sức chứa khách tối đa:** Tổng số chỗ ngồi phục vụ tối đa cùng lúc (`72 chỗ`).
- **Tìm kiếm & Làm mới tức thời:** Tìm kiếm nhanh theo tên khu vực hoặc mô tả không gian.
- **Thêm mới / Cập nhật / Xóa mềm (`KV_Xoa = 1`) & Khôi phục thông minh:**
  - Ràng buộc: `KV_Ten` bắt buộc nhập (`<= 50` ký tự), không trùng tên khu vực đang hoạt động.
  - **Đồng bộ tên khu vực tự động (Cascade Update):** Khi đổi tên khu vực (ví dụ từ `Lầu 1` thành `Tầng 1`), hệ thống tự động cập nhật lại cột `B_KhuVuc` của toàn bộ các bàn thuộc khu vực đó trong bảng `Ban`.
  - **Bảo vệ toàn vẹn khóa ngoại (FK Protection):** Chặn tuyệt đối hành vi xóa khu vực nếu đang có bàn ăn hoạt động (`Ban.B_Xoa = 0`).
  - **Khôi phục xóa mềm (Soft-Delete Recovery):** Nếu người dùng thêm mới tên khu vực trùng với một khu vực đã xóa mềm trước đó (`KV_Xoa = 1`), hệ thống tự động khôi phục lại mã `KV_Ma` cũ, phục hồi `KV_Xoa = 0` và cập nhật lại mô tả mới.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & TRUY VẤN SQL (`KhuVuc`)

### 2.1. Cấu trúc bảng `KhuVuc` (Từ [`create-database.sql`](../../../../database/docker-mssql/create-database.sql))
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `KV_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã định danh tự tăng của khu vực bàn |
| `KV_Ten` | `NVARCHAR(50)` | `NOT NULL UNIQUE` | Tên khu vực (VD: *Tầng trệt*, *Lầu 1 (Máy lạnh)*, *Phòng VIP Máy lạnh*...) |
| `KV_MoTa` | `NVARCHAR(255)` | `NULL` | Mô tả đặc điểm không gian, tiện ích phục vụ |
| `KV_Xoa` | `BIT` | `DEFAULT 0` | Cờ xóa mềm (`0`: Đang hoạt động, `1`: Đã xóa) |

### 2.2. Dữ liệu mẫu chuẩn (Từ [`seed-data.sql`](../../../../database/docker-mssql/seed-data.sql))
| `KV_Ma` | `KV_Ten` | `KV_MoTa` | Số bàn (`Ban`) | Tổng sức chứa |
| :---: | :--- | :--- | :---: | :---: |
| `1` | `Tầng trệt` | `Khu vực sảnh chính tầng trệt, không gian mở năng động, gần quầy thu ngân` | `5 bàn` | `20 chỗ` |
| `2` | `Lầu 1 (Máy lạnh)` | `Khu vực tầng 1 phòng lạnh mát mẻ, yên tĩnh, phù hợp gia đình & bạn bè` | `3 bàn` | `18 chỗ` |
| `3` | `Phòng VIP Máy lạnh` | `Phòng riêng máy lạnh cao cấp dành cho tiệc riêng tư, hội họp đối tác` | `2 bàn` | `22 chỗ` |
| `4` | `Sân vườn thoáng mát` | `Khu vực sân vườn ngoài trời nhiều cây xanh, thoáng mát tự nhiên ban đêm` | `2 bàn` | `12 chỗ` |

---

## 3. THIẾT KẾ GIAO DIỆN & BỐ CỤC (UI/UX GEOMETRY SPEC)

Màn hình `frmKhuVuc` tuân thủ chuẩn **Split-Layout 38% : 62%** đồng bộ toàn hệ thống:
- **Kích thước Form:** `ClientSize = New Size(1080, 660)`, `MinimumSize = New Size(1000, 640)`, `StartPosition = CenterParent`.
- **Tầng 1 — Header (`pnlHeader`, `Dock = Top, Height = 68px`):**
  - Nền Navy đậm `rgb(26, 82, 118)`.
  - Tiêu đề `lblTitle`: `"🏢 QUẢN LÝ KHU VỰC BÀN ĂN"` + Phụ đề `lblSubtitle`: `"Danh mục chuẩn (4/5) • Phân loại không gian sảnh, phòng VIP, sân vườn & đồng bộ sơ đồ bàn"`.
  - Cụm nút Header: Nút mở nhanh sang MH Bàn `btnMoBan` (`"🪑 Quản lý Bàn"`) và nút `btnDong` (`"✖ Đóng"`).
- **Tầng 2 — KPI Cards (`tlpKpiRow`, `Dock = Top, Height = 80px`, 3 cột `33.33%`):**
  - `pnlKpiTongKhuVuc`: **TỔNG SỐ KHU VỰC HOẠT ĐỘNG** (`4 khu vực`).
  - `pnlKpiTongBan`: **TỔNG SỐ BÀN ĐÃ BỐ TRÍ** (`12 bàn`).
  - `pnlKpiTongCho`: **TỔNG SỨC CHỨA KHÁCH TỐI ĐA** (`72 chỗ ngồi`).
- **Tầng 3 — Nội dung chính (`tlpMainContent`, `Dock = Fill`, 2 cột `38% : 62%`):**
  - **Cột Trái (`pnlFormCard` - 38%):**
    - Tiêu đề `"📝 THÔNG TIN KHU VỰC"` + Badge trạng thái (`"CHẾ ĐỘ: THÊM MỚI"` / `"CHẾ ĐỘ: CẬP NHẬT"` / `"CHẾ ĐỘ: CHỈ XEM"`).
    - Hộp thông báo trạng thái `lblThongBao` (Xanh lá khi thành công, Đỏ khi lỗi).
    - `txtMaKhuVuc` (`ReadOnly = True`, tự động sinh).
    - `txtTenKhuVuc` (`MaxLength = 50`, bắt buộc).
    - `txtMoTa` (`Multiline = True, Height = 75px`, mô tả tiện ích không gian).
    - Badge thống kê bàn `pnlThongKeBanBadge` (`lblThongKeBan`: `"🪑 Số bàn hiện có: 5 bàn  |  👥 Sức chứa: 20 chỗ"`).
    - Cụm 4 nút `tlpButtons` (`Dock = Bottom, Height = 80px`, lưới `2x2`): `➕ Thêm mới`, `💾 Cập nhật`, `🗑️ Xóa khu vực`, `🔄 Làm mới`.
  - **Cột Phải (`pnlGridCard` - 62%):**
    - `lblGridTitle` (`Dock = Top`), `pnlSearchBar` (`Dock = Top`, chứa `txtTimKiem`, `btnTimKiem`, `btnTaiLai`), và `dgvKhuVuc` (`Dock = Fill`).
    - 5 cột trên `dgvKhuVuc`: `Mã KV`, `Tên khu vực`, `Mô tả không gian`, `Số bàn hiện có`, `Tổng chỗ ngồi`.

---

## 4. CHECKLIST 5 BƯỚC THỰC HIỆN SPRINT (`frmKhuVuc`)

- [x] **Bước 1: Đặc tả Kỹ thuật, CSDL KhuVuc & Interactive Mockup HTML (`docs/features/table/khu_vuc/`)**
  - [x] Tạo tài liệu đặc tả [`KHU_VUC_SPRINT.md`](KHU_VUC_SPRINT.md).
  - [x] Tạo file Mockup tương tác [`frmKhuVuc_mockup_v1_0.html`](frmKhuVuc_mockup_v1_0.html) với 4 kịch bản demo trực quan.
  - [x] Bổ sung bảng `KhuVuc` trong `create-database.sql` & `seed-data.sql` và cập nhật trực tiếp lên SQL Server Docker.
- [x] **Bước 2: Thiết kế Giao diện WinForms (`Quanlyquanan/Features/Table/frmKhuVuc.Designer.vb`)**
  - [x] Thiết kế 3 tầng + Split-Layout 38:62 chống cắt chữ / chống đè control ở cả kích thước Minimum và FullHD.
- [x] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmKhuVuc.vb`)**
  - [x] Tạo `KhuVucDTO.vb`, `KhuVucDAO.vb`, `KhuVucBUS.vb` và hoàn thiện sự kiện trong `frmKhuVuc.vb`.
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (`KhuVucVerifier`)**
  - [ ] Tích hợp mở `frmKhuVuc` từ `frmMain` và thực thi bộ kiểm thử tự động 24/24 tiêu chí (Layout Geometry + CRUD + FK Protection + Cascade Sync + RBAC).
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/report_0_2_6.html`), Đồng bộ 2 Checklist & Git Tag `v0.2.6`**
