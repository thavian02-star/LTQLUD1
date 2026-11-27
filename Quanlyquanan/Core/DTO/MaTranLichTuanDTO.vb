Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object đại diện cho 1 dòng nhân sự trong ma trận phân ca 7 ngày tuần.
    ''' </summary>
    Public Class MaTranLichTuanDTO
        Public Property MaNV As Integer
        Public Property HoTenNV As String
        Public Property TenVaiTro As String
        Public Property CaThuHai As String
        Public Property CaThuBa As String
        Public Property CaThuTu As String
        Public Property CaThuNam As String
        Public Property CaThuSau As String
        Public Property CaThuBay As String
        Public Property CaChuNhat As String

        Public ReadOnly Property TongSoCaTrongTuan As Integer
            Get
                Dim count As Integer = 0
                Dim arr As String() = {CaThuHai, CaThuBa, CaThuTu, CaThuNam, CaThuSau, CaThuBay, CaChuNhat}
                For Each c In arr
                    If Not String.IsNullOrEmpty(c) AndAlso c <> "—" AndAlso Not c.ToLower().Contains("nghỉ") Then
                        count += 1
                    End If
                Next
                Return count
            End Get
        End Property

        Public Sub New()
            HoTenNV = String.Empty
            TenVaiTro = String.Empty
            CaThuHai = "—"
            CaThuBa = "—"
            CaThuTu = "—"
            CaThuNam = "—"
            CaThuSau = "—"
            CaThuBay = "—"
            CaChuNhat = "—"
        End Sub
    End Class

End Namespace
