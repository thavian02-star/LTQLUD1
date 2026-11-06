-- ==============================================================
-- DỮ LIỆU MẪU THỰC TẾ (SEED DATA): HỆ THỐNG QUẢN LÝ QUÁN ĂN
-- Tên mô hình quán: Quán Ăn Gia Đình Hương Việt (TP. Hồ Chí Minh)
-- Hệ quản trị: Microsoft SQL Server 2022 Express (Docker)
-- Thiết kế theo: GIAI ĐOẠN 2 - Mục 2.2 (Nạp dữ liệu mẫu cho 18 bảng)
-- ==============================================================
-- CƠ CHẾ CHỐNG TRÙNG LẶP TUYỆT ĐỐI (IDEMPOTENT / NO DUPLICATES):
-- 1. Mỗi bảng đều được bảo vệ bởi khối `IF NOT EXISTS (SELECT 1 FROM TenBang)`.
-- 2. Sử dụng `SET IDENTITY_INSERT TenBang ON` với ID tường minh để đảm bảo
--    toàn bộ khóa ngoại (Foreign Keys) giữa 18 bảng khớp chính xác 100%.
-- 3. Nếu bảng đã có dữ liệu (do chạy lần trước hoặc người dùng đã thao tác),
--    khối INSERT của bảng đó sẽ tự động được bỏ qua, KHÔNG BAO GIỜ bị nhân đôi!
-- ==============================================================

USE [QuanLyQuanAnDB];
GO

SET NOCOUNT ON;
GO

-- ==============================================================
-- NHÓM 1: DỮ LIỆU PHÂN QUYỀN & TÀI KHOẢN (RBAC - 5 BẢNG)
-- Mật khẩu mặc định của tất cả tài khoản: 123456
-- Chuỗi MD5 chuẩn của '123456': e10adc3949ba59abbe56e057f20f883e
-- ==============================================================

-- 1.1. Bảng VaiTro (4 vai trò chuẩn trong quán ăn)
IF NOT EXISTS (SELECT 1 FROM VaiTro)
BEGIN
    SET IDENTITY_INSERT VaiTro ON;
    INSERT INTO VaiTro (VT_Ma, VT_Ten, VT_Xoa) VALUES
        (1, N'Chủ quán', 0),
        (2, N'Quản lý', 0),
        (3, N'Nhân viên phục vụ', 0),
        (4, N'Nhà bếp / Pha chế', 0);
    SET IDENTITY_INSERT VaiTro OFF;
END
GO

-- 1.2. Bảng TaiKhoan (6 tài khoản thực tế tương ứng với 6 nhân sự của quán)
IF NOT EXISTS (SELECT 1 FROM TaiKhoan)
BEGIN
    SET IDENTITY_INSERT TaiKhoan ON;
    INSERT INTO TaiKhoan (TK_Ma, TK_TenDangNhap, TK_MatKhau, TK_Xoa) VALUES
        (1, N'chuquan',  N'e10adc3949ba59abbe56e057f20f883e', 0),
        (2, N'quanly',   N'e10adc3949ba59abbe56e057f20f883e', 0),
        (3, N'phucvu1',  N'e10adc3949ba59abbe56e057f20f883e', 0),
        (4, N'phucvu2',  N'e10adc3949ba59abbe56e057f20f883e', 0),
        (5, N'nhabep1',  N'e10adc3949ba59abbe56e057f20f883e', 0),
        (6, N'phache1',  N'e10adc3949ba59abbe56e057f20f883e', 0);
    SET IDENTITY_INSERT TaiKhoan OFF;
END
GO

-- 1.3. Bảng Quyen (Danh mục quyền gắn với thuộc tính Tag của Menu/Button trên WinForms)
IF NOT EXISTS (SELECT 1 FROM Quyen)
BEGIN
    SET IDENTITY_INSERT Quyen ON;
    INSERT INTO Quyen (Q_Ma, Q_Ten, Q_Tag, Q_Xoa) VALUES
        (1,  N'Sơ đồ bàn & Gọi món tại bàn',               N'POS_SO_DO_BAN', 0),
        (2,  N'Chuyển bàn & Gộp bàn',                      N'POS_CHUYEN_GOP_BAN', 0),
        (3,  N'Tính tiền & In hóa đơn',                    N'POS_THANH_TOAN', 0),
        (4,  N'Xem lịch cá nhân & Chấm công vào/ra ca',    N'CA_NHAN_CHAM_CONG', 0),
        (5,  N'Màn hình hàng đợi Nhà bếp & Báo xong món',  N'BEP_HANG_DOI_MON', 0),
        (6,  N'Duyệt chấm công nhân viên',                 N'QL_DUYET_CHAM_CONG', 0),
        (7,  N'Quản lý hồ sơ nhân sự & Tuyển dụng',        N'CQ_QUAN_LY_NHAN_VIEN', 0),
        (8,  N'Quản lý sơ đồ bàn ghế & Khu vực',           N'CQ_QUAN_LY_BAN', 0),
        (9,  N'Quản lý danh mục & Thực đơn món ăn',        N'CQ_QUAN_LY_THUC_DON', 0),
        (10, N'Xếp lịch & Phân công ca làm việc',          N'CQ_XEP_LICH_LAM_VIEC', 0),
        (11, N'Xem 6 báo cáo doanh thu & Thống kê lương',  N'CQ_BAO_CAO_THONG_KE', 0),
        (12, N'Quản trị phân quyền & Sao lưu CSDL',        N'CQ_HE_THONG_PHAN_QUYEN', 0);
    SET IDENTITY_INSERT Quyen OFF;
