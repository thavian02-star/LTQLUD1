# ĐẶC TẢ NGHIỆP VỤ: MÀN HÌNH ĐIỂM BÁN HÀNG & SƠ ĐỒ BÀN (POS ORDER HUB)
**Tên Form WinForms:** `frmSoDoBan`  
**Phiên bản:** `v1.0` (Mở đầu Giai đoạn 3: Phân hệ Nghiệp vụ Bán Hàng & Vận Hành)  
**Phân quyền (RBAC):** `PV_BAN_HANG`, `QL_BAN_HANG`, `CQ_QUAN_LY_BAN`  
**Liên kết Checklist:** [`docs/CHECKLIST_DO_AN.md`](../../CHECKLIST_DO_AN.md) — Mục 3.3 (Phân hệ Nhân viên phục vụ)

---

## 1. MỤC TIÊU NGHIỆP VỤ
Màn hình Điểm Bán Hàng & Sơ Đồ Bàn (`frmSoDoBan`) là trung tâm tác nghiệp quan trọng nhất của nhân viên phục vụ và thu ngân nhà hàng:
1. **Giám sát không gian bàn trực quan:** Hiển thị toàn bộ sơ đồ bàn theo từng khu vực (Tầng 1, Tầng 2, Phòng VIP) với mã màu trạng thái rõ ràng:
   - 🟢 **Bàn Trống (Trạng thái 0):** Sẵn sàng đón khách mới.
   - 🔴 **Đang Phục Vụ (Trạng thái 1):** Đang có khách ngồi, có hóa đơn mở, hiển thị số khách và thời gian vào.
   - 🟡 **Đã Đặt Trước (Trạng thái 2):** Đã có lịch hẹn giờ của khách.
2. **Quy trình Mở bàn & Gọi món (Order):**
   - Chọn bàn trống &rarr; Nhập số lượng khách (kiểm tra sức chứa tối đa) &rarr; Tạo phiên phục vụ (`HoaDon`).
   - Duyệt thực đơn món ăn theo nhóm (Khai vị, Món chính, Đồ uống...) &rarr; Chọn món, số lượng, ghi chú &rarr; Đẩy vào `ChiTietHoaDon` với trạng thái `0 - Chờ thực hiện` (gửi tức thì xuống Bếp).
3. **Thao tác vận hành tại bàn:**
   - **Thêm món:** Gọi thêm món vào hóa đơn đang mở bất kỳ lúc nào.
   - **Hủy món:** Chỉ cho phép hủy món khi Bếp chưa nấu (`CTHD_TrangThaiMon = 0`).
   - **Chuyển bàn:** Di chuyển toàn bộ hóa đơn từ bàn hiện tại sang bàn trống khác.
   - **Gộp bàn:** Gộp nhiều bàn đang phục vụ vào chung 1 hóa đơn để thanh toán.
4. **Thanh toán & Đóng bàn:**
   - Xem bảng kê chi tiết hóa đơn, tạm tính tổng tiền, phụ thu phòng VIP (nếu có).
   - Chọn phương thức thanh toán (Tiền mặt / Chuyển khoản QR / Thẻ).
   - Xác nhận thanh toán &rarr; Chuyển `HoaDon.HD_TrangThai = 1 (Đã thanh toán)` &rarr; Đổi bàn về trạng thái `0 (Trống)`.

---

## 2. KIẾN TRÚC GIAO DIỆN (SPLIT 3 KHỐI HIỆN ĐẠI)
Giao diện `frmSoDoBan` được thiết kế theo tỷ lệ công thái học màn hình POS cảm ứng:
- **Khối Trái (Sidebar Lọc Khu Vực & Thống Kê Nhanh - 220px):**
  + Bộ lọc: Tất cả bàn, Tầng 1 (Sảnh), Tầng 2 (Sân vườn), Phòng VIP.
  + Thống kê nhanh: Tổng số bàn, Bàn trống, Bàn đang có khách.
- **Khối Giữa (Lưới Sơ Đồ Bàn Trực Quan - Flex 1):**
  + Mỗi bàn là 1 Card thẻ trực quan: Tên bàn, Sức chứa, Số khách đang ngồi, Giờ vào, Tổng tiền tạm tính.
  + Click vào bàn để chọn tác nghiệp.
- **Khối Phải (Bảng Kê Hóa Đơn & Quầy Gọi Món - 380px):**
  + Header: Thông tin bàn đang chọn, Mã hóa đơn, Nhân viên phục vụ.
  + Body: DataGridView danh sách món gọi (Tên món, Đơn giá, SL, Thành tiền, Trạng thái bếp: Chờ làm / Đã nấu / Đã mang ra).
  + Footer: Tổng tiền, Nút Mở Bàn / Gọi Thêm Món / Chuyển Bàn / Thanh Toán.

---

## 3. RÀNG BUỘC KỸ THUẬT & QUY TẮC DỰ ÁN
- **Độ dài hàm:** &le; 40 dòng/hàm.
- **Độ dài file:** &le; 500 dòng/file.
- **Quy trình 5 bước:**
  1. Đặc tả & Mockup HTML
  2. CSDL & DTO / DAO
  3. Lập trình BUS & WinForms UI
  4. Kiểm thử tự động (Verifier Script 100% PASS)
  5. Đóng gói, Báo cáo & Release Tag
