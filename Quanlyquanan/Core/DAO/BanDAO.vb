Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng Ban.
    ''' Sử dụng Parameterized SQL qua KetNoiCSDL, kết nối phiên phục vụ HoaDon và bảo vệ toàn vẹn dữ liệu.
    ''' </summary>
    Public Class BanDAO

        ''' <summary>
        ''' Lấy danh sách bàn ăn đang hoạt động (B_Xoa = 0), hỗ trợ lọc theo Khu vực, Trạng thái và Từ khóa.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional khuVuc As String = "",
                                           Optional trangThai As Integer = -1) As List(Of BanDTO)
            Dim ds As New List(Of BanDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()
            Dim area As String = If(khuVuc, String.Empty).Trim()

            Dim sql As String = "
                SELECT 
                    b.B_Ma,
                    b.B_SoThuTu,
                    b.B_TenBan,
                    b.B_KhuVuc,
                    b.B_SoNguoiToiDa,
                    b.B_TrangThai,
                    b.B_Xoa,
                    curHd.HD_Ma AS MaHoaDon,
                    curHd.NV_HoTen AS TenNVPhucVu
                FROM Ban b
                LEFT JOIN (
                    SELECT hd.HD_Ma, hd.HD_MaBan, nv.NV_HoTen
                    FROM HoaDon hd
                    LEFT JOIN NhanVien nv ON nv.NV_Ma = hd.HD_MaNVPhucVu
                    WHERE hd.HD_Xoa = 0 AND hd.HD_TrangThai = 0
                ) curHd ON curHd.HD_MaBan = b.B_Ma
                WHERE b.B_Xoa = 0
                  AND (@KhuVuc = N'' OR b.B_KhuVuc = @KhuVuc)
                  AND (@TrangThai = -1 OR b.B_TrangThai = @TrangThai)
                  AND (@TuKhoa = N'' OR b.B_TenBan LIKE N'%' + @TuKhoa + N'%' 
                                    OR CAST(b.B_SoThuTu AS NVARCHAR(10)) LIKE N'%' + @TuKhoa + N'%'
                                    OR b.B_KhuVuc LIKE N'%' + @TuKhoa + N'%')
                ORDER BY b.B_SoThuTu ASC, b.B_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@KhuVuc", SqlDbType.NVarChar, 50) With {.Value = area},
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = trangThai},
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 50) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                Dim maHD As Integer? = Nothing
                If Not IsDBNull(row("MaHoaDon")) Then
                    maHD = Convert.ToInt32(row("MaHoaDon"))
                End If

                Dim tenNV As String = String.Empty
                If Not IsDBNull(row("TenNVPhucVu")) Then
                    tenNV = Convert.ToString(row("TenNVPhucVu"))
                End If

                Dim dto As New BanDTO() With {
                    .MaBan = Convert.ToInt32(row("B_Ma")),
                    .SoThuTu = Convert.ToInt32(row("B_SoThuTu")),
                    .TenBan = Convert.ToString(row("B_TenBan")).Trim(),
                    .KhuVuc = If(IsDBNull(row("B_KhuVuc")), "Tầng trệt", Convert.ToString(row("B_KhuVuc")).Trim()),
                    .SoNguoiToiDa = Convert.ToInt32(row("B_SoNguoiToiDa")),
                    .TrangThai = Convert.ToInt32(row("B_TrangThai")),
                    .Xoa = Convert.ToBoolean(row("B_Xoa")),
                    .MaHoaDonHienTai = maHD,
                    .TenNVPhucVu = tenNV
                }
                ds.Add(dto)
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Lấy danh sách các tên khu vực đang được sử dụng trong CSDL.
        ''' </summary>
        Public Shared Function LayDanhSachKhuVuc() As List(Of String)
            Dim ds As New List(Of String)()
            Dim sql As String = "
                SELECT DISTINCT B_KhuVuc
                FROM Ban
                WHERE B_Xoa = 0 
                  AND B_KhuVuc IS NOT NULL 
                  AND LTRIM(RTRIM(B_KhuVuc)) <> N''
                ORDER BY B_KhuVuc ASC;"

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)
            For Each row As DataRow In dt.Rows
                ds.Add(Convert.ToString(row("B_KhuVuc")).Trim())
            Next

            ' Danh sách khu vực mặc định nếu CSDL chưa có
            Dim defaultAreas As String() = {"Tầng trệt", "Lầu 1 (Máy lạnh)", "Phòng VIP Máy lạnh", "Sân vườn thoáng mát"}
            For Each def In defaultAreas
                If Not ds.Contains(def) Then
                    ds.Add(def)
                End If
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Kiểm tra số thứ tự bàn đã được sử dụng bởi bàn đang hoạt động khác hay chưa.
        ''' </summary>
        Public Shared Function KiemTraTrungSoThuTu(soThuTu As Integer, Optional maBanLoaiTru As Integer = 0) As Boolean
            Dim sql As String = "
                SELECT COUNT(1)
                FROM Ban
                WHERE B_Xoa = 0
                  AND B_SoThuTu = @STT
                  AND B_Ma <> @MaLoaiTru;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@STT", SqlDbType.Int) With {.Value = soThuTu},
                New SqlParameter("@MaLoaiTru", SqlDbType.Int) With {.Value = maBanLoaiTru}
            }

            Dim count As Integer = Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sql, prms))
            Return count > 0
        End Function

        ''' <summary>
        ''' Tìm mã bàn đã bị xóa mềm (B_Xoa = 1) có cùng số thứ tự để khôi phục.
        ''' </summary>
        Public Shared Function TimMaBanDaXoaTheoSTT(soThuTu As Integer) As Integer
            Dim sql As String = "
                SELECT TOP 1 B_Ma
                FROM Ban
                WHERE B_Xoa = 1
                  AND B_SoThuTu = @STT
                ORDER BY B_Ma DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@STT", SqlDbType.Int) With {.Value = soThuTu}
            }

            Dim obj As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                Return Convert.ToInt32(obj)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Kiểm tra bàn có đang phục vụ khách hoặc có hóa đơn chưa thanh toán hay không.
        ''' </summary>
        Public Shared Function KiemTraBanDangPhucVu(maBan As Integer, ByRef lyDo As String) As Boolean
            ' 1. Kiểm tra trạng thái bàn trên bảng Ban
            Dim sqlBan As String = "SELECT B_TenBan, B_TrangThai FROM Ban WHERE B_Ma = @Ma AND B_Xoa = 0;"
            Dim dtBan As DataTable = KetNoiCSDL.ExecuteQuery(sqlBan, {New SqlParameter("@Ma", maBan)})
            If dtBan.Rows.Count > 0 Then
                Dim tt As Integer = Convert.ToInt32(dtBan.Rows(0)("B_TrangThai"))
                Dim ten As String = Convert.ToString(dtBan.Rows(0)("B_TenBan"))
                If tt <> 0 Then
                    Dim ttText As String = "Có khách"
                    If tt = 2 Then ttText = "Đang đợi món"
                    If tt = 3 Then ttText = "Món đã xong"
                    lyDo = $"Bàn ""{ten}"" đang trong phiên phục vụ (Trạng thái: {ttText})!"
                    Return True
                End If
            End If

            ' 2. Kiểm tra hóa đơn chưa thanh toán (HD_TrangThai = 0)
            Dim sqlHD As String = "SELECT COUNT(1) FROM HoaDon WHERE HD_MaBan = @Ma AND HD_Xoa = 0 AND HD_TrangThai = 0;"
            Dim soHD As Integer = Convert.ToInt32(KetNoiCSDL.ExecuteScalar(sqlHD, {New SqlParameter("@Ma", maBan)}))
            If soHD > 0 Then
                lyDo = $"Bàn này đang có {soHD} hóa đơn đang mở chưa thanh toán!"
                Return True
            End If

            lyDo = String.Empty
            Return False
        End Function

        ''' <summary>
        ''' Thêm mới bàn ăn vào bảng Ban.
        ''' </summary>
        Public Shared Function ThemBan(dto As BanDTO) As Boolean
            Dim sql As String = "
                INSERT INTO Ban (B_SoThuTu, B_TenBan, B_KhuVuc, B_SoNguoiToiDa, B_TrangThai, B_Xoa)
                VALUES (@STT, @Ten, @KhuVuc, @SucChua, @TrangThai, 0);"

            Dim prms As SqlParameter() = {
                New SqlParameter("@STT", SqlDbType.Int) With {.Value = dto.SoThuTu},
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenBan.Trim()},
                New SqlParameter("@KhuVuc", SqlDbType.NVarChar, 50) With {.Value = dto.KhuVuc.Trim()},
                New SqlParameter("@SucChua", SqlDbType.Int) With {.Value = dto.SoNguoiToiDa},
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = dto.TrangThai}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Khôi phục bàn đã xóa mềm (B_Xoa = 0) và cập nhật thông tin mới.
        ''' </summary>
        Public Shared Function KhoiPhucBan(maBan As Integer, dto As BanDTO) As Boolean
            Dim sql As String = "
                UPDATE Ban
                SET B_SoThuTu = @STT,
                    B_TenBan = @Ten,
                    B_KhuVuc = @KhuVuc,
                    B_SoNguoiToiDa = @SucChua,
                    B_TrangThai = @TrangThai,
                    B_Xoa = 0
                WHERE B_Ma = @Ma;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@STT", SqlDbType.Int) With {.Value = dto.SoThuTu},
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenBan.Trim()},
                New SqlParameter("@KhuVuc", SqlDbType.NVarChar, 50) With {.Value = dto.KhuVuc.Trim()},
                New SqlParameter("@SucChua", SqlDbType.Int) With {.Value = dto.SoNguoiToiDa},
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = dto.TrangThai},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maBan}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Cập nhật thông tin bàn ăn đang hoạt động.
        ''' </summary>
        Public Shared Function CapNhatBan(dto As BanDTO) As Boolean
            Dim sql As String = "
                UPDATE Ban
                SET B_SoThuTu = @STT,
                    B_TenBan = @Ten,
                    B_KhuVuc = @KhuVuc,
                    B_SoNguoiToiDa = @SucChua,
                    B_TrangThai = @TrangThai
                WHERE B_Ma = @Ma AND B_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@STT", SqlDbType.Int) With {.Value = dto.SoThuTu},
                New SqlParameter("@Ten", SqlDbType.NVarChar, 50) With {.Value = dto.TenBan.Trim()},
                New SqlParameter("@KhuVuc", SqlDbType.NVarChar, 50) With {.Value = dto.KhuVuc.Trim()},
                New SqlParameter("@SucChua", SqlDbType.Int) With {.Value = dto.SoNguoiToiDa},
                New SqlParameter("@TrangThai", SqlDbType.Int) With {.Value = dto.TrangThai},
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = dto.MaBan}
            }

            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Xóa mềm bàn ăn (đặt cờ B_Xoa = 1).
        ''' </summary>
        Public Shared Function XoaMemBan(maBan As Integer) As Boolean
            Dim sql As String = "UPDATE Ban SET B_Xoa = 1 WHERE B_Ma = @Ma;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@Ma", SqlDbType.Int) With {.Value = maBan}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

    End Class

End Namespace
