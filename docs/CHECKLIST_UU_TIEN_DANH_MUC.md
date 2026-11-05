# CHECKLIST ƯU TIÊN: 5 MÀN HÌNH DANH MỤC NỀN TẢNG (MASTER DATA)

**Dự án:** Hệ thống Quản lý Quán ăn (`Quanlyquanan`)  
**Công nghệ:** VB.NET Windows Forms (.NET 10.0) + SQL Server 2022 (Docker)  
**Liên kết Checklist tổng:** [`docs/CHECKLIST_DO_AN.md`](CHECKLIST_DO_AN.md)  
**Quy tắc đồng bộ:** Đây là 5 màn hình danh mục nền tảng (Master Data) được ưu tiên triển khai trước. Khi hoàn thành từng màn hình tại checklist này, các hạng mục tương ứng tại **Mục 3.5** của [`docs/CHECKLIST_DO_AN.md`](CHECKLIST_DO_AN.md) sẽ được đánh dấu `[x]` hoàn thành để không phải làm lại khi quay về luồng checklist chung.

---

## 1. BẢNG ÁNH XẠ ĐỒNG BỘ VỚI CHECKLIST CHUNG (`CHECKLIST_DO_AN.md`)

| STT | Màn hình theo yêu cầu ưu tiên | Tên Form (`VB.NET`) | Bảng CSDL liên quan | Quyền RBAC (`Q_Tag`) | Ánh xạ mục trùng trong `CHECKLIST_DO_AN.md` | Trạng thái |
| :-: | :--- | :--- | :--- | :--- | :--- | :-: |
| **1** | **MH Danh mục** | `frmDanhMuc` | `DanhMuc` | `CQ_QUAN_LY_THUC_DON` | Mục `3.5` — Quản lý Thực đơn *(Quản lý danh mục món)* | `[ ]` Chờ làm |
| **2** | **MH Món ăn** | `frmMonAn` | `MonAn`, `DanhMuc` | `CQ_QUAN_LY_THUC_DON` | Mục `3.5` — Quản lý Thực đơn *(Khởi tạo/chỉnh sửa món ăn, nước uống)* | `[ ]` Chờ làm |
| **3** | **MH Ca (hiển thị danh sách)** | `frmCaLamViec` | `CaLamViec` | `CQ_XEP_LICH_LAM_VIEC` | Mục `3.5` — Quản lý Lịch làm việc *(Cấu hình/hiển thị danh sách ca & khung giờ)* | `[ ]` Chờ làm |
| **4** | **MH Khu vực (Tầng trệt, Tầng 1, ...)** | `frmKhuVuc` | `KhuVuc` *(+ đồng bộ `Ban.B_KhuVuc`)* | `CQ_QUAN_LY_BAN` | Mục `3.5` — Quản lý Bàn ghế & Khu vực *(Tổ chức khu vực bàn)* | `[ ]` Chờ làm |
| **5** | **MH Bàn** | `frmBan` | `Ban`, `KhuVuc` | `CQ_QUAN_LY_BAN` | Mục `3.5` — Quản lý Bàn ghế (`frmQuanLyBan`: *Thêm/Sửa/Xóa bàn, STT, số người tối đa*) | `[ ]` Chờ làm |

> **Lý do thứ tự triển khai (1 → 5):**
> - **Cặp Thực đơn (`1. MH Danh mục` → `2. MH Món ăn`):** Phải có `DanhMuc` trước để `ComboBox` Danh mục trên `frmMonAn` nạp dữ liệu khóa ngoại (`MA_DanhMuc`).
> - **Độc lập (`3. MH Ca làm việc`):** Hiển thị danh sách ca làm việc (`Ca Sáng`, `Ca Chiều Tối`, giờ bắt đầu/kết thúc, lương mỗi ca).
> - **Cặp Không gian bàn (`4. MH Khu vực` → `5. MH Bàn`):** Phải có danh mục `KhuVuc` (*Tầng trệt, Tầng 1, Phòng VIP, Sân vườn...*) trước để `ComboBox` Khu vực trên `frmBan` chọn đúng khu vực chuẩn hóa.

---

