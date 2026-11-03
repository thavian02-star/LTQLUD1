# Danh sách đầy đủ 18 bảng trong đồ án Quản lý Quán ăn (Giai đoạn 2 - Mục 2.1):

## Nhóm 1: Phân quyền & Tài khoản (RBAC)
1. **TaiKhoan**: Quản lý tài khoản đăng nhập hệ thống (`TK_Ma`, `TK_TenDangNhap`, `TK_MatKhau`, `TK_Xoa`).
2. **VaiTro**: Quản lý các nhóm vai trò người dùng (`VT_Ma`, `VT_Ten`, `VT_Xoa` - *Chủ quán, Quản lý, Phục vụ, Nhà bếp*).
3. **Quyen**: Quản lý quyền chức năng (`Q_Ma`, `Q_Ten`, `Q_Tag`, `Q_Xoa` - ánh xạ `Q_Tag` vào `Tag` của Control trên WinForms).
4. **TaiKhoan_VaiTro**: Bảng trung gian gán vai trò cho tài khoản (`TKVT_Ma`, `TKVT_TaiKhoan`, `TKVT_VaiTro`, `TKVT_Xoa`).
5. **VaiTro_Quyen**: Bảng trung gian phân quyền chi tiết cho từng vai trò (`VTQ_Ma`, `VTQ_VaiTro`, `VTQ_Quyen`, `VTQ_Xoa`).

## Nhóm 2: Nhân sự & Tuyển dụng
6. **NhanVien**: Quản lý hồ sơ nhân sự (`NV_Ma`, `NV_HoTen`, `NV_GioiTinh`, `NV_NgaySinh`, `NV_ViTri`, `NV_DienThoai`, `NV_DiaChi`, `NV_CMND`, `NV_NgayBatDauLam`, `NV_MaTaiKhoan`, `NV_TrangThai`, `NV_Xoa`).
7. **TrinhDoViTinh**: Danh mục kỹ năng vi tính có thể thay đổi (`TDVT_Ma`, `TDVT_Ten`, `TDVT_Xoa` - *Word, Excel, Cài phần mềm, Khác*).
8. **NhanVien_ViTinh**: Bảng trung gian lưu nhiều trình độ vi tính của nhân viên (`ID`, `NV_Ma`, `TDVT_Ma`).
9. **DungCuTrangPhuc**: Danh mục dụng cụ/trang phục của quán (`DC_Ma`, `DC_Ten`, `DC_SoLuongTong`, `DC_GhiChu`, `DC_Xoa`).
10. **NhanVien_DungCu**: Quản lý cấp phát và thu hồi trang phục khi nhân viên nghỉ việc (`MP_Ma`, `NV_Ma`, `DC_Ma`, `SoLuong`, `NgayNhan`, `DaTra`, `NgayTra`, `GhiChu`).

## Nhóm 3: Ca làm việc, Xếp lịch & Chấm công
11. **CaLamViec**: Cấu hình danh sách ca, khung giờ và đơn giá lương ca (`CA_Ma`, `CA_Ten`, `CA_GioBatDau`, `CA_GioKetThuc`, `CA_LuongMoiCa`, `CA_Xoa`).
12. **LichLamViec**: Quản lý lịch làm việc theo ngày/tuần/tháng của nhân viên (`LLV_Ma`, `LLV_MaNV`, `LLV_MaCa`, `LLV_NgayLam`, `LLV_TrangThai`, `LLV_Xoa`).
13. **ChamCong**: Ghi nhận giờ bắt đầu/kết thúc làm và trạng thái Quản lý duyệt chấm công (`CC_Ma`, `CC_MaLich`, `CC_MaNV`, `CC_GioBatDau`, `CC_GioKetThuc`, `CC_DaDuyet`, `CC_Xoa`).

## Nhóm 4: Bàn ăn & Thực đơn
14. **Ban**: Quản lý tổ chức bàn ghế, khu vực và trạng thái bàn (`B_Ma`, `B_SoThuTu`, `B_TenBan`, `B_KhuVuc`, `B_SoNguoiToiDa`, `B_TrangThai`, `B_Xoa`).
15. **DanhMuc**: Phân loại danh mục món ăn/nước uống (`DM_Ma`, `DM_Ten`, `DM_MoTa`, `DM_Xoa`).
16. **MonAn**: Quản lý thông tin món ăn/nước uống và báo hết món (`MA_Ma`, `MA_Ten`, `MA_DanhMuc`, `MA_DonGia`, `MA_HetMon`, `MA_MoTa`, `MA_Xoa`).

## Nhóm 5: Phục vụ, Gọi món & Hóa đơn
17. **HoaDon**: Quản lý phiên phục vụ tại bàn, ca làm việc, chuyển bàn, gộp bàn, thanh toán (`HD_Ma`, `HD_MaBan`, `HD_MaNVPhucVu`, `HD_MaCa`, `HD_MaHoaDonGop`, `HD_SoLuongKhach`, `HD_ThoiGianVao`, `HD_ThoiGianThanhToan`, `HD_TongTien`, `HD_TrangThai`, `HD_Xoa`).
18. **ChiTietHoaDon**: Chi tiết từng lần gọi món, ghi chú, thứ tự thời gian chuyển xuống bếp và trạng thái món (`CTHD_Ma`, `CTHD_MaHoaDon`, `CTHD_MaMonAn`, `CTHD_SoLuong`, `CTHD_DonGia`, `CTHD_GhiChu`, `CTHD_ThoiGianGoi`, `CTHD_TrangThaiMon`, `CTHD_Xoa`).
