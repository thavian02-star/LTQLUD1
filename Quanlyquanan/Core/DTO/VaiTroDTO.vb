Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object đại diện cho một vai trò người dùng (Bảng VaiTro).
    ''' </summary>
    Public Class VaiTroDTO
        Public Property VT_Ma As Integer
        Public Property VT_Ten As String
        Public Property VT_MoTa As String
        Public Property SoLuongQuyen As Integer

        Public Sub New()
            VT_Ten = String.Empty
            VT_MoTa = String.Empty
            SoLuongQuyen = 0
        End Sub
    End Class

End Namespace
