Namespace Core.DTO
    ''' <summary>
    ''' DTO biểu diễn thông tin một Món ăn / Thức uống (Bảng MonAn kết hợp tên nhóm từ bảng DanhMuc).
    ''' </summary>
    Public Class MonAnDTO
        Public Property MaMonAn As Integer
        Public Property TenMonAn As String = String.Empty
        Public Property MaDanhMuc As Integer
        Public Property TenDanhMuc As String = String.Empty
        Public Property DonGia As Decimal = 0D
        Public Property HetMon As Boolean = False
        Public Property MoTa As String = String.Empty
        Public Property Xoa As Boolean = False

        ''' <summary>
        ''' Chuỗi hiển thị trực quan trạng thái phục vụ trên cột colTrangThai của DataGridView.
        ''' </summary>
        Public ReadOnly Property TrangThaiText As String
            Get
                Return If(HetMon, "🔴 Hết món", "🟢 Còn món")
            End Get
        End Property
    End Class
End Namespace
