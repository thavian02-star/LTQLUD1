# ĐẶC TẢ NGHIỆP VỤ: MÀN HÌNH ĐIỀU PHỐI CHẾ BIẾN NHÀ BẾP (KITCHEN DISPLAY SYSTEM - KDS)
**Tên Form WinForms:** `frmNhaBep`  
**Phiên bản:** `v1.0`  
**Phân quyền (RBAC):** `BEP_CHE_BIEN`, `QL_CHE_BIEN`, `CQ_CHE_BIEN`  
**Liên kết Checklist:** [`docs/CHECKLIST_DO_AN.md`](../../CHECKLIST_DO_AN.md) — Mục 3.4 (Phân hệ Nhà bếp / Pha chế)

---

## 1. MỤC TIÊU NGHIỆP VỤ
Màn hình Nhà Bếp (KDS) là trung tâm điều phối chế biến ẩm thực cho các đầu bếp và nhân viên pha chế:
1. **Tiếp nhận yêu cầu gọi món theo thời gian thực:**
   - Ngay khi nhân viên phục vụ tại bàn (`frmSoDoBan`) bấm gửi món hoặc gọi thêm món, các món ăn/thức uống sẽ tự động xuất hiện tại màn hình Bếp.
2. **Hiển thị thứ tự ưu tiên chuẩn FIFO (First In, First Out):**
   - Danh sách món được sắp xếp theo thời gian đặt tăng dần (`CTHD_ThoiGianGoi ASC`): Món nào gọi trước phải nấu trước.
   - Thể hiện rõ thời gian đã chờ (ví dụ: `Đã chờ: 3 phút`, `Đã chờ: 12 phút (Cảnh báo trễ)`).
3. **Thông tin hiển thị chi tiết cho đầu bếp:**
   - Số bàn ăn gọi món (ví dụ: `Bàn 02`, `Phòng VIP 1`).
   - Tên món ẩm thực & Nhóm chế biến (ví dụ: `Phở Bò Tái Nạm`, `Cơm Tấm`).
   - Số lượng suất cần nấu (ví dụ: `x2`, `x1`).
   - Ghi chú đặc thù của khách (ví dụ: `Không hành lá`, `Ít cay`, `Uống đá riêng`).
4. **Tác nghiệp hoàn thành chế biến:**
   - Khi nấu xong món, đầu bếp bấm nút **"Hoàn Thành Món"** (hoặc phím tắt).
   - Hệ thống lập tức cập nhật `CTHD_TrangThaiMon = 1 (Đã nấu xong)`.
   - Bàn ăn tại màn hình phục vụ POS sẽ đổi trạng thái thông báo `Món đã xong` để nhân viên phục vụ bưng lên cho khách.
5. **Bộ lọc khu vực chế biến:**
   - Lọc theo: Tất cả món, Bếp Nóng (Món chính), Bếp Lạnh (Khai vị / Gỏi), Quầy Pha Chế (Đồ uống).

---

## 2. BỐ CỤC GIAO DIỆN (KDS TOUCH DESIGN)
- **Thanh Header trên cùng:**
  + Tiêu đề: `ĐIỀU PHỐI CHẾ BIẾN NHÀ BẾP (KDS FIFO)`
  + Thống kê thời gian thực: Tổng món chờ làm, Món đã nấu xong ca trực, Món chờ quá 15 phút.
  + Đồng hồ kỹ thuật số chạy từng giây.
- **Thanh Công Cụ Bộ Lọc (Toolbar):**
  + Lọc theo nhóm bếp: Tất cả, Bếp Nóng, Bếp Lạnh, Quầy Nước.
  + Nút làm mới / Tự động tải lại sau mỗi 5 giây.
- **Vùng Hiển Thị Thẻ Chế Biến (Card Grid):**
  + Mỗi order là một Thẻ (Ticket Card) trực quan hoặc danh sách dạng Bảng tác nghiệp cảm ứng lớn.
  + Thẻ hiển thị: Số Bàn, Thời gian gọi, Tên món (in đậm to), Số lượng badge nổi bật, Ghi chú màu vàng, Nút bấm lớn "ĐÃ NẤU XONG".

---

## 3. RÀNG BUỘC KỸ THUẬT & QUY TẮC DỰ ÁN
- Mỗi hàm &le; 40 dòng.
- Mỗi file &le; 500 dòng.
- Kiến trúc chuẩn 3 lớp: DTO & DAO &rarr; BUS &rarr; WinForms UI.
- Kiểm thử tự động 100% PASS trước khi phát hành.
