Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object cho báo cáo doanh thu theo mốc thời gian.
    ''' </summary>
    Public Class BaoCaoDoanhThuDTO
        Public Property MocThoiGian As String
        Public Property SoLuongHoaDon As Integer
        Public Property SoLuongKhach As Integer
        Public Property DoanhThu As Decimal

        Public ReadOnly Property DoanhThuTrungBinh As Decimal
            Get
                If SoLuongHoaDon > 0 Then
                    Return Math.Round(DoanhThu / SoLuongHoaDon, 0)
                End If
                Return 0D
            End Get
        End Property

        Public Sub New()
            MocThoiGian = String.Empty
            SoLuongHoaDon = 0
            SoLuongKhach = 0
            DoanhThu = 0D
        End Sub
    End Class

End Namespace
