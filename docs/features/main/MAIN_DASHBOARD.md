# KẾ HOẠCH SPRINT: PHÂN HỆ MÀN HÌNH CHÍNH (MAIN DASHBOARD SPRINT PLAN)

**Dự án:** Hệ thống Quản lý Quán ăn (VB.NET WinForms - .NET 10.0)  
**Phân hệ:** `Features/Main/` (App Shell / Khung điều hướng & Phân quyền giao diện)  
**Tài liệu tham chiếu:** [`KIEN_TRUC_HE_THONG.md`](../../KIEN_TRUC_HE_THONG.md) & [`MA_TRAN_PHAN_QUYEN.md`](../../MA_TRAN_PHAN_QUYEN.md)  

---

## 1. MỤC TIÊU SPRINT & ĐIỀU KIỆN HOÀN THÀNH (DEFINITION OF DONE)

- **Mục tiêu:** Xây dựng màn hình khung trung tâm (`frmMain`) của hệ thống làm cửa ngõ điều hướng cho toàn bộ ứng dụng, hiển thị thông tin phiên làm việc, áp dụng cơ chế tự động phân quyền theo vai trò (RBAC) và nhúng các màn hình con nghiệp vụ.
- **Thư mục triển khai:** `Quanlyquanan/Features/Main/`
- **Tiêu chuẩn nghiệm thu (DoD):**
  1. Hiển thị thanh Header thông tin tài khoản hiện tại: Họ tên nhân viên, vai trò (*Chủ quán, Quản lý, Phục vụ, Nhà bếp*) và đồng hồ thời gian thực (`Timer`).
  2. Sidebar điều hướng phân nhóm rõ ràng các phân hệ nghiệp vụ, gắn thẻ `Tag` chuẩn theo [MA_TRAN_PHAN_QUYEN.md](../../MA_TRAN_PHAN_QUYEN.md).
  3. Áp dụng tự động `PhanQuyenHelper.PhanQuyenForm(Me)` khi Form nạp: Nút chức năng tự động ẩn/khóa nếu tài khoản không có quyền.
  4. Khu vực trung tâm (`pnlContent`) hỗ trợ cơ chế nạp linh hoạt các Form con vào bên trong (`TopLevel = False`, `Dock = Fill`).
  5. Xử lý chức năng **Đăng xuất (Logout)**: Xóa thông tin `Session` và đưa người dùng an toàn trở lại màn hình `frmDangNhap`.
  6. Xử lý chức năng **Thoát ứng dụng**: Hỏi xác nhận đóng phần mềm.
  7. Kiểm thử thành công trên cả 4 vai trò mẫu: `chuquan`, `quanly`, `phucvu1`, `nhabep1`.

---

## 2. QUY TRÌNH 5 BƯỚC TRIỂN KHAI CHI TIẾT (STEP-BY-STEP)

```
┌────────────────────────────────────────────────────────────────────────┐
│                        LỘ TRÌNH 5 BƯỚC THỰC HIỆN                       │
│                                                                        │
│   Bước 1: Đặc tả UI ──► Bước 2: Thiết kế GUI ──► Bước 3: Logic & RBAC │
│   (Layout & Tag)        (frmMain.Designer)       (frmMain.vb)          │
│                                                        │               │
│                                 Bước 5: Test 4 vai trò ◄── Bước 4: Nối │
│                                 (Nghiệm thu RBAC)         (Auth ➔ Main)│
└────────────────────────────────────────────────────────────────────────┘
```

---

### BƯỚC 1: Đặc tả Bố cục Giao diện & Ánh xạ Mã quyền (Tag Matrix)
- **Cấu trúc bố cục Form chính:**
  - **Top Bar (Header - `pnlHeader`):** 
    - Bên trái: Tên phần mềm / Tên quán ăn (`lblBrand`).
    - Bên phải: Họ tên nhân viên, Vai trò (`lblUserInfo`), Đồng hồ (`lblClock`), Nút Đăng xuất (`btnDangXuat`).
  - **Sidebar (Thanh menu trái - `pnlSidebar`):**
    - Chứa danh sách các nút điều hướng nghiệp vụ.
  - **Content Area (Vùng làm việc trung tâm - `pnlContent`):**
    - Panel trống dùng để chứa Form nghiệp vụ con khi được kích hoạt hoặc trang Dashboard thống kê nhanh ban đầu.
  - **Status Bar (Dưới cùng - `statusStrip`):**
    - Trạng thái kết nối CSDL, phiên bản phần mềm.

