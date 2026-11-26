Imports System

Namespace Core.DTO

    ''' <summary>
    ''' DTO biểu diễn phân bổ thực đơn cho một chi nhánh (ChiNhanh_Menu).
    ''' </summary>
    Public Class ChiNhanhMenuDTO
        Public Property MaCNM As Integer = 0
        Public Property MaChiNhanh As Integer = 0
        Public Property TenChiNhanh As String = String.Empty
        Public Property MaMenu As Integer = 0
        Public Property TenMenu As String = String.Empty
        Public Property LoaiMenu As String = "Alacarte"
        Public Property NgayBatDau As Date = Date.Today
        Public Property NgayKetThuc As Nullable(Of Date) = Nothing
        Public Property GhiChu As String = String.Empty
        Public Property TrangThai As String = "Đang áp dụng"
        Public Property Xoa As Boolean = False
        Public Property SoMonAn As Integer = 0

        Public ReadOnly Property TrangThaiText As String
            Get
                Select Case TrangThai.Trim()
                    Case "Đang áp dụng"
                        Return "🟢 Đang áp dụng"
                    Case "Tạm ngưng"
                        Return "🟡 Tạm ngưng"
                    Case "Hết hạn"
                        Return "🔴 Hết hạn"
                    Case Else
                        Return TrangThai
                End Select
            End Get
        End Property

        Public ReadOnly Property NgayKetThucText As String
            Get
                If NgayKetThuc.HasValue Then
                    Return NgayKetThuc.Value.ToString("dd/MM/yyyy")
                End If
                Return "(Vô thời hạn)"
            End Get
        End Property

        Public ReadOnly Property DisplayText As String
            Get
                Return $"[{MaMenu}] {TenMenu} ({LoaiMenu})"
            End Get
        End Property
    End Class

End Namespace
