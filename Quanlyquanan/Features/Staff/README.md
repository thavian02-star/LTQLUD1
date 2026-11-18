# 👥 PHÂN HỆ QUẢN LÝ NHÂN SỰ & CHẤM CÔNG (STAFF SUBSYSTEM)

> **Nhóm người dùng:** Chủ quán, Quản lý nhân sự, Toàn bộ nhân viên (xem lịch & chấm công).  
> **Màn hình chính:** `frmNhanVien.vb` (Màn hình 6 / 9 thuộc Danh mục nền tảng).

---

## CÁC MÀN HÌNH & CHỨC NĂNG CỐT LÕI:
1. `frmNhanVien.vb` — **Quản lý Hồ sơ nhân sự (Staff Directory - MH 6):**
   - Hồ sơ: Họ tên, Giới tính, Ngày sinh, CCCD, SĐT, Địa chỉ, Vị trí (Phục vụ, Pha chế, Bếp, Quản lý).
   - Quản lý nhiều **Trình độ vi tính** (`NhanVien_ViTinh`).
   - Cấp phát & thu hồi **Dụng cụ / Trang phục** (`NhanVien_DungCu`).
   - Tự động liên kết tạo tài khoản đăng nhập `TaiKhoan` khi tiếp nhận nhân viên mới.
   - Xóa mềm / Khóa tài khoản khi nhân viên nghỉ việc.
2. `Features/Shift/frmCaLamViec.vb` — **Cấu hình ca làm việc (Shift Configuration - MH 3):**
   - Danh sách ca, khung giờ bắt đầu/kết thúc, thời lượng ca, định mức lương mỗi ca.
3. `frmLichLamViec.vb` — **Xếp lịch làm việc theo tuần / tháng:**
   - Phân công nhân viên vào từng ca làm việc, quản lý lịch trực.
4. `frmChamCong.vb` & `frmDuyetChamCong.vb` — **Chấm công cá nhân & Duyệt chấm công:**
   - Nhân viên check-in / check-out.
   - Quản lý duyệt số ca làm việc thực tế để xuất bảng tính lương cuối tháng.
