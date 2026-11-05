# 📋 TÀI LIỆU ĐẶC TẢ KỸ THUẬT & SPRINT PLAN: QUẢN LÝ CA LÀM VIỆC (`frmCaLamViec` v1.0)

> **Phân hệ:** Quản lý Lịch & Ca Làm Việc (`Features/Shift`)  
> **Màn hình ưu tiên:** Màn hình 3 / 5 thuộc [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md)  
> **Phiên bản mục tiêu:** `v0.2.5`  
> **Bảng CSDL chính:** `CaLamViec` (Liên kết khóa ngoại từ `LichLamViec.LLV_MaCa` & `HoaDon.HD_MaCa`)  
> **Phân quyền RBAC:** Xem danh sách ca cho `Chủ quán` & `Quản lý` (`QL_DUYET_CHAM_CONG`, `CQ_XEP_LICH_LAM_VIEC`); quyền Thêm/Sửa/Xóa cấu hình ca dành cho `CQ_XEP_LICH_LAM_VIEC` / Chủ quán.

---

## 1. MỤC TIÊU NGHIỆP VỤ (BUSINESS GOALS)

Màn hình **Quản lý Danh sách Ca Làm Việc (`frmCaLamViec`)** đóng vai trò cấu hình khung giờ hoạt động chuẩn của quán ăn trong ngày (ví dụ: *Ca 1 (Ca Sáng) 08:00 – 15:00*, *Ca 2 (Ca Chiều Tối) 15:00 – 22:00*) và định mức lương cơ bản cho mỗi ca. Đây là dữ liệu nền tảng bắt buộc cho:
1. **Phân hệ Xếp lịch & Chấm công (`LichLamViec`):** Khi phân công nhân viên theo ngày, hệ thống chọn ca từ `CaLamViec` và đối chiếu `LLV_GioVao` / `LLV_GioRa` với `CA_GioBatDau` / `CA_GioKetThuc`.
2. **Phân hệ Bán hàng & Hóa đơn (`HoaDon`):** Mỗi hóa đơn thanh toán (`HD_MaCa`) gắn với ca làm việc tương ứng để thống kê doanh thu theo từng ca.
3. **Phân hệ Tính lương cuối tháng:** Lấy `CA_LuongMoiCa` nhân với số ca được duyệt (`LLV_DaDuyet = 1`) để tính lương nhân viên chính xác.

### Các chức năng cốt lõi của `frmCaLamViec` v1.0:
- **Hiển thị trực quan Danh sách Ca làm việc:**
  - Hiển thị đầy đủ: `Mã ca` (`CA_Ma`), `Tên ca làm việc` (`CA_Ten`), `Khung giờ` (`CA_GioBatDau – CA_GioKetThuc` định dạng `HH:mm`), `Thời lượng ca` (tự động tính số giờ làm việc, ví dụ `7.0 giờ`), `Định mức lương / ca` (`#,##0 đ`), và `Số lượt đã xếp lịch` (`SoLuotXepLich` đếm từ bảng `LichLamViec`).
- **3 Thẻ Thống kê nhanh (KPI Cards):**
  1. **Tổng số ca hoạt động:** Số lượng ca đang cấu hình (`CA_Xoa = 0`).
  2. **Tổng thời lượng mở cửa / ngày:** Tổng số giờ của các ca hoạt động (ví dụ: `14.0 giờ/ngày`).
  3. **Định mức lương TB / ca:** Trung bình cộng mức lương mỗi ca (`#,##0 đ`).
