# Sơ Đồ Luồng Hoạt Động Hệ Thống (Application Flowcharts)
**Dự án:** Hệ Thống Quản Lý Quán Ăn & Chuỗi Nhà Hàng — Phúc Lộc Thọ  
**Công nghệ:** VB.NET WinForms (.NET 10.0) + SQL Server + Kiến trúc 3 Lớp

---

## 1. Sơ Đồ Luồng Tổng Thể Hệ Thống (Master System Flow)

```mermaid
flowchart TD
    Start(["Khởi động ứng dụng"]) --> Login["Màn hình Đăng Nhập (frmDangNhap)"]
    Login --> AuthCheck{"Xác thực tài khoản & Vai trò"}

    AuthCheck -- "Sai tài khoản / mật khẩu" --> Login
    AuthCheck -- "Thành công" --> SessionInit["Khởi tạo Session & Nạp danh sách quyền (Q_Tag)"]
    SessionInit --> MainHub["Trung tâm Điều Hành Launchpad (frmMain)"]

    MainHub --> NavPOS["🍽️ Điểm Bán Hàng & POS (frmSoDoBan)"]
    MainHub --> NavKDS["🍳 Hàng Đợi Nhà Bếp KDS (frmNhaBep)"]
    MainHub --> NavStaff["⏱️ Nhân Sự & Chấm Công"]
    MainHub --> NavMaster["📋 Danh Mục Nền Tảng (9/9)"]
    MainHub --> NavReport["📊 Báo Cáo & Thống Kê (frmBaoCao)"]
    MainHub --> NavSecurity["🛡️ Quản Trị & Phân Quyền (frmPhanQuyen)"]

    subgraph StaffGroup ["Phân Hệ Nhân Sự & Ca Trực"]
        NavStaff --> StaffCheckIn["Chấm Công Cá Nhân (frmChamCongCaNhan)"]
        NavStaff --> StaffApproval["Quản Lý Duyệt Công (frmDuyetChamCong)"]
        NavStaff --> StaffRoster["Xếp Lịch Tuần (frmQuanLyLichLamViec)"]
    end

    subgraph MasterGroup ["9 Màn Hình Danh Mục Master"]
        NavMaster --> M1["Món Ăn & Danh Mục (frmMonAn, frmDanhMuc)"]
        NavMaster --> M2["Bàn Ăn & Khu Vực (frmBan, frmKhuVuc)"]
        NavMaster --> M3["Ca Làm Việc & Lương (frmCaLamViec)"]
        NavMaster --> M4["Hồ Sơ Nhân Sự (frmNhanVien)"]
        NavMaster --> M5["Thực Đơn & Chi Nhánh (frmMenu, frmChiNhanh, frmMenuChiNhanh)"]
    end
```

---

## 2. Sơ Đồ Chu Trình Bán Hàng, Chế Biến & Thanh Toán (POS & Kitchen Flow)

