# Báo Cáo Đánh Giá Cơ Sở Dữ Liệu (Database Schema Review — Đã Hoàn Tất Cải Tiến)

**Tài liệu đối chiếu:** [Đồ án - Quan ly quan an 3.pdf](file:///c:/Users/wmwar/OneDrive/Desktop/DAQLUD1/docs/%C4%90%E1%BB%93%20%C3%A1n%20-%20Quan%20ly%20quan%20an%203.pdf)  
**File kiểm tra:** [create-database.sql](file:///c:/Users/wmwar/OneDrive/Desktop/DAQLUD1/database/docker-mssql/create-database.sql)  
**Trạng thái:** ✅ **ĐÃ ĐÁP ỨNG 100% YÊU CẦU ĐỒ ÁN** (Giữ cấu trúc **18 bảng** gọn gàng, cố định 2 ca làm việc chính để Quản lý trực tiếp phân công, không tạo bảng đăng ký ca rảnh dư thừa).

---

## 1. Tổng quan cấu trúc 18 bảng hiện tại

File [create-database.sql](file:///c:/Users/wmwar/OneDrive/Desktop/DAQLUD1/database/docker-mssql/create-database.sql) bao gồm **18 bảng** chia làm **5 phân hệ**:
1. **Phân quyền (RBAC - 5 bảng):** `TaiKhoan`, `VaiTro`, `Quyen`, `TaiKhoan_VaiTro`, `VaiTro_Quyen`
2. **Nhân sự & Tuyển dụng (5 bảng):** `NhanVien`, `TrinhDoViTinh`, `NhanVien_ViTinh`, `DungCuTrangPhuc`, `NhanVien_DungCu`
3. **Ca làm việc & Chấm công (3 bảng):** `CaLamViec` (cố định 2 ca), `LichLamViec` (Quản lý phân công trực tiếp), `ChamCong`
4. **Bàn & Thực đơn (3 bảng):** `Ban`, `DanhMuc`, `MonAn`
5. **Gọi món & Hóa đơn (2 bảng):** `HoaDon`, `ChiTietHoaDon`

---

## 2. Đối chiếu chi tiết từng yêu cầu trong PDF

### 2.1. Phân hệ Tuyển dụng & Quản lý Nhân viên
| Yêu cầu trong PDF (Trang 1 - 2) | Bảng / Cột trong `create-database.sql` | Đánh giá |
| :--- | :--- | :---: |
| Họ tên, Ngày sinh, Giới tính, CMND, ĐT, Email, Địa chỉ | `NhanVien` (`NV_HoTen`, `NV_NgaySinh`, `NV_GioiTinh`, `NV_CMND`, `NV_DienThoai`, `NV_Email`, `NV_DiaChi`) | ✅ Đầy đủ |
| Ngày nhận việc, Ngày thôi việc | `NhanVien` (`NV_NgayBatDauLam`, `NV_NgayThoiViec`) | ✅ Đầy đủ |
| Trình độ học vấn, Danh sách ngoại ngữ | `NhanVien` (`NV_TrinhDoHocVan`, `NV_NgoaiNgu`) | ✅ Đầy đủ |
| Trình độ vi tính (Word, Excel, khác...) có thể thay đổi | `TrinhDoViTinh` + `NhanVien_ViTinh` (Quan hệ N-N) | ✅ Đầy đủ |
| **Ca làm việc & Xếp lịch** (Đơn giản hóa: Cố định 2 ca, Quản lý trực tiếp phân công ca cho nhân viên) | `CaLamViec` (2 ca cố định) + `LichLamViec` (`LLV_MaNV`, `LLV_MaCa`, `LLV_NgayLam`) | ✅ Đầy đủ & Tối ưu |
| Giao dụng cụ & trang phục (danh sách có thể thay đổi) | `DungCuTrangPhuc` + `NhanVien_DungCu` (`SoLuong`, `NgayNhan`, `DaTra`, `NgayTra`) | ✅ Đầy đủ |

### 2.2. Phân hệ Bàn, Thực đơn & Gọi món
| Yêu cầu trong PDF (Trang 2) | Bảng / Cột trong `create-database.sql` | Đánh giá |
| :--- | :--- | :---: |
| Bàn có mã số, số lượng người tối đa, khu vực | `Ban` (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_SoNguoiToiDa`, `B_KhuVuc`, `B_TrangThai`) | ✅ Đầy đủ |
| Tìm bàn trống theo số lượng khách | Truy vấn `WHERE B_TrangThai = 0 AND B_SoNguoiToiDa >= @SoKhach` | ✅ Đầy đủ |
| Chọn danh sách món ăn cho bàn (món, số lượng) | `HoaDon` + `ChiTietHoaDon` (`CTHD_MaMonAn`, `CTHD_SoLuong`, `CTHD_DonGia`) | ✅ Đầy đủ |
| Chuyển bàn | Cập nhật `HoaDon.HD_MaBan` sang bàn mới + đổi `B_TrangThai` | ✅ Đầy đủ |
| Gộp bàn | `HoaDon.HD_MaHoaDonGop` (Self-referencing FK lưu vết hóa đơn gốc khi gộp) | ✅ Đầy đủ |
| Tính tiền bàn | `HoaDon` (`HD_TongTien`, `HD_TrangThai = 1`, `HD_ThoiGianThanhToan`) | ✅ Đầy đủ |

### 2.3. Phân hệ Vai trò (Nhân viên, Quản lý, Chủ quán) & Báo cáo thống kê
| Yêu cầu trong PDF (Trang 2 - 3) | Bảng / Cột trong `create-database.sql` | Đánh giá |
| :--- | :--- | :---: |
| **Nhân viên phục vụ:** Xem lịch làm việc, Chấm công | `LichLamViec` + `ChamCong` (`CC_GioBatDau`, `CC_GioKetThuc`) | ✅ Đầy đủ |
| **Quản lý:** Duyệt chấm công (bấm duyệt) | `ChamCong` (`CC_DaDuyet`, `CC_NguoiDuyet`, `CC_ThoiGianDuyet`) | ✅ Đầy đủ |
| **Quản lý:** Các chức năng của nhân viên phục vụ (nhưng có thêm giá trị đầu vào là nhân viên phục vụ đó) | `HoaDon` (`HD_MaNVPhucVu` tính doanh thu cho NV, `HD_NguoiTao` lưu người thực tế bấm tạo) | ✅ Đầy đủ |
| **Báo cáo 1 (Chủ quán):** Số ca làm việc trong tháng (dựa vào quản lý duyệt) | Truy vấn `ChamCong` (`WHERE CC_DaDuyet = 1`) kết hợp `LichLamViec` | ✅ Đầy đủ |
| **Báo cáo 2:** Số lượng khách theo từng thời điểm (ca, ngày, tháng, năm, khoảng thời gian) | `HoaDon` (`HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_MaCa`) | ✅ Đầy đủ |
| **Báo cáo 3:** Doanh thu theo từng thời điểm (ca, ngày, tháng, năm, khoảng thời gian) | `HoaDon` (`HD_TongTien`, `HD_ThoiGianThanhToan`, `HD_MaCa`) | ✅ Đầy đủ |
| **Báo cáo 4:** Doanh thu theo nhân viên theo từng thời điểm | `HoaDon` (`HD_MaNVPhucVu`, `HD_TongTien`, `HD_MaCa`, `HD_ThoiGianThanhToan`) | ✅ Đầy đủ |
| **Báo cáo 5:** Doanh thu theo từng bàn theo từng thời điểm | `HoaDon` (`HD_MaBan`, `HD_TongTien`, `HD_MaCa`, `HD_ThoiGianThanhToan`) | ✅ Đầy đủ |
| **Báo cáo 6:** Doanh thu theo món ăn theo từng thời điểm | `ChiTietHoaDon` (`CTHD_SoLuong * CTHD_DonGia`) JOIN `HoaDon` (`HD_MaCa`, `HD_ThoiGianThanhToan`) | ✅ Đầy đủ |

---

## 3. Tổng hợp các Cải tiến đã thực hiện

### Đợt 1 (Commit `5218204`)
- [x] **Cải tiến 1.1:** Thêm `HD_MaCa` vào `HoaDon` phục vụ 5 báo cáo thống kê theo Ca.
- [x] **Cải tiến 1.2:** Thêm `HD_MaHoaDonGop` vào `HoaDon` phục vụ nghiệp vụ Gộp bàn.
- [x] **Cải tiến 1.3:** Thêm `B_KhuVuc` vào `Ban` giúp quản lý vị trí bàn.

### Đợt 2 (Hiện tại)
- [x] **Sửa lỗi cú pháp dòng 48:** Đóng comment `--` cho dòng 48 bị sót trong khối `[CHẾ ĐỘ THIẾT KẾ / DEVELOPMENT RESET]`.
- [x] **Đơn giản hóa nghiệp vụ Ca làm việc:** Cố định 2 ca trong bảng `CaLamViec`, bỏ bảng đăng ký ca rảnh, Quản lý trực tiếp phân công ca vào bảng `LichLamViec`.
- [x] **Hoàn thiện hồ sơ tuyển dụng `NhanVien`:** Bổ sung `NV_Email`, `NV_TrinhDoHocVan`, `NV_NgoaiNgu`, `NV_NgayThoiViec` đúng theo yêu cầu Trang 1 PDF.
- [x] **Lưu vết Quản lý duyệt chấm công (`ChamCong`):** Bổ sung `CC_NguoiDuyet` và `CC_ThoiGianDuyet`.
- [x] **Lưu vết Quản lý thao tác hộ Nhân viên (`HoaDon`):** Bổ sung `HD_NguoiTao` bên cạnh `HD_MaNVPhucVu`.
- [x] **Ràng buộc toàn vẹn dữ liệu (`UNIQUE` & `CHECK`):**
  - `UNIQUE`: `Quyen(Q_Tag)`, `TaiKhoan_VaiTro(TKVT_TaiKhoan, TKVT_VaiTro)`, `VaiTro_Quyen(VTQ_VaiTro, VTQ_Quyen)`, `NhanVien_ViTinh(NV_Ma, TDVT_Ma)`, `LichLamViec(LLV_MaNV, LLV_MaCa, LLV_NgayLam)`.
  - `CHECK`: Kiểm tra số lượng, số ghế tối đa `> 0` và đơn giá, mức lương, tổng tiền `>= 0`.
