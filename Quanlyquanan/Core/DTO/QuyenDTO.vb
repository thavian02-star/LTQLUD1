Imports System

Namespace Core.DTO

    ''' <summary>
    ''' Data Transfer Object đại diện cho một chức năng/quyền hạn trong hệ thống (Bảng Quyen).
    ''' </summary>
    Public Class QuyenDTO
        Public Property Q_Ma As Integer
        Public Property Q_Ten As String
        Public Property Q_MoTa As String
        Public Property Q_Tag As String
        Public Property Q_Nhom As String
        Public Property DuocCap As Boolean

        Public Sub New()
            Q_Ten = String.Empty
            Q_MoTa = String.Empty
            Q_Tag = String.Empty
            Q_Nhom = String.Empty
            DuocCap = False
        End Sub
    End Class

End Namespace
