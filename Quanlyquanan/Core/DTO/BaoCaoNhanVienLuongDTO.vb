Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object cho báo cáo năng suất phục vụ và tổng hợp lương ca nhân viên.
    ''' </summary>
    Public Class BaoCaoNhanVienLuongDTO
        Public Property MaNV As Integer
        Public Property HoTenNV As String
        Public Property TenVaiTro As String
        Public Property SoCaLam As Integer
        Public Property TongSoGio As Double
        Public Property SoKhachPhucVu As Integer
        Public Property TongTienLuong As Decimal

        Public Sub New()
            HoTenNV = String.Empty
            TenVaiTro = String.Empty
            SoCaLam = 0
            TongSoGio = 0
            SoKhachPhucVu = 0
            TongTienLuong = 0D
        End Sub
    End Class

End Namespace
