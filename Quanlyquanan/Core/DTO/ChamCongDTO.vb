Namespace Core.DTO
    ''' <summary>
    ''' Data Transfer Object đại diện cho một lượt chấm công ca trực (Bảng ChamCong).
    ''' </summary>
    Public Class ChamCongDTO
        Public Property CC_Ma As Integer
        Public Property CC_MaLich As Nullable(Of Integer)
        Public Property CC_MaNV As Integer
        Public Property CC_GioBatDau As Nullable(Of DateTime)
        Public Property CC_GioKetThuc As Nullable(Of DateTime)
        Public Property CC_DaDuyet As Boolean
        Public Property CC_NguoiDuyet As Nullable(Of Integer)
        Public Property CC_ThoiGianDuyet As Nullable(Of DateTime)
        Public Property CC_Xoa As Boolean

        ' Thuộc tính bổ trợ hiển thị (Join)
        Public Property TenCa As String
        Public Property TenNV As String
        Public Property NgayLam As DateTime

        Public ReadOnly Property ThoiLuongGio As Double
            Get
                If CC_GioBatDau.HasValue AndAlso CC_GioKetThuc.HasValue Then
                    Dim diff = CC_GioKetThuc.Value - CC_GioBatDau.Value
                    Return Math.Round(diff.TotalHours, 1)
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property TrangThaiDuyetText As String
            Get
                If Not CC_GioKetThuc.HasValue Then Return "Đang làm việc"
                Return If(CC_DaDuyet, "Đã duyệt công", "Chờ quản lý duyệt")
            End Get
        End Property

        Public Sub New()
            CC_DaDuyet = False
            CC_Xoa = False
        End Sub
    End Class
End Namespace
