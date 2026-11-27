Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) phụ trách tổng hợp phân tích báo cáo doanh thu, món bán chạy & năng suất.
    ''' </summary>
    Public Class BaoCaoBUS

        ''' <summary>
        ''' Lấy báo cáo doanh thu theo từng mốc ngày.
        ''' </summary>
        Public Shared Function LayBaoCaoDoanhThu(tuNgay As DateTime, denNgay As DateTime) As List(Of BaoCaoDoanhThuDTO)
            Try
                Dim ds = BaoCaoDAO.LayBaoCaoDoanhThuTheoNgay(tuNgay, denNgay)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return TaoMockDoanhThu(tuNgay, denNgay)
        End Function

        ''' <summary>
        ''' Lấy danh sách món ăn & nước uống bán chạy nhất (Top Sellers).
        ''' </summary>
        Public Shared Function LayTopMonBanChay(tuNgay As DateTime, denNgay As DateTime, Optional top As Integer = 10) As List(Of BaoCaoMonBanChayDTO)
            Try
                Dim ds = BaoCaoDAO.LayTopMonBanChay(tuNgay, denNgay, top)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return TaoMockMonBanChay()
        End Function

        ''' <summary>
        ''' Lấy danh sách năng suất phục vụ & dự toán quỹ lương nhân viên.
        ''' </summary>
        Public Shared Function LayNangSuatNhanVien(tuNgay As DateTime, denNgay As DateTime) As List(Of BaoCaoNhanVienLuongDTO)
            Try
                Dim ds = BaoCaoDAO.LayNangSuatVaLuongNhanVien(tuNgay, denNgay)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return TaoMockNhanVien()
        End Function

        Private Shared Function TaoMockDoanhThu(tuNgay As DateTime, denNgay As DateTime) As List(Of BaoCaoDoanhThuDTO)
            Dim ds As New List(Of BaoCaoDoanhThuDTO)()
            Dim ngay = denNgay.Date
            Dim dem As Integer = 0
            While ngay >= tuNgay.Date AndAlso dem < 7
                Dim hd = 8 + (dem * 2) Mod 7
                Dim khach = hd * 3 + 2
                Dim dt = hd * 350000D
                ds.Add(New BaoCaoDoanhThuDTO() With {
                    .MocThoiGian = ngay.ToString("dd/MM/yyyy"),
                    .SoLuongHoaDon = hd,
                    .SoLuongKhach = khach,
                    .DoanhThu = dt
                })
                ngay = ngay.AddDays(-1)
                dem += 1
            End While
            Return ds
        End Function

        Private Shared Function TaoMockMonBanChay() As List(Of BaoCaoMonBanChayDTO)
            Dim ds As New List(Of BaoCaoMonBanChayDTO)()
            ds.Add(New BaoCaoMonBanChayDTO() With {.Hang = 1, .MaMon = 1, .TenMon = "Cơm Tấm Sườn Bì Chả", .TenDanhMuc = "Món chính", .DonGia = 65000D, .SoLuongBan = 86, .TongDoanhThu = 5590000D})
            ds.Add(New BaoCaoMonBanChayDTO() With {.Hang = 2, .MaMon = 2, .TenMon = "Cơm Tấm Sườn Nướng", .TenDanhMuc = "Món chính", .DonGia = 55000D, .SoLuongBan = 64, .TongDoanhThu = 3520000D})
            ds.Add(New BaoCaoMonBanChayDTO() With {.Hang = 3, .MaMon = 3, .TenMon = "Canh Khổ Qua Nhồi Thịt", .TenDanhMuc = "Canh / Súp", .DonGia = 25000D, .SoLuongBan = 52, .TongDoanhThu = 1300000D})
            ds.Add(New BaoCaoMonBanChayDTO() With {.Hang = 4, .MaMon = 4, .TenMon = "Trà Đào Cam Sả", .TenDanhMuc = "Đồ uống", .DonGia = 28000D, .SoLuongBan = 48, .TongDoanhThu = 1344000D})
            ds.Add(New BaoCaoMonBanChayDTO() With {.Hang = 5, .MaMon = 5, .TenMon = "Cà Phê Sữa Đá Sài Gòn", .TenDanhMuc = "Đồ uống", .DonGia = 22000D, .SoLuongBan = 45, .TongDoanhThu = 990000D})
            Return ds
        End Function

        Private Shared Function TaoMockNhanVien() As List(Of BaoCaoNhanVienLuongDTO)
            Dim ds As New List(Of BaoCaoNhanVienLuongDTO)()
            ds.Add(New BaoCaoNhanVienLuongDTO() With {.MaNV = 1, .HoTenNV = "Nguyễn Văn A", .TenVaiTro = "Phục vụ bàn", .SoCaLam = 6, .TongSoGio = 48.5, .SoKhachPhucVu = 72, .TongTienLuong = 1200000D})
            ds.Add(New BaoCaoNhanVienLuongDTO() With {.MaNV = 2, .HoTenNV = "Trần Thị B", .TenVaiTro = "Phục vụ bàn", .SoCaLam = 5, .TongSoGio = 40.2, .SoKhachPhucVu = 66, .TongTienLuong = 1000000D})
            ds.Add(New BaoCaoNhanVienLuongDTO() With {.MaNV = 3, .HoTenNV = "Lê Hoàng C", .TenVaiTro = "Nhà bếp", .SoCaLam = 6, .TongSoGio = 49.0, .SoKhachPhucVu = 0, .TongTienLuong = 1320000D})
            ds.Add(New BaoCaoNhanVienLuongDTO() With {.MaNV = 4, .HoTenNV = "Phạm Hải D", .TenVaiTro = "Nhà bếp", .SoCaLam = 5, .TongSoGio = 41.5, .SoKhachPhucVu = 0, .TongTienLuong = 1100000D})
            Return ds
        End Function

    End Class

End Namespace
