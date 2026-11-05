# SPRINT PLAN & ĐẶC TẢ KỸ THUẬT: MÀN HÌNH QUẢN LÝ MÓN ĂN (`frmMonAn` v1.0)

**Thuộc Checklist ưu tiên:** [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md) — **Màn hình 2 / 5 (`MH Món ăn`)**  
**Ánh xạ Checklist chung:** [`docs/CHECKLIST_DO_AN.md`](../../../CHECKLIST_DO_AN.md) — **Mục 3.5: Quản lý Thực đơn (Quản lý Món ăn & Thức uống)**  
**Phân quyền RBAC (`Q_Tag`):** `CQ_QUAN_LY_THUC_DON` *(Dành cho vai trò **Chủ quán** — `VT_Ma = 1`)*  
**File Mockup tương tác:** [`docs/features/menu/mon_an/frmMonAn_mockup_v1_0.html`](frmMonAn_mockup_v1_0.html)

---

## 1. MỤC TIÊU NGHIỆP VỤ & PHẠM VI (`frmMonAn`)

Màn hình **Quản lý Món ăn & Thức uống (`frmMonAn`)** là màn hình thứ 2 trong cặp chức năng **Thực đơn (`DanhMuc` → `MonAn`)**, kế thừa trực tiếp danh sách nhóm thực đơn từ [`frmDanhMuc`](../danh_muc/DANH_MUC_SPRINT.md) để quản lý chi tiết từng món ăn, thức uống, giá bán VNĐ và trạng thái còn/hết món phục vụ cho phân hệ Bán hàng (POS) và Nhà bếp.

### Các nghiệp vụ chính:
1. **Hiển thị danh sách món ăn & thức uống (`SELECT` + `INNER JOIN DanhMuc`):**
   - Liệt kê toàn bộ món ăn chưa xóa (`MA_Xoa = 0` thuộc các danh mục `DM_Xoa = 0`) trên lưới `DataGridView` (`dgvMonAn`).
   - Hiển thị đầy đủ các cột: **Mã món (`#1`, `#2`)**, **Tên món ăn & thức uống**, **Nhóm danh mục (`DM_Ten`)**, **Đơn giá bán (`#,##0 đ`)**, và **Trạng thái (`🟢 Còn món` / `🔴 Hết món`)**.
   - Hiển thị **3 thẻ thống kê nhanh (KPI Summary)** phía trên:
     - **Tổng số món trong thực đơn:** Tổng số món đang kinh doanh (`MA_Xoa = 0`).
     - **Đang phục vụ (Còn món):** Số món sẵn sàng nhận order (`MA_HetMon = 0`).
     - **Tạm hết nguyên liệu (Hết món):** Số món đang đánh dấu tạm hết (`MA_HetMon = 1`) để Chủ quán và Nhà bếp kịp thời bổ sung.
2. **Bộ lọc đa chiều tức thì (`Filter & Search`):**
   - **Lọc theo Danh mục (`cboLocDanhMuc`):** Chọn `"-- Tất cả danh mục --"` hoặc lọc riêng từng nhóm (*Món Khai Vị & Gỏi, Món Chính, Món Lẩu & Nướng, Thức Uống, Tráng Miệng*).
   - **Lọc theo Trạng thái (`cboLocTrangThai`):** `"Tất cả trạng thái"`, `"🟢 Còn món"`, hoặc `"🔴 Hết món"`.
   - **Tìm kiếm từ khóa (`txtTimKiem`):** Tìm tức thì theo **Tên món ăn (`MA_Ten`)** hoặc **Mô tả (`MA_MoTa`)** không phân biệt hoa thường.
