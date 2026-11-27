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
- [x] **Nhóm bảng Bàn ăn & Thực đơn Nền tảng:**
  - [x] `KhuVuc` (`KV_Ma`, `KV_Ten`, `KV_MoTa`, `KV_Xoa`).
  - [x] `Ban` (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_KhuVuc`, `B_SoNguoiToiDa`, `B_TrangThai`, `B_Xoa`).
  - [x] `DanhMuc` (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa`).
  - [x] `MonAn` (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon`, `MA_MoTa`, `MA_Xoa`).
- [x] **Nhóm bảng Mở rộng Chuỗi Chi Nhánh & Bảng Thực Đơn:**
  - [x] `ChiNhanh` (`CN_Ma`, `CN_Ten`, `CN_DiaChi`, `CN_SoDienThoai`, `CN_NguoiQuanLy`, `CN_TrangThai`, `CN_Xoa`).
  - [x] `Menu` (`MN_Ma`, `MN_Ten`, `MN_LoaiMenu`, `MN_MoTa`, `MN_TrangThai`, `MN_Xoa`).
  - [x] `Menu_MonAn` (`MMA_Ma`, `MMA_MaMenu`, `MMA_MaMonAn`, `MMA_DonGia`, `MMA_ThuTuHienThi`, `MMA_Xoa`).
  - [x] `ChiNhanh_Menu` (`CNM_Ma`, `CNM_MaChiNhanh`, `CNM_MaMenu`, `CNM_NgayBatDau`, `CNM_NgayKetThuc`, `CNM_TrangThai`, `CNM_Xoa`).
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
- [x] **Màn hình Chính (`frmMain`):** Thanh điều hướng (Menu/Sidebar) hiển thị các chức năng được phép truy cập theo vai trò (đã nghiệm thu 64/64 test cases RBAC).
- [x] **Màn hình Đổi mật khẩu (`frmDoiMatKhau`):** Xác nhận mật khẩu cũ và cập nhật mật khẩu mới (băm MD5) — Đã nghiệm thu 48/48 test cases trên 4 vai trò.
- [ ] **Màn hình Cá nhân & Chấm công (`frmChamCongCaNhan`):**
  - [ ] Xem lịch làm việc của bản thân theo tuần.
  - [ ] Nút **Bắt đầu làm** (Check-in) và **Kết thúc làm** (Check-out) cho ca hiện tại.

### 3.3. Phân hệ Nhân viên phục vụ (Bán hàng & Quản lý bàn) — `[x] HOÀN TẤT (v0.3.0)`
- [x] **Màn hình Sơ đồ bàn & Phục vụ (`frmSoDoBan`):** *(Đã hoàn thành 32/32 test cases tại [`report_0_3_0.html`](release_report/report_0_3_0.html))*
  - [x] Hiển thị danh sách bàn trực quan (màu sắc theo trạng thái: *Trống, Đang phục vụ, Đã đặt trước*).
  - [x] Lọc theo từng khu vực: Sảnh chính tầng 1, Sân vườn tầng 2, Phòng VIP máy lạnh.
- [x] **Chức năng Mở bàn & Gọi món / Đặt món:**
  - [x] Chọn bàn trống -> Tạo hóa đơn (`HoaDon`) -> Chọn món ăn/nước uống, số lượng, đơn giá, ghi chú.
  - [x] Đẩy danh sách món xuống hàng đợi bếp (`ChiTietHoaDon`).
- [x] **Chức năng Thêm món / Hủy món:**
  - [x] Khách gọi thêm món nhiều lần trên cùng bàn.
  - [x] Chỉ cho phép **Hủy món** khi món ở trạng thái *Chờ thực hiện* (`CTHD_TrangThaiMon = 0`).
- [x] **Chức năng Chuyển bàn:**
  - [x] **Chuyển bàn:** Chuyển hóa đơn đang phục vụ từ bàn A sang bàn B (đang trống), tự động hoàn trả bàn cũ về trống.
- [x] **Chức năng Tính tiền & Thanh toán (`frmThanhToan` / `frmSoDoBan`):**
  - [x] Cộng tổng tiền các món hợp lệ (không tính món đã hủy).
  - [x] Cập nhật trạng thái hóa đơn *Đã thanh toán* (`HD_TrangThai = 1`) và đổi trạng thái bàn về *Trống*.

### 3.4. Phân hệ Nhà bếp / Pha chế — `[x] HOÀN TẤT (v0.3.1)`
- [x] **Màn hình Hàng đợi Nhà bếp (`frmNhaBep`):** *(Đã hoàn thành 19/19 test cases tại [`report_0_3_1.html`](release_report/report_0_3_1.html))*
  - [x] Hiển thị danh sách các món ăn/nước uống đang ở trạng thái *Chờ thực hiện* sắp xếp theo thứ tự thời gian đặt (`CTHD_ThoiGianGoi ASC` - FIFO).
  - [x] Hiển thị rõ: Số bàn, Tên món, Số lượng, Ghi chú của khách, Thời gian đặt, cảnh báo món trễ quá 15 phút.
  - [x] Nút **Báo đã nấu xong**: Cập nhật trạng thái món sang *Đã nấu xong* (`CTHD_TrangThaiMon = 1`) và tự động đồng bộ sang phục vụ bàn.

### 3.5. Phân hệ Quản lý & Chủ quán (Hệ thống 9 Màn hình Danh mục & Quản trị Chuỗi)
> 📌 **Lưu ý đồng bộ tiến độ:** Hệ thống 9 màn hình danh mục nền tảng (Master Data) được quản lý tập trung và chi tiết tại [`docs/CHECKLIST_UU_TIEN_DANH_MUC.md`](CHECKLIST_UU_TIEN_DANH_MUC.md). Khi hoàn thành từng màn hình tại checklist danh mục, các mục tương ứng bên dưới sẽ được tự động đánh dấu `[x]` hoàn thành.
- [x] **Quản lý Nhân sự (`frmNhanVien` — MH 6 / 9):** *(Đã hoàn thành 31/31 test cases tại [`report_0_2_8.html`](release_report/report_0_2_8.html))*
  - [x] Thêm / Sửa nhân viên: Họ tên, giới tính, ngày sinh, vị trí làm việc (Phục vụ, Pha chế, Bếp, Quản lý), SĐT, địa chỉ, CCCD, ngày vào làm.
  - [x] Chọn nhiều **Trình độ vi tính** (Word, Excel, Cài phần mềm, Khác) và cập nhật bảng `NhanVien_ViTinh`.
  - [x] Quản lý **Dụng cụ / Trang phục** cấp phát cho nhân viên (`NhanVien_DungCu`).
  - [x] Nghiệp vụ **Nhân viên nghỉ việc**: Đổi trạng thái, tự động hoàn tất thu hồi trang phục/dụng cụ, khôi phục làm việc.
- [x] **Quản lý Bàn ghế & Khu vực (`frmKhuVuc`, `frmBan` — MH 4 & MH 5 / 9):** *(Đã hoàn thành trọn vẹn cả 2 màn hình)*
  - [x] Quản lý Khu vực bàn (`frmKhuVuc`): Tầng trệt, Tầng 1, Phòng VIP, Sân vườn... *(Đã hoàn thành 24/24 test cases tại [`report_0_2_6.html`](release_report/report_0_2_6.html))*
  - [x] Tổ chức bàn ghế (`frmBan`): Thêm / Sửa / Xóa bàn, gán khu vực, số thứ tự, số người tối đa *(Đã hoàn thành 26/26 test cases tại [`report_0_2_7.html`](release_report/report_0_2_7.html))*.
- [x] **Quản lý Thực đơn Nền tảng (`frmDanhMuc`, `frmMonAn` — MH 1 & MH 2 / 9):** *(Đã hoàn thành cả 2 màn hình)*
  - [x] Quản lý Danh mục món (`frmDanhMuc`): Thêm / Sửa / Xóa nhóm thực đơn *(Đã hoàn thành 24/24 test cases tại [`report_0_2_3.html`](release_report/report_0_2_3.html))*.
  - [x] Quản lý Món ăn & Thức uống (`frmMonAn`): Khởi tạo/chỉnh sửa món ăn, nước uống (tên, danh mục, giá bán, mô tả, đánh dấu còn/hết món) *(Đã hoàn thành 28/28 test cases tại [`report_0_2_4.html`](release_report/report_0_2_4.html))*.
- [x] **Quản lý Bảng Thực Đơn Bán Hàng (`frmMenu` — MH 7 / 9):** *(Đã hoàn thành 54/54 test cases tại [`report_0_2_9.html`](release_report/report_0_2_9.html))*
  - [x] Tạo & quản lý các gói thực đơn kinh doanh (Alacarte ngày, Buffet trưa, Set tiệc lễ tết...).
  - [x] Gán danh sách món ăn từ kho `MonAn` vào `Menu_MonAn` kèm đơn giá niêm yết theo menu.
- [x] **Quản lý Chi Nhánh & Menu Chi Nhánh (`frmChiNhanh`, `frmMenuChiNhanh` — MH 8 & MH 9 / 9):**
  - [x] Quản lý danh mục Chi nhánh chuỗi nhà hàng (`frmChiNhanh`): Tên, địa chỉ, hotline, người quản lý cơ sở *(Đã hoàn thành 39/39 test cases tại [`report_0_2_10.html`](release_report/report_0_2_10.html))*.
  - [x] Phân bổ bảng thực đơn theo chi nhánh (`frmMenuChiNhanh`): Thiết lập chi nhánh nào bán menu nào, giá bán áp dụng theo khu vực chi nhánh, bật/tắt phục vụ món tại chỗ *(Đã hoàn thành 44/44 test cases tại [`report_0_2_11.html`](release_report/report_0_2_11.html))*.
- [ ] **Quản lý Lịch làm việc & Chấm công (`frmQuanLyLichLamViec`, `frmDuyetChamCong`):**
  - [x] Hiển thị & cấu hình danh sách ca và khung giờ làm việc (`frmCaLamViec` — *Đã hoàn thành 24/24 test cases tại [`CHECKLIST_UU_TIEN_DANH_MUC.md`](CHECKLIST_UU_TIEN_DANH_MUC.md) — MH 3 & [`report_0_2_5.html`](release_report/report_0_2_5.html)*).
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
