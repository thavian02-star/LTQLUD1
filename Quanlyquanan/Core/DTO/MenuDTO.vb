Imports System

Namespace Core.DTO

    ''' <summary>
    ''' DTO biểu diễn một Bảng Thực Đơn Kinh Doanh (Menu Catalog) - Tầng 2 trong kiến trúc Thực đơn F&amp;B.
    ''' </summary>
    Public Class MenuDTO
        Public Property MaMenu As Integer = 0
        Public Property TenMenu As String = String.Empty
        Public Property LoaiMenu As String = "Alacarte"
        Public Property MoTa As String = String.Empty
        Public Property TrangThai As String = "Đang áp dụng"
        Public Property Xoa As Boolean = False
        Public Property SoLuongMon As Integer = 0

        ''' <summary>
        ''' Chuỗi hiển thị trực quan trạng thái trên DataGridView.
        ''' </summary>
        Public ReadOnly Property TrangThaiText As String
            Get
                Select Case TrangThai.Trim()
                    Case "Đang áp dụng"
                        Return "🟢 Đang áp dụng"
                    Case "Tạm ngưng"
                        Return "🟡 Tạm ngưng"
                    Case "Dự thảo"
                        Return "⚪ Dự thảo"
                    Case Else
                        Return TrangThai
                End Select
            End Get
        End Property

        ''' <summary>
        ''' Hiển thị text trong ComboBox chọn Menu nếu cần.
        ''' </summary>
        Public ReadOnly Property DisplayText As String
            Get
                Return $"[{MaMenu}] {TenMenu} ({LoaiMenu})"
            End Get
        End Property
    End Class

    ''' <summary>
    ''' DTO biểu diễn một Món Ăn được gán vào Bảng Menu cụ thể kèm giá bán niêm yết theo Menu (Menu_MonAn).
    ''' </summary>
    Public Class MenuMonAnDTO
        Public Property MaMMA As Integer = 0
        Public Property MaMenu As Integer = 0
        Public Property MaMonAn As Integer = 0
        Public Property TenMonAn As String = String.Empty
        Public Property TenDanhMuc As String = String.Empty
        Public Property DonGia As Decimal = 0D
        Public Property ThuTuHienThi As Integer = 1
        Public Property GhiChu As String = String.Empty
        Public Property Xoa As Boolean = False

        ''' <summary>
        ''' Định dạng đơn giá hiển thị dạng tiền tệ (VD: "45,000 đ" hoặc "0 đ (Buffet)").
        ''' </summary>
        Public ReadOnly Property DonGiaHienThi As String
            Get
                If DonGia = 0D Then
                    Return "0 đ (Trọn gói)"
                End If
                Return DonGia.ToString("N0") & " đ"
            End Get
        End Property
    End Class

End Namespace