- **Bảng ánh xạ `Tag` phân quyền trên Sidebar:**

| STT | Nút giao diện | Text hiển thị | Thuộc tính `Tag` | Vai trò có quyền truy cập |
| :---: | :--- | :--- | :--- | :--- |
| 1 | `btnSoDoBan` | 🍽️ Bàn ăn & Gọi món | `POS_SO_DO_BAN` | Chủ quán, Quản lý, Phục vụ |
| 2 | `btnNhaBep` | 🍳 Nhà bếp & Pha chế | `B_XEM_MON_CHE_BIEN` | Chủ quán, Nhà bếp |
| 3 | `btnDuyetChamCong` | 🕒 Duyệt chấm công | `QL_DUYET_CHAM_CONG` | Chủ quán, Quản lý |
| 4 | `btnQuanLyNhanSu` | 👥 Quản lý Nhân sự | `CQ_QUAN_LY_NHAN_VIEN` | Chủ quán |
| 5 | `btnQuanLyThucDon` | 📋 Thực đơn & Bàn ăn | `CQ_QUAN_LY_THUC_DON` | Chủ quán |
| 6 | `btnBaoCaoThongKe` | 📊 Báo cáo & Doanh thu | `CQ_BAO_CAO_THONG_KE` | Chủ quán |
| 7 | `btnChamCongCaNhan`| ⏱️ Chấm công cá nhân | `CHUNG_CHAM_CONG_CA_NHAN`| Tất cả nhân viên |
| 8 | `btnDoiMatKhau` | 🔑 Đổi mật khẩu | `CHUNG_DOI_MAT_KHAU` | Tất cả nhân viên |

---

### BƯỚC 2: Thiết kế Giao diện `frmMain.Designer.vb`
- **Vị trí file:** `Quanlyquanan/Features/Main/frmMain.Designer.vb`
- **Thông số kỹ thuật:**
  - `WindowState`: `Maximized` (Mở rộng toàn màn hình) hoặc `Size`: 1200 x 750 (mặc định mở giữa màn hình).
  - `StartPosition`: `CenterScreen`.
  - Sử dụng Font Segoe UI đồng bộ với `frmDangNhap`.
  - Màu sắc chủ đạo: 
    - Header: `#2C3E50` (Midnight Navy sang trọng).
    - Sidebar: `#34495E` (Wet Asphalt sạch sẽ, hiện đại).
    - Nút được chọn (Active): `#2980B9` (Belize Hole Blue).
    - Nút Đăng xuất: `#C0392B` (Pomegranate Red cảnh báo).
    - Vùng làm việc: `#ECF0F1` (Clouds Gray).

---

### BƯỚC 3: Xây dựng Tầng Logic & Kích hoạt Phân quyền (`frmMain.vb`)
- **Vị trí file:** `Quanlyquanan/Features/Main/frmMain.vb`
- **Các phương thức chính:**
  1. `frmMain_Load`:
     - Nạp thông tin từ `Session` lên Header: `lblUserInfo.Text = Session.HoTenNhanVien & " (" & Session.TenVaiTro & ")"`.
     - Kích hoạt Timer đồng hồ: cập nhật `DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")`.
     - **Gọi phân quyền:** `PhanQuyenHelper.PhanQuyenForm(Me)` để ẩn/hiện hoặc bật/tắt các nút trên Sidebar.
     - Mặc định mở màn hình chào mừng hoặc trang Sơ đồ bàn ăn (nếu có quyền).
  2. `MoFormCon(childForm As Form)`:
     - Đóng hoặc xóa các Control cũ trong `pnlContent`.
     - Cấu hình Form con: `childForm.TopLevel = False`, `childForm.FormBorderStyle = None`, `childForm.Dock = DockStyle.Fill`.
     - Thêm vào Panel: `pnlContent.Controls.Add(childForm)` và gọi `childForm.Show()`.
  3. `btnDangXuat_Click`:
     - Hiện hộp thoại xác nhận: *"Bạn có chắc chắn muốn đăng xuất?"*.
     - Nếu đồng ý: Xóa phiên `Session.Clear()`, ẩn `frmMain` và hiển thị lại `frmDangNhap`.
  4. `frmMain_FormClosing`:
     - Nếu người dùng bấm nút [X] của cửa sổ: Xác nhận thoát toàn bộ chương trình và đảm bảo giải phóng bộ nhớ.

