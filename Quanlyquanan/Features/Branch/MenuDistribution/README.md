# 🏬 PHÂN BỔ THỰC ĐƠN THEO CHI NHÁNH (BRANCH MENU DISTRIBUTION) — TẦNG 3.2

> **Màn hình phụ trách:** `frmMenuChiNhanh.vb` (Màn hình 9 / 9)  
> **Bảng CSDL liên quan:** `ChiNhanh_Menu`, `ChiNhanh`, `Menu`  
> **Phân quyền RBAC:** `CQ_QUAN_LY_THUC_DON`

---

## 1. MỤC TIÊU NGHIỆP VỤ:
- Cho phép Giám đốc chuỗi / Quản lý điều hành gán các Bảng thực đơn bán lẻ cho từng cơ sở chi nhánh:
  - Chọn Chi nhánh (từ `Features/Branch/Store/`) $\rightarrow$ Gán Menu được phép bán (từ `Features/Menu/Catalog/`).
  - Thiết lập thời gian hiệu lực (Ngày bắt đầu, Ngày kết thúc).
  - Tùy chỉnh bật/tắt phục vụ từng món tại từng chi nhánh (hết hàng nguyên liệu cục bộ).
  - Áp dụng chính sách giá theo chi nhánh (ví dụ: Chi nhánh sân bay / trung tâm áp dụng phụ thu).
- Cung cấp dữ liệu trực tiếp cho phân hệ Bán hàng & Gọi món `Features/POS/`.
