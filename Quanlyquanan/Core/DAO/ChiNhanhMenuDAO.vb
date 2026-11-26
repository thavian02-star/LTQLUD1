Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng ChiNhanh_Menu.
    ''' 100% Parameterized SQL an toàn tuyệt đối qua KetNoiCSDL.
    ''' </summary>
    Public Class ChiNhanhMenuDAO

        Public Shared Function LayDanhSachTheoChiNhanh(maChiNhanh As Integer, Optional tuKhoa As String = "", Optional trangThai As String = "") As List(Of ChiNhanhMenuDTO)
            Dim ds As New List(Of ChiNhanhMenuDTO)()
            Dim kw As String = If(tuKhoa, String.Empty).Trim()
            Dim st As String = If(trangThai, String.Empty).Trim()

            Dim sql As String = "
                SELECT cnm.CNM_Ma, cnm.CNM_MaChiNhanh, cn.CN_Ten, cnm.CNM_MaMenu,
                       mn.MN_Ten, mn.MN_LoaiMenu, cnm.CNM_NgayBatDau, cnm.CNM_NgayKetThuc,
                       cnm.CNM_GhiChu, cnm.CNM_TrangThai, cnm.CNM_Xoa,
                       (SELECT COUNT(*) FROM Menu_MonAn mma WHERE mma.MMA_MaMenu = cnm.CNM_MaMenu AND mma.MMA_Xoa = 0) AS SoMonAn
                FROM ChiNhanh_Menu cnm
                JOIN ChiNhanh cn ON cnm.CNM_MaChiNhanh = cn.CN_Ma
                JOIN Menu mn ON cnm.CNM_MaMenu = mn.MN_Ma
                WHERE cnm.CNM_Xoa = 0
                  AND (@MaCN = 0 OR cnm.CNM_MaChiNhanh = @MaCN)
                  AND (@TuKhoa = N'' OR mn.MN_Ten LIKE N'%' + @TuKhoa + N'%' OR mn.MN_LoaiMenu LIKE N'%' + @TuKhoa + N'%' OR cnm.CNM_GhiChu LIKE N'%' + @TuKhoa + N'%')
                  AND (@TrangThai = N'' OR cnm.CNM_TrangThai = @TrangThai)
                ORDER BY cnm.CNM_NgayBatDau DESC, cnm.CNM_Ma DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = maChiNhanh},
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = kw},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) With {.Value = st}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(MapRowToDTO(row))
            Next
            Return ds
        End Function

        Private Shared Function MapRowToDTO(row As DataRow) As ChiNhanhMenuDTO
            Dim dto As New ChiNhanhMenuDTO()
            dto.MaCNM = Convert.ToInt32(row("CNM_Ma"))
            dto.MaChiNhanh = Convert.ToInt32(row("CNM_MaChiNhanh"))
            dto.TenChiNhanh = If(IsDBNull(row("CN_Ten")), String.Empty, row("CN_Ten").ToString())
            dto.MaMenu = Convert.ToInt32(row("CNM_MaMenu"))
            dto.TenMenu = If(IsDBNull(row("MN_Ten")), String.Empty, row("MN_Ten").ToString())
            dto.LoaiMenu = If(IsDBNull(row("MN_LoaiMenu")), "Alacarte", row("MN_LoaiMenu").ToString())
            dto.NgayBatDau = If(IsDBNull(row("CNM_NgayBatDau")), Date.Today, Convert.ToDateTime(row("CNM_NgayBatDau")))
            If Not IsDBNull(row("CNM_NgayKetThuc")) Then
                dto.NgayKetThuc = Convert.ToDateTime(row("CNM_NgayKetThuc"))
            End If
            dto.GhiChu = If(IsDBNull(row("CNM_GhiChu")), String.Empty, row("CNM_GhiChu").ToString())
            dto.TrangThai = If(IsDBNull(row("CNM_TrangThai")), "Đang áp dụng", row("CNM_TrangThai").ToString())
            dto.Xoa = If(IsDBNull(row("CNM_Xoa")), False, Convert.ToBoolean(row("CNM_Xoa")))
            dto.SoMonAn = If(IsDBNull(row("SoMonAn")), 0, Convert.ToInt32(row("SoMonAn")))
            Return dto
        End Function

        Public Shared Function LayTheoMa(maCNM As Integer) As ChiNhanhMenuDTO
            Dim sql As String = "
                SELECT cnm.CNM_Ma, cnm.CNM_MaChiNhanh, cn.CN_Ten, cnm.CNM_MaMenu,
                       mn.MN_Ten, mn.MN_LoaiMenu, cnm.CNM_NgayBatDau, cnm.CNM_NgayKetThuc,
                       cnm.CNM_GhiChu, cnm.CNM_TrangThai, cnm.CNM_Xoa,
                       (SELECT COUNT(*) FROM Menu_MonAn mma WHERE mma.MMA_MaMenu = cnm.CNM_MaMenu AND mma.MMA_Xoa = 0) AS SoMonAn
                FROM ChiNhanh_Menu cnm
                JOIN ChiNhanh cn ON cnm.CNM_MaChiNhanh = cn.CN_Ma
                JOIN Menu mn ON cnm.CNM_MaMenu = mn.MN_Ma
                WHERE cnm.CNM_Ma = @MaCNM AND cnm.CNM_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCNM", SqlDbType.Int) With {.Value = maCNM}
            }
            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            If dt.Rows.Count > 0 Then
                Return MapRowToDTO(dt.Rows(0))
            End If
            Return Nothing
        End Function

        Public Shared Function KiemTraMenuDaGan(maChiNhanh As Integer, maMenu As Integer, Optional loaiTruMaCNM As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(*) FROM ChiNhanh_Menu
                WHERE CNM_MaChiNhanh = @MaCN AND CNM_MaMenu = @MaMenu
                  AND CNM_Xoa = 0 AND (@LoaiTruMa = 0 OR CNM_Ma <> @LoaiTruMa);"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = maChiNhanh},
                New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu},
                New SqlParameter("@LoaiTruMa", SqlDbType.Int) With {.Value = loaiTruMaCNM}
            }
            Dim count As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return count IsNot Nothing AndAlso Convert.ToInt32(count) > 0
        End Function

        Public Shared Function GanMenu(dto As ChiNhanhMenuDTO) As Integer
            Dim checkSql As String = "SELECT CNM_Ma FROM ChiNhanh_Menu WHERE CNM_MaChiNhanh = @MaCN AND CNM_MaMenu = @MaMenu;"
            Dim prmsCheck As SqlParameter() = {
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = dto.MaChiNhanh},
                New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = dto.MaMenu}
            }
            Dim existingId As Object = KetNoiCSDL.ExecuteScalar(checkSql, prmsCheck)

            If existingId IsNot Nothing AndAlso Convert.ToInt32(existingId) > 0 Then
                Return TaiKichHoatMenu(Convert.ToInt32(existingId), dto)
            End If
            Return ChenMenuMoi(dto)
        End Function

        Private Shared Function TaiKichHoatMenu(maCNM As Integer, dto As ChiNhanhMenuDTO) As Integer
            Dim sql As String = "
                UPDATE ChiNhanh_Menu
                SET CNM_NgayBatDau = @NgayBD, CNM_NgayKetThuc = @NgayKT, CNM_GhiChu = @GhiChu,
                    CNM_TrangThai = @TrangThai, CNM_Xoa = 0
                WHERE CNM_Ma = @MaCNM;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@NgayBD", SqlDbType.Date) With {.Value = dto.NgayBatDau},
                New SqlParameter("@NgayKT", SqlDbType.Date) With {.Value = If(dto.NgayKetThuc.HasValue, CObj(dto.NgayKetThuc.Value), DBNull.Value)},
                New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(dto.GhiChu, String.Empty).Trim()},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()},
                New SqlParameter("@MaCNM", SqlDbType.Int) With {.Value = maCNM}
            }
            Dim rows As Integer = KetNoiCSDL.ExecuteNonQuery(sql, prms)
            Return If(rows > 0, maCNM, 0)
        End Function

        Private Shared Function ChenMenuMoi(dto As ChiNhanhMenuDTO) As Integer
            Dim insertSql As String = "
                INSERT INTO ChiNhanh_Menu (CNM_MaChiNhanh, CNM_MaMenu, CNM_NgayBatDau, CNM_NgayKetThuc, CNM_GhiChu, CNM_TrangThai, CNM_Xoa)
                VALUES (@MaCN, @MaMenu, @NgayBD, @NgayKT, @GhiChu, @TrangThai, 0);
                SELECT SCOPE_IDENTITY();"
            Dim prmsIns As SqlParameter() = {
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = dto.MaChiNhanh},
                New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = dto.MaMenu},
                New SqlParameter("@NgayBD", SqlDbType.Date) With {.Value = dto.NgayBatDau},
                New SqlParameter("@NgayKT", SqlDbType.Date) With {.Value = If(dto.NgayKetThuc.HasValue, CObj(dto.NgayKetThuc.Value), DBNull.Value)},
                New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(dto.GhiChu, String.Empty).Trim()},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()}
            }
            Dim newId As Object = KetNoiCSDL.ExecuteScalar(insertSql, prmsIns)
            Return If(newId IsNot Nothing, Convert.ToInt32(newId), 0)
        End Function

        Public Shared Function CapNhat(dto As ChiNhanhMenuDTO) As Boolean
            Dim sql As String = "
                UPDATE ChiNhanh_Menu
                SET CNM_NgayBatDau = @NgayBD, CNM_NgayKetThuc = @NgayKT,
                    CNM_GhiChu = @GhiChu, CNM_TrangThai = @TrangThai
                WHERE CNM_Ma = @MaCNM AND CNM_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@NgayBD", SqlDbType.Date) With {.Value = dto.NgayBatDau},
                New SqlParameter("@NgayKT", SqlDbType.Date) With {.Value = If(dto.NgayKetThuc.HasValue, CObj(dto.NgayKetThuc.Value), DBNull.Value)},
                New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(dto.GhiChu, String.Empty).Trim()},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()},
                New SqlParameter("@MaCNM", SqlDbType.Int) With {.Value = dto.MaCNM}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Public Shared Function GoMenu(maCNM As Integer) As Boolean
            Dim sql As String = "UPDATE ChiNhanh_Menu SET CNM_Xoa = 1 WHERE CNM_Ma = @MaCNM;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCNM", SqlDbType.Int) With {.Value = maCNM}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Public Shared Function LayDanhSachMenuMaster() As DataTable
            Dim sql As String = "
                SELECT MN_Ma, MN_Ten, MN_LoaiMenu, MN_TrangThai
                FROM Menu
                WHERE MN_Xoa = 0
                ORDER BY MN_Ma ASC;"
            Return KetNoiCSDL.ExecuteQuery(sql)
        End Function

    End Class

End Namespace
