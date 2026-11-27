Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object phục vụ việc duyệt chấm công và tính lương ca của nhân viên.
    ''' </summary>
    Public Class BaoCaoChamCongDTO
        Public Property CC_Ma As Integer
        Public Property CC_MaNV As Integer
        Public Property HoTenNV As String
        Public Property VaiTroNV As String
        Public Property TenCa As String
        Public Property LuongMoiCa As Decimal
        Public Property CC_GioBatDau As Nullable(Of DateTime)
        Public Property CC_GioKetThuc As Nullable(Of DateTime)
        Public Property CC_DaDuyet As Boolean
        Public Property CC_NguoiDuyet As Nullable(Of Integer)
        Public Property TenNguoiDuyet As String
        Public Property CC_ThoiGianDuyet As Nullable(Of DateTime)

        Public ReadOnly Property ThoiLuongGio As Double
            Get
                If CC_GioBatDau.HasValue AndAlso CC_GioKetThuc.HasValue Then
                    Dim diff = CC_GioKetThuc.Value - CC_GioBatDau.Value
                    Return Math.Round(diff.TotalHours, 1)
                End If
                Return 0
            End Get
        End Property

        Public ReadOnly Property TienLuongDuKien As Decimal
            Get
                ' Nếu có cấu hình lương ca thì lấy lương ca, tối thiểu 200,000 đ
                Return If(LuongMoiCa > 0, LuongMoiCa, 200000D)
            End Get
        End Property

        Public ReadOnly Property TrangThaiText As String
            Get
                If Not CC_GioKetThuc.HasValue Then Return "Đang làm việc"
                Return If(CC_DaDuyet, "Đã duyệt công", "Chờ quản lý duyệt")
            End Get
        End Property

        Public Sub New()
            HoTenNV = String.Empty
            VaiTroNV = String.Empty
            TenCa = String.Empty
            LuongMoiCa = 200000D
            CC_DaDuyet = False
        End Sub
    End Class

End Namespace
