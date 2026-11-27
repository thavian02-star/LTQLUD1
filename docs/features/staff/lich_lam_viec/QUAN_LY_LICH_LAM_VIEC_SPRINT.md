# Kế Hoạch Sprint: Phân Hệ Quản Lý Phân Ca & Xếp Lịch Làm Việc Tuần
**Màn hình:** `frmQuanLyLichLamViec` (Mục 3.5 Checklist Đồ Án)  
**Phiên bản dự kiến:** `v0.3.5`  
**Đối tượng sử dụng:** Quản lý cơ sở, Trưởng ca, Chủ nhà hàng (RBAC: `QUAN_LY_LICH_LAM_VIEC`, `CHU_QUAN`)

---

## 1. Mục Tiêu Nghiệp Vụ
1. **Ma Trận Phân Ca Tuần Trực Quan (Weekly Roster Grid):**
   - Hiển thị toàn bộ nhân sự theo hàng và 7 ngày trong tuần (Thứ Hai &rarr; Chủ Nhật) theo các cột.
   - Mỗi ô giao điểm thể hiện rõ ca trực của nhân viên trong ngày đó (VD: `Ca Sáng (06:00-14:00)`, `Ca Chiều`, `Nghỉ ca`).
   - Đổi màu nổi bật theo ca và trạng thái (Đã xếp lịch, Hoàn thành, Nghỉ phép).
2. **Thao Tác Phân Ca & Đổi Ca Nhanh Chóng:**
   - Thêm nhân viên vào ca: Chọn Nhân viên, Ngày làm việc, Ca làm việc &rarr; Bấm `Thêm Vào Ca`.
   - Xóa ca phân công hoặc đổi nhân viên khác trực thay khi có nhân sự báo nghỉ đột xuất.
   - Cảnh báo trùng ca: Không cho phép xếp 1 nhân viên vào 2 ca bị chồng chéo giờ trong cùng một ngày.
3. **Thống Kê Quân Số & Độ Phủ Nhân Sự:**
   - Thống kê tổng số ca đã xếp trong tuần.
   - Thống kê quân số trung bình mỗi ca trực (đảm bảo ca sáng/tối luôn đủ tối thiểu nhân sự phục vụ và đầu bếp).
4. **Điều Hướng Thời Gian:**
   - Chuyển đổi tuần nhanh: `◀ Tuần trước`, `Tuần này`, `Tuần sau ▶` và chọn tuần qua DateTimePicker.

---

## 2. Thiết Kế Cơ Sở Dữ Liệu & Truy Vấn
- **Bảng `LichLamViec`:**
  - `LLV_Ma` (PK, INT IDENTITY)
  - `LLV_MaNV` (FK -> `NhanVien.NV_Ma`)
  - `LLV_MaCa` (FK -> `CaLamViec.CA_Ma`)
  - `LLV_NgayLam` (DATE)
  - `LLV_TrangThai` (NVARCHAR(50) - "Đã xếp lịch", "Đã hoàn thành", "Nghỉ phép")
  - `LLV_Xoa` (BIT)
- **Bảng `CaLamViec` & `NhanVien`:**
  - `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `NV_HoTen`, `NV_ChucVu`.

---

## 3. Kiến Trúc 3 Lớp & Quy Tắc Kỹ Thuật
- `Quanlyquanan/Core/DTO/MaTranLichTuanDTO.vb`: Chứa dòng nhân viên và 7 ô ca trực tương ứng từ T2 đến CN.
- `Quanlyquanan/Core/DAO/LichLamViecDAO.vb`: Thêm ca, Xóa ca, Sửa ca, Truy vấn lịch tuần toàn quán.
- `Quanlyquanan/Core/BUS/LichLamViecBUS.vb`: Kiểm tra xung đột ca, tổng hợp dữ liệu ma trận tuần và fallback offline mock.
- `Quanlyquanan/Features/Staff/frmQuanLyLichLamViec.Designer.vb` & `frmQuanLyLichLamViec.vb`: Giao diện WinForms hiện đại, hỗ trợ phím tắt và thao tác 1-Click.
- **Tiêu chuẩn:** Mỗi hàm $\le 40$ dòng, mỗi file $\le 500$ dòng, biên dịch .NET 10.0 không lỗi.
