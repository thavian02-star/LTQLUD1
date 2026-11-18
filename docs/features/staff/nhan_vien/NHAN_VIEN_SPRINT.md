# 📋 TÀI LIỆU ĐẶC TẢ KỸ THUẬT & SPRINT PLAN: QUẢN LÝ NHÂN SỰ (`frmNhanVien` v1.0)

> **Phân hệ:** Quản lý Nhân sự & Tuyển dụng (`Features/Staff`)  
> **Màn hình nền tảng:** Màn hình 6 / 9 thuộc [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](../../../CHECKLIST_UU_TIEN_DANH_MUC.md)  
> **Phiên bản mục tiêu:** `v0.2.8`  
> **Bảng CSDL chính:** `NhanVien`, `TrinhDoViTinh`, `NhanVien_ViTinh`, `DungCuTrangPhuc`, `NhanVien_DungCu`, `TaiKhoan`  
> **Phân quyền RBAC:** `CQ_QUAN_LY_NHAN_SU` (Chủ quán & Quản lý toàn quyền Thêm/Sửa/Khóa; Phục vụ & Nhà bếp chỉ xem hoặc không truy cập).

---

## 1. MỤC TIÊU NGHIỆP VỤ (BUSINESS GOALS)

Màn hình **Quản lý Danh sách Nhân viên (`frmNhanVien`)** là trung tâm quản trị toàn bộ vòng đời nhân sự của quán ăn:
1. **Tiếp nhận hồ sơ tuyển dụng:** Lưu trữ đầy đủ thông tin cá nhân (Họ tên, Giới tính, Ngày sinh, CCCD, SĐT, Email, Địa chỉ, Học vấn, Ngoại ngữ).
2. **Kỹ năng vi tính chuẩn hóa:** Quản lý danh sách các trình độ vi tính của nhân viên qua bảng trung gian `NhanVien_ViTinh` (*Word, Excel, Phần mềm POS, Khác*).
3. **Quản lý cấp phát trang phục & dụng cụ:** Theo dõi số lượng áo đồng phục, tạp dề, nón bếp, bảng tên cấp phát cho nhân viên và tình trạng thu hồi khi nghỉ việc (`NhanVien_DungCu`).
4. **Liên kết tài khoản đăng nhập (RBAC):** Gắn nhân viên với tài khoản hệ thống (`TaiKhoan`), tự động cấp vai trò phù hợp (Chủ quán, Quản lý, Phục vụ, Nhà bếp).
5. **Nghiệp vụ nhân viên thôi việc:** Cập nhật trạng thái `Đã nghỉ việc`, lưu ngày thôi việc, cảnh báo thu hồi đồng phục còn giữ, và hủy kích hoạt tài khoản tương ứng.

### Các chức năng cốt lõi của `frmNhanVien` v1.0:
- **Hiển thị trực quan Danh sách Nhân viên:**
  - Bảng lưới `dgvNhanVien` hiển thị: `Mã NV`, `Họ tên`, `Giới tính`, `Vị trí`, `Điện thoại`, `CCCD`, `Trạng thái`, `Tài khoản liên kết`.
- **4 Thẻ Thống kê nhanh (KPI Cards):**
  1. **Tổng nhân viên:** Tổng số nhân viên đã và đang làm việc (`7 người`).
  2. **Đang làm việc:** Nhân viên đang hoạt động (`6 người`).
  3. **Đã nghỉ việc:** Nhân viên đã thôi việc (`1 người`).
  4. **Có tài khoản:** Nhân viên đã được cấp tài khoản phần mềm (`6 người`).
- **Bộ lọc đa chiều & Tìm kiếm nhanh:**
  - Lọc theo **Vị trí** (*Tất cả, Chủ quán, Quản lý, Phục vụ, Đầu bếp chính, Pha chế, Tiếp tân*).
  - Lọc theo **Trạng thái** (*Tất cả, Đang làm việc, Đã nghỉ việc*).
  - Tìm kiếm tức thời theo từ khóa: Tên nhân viên, Số điện thoại hoặc CCCD.
- **Thao tác Thêm / Sửa / Xóa mềm & Nghiệp vụ Thôi việc:**
  - Kiểm tra ràng buộc: `NV_HoTen` bắt buộc, `NV_ViTri` bắt buộc, `NV_DienThoai` đúng định dạng, `NV_CMND` duy nhất.
  - Hỗ trợ tích chọn nhiều kỹ năng vi tính trên `CheckedListBox`.
  - Hiển thị badge thống kê trang phục đang giữ.