## 2. CHECKLIST CHI TIẾT TỪNG MÀN HÌNH (QUY TRÌNH 5 BƯỚC CHUẨN)

### MÀN HÌNH 1: MH DANH MỤC (`frmDanhMuc`)
> **Mục tiêu:** Quản lý các nhóm phân loại thực đơn (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa` — VD: *Món Khai Vị & Gỏi, Món Chính, Món Lẩu & Nướng, Thức Uống, Tráng Miệng*).

- [x] **Bước 1: Đặc tả Nghiệp vụ, UI/UX & Mockup HTML (`docs/features/menu/danh_muc/`)**
  - [x] Tạo tài liệu đặc tả `DANH_MUC_SPRINT.md` và file mockup `frmDanhMuc_mockup_v1_0.html` để PO duyệt.
- [ ] **Bước 2: Thiết kế Giao diện WinForms (`Features/Menu/frmDanhMuc.Designer.vb`)**
  - [ ] Thiết kế bố cục: Khung nhập liệu (`Mã DM`, `Tên danh mục`, `Mô tả`), thanh tìm kiếm nhanh, các nút `Thêm`, `Sửa`, `Xóa`, `Làm mới`, và lưới `DataGridView` hiển thị danh sách danh mục kèm tổng số món ăn thuộc từng danh mục.
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmDanhMuc.vb`)**
  - [ ] Tạo `DanhMucDTO.vb`, `DanhMucDAO.vb`, `DanhMucBUS.vb`.
  - [ ] Ràng buộc nghiệp vụ: Không để trống `DM_Ten`, kiểm tra trùng tên danh mục, xóa mềm (`DM_Xoa = 1`) và chặn xóa nếu danh mục đang chứa món ăn đang kinh doanh.
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (Automated Verification)**
  - [ ] Gắn sự kiện mở `frmDanhMuc` từ `frmMain` (phân quyền `CQ_QUAN_LY_THUC_DON`).
  - [ ] Chạy bộ test tự động kiểm tra CRUD + Validation + Layout Geometry.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/`) & Đồng bộ `CHECKLIST_DO_AN.md`**

---

### MÀN HÌNH 2: MH MÓN ĂN (`frmMonAn`)
> **Mục tiêu:** Quản lý danh sách món ăn & thức uống (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon`, `MA_MoTa`, `MA_Xoa`).

- [ ] **Bước 1: Đặc tả Nghiệp vụ, UI/UX & Mockup HTML (`docs/features/menu/mon_an/`)**
  - [ ] Tạo tài liệu đặc tả `MON_AN_SPRINT.md` và file mockup `frmMonAn_mockup_v1_0.html` để PO duyệt.
- [ ] **Bước 2: Thiết kế Giao diện WinForms (`Features/Menu/frmMonAn.Designer.vb`)**
  - [ ] Thiết kế bố cục: Bộ lọc theo `Danh mục` + Từ khóa + Trạng thái (`Còn món` / `Hết món`), khung chi tiết (`Tên món`, `ComboBox Danh mục`, `Đơn giá VNĐ`, `CheckBox Báo hết món`, `Mô tả`), các nút `Thêm`, `Sửa`, `Xóa`, `Làm mới` và lưới `DataGridView` định dạng tiền tệ `#,##0 đ`.
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmMonAn.vb`)**
  - [ ] Tạo `MonAnDTO.vb`, `MonAnDAO.vb`, `MonAnBUS.vb`.
  - [ ] Ràng buộc nghiệp vụ: `MA_Ten` bắt buộc, `MA_DonGia >= 0`, `MA_DanhMuc` hợp lệ, hỗ trợ bật/tắt nhanh trạng thái `Hết món` (`MA_HetMon`), xóa mềm (`MA_Xoa = 1`).
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (Automated Verification)**
  - [ ] Mở từ `btnMenuThucDon` / `btnQuickThucDon` trên `frmMain` (hoặc điều hướng liên hoàn giữa `frmDanhMuc` ↔ `frmMonAn`).
  - [ ] Chạy bộ test tự động kiểm tra CRUD + Filter theo Danh mục + Validation giá bán.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/`) & Đánh dấu `[x]` Mục 3.5 Quản lý Thực đơn trong `CHECKLIST_DO_AN.md`**