- **Tìm kiếm & Làm mới tức thời:** Tìm nhanh theo tên ca làm việc (`CA_Ten`).
- **Thêm mới / Cập nhật / Xóa mềm (`CA_Xoa = 1`) & Khôi phục thông minh:**
  - Tự động tính **Thời lượng ca (giờ)** ngay khi người dùng thay đổi `Giờ bắt đầu` hoặc `Giờ kết thúc` trên form.
  - Kiểm tra ràng buộc: `CA_Ten` không rỗng (`<= 50` ký tự), không trùng tên ca đang hoạt động, `CA_GioKetThuc > CA_GioBatDau` (tối thiểu `30 phút`), `CA_LuongMoiCa >= 0`.
  - **Bảo vệ toàn vẹn khóa ngoại (FK Protection):** Không cho phép xóa ca làm việc đang có lịch phân công nhân viên (`LichLamViec` với `LLV_Xoa = 0`) hoặc đã phát sinh hóa đơn (`HoaDon` với `HD_Xoa = 0`).
  - **Khôi phục ca đã xóa mềm (Soft-Delete Recovery):** Nếu thêm mới tên ca trùng với một ca đã xóa mềm (`CA_Xoa = 1`), hệ thống tự động khôi phục bản ghi cũ (`CA_Xoa = 0`) và cập nhật khung giờ + mức lương mới.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & TRUY VẤN SQL (`CaLamViec`)

