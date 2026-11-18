# 🍳 PHÂN HỆ VẬN HÀNH NHÀ BẾP & PHA CHẾ (KITCHEN DISPLAY SYSTEM - KDS)

> **Nhóm người dùng:** Bếp trưởng (Head Chef), Đầu bếp (Cooks), Nhân viên pha chế (Bartenders).  
> **Nguồn dữ liệu:** Nhận lệnh đặt món thời gian thực từ `Features/POS/frmGoiMon.vb`.

---

## CÁC MÀN HÌNH & CHỨC NĂNG CỐT LÕI:
1. `frmNhaBep.vb` — **Màn hình Hàng đợi chế biến (Kitchen Queue):**
   - Hiển thị danh sách các món cần nấu theo thứ tự thời gian thực (FIFO - First In First Out).
   - Hiển thị rõ: Số bàn, Tên món, Số lượng, Ghi chú đặc biệt của khách, Thời gian đặt món.
   - Thao tác: Bấm nút **"Bắt đầu nấu"** $\rightarrow$ **"Hoàn thành món"**.
   - Khi hoàn thành món: Tự động đổi trạng thái bàn trên `Features/POS/frmSoDoBan.vb` sang màu vàng ("Món đã xong") và phát tín hiệu chuông để nhân viên phục vụ biết mang ra cho khách.