END
GO

-- 1.4. Bảng TaiKhoan_VaiTro (Gán vai trò cho từng tài khoản)
IF NOT EXISTS (SELECT 1 FROM TaiKhoan_VaiTro)
BEGIN
    SET IDENTITY_INSERT TaiKhoan_VaiTro ON;
    INSERT INTO TaiKhoan_VaiTro (TKVT_Ma, TKVT_TaiKhoan, TKVT_VaiTro, TKVT_Xoa) VALUES
        (1, 1, 1, 0), -- chuquan -> Chủ quán
        (2, 2, 2, 0), -- quanly  -> Quản lý
        (3, 3, 3, 0), -- phucvu1 -> Nhân viên phục vụ
        (4, 4, 3, 0), -- phucvu2 -> Nhân viên phục vụ
        (5, 5, 4, 0), -- nhabep1 -> Nhà bếp / Pha chế
        (6, 6, 4, 0); -- phache1 -> Nhà bếp / Pha chế
    SET IDENTITY_INSERT TaiKhoan_VaiTro OFF;
END
GO

-- 1.5. Bảng VaiTro_Quyen (Phân quyền chi tiết theo đúng đặc tả đề bài PDF)
IF NOT EXISTS (SELECT 1 FROM VaiTro_Quyen)
BEGIN
    SET IDENTITY_INSERT VaiTro_Quyen ON;
    INSERT INTO VaiTro_Quyen (VTQ_Ma, VTQ_VaiTro, VTQ_Quyen, VTQ_Xoa) VALUES
        -- Chủ quán (Toàn quyền 1 -> 12)
        (1,  1, 1, 0), (2,  1, 2, 0), (3,  1, 3, 0), (4,  1, 4, 0),
        (5,  1, 5, 0), (6,  1, 6, 0), (7,  1, 7, 0), (8,  1, 8, 0),
        (9,  1, 9, 0), (10, 1, 10, 0), (11, 1, 11, 0), (12, 1, 12, 0),
        -- Quản lý (Các chức năng của phục vụ + Duyệt chấm công + Xem/Xếp lịch)
        (13, 2, 1, 0), (14, 2, 2, 0), (15, 2, 3, 0), (16, 2, 4, 0),
        (17, 2, 6, 0), (18, 2, 10, 0),
        -- Nhân viên phục vụ (Bán hàng tại bàn, Chuyển/Gộp bàn, Thanh toán, Chấm công cá nhân)
        (19, 3, 1, 0), (20, 3, 2, 0), (21, 3, 3, 0), (22, 3, 4, 0),
        -- Nhà bếp / Pha chế (Hàng đợi món chờ chế biến + Xem lịch & Chấm công cá nhân)
        (23, 4, 4, 0), (24, 4, 5, 0);
    SET IDENTITY_INSERT VaiTro_Quyen OFF;
END
GO

-- ==============================================================
-- NHÓM 2: DỮ LIỆU NHÂN SỰ & TUYỂN DỤNG (5 BẢNG)
-- ==============================================================

-- 2.1. Bảng NhanVien (7 nhân sự thực tế: 6 đang làm việc + 1 đã nghỉ việc để test thu hồi đồng phục)
IF NOT EXISTS (SELECT 1 FROM NhanVien)
BEGIN
    SET IDENTITY_INSERT NhanVien ON;
    INSERT INTO NhanVien (
        NV_Ma, NV_HoTen, NV_GioiTinh, NV_NgaySinh, NV_ViTri,
        NV_CMND, NV_DienThoai, NV_Email, NV_DiaChi,
        NV_TrinhDoHocVan, NV_NgoaiNgu, NV_NgayBatDauLam, NV_NgayThoiViec,
        NV_MaTaiKhoan, NV_TrangThai, NV_Xoa
    ) VALUES
        (1, N'Nguyễn Hoàng Nam', 1, '1985-04-12', N'Chủ quán',
         N'079085001234', N'0903112233', N'nam.nguyen@huongviet.vn', N'128 Nguyễn Thị Minh Khai, Quận 3, TP.HCM',
         N'Đại học Kinh tế', N'Tiếng Anh giao tiếp', '2023-01-01', NULL,
         1, N'Đang làm việc', 0),

        (2, N'Trần Thị Thu Thảo', 0, '1993-08-25', N'Quản lý',
         N'079193004567', N'0908445566', N'thao.tran@huongviet.vn', N'45 Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM',
         N'Cao đẳng Quản trị Nhà hàng', N'Tiếng Anh (TOEIC 650)', '2023-02-15', NULL,
         2, N'Đang làm việc', 0),

        (3, N'Lê Minh Tuấn', 1, '2002-11-05', N'Phục vụ',
         N'079202007891', N'0912334455', N'tuan.le@gmail.com', N'210 Cách Mạng Tháng 8, Quận 10, TP.HCM',
         N'Lớp 12/12', N'Tiếng Anh cơ bản', '2024-03-10', NULL,
         3, N'Đang làm việc', 0),

        (4, N'Phạm Ngọc Ánh', 0, '2003-05-19', N'Phục vụ',
         N'079303009876', N'0937667788', N'anh.pham03@gmail.com', N'88 Hoàng Hoa Thám, Quận Bình Thạnh, TP.HCM',
         N'Sinh viên Đại học (Bán thời gian)', N'Tiếng Anh, Tiếng Hàn cơ bản', '2024-06-01', NULL,
         4, N'Đang làm việc', 0),

        (5, N'Võ Văn Hùng', 1, '1990-02-14', N'Đầu bếp chính',
         N'079090003456', N'0979112299', N'hung.bep@huongviet.vn', N'15 Âu Cơ, Quận Tân Bình, TP.HCM',
         N'Trung cấp Kỹ thuật Chế biến Món ăn', N'Không', '2023-01-10', NULL,
         5, N'Đang làm việc', 0),

        (6, N'Đặng Quốc Bảo', 1, '2001-09-30', N'Pha chế',
         N'079201006543', N'0984556677', N'bao.barista@gmail.com', N'302 Nguyễn Văn Đậu, Quận Bình Thạnh, TP.HCM',
         N'Chứng chỉ Pha chế tổng hợp', N'Tiếng Anh cơ bản', '2024-04-20', NULL,
         6, N'Đang làm việc', 0),

        (7, N'Hoàng Gia Huy', 1, '2003-12-01', N'Phục vụ',
         N'079203001122', N'0965889900', N'huy.hoang@gmail.com', N'52 Thành Thái, Quận 10, TP.HCM',
         N'Lớp 12/12', N'Không', '2024-01-15', '2024-09-30',
         NULL, N'Đã nghỉ việc', 0);
    SET IDENTITY_INSERT NhanVien OFF;