---

## 2. THIẾT KẾ CƠ SỞ DỮ LIỆU & TRUY VẤN SQL

### 2.1. Cấu trúc bảng `NhanVien`
| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
| :--- | :--- | :--- | :--- |
| `NV_Ma` | `INT IDENTITY(1,1)` | `PRIMARY KEY` | Mã định danh nhân viên |
| `NV_HoTen` | `NVARCHAR(100)` | `NOT NULL` | Họ và tên đầy đủ |
| `NV_GioiTinh` | `BIT` | `DEFAULT 1` | 1: Nam, 0: Nữ |
| `NV_NgaySinh` | `DATE` | `NULL` | Ngày tháng năm sinh |
| `NV_ViTri` | `NVARCHAR(50)` | `NOT NULL` | Vị trí công việc (Phục vụ, Pha chế, Quản lý, Bếp...) |
| `NV_CMND` | `NVARCHAR(20)` | `NULL UNIQUE` | Số CCCD / CMND |
| `NV_DienThoai` | `NVARCHAR(20)` | `NULL` | Số điện thoại liên lạc |
| `NV_Email` | `NVARCHAR(100)` | `NULL` | Địa chỉ email |
| `NV_DiaChi` | `NVARCHAR(255)` | `NULL` | Địa chỉ thường trú / tạm trú |
| `NV_TrinhDoHocVan` | `NVARCHAR(100)` | `NULL` | Trình độ học vấn (12/12, Trung cấp, Đại học...) |
| `NV_NgoaiNgu` | `NVARCHAR(255)` | `NULL` | Ngoại ngữ (Tiếng Anh, Tiếng Hoa...) |
| `NV_NgayBatDauLam`| `DATE` | `DEFAULT GETDATE()` | Ngày bắt đầu làm việc |
| `NV_NgayThoiViec` | `DATE` | `NULL` | Ngày chính thức thôi việc |
| `NV_MaTaiKhoan` | `INT` | `NULL, FK TaiKhoan` | Tài khoản đăng nhập hệ thống |
| `NV_TrangThai` | `NVARCHAR(30)` | `DEFAULT N'Đang làm việc'` | Đang làm việc / Đã nghỉ việc |
| `NV_Xoa` | `BIT` | `DEFAULT 0` | 0: Đang hoạt động, 1: Đã xóa mềm |

