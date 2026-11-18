# 📋 BẢNG THỰC ĐƠN THƯƠNG MẠI (MENU CATALOG) — TẦNG 2

> **Màn hình phụ trách:** `frmMenu.vb` (Màn hình 7 / 9)  
> **Bảng CSDL liên quan:** `Menu`, `Menu_MonAn`, `MonAn`  
> **Phân quyền RBAC:** `CQ_QUAN_LY_THUC_DON`

---

## 1. MỤC TIÊU NGHIỆP VỤ:
- Cho phép Bếp trưởng / Chủ quán thiết kế các gói bảng thực đơn bán hàng cụ thể:
  - *Menu Alacarte Ngày* (gọi món lẻ)
  - *Menu Buffet Trưa 199k*
  - *Menu Buffet Tối Nướng & Lẩu 299k*
  - *Menu Cơm Trưa Văn Phòng (11h - 14h)*
  - *Menu Tiệc Sinh Nhật / Khuyến Mãi Mùa Hè*
- Quản lý danh sách các món ăn nằm trong bảng thực đơn (`Menu_MonAn`) và định giá bán theo từng menu.
- Làm đầu vào cho `Features/Branch/MenuDistribution/` để gán cho từng Chi nhánh.