END
GO

-- 2.2. Bảng TrinhDoViTinh (4 kỹ năng vi tính chuẩn theo đề bài PDF)
IF NOT EXISTS (SELECT 1 FROM TrinhDoViTinh)
BEGIN
    SET IDENTITY_INSERT TrinhDoViTinh ON;
    INSERT INTO TrinhDoViTinh (TDVT_Ma, TDVT_Ten, TDVT_Xoa) VALUES
        (1, N'Microsoft Word (Soạn thảo văn bản)', 0),
        (2, N'Microsoft Excel (Bảng tính & Thống kê)', 0),
        (3, N'Cài đặt & Sử dụng phần mềm POS bán hàng', 0),
        (4, N'Khác (Thiết kế Canva, Quản lý Fanpage)', 0);
    SET IDENTITY_INSERT TrinhDoViTinh OFF;
END
GO

-- 2.3. Bảng NhanVien_ViTinh (Gán kỹ năng vi tính thực tế cho từng nhân viên)
IF NOT EXISTS (SELECT 1 FROM NhanVien_ViTinh)
BEGIN
    SET IDENTITY_INSERT NhanVien_ViTinh ON;
    INSERT INTO NhanVien_ViTinh (ID, NV_Ma, TDVT_Ma) VALUES
        (1,  1, 1), (2,  1, 2), (3,  1, 3), (4,  1, 4), -- Chủ quán Nam: thành thạo cả 4 kỹ năng
        (5,  2, 1), (6,  2, 2), (7,  2, 3),             -- Quản lý Thảo: Word, Excel, POS
        (8,  3, 1), (9,  3, 3),                         -- Phục vụ Tuấn: Word, POS
        (10, 4, 1), (11, 4, 2), (12, 4, 3),             -- Phục vụ Ánh: Word, Excel, POS
        (13, 5, 3),                                     -- Đầu bếp Hùng: Sử dụng màn hình POS Nhà bếp
        (14, 6, 3);                                     -- Pha chế Bảo: Sử dụng màn hình POS Pha chế
    SET IDENTITY_INSERT NhanVien_ViTinh OFF;
END
GO

-- 2.4. Bảng DungCuTrangPhuc (Danh mục đồng phục & công cụ làm việc thực tế tại quán)
IF NOT EXISTS (SELECT 1 FROM DungCuTrangPhuc)
BEGIN
    SET IDENTITY_INSERT DungCuTrangPhuc ON;
    INSERT INTO DungCuTrangPhuc (DC_Ma, DC_Ten, DC_SoLuongTong, DC_GhiChu, DC_Xoa) VALUES
        (1, N'Áo thun đồng phục Hương Việt (Màu đỏ đô)', 30, N'Cấp 2 áo/nhân viên phục vụ & quản lý', 0),
        (2, N'Tạp dề ngắn nửa thân (Phục vụ & Pha chế)', 20, N'Màu đen có thêu logo quán', 0),
        (3, N'Áo bếp chuyên dụng dài tay (Màu trắng)',    10, N'Vải kaki dày chống nóng cho bộ phận bếp', 0),
        (4, N'Nón lưới trùm tóc vệ sinh ATTP',           25, N'Bắt buộc đội khi chế biến trong bếp', 0),
        (5, N'Bảng tên nhân viên cài áo (Nam châm)',     25, N'In tên và chức vụ từng nhân sự', 0);
    SET IDENTITY_INSERT DungCuTrangPhuc OFF;
END
GO

