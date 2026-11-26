Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng ChiNhanh.
    ''' 100% Parameterized SQL an toàn tuyệt đối qua KetNoiCSDL.
    ''' </summary>
    Public Class ChiNhanhDAO

        Public Shared Function LayDanhSach(Optional tuKhoa As String = "", Optional trangThai As String = "") As List(Of ChiNhanhDTO)
            Dim ds As New List(Of ChiNhanhDTO)()
            Dim kw As String = If(tuKhoa, String.Empty).Trim()
            Dim st As String = If(trangThai, String.Empty).Trim()

            Dim sql As String = "
                SELECT cn.CN_Ma, cn.CN_Ten, cn.CN_DiaChi, cn.CN_SoDienThoai, cn.CN_NguoiQuanLy,
                       nv.NV_HoTen AS TenQuanLy, cn.CN_SucChua, cn.CN_GioMoCua, cn.CN_MoTa, cn.CN_TrangThai, cn.CN_Xoa
                FROM ChiNhanh cn
                LEFT JOIN NhanVien nv ON cn.CN_NguoiQuanLy = nv.NV_Ma
                WHERE cn.CN_Xoa = 0
                  AND (@TuKhoa = N'' OR cn.CN_Ten LIKE N'%' + @TuKhoa + N'%' OR cn.CN_DiaChi LIKE N'%' + @TuKhoa + N'%' OR cn.CN_SoDienThoai LIKE N'%' + @TuKhoa + N'%')
                  AND (@TrangThai = N'' OR cn.CN_TrangThai = @TrangThai)
                ORDER BY cn.CN_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = kw},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) With {.Value = st}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(MapRowToDTO(row))
            Next
            Return ds
        End Function

        Private Shared Function MapRowToDTO(row As DataRow) As ChiNhanhDTO
            Dim dto As New ChiNhanhDTO()
            dto.MaCN = Convert.ToInt32(row("CN_Ma"))
            dto.TenCN = If(IsDBNull(row("CN_Ten")), String.Empty, row("CN_Ten").ToString())
            dto.DiaChi = If(IsDBNull(row("CN_DiaChi")), String.Empty, row("CN_DiaChi").ToString())
            dto.SoDienThoai = If(IsDBNull(row("CN_SoDienThoai")), String.Empty, row("CN_SoDienThoai").ToString())
            If Not IsDBNull(row("CN_NguoiQuanLy")) Then
                dto.NguoiQuanLy = Convert.ToInt32(row("CN_NguoiQuanLy"))
            End If
            dto.TenNguoiQuanLy = If(IsDBNull(row("TenQuanLy")), "(Chưa gán)", row("TenQuanLy").ToString())
            dto.SucChua = If(IsDBNull(row("CN_SucChua")), 50, Convert.ToInt32(row("CN_SucChua")))
            dto.GioMoCua = If(IsDBNull(row("CN_GioMoCua")), "07:00 - 22:00", row("CN_GioMoCua").ToString())
            dto.MoTa = If(IsDBNull(row("CN_MoTa")), String.Empty, row("CN_MoTa").ToString())
            dto.TrangThai = If(IsDBNull(row("CN_TrangThai")), "Đang mở cửa", row("CN_TrangThai").ToString())
            dto.Xoa = If(IsDBNull(row("CN_Xoa")), False, Convert.ToBoolean(row("CN_Xoa")))
            Return dto
        End Function

        Public Shared Function LayTheoMa(maCN As Integer) As ChiNhanhDTO
            Dim sql As String = "
                SELECT cn.CN_Ma, cn.CN_Ten, cn.CN_DiaChi, cn.CN_SoDienThoai, cn.CN_NguoiQuanLy,
                       nv.NV_HoTen AS TenQuanLy, cn.CN_SucChua, cn.CN_GioMoCua, cn.CN_MoTa, cn.CN_TrangThai, cn.CN_Xoa
                FROM ChiNhanh cn
                LEFT JOIN NhanVien nv ON cn.CN_NguoiQuanLy = nv.NV_Ma
                WHERE cn.CN_Ma = @MaCN AND cn.CN_Xoa = 0;"

            Dim prms As SqlParameter() = {New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = maCN}}
            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            If dt.Rows.Count > 0 Then
                Return MapRowToDTO(dt.Rows(0))
            End If
            Return Nothing
        End Function

        Public Shared Function KiemTraTrungTen(tenCN As String, maCNApDung As Integer) As Boolean
            Dim sql As String = "
                SELECT COUNT(1) FROM ChiNhanh
                WHERE CN_Ten = @TenCN AND CN_Ma <> @MaCN AND CN_Xoa = 0;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@TenCN", SqlDbType.NVarChar, 100) With {.Value = tenCN.Trim()},
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = maCNApDung}
            }
            Dim count As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return Convert.ToInt32(count) > 0
        End Function

        Public Shared Function Them(dto As ChiNhanhDTO) As Integer
            Dim sql As String = "
                INSERT INTO ChiNhanh (CN_Ten, CN_DiaChi, CN_SoDienThoai, CN_NguoiQuanLy, CN_SucChua, CN_GioMoCua, CN_MoTa, CN_TrangThai, CN_Xoa)
                VALUES (@Ten, @DiaChi, @SDT, @QuanLy, @SucChua, @GioMoCua, @MoTa, @TrangThai, 0);
                SELECT SCOPE_IDENTITY();"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenCN.Trim()},
                New SqlParameter("@DiaChi", SqlDbType.NVarChar, 255) With {.Value = dto.DiaChi.Trim()},
                New SqlParameter("@SDT", SqlDbType.NVarChar, 20) With {.Value = If(String.IsNullOrWhiteSpace(dto.SoDienThoai), DBNull.Value, CObj(dto.SoDienThoai.Trim()))},
                New SqlParameter("@QuanLy", SqlDbType.Int) With {.Value = If(dto.NguoiQuanLy.HasValue, CObj(dto.NguoiQuanLy.Value), DBNull.Value)},
                New SqlParameter("@SucChua", SqlDbType.Int) With {.Value = dto.SucChua},
                New SqlParameter("@GioMoCua", SqlDbType.NVarChar, 50) With {.Value = If(String.IsNullOrWhiteSpace(dto.GioMoCua), "07:00 - 22:00", dto.GioMoCua.Trim())},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), DBNull.Value, CObj(dto.MoTa.Trim()))},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
            Return 0
        End Function

        Public Shared Function CapNhat(dto As ChiNhanhDTO) As Boolean
            Dim sql As String = "
                UPDATE ChiNhanh SET
                    CN_Ten = @Ten,
                    CN_DiaChi = @DiaChi,
                    CN_SoDienThoai = @SDT,
                    CN_NguoiQuanLy = @QuanLy,
                    CN_SucChua = @SucChua,
                    CN_GioMoCua = @GioMoCua,
                    CN_MoTa = @MoTa,
                    CN_TrangThai = @TrangThai
                WHERE CN_Ma = @MaCN AND CN_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenCN.Trim()},
                New SqlParameter("@DiaChi", SqlDbType.NVarChar, 255) With {.Value = dto.DiaChi.Trim()},
                New SqlParameter("@SDT", SqlDbType.NVarChar, 20) With {.Value = If(String.IsNullOrWhiteSpace(dto.SoDienThoai), DBNull.Value, CObj(dto.SoDienThoai.Trim()))},
                New SqlParameter("@QuanLy", SqlDbType.Int) With {.Value = If(dto.NguoiQuanLy.HasValue, CObj(dto.NguoiQuanLy.Value), DBNull.Value)},
                New SqlParameter("@SucChua", SqlDbType.Int) With {.Value = dto.SucChua},
                New SqlParameter("@GioMoCua", SqlDbType.NVarChar, 50) With {.Value = If(String.IsNullOrWhiteSpace(dto.GioMoCua), "07:00 - 22:00", dto.GioMoCua.Trim())},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), DBNull.Value, CObj(dto.MoTa.Trim()))},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()},
                New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = dto.MaCN}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Public Shared Function Xoa(maCN As Integer) As Boolean
            Dim sql As String = "UPDATE ChiNhanh SET CN_Xoa = 1 WHERE CN_Ma = @MaCN;"
            Dim prms As SqlParameter() = {New SqlParameter("@MaCN", SqlDbType.Int) With {.Value = maCN}}
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Public Shared Function LayDanhSachQuanLy() As DataTable
            Dim sql As String = "
                SELECT NV_Ma, NV_HoTen + ' (' + ISNULL(NV_ViTri, N'Nhân viên') + ')' AS DisplayText
                FROM NhanVien
                WHERE NV_Xoa = 0 AND NV_TrangThai = N'Đang làm việc'
                ORDER BY NV_Ma ASC;"
            Return KetNoiCSDL.ExecuteQuery(sql)
        End Function

    End Class

End Namespace