### 2.2. Dữ liệu mẫu chuẩn (7 Nhân viên từ Seed Data)
| `NV_Ma` | Họ tên | Giới tính | Vị trí | Điện thoại | CCCD | Tài khoản | Trạng thái |
| :---: | :--- | :---: | :--- | :---: | :---: | :---: | :--- |
| `1` | Nguyễn Hoàng Nam | Nam | Chủ quán | 0903112233 | 079085001234 | `chuquan` (#1) | Đang làm việc |
| `2` | Trần Thị Thu Thảo | Nữ | Quản lý | 0908445566 | 079193004567 | `quanly` (#2) | Đang làm việc |
| `3` | Lê Minh Tuấn | Nam | Phục vụ | 0912334455 | 079202007891 | `phucvu1` (#3) | Đang làm việc |
| `4` | Phạm Ngọc Ánh | Nữ | Phục vụ | 0937667788 | 079303009876 | `phucvu2` (#4) | Đang làm việc |
| `5` | Võ Văn Hùng | Nam | Đầu bếp chính | 0979112299 | 079090003456 | `nhabep1` (#5) | Đang làm việc |
| `6` | Đặng Quốc Bảo | Nam | Pha chế | 0984556677 | 079201006543 | `phache1` (#6) | Đang làm việc |
| `7` | Hoàng Gia Huy | Nam | Phục vụ | 0965889900 | 079203001122 | *(Không có)* | Đã nghỉ việc |

---

## 3. THIẾT KẾ GIAO DIỆN & BỐ CỤC (UI/UX GEOMETRY SPEC)

Màn hình `frmNhanVien` tuân thủ chuẩn **Split-Layout 40% : 60%** chuyên nghiệp:
- **Kích thước Form:** `ClientSize = New Size(1160, 700)`, `MinimumSize = New Size(1060, 660)`, `StartPosition = CenterParent`.
- **Tầng 1 — Header (`pnlHeader`, `Dock = Top, Height = 68px`):**
  - Nền Navy đậm `rgb(26, 82, 118)`.
  - Tiêu đề `lblTitle`: `"👥 QUẢN LÝ DANH SÁCH NHÂN SỰ"` + Phụ đề `lblSubtitle`: `"Danh mục chuẩn (6/9) • Hồ sơ nhân viên, vị trí, kỹ năng vi tính, cấp phát đồng phục & tài khoản"`.
  - Nút `btnDong` (`"✖ Đóng"`).
- **Tầng 2 — KPI Cards (`tlpKpiRow`, `Dock = Top, Height = 78px`, 4 cột `25%`):**
  - `pnlKpiTongNV`: **TỔNG NHÂN VIÊN** (`7 người`).
  - `pnlKpiDangLam`: **ĐANG LÀM VIỆC** (`6 người`).
  - `pnlKpiNghiViec`: **ĐÃ NGHỈ VIỆC** (`1 người`).
  - `pnlKpiCoTaiKhoan`: **ĐÃ CẤP TÀI KHOẢN** (`6 người`).
- **Tầng 3 — Nội dung chính (`tlpMainContent`, `Dock = Fill`, 2 cột `40% : 60%`):**
  - **Cột Trái (`pnlFormCard` - 40%):**
    - Tiêu đề `"📝 THÔNG TIN NHÂN SỰ"` + Badge trạng thái (`"CHẾ ĐỘ: THÊM MỚI"` / `"CHẾ ĐỘ: CẬP NHẬT"` / `"CHẾ ĐỘ: CHỈ XEM"`).
    - Hộp thông báo `lblThongBao`.
    - TabControl hoặc Nhóm trường nhập liệu 2 cột:
      - Mã NV (`txtMaNV` readonly), Họ tên (`txtHoTen`), Giới tính (`rdoNam` / `rdoNu`), Ngày sinh (`dtpNgaySinh`).
      - Vị trí (`cboViTri`), CCCD (`txtCMND`), SĐT (`txtDienThoai`), Email (`txtEmail`).
      - Học vấn (`cboHocVan`), Ngoại ngữ (`txtNgoaiNgu`), Ngày vào làm (`dtpNgayVaoLam`), Trạng thái (`cboTrangThai`).
      - Kỹ năng vi tính: `clbViTinh` (CheckedListBox 4 kỹ năng chuẩn).
      - Badge đồng phục cấp phát (`lblThongTinTrangPhuc`).
    - Cụm 4 nút CRUD (`tlpButtons`, `Dock = Bottom, Height = 80px`, lưới `2x2`): `➕ Thêm nhân viên`, `💾 Lưu cập nhật`, `🛑 Thôi việc / Xóa`, `🔄 Làm mới`.
  - **Cột Phải (`pnlGridCard` - 60%):**
    - `lblGridTitle` (`Dock = Top`).
    - `pnlFilterBar` (`Dock = Top, Height = 48px`, chứa `cboLocViTri`, `cboLocTrangThai`, `txtTimKiem`, `btnTaiLai`).
    - `dgvNhanVien` (`Dock = Fill`, 8 cột hiển thị thông tin rõ ràng).

---

## 4. CHECKLIST 5 BƯỚC THỰC HIỆN SPRINT (`frmNhanVien`)

- [x] **Bước 1: Đặc tả Kỹ thuật & Interactive Mockup HTML (`docs/features/staff/nhan_vien/`)**
  - [x] Tạo tài liệu đặc tả [`NHAN_VIEN_SPRINT.md`](NHAN_VIEN_SPRINT.md).
  - [x] Tạo file Mockup tương tác [`frmNhanVien_mockup_v1_0.html`](frmNhanVien_mockup_v1_0.html) với 5 kịch bản mô phỏng trực quan.
- [x] **Bước 2: Thiết kế Giao diện WinForms (`Quanlyquanan/Features/Staff/frmNhanVien.Designer.vb`)**
  - [x] Thiết kế 3 tầng + Split-Layout 42:58 chống tràn, bố cục thẻ nhập liệu chuyên nghiệp.
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmNhanVien.vb`)**
  - [ ] Tạo `NhanVienDTO.vb`, `NhanVienDAO.vb`, `NhanVienBUS.vb` và hoàn thiện logic trong `frmNhanVien.vb`.
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (`NhanVienVerifier`)**
  - [ ] Tích hợp mở `frmNhanVien` từ menu Quản lý trên `frmMain.vb`.
  - [ ] Xây dựng test suite tự động kiểm tra Layout + CRUD + Validation + RBAC.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/report_0_2_8.html`), Đồng bộ 2 Checklist & Git Tag `v0.2.8`**