-- 2.5. Bảng NhanVien_DungCu (Lịch sử cấp phát đồng phục & thu hồi khi nghỉ việc)
IF NOT EXISTS (SELECT 1 FROM NhanVien_DungCu)
BEGIN
    SET IDENTITY_INSERT NhanVien_DungCu ON;
    INSERT INTO NhanVien_DungCu (MP_Ma, NV_Ma, DC_Ma, SoLuong, NgayNhan, DaTra, NgayTra, GhiChu) VALUES
        (1, 2, 1, 2, '2023-02-15', 0, NULL,         N'Cấp 2 áo size M cho Quản lý Thảo'),
        (2, 2, 5, 1, '2023-02-15', 0, NULL,         N'Bảng tên Quản lý'),
        (3, 3, 1, 2, '2024-03-10', 0, NULL,         N'Cấp 2 áo size L cho Phục vụ Tuấn'),
        (4, 3, 2, 1, '2024-03-10', 0, NULL,         N'Cấp 1 tạp dề phục vụ'),
        (5, 3, 5, 1, '2024-03-10', 0, NULL,         N'Bảng tên Nhân viên phục vụ'),
        (6, 4, 1, 2, '2024-06-01', 0, NULL,         N'Cấp 2 áo size S cho Phục vụ Ánh'),
        (7, 4, 2, 1, '2024-06-01', 0, NULL,         N'Cấp 1 tạp dề phục vụ'),
        (8, 5, 3, 2, '2023-01-10', 0, NULL,         N'Cấp 2 áo bếp trưởng size XL'),
        (9, 5, 4, 2, '2023-01-10', 0, NULL,         N'Cấp 2 nón bếp'),
        (10, 6, 1, 2, '2024-04-20', 0, NULL,        N'Cấp 2 áo size M cho Pha chế Bảo'),
        (11, 6, 2, 1, '2024-04-20', 0, NULL,        N'Cấp 1 tạp dề pha chế'),
        (12, 7, 1, 2, '2024-01-15', 1, '2024-09-30', N'Đã thu hồi đủ 2 áo khi nhân viên Huy nghỉ việc');
    SET IDENTITY_INSERT NhanVien_DungCu OFF;
END
GO

-- ==============================================================
-- NHÓM 3: DỮ LIỆU CA LÀM VIỆC, XẾP LỊCH & CHẤM CÔNG (3 BẢNG)
-- ==============================================================

-- 3.1. Bảng CaLamViec (Cố định 2 ca làm việc chính trong ngày)
IF NOT EXISTS (SELECT 1 FROM CaLamViec)
BEGIN
    SET IDENTITY_INSERT CaLamViec ON;
    INSERT INTO CaLamViec (CA_Ma, CA_Ten, CA_GioBatDau, CA_GioKetThuc, CA_LuongMoiCa, CA_Xoa) VALUES
        (1, N'Ca 1 (Ca Sáng)',      '08:00:00', '15:00:00', 180000, 0),
        (2, N'Ca 2 (Ca Chiều Tối)', '15:00:00', '22:00:00', 210000, 0);
    SET IDENTITY_INSERT CaLamViec OFF;
END
GO

-- 3.2. Bảng LichLamViec (Lịch phân công trực tiếp bởi Quản lý cho hôm qua & hôm nay)
IF NOT EXISTS (SELECT 1 FROM LichLamViec)
BEGIN
    DECLARE @HomQua DATE = CAST(DATEADD(DAY, -1, GETDATE()) AS DATE);
    DECLARE @HomNay DATE = CAST(GETDATE() AS DATE);

    SET IDENTITY_INSERT LichLamViec ON;
    INSERT INTO LichLamViec (LLV_Ma, LLV_MaNV, LLV_MaCa, LLV_NgayLam, LLV_TrangThai, LLV_Xoa) VALUES
        -- Lịch ngày hôm qua (Ca Sáng & Ca Chiều Tối)
        (1, 2, 1, @HomQua, N'Hoàn thành', 0), -- Quản lý Thảo trực Ca Sáng hôm qua
        (2, 3, 1, @HomQua, N'Hoàn thành', 0), -- Phục vụ Tuấn làm Ca Sáng hôm qua
        (3, 5, 1, @HomQua, N'Hoàn thành', 0), -- Đầu bếp Hùng làm Ca Sáng hôm qua
        (4, 4, 2, @HomQua, N'Hoàn thành', 0), -- Phục vụ Ánh làm Ca Chiều Tối hôm qua
        (5, 6, 2, @HomQua, N'Hoàn thành', 0), -- Pha chế Bảo làm Ca Chiều Tối hôm qua
        -- Lịch ngày hôm nay (Ca Sáng & Ca Chiều Tối)
        (6, 2, 1, @HomNay, N'Đang làm việc', 0), -- Quản lý Thảo trực Ca Sáng hôm nay
        (7, 3, 1, @HomNay, N'Đang làm việc', 0), -- Phục vụ Tuấn làm Ca Sáng hôm nay
        (8, 5, 1, @HomNay, N'Đang làm việc', 0), -- Đầu bếp Hùng làm Ca Sáng hôm nay
        (9, 4, 2, @HomNay, N'Đã xếp lịch',   0), -- Phục vụ Ánh xếp lịch Ca Chiều Tối hôm nay
        (10, 6, 2, @HomNay, N'Đã xếp lịch',  0); -- Pha chế Bảo xếp lịch Ca Chiều Tối hôm nay
    SET IDENTITY_INSERT LichLamViec OFF;
END
GO

