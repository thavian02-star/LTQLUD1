Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng KhuVuc và liên kết bảng Ban.
    ''' Sử dụng 100% Parameterized SQL qua KetNoiCSDL.
    ''' </summary>
    Public Class KhuVucDAO

        ''' <summary>
        ''' Lấy danh sách các khu vực đang hoạt động (KV_Xoa = 0) kèm số lượng bàn và tổng sức chứa.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "") As List(Of KhuVucDTO)
            Dim ds As New List(Of KhuVucDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()

            Dim sql As String = "
                SELECT 
                    kv.KV_Ma,
                    kv.KV_Ten,
                    kv.KV_MoTa,
                    kv.KV_Xoa,
                    ISNULL(COUNT(b.B_Ma), 0) AS SoLuongBan,
                    ISNULL(SUM(b.B_SoNguoiToiDa), 0) AS TongSucChua
                FROM KhuVuc kv
                LEFT JOIN Ban b ON kv.KV_Ten = b.B_KhuVuc AND b.B_Xoa = 0
                WHERE kv.KV_Xoa = 0
                  AND (@TuKhoa = N'' OR kv.KV_Ten LIKE N'%' + @TuKhoa + N'%' OR kv.KV_MoTa LIKE N'%' + @TuKhoa + N'%')
                GROUP BY kv.KV_Ma, kv.KV_Ten, kv.KV_MoTa, kv.KV_Xoa
                ORDER BY kv.KV_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                Dim item As New KhuVucDTO() With {
                    .KV_Ma = Convert.ToInt32(row("KV_Ma")),
                    .KV_Ten = If(IsDBNull(row("KV_Ten")), String.Empty, row("KV_Ten").ToString()),
                    .KV_MoTa = If(IsDBNull(row("KV_MoTa")), String.Empty, row("KV_MoTa").ToString()),
                    .KV_Xoa = If(IsDBNull(row("KV_Xoa")), False, Convert.ToBoolean(row("KV_Xoa"))),
                    .SoLuongBan = If(IsDBNull(row("SoLuongBan")), 0, Convert.ToInt32(row("SoLuongBan"))),
                    .TongSucChua = If(IsDBNull(row("TongSucChua")), 0, Convert.ToInt32(row("TongSucChua")))
                }
                ds.Add(item)
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Lấy thông tin chi tiết một khu vực theo mã định danh.
        ''' </summary>
        Public Shared Function LayTheoMa(ma As Integer) As KhuVucDTO
            Dim sql As String = "
                SELECT 
                    kv.KV_Ma,
                    kv.KV_Ten,
                    kv.KV_MoTa,
                    kv.KV_Xoa,
                    ISNULL(COUNT(b.B_Ma), 0) AS SoLuongBan,
                    ISNULL(SUM(b.B_SoNguoiToiDa), 0) AS TongSucChua
                FROM KhuVuc kv
                LEFT JOIN Ban b ON kv.KV_Ten = b.B_KhuVuc AND b.B_Xoa = 0
                WHERE kv.KV_Ma = @Ma
                GROUP BY kv.KV_Ma, kv.KV_Ten, kv.KV_MoTa, kv.KV_Xoa;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = ma}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                Return New KhuVucDTO() With {
                    .KV_Ma = Convert.ToInt32(row("KV_Ma")),
                    .KV_Ten = If(IsDBNull(row("KV_Ten")), String.Empty, row("KV_Ten").ToString()),
                    .KV_MoTa = If(IsDBNull(row("KV_MoTa")), String.Empty, row("KV_MoTa").ToString()),
                    .KV_Xoa = If(IsDBNull(row("KV_Xoa")), False, Convert.ToBoolean(row("KV_Xoa"))),
                    .SoLuongBan = If(IsDBNull(row("SoLuongBan")), 0, Convert.ToInt32(row("SoLuongBan"))),
                    .TongSucChua = If(IsDBNull(row("TongSucChua")), 0, Convert.ToInt32(row("TongSucChua")))
                }
            End If

            Return Nothing
        End Function

        ''' <summary>
        ''' Kiểm tra tên khu vực đã tồn tại trong các bản ghi đang hoạt động (KV_Xoa = 0) chưa.
        ''' </summary>
        Public Shared Function KiemTraTrungTen(ten As String, Optional maLoaiTru As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(1) 
                FROM KhuVuc 
                WHERE LOWER(LTRIM(RTRIM(KV_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                  AND KV_Xoa = 0
                  AND (@MaLoaiTru = 0 OR KV_Ma <> @MaLoaiTru);"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = ten.Trim()},
                New SqlParameter("@MaLoaiTru", SqlDbType.Int) With {.Value = maLoaiTru}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result) > 0
            End If
            Return False
        End Function

        ''' <summary>
        ''' Tìm mã KV_Ma của khu vực đã bị xóa mềm có cùng tên (nếu có) để hỗ trợ khôi phục.
        ''' </summary>
        Public Shared Function TimMaKhuVucDaXoaTheoTen(ten As String) As Integer
            Dim sql As String = "
                SELECT TOP 1 KV_Ma 
                FROM KhuVuc 
                WHERE LOWER(LTRIM(RTRIM(KV_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                  AND KV_Xoa = 1;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = ten.Trim()}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Đếm số lượng bàn ăn đang hoạt động (Ban.B_Xoa = 0) thuộc một khu vực theo tên.
        ''' </summary>
        Public Shared Function DemSoBanThuocKhuVuc(tenKhuVuc As String) As Integer
            Dim sql As String = "
                SELECT COUNT(1) 
                FROM Ban 
                WHERE B_KhuVuc = @TenKhuVuc 
                  AND B_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TenKhuVuc", SqlDbType.NVarChar, 50) With {.Value = tenKhuVuc.Trim()}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                Return Convert.ToInt32(result)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Thêm mới một khu vực bàn vào CSDL.
        ''' </summary>
        Public Shared Function ThemKhuVuc(dto As KhuVucDTO) As Boolean
            Dim sql As String = "
                INSERT INTO KhuVuc (KV_Ten, KV_MoTa, KV_Xoa)
                VALUES (@Ten, @MoTa, 0);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.KV_Ten.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.KV_MoTa), DBNull.Value, CObj(dto.KV_MoTa.Trim()))}
            }

            Dim newId As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If newId IsNot Nothing AndAlso Not IsDBNull(newId) Then
                dto.KV_Ma = Convert.ToInt32(newId)
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Cập nhật thông tin khu vực bàn và Cascade Update đồng bộ tên bàn trong bảng Ban nếu tên khu vực thay đổi.
        ''' </summary>
        Public Shared Function CapNhatKhuVuc(dto As KhuVucDTO, tenCu As String) As Boolean
            Dim sql As String = "
                UPDATE KhuVuc 
                SET KV_Ten = @TenMoi,
                    KV_MoTa = @MoTa
                WHERE KV_Ma = @Ma AND KV_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TenMoi", SqlDbType.NVarChar, 50) With {.Value = dto.KV_Ten.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.KV_MoTa), DBNull.Value, CObj(dto.KV_MoTa.Trim()))},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = dto.KV_Ma}
            }

            Dim rows As Integer = KetNoiCSDL.ExecuteNonQuery(sql, prms)
            If rows > 0 Then
                ' Tự động đồng bộ tên khu vực mới cho các bàn trong bảng Ban nếu đổi tên
                If Not String.IsNullOrWhiteSpace(tenCu) AndAlso Not tenCu.Trim().Equals(dto.KV_Ten.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    Dim sqlSync As String = "UPDATE Ban SET B_KhuVuc = @TenMoi WHERE B_KhuVuc = @TenCu;"
                    Dim prmsSync As SqlParameter() = {
                        New SqlParameter("@TenMoi", SqlDbType.NVarChar, 50) With {.Value = dto.KV_Ten.Trim()},
                        New SqlParameter("@TenCu", SqlDbType.NVarChar, 50) With {.Value = tenCu.Trim()}
                    }
                    KetNoiCSDL.ExecuteNonQuery(sqlSync, prmsSync)
                End If
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Khôi phục bản ghi đã xóa mềm (KV_Xoa = 1) và cập nhật thông tin mới.
        ''' </summary>
        Public Shared Function KhoiPhucKhuVuc(ma As Integer, dto As KhuVucDTO) As Boolean
            Dim sql As String = "
                UPDATE KhuVuc 
                SET KV_Ten = @Ten,
                    KV_MoTa = @MoTa,
                    KV_Xoa = 0
                WHERE KV_Ma = @Ma;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.KV_Ten.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.KV_MoTa), DBNull.Value, CObj(dto.KV_MoTa.Trim()))},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = ma}
            }

            Dim rows As Integer = KetNoiCSDL.ExecuteNonQuery(sql, prms)
            If rows > 0 Then
                dto.KV_Ma = ma
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Xóa mềm khu vực bàn (KV_Xoa = 1).
        ''' </summary>
        Public Shared Function XoaMemKhuVuc(ma As Integer) As Boolean
            Dim sql As String = "UPDATE KhuVuc SET KV_Xoa = 1 WHERE KV_Ma = @Ma;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = ma}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

    End Class

End Namespace
