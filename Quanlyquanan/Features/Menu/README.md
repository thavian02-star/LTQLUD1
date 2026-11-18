# 📋 PHÂN HỆ QUẢN LÝ THỰC ĐƠN (MENU SUBSYSTEM) — TẦNG 1 & TẦNG 2

> **Vai trò:** Quản trị toàn bộ thư viện món ăn và thiết kế các bảng thực đơn kinh doanh.

---

## CẤU TRÚC PHÂN CẤP THỰC ĐƠN:

```
Features/Menu/
├── 📁 Category/    # [Tầng 1.1] Phân loại món (Khai vị, Món chính, Lẩu, Nước...) -> frmDanhMuc.vb (MH 1)
├── 📁 Dish/        # [Tầng 1.2] Kho món ăn gốc (Thư viện toàn bộ món ăn của quán) -> frmMonAn.vb (MH 2)
└── 📁 Catalog/     # [Tầng 2] Thiết kế Bảng Thực Đơn thương mại (Alacarte, Buffet, Set cơm trưa...) -> frmMenu.vb (MH 7)
```

### Nguyên lý luồng dữ liệu:
1. `Category/` tạo các nhóm danh mục.
2. `Dish/` tạo các món ăn và gán vào nhóm danh mục tương ứng.
3. `Catalog/` tập hợp các món ăn từ kho `Dish/` thành các Bảng thực đơn bán lẻ hoàn chỉnh (`Menu_MonAn`).
4. Các Bảng thực đơn từ `Catalog/` sẽ được chuyển tiếp sang `Features/Branch/MenuDistribution/` để mở bán tại từng Chi nhánh cơ sở.
