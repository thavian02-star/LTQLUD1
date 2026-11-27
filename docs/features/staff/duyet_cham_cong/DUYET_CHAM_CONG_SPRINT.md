# Kế Hoạch Sprint: Phân Hệ Quản Lý Duyệt Chấm Công & Bảng Công Nhân Sự
**Màn hình:** `frmDuyetChamCong` (Mục 3.5 Checklist Đồ Án)  
**Phiên bản dự kiến:** `v0.3.3`  
**Đối tượng sử dụng:** Quản lý cơ sở, Chủ nhà hàng (RBAC: `QUAN_LY_DUYET_CHAM_CONG`, `CHU_QUAN`)

---

## 1. Mục Tiêu Nghiệp Vụ
1. **Duyệt Công 1-Click & Hàng Loạt (Bulk Approval):**
   - Quản lý kiểm tra các ca làm việc của nhân viên trong ngày hoặc khoảng thời gian.
   - Hiển thị rõ: Giờ vào thực tế, Giờ ra thực tế, Thời lượng (giờ), Trạng thái duyệt (`Chờ duyệt`, `Đã duyệt`).
   - Nút `Duyệt công [F5]` từng ca và nút `Duyệt tất cả ca hợp lệ [F6]`.
2. **Lọc Dữ Liệu Thông Minh:**
   - Lọc theo ngày làm việc / tuần / tháng.
   - Lọc theo trạng thái (`Tất cả`, `Chờ quản lý duyệt`, `Đã duyệt`).
   - Lọc theo nhân viên hoặc vị trí (Phục vụ bàn, Đầu bếp, Pha chế).
3. **Tổng Hợp Giờ Công & Dự Toán Lương Ca:**
   - Thống kê tổng số ca đã làm, tổng số giờ công thực tế, tổng số tiền lương dự kiến (`Số ca * CA_LuongMoiCa`).
   - Cảnh báo ca bất thường: Vào muộn (>15p), ra sớm, hoặc quên checkout (>12 tiếng chưa ra ca).
4. **Quy Tắc An Toàn Dữ Liệu:**
   - Chỉ Quản lý (`VT_Ma = 2`) hoặc Chủ quán (`VT_Ma = 1`) mới có quyền duyệt.
   - Khi duyệt, lưu `CC_DaDuyet = 1`, `CC_NguoiDuyet = Session.MaNhanVien`, `CC_ThoiGianDuyet = GETDATE()`.
   - Có thể Hủy duyệt (Unapprove) nếu phát hiện sai sót trước khi chốt bảng lương cuối tháng.

---

## 2. Thiết Kế Cơ Sở Dữ Liệu & Truy Vấn
- **Bảng `ChamCong`:**
  - `CC_Ma`, `CC_MaLich`, `CC_MaNV`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `CC_NguoiDuyet`, `CC_ThoiGianDuyet`, `CC_Xoa`.
- **Bảng `LichLamViec` & `CaLamViec` & `NhanVien`:**
  - `NV_HoTen`, `NV_ChucVu`, `CA_Ten`, `CA_LuongMoiCa`.

---

## 3. Kiến Trúc 3 Lớp & Quy Tắc Kỹ Thuật
- `Quanlyquanan/Core/DTO/BaoCaoChamCongDTO.vb`: Chứa thông tin tổng hợp dòng công & thống kê KPI.
- `Quanlyquanan/Core/DAO/DuyetChamCongDAO.vb`: Các phương thức truy vấn danh sách cần duyệt, thực thi duyệt, hủy duyệt, tổng hợp lương.
- `Quanlyquanan/Core/BUS/DuyetChamCongBUS.vb`: Xử lý logic nghiệp vụ, tính lương, kiểm tra tính hợp lệ và fallback mock.
- `Quanlyquanan/Features/Staff/frmDuyetChamCong.Designer.vb` & `frmDuyetChamCong.vb`: Giao diện WinForms hiện đại, trực quan, hỗ trợ phím tắt.
- **Tiêu chuẩn:** Mỗi hàm $\le 40$ dòng, mỗi file $\le 500$ dòng, biên dịch .NET 10.0 không lỗi.