---

### MÀN HÌNH 3: MH CA LÀM VIỆC — HIỂN THỊ DANH SÁCH (`frmCaLamViec`)
> **Mục tiêu:** Hiển thị trực quan danh sách các ca làm việc trong ngày (`CA_Ma`, `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `CA_LuongMoiCa`, `CA_Xoa` — VD: *Ca 1 (Ca Sáng) 08:00–15:00, Ca 2 (Ca Chiều Tối) 15:00–22:00*) kèm thông tin khung giờ và định mức lương mỗi ca.

- [ ] **Bước 1: Đặc tả Nghiệp vụ, UI/UX & Mockup HTML (`docs/features/shift/ca_lam_viec/`)**
  - [ ] Tạo tài liệu đặc tả `CA_LAM_VIEC_SPRINT.md` và file mockup `frmCaLamViec_mockup_v1_0.html` để PO duyệt.
- [ ] **Bước 2: Thiết kế Giao diện WinForms (`Features/Shift/frmCaLamViec.Designer.vb`)**
  - [ ] Thiết kế bố cục: Bảng danh sách ca làm việc (`DataGridView`) hiển thị rõ `Mã ca`, `Tên ca`, `Giờ bắt đầu`, `Giờ kết thúc`, `Số giờ làm`, `Lương mỗi ca (VNĐ)`, cùng khu vực thông tin chi tiết ca / cập nhật cấu hình ca (nếu là Chủ quán).
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmCaLamViec.vb`)**
  - [ ] Tạo `CaLamViecDTO.vb`, `CaLamViecDAO.vb`, `CaLamViecBUS.vb`.
  - [ ] Nạp danh sách ca từ bảng `CaLamViec`, tính tự động thời lượng ca (số giờ) và định dạng tiền lương.
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (Automated Verification)**
  - [ ] Kết nối vào nhóm chức năng Lịch & Ca làm việc trên `frmMain`.
  - [ ] Kiểm thử tự động truy vấn danh sách ca & hiển thị UI.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/`) & Đánh dấu `[x]` mục danh sách ca trong `CHECKLIST_DO_AN.md`**

---

### MÀN HÌNH 4: MH KHU VỰC — TẦNG TRỆT, TẦNG 1, ... (`frmKhuVuc`)
> **Mục tiêu:** Quản lý danh sách Khu vực bố trí bàn trong quán (*Tầng trệt, Tầng 1 / Lầu 1 (Máy lạnh), Phòng VIP Máy lạnh, Sân vườn thoáng mát...*).

- [ ] **Bước 1: Đặc tả Nghiệp vụ, CSDL `KhuVuc`, UI/UX & Mockup HTML (`docs/features/table/khu_vuc/`)**
  - [ ] Bổ sung bảng `KhuVuc` (`KV_Ma`, `KV_Ten`, `KV_MoTa`, `KV_Xoa`) vào `create-database.sql` & `seed-data.sql` (đảm bảo Idempotent 100% và đồng bộ với cột `B_KhuVuc` của bảng `Ban`).
  - [ ] Tạo tài liệu đặc tả `KHU_VUC_SPRINT.md` và file mockup `frmKhuVuc_mockup_v1_0.html` để PO duyệt.
- [ ] **Bước 2: Thiết kế Giao diện WinForms (`Features/Table/frmKhuVuc.Designer.vb`)**
  - [ ] Thiết kế bố cục: Khung nhập `Tên khu vực` (*Tầng trệt, Tầng 1...*), `Mô tả / Ghi chú`, các nút `Thêm`, `Sửa`, `Xóa`, `Làm mới`, và lưới `DataGridView` hiển thị danh sách khu vực kèm số lượng bàn hiện có trong từng khu vực.
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmKhuVuc.vb`)**
  - [ ] Tạo `KhuVucDTO.vb`, `KhuVucDAO.vb`, `KhuVucBUS.vb`.
  - [ ] Ràng buộc nghiệp vụ: Không trùng tên khu vực, khi đổi tên khu vực tự động đồng bộ tên khu vực cho các bàn thuộc khu vực đó, chặn xóa khu vực đang có bàn hoạt động.
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (Automated Verification)**
  - [ ] Chạy bộ test tự động kiểm tra CRUD Khu vực + ràng buộc toàn vẹn với bảng `Ban`.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/`) & Đồng bộ `CHECKLIST_DO_AN.md`**

---

### MÀN HÌNH 5: MH BÀN (`frmBan`)
> **Mục tiêu:** Quản lý danh sách Bàn ăn (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_KhuVuc`, `B_SoNguoiToiDa`, `B_TrangThai`, `B_Xoa`).

