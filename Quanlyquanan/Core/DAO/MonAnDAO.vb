Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO
    ''' <summary>
    ''' Lớp truy xuất dữ liệu (DAO) cho bảng MonAn.
    ''' Sử dụng Parameterized Query chống SQL Injection, kết nối khóa ngoại DanhMuc và kiểm tra ràng buộc HoaDon đang phục vụ.
    ''' </summary>
    Public Class MonAnDAO

        ''' <summary>
        ''' Lấy danh sách món ăn đang kinh doanh (MA_Xoa = 0) kèm tên danh mục (DM_Ten).
        ''' Hỗ trợ lọc đa chiều theo: Từ khóa (tuKhoa), Mã danh mục (maDanhMuc = 0 là tất cả),
        ''' và Trạng thái hết món (trangThaiHetMon = -1 là tất cả, 0 = Còn món, 1 = Hết món).
        ''' </summary>
        Public Function LayDanhSach(Optional tuKhoa As String = "",
                                    Optional maDanhMuc As Integer = 0,
                                    Optional trangThaiHetMon As Integer = -1) As List(Of MonAnDTO)
            Dim danhSach As New List(Of MonAnDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()

            Dim sql As String = "
                SELECT ma.MA_Ma,
                       ma.MA_Ten,
                       ma.MA_DanhMuc,
                       dm.DM_Ten,
                       ma.MA_DonGia,
                       ma.MA_HetMon,
                       ISNULL(ma.MA_MoTa, N'') AS MA_MoTa,
                       ma.MA_Xoa
                FROM MonAn ma
                INNER JOIN DanhMuc dm ON dm.DM_Ma = ma.MA_DanhMuc AND dm.DM_Xoa = 0
                WHERE ma.MA_Xoa = 0
                  AND (@MaDM = 0 OR ma.MA_DanhMuc = @MaDM)
                  AND (@TrangThai = -1 OR ma.MA_HetMon = CASE WHEN @TrangThai = 1 THEN 1 ELSE 0 END)
                  AND (@TuKhoa = N'' OR ma.MA_Ten LIKE N'%' + @TuKhoa + N'%' OR ISNULL(ma.MA_MoTa, N'') LIKE N'%' + @TuKhoa + N'%')
                ORDER BY ma.MA_Ma ASC;"

            Dim params As SqlParameter() = {
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = maDanhMuc},
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = trangThaiHetMon},
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, params)
            For Each row As DataRow In dt.Rows
                Dim item As New MonAnDTO() With {
                    .MaMonAn = Convert.ToInt32(row("MA_Ma")),
                    .TenMonAn = row("MA_Ten").ToString().Trim(),
                    .MaDanhMuc = Convert.ToInt32(row("MA_DanhMuc")),
                    .TenDanhMuc = row("DM_Ten").ToString().Trim(),
                    .DonGia = Convert.ToDecimal(row("MA_DonGia")),
                    .HetMon = Convert.ToBoolean(row("MA_HetMon")),
                    .MoTa = row("MA_MoTa").ToString().Trim(),
                    .Xoa = Convert.ToBoolean(row("MA_Xoa"))
                }
                danhSach.Add(item)
            Next

            Return danhSach
        End Function

        ''' <summary>
        ''' Kiểm tra tên món ăn có bị trùng với món đang hoạt động khác (MA_Xoa = 0) hay không.
        ''' </summary>
        Public Function KiemTraTrungTen(tenMonAn As String, Optional maLoaiTru As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(1)
                FROM MonAn
                WHERE MA_Xoa = 0
                  AND LOWER(LTRIM(RTRIM(MA_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                  AND MA_Ma <> @MaLoaiTru;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenMonAn.Trim()},
                New SqlParameter("@MaLoaiTru", SqlDbType.Int) With {.Value = maLoaiTru}
            }

            Dim count As Integer = Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, params))
            Return count > 0
        End Function

        ''' <summary>
        ''' Tìm mã món ăn đã xóa mềm (MA_Xoa = 1) có cùng tên để tự động khôi phục lại.
        ''' </summary>
        Public Function TimMaMonDaXoaTheoTen(tenMonAn As String) As Integer
            Dim sql As String = "
                SELECT TOP 1 MA_Ma
                FROM MonAn
                WHERE MA_Xoa = 1
                  AND LOWER(LTRIM(RTRIM(MA_Ten))) = LOWER(LTRIM(RTRIM(@Ten)))
                ORDER BY MA_Ma DESC;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenMonAn.Trim()}
            }

            Dim obj As Object = KetNoiCSDL.ExecuteScalar(sql, params)
            If obj IsNot Nothing AndAlso obj IsNot DBNull.Value Then
                Return Convert.ToInt32(obj)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Kiểm tra mã danh mục có tồn tại và đang hoạt động (DM_Xoa = 0) hay không.
        ''' </summary>
        Public Function KiemTraDanhMucHopLe(maDanhMuc As Integer) As Boolean
            Dim sql As String = "
                SELECT COUNT(1)
                FROM DanhMuc
                WHERE DM_Ma = @MaDM AND DM_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = maDanhMuc}
            }

            Return Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, params)) > 0
        End Function

        ''' <summary>
        ''' Đếm số lượt gọi của món ăn này trong các hóa đơn ĐANG PHỤC VỤ (HD_TrangThai = 0, CTHD_TrangThaiMon <> 3).
        ''' Nếu > 0 thì chặn xóa để bảo vệ phiên phục vụ tại bàn.
        ''' </summary>
        Public Function DemSoLuotDangPhucVu(maMonAn As Integer) As Integer
            Dim sql As String = "
                SELECT COUNT(1)
                FROM ChiTietHoaDon cthd
                INNER JOIN HoaDon hd ON hd.HD_Ma = cthd.CTHD_MaHoaDon
                WHERE cthd.CTHD_MaMonAn = @MaMon
                  AND cthd.CTHD_Xoa = 0
                  AND cthd.CTHD_TrangThaiMon <> 3
                  AND hd.HD_Xoa = 0
                  AND hd.HD_TrangThai = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@MaMon", SqlDbType.Int) With {.Value = maMonAn}
            }

            Return Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, params))
        End Function

        ''' <summary>
        ''' Thêm mới một món ăn vào bảng MonAn và trả về mã MA_Ma vừa sinh.
        ''' </summary>
        Public Function ThemMonAn(dto As MonAnDTO) As Integer
            Dim sql As String = "
                INSERT INTO MonAn (MA_Ten, MA_DanhMuc, MA_DonGia, MA_HetMon, MA_MoTa, MA_Xoa)
                VALUES (@Ten, @MaDM, @DonGia, @HetMon, @MoTa, 0);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenMonAn.Trim()},
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = dto.MaDanhMuc},
                New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.DonGia},
                New SqlParameter("@HetMon", SqlDbType.Bit) With {.Value = dto.HetMon},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), CType(DBNull.Value, Object), dto.MoTa.Trim())}
            }

            Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, params)
            Return Convert.ToInt32(result)
        End Function

        ''' <summary>
        ''' Khôi phục món ăn đã xóa mềm (MA_Xoa = 1 -> 0) và cập nhật thông tin mới.
        ''' </summary>
        Public Function KhoiPhucMonAn(maMonAn As Integer, dto As MonAnDTO) As Boolean
            Dim sql As String = "
                UPDATE MonAn
                SET MA_Ten = @Ten,
                    MA_DanhMuc = @MaDM,
                    MA_DonGia = @DonGia,
                    MA_HetMon = @HetMon,
                    MA_MoTa = @MoTa,
                    MA_Xoa = 0
                WHERE MA_Ma = @Ma;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenMonAn.Trim()},
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = dto.MaDanhMuc},
                New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.DonGia},
                New SqlParameter("@HetMon", SqlDbType.Bit) With {.Value = dto.HetMon},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), CType(DBNull.Value, Object), dto.MoTa.Trim())},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maMonAn}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

        ''' <summary>
        ''' Cập nhật thông tin món ăn đang hoạt động.
        ''' </summary>
        Public Function CapNhatMonAn(dto As MonAnDTO) As Boolean
            Dim sql As String = "
                UPDATE MonAn
                SET MA_Ten = @Ten,
                    MA_DanhMuc = @MaDM,
                    MA_DonGia = @DonGia,
                    MA_HetMon = @HetMon,
                    MA_MoTa = @MoTa
                WHERE MA_Ma = @Ma AND MA_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenMonAn.Trim()},
                New SqlParameter("@MaDM", SqlDbType.Int) With {.Value = dto.MaDanhMuc},
                New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Precision = 18, .Scale = 2, .Value = dto.DonGia},
                New SqlParameter("@HetMon", SqlDbType.Bit) With {.Value = dto.HetMon},
                New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(dto.MoTa), CType(DBNull.Value, Object), dto.MoTa.Trim())},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = dto.MaMonAn}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

        ''' <summary>
        ''' Cập nhật nhanh cờ Báo hết món (MA_HetMon).
        ''' </summary>
        Public Function CapNhatTrangThaiHetMon(maMonAn As Integer, hetMon As Boolean) As Boolean
            Dim sql As String = "
                UPDATE MonAn
                SET MA_HetMon = @HetMon
                WHERE MA_Ma = @Ma AND MA_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@HetMon", SqlDbType.Bit) With {.Value = hetMon},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maMonAn}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

        ''' <summary>
        ''' Xóa mềm món ăn (đánh dấu MA_Xoa = 1).
        ''' </summary>
        Public Function XoaMemMonAn(maMonAn As Integer) As Boolean
            Dim sql As String = "
                UPDATE MonAn
                SET MA_Xoa = 1
                WHERE MA_Ma = @Ma AND MA_Xoa = 0;"

            Dim params As SqlParameter() = {
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maMonAn}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
        End Function

    End Class
End Namespace
