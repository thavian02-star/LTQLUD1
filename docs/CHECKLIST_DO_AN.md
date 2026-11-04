# CHECKLIST HOÀN THÀNH ĐỒ ÁN: HỆ THỐNG QUẢN LÝ QUÁN ĂN
**Môn học:** Lập trình ứng dụng quản lý 1  
**Công nghệ:** Visual Basic .NET (WinForms) + Microsoft SQL Server 2022 (Docker)  
**Tài liệu gốc:** `Đồ án - Quan ly quan an 3.pdf`

---

## GIAI ĐOẠN 1: PHÂN TÍCH YÊU CẦU & THIẾT KẾ HỆ THỐNG (Analysis & Design)

### 1.1. Phân tích nghiệp vụ & Tác nhân (Actors)
- [ ] Xác định 4 nhóm người dùng (vai trò) trong hệ thống:
  - **Nhân viên phục vụ** (Bán hàng, quản lý bàn, đặt/thêm/đổi/hủy món, chuyển/gộp bàn, tính tiền, chấm công, xem lịch).
  - **Nhà bếp / Pha chế** (Xem danh sách món chờ chế biến theo thời gian, cập nhật trạng thái món đã nấu xong).
  - **Quản lý** (Xem lịch chung/riêng, duyệt chấm công, thực hiện các chức năng của phục vụ với đầu vào là nhân viên phục vụ tương ứng).
  - **Chủ quán** (Quản lý nhân viên, tổ chức bàn ghế, quản lý thực đơn, xếp lịch làm việc theo tuần/tháng, xem báo cáo thống kê, phân quyền, sao lưu/phục hồi).
- [x] Đặc tả chi tiết **Quy trình 1: Phục vụ khách hàng** (Chọn bàn -> Đặt món -> Chuyển bếp -> Bếp báo xong -> Mang món -> Chuyển/Gộp bàn -> Tính tiền & In hóa đơn) (chi tiết tại [`docs/QUY_TRINH_ORDER_MON.md`](QUY_TRINH_ORDER_MON.md)).
- [ ] Đặc tả chi tiết **Quy trình 2: Quản lý nhân sự** (Tiếp nhận hồ sơ, trình độ vi tính, cấp phát dụng cụ/trang phục -> Đăng ký/Xếp ca -> Chấm công & Duyệt công -> Tính lương theo số ca -> Nghỉ việc & Thu hồi dụng cụ).

### 1.2. Thiết kế kiến trúc & Mô hình dữ liệu
- [ ] Lập danh sách các lớp thực thể (theo bảng mẫu cuối file PDF: Tên lớp, Tên thuộc tính, Kiểu dữ liệu).
- [ ] Vẽ sơ đồ ERD (Mô hình thực thể kết hợp) và Sơ đồ quan hệ (Relational Schema).
- [x] Thiết kế kiến trúc phần mềm VB.NET theo mô hình 3 lớp (**GUI - BUS - DAO/DTO**) (chi tiết tại `docs/KIEN_TRUC_HE_THONG.md`).
- [ ] Phác thảo giao diện (Wireframe / Mockup) các màn hình chính trên Windows Forms.

---

## GIAI ĐOẠN 2: THIẾT KẾ & KHỞI TẠO CƠ SỞ DỮ LIỆU (Microsoft SQL Server Docker)

### 2.1. Cấu trúc bảng trong `database/docker-mssql/create-database.sql`
> Hệ quản trị: Microsoft SQL Server 2022 Express. Chuỗi kết nối: `localhost,1433;Database=QuanLyQuanAnDB;User Id=sa;Password=password123!;TrustServerCertificate=True;`

- [x] **Nhóm bảng Phân quyền & Tài khoản (RBAC):**
  - [x] `TaiKhoan` (`TK_Ma`, `TK_TenDangNhap`, `TK_MatKhau` băm MD5, `TK_Xoa`).
  - [x] `VaiTro` (`VT_Ma`, `VT_Ten`, `VT_Xoa`): *Chủ quán, Quản lý, Phục vụ, Nhà bếp*.
  - [x] `Quyen` (`Q_Ma`, `Q_Ten`, `Q_Tag`, `Q_Xoa`): Ánh xạ `Q_Tag` vào `Tag` của Button/Menu trên WinForms.
  - [x] `TaiKhoan_VaiTro` & `VaiTro_Quyen`.
