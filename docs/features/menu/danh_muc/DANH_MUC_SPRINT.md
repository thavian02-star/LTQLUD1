# SPRINT PLAN & ĐẶC TẢ KỸ THUẬT: MÀN HÌNH QUẢN LÝ DANH MỤC (`frmDanhMuc` v1.0)

**Thuộc Checklist ưu tiên:** [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md) — **Màn hình 1 / 5 (`MH Danh mục`)**  
**Ánh xạ Checklist chung:** [`docs/CHECKLIST_DO_AN.md`](../../../CHECKLIST_DO_AN.md) — **Mục 3.5: Quản lý Thực đơn (Quản lý Danh mục món)**  
**Phân quyền RBAC (`Q_Tag`):** `CQ_QUAN_LY_THUC_DON` *(Dành cho vai trò **Chủ quán** — `VT_Ma = 1`)*  
**File Mockup tương tác:** [`docs/features/menu/danh_muc/frmDanhMuc_mockup_v1_0.html`](frmDanhMuc_mockup_v1_0.html)

---

## 1. MỤC TIÊU NGHIỆP VỤ & PHẠM VI (`frmDanhMuc`)

Màn hình **Quản lý Danh mục món ăn (`frmDanhMuc`)** là màn hình nền tảng đầu tiên trong cặp chức năng **Thực đơn (`DanhMuc` → `MonAn`)**, giúp Chủ quán tổ chức các nhóm thực đơn của quán ăn (ví dụ: *Món Khai Vị & Gỏi, Món Chính - Cơm & Mì/Phở, Món Lẩu & Nướng Tại Bàn, Thức Uống & Giải Khát, Tráng Miệng*).

### Các nghiệp vụ chính:
1. **Hiển thị danh sách danh mục (`SELECT`):**
   - Liệt kê toàn bộ danh mục chưa xóa (`DM_Xoa = 0`) trên lưới `DataGridView`.
   - Hiển thị kèm cột **Số lượng món ăn hiện có** (`SoLuongMon`) trong từng danh mục (thống kê bằng `LEFT JOIN MonAn ON MA_DanhMuc = DM_Ma AND MA_Xoa = 0`) để Chủ quán biết ngay nhóm nào đang có bao nhiêu món.
   - Hiển thị 3 thẻ thống kê nhanh (KPI Summary) phía trên: **Tổng số danh mục**, **Tổng số món đang kinh doanh**, và **Danh mục trống (0 món)**.
2. **Tìm kiếm & Lọc tức thì (`Search`):**
   - Tìm kiếm theo **Tên danh mục** (`DM_Ten`) hoặc **Mô tả** (`DM_MoTa`) không phân biệt hoa thường.
3. **Thêm mới danh mục (`INSERT`):**
   - Nhập `Tên danh mục` (bắt buộc, tối đa `100` ký tự) và `Mô tả` (tùy chọn, tối đa `255` ký tự).
   - **Ràng buộc chống trùng lặp:** Không cho phép thêm danh mục có `DM_Ten` trùng với danh mục đang tồn tại (`DM_Xoa = 0`). Nếu trùng với danh mục đã xóa mềm (`DM_Xoa = 1`), tự động khôi phục (`DM_Xoa = 0`) và cập nhật mô tả mới.
4. **Cập nhật thông tin danh mục (`UPDATE`):**
   - Chọn 1 dòng trên lưới `DataGridView` → tự động đổ dữ liệu (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `SoLuongMon`) sang khung chi tiết bên trái.
   - Kiểm tra không để trống `DM_Ten` và không trùng tên với danh mục khác (`DM_Ma <> @MaHienTai`).
