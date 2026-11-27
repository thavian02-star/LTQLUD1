Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object cho báo cáo thống kê món ăn bán chạy (Best Sellers).
    ''' </summary>
    Public Class BaoCaoMonBanChayDTO
        Public Property Hang As Integer
        Public Property MaMon As Integer
        Public Property TenMon As String
        Public Property TenDanhMuc As String
        Public Property DonGia As Decimal
        Public Property SoLuongBan As Integer
        Public Property TongDoanhThu As Decimal

        Public Sub New()
            TenMon = String.Empty
            TenDanhMuc = String.Empty
            DonGia = 0D
            SoLuongBan = 0
            TongDoanhThu = 0D
        End Sub
    End Class

End Namespace
