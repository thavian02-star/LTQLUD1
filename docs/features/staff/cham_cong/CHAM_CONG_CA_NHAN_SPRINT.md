# ĐẶC TẢ NGHIỆP VỤ: MÀN HÌNH CHẤM CÔNG & LỊCH TRỰC CÁ NHÂN
**Tên Form WinForms:** `frmChamCongCaNhan`  
**Phiên bản:** `v1.0`  
**Phân quyền (RBAC):** `NV_CHAM_CONG` (Tất cả nhân viên đang đăng nhập)  
**Liên kết Checklist:** [`docs/CHECKLIST_DO_AN.md`](../../CHECKLIST_DO_AN.md) — Mục 3.2 (Phân hệ Chung: Cá nhân & Chấm công)

---

## 1. MỤC TIÊU NGHIỆP VỤ
Màn hình Chấm Công Cá Nhân (`frmChamCongCaNhan`) là nơi nhân viên tự quản lý thời gian làm việc và điểm danh ca trực:
1. **Thông tin nhân sự trực ca:**
   - Hiển thị họ tên, mã nhân viên, chức vụ và ca làm việc được phân công trong ngày.
2. **Điểm danh vào/ra ca trực (Check-in / Check-out):**
   - **Vào Ca (Check-in):** Ghi nhận chính xác thời điểm bắt đầu làm việc (`CC_GioBatDau = NOW`).
   - **Hết Ca (Check-out):** Ghi nhận thời điểm kết thúc làm việc (`CC_GioKetThuc = NOW`), tự động tính số giờ làm thực tế.
3. **Xem lịch làm việc tuần:**
   - Hiển thị danh sách 7 ngày trong tuần hiện tại: Ngày làm việc, Tên ca, Khung giờ quy định, Trạng thái (Đã xếp / Đã làm / Nghỉ).
4. **Lịch sử chấm công cá nhân:**
   - Danh sách các ca làm việc gần đây, giờ vào, giờ ra, số giờ làm và trạng thái kiểm duyệt của Quản lý (`0: Chờ duyệt, 1: Đã duyệt công`).

---

## 2. BỐ CỤC GIAO DIỆN
- **Khối Header:** Tên nhân viên, chức danh, đồng hồ kỹ thuật số.
- **Khối Thao Tác Điểm Danh Nhanh (Clock-in Panel):**
  - Trạng thái hiện tại: Chưa vào ca / Đang trong ca làm việc.
  - 2 nút bấm cảm ứng lớn: **[🟢 BẮT ĐẦU VÀO CA]** và **[🔴 KẾT THÚC CA LÀM]**.
- **Khối Lịch Tuần (Weekly Schedule Grid):** Thẻ 7 ngày trong tuần với nhãn ca làm.
- **Khối Lịch Sử Chấm Công (DataGridView):** Ngày, Ca, Giờ vào, Giờ ra, Số giờ, Tình trạng duyệt.

---

## 3. RÀNG BUỘC KỸ THUẬT
- File &le; 500 dòng.
- Hàm &le; 40 dòng.
- Kiến trúc chuẩn 3 lớp: DTO & DAO &rarr; BUS &rarr; WinForms.