---

### BƯỚC 4: Đấu nối Chuyển hướng từ `frmDangNhap`
- **Cập nhật file:** `Quanlyquanan/Features/Auth/frmDangNhap.vb`
- **Xử lý sự kiện đăng nhập thành công:**
  - Sau khi `AuthBUS.DangNhap` trả về `True` và hiển thị thông báo chào mừng:
  - Khởi tạo instance `frmMain`:
    ```vbnet
    Dim fMain As New frmMain()
    AddHandler fMain.FormClosed, Sub(s, args) Me.Close() ' Đóng ứng dụng khi đóng frmMain
    fMain.Show()
    Me.Hide() ' Ẩn màn hình đăng nhập
    ```

---

### BƯỚC 5: Kiểm thử Nghiệm thu Đa Vai trò (Multi-Role RBAC Testing)

Thực hiện đăng nhập lần lượt bằng 4 tài khoản mẫu để kiểm tra kết quả phân quyền trên giao diện:

| Tài khoản | Mật khẩu | Vai trò | Kết quả kỳ vọng trên giao diện `frmMain` |
| :--- | :---: | :--- | :--- |
| `chuquan` | `123456` | **Chủ quán** | Thấy toàn bộ menu: Bàn ăn, Bếp, Duyệt công, Nhân sự, Thực đơn, Báo cáo, Đổi MK. |
| `quanly` | `123456` | **Quản lý** | Thấy menu: Bàn ăn, Duyệt chấm công, Chấm công cá nhân, Đổi MK. *Ẩn/Khóa: Báo cáo, Quản lý Nhân sự.* |
| `phucvu1` | `123456` | **Nhân viên phục vụ** | Chỉ thấy menu: Bàn ăn & Gọi món, Chấm công cá nhân, Đổi MK. *Ẩn/Khóa các menu quản lý.* |
| `nhabep1` | `123456` | **Nhà bếp** | Chỉ thấy menu: Nhà bếp & Pha chế, Chấm công cá nhân, Đổi MK. *Ẩn/Khóa các menu bán hàng & quản lý.* |

---

## 3. CHECKLIST THEO DÕI TIẾN ĐỘ SPRINT

- [x] **Bước 1:** Hoàn thiện tài liệu đặc tả bố cục và ma trận Tag (DoD 1) (chi tiết tại [`MAIN_UI_VA_PHAN_QUYEN.md`](MAIN_UI_VA_PHAN_QUYEN.md)).
- [x] **Bước 2:** Tạo file `frmMain.Designer.vb` và `frmMain.resx` với đầy đủ component (DoD 2).
- [x] **Bước 3:** Viết code xử lý logic `frmMain.vb` (nạp Session, Timer, mở form con, phân quyền) (DoD 3, 4).
- [x] **Bước 4:** Cập nhật `frmDangNhap.vb` để mở `frmMain` sau khi xác thực thành công (DoD 5).
- [ ] **Bước 5:** Chạy thử ứng dụng, kiểm thử đăng nhập 4 vai trò và xác nhận phân quyền hoạt động 100% (DoD 6, 7).
- [ ] **Bước 6:** Commit mã nguồn lên Git và cập nhật tài liệu tổng kết.
