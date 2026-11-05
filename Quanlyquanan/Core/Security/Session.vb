Imports System.Collections.Generic

Namespace Core.Security
    ''' <summary>
    ''' Quản lý phiên đăng nhập toàn cục của hệ thống (Current User Session & RBAC Permissions).
    ''' </summary>
    Public Class Session
        ''' <summary>
        ''' Mã tài khoản đang đăng nhập (TK_Ma).
        ''' </summary>
        Public Shared Property MaTaiKhoan As Integer = 0

        ''' <summary>
        ''' Tên đăng nhập (TK_TenDangNhap).
        ''' </summary>
        Public Shared Property TenDangNhap As String = String.Empty

        ''' <summary>
        ''' Mã vai trò (VT_Ma: 1: Chủ quán, 2: Quản lý, 3: Phục vụ, 4: Nhà bếp).
        ''' </summary>
        Public Shared Property MaVaiTro As Integer = 0

        ''' <summary>
        ''' Tên vai trò hiển thị.
        ''' </summary>
        Public Shared Property TenVaiTro As String = String.Empty

        ''' <summary>
        ''' Mã nhân viên tương ứng với tài khoản (NV_Ma).
        ''' </summary>
        Public Shared Property MaNhanVien As Integer = 0

        ''' <summary>
        ''' Họ tên nhân viên.
        ''' </summary>
        Public Shared Property HoTenNhanVien As String = String.Empty

        ''' <summary>
        ''' Danh sách mã quyền (Q_Tag) mà tài khoản này được cấp.
        ''' </summary>
        Public Shared Property DanhSachQuyen As New List(Of String)()

        ''' <summary>
        ''' Kiểm tra tài khoản hiện tại có quyền ứng với mã Tag được chỉ định hay không.
        ''' </summary>
        Public Shared Function CoQuyen(tagQuyen As String) As Boolean
            If String.IsNullOrWhiteSpace(tagQuyen) Then Return True
            ' Chủ quán (MaVaiTro = 1) mặc định có toàn quyền
            If MaVaiTro = 1 Then Return True
            Return DanhSachQuyen.Contains(tagQuyen.Trim().ToUpper())
        End Function

        ''' <summary>
        ''' Xóa sạch dữ liệu phiên khi đăng xuất.
        ''' </summary>
        Public Shared Sub DangXuat()
            MaTaiKhoan = 0
            TenDangNhap = String.Empty
            MaVaiTro = 0
            TenVaiTro = String.Empty
            MaNhanVien = 0
            HoTenNhanVien = String.Empty
            DanhSachQuyen.Clear()
        End Sub

        ''' <summary>
        ''' Bí danh tương đương hàm DangXuat.
        ''' </summary>
        Public Shared Sub Clear()
            DangXuat()
        End Sub
    End Class
End Namespace
