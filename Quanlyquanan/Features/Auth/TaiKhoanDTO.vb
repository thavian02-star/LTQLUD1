Namespace Features.Auth
    ''' <summary>
    ''' Lớp thực thể dữ liệu (Data Transfer Object) đại diện cho thông tin tài khoản người dùng
    ''' và vai trò của họ sau khi xác thực thành công.
    ''' </summary>
    Public Class TaiKhoanDTO
        ''' <summary>
        ''' Mã định danh tài khoản trong CSDL (TK_Ma).
        ''' </summary>
        Public Property MaTaiKhoan As Integer = 0

        ''' <summary>
        ''' Tên đăng nhập hệ thống (TK_TenDangNhap).
        ''' </summary>
        Public Property TenDangNhap As String = String.Empty

        ''' <summary>
        ''' Mật khẩu đã băm MD5 (TK_MatKhau).
        ''' </summary>
        Public Property MatKhau As String = String.Empty

        ''' <summary>
        ''' Mã vai trò của tài khoản (VT_Ma: 1 = Chủ quán, 2 = Quản lý, 3 = Phục vụ, 4 = Nhà bếp).
        ''' </summary>
        Public Property MaVaiTro As Integer = 0

        ''' <summary>
        ''' Tên vai trò hiển thị (VT_Ten: "Chủ quán", "Quản lý", ...).
        ''' </summary>
        Public Property TenVaiTro As String = String.Empty

        ''' <summary>
        ''' Mã nhân viên sở hữu tài khoản này (NV_Ma). Nếu là tài khoản quản trị không gắn NV thì là 0.
        ''' </summary>
        Public Property MaNhanVien As Integer = 0

        ''' <summary>
        ''' Họ và tên nhân viên (NV_HoTen).
        ''' </summary>
        Public Property HoTenNhanVien As String = String.Empty

        ''' <summary>
        ''' Constructor mặc định không tham số.
        ''' </summary>
        Public Sub New()
        End Sub

        ''' <summary>
        ''' Constructor tiện ích khởi tạo nhanh đầy đủ thông tin tài khoản sau khi đăng nhập.
        ''' </summary>
        Public Sub New(maTK As Integer, tenDN As String, maVT As Integer, tenVT As String, maNV As Integer, hoTen As String)
            Me.MaTaiKhoan = maTK
            Me.TenDangNhap = tenDN
            Me.MaVaiTro = maVT
            Me.TenVaiTro = tenVT
            Me.MaNhanVien = maNV
            Me.HoTenNhanVien = hoTen
        End Sub
    End Class
End Namespace
