Namespace Core.DTO
    ''' <summary>
    ''' Data Transfer Object đại diện cho một dòng món gọi trong hóa đơn (Bảng ChiTietHoaDon).
    ''' </summary>
    Public Class ChiTietHoaDonDTO
        Public Property CTHD_Ma As Integer
        Public Property CTHD_MaHoaDon As Integer
        Public Property CTHD_MaMonAn As Integer
        Public Property CTHD_SoLuong As Integer
        Public Property CTHD_DonGia As Decimal
        Public Property CTHD_GhiChu As String
        Public Property CTHD_ThoiGianGoi As DateTime
        Public Property CTHD_TrangThaiMon As Integer ' 0: Chờ thực hiện, 1: Đã nấu xong, 2: Đã mang ra, 3: Đã hủy
        Public Property CTHD_Xoa As Boolean

        ' Thuộc tính bổ trợ hiển thị (Join)
        Public Property TenMonAn As String
        Public Property DonViTinh As String
        Public Property TenDanhMuc As String
        Public Property TenBan As String

        Public ReadOnly Property ThanhTien As Decimal
            Get
                Return CTHD_SoLuong * CTHD_DonGia
            End Get
        End Property

        Public ReadOnly Property SoPhutCho As Integer
            Get
                Dim diff As TimeSpan = DateTime.Now - CTHD_ThoiGianGoi
                Return Math.Max(0, CInt(diff.TotalMinutes))
            End Get
        End Property

        Public Sub New()
            CTHD_SoLuong = 1
            CTHD_DonGia = 0
            CTHD_ThoiGianGoi = DateTime.Now
            CTHD_TrangThaiMon = 0
            CTHD_Xoa = False
        End Sub
    End Class
End Namespace
