# TÀI LIỆU KIẾN TRÚC HỆ THỐNG (SYSTEM ARCHITECTURE)
**Dự án:** Hệ thống Quản lý Quán ăn  
**Môn học:** Lập trình ứng dụng quản lý 1  
**Nền tảng:** Visual Basic .NET (.NET 10.0 Windows Forms)  
**Cơ sở dữ liệu:** Microsoft SQL Server 2022 Express (Docker) / MS Access 2000-2003 (.mdb)  

---

## 1. TỔNG QUAN HỆ THỐNG

Phần mềm Quản lý Quán ăn được xây dựng nhằm hỗ trợ toàn diện các hoạt động vận hành thường nhật của một quán ăn/nhà hàng vừa và nhỏ, bao gồm 4 nhóm tác nhân (Actors):
1. **Chủ quán (Admin):** Quản lý hồ sơ nhân sự, xếp lịch làm việc theo tuần/tháng, thiết lập danh mục món ăn/bàn ghế, xem báo cáo doanh thu & thống kê, phân quyền tài khoản.
2. **Quản lý (Manager):** Xem lịch làm việc chung/cá nhân, duyệt bảng chấm công hàng ngày, hỗ trợ xử lý nghiệp vụ bán hàng khi cần thiết.
3. **Nhân viên phục vụ (Staff):** Quản lý trạng thái bàn (trống/có khách/đặt trước), ghi nhận order, thêm/hủy món, chuyển/gộp bàn, tính tiền & in hóa đơn, chấm công cá nhân.
4. **Nhà bếp / Pha chế (Kitchen):** Theo dõi danh sách món ăn đang chờ chế biến theo thứ tự thời gian thực, cập nhật trạng thái món đã chế biến xong để phục vụ mang lên.

---

## 2. MÔ HÌNH KIẾN TRÚC 3 LỚP (3-TIER ARCHITECTURE)

Dự án áp dụng mô hình phân lớp chuẩn công nghiệp nhằm đảm bảo tính độc lập, dễ bảo trì, dễ mở rộng và kiểm thử:

```
┌─────────────────────────────────────────────────────────────────┐
│              1. TẦNG TRÌNH DIỄN (Presentation Layer - GUI)       │
│  - Windows Forms (VB.NET .NET 10.0-windows)                    │
│  - Form Đăng nhập, Bán hàng/Bàn ăn, Nhà bếp, Nhân sự, Báo cáo │
│  - Bắt sự kiện người dùng, kiểm soát trạng thái giao diện      │
└────────────────────────────────┬────────────────────────────────┘
                                 │ (Gọi xử lý)
┌────────────────────────────────▼────────────────────────────────┐
│           2. TẦNG NGHIỆP VỤ (Business Logic Layer - BUS / BLL)   │
│  - Quy tắc nghiệp vụ (Business Rules & Validation)              │
│  - Phân quyền RBAC (Role-Based Access Control)                  │
│  - Xử lý chuyển/gộp bàn, tính tổng tiền hóa đơn, duyệt công     │
└────────────────────────────────┬────────────────────────────────┘
                                 │ (Truyền tải DTO & gọi DAO)
┌────────────────────────────────▼────────────────────────────────┐
│           3. TẦNG TRUY CẬP DỮ LIỆU (Data Access Layer - DAO)     │
│  - DTO (Data Transfer Objects): Lớp đối tượng thực thể          │
│  - DAO (Data Access Objects): SqlHelper / KetNoiCSDL            │
│  - Thực thi SqlCommand, Parameters, chống SQL Injection         │
└────────────────────────────────┬────────────────────────────────┘
                                 │ (Chuỗi kết nối / T-SQL)
┌────────────────────────────────▼────────────────────────────────┐
│                   4. CƠ SỞ DỮ LIỆU (Database Server)             │
│  - Microsoft SQL Server 2022 Express (Docker Container)         │
│  - 18 bảng chuẩn hóa quan hệ (1-N, N-N)                          │
└─────────────────────────────────────────────────────────────────┘
```

---

## 3. CHI TIẾT TỪNG TẦNG TRONG HỆ THỐNG

### 3.1. Tầng Giao diện (Presentation Layer - GUI)
- **Vị trí thư mục:** `Quanlyquanan/`
- **Thành phần chính:**
  - `frmDangNhap`: Đăng nhập, ghi nhận phiên làm việc, tải danh sách quyền.
  - `frmMain`: Giao diện chính chứa MenuStrip / Sidebar điều hướng theo quyền hạn.
  - `frmBanAn` & `frmGoiMon`: Quản lý sơ đồ bàn trực quan theo màu sắc trạng thái, menu gọi món, hóa đơn tạm tính.
  - `frmNhaBep`: Màn hình dành riêng cho bếp theo dõi order theo thời gian thực (FIFO).
  - `frmNhanVien`, `frmLichLamViec`, `frmChamCong`: Phân hệ quản trị nhân sự và lịch làm việc.
  - `frmThucDon`, `frmBan`: Quản lý danh mục món, nhóm món và sơ đồ bàn ăn.
  - `frmBaoCao`: Thống kê doanh thu theo ngày/tháng, nhân viên bán nhiều nhất, món bán chạy.

