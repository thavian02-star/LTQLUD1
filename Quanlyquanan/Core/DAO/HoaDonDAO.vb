Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng HoaDon.
    ''' Quản lý phiên phục vụ, mở bàn mới, cập nhật tiền, chuyển bàn và thanh toán.
    ''' </summary>
    Public Class HoaDonDAO

        ''' <summary>
        ''' Lấy hóa đơn đang phục vụ (HD_TrangThai = 0) của một bàn cụ thể.
        ''' </summary>
        Public Shared Function LayHoaDonHienTaiCuaBan(maBan As Integer) As HoaDonDTO
            Dim sql As String = "
                SELECT TOP 1 hd.*, b.B_TenBan, nv.NV_HoTen AS TenNVPhucVu
                FROM HoaDon hd
                INNER JOIN Ban b ON b.B_Ma = hd.HD_MaBan
                LEFT JOIN NhanVien nv ON nv.NV_Ma = hd.HD_MaNVPhucVu
                WHERE hd.HD_Xoa = 0 AND hd.HD_TrangThai = 0 AND hd.HD_MaBan = @MaBan
                ORDER BY hd.HD_ThoiGianVao DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaBan", SqlDbType.Int) With {.Value = maBan}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            If dt.Rows.Count > 0 Then
                Return ChuyenDataRowThanhDTO(dt.Rows(0))
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Mở bàn mới: Tạo hóa đơn mới với trạng thái 0 (Đang phục vụ) và cập nhật trạng thái Bàn = 1.
        ''' </summary>
        Public Shared Function MoBan(maBan As Integer, maNVPhucVu As Integer, soKhach As Integer,
                                     nguoiTao As Nullable(Of Integer), maCa As Nullable(Of Integer)) As Integer
            Dim sql As String = "
                INSERT INTO HoaDon (HD_MaBan, HD_MaNVPhucVu, HD_NguoiTao, HD_MaCa, HD_SoLuongKhach, HD_ThoiGianVao, HD_TongTien, HD_TrangThai, HD_Xoa)
                VALUES (@MaBan, @MaNV, @NguoiTao, @MaCa, @SoKhach, GETDATE(), 0, 0, 0);
                SELECT SCOPE_IDENTITY();
                UPDATE Ban SET B_TrangThai = 1 WHERE B_Ma = @MaBan;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaBan", SqlDbType.Int) With {.Value = maBan},
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNVPhucVu},
                New SqlParameter("@NguoiTao", SqlDbType.Int) With {.Value = If(nguoiTao.HasValue, CObj(nguoiTao.Value), DBNull.Value)},
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = If(maCa.HasValue, CObj(maCa.Value), DBNull.Value)},
                New SqlParameter("@SoKhach", SqlDbType.Int) With {.Value = soKhach}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq IsNot Nothing AndAlso Not IsDBNull(kq) Then
                Return Convert.ToInt32(kq)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Cập nhật tổng tiền hóa đơn sau khi thêm/sửa/hủy món.
        ''' </summary>
        Public Shared Function CapNhatTongTien(maHD As Integer, tongTien As Decimal) As Boolean
            Dim sql As String = "UPDATE HoaDon SET HD_TongTien = @TongTien WHERE HD_Ma = @MaHD AND HD_Xoa = 0;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@TongTien", SqlDbType.Decimal) With {.Value = tongTien},
                New SqlParameter("@MaHD", SqlDbType.Int) With {.Value = maHD}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Thanh toán hóa đơn: Cập nhật trạng thái = 1, phương thức thanh toán, thời gian ra và trả bàn về trống (B_TrangThai = 0).
        ''' </summary>
        Public Shared Function ThanhToan(maHD As Integer, maBan As Integer, phuongThuc As String, tongTien As Decimal) As Boolean
            Dim sql As String = "
                UPDATE HoaDon 
                SET HD_TrangThai = 1,
                    HD_PhuongThucThanhToan = @PhuongThuc,
                    HD_TongTien = @TongTien,
                    HD_ThoiGianThanhToan = GETDATE()
                WHERE HD_Ma = @MaHD;
                UPDATE Ban SET B_TrangThai = 0 WHERE B_Ma = @MaBan;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaHD", SqlDbType.Int) With {.Value = maHD},
                New SqlParameter("@MaBan", SqlDbType.Int) With {.Value = maBan},
                New SqlParameter("@PhuongThuc", SqlDbType.NVarChar, 30) With {.Value = phuongThuc},
                New SqlParameter("@TongTien", SqlDbType.Decimal) With {.Value = tongTien}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Chuyển bàn: Cập nhật mã bàn mới cho hóa đơn và cập nhật trạng thái 2 bàn.
        ''' </summary>
        Public Shared Function ChuyenBan(maHD As Integer, maBanCu As Integer, maBanMoi As Integer) As Boolean
            Dim sql As String = "
                UPDATE HoaDon SET HD_MaBan = @MaBanMoi WHERE HD_Ma = @MaHD;
                UPDATE Ban SET B_TrangThai = 0 WHERE B_Ma = @MaBanCu;
                UPDATE Ban SET B_TrangThai = 1 WHERE B_Ma = @MaBanMoi;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaHD", SqlDbType.Int) With {.Value = maHD},
                New SqlParameter("@MaBanCu", SqlDbType.Int) With {.Value = maBanCu},
                New SqlParameter("@MaBanMoi", SqlDbType.Int) With {.Value = maBanMoi}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Private Shared Function ChuyenDataRowThanhDTO(row As DataRow) As HoaDonDTO
            Dim dto As New HoaDonDTO()
            dto.HD_Ma = Convert.ToInt32(row("HD_Ma"))
            dto.HD_MaBan = Convert.ToInt32(row("HD_MaBan"))
            dto.HD_MaNVPhucVu = Convert.ToInt32(row("HD_MaNVPhucVu"))
            dto.HD_SoLuongKhach = Convert.ToInt32(row("HD_SoLuongKhach"))
            dto.HD_ThoiGianVao = Convert.ToDateTime(row("HD_ThoiGianVao"))
            dto.HD_TongTien = Convert.ToDecimal(row("HD_TongTien"))
            dto.HD_TrangThai = Convert.ToInt32(row("HD_TrangThai"))
            dto.HD_Xoa = Convert.ToBoolean(row("HD_Xoa"))
            If row.Table.Columns.Contains("B_TenBan") AndAlso Not IsDBNull(row("B_TenBan")) Then
                dto.TenBan = row("B_TenBan").ToString()
            End If
            If row.Table.Columns.Contains("TenNVPhucVu") AndAlso Not IsDBNull(row("TenNVPhucVu")) Then
                dto.TenNVPhucVu = row("TenNVPhucVu").ToString()
            End If
            Return dto
        End Function

    End Class

End Namespace