-- 3.3. Bảng ChamCong (Dữ liệu chấm công thực tế: có ca Quản lý đã duyệt và ca đang chờ duyệt)
IF NOT EXISTS (SELECT 1 FROM ChamCong)
BEGIN
    DECLARE @NgayHomQua DATETIME = CAST(CAST(DATEADD(DAY, -1, GETDATE()) AS DATE) AS DATETIME);
    DECLARE @NgayHomNay DATETIME = CAST(CAST(GETDATE() AS DATE) AS DATETIME);

    SET IDENTITY_INSERT ChamCong ON;
    INSERT INTO ChamCong (
        CC_Ma, CC_MaLich, CC_MaNV,
        CC_GioBatDau, CC_GioKetThuc,
        CC_DaDuyet, CC_NguoiDuyet, CC_ThoiGianDuyet, CC_Xoa
    ) VALUES
        -- Ca hôm qua: Đã được Quản lý Thảo (NV_Ma = 2) bấm duyệt để tính lương
        (1, 2, 3, DATEADD(MINUTE, 475, @NgayHomQua), DATEADD(MINUTE, 905, @NgayHomQua),  1, 2, DATEADD(MINUTE, 915, @NgayHomQua),  0), -- Tuấn: 07:55 -> 15:05 (Đã duyệt)
        (2, 3, 5, DATEADD(MINUTE, 470, @NgayHomQua), DATEADD(MINUTE, 900, @NgayHomQua),  1, 2, DATEADD(MINUTE, 915, @NgayHomQua),  0), -- Hùng: 07:50 -> 15:00 (Đã duyệt)
        (3, 4, 4, DATEADD(MINUTE, 895, @NgayHomQua), DATEADD(MINUTE, 1325, @NgayHomQua), 1, 2, DATEADD(MINUTE, 1330, @NgayHomQua), 0), -- Ánh:  14:55 -> 22:05 (Đã duyệt)
        (4, 5, 6, DATEADD(MINUTE, 898, @NgayHomQua), DATEADD(MINUTE, 1320, @NgayHomQua), 0, NULL, NULL, 0),                            -- Bảo:  14:58 -> 22:00 (Chờ Quản lý bấm duyệt)
        -- Ca sáng hôm nay: Nhân viên đã Check-in đầu ca
        (5, 7, 3, DATEADD(MINUTE, 478, @NgayHomNay), NULL, 0, NULL, NULL, 0), -- Tuấn đang trong ca làm việc hôm nay
        (6, 8, 5, DATEADD(MINUTE, 472, @NgayHomNay), NULL, 0, NULL, NULL, 0); -- Đầu bếp Hùng đang trong ca hôm nay
    SET IDENTITY_INSERT ChamCong OFF;
END
GO

-- ==============================================================
-- NHÓM 4: DỮ LIỆU BÀN ĂN & THỰC ĐƠN (4 BẢNG)
-- ==============================================================

-- 4.0. Bảng KhuVuc (4 khu vực chuẩn đồng bộ trực tiếp với các bàn trong bảng Ban)
IF NOT EXISTS (SELECT 1 FROM KhuVuc)
BEGIN
    SET IDENTITY_INSERT KhuVuc ON;
    INSERT INTO KhuVuc (KV_Ma, KV_Ten, KV_MoTa, KV_Xoa) VALUES
        (1, N'Tầng trệt',          N'Khu vực sảnh chính tầng trệt, không gian mở năng động, gần quầy thu ngân', 0),
        (2, N'Lầu 1 (Máy lạnh)',   N'Khu vực tầng 1 phòng lạnh mát mẻ, yên tĩnh, phù hợp gia đình & bạn bè', 0),
        (3, N'Phòng VIP Máy lạnh', N'Phòng riêng máy lạnh cao cấp dành cho tiệc riêng tư, hội họp đối tác', 0),
        (4, N'Sân vườn thoáng mát', N'Khu vực sân vườn ngoài trời nhiều cây xanh, thoáng mát tự nhiên ban đêm', 0);
    SET IDENTITY_INSERT KhuVuc OFF;
END
GO

-- 4.1. Bảng Ban (12 bàn chia theo 3 khu vực thực tế: Tầng trệt, Lầu 1 - Máy lạnh, Sân vườn)
IF NOT EXISTS (SELECT 1 FROM Ban)
BEGIN
    SET IDENTITY_INSERT Ban ON;
    INSERT INTO Ban (B_Ma, B_SoThuTu, B_TenBan, B_KhuVuc, B_SoNguoiToiDa, B_TrangThai, B_Xoa) VALUES
        (1,  1,  N'Bàn 01',          N'Tầng trệt',          2,  0, 0), -- Trống
        (2,  2,  N'Bàn 02',          N'Tầng trệt',          4,  2, 0), -- Đang đợi món (Hóa đơn số 5 đang phục vụ)
        (3,  3,  N'Bàn 03',          N'Tầng trệt',          4,  3, 0), -- Món đã xong (Hóa đơn số 6 chờ mang ra)
        (4,  4,  N'Bàn 04',          N'Tầng trệt',          4,  0, 0), -- Trống
        (5,  5,  N'Bàn 05',          N'Tầng trệt',          6,  0, 0), -- Trống
        (6,  6,  N'Bàn 06',          N'Lầu 1 (Máy lạnh)',   4,  0, 0), -- Trống
        (7,  7,  N'Bàn 07',          N'Lầu 1 (Máy lạnh)',   6,  0, 0), -- Trống
        (8,  8,  N'Bàn 08',          N'Lầu 1 (Máy lạnh)',   8,  0, 0), -- Trống
        (9,  9,  N'Bàn 09 (VIP 1)',  N'Phòng VIP Máy lạnh', 10, 0, 0), -- Trống
        (10, 10, N'Bàn 10 (VIP 2)',  N'Phòng VIP Máy lạnh', 12, 0, 0), -- Trống
        (11, 11, N'Bàn 11',          N'Sân vườn thoáng mát', 4, 0, 0), -- Trống
        (12, 12, N'Bàn 12',          N'Sân vườn thoáng mát', 8, 0, 0); -- Trống
    SET IDENTITY_INSERT Ban OFF;
END
GO