```mermaid
flowchart TD
    KhachDen["Khách đến nhà hàng"] --> ChonBan["Nhân viên chọn bàn trên Sơ đồ (frmSoDoBan)"]
    ChonBan --> MoBan["Mở bàn & Khởi tạo Hóa đơn mới (HoaDon)"]
    MoBan --> GoiMon["Chọn món ăn, thức uống, số lượng & ghi chú"]
    GoiMon --> GuiLenh["Bấm 'Gửi Bếp Chế Biến'"]

    GuiLenh --> KDSQueue["Đẩy món vào Hàng đợi KDS (ChiTietHoaDon: CTHD_TrangThaiMon = 0)"]
    KDSQueue --> HienThiKDS["Màn hình Bếp KDS hiển thị thứ tự FIFO (frmNhaBep)"]
    HienThiKDS --> CheBien["Đầu bếp thực hiện chế biến món"]
    CheBien --> BaoXong["Bếp bấm 'Báo Đã Nấu Xong' (CTHD_TrangThaiMon = 1)"]
    BaoXong --> PhucVuMon["Đồng bộ trạng thái -> Phục vụ mang món ra bàn"]

    PhucVuMon --> KhachDungBua{"Nhu cầu khách hàng"}
    KhachDungBua -- "Gọi thêm món" --> GoiMon
    KhachDungBua -- "Yêu cầu chuyển bàn" --> ChuyenBan["Chuyển bàn sang bàn trống khác (Cập nhật HD_MaBan)"]
    ChuyenBan --> KhachDungBua

    KhachDungBua -- "Yêu cầu thanh toán" --> TinhTien["Bấm 'Thanh Toán' trên frmSoDoBan"]
    TinhTien --> InHoaDon["Cộng tổng tiền món hợp lệ (không tính món hủy) -> Xuất hóa đơn"]
    InHoaDon --> KetThucDon["Cập nhật HD_TrangThai = 1, Đổi trạng thái bàn về 'Trống'"]
    KetThucDon --> DoanhThu["Dữ liệu hóa đơn tự động cập nhật vào Báo Cáo Doanh Thu (frmBaoCao)"]
```

---

## 3. Sơ Đồ Chu Trình Quản Trị Nhân Sự, Chấm Công & Tính Lương (Staff Lifecycle)

```mermaid
flowchart LR
    Step1["1. Xếp Lịch Tuần<br>(frmQuanLyLichLamViec)"] --> Step2["2. Điểm Danh Vào Ca<br>(frmChamCongCaNhan)"]
    Step2 --> Step3["3. Thực Hiện Ca & Ra Ca<br>(Check-out 1-Click)"]
    Step3 --> Step4["4. Quản Lý Duyệt Công<br>(frmDuyetChamCong [F6])"]
    Step4 --> Step5["5. Thống Kê & Bảng Lương<br>(frmBaoCao Tab 3)"]
```

---

## 4. Sơ Đồ Kiến Trúc Phân Tầng Dữ Liệu 3 Lớp (3-Tier Architecture)

```mermaid
flowchart TD
    subgraph PresentationLayer ["Tầng Giao Diện (Presentation Layer - WinForms)"]
        UI1["Forms Nghiệp Vụ: frmSoDoBan, frmNhaBep, frmBaoCao..."]
        UI2["Controls: DataGridView, TabControl, DateTimePicker..."]
    end

    subgraph BusinessLayer ["Tầng Nghiệp Vụ (Business Logic Layer - BUS)"]
        BUS1["HoaDonBUS, NhaBepBUS, ChamCongBUS, BaoCaoBUS..."]
        BUS2["Xử lý logic, tính toán, kiểm tra ràng buộc & Fallback Mock"]
    end

    subgraph DataAccessLayer ["Tầng Truy Cập Dữ Liệu (Data Access Layer - DAO)"]
        DAO1["HoaDonDAO, ChiTietHoaDonDAO, ChamCongDAO, BaoCaoDAO..."]
        DAO2["KetNoiCSDL.vb (ExecuteQuery, ExecuteNonQuery, ExecuteScalar)"]
    end

    subgraph DataTransferLayer ["Tầng Thực Thể (DTO)"]
        DTO["HoaDonDTO, ChiTietHoaDonDTO, ChamCongDTO, BaoCaoDoanhThuDTO..."]
    end

    subgraph DatabaseLayer ["Cơ Sở Dữ Liệu (Database - SQL Server)"]
        DB[(SQL Server Database / Docker MSSQL)]
    end

    UI1 --> BUS1
    BUS1 --> DAO1
    DAO1 --> DB
    DTO -. "Vận chuyển dữ liệu xuyên suốt" .-> UI1
    DTO -. "Vận chuyển dữ liệu xuyên suốt" .-> BUS1
    DTO -. "Vận chuyển dữ liệu xuyên suốt" .-> DAO1
```
