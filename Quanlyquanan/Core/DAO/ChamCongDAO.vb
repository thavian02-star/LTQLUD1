Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng ChamCong và LichLamViec.
    ''' </summary>
    Public Class ChamCongDAO

        ''' <summary>
        ''' Lấy bản ghi chấm công ca hiện tại trong ngày của nhân viên (nếu có).
        ''' </summary>
        Public Shared Function LayChamCongHomNay(maNV As Integer) As ChamCongDTO
            Dim sql As String = "
                SELECT TOP 1 cc.*, nv.NV_HoTen AS TenNV, ca.CA_Ten AS TenCa, llv.LLV_NgayLam AS NgayLam
                FROM ChamCong cc
                INNER JOIN NhanVien nv ON nv.NV_Ma = cc.CC_MaNV
                LEFT JOIN LichLamViec llv ON llv.LLV_Ma = cc.CC_MaLich
                LEFT JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                WHERE cc.CC_Xoa = 0 
                  AND cc.CC_MaNV = @MaNV 
                  AND CAST(cc.CC_GioBatDau AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY cc.CC_GioBatDau DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            If dt.Rows.Count > 0 Then
                Return ChuyenDataRowThanhDTO(dt.Rows(0))
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Điểm danh vào ca: Ghi nhận giờ bắt đầu làm việc.
        ''' </summary>
        Public Shared Function VaoCa(maNV As Integer, maLich As Nullable(Of Integer)) As Integer
            Dim sql As String = "
                INSERT INTO ChamCong (CC_MaLich, CC_MaNV, CC_GioBatDau, CC_DaDuyet, CC_Xoa)
                VALUES (@MaLich, @MaNV, GETDATE(), 0, 0);
                SELECT SCOPE_IDENTITY();"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV},
                New SqlParameter("@MaLich", SqlDbType.Int) With {.Value = If(maLich.HasValue, CObj(maLich.Value), DBNull.Value)}
            }

            Dim kq As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            If kq IsNot Nothing AndAlso Not IsDBNull(kq) Then
                Return Convert.ToInt32(kq)
            End If
            Return 0
        End Function

        ''' <summary>
        ''' Điểm danh kết thúc ca: Ghi nhận giờ kết thúc làm việc.
        ''' </summary>
        Public Shared Function RaCa(maCC As Integer) As Boolean
            Dim sql As String = "UPDATE ChamCong SET CC_GioKetThuc = GETDATE() WHERE CC_Ma = @MaCC AND CC_GioKetThuc IS NULL;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCC", SqlDbType.Int) With {.Value = maCC}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Lấy lịch sử các lần chấm công gần nhất của nhân viên.
        ''' </summary>
        Public Shared Function LayLichSuChamCong(maNV As Integer, Optional limit As Integer = 10) As List(Of ChamCongDTO)
            Dim ds As New List(Of ChamCongDTO)()
            Dim sql As String = "
                SELECT TOP (@Limit) cc.*, nv.NV_HoTen AS TenNV, ca.CA_Ten AS TenCa, 
                       ISNULL(llv.LLV_NgayLam, CAST(cc.CC_GioBatDau AS DATE)) AS NgayLam
                FROM ChamCong cc
                INNER JOIN NhanVien nv ON nv.NV_Ma = cc.CC_MaNV
                LEFT JOIN LichLamViec llv ON llv.LLV_Ma = cc.CC_MaLich
                LEFT JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                WHERE cc.CC_Xoa = 0 AND cc.CC_MaNV = @MaNV
                ORDER BY cc.CC_GioBatDau DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV},
                New SqlParameter("@Limit", SqlDbType.Int) With {.Value = limit}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(ChuyenDataRowThanhDTO(row))
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Lấy danh sách lịch phân ca trong tuần của nhân viên.
        ''' </summary>
        Public Shared Function LayLichTuanCuaNhanVien(maNV As Integer, tuNgay As DateTime, denNgay As DateTime) As List(Of LichLamViecDTO)
            Dim ds As New List(Of LichLamViecDTO)()
            Dim sql As String = "
                SELECT llv.*, ca.CA_Ten AS TenCa, ca.CA_GioBatDau AS GioBatDau, ca.CA_GioKetThuc AS GioKetThuc
                FROM LichLamViec llv
                INNER JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                WHERE llv.LLV_Xoa = 0 
                  AND llv.LLV_MaNV = @MaNV
                  AND llv.LLV_NgayLam >= @TuNgay AND llv.LLV_NgayLam <= @DenNgay
                ORDER BY llv.LLV_NgayLam ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV},
                New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date},
                New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                Dim dto As New LichLamViecDTO() With {
                    .LLV_Ma = Convert.ToInt32(row("LLV_Ma")),
                    .LLV_MaNV = Convert.ToInt32(row("LLV_MaNV")),
                    .LLV_MaCa = Convert.ToInt32(row("LLV_MaCa")),
                    .LLV_NgayLam = Convert.ToDateTime(row("LLV_NgayLam")),
                    .LLV_TrangThai = row("LLV_TrangThai").ToString(),
                    .TenCa = row("TenCa").ToString(),
                    .GioBatDau = CType(row("GioBatDau"), TimeSpan),
                    .GioKetThuc = CType(row("GioKetThuc"), TimeSpan)
                }
                ds.Add(dto)
            Next
            Return ds
        End Function

        Private Shared Function ChuyenDataRowThanhDTO(row As DataRow) As ChamCongDTO
            Dim dto As New ChamCongDTO()
            dto.CC_Ma = Convert.ToInt32(row("CC_Ma"))
            If Not IsDBNull(row("CC_MaLich")) Then dto.CC_MaLich = Convert.ToInt32(row("CC_MaLich"))
            dto.CC_MaNV = Convert.ToInt32(row("CC_MaNV"))
            If Not IsDBNull(row("CC_GioBatDau")) Then dto.CC_GioBatDau = Convert.ToDateTime(row("CC_GioBatDau"))
            If Not IsDBNull(row("CC_GioKetThuc")) Then dto.CC_GioKetThuc = Convert.ToDateTime(row("CC_GioKetThuc"))
            dto.CC_DaDuyet = Convert.ToBoolean(row("CC_DaDuyet"))
            If Not IsDBNull(row("CC_NguoiDuyet")) Then dto.CC_NguoiDuyet = Convert.ToInt32(row("CC_NguoiDuyet"))
            If Not IsDBNull(row("CC_ThoiGianDuyet")) Then dto.CC_ThoiGianDuyet = Convert.ToDateTime(row("CC_ThoiGianDuyet"))
            dto.CC_Xoa = Convert.ToBoolean(row("CC_Xoa"))
            If row.Table.Columns.Contains("TenCa") AndAlso Not IsDBNull(row("TenCa")) Then dto.TenCa = row("TenCa").ToString()
            If row.Table.Columns.Contains("TenNV") AndAlso Not IsDBNull(row("TenNV")) Then dto.TenNV = row("TenNV").ToString()
            If row.Table.Columns.Contains("NgayLam") AndAlso Not IsDBNull(row("NgayLam")) Then dto.NgayLam = Convert.ToDateTime(row("NgayLam"))
            Return dto
        End Function

    End Class

End Namespace