-- 4.2. Bảng DanhMuc (5 nhóm thực đơn đặc trưng của quán ăn gia đình Việt Nam)
IF NOT EXISTS (SELECT 1 FROM DanhMuc)
BEGIN
    SET IDENTITY_INSERT DanhMuc ON;
    INSERT INTO DanhMuc (DM_Ma, DM_Ten, DM_MoTa, DM_Xoa) VALUES
        (1, N'Món Khai Vị & Gỏi',       N'Các món gỏi cuốn, chả giò, salad trộn khai vị đầu bữa', 0),
        (2, N'Món Chính - Cơm &Mì/Phở', N'Các món ăn no truyền thống phục vụ suốt ngày', 0),
        (3, N'Món Lẩu & Nướng Tại Bàn', N'Các món lẩu gia đình và đồ nướng than hoa buổi tối', 0),
        (4, N'Thức Uống & Giải Khát',   N'Trà trái cây tươi, nước ép, cà phê và nước ngọt đóng lon', 0),
        (5, N'Tráng Miệng',             N'Chè truyền thống, bánh flan, sữa chua và trái cây theo mùa', 0);
    SET IDENTITY_INSERT DanhMuc OFF;
END
GO

-- 4.3. Bảng MonAn (16 món ăn & thức uống thực tế với giá bán chuẩn VNĐ)
IF NOT EXISTS (SELECT 1 FROM MonAn)
BEGIN
    SET IDENTITY_INSERT MonAn ON;
    INSERT INTO MonAn (MA_Ma, MA_Ten, MA_DanhMuc, MA_DonGia, MA_HetMon, MA_MoTa, MA_Xoa) VALUES
        -- Danh mục 1: Món Khai Vị & Gỏi
        (1,  N'Gỏi cuốn tôm thịt (Phần 4 cuốn)',       1, 45000,  0, N'Tôm sú tươi, thịt ba rọi luộc, bún tươi, rau sống chấm tương đậu phộng', 0),
        (2,  N'Chả giò hải sản Hương Việt (6 cuốn)',   1, 65000,  0, N'Nhân tôm, mực, thịt cua chiên giòn rụm kèm rau sống', 0),
        (3,  N'Gỏi ngó sen tôm thịt + Bánh phồng tôm', 1, 89000,  0, N'Ngó sen giòn trộn chua ngọt với tôm sú và thịt ba chỉ', 0),

        -- Danh mục 2: Món Chính - Cơm & Mì/Phở
        (4,  N'Cơm tấm sườn nướng bì chả trứng',       2, 65000,  0, N'Sườn cốt lết ướp mật ong nướng than hoa kèm bì, chả hấp', 0),
        (5,  N'Phở bò tái nạm gầu đặc biệt',           2, 70000,  0, N'Nước dùng ninh xương ống bò 12 tiếng, thịt bò tươi mềm', 0),
        (6,  N'Bún bò Huế giò heo chả cua',            2, 65000,  0, N'Chuẩn vị cố đô với khoanh giò heo, bắp bò và chả cua tươi', 0),
        (7,  N'Cơm chiên hải sản hoàng kim (Đĩa lớn)', 2, 115000, 0, N'Cơm chiên trứng muối hạt tơi vàng ươm cùng tôm, mực tươi', 0),
        (8,  N'Mì xào giòn hải sản rau củ',            2, 95000,  0, N'Mì trứng chiên giòn rưới sốt hải sản cải thìa, nấm đông cô', 0),

        -- Danh mục 3: Món Lẩu & Nướng Tại Bàn
        (9,  N'Lẩu Thái Tomyum hải sản (Nồi 4 người)', 3, 260000, 0, N'Tôm sú, mực ống, nghêu, cá phi lê, nấm kim châm và bún tươi', 0),
        (10, N'Bò lúc lắc khoai tây chiên + Bánh mì',  3, 145000, 0, N'Thăn bò Úc áp chảo sốt tiêu đen ăn kèm khoai tây chiên', 0),
        (11, N'Sườn non nướng tảng sốt BBQ',           3, 185000, 1, N'Món bán chạy - Tạm hết nguyên liệu trong ca để test cảnh báo Hết Món', 0),

        -- Danh mục 4: Thức Uống & Giải Khát
        (12, N'Trà đào cam sả (Ly lớn)',               4, 39000,  0, N'Trà đen ủ lạnh kết hợp đào miếng giòn, cam vàng và sả tươi', 0),
        (13, N'Trà tắc mật ong nha đam',               4, 32000,  0, N'Thanh mát giải nhiệt với nha đam hạt lựu nấu đường phèn', 0),
        (14, N'Cà phê sữa đá pha phin truyền thống',   4, 29000,  0, N'Hạt Robusta Buôn Ma Thuột rang mộc đậm đà', 0),
        (15, N'Nước ép cam tươi nguyên chất',          4, 42000,  0, N'Cam sành vắt tươi 100% không pha nước', 0),

        -- Danh mục 5: Tráng Miệng
        (16, N'Bánh flan trứng sữa caramel (Phần 2 cái)', 5, 28000, 0, N'Bánh flan nhà làm mềm mịn thơm mùi cà phê và caramel', 0);
    SET IDENTITY_INSERT MonAn OFF;
END
GO

-- ==============================================================
-- NHÓM 5: DỮ LIỆU PHỤC VỤ, GỌI MÓN & HÓA ĐƠN (2 BẢNG)
-- Bao gồm:
--   + 4 hóa đơn ĐÃ THANH TOÁN (rải đều Ca Sáng & Ca Tối) để test 6 Báo cáo thống kê
--   + 2 hóa đơn ĐANG PHỤC VỤ tại Bàn 02 & Bàn 03 để test Màn hình Sơ đồ bàn & Nhà bếp
-- ==============================================================

