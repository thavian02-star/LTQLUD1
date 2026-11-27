Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng ChiTietHoaDon.
    ''' Quản lý việc gọi món, cập nhật số lượng, trạng thái chế biến bếp và hủy món.
    ''' </summary>
    Public Class ChiTietHoaDonDAO

        ''' <summary>
        ''' Lấy danh sách món ăn đã gọi của một hóa đơn (không lấy món đã hủy).
        ''' </summary>
        Public Shared Function LayDanhSachTheoHoaDon(maHD As Integer) As List(Of ChiTietHoaDonDTO)
            Dim ds As New List(Of ChiTietHoaDonDTO)()
            Dim sql As String = "
                SELECT cthd.*, ma.MA_Ten AS TenMonAn, dm.DM_Ten AS TenDanhMuc
                FROM ChiTietHoaDon cthd
                INNER JOIN MonAn ma ON ma.MA_Ma = cthd.CTHD_MaMonAn
                LEFT JOIN DanhMuc dm ON dm.DM_Ma = ma.MA_DanhMuc
                WHERE cthd.CTHD_Xoa = 0 
                  AND cthd.CTHD_TrangThaiMon <> 3
                  AND cthd.CTHD_MaHoaDon = @MaHD
                ORDER BY cthd.CTHD_ThoiGianGoi ASC, cthd.CTHD_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaHD", SqlDbType.Int) With {.Value = maHD}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(ChuyenDataRowThanhDTO(row))
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Thêm món vào hóa đơn: Nếu món chưa làm đã tồn tại cùng ghi chú thì cộng dồn số lượng, ngược lại thêm dòng mới.
        ''' </summary>
        Public Shared Function ThemMon(maHD As Integer, maMonAn As Integer, soLuong As Integer,
                                       donGia As Decimal, ghiChu As String) As Integer
            Dim sql As String = "
                INSERT INTO ChiTietHoaDon (CTHD_MaHoaDon, CTHD_MaMonAn, CTHD_SoLuong, CTHD_DonGia, CTHD_GhiChu, CTHD_ThoiGianGoi, CTHD_TrangThaiMon, CTHD_Xoa)
                VALUES (@MaHD, @MaMonAn, @SoLuong, @DonGia, @GhiChu, GETDATE(), 0, 0);
                SELECT SCOPE_IDENTITY();"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaHD", SqlDbType.Int) With {.Value = maHD},
                New SqlParameter("@MaMonAn", SqlDbType.Int) With {.Value = maMonAn},
                New SqlParameter("@SoLuong", SqlDbType.Int) With {.Value = soLuong},
                New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Value = donGia},
                New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrWhiteSpace(ghiChu), CObj(DBNull.Value), ghiChu.Trim())}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq IsNot Nothing AndAlso Not IsDBNull(kq) Then
                Return Convert.ToInt32(kq)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Hủy món ăn trong hóa đơn: Chỉ cho phép hủy khi món còn ở trạng thái 0 (Chờ thực hiện).
        ''' </summary>
        Public Shared Function HuyMon(maCTHD As Integer) As Boolean
            Dim sql As String = "
                UPDATE ChiTietHoaDon 
                SET CTHD_TrangThaiMon = 3 
                WHERE CTHD_Ma = @MaCTHD AND CTHD_TrangThaiMon = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCTHD", SqlDbType.Int) With {.Value = maCTHD}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Cập nhật trạng thái chế biến của món ăn (0: Chờ thực hiện, 1: Đã nấu xong, 2: Đã mang ra).
        ''' </summary>
        Public Shared Function CapNhatTrangThaiMon(maCTHD As Integer, trangThaiMoi As Integer) As Boolean
            Dim sql As String = "UPDATE ChiTietHoaDon SET CTHD_TrangThaiMon = @TrangThai WHERE CTHD_Ma = @MaCTHD;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = trangThaiMoi},
                New SqlParameter("@MaCTHD", SqlDbType.Int) With {.Value = maCTHD}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Private Shared Function ChuyenDataRowThanhDTO(row As DataRow) As ChiTietHoaDonDTO
            Dim dto As New ChiTietHoaDonDTO()
            dto.CTHD_Ma = Convert.ToInt32(row("CTHD_Ma"))
            dto.CTHD_MaHoaDon = Convert.ToInt32(row("CTHD_MaHoaDon"))
            dto.CTHD_MaMonAn = Convert.ToInt32(row("CTHD_MaMonAn"))
            dto.CTHD_SoLuong = Convert.ToInt32(row("CTHD_SoLuong"))
            dto.CTHD_DonGia = Convert.ToDecimal(row("CTHD_DonGia"))
            If Not IsDBNull(row("CTHD_GhiChu")) Then dto.CTHD_GhiChu = row("CTHD_GhiChu").ToString()
            dto.CTHD_ThoiGianGoi = Convert.ToDateTime(row("CTHD_ThoiGianGoi"))
            dto.CTHD_TrangThaiMon = Convert.ToInt32(row("CTHD_TrangThaiMon"))
            dto.CTHD_Xoa = Convert.ToBoolean(row("CTHD_Xoa"))
            If row.Table.Columns.Contains("TenMonAn") AndAlso Not IsDBNull(row("TenMonAn")) Then
                dto.TenMonAn = row("TenMonAn").ToString()
            End If
            If row.Table.Columns.Contains("TenDanhMuc") AndAlso Not IsDBNull(row("TenDanhMuc")) Then
                dto.TenDanhMuc = row("TenDanhMuc").ToString()
            End If
            Return dto
        End Function

    End Class

End Namespace
