Namespace Core.DTO
    ''' <summary>
    ''' Data Transfer Object đại diện cho lịch làm việc phân công ca (Bảng LichLamViec).
    ''' </summary>
    Public Class LichLamViecDTO
        Public Property LLV_Ma As Integer
        Public Property LLV_MaNV As Integer
        Public Property LLV_MaCa As Integer
        Public Property LLV_NgayLam As DateTime
        Public Property LLV_TrangThai As String
        Public Property LLV_Xoa As Boolean

        ' Thuộc tính bổ trợ hiển thị (Join)
        Public Property TenCa As String
        Public Property GioBatDau As TimeSpan
        Public Property GioKetThuc As TimeSpan
        Public Property TenNV As String

        Public ReadOnly Property KhungGioText As String
            Get
                Return $"{GioBatDau.ToString("hh\:mm")} - {GioKetThuc.ToString("hh\:mm")}"
            End Get
        End Property

        Public Sub New()
            LLV_NgayLam = DateTime.Today
            LLV_TrangThai = "Đã xếp lịch"
            LLV_Xoa = False
        End Sub
    End Class
End Namespace
