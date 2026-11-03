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
- [ ] Đặc tả chi tiết **Quy trình 1: Phục vụ khách hàng** (Chọn bàn -> Đặt món -> Chuyển bếp -> Bếp báo xong -> Mang món -> Chuyển/Gộp bàn -> Tính tiền & In hóa đơn).
- [ ] Đặc tả chi tiết **Quy trình 2: Quản lý nhân sự** (Tiếp nhận hồ sơ, trình độ vi tính, cấp phát dụng cụ/trang phục -> Đăng ký/Xếp ca -> Chấm công & Duyệt công -> Tính lương theo số ca -> Nghỉ việc & Thu hồi dụng cụ).

### 1.2. Thiết kế kiến trúc & Mô hình dữ liệu
- [ ] Lập danh sách các lớp thực thể (theo bảng mẫu cuối file PDF: Tên lớp, Tên thuộc tính, Kiểu dữ liệu).
- [ ] Vẽ sơ đồ ERD (Mô hình thực thể kết hợp) và Sơ đồ quan hệ (Relational Schema).
- [ ] Thiết kế kiến trúc phần mềm VB.NET theo mô hình 3 lớp (**GUI - BUS - DAO/DTO**).
- [ ] Phác thảo giao diện (Wireframe / Mockup) các màn hình chính trên Windows Forms.

---

## GIAI ĐOẠN 2: THIẾT KẾ & KHỞI TẠO CƠ SỞ DỮ LIỆU (Database & Docker)

### 2.1. Thiết kế bảng trong `docker-data-server/create-database.sql`
> Quy ước chung: Sử dụng cờ xóa mềm (`_Xoa BIT DEFAULT 0`) và hỗ trợ tiếng Việt (`COLLATE Latin1_General_100_CI_AS_SC_UTF8`).

- [ ] **Nhóm bảng Tài khoản & Phân quyền (RBAC):**
  - [x] `TaiKhoan` (`TK_Ma`, `TK_TenDangNhap`, `TK_MatKhau` mã hóa MD5, `TK_Xoa`)
  - [x] `VaiTro` (`VT_Ma`, `VT_Ten`, `VT_Xoa`) -> Cập nhật 4 vai trò: *Phục vụ, Nhà bếp, Quản lý, Chủ quán*.
  - [x] `Quyen` (`Q_Ma`, `Q_Ten`, `Q_Tag`, `Q_Xoa`) -> Cập nhật `Q_Tag` khớp với các màn hình quán ăn.
  - [x] `TaiKhoan_VaiTro` & `VaiTro_Quyen`
- [ ] **Nhóm bảng Nhân sự & Tuyển dụng:**
  - [ ] Mở rộng bảng `NguoiDung` / `NhanVien` (`ND_Ma`, `ND_Ten`, `ND_GioiTinh`, `ND_NgaySinh`, `ND_ViTriDuTuyen`, `ND_DienThoai`, `ND_DiaChi`, `ND_CMND`, `ND_NgayBatDauLam`, `ND_TrangThai` [Đang làm/Nghỉ việc], `ND_MaTaiKhoan`, `ND_Xoa`).
  - [ ] `TrinhDoViTinh` (`TDVT_Ma`, `TDVT_Ten`, `TDVT_Xoa`) — Dữ liệu mặc định: *Word, Excel, Cài phần mềm, Khác* (cho phép thay đổi).
  - [ ] `NhanVien_ViTinh` (Bảng trung gian lưu các kỹ năng vi tính của nhân viên).
  - [ ] `DungCuTrangPhuc` (`DC_Ma`, `DC_Ten`, `DC_MoTa`, `DC_Xoa`) & `NhanVien_DungCu` (Lưu ngày nhận, số lượng, trạng thái đã trả khi nghỉ việc).