3. **Thêm mới món ăn (`INSERT`):**
   - Nhập `Tên món ăn` (bắt buộc, tối đa `100` ký tự), chọn `Danh mục` từ `ComboBox` (`cboDanhMuc`), nhập `Đơn giá bán (VNĐ)` bằng `NumericUpDown` (`nudDonGia`, `>= 0`, bước tăng `1.000 đ`), tùy chọn tích `chkHetMon` (`Báo tạm hết món`), và nhập `Mô tả / Định lượng` (tối đa `255` ký tự).
   - **Ràng buộc chống trùng lặp & Khôi phục xóa mềm:**
     - Không cho phép thêm món có `MA_Ten` trùng với món đang hoạt động (`MA_Xoa = 0`).
     - Nếu `MA_Ten` trùng với một món đã xóa mềm trước đó (`MA_Xoa = 1`), hệ thống **tự động khôi phục (`MA_Xoa = 0`)** và cập nhật lại Danh mục, Đơn giá, Trạng thái, Mô tả mới.
4. **Cập nhật thông tin & Báo hết món nhanh (`UPDATE`):**
   - Chọn 1 dòng trên `dgvMonAn` → tự động đổ dữ liệu (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon`, `MA_MoTa`) sang khung chi tiết bên trái.
   - Hỗ trợ đổi giá bán, chuyển nhóm danh mục, sửa mô tả hoặc bật/tắt cờ **Báo hết món (`MA_HetMon`)** nhanh chóng.
5. **Xóa mềm món ăn (`SOFT DELETE` — `MA_Xoa = 1`):**
   - **Ràng buộc bảo vệ bàn đang phục vụ (Business Rule quan trọng):**
     - Kiểm tra xem món ăn có đang nằm trong hóa đơn **Đang phục vụ** (`HoaDon.HD_TrangThai = 0` và `ChiTietHoaDon.CTHD_Xoa = 0` và `CTHD_TrangThaiMon <> 3`) hay không.
     - Nếu món đang được khách gọi tại các bàn chưa thanh toán (`SoLuotDangPhucVu > 0`), **chặn xóa** và cảnh báo rõ: *"Không thể xóa món [Tên món] vì đang có [N] lượt gọi tại các bàn đang phục vụ! Bạn có thể tích chọn [Tạm hết món] để ngừng nhận thêm order mới."*
     - Nếu món không vướng bàn đang phục vụ (`SoLuotDangPhucVu = 0`), thực hiện xóa mềm (`MA_Xoa = 1`) để ẩn khỏi thực đơn hiện tại nhưng vẫn giữ nguyên vẹn lịch sử hóa đơn cũ phục vụ báo cáo doanh thu.
6. **Điều hướng liên hoàn 2 chiều (`frmDanhMuc` ↔ `frmMonAn`):**
   - Nút **"📂 Quản lý Danh mục"** trên thanh Header cho phép mở nhanh màn hình `frmDanhMuc` để thêm/sửa nhóm danh mục và tự động làm mới lại `ComboBox` Danh mục ngay khi quay về.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & KIẾN TRÚC 3 LỚP (`DTO` - `DAO` - `BUS` - `GUI`)

### 2.1. Bảng CSDL (`MonAn` — Đã có sẵn trong `create-database.sql` & `seed-data.sql`)
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `MA_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã món ăn tự tăng |
| `MA_Ten` | `NVARCHAR(100)` | `NOT NULL` | Tên món ăn / thức uống |
| `MA_DanhMuc` | `INT` | `NOT NULL, FK -> DanhMuc(DM_Ma)` | Mã danh mục thực đơn |
| `MA_DonGia` | `DECIMAL(18, 2)` | `NOT NULL, CHECK >= 0` | Đơn giá bán (VNĐ) |
| `MA_HetMon` | `BIT` | `DEFAULT 0` | `0`: Còn món, `1`: Tạm hết món |
| `MA_MoTa` | `NVARCHAR(255)` | `NULL` | Mô tả thành phần / định lượng món |
| `MA_Xoa` | `BIT` | `DEFAULT 0` | `0`: Đang kinh doanh, `1`: Đã xóa mềm |

### 2.2. Cấu trúc File Mã Nguồn (`Quanlyquanan`)
| Lớp (Layer) | Đường dẫn File | Trách nhiệm chính |
| :--- | :--- | :--- |
| **DTO** | `Core/DTO/MonAnDTO.vb` | Thuộc tính: `MaMonAn As Integer`, `TenMonAn As String`, `MaDanhMuc As Integer`, `TenDanhMuc As String`, `DonGia As Decimal`, `HetMon As Boolean`, `MoTa As String`, `Xoa As Boolean`, cùng thuộc tính hiển thị `TrangThaiText As String`. |
| **DAO** | `Core/DAO/MonAnDAO.vb` | Truy vấn SQL tham số hóa: `LayDanhSach(tuKhoa, maDanhMuc, trangThaiHetMon)`, `KiemTraTrungTen(ten, maLoaiTru)`, `TimMaMonDaXoaTheoTen(ten)`, `DemSoLuotGoiTrongHoaDonDangPhucVu(maMon)`, `ThemMonAn(dto)`, `KhoiPhucMonAn(maMon, dto)`, `CapNhatMonAn(dto)`, `XoaMemMonAn(maMon)`. |
| **BUS** | `Core/BUS/MonAnBUS.vb` | Kiểm tra nghiệp vụ (Validate tên rỗng, độ dài, `DonGia >= 0`, `MaDanhMuc > 0`, trùng tên, chặn xóa khi món đang có trong bàn đang phục vụ), trả về đối tượng `KetQuaMonAn`. |
| **GUI** | `Features/Menu/frmMonAn.Designer.vb`<br>`Features/Menu/frmMonAn.vb` | Giao diện chuẩn Modern POS Split-Layout (`38%` Form nhập liệu bên trái : `62%` Bộ lọc đa chiều & `DataGridView` bên phải), kết nối liên hoàn với `frmDanhMuc` và `frmMain`. |

---

## 3. ĐẶC TẢ GIAO DIỆN (`frmMonAn.Designer.vb`)

- **Kích thước Form:** `ClientSize = (1120, 680)`, `MinimumSize = (1000, 620)`, `StartPosition = CenterParent`, `BackColor = Color.FromArgb(245, 246, 250)`.
- **Bố cục 3 tầng dọc (Chống đè chữ & Co giãn Responsive 100%):**
  1. **`pnlHeader` (`Dock = Top`, `Height = 68px`, nền trắng):**
     - Tiêu đề `lblTitle`: `"🍜 QUẢN LÝ MÓN ĂN & THỨC UỐNG"` + phụ đề `lblSubtitle`: `"Thiết lập thực đơn, định giá bán VNĐ và kiểm soát trạng thái Còn món / Hết món"`.
     - Nút `btnMoDanhMuc` (`"📂 Quản lý Danh mục"`, góc phải) và nút `btnDong` (`"✖ Đóng"`).
  2. **`tlpKpiRow` (`Dock = Top`, `Height = 86px`, `TableLayoutPanel` 3 cột đều nhau `33.33%`):**
     - Thẻ 1 (`pnlKpiTongMon`): Tổng số món trong thực đơn (`16 món`).
     - Thẻ 2 (`pnlKpiConMon`): Đang phục vụ — Còn món (`15 món`, màu xanh lá `#16A34A`).
     - Thẻ 3 (`pnlKpiHetMon`): Tạm hết nguyên liệu — Hết món (`1 món`, màu đỏ cam `#EA580C`).
  3. **`tlpMainContent` (`Dock = Fill`, `TableLayoutPanel` 2 cột: Cột trái `38%` - Khung thông tin món ăn, Cột phải `62%` - Bộ lọc & Danh sách món):**
     - **Cột trái (`pnlFormCard`):**
       - `txtMaMon` (`ReadOnly = True`, nền xám nhạt `#F1F5F9`, hiển thị `"Tự động (IDENTITY)"` hoặc `#1`, `#2`...).
       - `txtTenMon` (`MaxLength = 100`, bắt buộc `*`).
       - `cboDanhMuc` (`DropDownStyle = DropDownList`, nạp danh sách từ `DanhMucBUS`).
       - `nudDonGia` (`NumericUpDown`, `Minimum = 0`, `Maximum = 100000000`, `Increment = 5000`, `ThousandsSeparator = True`, hiển thị đơn giá VNĐ).
       - `pnlTrangThaiBox`: Chứa `chkHetMon` (`"🔴 Báo tạm hết món (Ngừng nhận order món này)"`).
       - `txtMoTa` (`Multiline = True`, `Height = 54px`, `MaxLength = 255`).
       - Cụm 4 nút chức năng (`tlpButtons` 2×2, `Dock = Bottom`):
         - `btnThem` (`"➕ Thêm món mới"`, nền xanh lá `#16A34A`)
         - `btnCapNhat` (`"💾 Lưu cập nhật"`, nền xanh dương `#2563EB`)
         - `btnXoa` (`"🗑️ Xóa món ăn"`, nền đỏ `#DC2626`)
         - `btnLamMoi` (`"🔄 Làm mới ô nhập"`, nền xám `#475569`)
     - **Cột phải (`pnlGridCard`):**
       - Thanh công cụ lọc đa chiều (`pnlSearchBar`, `Dock = Top`, `Height = 50px`):
         - `cboLocDanhMuc` (Lọc theo nhóm danh mục)
         - `cboLocTrangThai` (Lọc Tất cả / Còn món / Hết món)
         - `txtTimKiem` (Nhập tên món hoặc mô tả)
         - `btnTaiLai` (Xóa bộ lọc & tải lại)
       - Bảng dữ liệu `dgvMonAn` (`Dock = Fill`, `AutoSizeColumnsMode = Fill`, `SelectionMode = FullRowSelect`, `ReadOnly = True`):
         - Cột 1: `colMaMon` (`Mã`, rộng `10%`, căn giữa)
         - Cột 2: `colTenMon` (`Tên món ăn / thức uống`, rộng `34%`, in đậm)
         - Cột 3: `colTenDanhMuc` (`Danh mục`, rộng `22%`)
         - Cột 4: `colDonGia` (`Đơn giá`, rộng `18%`, căn phải, định dạng `#,##0 đ`)
         - Cột 5: `colTrangThai` (`Trạng thái`, rộng `16%`, căn giữa, tô màu xanh `Còn món` / đỏ `Hết món`)

---

## 4. QUY TRÌNH 5 BƯỚC TRIỂN KHAI SPRINT `frmMonAn v1.0`

- [x] **Bước 1: Phân tích nghiệp vụ, tạo Sprint Plan (`MON_AN_SPRINT.md`) & Interactive HTML Mockup (`frmMonAn_mockup_v1_0.html`) để PO review**
- [x] **Bước 2: Thiết kế giao diện WinForms (`Features/Menu/frmMonAn.Designer.vb`)**
- [x] **Bước 3: Xây dựng tầng `DTO` (`MonAnDTO.vb`), `DAO` (`MonAnDAO.vb`), `BUS` (`MonAnBUS.vb`) và xử lý sự kiện `frmMonAn.vb`**
- [x] **Bước 4: Kết nối liên hoàn `frmMain` ↔ `frmDanhMuc` ↔ `frmMonAn` & Chạy bộ Kiểm thử tự động (CRUD + Filter + Validation + Layout Geometry + RBAC — `28/28 PASS = 100%`)**
- [ ] **Bước 5: Tạo Release Report (`docs/release_report/report_0_2_4.html`) & Đánh dấu hoàn thành `[x]` trong `CHECKLIST_UU_TIEN_DANH_MUC.md` + `CHECKLIST_DO_AN.md`**
