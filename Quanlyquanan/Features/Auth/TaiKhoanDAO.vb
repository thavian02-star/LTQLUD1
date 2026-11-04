Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database

Namespace Features.Auth
    ''' <summary>
    ''' Lớp truy cập dữ liệu (Data Access Object) cho phân hệ Xác thực và Tài khoản.
    ''' Thực thi các truy vấn tới các bảng: TaiKhoan, VaiTro, Quyen, TaiKhoan_VaiTro, VaiTro_Quyen.
    ''' </summary>
    Public Class TaiKhoanDAO
        ''' <summary>
        ''' Xác thực thông tin đăng nhập từ CSDL.
        ''' Sử dụng Parameterized Query để phòng chống tấn công SQL Injection.
        ''' </summary>
        ''' <param name="tenDangNhap">Tên đăng nhập do người dùng nhập</param>
        ''' <param name="matKhauMD5">Mật khẩu đã được băm MD5</param>
        ''' <returns>Đối tượng TaiKhoanDTO nếu thông tin hợp lệ; ngược lại trả về Nothing</returns>
        Public Shared Function KiemTraDangNhap(tenDangNhap As String, matKhauMD5 As String) As TaiKhoanDTO
            Dim sql As String =
                "SELECT TOP 1 " &
                "   tk.TK_Ma, tk.TK_TenDangNhap, " &
                "   vt.VT_Ma, vt.VT_Ten, " &
                "   ISNULL(nv.NV_Ma, 0) AS NV_Ma, " &
                "   ISNULL(nv.NV_HoTen, N'') AS NV_HoTen " &
                "FROM TaiKhoan tk " &
                "INNER JOIN TaiKhoan_VaiTro tkvt ON tk.TK_Ma = tkvt.TKVT_TaiKhoan AND tkvt.TKVT_Xoa = 0 " &
                "INNER JOIN VaiTro vt ON tkvt.TKVT_VaiTro = vt.VT_Ma AND vt.VT_Xoa = 0 " &
                "LEFT JOIN NhanVien nv ON tk.TK_Ma = nv.NV_MaTaiKhoan AND nv.NV_Xoa = 0 " &
                "WHERE tk.TK_TenDangNhap = @TenDangNhap " &
                "  AND tk.TK_MatKhau = @MatKhau " &
                "  AND tk.TK_Xoa = 0"

            Dim parameters As SqlParameter() = {
                New SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) With {.Value = tenDangNhap.Trim()},
                New SqlParameter("@MatKhau", SqlDbType.NVarChar, 100) With {.Value = matKhauMD5.Trim()}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, parameters)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Dim dto As New TaiKhoanDTO() With {
                    .MaTaiKhoan = Convert.ToInt32(row("TK_Ma")),
                    .TenDangNhap = row("TK_TenDangNhap").ToString(),
                    .MaVaiTro = Convert.ToInt32(row("VT_Ma")),
                    .TenVaiTro = row("VT_Ten").ToString(),
                    .MaNhanVien = Convert.ToInt32(row("NV_Ma")),
                    .HoTenNhanVien = row("NV_HoTen").ToString()
                }
                Return dto
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Lấy toàn bộ danh sách mã định danh quyền (Q_Tag) mà vai trò này được cấp trong bảng VaiTro_Quyen.
        ''' </summary>
        ''' <param name="maVaiTro">Mã vai trò (VT_Ma)</param>
        ''' <returns>Danh sách chuỗi các mã quyền (ví dụ: POS_SO_DO_BAN, CQ_BAO_CAO_THONG_KE...)</returns>
        Public Shared Function LayDanhSachQuyen(maVaiTro As Integer) As List(Of String)
            Dim danhSachQuyen As New List(Of String)()

            Dim sql As String =
                "SELECT q.Q_Tag " &
                "FROM VaiTro_Quyen vtq " &
                "INNER JOIN Quyen q ON vtq.VTQ_Quyen = q.Q_Ma AND q.Q_Xoa = 0 " &
                "WHERE vtq.VTQ_VaiTro = @MaVaiTro " &
                "  AND vtq.VTQ_Xoa = 0"

            Dim parameters As SqlParameter() = {
                New SqlParameter("@MaVaiTro", SqlDbType.Int) With {.Value = maVaiTro}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, parameters)

            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    If Not row.IsNull("Q_Tag") Then
                        Dim tag As String = row("Q_Tag").ToString().Trim().ToUpper()
                        If Not String.IsNullOrEmpty(tag) AndAlso Not danhSachQuyen.Contains(tag) Then
                            danhSachQuyen.Add(tag)
                        End If
                    End If
                Next
            End If

            Return danhSachQuyen
        End Function

        ''' <summary>
        ''' Cập nhật mật khẩu mới cho tài khoản (dùng cho chức năng Đổi mật khẩu).
        ''' </summary>
        Public Shared Function DoiMatKhau(maTaiKhoan As Integer, matKhauMoiMD5 As String) As Boolean
            Dim sql As String =
                "UPDATE TaiKhoan " &
                "SET TK_MatKhau = @MatKhauMoi " &
                "WHERE TK_Ma = @MaTaiKhoan AND TK_Xoa = 0"

            Dim parameters As SqlParameter() = {
                New SqlParameter("@MatKhauMoi", SqlDbType.NVarChar, 100) With {.Value = matKhauMoiMD5.Trim()},
                New SqlParameter("@MaTaiKhoan", SqlDbType.Int) With {.Value = maTaiKhoan}
            }

            Dim rowsAffected As Integer = KetNoiCSDL.ExecuteNonQuery(sql, parameters)
            Return rowsAffected > 0
        End Function
    End Class
End Namespace
