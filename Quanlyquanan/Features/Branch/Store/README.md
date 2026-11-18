# 🏢 DANH MỤC CHI NHÁNH CHUỖI NHÀ HÀNG (STORE MASTER) — TẦNG 3.1

> **Màn hình phụ trách:** `frmChiNhanh.vb` (Màn hình 8 / 9)  
> **Bảng CSDL liên quan:** `ChiNhanh`  
> **Phân quyền RBAC:** `CQ_QUAN_LY_CHI_NHANH`

---

## 1. MỤC TIÊU NGHIỆP VỤ:
- Quản lý danh mục các cơ sở, chi nhánh trực thuộc chuỗi nhà hàng:
  - Mã chi nhánh (`CN_Ma`)
  - Tên chi nhánh (`CN_Ten` - VD: *Chi nhánh 1: Quận 1, Chi nhánh 2: Thủ Đức...*)
  - Địa chỉ cơ sở (`CN_DiaChi`)
  - Hotline liên hệ (`CN_SoDienThoai`)
  - Người quản lý cơ sở (`CN_NguoiQuanLy` liên kết bảng `NhanVien`)
  - Trạng thái hoạt động (`CN_TrangThai`: Đang mở cửa / Tạm đóng cửa / Đang sửa chữa)
- Bảo vệ khóa ngoại: Chặn xóa chi nhánh đang có nhân viên, bàn ăn hoặc hóa đơn hoạt động.
