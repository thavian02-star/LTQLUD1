Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Quanlyquanan.Core.Security

Namespace Features.Auth

    ''' <summary>
    ''' Màn hình Đăng nhập (Presentation / GUI Layer) cho phân hệ Xác thực.
    ''' Đã tích hợp sẵn bộ chọn nhanh 4 tài khoản mẫu (Chủ quán, Quản lý, Phục vụ, Nhà bếp).
    ''' </summary>
    Public Class frmDangNhap

        Private Class TaiKhoanMauItem
            Public Property DisplayText As String
            Public Property Username As String
            Public Property Password As String

            Public Sub New(display As String, u As String, p As String)
                DisplayText = display
                Username = u
                Password = p
            End Sub

            Public Overrides Function ToString() As String
                Return DisplayText
            End Function
        End Class

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lblThongBaoLoi.Text = String.Empty
            NapDanhSachTaiKhoanMau()
        End Sub

        Private Sub NapDanhSachTaiKhoanMau()
            Dim ds As New List(Of TaiKhoanMauItem) From {
                New TaiKhoanMauItem("👑 [Chủ Quán] - chuquan (Full 100% quyền hệ thống)", "chuquan", "123456"),
                New TaiKhoanMauItem("👔 [Quản Lý] - quanly (Quản trị chi nhánh, menu, ca)", "quanly", "123456"),
                New TaiKhoanMauItem("🍽️ [Phục Vụ] - phucvu1 (Sơ đồ bàn, gọi món POS)", "phucvu1", "123456"),
                New TaiKhoanMauItem("🍳 [Nhà Bếp] - nhabep1 (Hàng đợi món FIFO)", "nhabep1", "123456")
            }
            cboTaiKhoanMau.DataSource = ds
            cboTaiKhoanMau.DisplayMember = "DisplayText"
            If cboTaiKhoanMau.Items.Count > 0 Then
                cboTaiKhoanMau.SelectedIndex = 0
            End If
        End Sub

        Private Sub cboTaiKhoanMau_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTaiKhoanMau.SelectedIndexChanged
            Dim item As TaiKhoanMauItem = TryCast(cboTaiKhoanMau.SelectedItem, TaiKhoanMauItem)
            If item IsNot Nothing Then
                txtTenDangNhap.Text = item.Username
                txtMatKhau.Text = item.Password
                lblThongBaoLoi.Text = String.Empty
            End If
        End Sub

        Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
            lblThongBaoLoi.Text = String.Empty
            Dim tenDangNhap As String = txtTenDangNhap.Text
            Dim matKhau As String = txtMatKhau.Text
            Dim thongBaoLoi As String = String.Empty

            btnDangNhap.Enabled = False
            Cursor = Cursors.WaitCursor

            Try
                Dim thanhCong As Boolean = AuthBUS.DangNhap(tenDangNhap, matKhau, thongBaoLoi)
                If thanhCong Then
                    XuLyDangNhapThanhCong()
                Else
                    lblThongBaoLoi.Text = thongBaoLoi
                    txtMatKhau.Focus()
                End If
            Finally
                btnDangNhap.Enabled = True
                Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub XuLyDangNhapThanhCong()
            txtMatKhau.Clear()
            lblThongBaoLoi.Text = String.Empty

            Dim fMain As New Features.Main.frmMain()
            AddHandler fMain.FormClosed, Sub(s, args)
                                             If fMain.DialogResult = DialogResult.OK Then
                                                 txtTenDangNhap.Focus()
                                                 Me.Show()
                                             Else
                                                 Me.Close()
                                             End If
                                         End Sub
            Me.Hide()
            fMain.Show()
        End Sub

        Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
            Dim hoi As DialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )
            If hoi = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        Private Sub chkHienMatKhau_CheckedChanged(sender As Object, e As EventArgs) Handles chkHienMatKhau.CheckedChanged
            txtMatKhau.UseSystemPasswordChar = Not chkHienMatKhau.Checked
        End Sub

        Private Sub txtTenDangNhap_TextChanged(sender As Object, e As EventArgs) Handles txtTenDangNhap.TextChanged
            lblThongBaoLoi.Text = String.Empty
        End Sub

        Private Sub txtMatKhau_TextChanged(sender As Object, e As EventArgs) Handles txtMatKhau.TextChanged
            lblThongBaoLoi.Text = String.Empty
        End Sub

    End Class

End Namespace