-- 5.1. Bảng HoaDon
IF NOT EXISTS (SELECT 1 FROM HoaDon)
BEGIN
    DECLARE @HomQuaHD DATETIME = CAST(CAST(DATEADD(DAY, -1, GETDATE()) AS DATE) AS DATETIME);
    DECLARE @HomNayHD DATETIME = CAST(CAST(GETDATE() AS DATE) AS DATETIME);

    SET IDENTITY_INSERT HoaDon ON;
    INSERT INTO HoaDon (
        HD_Ma, HD_MaBan, HD_MaNVPhucVu, HD_NguoiTao, HD_MaCa, HD_MaHoaDonGop,
        HD_SoLuongKhach, HD_ThoiGianVao, HD_ThoiGianThanhToan,
        HD_PhuongThucThanhToan, HD_TongTien, HD_TrangThai, HD_Xoa
    ) VALUES
        -- 1. Hóa đơn Ca Sáng hôm qua tại Bàn 01 (Phục vụ Tuấn - Đã thanh toán Tiền mặt)
        (1, 1, 3, 3, 1, NULL, 2,
         DATEADD(MINUTE, 510, @HomQuaHD), DATEADD(MINUTE, 560, @HomQuaHD),
         N'Tiền mặt', 193000, 1, 0),

        -- 2. Hóa đơn Ca Sáng hôm qua tại Bàn 06 (Phục vụ Tuấn - Đã thanh toán Chuyển khoản)
        (2, 6, 3, 3, 1, NULL, 4,
         DATEADD(MINUTE, 720, @HomQuaHD), DATEADD(MINUTE, 785, @HomQuaHD),
         N'Chuyển khoản', 442000, 1, 0),

        -- 3. Hóa đơn Ca Tối hôm qua tại Bàn 09 VIP 1 (Phục vụ Ánh đứng bàn, Quản lý Thảo bấm tạo hộ - Đã thanh toán QR Code)
        (3, 9, 4, 2, 2, NULL, 6,
         DATEADD(MINUTE, 1110, @HomQuaHD), DATEADD(MINUTE, 1215, @HomQuaHD),
         N'QR Code', 782000, 1, 0),

        -- 4. Hóa đơn Ca Sáng hôm nay tại Bàn 04 (Phục vụ Tuấn - Đã thanh toán Tiền mặt)
        (4, 4, 3, 3, 1, NULL, 3,
         DATEADD(MINUTE, 540, @HomNayHD), DATEADD(MINUTE, 595, @HomNayHD),
         N'Tiền mặt', 298000, 1, 0),

        -- 5. Hóa đơn ĐANG PHỤC VỤ tại Bàn 02 (Phục vụ Tuấn - Khách vừa gọi món, đang chờ bếp chế biến)
        (5, 2, 3, 3, 1, NULL, 4,
         DATEADD(MINUTE, -25, GETDATE()), NULL,
         N'Tiền mặt', 397000, 0, 0),

        -- 6. Hóa đơn ĐANG PHỤC VỤ tại Bàn 03 (Phục vụ Tuấn - Bếp vừa báo nấu xong, chờ mang ra bàn)
        (6, 3, 3, 3, 1, NULL, 2,
         DATEADD(MINUTE, -40, GETDATE()), NULL,
         N'Tiền mặt', 198000, 0, 0);
    SET IDENTITY_INSERT HoaDon OFF;
END
GO