5. **Xóa mềm danh mục (`SOFT DELETE` — `DM_Xoa = 1`):**
   - **Ràng buộc toàn vẹn khóa ngoại (Business Rule quan trọng):**
     - Nếu danh mục đang chứa món ăn chưa xóa (`SoLuongMon > 0`), **chặn xóa** và hiển thị cảnh báo rõ ràng: *"Không thể xóa danh mục [Tên] vì đang có [N] món ăn thuộc danh mục này. Vui lòng chuyển hoặc xóa các món ăn trước!"*.
     - Nếu `SoLuongMon = 0`, hiển thị hộp thoại xác nhận `MessageBox` trước khi cập nhật `DM_Xoa = 1`.
6. **Điều hướng liên hoàn sang `MH Món ăn` (`frmMonAn`):**
   - Có nút **"🍜 Mở Quản lý Món ăn"** ngay trên thanh Header để Chủ quán chuyển nhanh sang màn hình `frmMonAn` (Màn hình 2) sau khi tạo xong danh mục.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & KIẾN TRÚC 3 LỚP (`DTO` - `DAO` - `BUS` - `GUI`)

### 2.1. Bảng CSDL (`DanhMuc` — Đã có sẵn trong `create-database.sql` & `seed-data.sql`)
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `DM_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã danh mục tự tăng |
| `DM_Ten` | `NVARCHAR(100)` | `NOT NULL` | Tên nhóm thực đơn |
| `DM_MoTa` | `NVARCHAR(255)` | `NULL` | Mô tả chi tiết nhóm thực đơn |
| `DM_Xoa` | `BIT` | `DEFAULT 0` | `0`: Đang hoạt động, `1`: Đã xóa mềm |

### 2.2. Cấu trúc File Mã Nguồn (`Quanlyquanan`)
| Lớp (Layer) | Đường dẫn File | Trách nhiệm chính |
| :--- | :--- | :--- |
| **DTO** | `Core/DTO/DanhMucDTO.vb` | Thuộc tính: `MaDanhMuc As Integer`, `TenDanhMuc As String`, `MoTa As String`, `SoLuongMon As Integer`, `Xoa As Boolean`. |
| **DAO** | `Core/DAO/DanhMucDAO.vb` | Truy vấn SQL tham số hóa (`@Ten`, `@MoTa`, `@Ma`): `LayDanhSach()`, `TimKiem(tuKhoa)`, `KiemTraTrungTen(ten, maLoaiTru)`, `DemSoMonTrongDanhMuc(maDM)`, `Them(dto)`, `CapNhat(dto)`, `XoaMem(maDM)`. |
| **BUS** | `Core/BUS/DanhMucBUS.vb` | Kiểm tra nghiệp vụ (Validate rỗng, độ dài, trùng tên, chặn xóa khi `SoLuongMon > 0`), trả về kết quả kèm thông điệp lỗi tường minh. |
| **GUI** | `Features/Menu/frmDanhMuc.Designer.vb`<br>`Features/Menu/frmDanhMuc.vb` | Giao diện chuẩn Modern POS Split-Layout (`38%` Form nhập liệu bên trái : `62%` Danh sách `DataGridView` bên phải bằng `TableLayoutPanel`), tích hợp ghi nhật ký hoạt động vào `frmMain.GhiNhatKyHoatDong()`. |

---

## 3. ĐẶC TẢ GIAO DIỆN (`frmDanhMuc.Designer.vb`)

- **Kích thước Form:** `Size = (1060, 650)`, `MinimumSize = (940, 560)`, `StartPosition = CenterParent`, `BackColor = Color.FromArgb(245, 246, 250)`.
- **Bố cục tổng thể (Chống đè chữ & Co giãn Responsive 100%):**
  1. **`pnlHeader` (`Dock = Top`, `Height = 68px`, nền trắng):**
     - Tiêu đề `lblTitle`: `"📂 QUẢN LÝ DANH MỤC THỰC ĐƠN"` + phụ đề `lblSubtitle`: `"Tổ chức các nhóm món ăn & thức uống của quán"`.
     - Nút `btnMoMonAn` (`"🍜 Quản lý Món ăn ➔"`, góc phải) và nút `btnDong` (`"✖ Đóng"`).
  2. **`tlpKpiRow` (`Dock = Top`, `Height = 76px`, `TableLayoutPanel` 3 cột đều nhau `33.33%`):**
     - Thẻ 1 (`pnlKpiTongDM`): Tổng số danh mục đang hoạt động.
     - Thẻ 2 (`pnlKpiTongMon`): Tổng số món ăn thuộc các danh mục.
     - Thẻ 3 (`pnlKpiDanhMucTrong`): Số danh mục chưa có món ăn (`0 món` — có thể xóa an toàn).
  3. **`tlpMainContent` (`Dock = Fill`, `TableLayoutPanel` 2 cột: Cột trái `38%` - Khung thông tin danh mục, Cột phải `62%` - Khung danh sách & tìm kiếm):**
     - **Cột trái (`pnlFormCard`):**
       - `txtMaDM` (`ReadOnly = True`, nền xám nhạt `#F1F5F9`, hiển thị `"Tự động"` khi thêm mới hoặc `#1`, `#2` khi chọn dòng).
       - `txtTenDM` (`MaxLength = 100`, bắt buộc `*`).
       - `txtMoTa` (`Multiline = True`, `Height = 96px`, `MaxLength = 255`).
       - `lblThongKeMon` (Badge thông báo: `"📌 Danh mục này đang có X món ăn"`).
       - Cụm 4 nút chức năng (`tlpButtons` 2×2):
         - `btnThem` (`"➕ Thêm mới"`, nền xanh lá `#16A34A`)
         - `btnCapNhat` (`"💾 Cập nhật"`, nền xanh dương `#2563EB`)
         - `btnXoa` (`"🗑️ Xóa danh mục"`, nền đỏ `#DC2626`)
         - `btnLamMoi` (`"🔄 Làm mới ô nhập"`, nền xám `#475569`)
     - **Cột phải (`pnlGridCard`):**
       - Thanh công cụ tìm kiếm (`pnlSearchBar`, `Dock = Top`, `Height = 52px`): Ô `txtTimKiem` + nút `btnTimKiem` + nút `btnTaiLai`.
       - Bảng dữ liệu `dgvDanhMuc` (`Dock = Fill`, `AutoSizeColumnsMode = Fill`, `SelectionMode = FullRowSelect`, `ReadOnly = True`, `AllowUserToAddRows = False`):
         - Cột 1: `colMa` (`Mã DM`, rộng `12%`, căn giữa)
         - Cột 2: `colTen` (`Tên danh mục`, rộng `32%`, in đậm)
         - Cột 3: `colMoTa` (`Mô tả chi tiết`, rộng `40%`)
         - Cột 4: `colSoMon` (`Số món`, rộng `16%`, căn giữa)