- [x] **Nhóm bảng Nhân sự & Tuyển dụng:**
  - [x] `NhanVien` (`NV_Ma`, `NV_HoTen`, `NV_GioiTinh`, `NV_NgaySinh`, `NV_ViTri`, `NV_DienThoai`, `NV_DiaChi`, `NV_CMND`, `NV_NgayBatDauLam`, `NV_MaTaiKhoan`, `NV_TrangThai`, `NV_Xoa`).
  - [x] `TrinhDoViTinh` (`TDVT_Ma`, `TDVT_Ten`, `TDVT_Xoa`) — *Word, Excel, Cài phần mềm, Khác* (danh sách có thể thay đổi).
  - [x] `NhanVien_ViTinh` (Bảng trung gian lưu nhiều kỹ năng vi tính của nhân viên).
  - [x] `DungCuTrangPhuc` (`DC_Ma`, `DC_Ten`, `DC_SoLuongTong`, `DC_GhiChu`, `DC_Xoa`) & `NhanVien_DungCu` (Quản lý cấp phát và thu hồi trang phục khi nghỉ việc).
- [x] **Nhóm bảng Ca làm việc, Xếp lịch & Chấm công:**
  - [x] `CaLamViec` (`CA_Ma`, `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `CA_LuongMoiCa`, `CA_Xoa`).
  - [x] `LichLamViec` (`LLV_Ma`, `LLV_MaNV`, `LLV_MaCa`, `LLV_NgayLam`, `LLV_TrangThai`, `LLV_Xoa`).
  - [x] `ChamCong` (`CC_Ma`, `CC_MaLich`, `CC_MaNV`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `CC_Xoa`).
- [x] **Nhóm bảng Bàn ăn & Thực đơn:**
  - [x] `Ban` (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_SoNguoiToiDa`, `B_TrangThai`, `B_Xoa`).
  - [x] `DanhMuc` (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa`).
  - [x] `MonAn` (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon`, `MA_MoTa`, `MA_Xoa`).
- [x] **Nhóm bảng Phục vụ, Gọi món & Hóa đơn:**
  - [x] `HoaDon` (`HD_Ma`, `HD_MaBan`, `HD_MaNVPhucVu`, `HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_ThoiGianThanhToan`, `HD_TongTien`, `HD_TrangThai`, `HD_Xoa`).
  - [x] `ChiTietHoaDon` (`CTHD_Ma`, `CTHD_MaHoaDon`, `CTHD_MaMonAn`, `CTHD_SoLuong`, `CTHD_DonGia`, `CTHD_GhiChu`, `CTHD_ThoiGianGoi`, `CTHD_TrangThaiMon`, `CTHD_Xoa`).
- [x] **Khởi chạy & Kiểm thử Docker:**
  - [x] Tạo file `docker-compose.yml` và script `start-db.bat` để chạy 1-click.

### 2.2. Nạp dữ liệu mẫu (Seed Data) & Kiểm thử Docker
- [x] Viết dữ liệu mẫu (`INSERT INTO`) cho 4 tài khoản đại diện 4 vai trò (mật khẩu `123456`), danh sách bàn, thực đơn món ăn/nước uống, ca làm việc, lịch làm việc và một vài hóa đơn mẫu để test báo cáo (chi tiết tại `database/docker-mssql/seed-data.sql`).
- [ ] Build Docker image và chạy container từ `docker-data-server`.
- [ ] Kiểm tra kết nối tới `localhost,1433` và xác nhận tất cả các bảng được tạo thành công không lỗi.

---

## GIAI ĐOẠN 3: PHÁT TRIỂN ỨNG DỤNG VB.NET WINFORMS (Development)

### 3.1. Khởi tạo Solution & Lớp nền tảng (Core / Infrastructure)
- [x] Tạo Solution VB.NET Windows Forms App (`Quanlyquanan` - target .NET 10.0-windows).
- [x] Xây dựng lớp `DatabaseAccess` / `KetNoiCSDL` (Quản lý `SqlConnection`, thực thi truy vấn `ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar`) tại `Core/Database/KetNoiCSDL.vb`.
- [x] Xây dựng hàm tiện ích mã hóa mật khẩu `MD5` (`Core/Security/MaHoaMD5.vb`) và quản lý phiên đăng nhập (`Core/Security/Session.vb`: lưu thông tin người dùng hiện tại và danh sách quyền `Q_Tag`).
- [x] Xây dựng cơ chế kiểm tra phân quyền tự động theo `Tag` của Menu/Button trên Form (`Core/Helpers/PhanQuyenHelper.vb`).

### 3.2. Phân hệ Chung (Hệ thống & Cá nhân)
- [x] **Màn hình Đăng nhập (`frmDangNhap`):** Đăng nhập, kiểm tra tài khoản, tải quyền theo vai trò (hoàn thành 5 bước theo `docs/features/AUTH_DANG_NHAP.md`).
- [ ] **Màn hình Chính (`frmMain`):** Thanh điều hướng (Menu/Sidebar) hiển thị các chức năng được phép truy cập theo vai trò.
- [ ] **Màn hình Đổi mật khẩu (`frmDoiMatKhau`):** Xác nhận mật khẩu cũ và cập nhật mật khẩu mới (băm MD5).
- [ ] **Màn hình Cá nhân & Chấm công (`frmChamCongCaNhan`):**
  - [ ] Xem lịch làm việc của bản thân theo tuần.
  - [ ] Nút **Bắt đầu làm** (Check-in) và **Kết thúc làm** (Check-out) cho ca hiện tại.

