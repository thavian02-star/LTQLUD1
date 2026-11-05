Namespace Core.DTO
    ''' <summary>
    ''' DTO biểu diễn thông tin một Danh mục thực đơn (Bảng DanhMuc) kèm tổng số món ăn hiện có.
    ''' </summary>
    Public Class DanhMucDTO
        Public Property MaDanhMuc As Integer
        Public Property TenDanhMuc As String = String.Empty
        Public Property MoTa As String = String.Empty
        Public Property SoLuongMon As Integer = 0
        Public Property Xoa As Boolean = False
    End Class
End Namespace