### 2.1. Cấu trúc bảng `CaLamViec` (Từ [`create-database.sql`](../../../../database/docker-mssql/create-database.sql))
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `CA_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã định danh tự tăng của ca làm việc |
| `CA_Ten` | `NVARCHAR(50)` | `NOT NULL` | Tên ca làm việc (VD: *Ca 1 (Ca Sáng)*, *Ca 2 (Ca Chiều Tối)*) |
| `CA_GioBatDau` | `TIME(0)` | `NOT NULL` | Giờ bắt đầu ca (VD: `'08:00:00'`, `'15:00:00'`) |
| `CA_GioKetThuc` | `TIME(0)` | `NOT NULL` | Giờ kết thúc ca (VD: `'15:00:00'`, `'22:00:00'`) |
| `CA_LuongMoiCa` | `DECIMAL(18, 2)` | `DEFAULT 0, CHECK (>= 0)` | Định mức lương mỗi ca (VNĐ) |
| `CA_Xoa` | `BIT` | `DEFAULT 0` | Cờ xóa mềm (`0`: Đang hoạt động, `1`: Đã xóa) |

### 2.2. Dữ liệu mẫu chuẩn (Từ [`seed-data.sql`](../../../../database/docker-mssql/seed-data.sql))
| `CA_Ma` | `CA_Ten` | `CA_GioBatDau` | `CA_GioKetThuc` | Thời lượng | `CA_LuongMoiCa` | Lịch đã xếp (`LichLamViec`) | Hóa đơn (`HoaDon`) |
| :---: | :--- | :---: | :---: | :---: | ---: | :---: | :---: |
| `1` | `Ca 1 (Ca Sáng)` | `08:00` | `15:00` | `7.0 giờ` | `180,000 đ` | `6 lượt` | `5 HĐ` |
| `2` | `Ca 2 (Ca Chiều Tối)` | `15:00` | `22:00` | `7.0 giờ` | `210,000 đ` | `4 lượt` | `1 HĐ` |

---

## 3. THIẾT KẾ GIAO DIỆN & BỐ CỤC (UI/UX GEOMETRY SPEC)

Màn hình `frmCaLamViec` tuân thủ chuẩn **Split-Layout 38% : 62%** đồng bộ với `frmDanhMuc` và `frmMonAn`:
- **Kích thước Form:** `ClientSize = New Size(1080, 660)`, `MinimumSize = New Size(1000, 640)`, `StartPosition = CenterParent`.
- **Tầng 1 — Header (`pnlHeader`, `Dock = Top, Height = 68px`):**
  - Nền Navy đậm `rgb(26, 82, 118)`.
  - Tiêu đề `lblTitle`: `"⏰ QUẢN LÝ DANH SÁCH CA LÀM VIỆC"` + Phụ đề `lblSubtitle`: `"Danh mục chuẩn (3/5) • Cấu hình khung giờ hoạt động, tính thời lượng tự động và định mức lương mỗi ca"`.
  - Nút `btnDong` (`"✖ Đóng"`, `Anchor = Top Or Right`).
- **Tầng 2 — KPI Cards (`tlpKpiRow`, `Dock = Top, Height = 80px`, 3 cột `33.33%`):**
  - `pnlKpiTongCa`: **TỔNG SỐ CA HOẠT ĐỘNG** (`2 ca`).
  - `pnlKpiTongGio`: **TỔNG THỜI LƯỢNG MỞ CỬA / NGÀY** (`14.0 giờ`).
  - `pnlKpiLuongTB`: **ĐỊNH MỨC LƯƠNG TB / CA** (`195,000 đ`).
- **Tầng 3 — Nội dung chính (`tlpMainContent`, `Dock = Fill`, 2 cột `38% : 62%`):**
  - **Cột Trái (`pnlFormCard` - 38%):**
    - Tiêu đề `"📝 THÔNG TIN CA LÀM VIỆC"` + Badge trạng thái (`"CHẾ ĐỘ: THÊM MỚI"` / `"CHẾ ĐỘ: CẬP NHẬT"` / `"CHẾ ĐỘ: CHỈ XEM"`).
    - Hộp thông báo trạng thái `lblThongBao` (Xanh lá khi thành công, Đỏ khi lỗi).
    - `txtMaCa` (`ReadOnly = True`, tự động sinh).
    - `txtTenCa` (`MaxLength = 50`, bắt buộc).
    - Khung chọn giờ 2 cột (`dtpGioBatDau` và `dtpGioKetThuc`, định dạng `HH:mm` 24h với `ShowUpDown = True`).
    - Badge tính tự động `pnlThoiLuongBadge` (`lblThoiLuong`: `"⏱️ Thời lượng ca: 7.0 giờ  |  📅 Đã xếp lịch: 6 lượt"`).
    - `nudLuongMoiCa` (`NumericUpDown`, `ThousandsSeparator = True`, `Increment = 10000`, `Maximum = 100000000`).
    - Cụm 4 nút `tlpButtons` (`Dock = Bottom, Height = 80px`, lưới `2x2`): `➕ Thêm mới`, `💾 Cập nhật`, `🗑️ Xóa ca`, `🔄 Làm mới`.
  - **Cột Phải (`pnlGridCard` - 62%):**
    - `lblGridTitle` (`Dock = Top`), `pnlSearchBar` (`Dock = Top`, chứa `txtTimKiem`, `btnTimKiem`, `btnTaiLai`), và `dgvCaLamViec` (`Dock = Fill`).
    - 6 cột trên `dgvCaLamViec`: `Mã ca`, `Tên ca làm việc`, `Khung giờ`, `Thời lượng`, `Lương / ca`, `Lịch đã xếp`.

---

## 4. CHECKLIST 5 BƯỚC THỰC HIỆN SPRINT (`frmCaLamViec`)

- [x] **Bước 1: Đặc tả Kỹ thuật & Interactive Mockup HTML (`docs/features/shift/ca_lam_viec/`)**
  - [x] Tạo tài liệu đặc tả [`CA_LAM_VIEC_SPRINT.md`](CA_LAM_VIEC_SPRINT.md).
  - [x] Tạo file Mockup tương tác [`frmCaLamViec_mockup_v1_0.html`](frmCaLamViec_mockup_v1_0.html) với 4 kịch bản demo trực quan.
- [x] **Bước 2: Thiết kế Giao diện WinForms (`Quanlyquanan/Features/Shift/frmCaLamViec.Designer.vb`)**
  - [x] Thiết kế 3 tầng + Split-Layout 38:62 chống cắt chữ / chống đè control ở cả kích thước Minimum và FullHD.
- [x] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmCaLamViec.vb`)**
  - [x] Tạo `CaLamViecDTO.vb`, `CaLamViecDAO.vb`, `CaLamViecBUS.vb` và hoàn thiện sự kiện trong `frmCaLamViec.vb`.
- [x] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (`CaLamViecVerifier`)**
  - [x] Tích hợp mở `frmCaLamViec` từ `frmMain` và thực thi bộ kiểm thử tự động 24/24 tiêu chí (Layout Geometry + CRUD + FK Protection + RBAC).
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/report_0_2_5.html`), Đồng bộ 2 Checklist & Git Tag `v0.2.5`**
