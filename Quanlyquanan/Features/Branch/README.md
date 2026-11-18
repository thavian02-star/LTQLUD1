# 🏢 PHÂN HỆ QUẢN TRỊ CHUỖI & PHÂN BỔ THỰC ĐƠN (BRANCH SUBSYSTEM) — TẦNG 3

> **Vai trò:** Quản lý danh mục các cơ sở/chi nhánh chuỗi quán ăn và phân bổ bảng thực đơn mở bán tại từng cơ sở.

---

## CẤU TRÚC PHÂN CẤP:

```
Features/Branch/
├── 📁 Store/               # [Tầng 3.1] Quản lý Chi nhánh chuỗi quán -> frmChiNhanh.vb (MH 8)
└── 📁 MenuDistribution/   # [Tầng 3.2] Phân bổ thực đơn theo chi nhánh -> frmMenuChiNhanh.vb (MH 9)
```

### Nguyên lý luồng dữ liệu:
1. `Store/` quản lý thông tin các chi nhánh (Địa chỉ, Hotline, Quản lý chi nhánh).
2. `MenuDistribution/` tiếp nhận các Bảng thực đơn từ `Features/Menu/Catalog/` và phân bổ xuống từng Chi nhánh.
3. Khi nhân viên phục vụ tại Chi nhánh mở màn hình bán hàng `Features/POS/`, hệ thống sẽ nạp đúng Thực đơn đã được cấu hình cho Chi nhánh đó.
