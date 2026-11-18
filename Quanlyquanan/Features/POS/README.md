# 🍽️ PHÂN HỆ VẬN HÀNH BÁN HÀNG & PHỤC VỤ (POINT OF SALE - POS)

> **Nhóm người dùng:** Nhân viên phục vụ bàn (Waiters), Thu ngân (Cashiers), Quản lý ca (Floor Supervisors).  
> **Nguồn dữ liệu:** Tiếp nhận Sơ đồ bàn từ `Features/Table/` và Thực đơn mở bán từ `Features/Branch/MenuDistribution/`.

---

## CÁC MÀN HÌNH & CHỨC NĂNG CỐT LÕI:
1. `frmSoDoBan.vb` — **Sơ đồ bàn thời gian thực (Table Floor Map):**
   - Trực quan hóa trạng thái bàn theo màu sắc (Trống, Có khách, Đang đợi món, Món đã xong).
   - Lọc bàn theo Khu vực (Tầng trệt, Tầng 1, VIP, Sân vườn) và theo Chi nhánh đang làm việc.
2. `frmGoiMon.vb` — **Màn hình Order món (Table Order Pad):**
   - Mở bàn trống, nhập số lượng khách.
   - Nạp danh mục món từ Menu của Chi nhánh này, chọn món, ghi chú yêu cầu riêng của khách (ít cay, không hành...).
   - Bấm "Gửi Bếp" $\rightarrow$ tự động chuyển món sang phân hệ `Features/Kitchen/` (Hàng đợi bếp).
3. `frmChuyenGopBan.vb` — **Nghiệp vụ Chuyển & Gộp bàn:**
   - Chuyển hóa đơn bàn đang phục vụ sang bàn trống khác.
   - Gộp 2 hoặc nhiều bàn thành một hóa đơn thanh toán duy nhất.
4. `frmThanhToan.vb` — **Màn hình Thanh toán & In hóa đơn:**
   - Xem chi tiết hóa đơn (món ăn, đơn giá, phụ thu, chiết khấu).
   - Phương thức thanh toán: Tiền mặt, Thẻ ngân hàng, Chuyển khoản QR.
   - In hóa đơn tính tiền (Print Receipt) và giải phóng trạng thái bàn về "Trống".