- [ ] **Nhóm bảng Ca làm việc, Lịch làm việc & Chấm công:**
  - [ ] `CaLamViec` (`CA_Ma`, `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `CA_MucLuongCa`, `CA_Xoa`) — Hỗ trợ cấu hình linh hoạt (3 ca: `8g-13g`, `12g-17g`, `17g-22g` hoặc 2 ca cố định: `9h-16h`, `16h-22h`).
  - [ ] `LichLamViec` (`LLV_Ma`, `LLV_NhanVien`, `LLV_Ca`, `LLV_NgayLam`, `LLV_Thang`, `LLV_Nam`, `LLV_TrangThai`, `LLV_Xoa`).
  - [ ] `ChamCong` (`CC_Ma`, `CC_LichLamViec`, `CC_NhanVien`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `CC_NguoiDuyet`, `CC_Xoa`).
- [ ] **Nhóm bảng Bàn & Thực đơn (Món ăn / Nước uống):**
  - [ ] `Ban` (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_SoNguoiToiDa`, `B_TrangThai` [0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong], `B_Xoa`).
  - [ ] `DanhMuc` (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa`) — *Món ăn, Nước uống...*
  - [ ] `SanPham` / `MonAn` (`SP_Ma`, `SP_Ten`, `SP_MoTa`, `SP_DanhMuc`, `SP_GiaBan`, `SP_HetHang` [BIT: báo hết món], `SP_Xoa`).
- [ ] **Nhóm bảng Phục vụ, Đặt món (Order), Nhà bếp & Hóa đơn:**
  - [ ] `HoaDon` (`HD_Ma`, `HD_MaBan`, `HD_NhanVienPhucVu`, `HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_ThoiGianThanhToan`, `HD_TongTien`, `HD_TrangThai` [0: Đang phục vụ, 1: Đã thanh toán, 2: Đã gộp/hủy], `HD_Xoa`).
  - [ ] `ChiTietHoaDon` (`CTHD_Ma`, `CTHD_MaHoaDon`, `CTHD_MaSanPham`, `CTHD_SoLuong`, `CTHD_DonGia`, `CTHD_GhiChu`, `CTHD_ThoiGianGoi`, `CTHD_TrangThaiMon` [0: Chờ thực hiện, 1: Đã nấu xong, 2: Đã mang ra, 3: Đã hủy], `CTHD_Xoa`).

### 2.2. Nạp dữ liệu mẫu (Seed Data) & Kiểm thử Docker
- [ ] Viết dữ liệu mẫu (`INSERT INTO`) cho 4 tài khoản đại diện 4 vai trò (mật khẩu `123456`), danh sách bàn, thực đơn món ăn/nước uống, ca làm việc, lịch làm việc và một vài hóa đơn mẫu để test báo cáo.
- [ ] Build Docker image và chạy container từ `docker-data-server`.
- [ ] Kiểm tra kết nối tới `localhost,1433` và xác nhận tất cả các bảng được tạo thành công không lỗi.

---

## GIAI ĐOẠN 3: PHÁT TRIỂN ỨNG DỤNG VB.NET WINFORMS (Development)

### 3.1. Khởi tạo Solution & Lớp nền tảng (Core / Infrastructure)
- [ ] Tạo Solution VB.NET Windows Forms App (`QuanLyQuanAn`).
- [ ] Xây dựng lớp `DatabaseAccess` / `KetNoiCSDL` (Quản lý `SqlConnection`, thực thi truy vấn `ExecuteQuery`, `ExecuteNonQuery`, `ExecuteScalar`).
- [ ] Xây dựng hàm tiện ích mã hóa mật khẩu `MD5` và quản lý phiên đăng nhập (`Session`: lưu thông tin người dùng hiện tại và danh sách quyền `Q_Tag`).
- [ ] Xây dựng cơ chế kiểm tra phân quyền tự động theo `Tag` của Menu/Button trên Form.

### 3.2. Phân hệ Chung (Hệ thống & Cá nhân)
- [ ] **Màn hình Đăng nhập (`frmDangNhap`):** Đăng nhập, kiểm tra tài khoản, tải quyền theo vai trò.
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
