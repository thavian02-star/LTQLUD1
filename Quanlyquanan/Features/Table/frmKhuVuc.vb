Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Table

    ''' <summary>
    ''' Màn hình 4/5: Quản lý Khu vực bàn ăn (frmKhuVuc).
    ''' </summary>
    Public Partial Class frmKhuVuc
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

    End Class

End Namespace
