Namespace Core.DTO
    ''' <summary>
    ''' Data Transfer Object đại diện cho một phiên phục vụ / hóa đơn tại bàn (Bảng HoaDon).
    ''' </summary>
    Public Class HoaDonDTO
        Public Property HD_Ma As Integer
        Public Property HD_MaBan As Integer
        Public Property HD_MaNVPhucVu As Integer
        Public Property HD_NguoiTao As Nullable(Of Integer)
        Public Property HD_MaCa As Nullable(Of Integer)
        Public Property HD_MaHoaDonGop As Nullable(Of Integer)
        Public Property HD_SoLuongKhach As Integer
        Public Property HD_ThoiGianVao As DateTime
        Public Property HD_ThoiGianThanhToan As Nullable(Of DateTime)
        Public Property HD_PhuongThucThanhToan As String
        Public Property HD_TongTien As Decimal
        Public Property HD_TrangThai As Integer ' 0: Đang phục vụ, 1: Đã thanh toán, 2: Đã gộp, 3: Đã hủy
        Public Property HD_Xoa As Boolean

        ' Thuộc tính bổ trợ hiển thị (Join)
        Public Property TenBan As String
        Public Property TenNVPhucVu As String

        Public Sub New()
            HD_SoLuongKhach = 1
            HD_ThoiGianVao = DateTime.Now
            HD_PhuongThucThanhToan = "Tiền mặt"
            HD_TongTien = 0
            HD_TrangThai = 0
            HD_Xoa = False
        End Sub
    End Class
End Namespace
