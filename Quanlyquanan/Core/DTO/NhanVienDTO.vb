Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Thực thể dữ liệu Nhân viên (ánh xạ bảng NhanVien, liên kết TaiKhoan, TrinhDoViTinh, DungCuTrangPhuc).
    ''' </summary>
    Public Class NhanVienDTO

        ''' <summary>Mã nhân viên (NV_Ma)</summary>
        Public Property MaNV As Integer

        ''' <summary>Họ và tên nhân viên (NV_HoTen)</summary>
        Public Property HoTen As String = String.Empty

        ''' <summary>Giới tính (NV_GioiTinh): True = Nam, False = Nữ</summary>
        Public Property GioiTinh As Boolean = True

        ''' <summary>Ngày sinh (NV_NgaySinh)</summary>
        Public Property NgaySinh As DateTime? = Nothing

        ''' <summary>Vị trí / Chức vụ (NV_ViTri): Quản lý, Phục vụ, Đầu bếp chính, Pha chế, Tiếp tân, Chủ quán...</summary>
        Public Property ViTri As String = "Phục vụ"

        ''' <summary>Số CCCD / CMND (NV_CMND)</summary>
        Public Property CMND As String = String.Empty

        ''' <summary>Số điện thoại (NV_DienThoai)</summary>
        Public Property DienThoai As String = String.Empty

        ''' <summary>Email liên hệ (NV_Email)</summary>
        Public Property Email As String = String.Empty

        ''' <summary>Địa chỉ thường trú / tạm trú (NV_DiaChi)</summary>
        Public Property DiaChi As String = String.Empty

        ''' <summary>Trình độ học vấn (NV_TrinhDoHocVan)</summary>
        Public Property TrinhDoHocVan As String = String.Empty

        ''' <summary>Trình độ ngoại ngữ (NV_NgoaiNgu)</summary>
        Public Property NgoaiNgu As String = String.Empty

        ''' <summary>Ngày bắt đầu làm việc (NV_NgayBatDauLam)</summary>
        Public Property NgayBatDauLam As DateTime = DateTime.Today

        ''' <summary>Ngày thôi việc (NV_NgayThoiViec) nếu đã nghỉ việc</summary>
        Public Property NgayThoiViec As DateTime? = Nothing

        ''' <summary>Mã tài khoản đăng nhập liên kết (NV_MaTaiKhoan)</summary>
        Public Property MaTaiKhoan As Integer? = Nothing

        ''' <summary>Tên tài khoản hiển thị (JOIN bảng TaiKhoan)</summary>
        Public Property TenTaiKhoanHienThi As String = String.Empty

        ''' <summary>Trạng thái công tác (NV_TrangThai): 'Đang làm việc' hoặc 'Đã nghỉ việc'</summary>
        Public Property TrangThai As String = "Đang làm việc"

        ''' <summary>Cờ xóa mềm (NV_Xoa)</summary>
        Public Property Xoa As Boolean = False

        ''' <summary>Danh sách mã kỹ năng vi tính nhân viên sở hữu (từ bảng NhanVien_ViTinh)</summary>
        Public Property DanhSachViTinh As New List(Of Integer)()

        ''' <summary>Chuỗi tóm tắt kỹ năng vi tính hiển thị</summary>
        Public Property KyNangViTinhHienThi As String = String.Empty

        ''' <summary>Số lượng trang phục / dụng cụ đang giữ chưa hoàn trả (DaTra = 0)</summary>
        Public Property SoDungCuDangGiu As Integer = 0

        ''' <summary>Chuỗi trạng thái dụng cụ / đồng phục hiển thị trên DataGridView</summary>
        Public Property ThongTinTrangPhucHienThi As String = String.Empty

        ' ==============================================================
        ' PROPERTIES ALIAS PHỤC VỤ DATA BINDING DATAGRIDVIEW
        ' ==============================================================
        Public Property NV_Ma As Integer
            Get
                Return MaNV
            End Get
            Set(value As Integer)
                MaNV = value
            End Set
        End Property

        Public Property NV_HoTen As String
            Get
                Return HoTen
            End Get
            Set(value As String)
                HoTen = value
            End Set
        End Property

        Public Property GioiTinhHienThi As String
            Get
                Return GioiTinhText
            End Get
            Set(value As String)
                ' Read-only logic binding support
            End Set
        End Property

        Public Property NV_ViTri As String
            Get
                Return ViTri
            End Get
            Set(value As String)
                ViTri = value
            End Set
        End Property

        Public Property NV_CMND As String
            Get
                Return CMND
            End Get
            Set(value As String)
                CMND = value
            End Set
        End Property

        Public Property NV_DienThoai As String
            Get
                Return DienThoai
            End Get
            Set(value As String)
                DienThoai = value
            End Set
        End Property

        Public Property NV_TrangThai As String
            Get
                Return TrangThai
            End Get
            Set(value As String)
                TrangThai = value
            End Set
        End Property

        ''' <summary>Thuộc tính hiển thị giới tính dạng Text</summary>
        Public ReadOnly Property GioiTinhText As String
            Get
                Return If(GioiTinh, "Nam", "Nữ")
            End Get
        End Property

        ''' <summary>Thuộc tính định dạng hiển thị ngày sinh</summary>
        Public ReadOnly Property NgaySinhText As String
            Get
                Return If(NgaySinh.HasValue, NgaySinh.Value.ToString("dd/MM/yyyy"), "")
            End Get
        End Property

        ''' <summary>Thuộc tính định dạng hiển thị ngày vào làm</summary>
        Public ReadOnly Property NgayVaoLamText As String
            Get
                Return NgayBatDauLam.ToString("dd/MM/yyyy")
            End Get
        End Property

        ''' <summary>Thuộc tính kiểm tra xem nhân viên có đang làm việc không</summary>
        Public ReadOnly Property IsDangLamViec As Boolean
            Get
                Return String.Equals(TrangThai, "Đang làm việc", StringComparison.OrdinalIgnoreCase)
            End Get
        End Property

    End Class

    ''' <summary>
    ''' Thực thể danh mục Kỹ năng Vi tính (ánh xạ bảng TrinhDoViTinh).
    ''' </summary>
    Public Class TrinhDoViTinhDTO
        Public Property MaTDVT As Integer
        Public Property TenTDVT As String = String.Empty
        Public Property Xoa As Boolean = False

        Public Overrides Function ToString() As String
            Return TenTDVT
        End Function
    End Class

    ''' <summary>
    ''' Thực thể rút gọn Tài khoản phục vụ Binding ComboBox tài khoản gán cho nhân viên.
    ''' </summary>
    Public Class TaiKhoanItemDTO
        Public Property MaTK As Integer
        Public Property TenDangNhap As String = String.Empty

        Public Overrides Function ToString() As String
            Return TenDangNhap
        End Function
    End Class

    ''' <summary>
    ''' Thực thể cấp phát đồng phục / dụng cụ nhân viên (bảng NhanVien_DungCu).
    ''' </summary>
    Public Class DungCuCapPhatDTO
        Public Property MPMa As Integer
        Public Property NVMa As Integer
        Public Property DCMa As Integer
        Public Property TenDungCu As String = String.Empty
        Public Property SoLuong As Integer = 1
        Public Property NgayNhan As DateTime = DateTime.Today
        Public Property DaTra As Boolean = False
        Public Property NgayTra As DateTime? = Nothing
        Public Property GhiChu As String = String.Empty
    End Class

End Namespace
