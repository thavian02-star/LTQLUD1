Imports System.Collections.Generic
Imports Quanlyquanan.Core.Security

Namespace Features.Auth
    ''' <summary>
    ''' Lớp xử lý nghiệp vụ (Business Logic Layer) cho phân hệ Xác thực và Đăng nhập.
    ''' Thực hiện kiểm tra tính hợp lệ dữ liệu, băm mật khẩu MD5, xác thực qua DAO và khởi tạo Session toàn cục.
    ''' </summary>
    Public Class AuthBUS
        ''' <summary>
        ''' Xử lý toàn bộ quy trình đăng nhập hệ thống.
        ''' </summary>
        ''' <param name="tenDangNhap">Tên đăng nhập người dùng nhập</param>
        ''' <param name="matKhauRaw">Mật khẩu thô chưa mã hóa</param>
        ''' <param name="thongBaoLoi">Biến trả về thông điệp lỗi nếu có</param>
        ''' <returns>True nếu đăng nhập thành công, False nếu thất bại</returns>
        Public Shared Function DangNhap(tenDangNhap As String, matKhauRaw As String, ByRef thongBaoLoi As String) As Boolean
            thongBaoLoi = String.Empty

            ' 1. Kiểm tra tính hợp lệ đầu vào (Validation)
            If String.IsNullOrWhiteSpace(tenDangNhap) Then
                thongBaoLoi = "Vui lòng nhập tên đăng nhập!"
                Return False
            End If

            If String.IsNullOrWhiteSpace(matKhauRaw) Then
                thongBaoLoi = "Vui lòng nhập mật khẩu!"
                Return False
            End If

            ' 2. Băm mật khẩu sang chuỗi MD5
            Dim matKhauMD5 As String = MaHoaMD5.BamMD5(matKhauRaw.Trim())

            ' 3. Gọi DAO truy vấn CSDL
            Dim dto As TaiKhoanDTO = Nothing
            Try
                dto = TaiKhoanDAO.KiemTraDangNhap(tenDangNhap.Trim(), matKhauMD5)
            Catch ex As Exception
                thongBaoLoi = "Lỗi kết nối CSDL: " & ex.Message & vbCrLf & "Vui lòng kiểm tra Docker SQL Server!"
                Return False
            End Try

            If dto Is Nothing Then
                thongBaoLoi = "Tên đăng nhập hoặc mật khẩu không chính xác!"
                Return False
            End If

            ' 4. Khởi tạo phiên làm việc toàn cục (Session)
            Session.MaTaiKhoan = dto.MaTaiKhoan
            Session.TenDangNhap = dto.TenDangNhap
            Session.MaVaiTro = dto.MaVaiTro
            Session.TenVaiTro = dto.TenVaiTro
            Session.MaNhanVien = dto.MaNhanVien
            Session.HoTenNhanVien = If(String.IsNullOrWhiteSpace(dto.HoTenNhanVien), dto.TenDangNhap, dto.HoTenNhanVien)

            ' 5. Tải danh sách quyền RBAC của vai trò
            Try
                Session.DanhSachQuyen = TaiKhoanDAO.LayDanhSachQuyen(dto.MaVaiTro)
            Catch ex As Exception
                Session.DanhSachQuyen = New List(Of String)()
            End Try

            Return True
        End Function

        ''' <summary>
        ''' Xử lý nghiệp vụ đổi mật khẩu cho tài khoản đang đăng nhập.
        ''' </summary>
        ''' <param name="matKhauCuRaw">Mật khẩu hiện tại</param>
        ''' <param name="matKhauMoiRaw">Mật khẩu mới</param>
        ''' <param name="xacNhanMoiRaw">Nhập lại mật khẩu mới</param>
        ''' <param name="thongBaoLoi">Biến trả về lỗi nếu có</param>
        ''' <returns>True nếu đổi thành công, False nếu thất bại</returns>
        Public Shared Function DoiMatKhau(matKhauCuRaw As String, matKhauMoiRaw As String, xacNhanMoiRaw As String, ByRef thongBaoLoi As String) As Boolean
            thongBaoLoi = String.Empty

            If Session.MaTaiKhoan <= 0 Then
                thongBaoLoi = "Chưa có tài khoản nào đăng nhập!"
                Return False
            End If

            If String.IsNullOrWhiteSpace(matKhauCuRaw) Then
                thongBaoLoi = "Vui lòng nhập mật khẩu cũ!"
                Return False
            End If

            If String.IsNullOrWhiteSpace(matKhauMoiRaw) Then
                thongBaoLoi = "Vui lòng nhập mật khẩu mới!"
                Return False
            End If

            If matKhauMoiRaw.Length < 6 Then
                thongBaoLoi = "Mật khẩu mới phải có ít nhất 6 ký tự!"
                Return False
            End If

            If matKhauMoiRaw <> xacNhanMoiRaw Then
                thongBaoLoi = "Mật khẩu mới và xác nhận mật khẩu không khớp!"
                Return False
            End If

            ' Xác thực mật khẩu cũ có đúng không
            Dim matKhauCuMD5 As String = MaHoaMD5.BamMD5(matKhauCuRaw.Trim())
            Dim dto As TaiKhoanDTO = TaiKhoanDAO.KiemTraDangNhap(Session.TenDangNhap, matKhauCuMD5)
            If dto Is Nothing Then
                thongBaoLoi = "Mật khẩu cũ không chính xác!"
                Return False
            End If

            ' Băm mật khẩu mới và lưu
            Dim matKhauMoiMD5 As String = MaHoaMD5.BamMD5(matKhauMoiRaw.Trim())
            Dim thanhCong As Boolean = TaiKhoanDAO.DoiMatKhau(Session.MaTaiKhoan, matKhauMoiMD5)

            If Not thanhCong Then
                thongBaoLoi = "Có lỗi xảy ra khi cập nhật mật khẩu vào CSDL!"
                Return False
            End If

            Return True
        End Function

        ''' <summary>
        ''' Đăng xuất người dùng hiện tại và xóa sạch thông tin phiên làm việc.
        ''' </summary>
        Public Shared Sub DangXuat()
            Session.DangXuat()
        End Sub
    End Class
End Namespace
