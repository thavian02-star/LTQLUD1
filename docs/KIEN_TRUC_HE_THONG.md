# TÀI LIỆU KIẾN TRÚC HỆ THỐNG (SYSTEM ARCHITECTURE)
**Dự án:** Hệ thống Quản lý Quán ăn  
**Môn học:** Lập trình ứng dụng quản lý 1  
**Nền tảng:** Visual Basic .NET (.NET 10.0 Windows Forms)  
**Cơ sở dữ liệu:** Microsoft SQL Server 2022 Express (Docker)  
**Mô hình tổ chức:** **Package-by-Feature (Vertical Slice Architecture) trên nền tảng 3 lớp (3-Tier)**

---

## 1. TỔNG QUAN HỆ THỐNG

Phần mềm Quản lý Quán ăn được xây dựng nhằm hỗ trợ toàn diện các hoạt động vận hành thường nhật của một quán ăn/nhà hàng vừa và nhỏ, bao gồm 4 nhóm tác nhân (Actors):
1. **Chủ quán (Admin):** Quản lý hồ sơ nhân sự, xếp lịch làm việc theo tuần/tháng, thiết lập danh mục món ăn/bàn ghế, xem báo cáo doanh thu & thống kê, phân quyền tài khoản.
2. **Quản lý (Manager):** Xem lịch làm việc chung/cá nhân, duyệt bảng chấm công hàng ngày, hỗ trợ xử lý nghiệp vụ bán hàng khi cần thiết.
3. **Nhân viên phục vụ (Staff):** Quản lý trạng thái bàn (trống/có khách/đặt trước), ghi nhận order, thêm/hủy món, chuyển/gộp bàn, tính tiền & in hóa đơn, chấm công cá nhân.
4. **Nhà bếp / Pha chế (Kitchen):** Theo dõi danh sách món ăn đang chờ chế biến theo thứ tự thời gian thực, cập nhật trạng thái món đã chế biến xong để phục vụ mang lên.

---

## 2. MÔ HÌNH TỔ CHỨC MÃ NGUỒN (PACKAGE-BY-FEATURE)

### 2.1. Tại sao chọn Package-by-Feature thay vì Package-by-Layer truyền thống?
- **Package-by-Layer (Cũ):** Chia theo thư mục kỹ thuật `DTO/`, `DAO/`, `BUS/`, `GUI/`. Nhược điểm lớn: Khi cần xem luồng xử lý hoặc sửa một màn hình, lập trình viên phải nhảy qua lại giữa 4 thư mục khác nhau. Khi dự án có nhiều màn hình, danh sách file trong mỗi thư mục trở nên quá dài và khó tìm kiếm.
- **Package-by-Feature (Hiện tại):** Gom trọn gói mã nguồn theo **từng Màn hình / Phân hệ nghiệp vụ khép kín**.
  - Muốn xem luồng nghiệp vụ của màn hình nào $\rightarrow$ Chỉ cần mở đúng 1 thư mục của màn hình đó.
  - Mỗi phân hệ tự chứa Form (GUI), nghiệp vụ kiểm tra (BUS), truy vấn dữ liệu (DAO) và khuôn mẫu thực thể (DTO) riêng của mình.
  - Các tiện ích cốt lõi dùng chung (kết nối CSDL, băm mật khẩu, phiên làm việc) được đặt tập trung trong thư mục `Core/`.

### 2.2. Sơ đồ cấu trúc tổ chức mã nguồn

