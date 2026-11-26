Imports System

Namespace Core.DTO

    ''' <summary>
    ''' DTO biểu diễn một Cơ sở / Chi nhánh trong chuỗi nhà hàng (ChiNhanh).
    ''' </summary>
    Public Class ChiNhanhDTO
        Public Property MaCN As Integer = 0
        Public Property TenCN As String = String.Empty
        Public Property DiaChi As String = String.Empty
        Public Property SoDienThoai As String = String.Empty
        Public Property NguoiQuanLy As Nullable(Of Integer) = Nothing
        Public Property TenNguoiQuanLy As String = String.Empty
        Public Property SucChua As Integer = 50
        Public Property GioMoCua As String = "07:00 - 22:00"
        Public Property MoTa As String = String.Empty
        Public Property TrangThai As String = "Đang mở cửa"
        Public Property Xoa As Boolean = False
        Public Property SoBanHienCo As Integer = 0

        Public ReadOnly Property TrangThaiText As String
            Get
                Select Case TrangThai.Trim()
                    Case "Đang mở cửa"
                        Return "🟢 Đang mở cửa"
                    Case "Tạm đóng cửa"
                        Return "🟡 Tạm đóng cửa"
                    Case "Đang sửa chữa"
                        Return "🔴 Đang sửa chữa"
                    Case Else
                        Return TrangThai
                End Select
            End Get
        End Property

        Public ReadOnly Property DisplayText As String
            Get
                Return $"[{MaCN}] {TenCN}"
            End Get
        End Property
    End Class

End Namespace
