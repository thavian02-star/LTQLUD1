Namespace Core.DTO

    ''' <summary>
    ''' Thực thể dữ liệu Khu Vực Bàn Ăn (ánh xạ bảng KhuVuc và thống kê bàn từ bảng Ban).
    ''' </summary>
    Public Class KhuVucDTO

        ''' <summary>Mã định danh khu vực bàn (KV_Ma)</summary>
        Public Property KV_Ma As Integer

        ''' <summary>Tên khu vực bàn (KV_Ten) - VD: Tầng trệt, Lầu 1 (Máy lạnh)...</summary>
        Public Property KV_Ten As String = String.Empty

        ''' <summary>Mô tả không gian & tiện ích (KV_MoTa)</summary>
        Public Property KV_MoTa As String = String.Empty

        ''' <summary>Cờ xóa mềm (KV_Xoa)</summary>
        Public Property KV_Xoa As Boolean

        ''' <summary>Số lượng bàn ăn đang hoạt động thuộc khu vực này (Ban.B_Xoa = 0)</summary>
        Public Property SoLuongBan As Integer

        ''' <summary>Tổng sức chứa khách tối đa của toàn bộ các bàn trong khu vực (SUM(Ban.B_SoNguoiToiDa))</summary>
        Public Property TongSucChua As Integer

        ''' <summary>Bí danh tương thích cho KV_Ma</summary>
        Public Property MaKhuVuc As Integer
            Get
                Return KV_Ma
            End Get
            Set(value As Integer)
                KV_Ma = value
            End Set
        End Property

        ''' <summary>Bí danh tương thích cho KV_Ten</summary>
        Public Property TenKhuVuc As String
            Get
                Return KV_Ten
            End Get
            Set(value As String)
                KV_Ten = value
            End Set
        End Property

        ''' <summary>Bí danh tương thích cho KV_MoTa</summary>
        Public Property MoTa As String
            Get
                Return KV_MoTa
            End Get
            Set(value As String)
                KV_MoTa = value
            End Set
        End Property

        ''' <summary>Chuỗi hiển thị số bàn (VD: "5 bàn")</summary>
        Public ReadOnly Property SoBanText As String
            Get
                Return $"{SoLuongBan} bàn"
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị tổng chỗ ngồi (VD: "20 chỗ")</summary>
        Public ReadOnly Property TongChoText As String
            Get
                Return $"{TongSucChua} chỗ"
            End Get
        End Property

        ''' <summary>Chuỗi tóm tắt thống kê trên Form Card</summary>
        Public ReadOnly Property ThongKeText As String
            Get
                Return $"🪑 Số bàn hiện có: {SoLuongBan} bàn  |  👥 Sức chứa: {TongSucChua} chỗ"
            End Get
        End Property

    End Class

End Namespace