### 3.2. Tầng Nghiệp vụ (Business Logic Layer - BUS)
- **Nhiệm vụ:**
  - Tiếp nhận yêu cầu từ GUI, kiểm tra dữ liệu đầu vào (Validation).
  - Áp dụng các quy tắc logic nghiệp vụ:
    - Bàn đang có khách thì không thể xóa bàn hoặc chuyển sang bàn đã có khách khác mà không có lệnh gộp bàn.
    - Món ăn đã chế biến xong không cho phép nhân viên phục vụ tự ý hủy nếu không có xác nhận của quản lý.
    - Nhân viên nghỉ việc sẽ tự động chuyển trạng thái, hủy lịch làm tương lai và yêu cầu hoàn trả đầy đủ dụng cụ/trang phục đã cấp phát.
    - Chỉ cho phép tính tiền nếu hóa đơn đang ở trạng thái `Chưa thanh toán`.

### 3.3. Tầng Truy cập Dữ liệu (Data Access Layer - DAO / DTO)
- **DTO (Data Transfer Objects):**
  - Chứa các class đơn giản (POCO) biểu diễn dữ liệu bảng: `TaiKhoanDTO`, `NhanVienDTO`, `MonAnDTO`, `BanDTO`, `HoaDonDTO`, `ChiTietHoaDonDTO`...
- **DAO (Data Access Objects):**
  - `KetNoiCSDL` / `DatabaseAccess`: Quản lý chuỗi kết nối (`ConnectionString`), mở/đóng kết nối tự động bằng khối `Using`.
  - Cung cấp các hàm dùng chung:
    - `ExecuteQuery(sql, parameters) As DataTable`: Đọc dữ liệu lên lưới (DataGridView) hoặc danh sách.
    - `ExecuteNonQuery(sql, parameters) As Integer`: Thực hiện `INSERT`, `UPDATE`, `DELETE`.
    - `ExecuteScalar(sql, parameters) As Object`: Lấy giá trị đơn lẻ (COUNT, MAX, SUM, SCOPE_IDENTITY).
  - Toàn bộ tham số đầu vào bắt buộc truyền qua `SqlParameter` để ngăn chặn hoàn toàn lỗi bảo mật **SQL Injection**.

---

## 4. CƠ CHẾ PHÂN QUYỀN VAI TRÒ (RBAC - ROLE BASED ACCESS CONTROL)

Hệ thống triển khai cơ chế kiểm soát truy cập dựa trên vai trò kết hợp với thuộc tính `Tag` của Windows Forms:

1. **Bảng phân quyền:**
   - `TaiKhoan` (1 - N) `TaiKhoan_VaiTro` (N - 1) `VaiTro` (1 - N) `VaiTro_Quyen` (N - 1) `Quyen`.
2. **Mã định danh quyền (`Q_Tag`):**
   - Mỗi chức năng hoặc nút bấm nhạy cảm trên form được cấp một mã `Q_Tag` duy nhất (ví dụ: `BTN_XOA_NV`, `MENU_BAO_CAO`, `BTN_DUYET_CONG`...).
3. **Quản lý phiên (Session Management):**
   - Khi đăng nhập thành công, lớp `Session` lưu trữ thông tin tài khoản hiện tại và nạp danh sách quyền (`List(Of String)`) mà tài khoản được cấp.
4. **Ánh xạ động lên UI:**
   - Một hàm tiện ích duyệt đệ quy toàn bộ Control/MenuItem trên Form:
     - Nếu Control có `Tag` được thiết lập và `Tag` đó không tồn tại trong danh sách quyền của `Session`, hệ thống sẽ tự động đặt `Control.Visible = False` hoặc `Control.Enabled = False`.

---

## 5. MÔ HÌNH CƠ SỞ DỮ LIỆU (DATABASE ARCHITECTURE)

Hệ thống gồm **18 bảng chuẩn hóa quan hệ** được chia làm 5 nhóm nghiệp vụ:
- **Nhóm 1 - Phân quyền & Tài khoản (5 bảng):** `TaiKhoan`, `VaiTro`, `Quyen`, `TaiKhoan_VaiTro`, `VaiTro_Quyen`.
- **Nhóm 2 - Nhân sự & Tuyển dụng (5 bảng):** `NhanVien`, `TrinhDoViTinh`, `NhanVien_ViTinh`, `DungCuTrangPhuc`, `NhanVien_DungCu`.
- **Nhóm 3 - Ca làm việc & Chấm công (3 bảng):** `CaLamViec`, `LichLamViec`, `ChamCong`.
- **Nhóm 4 - Bàn ăn & Thực đơn (3 bảng):** `Ban`, `DanhMuc`, `MonAn`.
- **Nhóm 5 - Phục vụ & Hóa đơn (2 bảng):** `HoaDon`, `ChiTietHoaDon`.

Toàn bộ script khởi tạo tự động có sẵn tại `database/docker-mssql/create-database.sql` và dữ liệu mẫu thực tế tại `database/docker-mssql/seed-data.sql`.
