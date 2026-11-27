Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho việc xếp lịch và phân ca toàn cơ sở.
    ''' </summary>
    Public Class LichLamViecDAO

        ''' <summary>
        ''' Lấy toàn bộ lịch làm việc của tất cả nhân viên trong tuần (Thứ Hai đến Chủ Nhật).
        ''' </summary>
        Public Shared Function LayLichTuanToanQuan(tuNgay As DateTime, denNgay As DateTime) As List(Of LichLamViecDTO)
            Dim ds As New List(Of LichLamViecDTO)()
            Dim sql As String = "
                SELECT llv.*, nv.NV_HoTen, ca.CA_Ten, ca.CA_GioBatDau, ca.CA_GioKetThuc
                FROM LichLamViec llv
                INNER JOIN NhanVien nv ON nv.NV_Ma = llv.LLV_MaNV
                INNER JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                WHERE llv.LLV_Xoa = 0 AND nv.NV_Xoa = 0
                  AND CAST(llv.LLV_NgayLam AS DATE) >= @TuNgay
                  AND CAST(llv.LLV_NgayLam AS DATE) <= @DenNgay
                ORDER BY llv.LLV_NgayLam ASC, ca.CA_GioBatDau ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date},
                New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(New LichLamViecDTO() With {
                    .LLV_Ma = Convert.ToInt32(row("LLV_Ma")),
                    .LLV_MaNV = Convert.ToInt32(row("LLV_MaNV")),
                    .LLV_MaCa = Convert.ToInt32(row("LLV_MaCa")),
                    .LLV_NgayLam = Convert.ToDateTime(row("LLV_NgayLam")),
                    .LLV_TrangThai = row("LLV_TrangThai").ToString(),
                    .TenNV = row("NV_HoTen").ToString(),
                    .TenCa = row("CA_Ten").ToString(),
                    .GioBatDau = CType(row("CA_GioBatDau"), TimeSpan),
                    .GioKetThuc = CType(row("CA_GioKetThuc"), TimeSpan)
                })
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Thêm hoặc cập nhật ca phân công cho nhân viên vào một ngày cụ thể.
        ''' </summary>
        Public Shared Function PhanCongCa(maNV As Integer, maCa As Integer, ngayLam As DateTime) As Integer
            Dim sql As String = "
                DELETE FROM LichLamViec WHERE LLV_MaNV = @MaNV AND CAST(LLV_NgayLam AS DATE) = @NgayLam;
                INSERT INTO LichLamViec (LLV_MaNV, LLV_MaCa, LLV_NgayLam, LLV_TrangThai, LLV_Xoa)
                VALUES (@MaNV, @MaCa, @NgayLam, N'Đã xếp lịch', 0);
                SELECT SCOPE_IDENTITY();"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV},
                New SqlParameter("@MaCa", SqlDbType.Int) With {.Value = maCa},
                New SqlParameter("@NgayLam", SqlDbType.Date) With {.Value = ngayLam.Date}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq IsNot Nothing AndAlso Not IsDBNull(kq) Then
                Return Convert.ToInt32(kq)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Hủy ca phân công của nhân viên trong ngày.
        ''' </summary>
        Public Shared Function HuyPhanCa(maNV As Integer, ngayLam As DateTime) As Boolean
            Dim sql As String = "DELETE FROM LichLamViec WHERE LLV_MaNV = @MaNV AND CAST(LLV_NgayLam AS DATE) = @NgayLam;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV},
                New SqlParameter("@NgayLam", SqlDbType.Date) With {.Value = ngayLam.Date}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Lấy danh sách nhân viên đang làm việc để hiển thị trên giao diện xếp lịch.
        ''' </summary>
        Public Shared Function LayDanhSachNhanVien() As DataTable
            Dim sql As String = "
                SELECT nv.NV_Ma, nv.NV_HoTen, ISNULL(vt.VT_Ten, N'Nhân viên') AS TenVaiTro
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON tk.TK_MaNV = nv.NV_Ma
                LEFT JOIN VaiTro vt ON vt.VT_Ma = tk.TK_MaVaiTro
                WHERE nv.NV_Xoa = 0
                ORDER BY nv.NV_HoTen ASC;"
            Return KetNoiCSDL.ExecuteQuery(sql)
        End Function

        ''' <summary>
        ''' Lấy danh sách ca làm việc để đưa vào ComboBox chọn ca.
        ''' </summary>
        Public Shared Function LayDanhSachCa() As DataTable
            Dim sql As String = "SELECT CA_Ma, CA_Ten, CA_GioBatDau, CA_GioKetThuc FROM CaLamViec WHERE CA_Xoa = 0 ORDER BY CA_GioBatDau ASC;"
            Return KetNoiCSDL.ExecuteQuery(sql)
        End Function

    End Class

End Namespace