---

## 4. QUY TRÌNH 5 BƯỚC TRIỂN KHAI SPRINT `frmDanhMuc v1.0`

- [x] **Bước 1: Phân tích nghiệp vụ, tạo Sprint Plan (`DANH_MUC_SPRINT.md`) & Interactive HTML Mockup (`frmDanhMuc_mockup_v1_0.html`) để PO review**
- [ ] **Bước 2: Thiết kế giao diện WinForms (`Features/Menu/frmDanhMuc.Designer.vb`)**
- [ ] **Bước 3: Xây dựng tầng `DTO` (`DanhMucDTO.vb`), `DAO` (`DanhMucDAO.vb`), `BUS` (`DanhMucBUS.vb`) và xử lý sự kiện `frmDanhMuc.vb`**
- [ ] **Bước 4: Kết nối vào `frmMain` (`btnMenuThucDon` / `btnQuickThucDon`) & Chạy bộ Kiểm thử tự động (CRUD + Validation + Anti-Overlap Layout + RBAC)**
- [ ] **Bước 5: Tạo Release Report (`docs/release_report/report_0_2_3.html`) & Đánh dấu hoàn thành `[x]` trong `CHECKLIST_UU_TIEN_DANH_MUC.md` + `CHECKLIST_DO_AN.md`**
