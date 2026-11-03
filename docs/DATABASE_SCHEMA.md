# ĐẶC TẢ CƠ SỞ DỮ LIỆU: QUANLYQUANANDB
**Hệ quản trị:** Microsoft SQL Server 2022 (Docker)  
**Tập tin kịch bản:** `database/docker-mssql/create-database.sql`  
**Chuỗi kết nối VB.NET:**
```vbnet
Server=localhost,1433;Database=QuanLyQuanAnDB;User Id=sa;Password=password123!;TrustServerCertificate=True;
```

---

## 1. PHÂN HỆ TÀI KHOẢN & PHÂN QUYỀN (RBAC)
- **`TaiKhoan`** (`TK_Ma`, `TK_TenDangNhap`, `TK_MatKhau` băm MD5, `TK_Xoa`)
- **`VaiTro`** (`VT_Ma`, `VT_Ten`, `VT_Xoa`): *Chủ quán, Quản lý, Nhân viên phục vụ, Nhà bếp / Pha chế*.
- **`Quyen`** (`Q_Ma`, `Q_Ten`, `Q_Tag`, `Q_Xoa`): Cột `Q_Tag` được gán trực tiếp vào thuộc tính `Tag` của Button/Menu trên Form VB.NET để ẩn/hiện chức năng tự động.
- **`TaiKhoan_VaiTro`** (`TKVT_Ma`, `TKVT_TaiKhoan`, `TKVT_VaiTro`)
- **`VaiTro_Quyen`** (`VTQ_Ma`, `VTQ_VaiTro`, `VTQ_Quyen`)

---

## 2. PHÂN HỆ NHÂN SỰ & TUYỂN DỤNG
- **`NhanVien`** (`NV_Ma`, `NV_HoTen`, `NV_GioiTinh`, `NV_NgaySinh`, `NV_ViTri`, `NV_DienThoai`, `NV_DiaChi`, `NV_CMND`, `NV_NgayBatDauLam`, `NV_MaTaiKhoan`, `NV_TrangThai` [Đang làm việc / Đã nghỉ việc], `NV_Xoa`)
- **`TrinhDoViTinh`** (`TDVT_Ma`, `TDVT_Ten`, `TDVT_Xoa`): Danh sách kỹ năng (*Word, Excel, Cài phần mềm, Khác* - có thể thay đổi linh hoạt).
- **`NhanVien_ViTinh`** (`ID`, `NV_Ma`, `TDVT_Ma`): Bảng quan hệ N-N cho phép một nhân viên có nhiều trình độ vi tính.
- **`DungCuTrangPhuc`** (`DC_Ma`, `DC_Ten`, `DC_SoLuongTong`, `DC_GhiChu`, `DC_Xoa`): Quản lý kho trang phục/dụng cụ của quán.
- **`NhanVien_DungCu`** (`MP_Ma`, `NV_Ma`, `DC_Ma`, `SoLuong`, `NgayNhan`, `DaTra`, `NgayTra`, `GhiChu`): Cấp phát và theo dõi thu hồi khi nhân viên nghỉ việc.

---

## 3. PHÂN HỆ CA LÀM, XẾP LỊCH & CHẤM CÔNG
- **`CaLamViec`** (`CA_Ma`, `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `CA_LuongMoiCa`, `CA_Xoa`): Cấu hình linh hoạt các ca làm việc.
- **`LichLamViec`** (`LLV_Ma`, `LLV_MaNV`, `LLV_MaCa`, `LLV_NgayLam`, `LLV_TrangThai`, `LLV_Xoa`): Quản lý xếp lịch làm việc theo tuần/tháng.
- **`ChamCong`** (`CC_Ma`, `CC_MaLich`, `CC_MaNV`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `CC_Xoa`): Ghi nhận giờ làm và Quản lý bấm duyệt chấm công để tính lương theo tổng số ca.

---

## 4. PHÂN HỆ BÀN ĂN & THỰC ĐƠN
- **`Ban`** (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_SoNguoiToiDa`, `B_TrangThai` [0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong], `B_Xoa`)
- **`DanhMuc`** (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa`)
- **`MonAn`** (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon` [1: Báo hết món], `MA_MoTa`, `MA_Xoa`)

---

## 5. PHÂN HỆ PHỤC VỤ, ĐẶT MÓN & HÓA ĐƠN
- **`HoaDon`** (`HD_Ma`, `HD_MaBan`, `HD_MaNVPhucVu`, `HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_ThoiGianThanhToan`, `HD_TongTien`, `HD_TrangThai` [0: Đang phục vụ, 1: Đã thanh toán, 2: Đã chuyển/gộp], `HD_Xoa`)
- **`ChiTietHoaDon`** (`CTHD_Ma`, `CTHD_MaHoaDon`, `CTHD_MaMonAn`, `CTHD_SoLuong`, `CTHD_DonGia`, `CTHD_GhiChu`, `CTHD_ThoiGianGoi`, `CTHD_TrangThaiMon` [0: Chờ thực hiện, 1: Đã nấu xong, 2: Đã mang ra, 3: Đã hủy], `CTHD_Xoa`)
