# Kế Hoạch Sprint: Phân Hệ Quản Lý Vai Trò & Phân Quyền Người Dùng Động
**Màn hình:** `frmPhanQuyen` (Mục 3.6 Checklist Đồ Án - Chức Năng Nâng Cao Cộng Điểm)  
**Phiên bản dự kiến:** `v0.3.6`  
**Đối tượng sử dụng:** Chủ nhà hàng, Quản trị viên tối cao (RBAC: `CHU_QUAN`, `ADMIN`)

---

## 1. Mục Tiêu Nghiệp Vụ
1. **Quản Lý Nhóm Vai Trò (Roles Management):**
   - Danh sách các vai trò: `Chủ quán / Giám đốc`, `Quản lý cơ sở`, `Nhân viên phục vụ bàn`, `Nhân viên nhà bếp / pha chế`, `Thu ngân`.
   - Thêm vai trò mới, Chỉnh sửa tên & mô tả vai trò, Xóa vai trò (không xóa vai trò mặc định của hệ thống).
2. **Cây Quyền Hạn Động Theo Phân Hệ (Dynamic Permissions Tree):**
   - Danh mục quyền hạn được gom nhóm khoa học:
     - `⚙️ Phân hệ Hệ Thống & Tài Khoản`: Đổi mật khẩu, Phân quyền người dùng.
     - `📋 Phân hệ Danh Mục Master (9/9)`: Món ăn, Bàn ăn, Khu vực, Ca làm việc, Chi nhánh, Menu.
     - `🍽️ Phân hệ Bán Hàng & POS`: Mở bàn, Đặt món, Chuyển bàn, Thanh toán hóa đơn.
     - `🍳 Phân hệ Nhà Bếp & KDS`: Tiếp nhận món, Báo xong món.
     - `⏱️ Phân hệ Nhân Sự & Lịch Trực`: Điểm danh chấm công, Duyệt công, Xếp lịch tuần.
     - `📊 Phân hệ Báo Cáo & Thống Kê`: Doanh thu, Báo cáo món bán chạy, Năng suất nhân viên.
3. **Thao Tác Cấp Quyền 1-Click (RBAC Matrix):**
   - Chọn một vai trò bên trái &rarr; Bảng cây quyền bên phải tự động hiển thị các checkbox tương ứng.
   - Nút `Chọn tất cả` / `Bỏ chọn tất cả`.
   - Nút `💾 Lưu Cấu Hình Phân Quyền [F2]`: Ghi nhận dữ liệu vào bảng `VaiTro_Quyen`.
   - Có cơ chế cảnh báo an toàn: Bảo vệ vai trò Chủ quán luôn giữ toàn quyền.

---

## 2. Thiết Kế Cơ Sở Dữ Liệu & Truy Vấn
- **Bảng `VaiTro`:** `VT_Ma`, `VT_Ten`, `VT_MoTa`, `VT_Xoa`.
- **Bảng `Quyen`:** `Q_Ma`, `Q_Ten`, `Q_MoTa`, `Q_Tag`, `Q_Nhom`, `Q_Xoa`.
- **Bảng `VaiTro_Quyen`:** `VTQ_MaVaiTro`, `VTQ_MaQuyen`, `VTQ_Xoa`.

---

## 3. Kiến Trúc 3 Lớp & Quy Tắc Kỹ Thuật
- `Quanlyquanan/Core/DTO/VaiTroDTO.vb` & `QuyenDTO.vb`
- `Quanlyquanan/Core/DAO/PhanQuyenDAO.vb`
- `Quanlyquanan/Core/BUS/PhanQuyenBUS.vb`
- `Quanlyquanan/Features/Security/frmPhanQuyen.Designer.vb` & `frmPhanQuyen.vb`
- **Tiêu chuẩn:** Mỗi hàm $\le 40$ dòng, mỗi file $\le 500$ dòng, biên dịch .NET 10.0 `0 Warning`, `0 Error`.
