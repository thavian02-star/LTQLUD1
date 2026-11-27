# Kế Hoạch Sprint: Phân Hệ Báo Cáo Doanh Thu, Năng Suất & Thống Kê
**Màn hình:** `frmBaoCao` (Mục 3.5 Checklist Đồ Án)  
**Phiên bản dự kiến:** `v0.3.4`  
**Đối tượng sử dụng:** Quản lý cơ sở, Chủ nhà hàng (RBAC: `XEM_BAO_CAO_DOANH_THU`, `CHU_QUAN`)

---

## 1. Mục Tiêu Nghiệp Vụ
1. **Báo Cáo Doanh Thu Đa Chiều:**
   - Thống kê doanh thu theo mốc thời gian: Theo Ngày (hôm nay / 7 ngày qua), Theo Tháng, Theo Quý (Q1-Q4), Theo Năm.
   - Hiển thị tổng số hóa đơn hợp lệ (`HD_TrangThai = 1`), tổng số lượng khách đã phục vụ, giá trị hóa đơn trung bình (AOV - Average Order Value).
2. **Top Món Ăn & Thức Uống Bán Chạy (Best Sellers):**
   - Thống kê xếp hạng món ăn/nước uống theo số lượng bán ra (`SUM(CTHD_SoLuong)`) và tổng doanh thu thu về từ món đó.
   - Nhận diện các món đóng góp doanh thu lớn nhất cho chuỗi nhà hàng.
3. **Thống Kê Năng Suất Phục Vụ & Quỹ Lương Nhân Viên:**
   - Thống kê từng nhân viên: Số ca trực đã làm, tổng số giờ làm việc, số lượng khách / bàn đã phục vụ, tổng số tiền lương ca thực nhận (`Số ca * CA_LuongMoiCa`).
4. **Thống Kê Khách & Hiệu Suất Bàn Ăn:**
   - Số lượt khách theo từng khu vực bàn (Tầng trệt, Tầng 1, Sân vườn, VIP).
5. **Giao Diện Trực Quan, Hiện Đại:**
   - Thẻ KPI lớn (Doanh thu, Hóa đơn, Khách, Quỹ lương).
   - TabControl chuyển đổi giữa các báo cáo:
     - Tab 1: `📊 Doanh Thu & Hóa Đơn`
     - Tab 2: `🍲 Món Ăn Bán Chạy (Top Sellers)`
     - Tab 3: `👥 Năng Suất & Lương Nhân Viên`
   - Bộ lọc linh hoạt: `Từ ngày` &rarr; `Đến ngày`, Nút lọc nhanh: *Hôm nay*, *7 ngày qua*, *Tháng này*, *Năm nay*.
   - Xuất dữ liệu / Làm mới thời gian thực.

---

## 2. Thiết Kế Cơ Sở Dữ Liệu & Truy Vấn
- **Bảng `HoaDon`:** `HD_Ma`, `HD_MaBan`, `HD_MaNVPhucVu`, `HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_ThoiGianThanhToan`, `HD_TongTien`, `HD_TrangThai`, `HD_Xoa`.
- **Bảng `ChiTietHoaDon` & `MonAn`:** `CTHD_MaMonAn`, `CTHD_SoLuong`, `CTHD_DonGia`, `MA_Ten`, `MA_DanhMuc`.
- **Bảng `ChamCong` & `NhanVien` & `CaLamViec`:** `CC_MaNV`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `NV_HoTen`, `CA_LuongMoiCa`.
- **Bảng `Ban` & `KhuVuc`:** `B_Ma`, `B_TenBan`, `KV_Ten`.

---

## 3. Kiến Trúc 3 Lớp & Quy Tắc Kỹ Thuật
- `Quanlyquanan/Core/DTO/BaoCaoDoanhThuDTO.vb`
- `Quanlyquanan/Core/DTO/BaoCaoMonBanChayDTO.vb`
- `Quanlyquanan/Core/DTO/BaoCaoNhanVienLuongDTO.vb`
- `Quanlyquanan/Core/DAO/BaoCaoDAO.vb`
- `Quanlyquanan/Core/BUS/BaoCaoBUS.vb`
- `Quanlyquanan/Features/Analytics/frmBaoCao.Designer.vb` & `frmBaoCao.vb`
- **Tiêu chuẩn:** Mỗi hàm $\le 40$ dòng, mỗi file $\le 500$ dòng, biên dịch .NET 10.0 `0 Warning`, `0 Error`.
