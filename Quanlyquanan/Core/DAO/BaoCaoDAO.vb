Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho phân hệ Báo Cáo Doanh Thu, Món Bán Chạy & Năng Suất Nhân Sự.
    ''' </summary>
    Public Class BaoCaoDAO

        ''' <summary>
        ''' Lấy báo cáo doanh thu theo từng ngày trong khoảng thời gian.
        ''' </summary>
        Public Shared Function LayBaoCaoDoanhThuTheoNgay(tuNgay As DateTime, denNgay As DateTime) As List(Of BaoCaoDoanhThuDTO)
            Dim ds As New List(Of BaoCaoDoanhThuDTO)()
            Dim sql As String = "
                SELECT CAST(HD_ThoiGianThanhToan AS DATE) AS Ngay,
                       COUNT(HD_Ma) AS SoLuongHoaDon,
                       ISNULL(SUM(HD_SoLuongKhach), 0) AS SoLuongKhach,
                       ISNULL(SUM(HD_TongTien), 0) AS DoanhThu
                FROM HoaDon
                WHERE HD_Xoa = 0 AND HD_TrangThai = 1
                  AND CAST(HD_ThoiGianThanhToan AS DATE) >= @TuNgay
                  AND CAST(HD_ThoiGianThanhToan AS DATE) <= @DenNgay
                GROUP BY CAST(HD_ThoiGianThanhToan AS DATE)
                ORDER BY Ngay DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date},
                New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                Dim d = Convert.ToDateTime(row("Ngay"))
                ds.Add(New BaoCaoDoanhThuDTO() With {
                    .MocThoiGian = d.ToString("dd/MM/yyyy"),
                    .SoLuongHoaDon = Convert.ToInt32(row("SoLuongHoaDon")),
                    .SoLuongKhach = Convert.ToInt32(row("SoLuongKhach")),
                    .DoanhThu = Convert.ToDecimal(row("DoanhThu"))
                })
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Lấy top món ăn & thức uống bán chạy nhất (Best Sellers).
        ''' </summary>
        Public Shared Function LayTopMonBanChay(tuNgay As DateTime, denNgay As DateTime, Optional top As Integer = 10) As List(Of BaoCaoMonBanChayDTO)
            Dim ds As New List(Of BaoCaoMonBanChayDTO)()
            Dim sql As String = "
                SELECT TOP (@Top)
                       ma.MA_Ma, ma.MA_Ten, ISNULL(dm.DM_Ten, N'Chung') AS TenDanhMuc,
                       ma.MA_DonGia,
                       SUM(cthd.CTHD_SoLuong) AS SoLuongBan,
                       SUM(cthd.CTHD_SoLuong * cthd.CTHD_DonGia) AS TongDoanhThu
                FROM ChiTietHoaDon cthd
                INNER JOIN MonAn ma ON ma.MA_Ma = cthd.CTHD_MaMonAn
                LEFT JOIN DanhMuc dm ON dm.DM_Ma = ma.MA_DanhMuc
                INNER JOIN HoaDon hd ON hd.HD_Ma = cthd.CTHD_MaHoaDon
                WHERE cthd.CTHD_Xoa = 0 AND hd.HD_Xoa = 0 AND hd.HD_TrangThai = 1
                  AND CAST(hd.HD_ThoiGianThanhToan AS DATE) >= @TuNgay
                  AND CAST(hd.HD_ThoiGianThanhToan AS DATE) <= @DenNgay
                GROUP BY ma.MA_Ma, ma.MA_Ten, dm.DM_Ten, ma.MA_DonGia
                ORDER BY SoLuongBan DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@Top", SqlDbType.Int) With {.Value = top},
                New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date},
                New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            Dim rank As Integer = 1
            For Each row As DataRow In dt.Rows
                ds.Add(New BaoCaoMonBanChayDTO() With {
                    .Hang = rank,
                    .MaMon = Convert.ToInt32(row("MA_Ma")),
                    .TenMon = row("MA_Ten").ToString(),
                    .TenDanhMuc = row("TenDanhMuc").ToString(),
                    .DonGia = Convert.ToDecimal(row("MA_DonGia")),
                    .SoLuongBan = Convert.ToInt32(row("SoLuongBan")),
                    .TongDoanhThu = Convert.ToDecimal(row("TongDoanhThu"))
                })
                rank += 1
            Next
            Return ds
        End Function

        ''' <summary>
        ''' Lấy báo cáo năng suất phục vụ & tổng hợp quỹ lương ca của nhân viên.
        ''' </summary>
        Public Shared Function LayNangSuatVaLuongNhanVien(tuNgay As DateTime, denNgay As DateTime) As List(Of BaoCaoNhanVienLuongDTO)
            Dim ds As New List(Of BaoCaoNhanVienLuongDTO)()
            Dim sql As String = "
                SELECT nv.NV_Ma, nv.NV_HoTen, ISNULL(vt.VT_Ten, N'Nhân viên') AS TenVaiTro,
                       COUNT(cc.CC_Ma) AS SoCaLam,
                       ISNULL(SUM(DATEDIFF(MINUTE, cc.CC_GioBatDau, cc.CC_GioKetThuc)), 0) / 60.0 AS TongSoGio,
                       ISNULL(SUM(ca.CA_LuongMoiCa), 0) AS TongTienLuong,
                       ISNULL((SELECT SUM(hd.HD_SoLuongKhach) FROM HoaDon hd 
                               WHERE hd.HD_MaNVPhucVu = nv.NV_Ma AND hd.HD_TrangThai = 1 
                                 AND CAST(hd.HD_ThoiGianThanhToan AS DATE) >= @TuNgay 
                                 AND CAST(hd.HD_ThoiGianThanhToan AS DATE) <= @DenNgay), 0) AS SoKhachPhucVu
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON tk.TK_MaNV = nv.NV_Ma
                LEFT JOIN VaiTro vt ON vt.VT_Ma = tk.TK_MaVaiTro
                LEFT JOIN ChamCong cc ON cc.CC_MaNV = nv.NV_Ma AND cc.CC_Xoa = 0 AND cc.CC_DaDuyet = 1
                      AND CAST(cc.CC_GioBatDau AS DATE) >= @TuNgay AND CAST(cc.CC_GioBatDau AS DATE) <= @DenNgay
                LEFT JOIN LichLamViec llv ON llv.LLV_Ma = cc.CC_MaLich
                LEFT JOIN CaLamViec ca ON ca.CA_Ma = llv.LLV_MaCa
                WHERE nv.NV_Xoa = 0
                GROUP BY nv.NV_Ma, nv.NV_HoTen, vt.VT_Ten
                ORDER BY SoCaLam DESC, TongTienLuong DESC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@TuNgay", SqlDbType.Date) With {.Value = tuNgay.Date},
                New SqlParameter("@DenNgay", SqlDbType.Date) With {.Value = denNgay.Date}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(New BaoCaoNhanVienLuongDTO() With {
                    .MaNV = Convert.ToInt32(row("NV_Ma")),
                    .HoTenNV = row("NV_HoTen").ToString(),
                    .TenVaiTro = row("TenVaiTro").ToString(),
                    .SoCaLam = Convert.ToInt32(row("SoCaLam")),
                    .TongSoGio = Math.Round(Convert.ToDouble(row("TongSoGio")), 1),
                    .SoKhachPhucVu = Convert.ToInt32(row("SoKhachPhucVu")),
                    .TongTienLuong = Convert.ToDecimal(row("TongTienLuong"))
                })
            Next
            Return ds
        End Function

    End Class

End Namespace