-- 5.2. Bảng ChiTietHoaDon (Chi tiết từng món ăn khớp chính xác 100% với HD_TongTien ở bảng HoaDon)
IF NOT EXISTS (SELECT 1 FROM ChiTietHoaDon)
BEGIN
    DECLARE @HomQuaCT DATETIME = CAST(CAST(DATEADD(DAY, -1, GETDATE()) AS DATE) AS DATETIME);
    DECLARE @HomNayCT DATETIME = CAST(CAST(GETDATE() AS DATE) AS DATETIME);

    SET IDENTITY_INSERT ChiTietHoaDon ON;
    INSERT INTO ChiTietHoaDon (
        CTHD_Ma, CTHD_MaHoaDon, CTHD_MaMonAn, CTHD_SoLuong, CTHD_DonGia,
        CTHD_GhiChu, CTHD_ThoiGianGoi, CTHD_TrangThaiMon, CTHD_Xoa
    ) VALUES
        -- Chi tiết Hóa đơn 1 (Tổng: 1*65.000 + 1*70.000 + 2*29.000 = 193.000đ)
        (1,  1, 4,  1, 65000,  N'Ít mỡ hành',                  DATEADD(MINUTE, 512, @HomQuaCT), 2, 0), -- 1 Cơm tấm sườn bì chả
        (2,  1, 5,  1, 70000,  N'Không hành lá, nước trong',   DATEADD(MINUTE, 512, @HomQuaCT), 2, 0), -- 1 Phở bò tái nạm
        (3,  1, 14, 2, 29000,  N'1 ly ít sữa',                 DATEADD(MINUTE, 515, @HomQuaCT), 2, 0), -- 2 Cà phê sữa đá

        -- Chi tiết Hóa đơn 2 (Tổng: 1*89.000 + 1*115.000 + 1*145.000 + 1*65.000 + 1*28.000 = 442.000đ)
        (4,  2, 3,  1, 89000,  N'Nước mắm để riêng',           DATEADD(MINUTE, 725, @HomQuaCT), 2, 0), -- 1 Gỏi ngó sen tôm thịt (89.000)
        (5,  2, 7,  1, 115000, N'Cơm chiên giòn hạt',          DATEADD(MINUTE, 725, @HomQuaCT), 2, 0), -- 1 Cơm chiên hải sản (115.000)
        (6,  2, 10, 1, 145000, N'Bò chín vừa (Medium)',        DATEADD(MINUTE, 726, @HomQuaCT), 2, 0), -- 1 Bò lúc lắc khoai tây (145.000)
        (7,  2, 2,  1, 65000,  N'Chiên nóng giòn',             DATEADD(MINUTE, 726, @HomQuaCT), 2, 0), -- 1 Chả giò hải sản (65.000)
        (8,  2, 16, 1, 28000,  N'Tráng miệng cuối bữa',        DATEADD(MINUTE, 760, @HomQuaCT), 2, 0), -- 1 Bánh flan caramel (28.000)

        -- Chi tiết Hóa đơn 3 - Bàn VIP tối hôm qua (Tổng: 1*89.000 + 1*260.000 + 1*145.000 + 1*115.000 + 3*39.000 + 2*28.000 = 782.000đ)
        (9,  3, 3,  1, 89000,  N'Khai vị bàn VIP',             DATEADD(MINUTE, 1115, @HomQuaCT), 2, 0), -- 1 Gỏi ngó sen tôm thịt (89.000)
        (10, 3, 9,  1, 260000, N'Cay vừa, thêm rau muống',     DATEADD(MINUTE, 1115, @HomQuaCT), 2, 0), -- 1 Lẩu Thái Tomyum (260.000)
        (11, 3, 10, 1, 145000, N'Thêm 1 ổ bánh mì nóng',       DATEADD(MINUTE, 1120, @HomQuaCT), 2, 0), -- 1 Bò lúc lắc (145.000)
        (12, 3, 7,  1, 115000, N'Không hành lá',               DATEADD(MINUTE, 1125, @HomQuaCT), 2, 0), -- 1 Cơm chiên hải sản (115.000)
        (13, 3, 12, 3, 39000,  N'Ít đá',                       DATEADD(MINUTE, 1115, @HomQuaCT), 2, 0), -- 3 Trà đào cam sả (117.000)
        (14, 3, 16, 2, 28000,  N'Mang ra sau khi ăn lẩu xong', DATEADD(MINUTE, 1185, @HomQuaCT), 2, 0), -- 2 Phần bánh flan (56.000)

        -- Chi tiết Hóa đơn 4 - Ca Sáng hôm nay (Tổng: 2*70.000 + 1*65.000 + 2*32.000 + 1*29.000 = 298.000đ)
        (15, 4, 5,  2, 70000,  N'1 tô không hành, 1 tô nhiều gầu', DATEADD(MINUTE, 545, @HomNayCT), 2, 0), -- 2 Phở bò tái nạm (140.000)
        (16, 4, 6,  1, 65000,  N'Cay ít',                          DATEADD(MINUTE, 545, @HomNayCT), 2, 0), -- 1 Bún bò Huế (65.000)
        (17, 4, 13, 2, 32000,  N'Ít đường',                        DATEADD(MINUTE, 546, @HomNayCT), 2, 0), -- 2 Trà tắc mật ong (64.000)
        (18, 4, 14, 1, 29000,  N'Cà phê sữa nhiều đá',             DATEADD(MINUTE, 546, @HomNayCT), 2, 0), -- 1 Cà phê sữa đá (29.000)

        -- Chi tiết Hóa đơn 5 - ĐANG PHỤC VỤ tại Bàn 02 (Tổng: 1*45.000 + 2*32.000 + 1*260.000 + 1*28.000 = 397.000đ)
        (19, 5, 1,  1, 45000,  N'Mang ra trước cho khách dùng', DATEADD(MINUTE, -22, GETDATE()), 2, 0), -- 1 Gỏi cuốn tôm thịt (Đã mang ra)
        (20, 5, 13, 2, 32000,  N'Mang ra ngay',                 DATEADD(MINUTE, -22, GETDATE()), 2, 0), -- 2 Trà tắc mật ong (Đã mang ra)
        (21, 5, 9,  1, 260000, N'Khách dặn cay vừa, không mì',  DATEADD(MINUTE, -15, GETDATE()), 0, 0), -- 1 Lẩu Thái Tomyum (0: Đang chờ bếp nấu - hiển thị trên màn hình Nhà bếp!)
        (22, 5, 16, 1, 28000,  N'Đợi khách ăn lẩu xong mới làm', DATEADD(MINUTE, -15, GETDATE()), 0, 0), -- 1 Bánh flan (0: Đang chờ bếp thực hiện)

        -- Chi tiết Hóa đơn 6 - ĐANG PHỤC VỤ tại Bàn 03 (Tổng: 2*65000 + 1*39000 + 1*29000 = 130k + 39k + 29k = 198.000đ)
        (23, 6, 4,  2, 65000,  N'1 đĩa thêm ớt tươi',          DATEADD(MINUTE, -35, GETDATE()), 1, 0), -- 2 Cơm tấm sườn bì chả (1: Bếp đã nấu xong, chờ Phục vụ bưng ra!)
        (24, 6, 12, 1, 39000,  N'Ít đá',                       DATEADD(MINUTE, -35, GETDATE()), 2, 0), -- 1 Trà đào cam sả (2: Đã mang ra)
        (25, 6, 14, 1, 29000,  N'Pha đậm',                     DATEADD(MINUTE, -35, GETDATE()), 2, 0); -- 1 Cà phê sữa đá (2: Đã mang ra)
    SET IDENTITY_INSERT ChiTietHoaDon OFF;
END
GO
