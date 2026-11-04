# MA TRẬN PHÂN QUYỀN HỆ THỐNG (ROLE-BASED ACCESS CONTROL - RBAC)

**Dự án:** Hệ thống Quản lý Quán ăn  
**Môn học:** Lập trình ứng dụng quản lý 1 - VB.NET  
**Cơ sở dữ liệu:** Microsoft SQL Server 2022 Express (Docker)  
**Tài liệu tham chiếu:** [Đề bài PDF - Trang 2 & 3](file:///c:/Users/wmwar/OneDrive/Desktop/DAQLUD1/docs/%C4%90%E1%BB%93%20%C3%A1n%20-%20Quan%20ly%20quan%20an%203.pdf) & [`seed-data.sql`](file:///c:/Users/wmwar/OneDrive/Desktop/DAQLUD1/database/docker-mssql/seed-data.sql)

---

## 1. ĐẶC TẢ 4 VAI TRÒ NGƯỜI DÙNG (ACTORS)

| STT | Vai trò (Role) | Mã VT | Tài khoản mẫu | Mô tả trách nhiệm & thẩm quyền |
|:---:|:---|:---:|:---|:---|
| **1** | **Chủ quán (Admin)** | `1` | `chuquan`<br>*(Pass: 123456)* | **Toàn quyền hệ thống:** Tuyển dụng nhân sự, cấp/thu hồi trang phục, xếp lịch tuần/tháng, quản lý thực đơn món & bàn ăn, xem 6 loại báo cáo thống kê doanh thu/lương, phân quyền tài khoản & sao lưu CSDL. |
| **2** | **Quản lý (Manager)** | `2` | `quanly`<br>*(Pass: 123456)* | **Điều hành & Duyệt công:** Xem lịch chung, duyệt bảng chấm công của nhân viên; hỗ trợ bán hàng thay phục vụ (ghi nhận người tạo là Quản lý nhưng tính doanh thu cho nhân viên phục vụ đó). |
| **3** | **Nhân viên phục vụ** | `3` | `phucvu1`, `phucvu2`<br>*(Pass: 123456)* | **Bán hàng trực tiếp:** Xem sơ đồ bàn, đặt món, chuyển bàn, gộp bàn, tính tiền & in hóa đơn; xem lịch làm việc và bấm chấm công cá nhân vào/ra ca. |
| **4** | **Nhà bếp / Pha chế** | `4` | `nhabep1`, `phache1`<br>*(Pass: 123456)* | **Chế biến món ăn:** Xem danh sách hàng đợi các món cần nấu theo thứ tự thời gian gọi (FIFO); bấm xác nhận món đã nấu xong để phục vụ mang lên; chấm công cá nhân. |

---

## 2. BẢNG MA TRẬN PHÂN QUYỀN (PERMISSION MATRIX)

Ký hiệu:  
- ✅ : **Được phép truy cập & thao tác**  
- ❌ : **Bị khóa / Ẩn khỏi màn hình**

| STT | Tên chức năng | Mã định danh (`Q_Tag`) | 👑 Chủ quán | 👔 Quản lý | ☕ Phục vụ | 🍳 Nhà bếp |
|:---:|:---|:---|:---:|:---:|:---:|:---:|
| **1** | Xem sơ đồ bàn & Gọi món tại bàn | `POS_SO_DO_BAN` | ✅ | ✅ | ✅ | ❌ |
| **2** | Chuyển bàn & Gộp bàn ăn | `POS_CHUYEN_GOP_BAN` | ✅ | ✅ | ✅ | ❌ |
| **3** | Tính tiền & In hóa đơn thanh toán | `POS_THANH_TOAN` | ✅ | ✅ | ✅ | ❌ |
| **4** | Xem lịch cá nhân & Chấm công vào/ra ca | `CA_NHAN_CHAM_CONG` | ✅ | ✅ | ✅ | ✅ |
| **5** | Màn hình hàng đợi Bếp & Báo nấu xong | `BEP_HANG_DOI_MON` | ✅ | ❌ | ❌ | ✅ |
| **6** | Duyệt bảng chấm công nhân sự | `QL_DUYET_CHAM_CONG` | ✅ | ✅ | ❌ | ❌ |
| **7** | Quản lý hồ sơ nhân sự, vi tính & đồng phục | `CQ_QUAN_LY_NHAN_VIEN` | ✅ | ❌ | ❌ | ❌ |
| **8** | Quản lý danh mục bàn ghế & Khu vực | `CQ_QUAN_LY_BAN` | ✅ | ❌ | ❌ | ❌ |
| **9** | Quản lý thực đơn & Giá bán món ăn | `CQ_QUAN_LY_THUC_DON` | ✅ | ❌ | ❌ | ❌ |
| **10**| Xếp lịch & Phân công ca làm việc | `CQ_XEP_LICH_LAM_VIEC` | ✅ | ✅ | ❌ | ❌ |
| **11**| Xem 6 báo cáo doanh thu & Thống kê | `CQ_BAO_CAO_THONG_KE` | ✅ | ❌ | ❌ | ❌ |
| **12**| Quản trị phân quyền tài khoản & Sao lưu | `CQ_HE_THONG_PHAN_QUYEN` | ✅ | ❌ | ❌ | ❌ |

---

## 3. CƠ CHẾ THỰC THI TRÊN ỨNG DỤNG WINFORMS

1. **Khi đăng nhập thành công (`frmDangNhap`):**
   - Hệ thống truy vấn các bảng `TaiKhoan_VaiTro` và `VaiTro_Quyen` để lấy toàn bộ danh sách `Q_Tag` mà user sở hữu.
   - Nạp danh sách này vào lớp `Session.DanhSachQuyen`.
2. **Khi Form hiển thị (`Form_Load`):**
   - Lớp tiện ích `PhanQuyenHelper.ApDungPhanQuyen(Me)` sẽ tự động duyệt đệ quy:
     - Nút/Menu nào có thuộc tính `Tag` trùng với `Q_Tag` được cấp $\rightarrow$ Giữ nguyên trạng thái hoạt động.
     - Nút/Menu nào có `Tag` mà tài khoản **không được cấp** $\rightarrow$ Tự động chuyển thành `Enabled = False` (làm mờ) hoặc `Visible = False` (ẩn hoàn toàn).
3. **Quy tắc đặc quyền của Chủ quán:**
   - Nếu `Session.MaVaiTro = 1` (Chủ quán), phương thức `PhanQuyenHelper` sẽ bỏ qua việc ẩn/mờ và tự động mở toàn bộ 100% chức năng.
