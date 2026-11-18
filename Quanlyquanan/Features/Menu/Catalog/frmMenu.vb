Imports System
Imports System.Windows.Forms

Namespace Features.Menu

    Public Class frmMenu

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Khoi tao ban dau
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

    End Class

End Namespace