### 3.3. Phân hệ Nhân viên phục vụ (Bán hàng & Quản lý bàn)
- [ ] **Màn hình Sơ đồ bàn & Phục vụ (`frmSoDoBan`):**
  - [ ] Hiển thị danh sách bàn trực quan (màu sắc theo 4 trạng thái: *Trống, Có khách, Đang đợi món, Món đã xong*).
  - [ ] Cho phép chọn nhân viên phục vụ tiếp nhận (nếu đăng nhập dưới quyền **Quản lý**).
- [ ] **Chức năng Gọi món / Đặt món:**
  - [ ] Chọn bàn trống -> Nhập số lượng khách (kiểm tra sức chứa tối đa của bàn) -> Chọn món ăn/nước uống, số lượng, ghi chú.
  - [ ] Cảnh báo ngay nếu món đã hết (`SP_HetHang = 1`).
  - [ ] Chuyển trạng thái bàn sang *Đang đợi món* và đẩy danh sách món xuống bếp.
- [ ] **Chức năng Thêm món / Đổi món / Hủy món:**
  - [ ] Khách kêu thêm món nhiều lần trên cùng bàn.
  - [ ] Chỉ cho phép **Đổi món / Hủy món** khi món ở trạng thái *Chờ thực hiện* (chưa được bếp nấu xong).
  - [ ] Xác nhận đã đem món ra cho khách khi bếp báo *Món đã xong*.
- [ ] **Chức năng Chuyển bàn & Gộp bàn:**
  - [ ] **Chuyển bàn:** Chuyển hóa đơn đang phục vụ từ bàn A sang bàn B (đang trống).
  - [ ] **Gộp bàn:** Gộp các món từ 2 hoặc nhiều bàn vào chung 1 hóa đơn để tính tiền, giải phóng các bàn được gộp về trạng thái *Trống*.
- [ ] **Chức năng Tính tiền & In hóa đơn (`frmThanhToan` / `frmInHoaDon`):**
  - [ ] Cộng tổng tiền các món hợp lệ (không tính món đã hủy).
  - [ ] Xuất/In hóa đơn (hiển thị Preview bằng `PrintDocument` / `PrintPreviewDialog` hoặc xuất file HTML/PDF/Text rõ ràng).
  - [ ] Cập nhật trạng thái hóa đơn *Đã thanh toán* và đổi trạng thái bàn về *Trống*.

### 3.4. Phân hệ Nhà bếp / Pha chế
- [ ] **Màn hình Hàng đợi Nhà bếp (`frmNhaBep`):**
  - [ ] Hiển thị danh sách các món ăn/nước uống đang ở trạng thái *Chờ thực hiện* sắp xếp theo thứ tự thời gian đặt (`CTHD_ThoiGianGoi ASC`).
  - [ ] Hiển thị rõ: Số bàn, Tên món, Số lượng, Ghi chú của khách, Thời gian đặt.
  - [ ] Nút **Hoàn thành món**: Cập nhật trạng thái món sang *Đã nấu xong* và tự động cập nhật trạng thái bàn tương ứng sang *Món đã xong* để nhân viên phục vụ biết mang ra.

### 3.5. Phân hệ Quản lý & Chủ quán
- [ ] **Quản lý Nhân sự (`frmQuanLyNhanVien`):**
  - [ ] Thêm / Sửa nhân viên với đầy đủ thông tin: Họ tên, giới tính, ngày sinh, vị trí dự tuyển (Phục vụ, Pha chế, Quản lý, Tiếp tân), SĐT, địa chỉ, CMND, ngày vào làm.
  - [ ] Chọn nhiều **Trình độ vi tính** (Word, Excel, Cài phần mềm, Khác) và cho phép thêm/sửa danh mục trình độ vi tính.
  - [ ] Quản lý **Dụng cụ / Trang phục** cấp phát cho nhân viên.
  - [ ] Nghiệp vụ **Nhân viên nghỉ việc**: Đổi trạng thái nghỉ việc, xóa lịch làm việc tương lai, đánh dấu thu hồi trang phục/dụng cụ.
- [ ] **Quản lý Bàn ghế (`frmQuanLyBan`):**
  - [ ] Tổ chức bàn ghế: Thêm / Sửa / Xóa bàn, gán số thứ tự, số người tối đa.
- [ ] **Quản lý Thực đơn (`frmQuanLyThucDon`):**
  - [ ] Quản lý danh mục món & khởi tạo/chỉnh sửa món ăn, nước uống (tên, giá bán, mô tả, đánh dấu còn/hết món).
