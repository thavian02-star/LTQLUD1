Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng CaLamViec.
    ''' Sử dụng 100% Parameterized SQL qua KetNoiCSDL.
    ''' </summary>
    Public Class CaLamViecDAO

        ''' <summary>
        ''' Lấy danh sách các ca làm việc đang hoạt động (CA_Xoa = 0) kèm số lượt xếp lịch.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "") As List(Of CaLamViecDTO)
            Dim ds As New List(Of CaLamViecDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()

            Dim sql As String = "
                SELECT 
                    ca.CA_Ma,
                    ca.CA_Ten,
                    ca.CA_GioBatDau,
                    ca.CA_GioKetThuc,
                    ca.CA_LuongMoiCa,
                    ca.CA_Xoa,
                    COUNT(llv.LLV_Ma) AS SoLuotXepLich
                FROM CaLamViec ca
                LEFT JOIN LichLamViec llv ON llv.LLV_MaCa = ca.CA_Ma AND llv.LLV_Xoa = 0
                WHERE ca.CA_Xoa = 0
                  AND (@TuKhoa = N'' OR ca.CA_Ten LIKE N'%' + @TuKhoa + N'%')
                GROUP BY ca.CA_Ma, ca.CA_Ten, ca.CA_GioBatDau, ca.CA_GioKetThuc, ca.CA_LuongMoiCa, ca.CA_Xoa
                ORDER BY ca.CA_GioBatDau ASC, ca.CA_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 50) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                Dim gioBD As TimeSpan = New TimeSpan(8, 0, 0)
                Dim gioKT As TimeSpan = New TimeSpan(15, 0, 0)

                If Not IsDBNull(row("CA_GioBatDau")) Then
                    If TypeOf row("CA_GioBatDau") Is TimeSpan Then
                        gioBD = DirectCast(row("CA_GioBatDau"), TimeSpan)
                    Else
                        TimeSpan.TryParse(row("CA_GioBatDau").ToString(), gioBD)
                    End If
                End If

                If Not IsDBNull(row("CA_GioKetThuc")) Then
                    If TypeOf row("CA_GioKetThuc") Is TimeSpan Then
                        gioKT = DirectCast(row("CA_GioKetThuc"), TimeSpan)
                    Else
                        TimeSpan.TryParse(row("CA_GioKetThuc").ToString(), gioKT)
                    End If
                End If

                Dim dto As New CaLamViecDTO() With {
                    .MaCa = Convert.ToInt32(row("CA_Ma")),
                    .TenCa = Convert.ToString(row("CA_Ten")),
                    .GioBatDau = gioBD,
                    .GioKetThuc = gioKT,
                    .LuongMoiCa = If(IsDBNull(row("CA_LuongMoiCa")), 0D, Convert.ToDecimal(row("CA_LuongMoiCa"))),
                    .SoLuotXepLich = If(IsDBNull(row("SoLuotXepLich")), 0, Convert.ToInt32(row("SoLuotXepLich"))),
                    .Xoa = Convert.ToBoolean(row("CA_Xoa"))
                }
                ds.Add(dto)
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Kiểm tra tên ca làm việc đã tồn tại trong các ca đang hoạt động (CA_Xoa = 0) hay chưa.
        ''' </summary>
        Public Shared Function KiemTraTrungTen(tenCa As String, Optional maCaLoaiTru As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(1)
                FROM CaLamViec
                WHERE CA_Xoa = 0
                  AND LOWER(LTRIM(RTRIM(CA_Ten))) = LOWER(LTRIM(RTRIM(@TenCa)))
                  AND CA_Ma <> @MaLoaiTru;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TenCa", SqlDbType.NVarChar, 50) With {.Value = tenCa.Trim()},
                New SqlParameter("@MaLoaiTru", SqlDbType.Int) With {.Value = maCaLoaiTru}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return Convert.ToInt32(kq) > 0
        End Function

        ''' <summary>
        ''' Tìm mã ca đã bị xóa mềm (CA_Xoa = 1) có cùng tên để khôi phục lại.
        ''' </summary>
        Public Shared Function TimMaCaDaXoaTheoTen(tenCa As String) As Integer
            Dim sql As String = "
                SELECT TOP 1 CA_Ma
                FROM CaLamViec
                WHERE CA_Xoa = 1
                  AND LOWER(LTRIM(RTRIM(CA_Ten))) = LOWER(LTRIM(RTRIM(@TenCa)))
                ORDER BY CA_Ma DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TenCa", SqlDbType.NVarChar, 50) With {.Value = tenCa.Trim()}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq Is Nothing OrElse IsDBNull(kq) Then
                Return 0
            End If
            Return Convert.ToInt32(kq)
        End Function

        ''' <summary>
        ''' Đếm số lượt phân công lịch làm việc đang hoạt động (LLV_Xoa = 0) của một ca.
        ''' </summary>
        Public Shared Function DemSoLichPhanCong(maCa As Integer) As Integer
            Dim sql As String = "SELECT COUNT(1) FROM LichLamViec WHERE LLV_MaCa = @MaCa AND LLV_Xoa = 0;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = maCa}
            }
            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return Convert.ToInt32(kq)
        End Function

        ''' <summary>
        ''' Đếm số hóa đơn đang hoạt động (HD_Xoa = 0) tham chiếu tới ca làm việc.
        ''' </summary>
        Public Shared Function DemSoHoaDonTheoCa(maCa As Integer) As Integer
            Dim sql As String = "SELECT COUNT(1) FROM HoaDon WHERE HD_MaCa = @MaCa AND HD_Xoa = 0;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = maCa}
            }
            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return Convert.ToInt32(kq)
        End Function

        ''' <summary>
        ''' Thêm mới một ca làm việc vào bảng CaLamViec.
        ''' </summary>
        Public Shared Function ThemCaLamViec(dto As CaLamViecDTO) As Boolean
            Dim sql As String = "
                INSERT INTO CaLamViec (CA_Ten, CA_GioBatDau, CA_GioKetThuc, CA_LuongMoiCa, CA_Xoa)
                VALUES (@Ten, @GioBatDau, @GioKetThuc, @LuongMoiCa, 0);"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenCa.Trim()},
                New SqlParameter("@GioBatDau", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioBatDau.Hours, dto.GioBatDau.Minutes, 0)},
                New SqlParameter("@GioKetThuc", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioKetThuc.Hours, dto.GioKetThuc.Minutes, 0)},
                New SqlParameter("@LuongMoiCa", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.LuongMoiCa}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Khôi phục ca đã xóa mềm (CA_Xoa = 0) và cập nhật khung giờ + định mức lương mới.
        ''' </summary>
        Public Shared Function KhoiPhucCaLamViec(maCa As Integer, dto As CaLamViecDTO) As Boolean
            Dim sql As String = "
                UPDATE CaLamViec
                SET CA_Ten = @Ten,
                    CA_GioBatDau = @GioBatDau,
                    CA_GioKetThuc = @GioKetThuc,
                    CA_LuongMoiCa = @LuongMoiCa,
                    CA_Xoa = 0
                WHERE CA_Ma = @MaCa;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenCa.Trim()},
                New SqlParameter("@GioBatDau", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioBatDau.Hours, dto.GioBatDau.Minutes, 0)},
                New SqlParameter("@GioKetThuc", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioKetThuc.Hours, dto.GioKetThuc.Minutes, 0)},
                New SqlParameter("@LuongMoiCa", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.LuongMoiCa},
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = maCa}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Cập nhật thông tin ca làm việc đang hoạt động.
        ''' </summary>
        Public Shared Function CapNhatCaLamViec(dto As CaLamViecDTO) As Boolean
            Dim sql As String = "
                UPDATE CaLamViec
                SET CA_Ten = @Ten,
                    CA_GioBatDau = @GioBatDau,
                    CA_GioKetThuc = @GioKetThuc,
                    CA_LuongMoiCa = @LuongMoiCa
                WHERE CA_Ma = @MaCa AND CA_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenCa.Trim()},
                New SqlParameter("@GioBatDau", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioBatDau.Hours, dto.GioBatDau.Minutes, 0)},
                New SqlParameter("@GioKetThuc", SqlDbType.Time) With {.Value = New TimeSpan(dto.GioKetThuc.Hours, dto.GioKetThuc.Minutes, 0)},
                New SqlParameter("@LuongMoiCa", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.LuongMoiCa},
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = dto.MaCa}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Xóa mềm ca làm việc (CA_Xoa = 1).
        ''' </summary>
        Public Shared Function XoaMemCaLamViec(maCa As Integer) As Boolean
            Dim sql As String = "UPDATE CaLamViec SET CA_Xoa = 1 WHERE CA_Ma = @MaCa;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = maCa}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

    End Class

End Namespace
