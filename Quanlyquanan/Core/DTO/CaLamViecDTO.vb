Namespace Core.DTO

    ''' <summary>
    ''' Thực thể dữ liệu Ca Làm Việc (ánh xạ bảng CaLamViec và số lượt xếp lịch từ LichLamViec).
    ''' </summary>
    Public Class CaLamViecDTO

        ''' <summary>Mã ca làm việc (CA_Ma)</summary>
        Public Property MaCa As Integer

        ''' <summary>Tên ca làm việc (CA_Ten)</summary>
        Public Property TenCa As String = String.Empty

        ''' <summary>Giờ bắt đầu ca (CA_GioBatDau)</summary>
        Public Property GioBatDau As TimeSpan = New TimeSpan(8, 0, 0)

        ''' <summary>Giờ kết thúc ca (CA_GioKetThuc)</summary>
        Public Property GioKetThuc As TimeSpan = New TimeSpan(15, 0, 0)

        ''' <summary>Định mức lương mỗi ca (CA_LuongMoiCa)</summary>
        Public Property LuongMoiCa As Decimal

        ''' <summary>Số lượt đã phân công trong bảng LichLamViec (LLV_Xoa = 0)</summary>
        Public Property SoLuotXepLich As Integer

        ''' <summary>Cờ xóa mềm (CA_Xoa)</summary>
        Public Property Xoa As Boolean

        ''' <summary>
        ''' Thời lượng ca làm việc tính theo số giờ (làm tròn 1 chữ số thập phân)
        ''' </summary>
        Public ReadOnly Property SoGioLam As Double
            Get
                Return Math.Round((GioKetThuc - GioBatDau).TotalHours, 1)
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị khung giờ (VD: "08:00 – 15:00")</summary>
        Public ReadOnly Property KhungGioText As String
            Get
                Return $"{GioBatDau:hh\:mm} – {GioKetThuc:hh\:mm}"
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị thời lượng ca (VD: "7.0 giờ")</summary>
        Public ReadOnly Property SoGioText As String
            Get
                Return $"{SoGioLam:0.0} giờ"
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị định mức lương mỗi ca (VD: "180,000 đ")</summary>
        Public ReadOnly Property LuongMoiCaText As String
            Get
                Return $"{LuongMoiCa:#,##0} đ"
            End Get
        End Property

        ''' <summary>Chuỗi hiển thị số lượt đã xếp lịch (VD: "6 lượt")</summary>
        Public ReadOnly Property SoLuotXepText As String
            Get
                Return $"{SoLuotXepLich} lượt"
            End Get
        End Property

    End Class

End Namespace
