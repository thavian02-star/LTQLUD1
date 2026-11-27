Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) phục vụ màn hình Duyệt Chấm Công.
    ''' </summary>
    Public Class DuyetChamCongDAO

        ''' <summary>
        ''' Lấy danh sách chấm công theo khoảng ngày và bộ lọc trạng thái.
        ''' </summary>
        Public Shared Function LayDanhSachChamCong(tuNgay As DateTime, denNgay As DateTime, Optional locTrangThai As String = "ALL", Optional maNV As Nullable(Of Integer) = Nothing) As List(Of BaoCaoChamCongDTO)
            Dim ds As New List(Of BaoCaoChamCongDTO)()
            Dim sql As String = "
                SELECT cc.CC_Ma, cc.CC_MaNV, nv.NV_HoTen, 
                       ISNULL(vt.VT_Ten, N'Nhân viên') AS TenVaiTro,
                       ISNULL(ca.CA_Ten, N'Ca tiêu chuẩn') AS TenCa,
                       ISNULL(ca.CA_LuongMoiCa, 200000) AS LuongMoiCa,
                       cc.CC_GioBatDau, cc.CC_GioKetThuc, cc.CC_DaDuyet, 
                       cc.CC_NguoiDuyet, nd.NV_HoTen AS TenNguoiDuyet, cc.CC_ThoiGianDuyet
                FROM ChamCong cc
                INNER JOIN NhanVien nv ON nv.NV_Ma = cc.CC_MaNV
                LEFT JOIN TaiKhoan tk ON tk.TK_MaNV = nv.NV_Ma
                LEFT JOIN VaiTro vt ON vt.VT_Ma = tk.TK_MaVaiTro
                LEFT JOIN LichLamViec llv ON llv.LLV_Ma = cc.CC_MaLich
                LEFT JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                LEFT JOIN NhanVien nd ON nd.NV_Ma = cc.CC_NguoiDuyet
                WHERE cc.CC_Xoa = 0
                  AND CAST(cc.CC_GioBatDau AS DATE) >= @TuNgay
                  AND CAST(cc.CC_GioBatDau AS DATE) <= @DenNgay"

            If locTrangThai = "PENDING" Then
                sql &= " AND cc.CC_DaDuyet = 0 AND cc.CC_GioKetThuc IS NOT NULL"
            ElseIf locTrangThai = "APPROVED" Then
                sql &= " AND cc.CC_DaDuyet = 1"
            End If

            If maNV.HasValue AndAlso maNV.Value > 0 Then
                sql &= " AND cc.CC_MaNV = @MaNV"
            End If

            sql &= " ORDER BY cc.CC_GioBatDau DESC;"

            Dim prms As New List(Of SqlParameter)()
            prms.Add(New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date})
            prms.Add(New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date})
            If maNV.HasValue AndAlso maNV.Value > 0 Then
                prms.Add(New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNV.Value})
            End If

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms.ToArray())
            For Each row As DataRow In dt.Rows
                ds.Add(ChuyenRowThanhBaoCaoDTO(row))
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Phê duyệt một ca chấm công.
        ''' </summary>
        Public Shared Function DuyetCa(maCC As Integer, nguoiDuyet As Integer) As Boolean
            Dim sql As String = "
                UPDATE ChamCong 
                SET CC_DaDuyet = 1, CC_NguoiDuyet = @NguoiDuyet, CC_ThoiGianDuyet = GETDATE()
                WHERE CC_Ma = @MaCC AND CC_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCC", SqlDbType.Int) With {.Value = maCC},
                New SqlParameter("@NguoiDuyet", SqlDbType.Int) With {.Value = nguoiDuyet}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Hoàn tác duyệt một ca chấm công.
        ''' </summary>
        Public Shared Function HuyDuyetCa(maCC As Integer) As Boolean
            Dim sql As String = "
                UPDATE ChamCong 
                SET CC_DaDuyet = 0, CC_NguoiDuyet = NULL, CC_ThoiGianDuyet = NULL
                WHERE CC_Ma = @MaCC AND CC_Xoa = 0;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaCC", SqlDbType.Int) With {.Value = maCC}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        Private Shared Function ChuyenRowThanhBaoCaoDTO(row As DataRow) As BaoCaoChamCongDTO
            Dim dto As New BaoCaoChamCongDTO()
            dto.CC_Ma = Convert.ToInt32(row("CC_Ma"))
            dto.CC_MaNV = Convert.ToInt32(row("CC_MaNV"))
            dto.HoTenNV = row("NV_HoTen").ToString()
            dto.VaiTroNV = row("TenVaiTro").ToString()
            dto.TenCa = row("TenCa").ToString()
            dto.LuongMoiCa = Convert.ToDecimal(row("LuongMoiCa"))
            If Not IsDBNull(row("CC_GioBatDau")) Then dto.CC_GioBatDau = Convert.ToDateTime(row("CC_GioBatDau"))
            If Not IsDBNull(row("CC_GioKetThuc")) Then dto.CC_GioKetThuc = Convert.ToDateTime(row("CC_GioKetThuc"))
            dto.CC_DaDuyet = Convert.ToBoolean(row("CC_DaDuyet"))
            If Not IsDBNull(row("CC_NguoiDuyet")) Then dto.CC_NguoiDuyet = Convert.ToInt32(row("CC_NguoiDuyet"))
            If Not IsDBNull(row("TenNguoiDuyet")) Then dto.TenNguoiDuyet = row("TenNguoiDuyet").ToString()
            If Not IsDBNull(row("CC_ThoiGianDuyet")) Then dto.CC_ThoiGianDuyet = Convert.ToDateTime(row("CC_ThoiGianDuyet"))
            Return dto
        End Function

    End Class

End Namespace