- [ ] **Bước 1: Đặc tả Nghiệp vụ, UI/UX & Mockup HTML (`docs/features/table/ban/`)**
  - [ ] Tạo tài liệu đặc tả `BAN_SPRINT.md` và file mockup `frmBan_mockup_v1_0.html` để PO duyệt.
- [ ] **Bước 2: Thiết kế Giao diện WinForms (`Features/Table/frmBan.Designer.vb`)**
  - [ ] Thiết kế bố cục: Bộ lọc theo `Khu vực` + `Trạng thái bàn`, khung nhập liệu (`Số thứ tự bàn`, `Tên bàn`, `ComboBox Khu vực` lấy từ `MH Khu vực`, `Số người tối đa` bằng `NumericUpDown`, `Trạng thái`), các nút `Thêm`, `Sửa`, `Xóa`, `Làm mới` và lưới `DataGridView`.
- [ ] **Bước 3: Xây dựng Tầng Dữ liệu & Nghiệp vụ (`DTO` / `DAO` / `BUS` / `frmBan.vb`)**
  - [ ] Tạo `BanDTO.vb`, `BanDAO.vb`, `BanBUS.vb`.
  - [ ] Ràng buộc nghiệp vụ: `B_SoThuTu` duy nhất (`> 0`), `B_SoNguoiToiDa > 0`, không cho phép xóa bàn đang có khách phục vụ (`B_TrangThai <> 0`).
- [ ] **Bước 4: Kết nối `frmMain` & Kiểm thử tự động (Automated Verification)**
  - [ ] Mở từ `btnMenuQuanLyBan` / `btnQuickQuanLyBan` trên `frmMain` (phân quyền `CQ_QUAN_LY_BAN`), hỗ trợ nút mở nhanh sang `frmKhuVuc`.
  - [ ] Chạy bộ test tự động kiểm tra CRUD Bàn + Ràng buộc `B_SoThuTu` + `B_SoNguoiToiDa`.
- [ ] **Bước 5: Báo cáo Phát hành (`docs/release_report/`) & Đánh dấu `[x]` Mục 3.5 Quản lý Bàn ghế trong `CHECKLIST_DO_AN.md`**

---

## 3. LỘ TRÌNH SAU KHI HOÀN TẤT 5 MÀN HÌNH ƯU TIÊN
Sau khi hoàn thành cả 5 màn hình trên (`[x] 5/5`), dự án sẽ quay lại thực hiện tiếp [`docs/CHECKLIST_DO_AN.md`](CHECKLIST_DO_AN.md):
1. Tiếp tục từ **Mục 3.2**: `frmChamCongCaNhan` (Màn hình Cá nhân & Chấm công).
2. Sang **Mục 3.3**: Phân hệ Nhân viên phục vụ (`frmSoDoBan`, Gọi món, Chuyển/Gộp bàn, Thanh toán) — *lúc này đã có sẵn toàn bộ dữ liệu chuẩn từ 5 màn hình `DanhMuc`, `MonAn`, `CaLamViec`, `KhuVuc`, `Ban`!*
3. Sang **Mục 3.4**: Phân hệ Nhà bếp (`frmNhaBep`).
4. Sang **Mục 3.5**: Các mục `Quản lý Bàn ghế`, `Quản lý Thực đơn`, `Danh sách ca` đã được đánh dấu `[x]` hoàn thành từ Checklist ưu tiên này, chỉ cần làm tiếp các màn hình còn lại (`frmQuanLyNhanVien`, `frmQuanLyLichLamViec`, `frmDuyetChamCong`, `frmBaoCao`).