- [ ] **Quản lý Lịch làm việc & Chấm công (`frmQuanLyLichLamViec`, `frmDuyetChamCong`):**
  - [ ] Cấu hình danh sách ca và khung giờ làm việc.
  - [ ] Xem & chỉnh sửa lịch làm việc chung của tất cả nhân viên trong tuần (7 ngày/tuần, xem ca nào trống, ca nào có bao nhiêu nhân viên, thêm/xóa nhân viên vào ca).
  - [ ] Xem & chỉnh sửa lịch làm việc riêng của 1 nhân viên được chọn (thay đổi trạng thái ca).
  - [ ] **Duyệt chấm công** (dành cho Quản lý) & Tổng hợp số ca làm việc trong tháng để **Tính lương nhân viên**.
- [ ] **Báo cáo & Thống kê (`frmBaoCao`):**
  - [ ] Báo cáo doanh thu theo Tháng / Quý / Năm.
  - [ ] Thống kê số lượng khách trong các ca theo Tháng / Quý / Năm.
  - [ ] Thống kê số lượng khách mà một nhân viên phục vụ trong tuần.
  - [ ] Thống kê số lượng khách của từng bàn theo Tháng / Quý / Năm.
  - [ ] Thống kê số lượng bán của từng món ăn/nước uống theo Tháng / Quý / Năm.
  - [ ] Thống kê tổng số ca làm việc của nhân viên (kèm bảng tính lương).
- [ ] **Chức năng mở rộng (Tùy chọn cộng điểm):**
  - [ ] **Phân quyền người dùng (`frmPhanQuyen`):** Tạo/sửa/xóa vai trò (`VaiTro`), tích chọn thêm/xóa chức năng (`Quyen`) cho từng vai trò.
  - [ ] **Sao lưu & Phục hồi (`frmBackupRestore`):** Thực thi lệnh `BACKUP DATABASE` và `RESTORE DATABASE` của SQL Server.

---

## GIAI ĐOẠN 4: KIỂM THỬ HỆ THỐNG (Testing)

- [ ] **Kiểm thử luồng nghiệp vụ chính (End-to-End):**
  - [ ] Luồng 1: Phục vụ mở bàn -> Đặt 3 món -> Hủy 1 món khi bếp chưa làm -> Bếp nấu xong 2 món -> Phục vụ mang ra -> Khách gọi thêm 1 nước -> Chuyển bàn -> Gộp bàn -> Tính tiền & In hóa đơn.
  - [ ] Luồng 2: Chủ quán tiếp nhận nhân viên mới -> Cấp đồng phục -> Xếp lịch tuần -> Nhân viên đăng nhập chấm công -> Quản lý duyệt công -> Cuối tháng xem báo cáo số ca & lương -> Cho nhân viên nghỉ việc & trả đồng phục.
- [ ] **Kiểm thử phân quyền:** Đăng nhập từng tài khoản (*Phục vụ, Bếp, Quản lý, Chủ quán*) để đảm bảo không truy cập được màn hình trái thẩm quyền.
- [ ] **Kiểm thử ràng buộc dữ liệu (Validation):** Kiểm tra nhập số âm, để trống trường bắt buộc, chọn món đã hết, hủy món khi bếp đã nấu xong, gộp bàn trống...

---

## GIAI ĐOẠN 5: TÀI LIỆU & ĐÓNG GÓI NỘP BÀI (Documentation & Submission)

Theo mục **Yêu cầu các tài liệu cần nộp** ở trang 3 file PDF:
- [ ] **1. Documents (Tài liệu báo cáo Word/PDF):**
  - [ ] Mô tả bài toán & phân tích yêu cầu chức năng.
  - [ ] Thiết kế hệ thống: Danh sách lớp đối tượng (Tên lớp, Tên thuộc tính, Kiểu dữ liệu), Sơ đồ ERD, Thiết kế CSDL vật lý.
  - [ ] Hướng dẫn cài đặt và hướng dẫn sử dụng có ảnh chụp màn hình từng phân hệ.
- [ ] **2. Sources (Mã nguồn):**
  - [ ] Dọn dẹp thư mục `bin/obj` không cần thiết hoặc đóng gói đầy đủ Solution VB.NET.
  - [ ] Đảm bảo chuỗi kết nối trong `App.config` / class kết nối dễ cấu hình.
- [ ] **3. Các phần mềm / công cụ cần thiết để chạy chương trình:**
  - [ ] Đóng gói thư mục `docker-data-server` (kèm file `create-database.sql` hoàn chỉnh và file hướng dẫn lệnh chạy Docker / hoặc file `.bat` khởi chạy 1-click).
  - [ ] Ghi chú phiên bản .NET Framework / .NET Desktop Runtime cần thiết.
