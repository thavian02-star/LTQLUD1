Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho việc quản lý vai trò và phân quyền động.
    ''' </summary>
    Public Class PhanQuyenDAO

        ''' <summary>
        ''' Lấy toàn bộ danh sách vai trò người dùng trong hệ thống.
        ''' </summary>
        Public Shared Function LayDanhSachVaiTro() As List(Of VaiTroDTO)
            Dim ds As New List(Of VaiTroDTO)()
            Dim sql As String = "
                SELECT vt.VT_Ma, vt.VT_Ten, vt.VT_MoTa,
                       (SELECT COUNT(*) FROM VaiTro_Quyen vtq WHERE vtq.VTQ_MaVaiTro = vt.VT_Ma AND vtq.VTQ_Xoa = 0) AS SoLuongQuyen
                FROM VaiTro vt
                WHERE vt.VT_Xoa = 0
                ORDER BY vt.VT_Ma ASC;"

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)
            For Each row As DataRow In dt.Rows
                ds.Add(New VaiTroDTO() With {
                    .VT_Ma = Convert.ToInt32(row("VT_Ma")),
                    .VT_Ten = row("VT_Ten").ToString(),
                    .VT_MoTa = If(IsDBNull(row("VT_MoTa")), "", row("VT_MoTa").ToString()),
                    .SoLuongQuyen = Convert.ToInt32(row("SoLuongQuyen"))
                })
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Lấy toàn bộ danh mục quyền kèm trạng thái cấp phép cho vai trò được chọn.
        ''' </summary>
        Public Shared Function LayDanhSachQuyen(maVaiTro As Integer) As List(Of QuyenDTO)
            Dim ds As New List(Of QuyenDTO)()
            Dim sql As String = "
                SELECT q.Q_Ma, q.Q_Ten, q.Q_MoTa, q.Q_Tag, q.Q_Nhom,
                       CASE WHEN vtq.VTQ_MaVaiTro IS NOT NULL THEN 1 ELSE 0 END AS DuocCap
                FROM Quyen q
                LEFT JOIN VaiTro_Quyen vtq ON vtq.VTQ_MaQuyen = q.Q_Ma AND vtq.VTQ_MaVaiTro = @MaVT AND vtq.VTQ_Xoa = 0
                WHERE q.Q_Xoa = 0
                ORDER BY q.Q_Nhom ASC, q.Q_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaVT", SqlDbType.Int) With {.Value = maVaiTro}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(New QuyenDTO() With {
                    .Q_Ma = Convert.ToInt32(row("Q_Ma")),
                    .Q_Ten = row("Q_Ten").ToString(),
                    .Q_MoTa = If(IsDBNull(row("Q_MoTa")), "", row("Q_MoTa").ToString()),
                    .Q_Tag = row("Q_Tag").ToString(),
                    .Q_Nhom = If(IsDBNull(row("Q_Nhom")), "Hệ Thống", row("Q_Nhom").ToString()),
                    .DuocCap = (Convert.ToInt32(row("DuocCap")) = 1)
                })
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Lưu phân bổ quyền cho một vai trò.
        ''' </summary>
        Public Shared Function LuuPhanQuyen(maVaiTro As Integer, dsMaQuyen As List(Of Integer)) As Boolean
            Dim sqlDel As String = "DELETE FROM VaiTro_Quyen WHERE VTQ_MaVaiTro = @MaVT;"
            Dim prmsDel As SqlParameter() = {New SqlParameter("@MaVT", SqlDbType.Int) With {.Value = maVaiTro}}
            KetNoiCSDL.ExecuteNonQuery(sqlDel, prmsDel)

            If dsMaQuyen IsNot Nothing AndAlso dsMaQuyen.Count > 0 Then
                For Each qId In dsMaQuyen
                    Dim sqlIns As String = "INSERT INTO VaiTro_Quyen (VTQ_MaVaiTro, VTQ_MaQuyen, VTQ_Xoa) VALUES (@MaVT, @MaQ, 0);"
                    Dim prmsIns As SqlParameter() = {
                        New SqlParameter("@MaVT", SqlDbType.Int) With {.Value = maVaiTro},
                        New SqlParameter("@MaQ", SqlDbType.Int) With {.Value = qId}
                    }
                    KetNoiCSDL.ExecuteNonQuery(sqlIns, prmsIns)
                Next
            End If
            Return True
        End Function

        ''' <summary>
        ''' Thêm một vai trò mới vào hệ thống.
        ''' </summary>
        Public Shared Function ThemVaiTro(ten As String, moTa As String) As Integer
            Dim sql As String = "INSERT INTO VaiTro (VT_Ten, VT_MoTa, VT_Xoa) VALUES (@Ten, @MoTa, 0); SELECT SCOPE_IDENTITY();"
            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = ten},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = moTa}
            }
            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq IsNot Nothing AndAlso Not IsDBNull(kq) Then
                Return Convert.ToInt32(kq)
            End If
            Return 0
        End Function

    End Class

End Namespace
