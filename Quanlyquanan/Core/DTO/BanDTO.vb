Namespace Core.DTO

    ''' <summary>
    ''' Thực thể dữ liệu Bàn ăn (ánh xạ bảng Ban và thông tin hóa đơn đang phục vụ).
    ''' </summary>
    Public Class BanDTO

        ''' <summary>Mã định danh bàn (B_Ma)</summary>
        Public Property MaBan As Integer

        ''' <summary>Số thứ tự hiển thị của bàn (B_SoThuTu)</summary>
        Public Property SoThuTu As Integer

        ''' <summary>Tên bàn ăn (B_TenBan - VD: Bàn 01, Bàn 09 (VIP 1))</summary>
        Public Property TenBan As String = String.Empty

        ''' <summary>Khu vực bố trí bàn (B_KhuVuc - VD: Tầng trệt, Lầu 1, Phòng VIP...)</summary>
        Public Property KhuVuc As String = "Tầng trệt"

        ''' <summary>Sức chứa số người tối đa (B_SoNguoiToiDa)</summary>
        Public Property SoNguoiToiDa As Integer = 4

        ''' <summary>
        ''' Trạng thái bàn (B_TrangThai):
        ''' 0: Trống, 1: Có khách, 2: Đang đợi món, 3: Món đã xong
        ''' </summary>
        Public Property TrangThai As Integer = 0

        ''' <summary>Cờ xóa mềm (B_Xoa)</summary>
        Public Property Xoa As Boolean = False

        ''' <summary>Mã hóa đơn đang mở tại bàn này (nếu có)</summary>
        Public Property MaHoaDonHienTai As Integer? = Nothing

        ''' <summary>Họ tên nhân viên phục vụ đang phụ trách bàn</summary>
        Public Property TenNVPhucVu As String = String.Empty

        ''' <summary>Chuỗi hiển thị sức chứa (VD: "4 người")</summary>
        Public ReadOnly Property SucChuaText As String
            Get
                Return $"{SoNguoiToiDa} người"
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị trạng thái bàn</summary>
        Public ReadOnly Property TrangThaiText As String
            Get
                Select Case TrangThai
                    Case 0 : Return "0 - Bàn Trống"
                    Case 1 : Return "1 - Có khách"
                    Case 2 : Return "2 - Đang đợi món"
                    Case 3 : Return "3 - Món đã xong"
                    Case Else : Return "Không rõ"
                End Select
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị thông tin hóa đơn đang mở</summary>
        Public ReadOnly Property ThongTinHoaDon As String
            Get
                If MaHoaDonHienTai.HasValue AndAlso MaHoaDonHienTai.Value > 0 Then
                    Dim nvText As String = If(String.IsNullOrWhiteSpace(TenNVPhucVu), "Chưa gán NV", TenNVPhucVu)
                    Return $"HĐ #{MaHoaDonHienTai.Value} ({nvText})"
                End If
                Return "Trống"
            End Get
        End Property

    End Class

End Namespace
