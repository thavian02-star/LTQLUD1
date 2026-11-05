Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO
    ''' <summary>
    ''' Lớp truy xuất dữ liệu (DAO) cho bảng DanhMuc.
    ''' Sử dụng Parameterized Query chống SQL Injection và đếm số món ăn thuộc từng danh mục.
    ''' </summary>
    Public Class DanhMucDAO

        ''' <summary>
        ''' Lấy danh sách các danh mục đang hoạt động (DM_Xoa = 0) kèm số lượng món ăn (MA_Xoa = 0).
        ''' Hỗ trợ lọc theo từ khóa tên danh mục hoặc mô tả.
        ''' </summary>
        Public Function LayDanhSach(Optional tuKhoa As String = "") As List(Of DanhMucDTO)
            Dim danhSach As New List(Of DanhMucDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()

            Dim sql As String = "
                SELECT dm.DM_Ma,
                       dm.DM_Ten,
                       ISNULL(dm.DM_MoTa, N'') AS DM_MoTa,
                       dm.DM_Xoa,
                       COUNT(ma.MA_Ma) AS SoLuongMon
                FROM DanhMuc dm
                LEFT JOIN MonAn ma ON ma.MA_DanhMuc = dm.DM_Ma AND ma.MA_Xoa = 0
                WHERE dm.DM_Xoa = 0
                  AND (@TuKhoa = N'' OR dm.DM_Ten LIKE N'%' + @TuKhoa + N'%' OR ISNULL(dm.DM_MoTa, N'') LIKE N'%' + @TuKhoa + N'%')
                GROUP BY dm.DM_Ma, dm.DM_Ten, dm.DM_MoTa, dm.DM_Xoa
                ORDER BY dm.DM_Ma ASC;"

            Dim params As SqlParameter() = {
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, params)
            For Each row As DataRow In dt.Rows
                Dim item As New DanhMucDTO() With {
                    .MaDanhMuc = Convert.ToInt32(row("DM_Ma")),
                    .TenDanhMuc = row("DM_Ten").ToString().Trim(),
                    .MoTa = row("DM_MoTa").ToString().Trim(),
                    .SoLuongMon = Convert.ToInt32(row("SoLuongMon")),
                    .Xoa = Convert.ToBoolean(row("DM_Xoa"))
                }
                danhSach.Add(item)
            Next

            Return danhSach
        End Function

        ''' <summary>
        ''' Kiểm tra tên danh mục có bị trùng với danh mục đang hoạt động khác hay không.
        ''' </summary>
        Public Function KiemTraTrungTen(tenDanhMuc As String, Optional maLoaiTru As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(1)
                FROM DanhMuc
                WHERE DM_Xoa = 0
                  AND LOWER(LTRIM(RTRIM(DM_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                  AND DM_Ma <> @MaLoaiTru;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenDanhMuc.Trim()},
                New SqlParameter("@MaLoaiTru", SqlDbType.Int) With {.Value = maLoaiTru}
            }

            Dim count As Integer = Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, params))
            Return count > 0
        End Function

        ''' <summary>
        ''' Tìm mã danh mục đã xóa mềm (DM_Xoa = 1) có cùng tên để khôi phục lại nếu cần.
        ''' </summary>
        Public Function TimMaDanhMucDaXoaTheoTen(tenDanhMuc As String) As Integer
            Dim sql As String = "
                SELECT TOP 1 DM_Ma
                FROM DanhMuc
                WHERE DM_Xoa = 1
                  AND LOWER(LTRIM(RTRIM(DM_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                ORDER BY DM_Ma DESC;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenDanhMuc.Trim()}
            }

            Dim obj As Object = KetNoiCSDL.ExecuteScalar(sql, params)
            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                Return Convert.ToInt32(obj)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Đếm số lượng món ăn đang hoạt động (MA_Xoa = 0) thuộc danh mục chỉ định.
        ''' </summary>
        Public Function DemSoMonTrongDanhMuc(maDanhMuc As Integer) As Integer
            Dim sql As String = "
                SELECT COUNT(1)
                FROM MonAn
                WHERE MA_DanhMuc = @MaDM AND MA_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = maDanhMuc}
            }

            Return Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, params))
        End Function

        ''' <summary>
        ''' Thêm mới một danh mục vào bảng DanhMuc và trả về mã DM_Ma vừa sinh.
        ''' </summary>
        Public Function ThemDanhMuc(dto As DanhMucDTO) As Integer
            Dim sql As String = "
                INSERT INTO DanhMuc (DM_Ten, DM_MoTa, DM_Xoa)
                VALUES (@Ten, @MoTa, 0);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenDanhMuc.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), CType(DBNull.Value, Object), dto.MoTa.Trim())}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, params)
            Return Convert.ToInt32(result)
        End Function

        ''' <summary>
        ''' Khôi phục danh mục đã xóa mềm (DM_Xoa = 1 -> 0) và cập nhật lại tên, mô tả chuẩn.
        ''' </summary>
        Public Function KhoiPhucDanhMuc(maDanhMuc As Integer, tenChuan As String, moTaMoi As String) As Boolean
            Dim sql As String = "
                UPDATE DanhMuc
                SET DM_Ten = @Ten,
                    DM_MoTa = @MoTa,
                    DM_Xoa = 0
                WHERE DM_Ma = @Ma;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenChuan.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(moTaMoi), CType(DBNull.Value, Object), moTaMoi.Trim())},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maDanhMuc}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

        ''' <summary>
        ''' Cập nhật tên và mô tả cho danh mục đang hoạt động.
        ''' </summary>
        Public Function CapNhatDanhMuc(dto As DanhMucDTO) As Boolean
            Dim sql As String = "
                UPDATE DanhMuc
                SET DM_Ten = @Ten,
                    DM_MoTa = @MoTa
                WHERE DM_Ma = @Ma AND DM_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenDanhMuc.Trim()},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), CType(DBNull.Value, Object), dto.MoTa.Trim())},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = dto.MaDanhMuc}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

        ''' <summary>
        ''' Xóa mềm danh mục (đánh dấu DM_Xoa = 1).
        ''' </summary>
        Public Function XoaMemDanhMuc(maDanhMuc As Integer) As Boolean
            Dim sql As String = "
                UPDATE DanhMuc
                SET DM_Xoa = 1
                WHERE DM_Ma = @Ma AND DM_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maDanhMuc}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

    End Class
End Namespace