```text
Quanlyquanan/
│
├── Core/                               # NỀN TẢNG KỸ THUẬT DÙNG CHUNG (INFRASTRUCTURE)
│   ├── Database/
│   │   └── KetNoiCSDL.vb               # Quản lý SqlConnection & ExecuteQuery / ExecuteNonQuery / ExecuteScalar
│   ├── Security/
│   │   ├── MaHoaMD5.vb                 # Tiện ích băm mật khẩu chuẩn MD5 (seed data: 123456)
│   │   └── Session.vb                  # Lưu thông tin tài khoản đăng nhập & danh sách quyền RBAC
│   └── Helpers/
│       └── PhanQuyenHelper.vb          # Tự động duyệt Control.Tag trên Form để ẩn/mờ theo quyền
│
├── Features/                           # CÁC PHÂN HỆ NGHIỆP VỤ / MÀN HÌNH (VERTICAL SLICES)
│   ├── Auth/                           # Màn hình: Đăng nhập & Đổi mật khẩu
│   │   ├── frmDangNhap.vb (.Designer, .resx)
│   │   ├── frmDoiMatKhau.vb
│   │   ├── TaiKhoanDTO.vb, TaiKhoanDAO.vb, AuthBUS.vb
│   │
│   ├── BanAn_GoiMon/                   # Màn hình: Sơ đồ bàn & Gọi món / Thu ngân
│   │   ├── frmBanAn.vb                 # Sơ đồ trạng thái bàn (Trống, Có khách, Đặt trước)
│   │   ├── frmGoiMon.vb                # Màn hình gọi món, chuyển/gộp bàn, in hóa đơn
│   │   ├── BanDTO.vb, HoaDonDTO.vb, ChiTietHoaDonDTO.vb
│   │   ├── BanDAO.vb, HoaDonDAO.vb, BanAnBUS.vb
│   │
│   ├── ThucDon/                        # Màn hình: Quản lý món ăn & Thực đơn
│   │   ├── frmThucDon.vb, MonAnDTO.vb, DanhMucDTO.vb, MonAnDAO.vb, ThucDonBUS.vb
│   │
│   ├── NhaBep/                         # Màn hình: Hàng đợi chế biến của Bếp & Pha chế
│   │   ├── frmNhaBep.vb, NhaBepDAO.vb, NhaBepBUS.vb
│   │
│   ├── NhanSu/                         # Màn hình: Quản lý tuyển dụng, kỹ năng vi tính & dụng cụ
│   │   ├── frmNhanVien.vb, NhanVienDTO.vb, DungCuDTO.vb, NhanVienDAO.vb, NhanSuBUS.vb
│   │
│   ├── ChamCong_LichLam/               # Màn hình: Xếp ca làm việc & Chấm công
│   │   ├── frmLichLamViec.vb, frmChamCong.vb
│   │   ├── CaLamViecDTO.vb, ChamCongDTO.vb, ChamCongDAO.vb, ChamCongBUS.vb
│   │
│   └── BaoCao_ThongKe/                 # Màn hình: Báo cáo thống kê dành cho Chủ quán
│       ├── frmBaoCao.vb, BaoCaoDAO.vb, BaoCaoBUS.vb
│
├── Form1.vb (.Designer.vb, .resx)      # Form khởi động mặc định ban đầu
├── Quanlyquanan.vbproj                  # Cấu hình project .NET 10.0-windows
└── Quanlyquanan.slnx                   # File Solution XML
```

---

## 3. NGUYÊN TẮC LUỒNG DỮ LIỆU BÊN TRONG MỖI FEATURE (3-TIER FLOW)

Dù được gom theo Màn hình (Feature), bên trong mỗi phân hệ vẫn tuân thủ nghiêm ngặt **3 lớp logic**:

```
[Người dùng tương tác] 
         │
         ▼
    [Form GUI]  (Bắt sự kiện click nút, nhập dữ liệu ô text, hiển thị DataGridView)
         │
         ▼ (Truyền tham số qua)
    [Lớp BUS]   (Kiểm tra tính hợp lệ dữ liệu, áp dụng quy tắc kinh doanh, tính tiền, gộp bàn)
         │
         ▼ (Gửi/nhận đối tượng DTO)
    [Lớp DAO]   (Gọi KetNoiCSDL.ExecuteQuery / ExecuteNonQuery với SqlParameter)
         │
         ▼ (T-SQL qua Port 1433)
[Microsoft SQL Server 2022 Docker]
```

### Quy chuẩn lập trình bắt buộc:
1. **Tuyệt đối không viết SQL trong Form:** Mọi câu lệnh `SELECT`, `INSERT`, `UPDATE`, `DELETE` bắt buộc phải nằm trong các lớp `DAO`.
2. **Chống SQL Injection 100%:** Luôn sử dụng `SqlParameter` hoặc danh sách tham số thông qua `KetNoiCSDL`.
3. **Phân quyền tự động bằng Tag:** Đặt `Tag = "Q_TENQUYEN"` trên các Control cần bảo vệ; gọi `PhanQuyenHelper.ApDungPhanQuyen(Me)` trong sự kiện `Form_Load`.

---

## 4. BẢNG PHÂN HỆ VÀ CÁC BẢNG CƠ SỞ DỮ LIỆU TƯƠNG ỨNG

| Feature (Màn hình) | Bảng dữ liệu tương ứng trong SQL Server |
| :--- | :--- |
| **Auth** | `TaiKhoan`, `VaiTro`, `Quyen`, `TaiKhoan_VaiTro`, `VaiTro_Quyen` |
| **NhanSu** | `NhanVien`, `TrinhDoViTinh`, `NhanVien_ViTinh`, `DungCuTrangPhuc`, `NhanVien_DungCu` |
| **ChamCong_LichLam** | `CaLamViec`, `LichLamViec`, `ChamCong` |
| **ThucDon** | `DanhMuc`, `MonAn` |
| **BanAn_GoiMon** | `Ban`, `HoaDon`, `ChiTietHoaDon` |
| **NhaBep** | `ChiTietHoaDon` (`CTHD_TrangThaiMon`, `CTHD_ThoiGianGoi`) |
| **BaoCao_ThongKe** | `HoaDon`, `ChiTietHoaDon`, `ChamCong`, `LichLamViec` |
