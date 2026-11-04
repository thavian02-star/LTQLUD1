Imports System.Windows.Forms
Imports Quanlyquanan.Core.Security

Namespace Features.Auth
    ''' <summary>
    ''' Màn hình Đăng nhập (Presentation / GUI Layer) cho phân hệ Xác thực.
    ''' Đã gắn kết đầy đủ các action, sự kiện và API xử lý nghiệp vụ thông qua AuthBUS.
    ''' </summary>
    Public Class frmDangNhap

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            lblThongBaoLoi.Text = String.Empty
            txtTenDangNhap.Focus()
        End Sub

        ''' <summary>
        ''' Xử lý sự kiện nhấn nút Đăng Nhập (hoặc nhấn phím Enter trên Form).
        ''' Gọi API AuthBUS để kiểm tra validation, băm mật khẩu MD5 và xác thực CSDL.
        ''' </summary>
        Private Sub btnDangNhap_Click(sender As Object, e As EventArgs) Handles btnDangNhap.Click
            lblThongBaoLoi.Text = String.Empty

            Dim tenDangNhap As String = txtTenDangNhap.Text
            Dim matKhau As String = txtMatKhau.Text
            Dim thongBaoLoi As String = String.Empty

            ' 1. Tắt tạm thời nút bấm để chống double click
            btnDangNhap.Enabled = False
            Cursor = Cursors.WaitCursor

            Try
                ' 2. Gọi tầng nghiệp vụ AuthBUS để xử lý xác thực
                Dim thanhCong As Boolean = AuthBUS.DangNhap(tenDangNhap, matKhau, thongBaoLoi)

                If thanhCong Then
                    ' Đăng nhập thành công -> Hiển thị chào mừng
                    MessageBox.Show(
                        "Đăng nhập thành công!" & vbCrLf &
                        "Xin chào: " & Session.HoTenNhanVien & " (" & Session.TenVaiTro & ")",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    )
                Else
                    ' Đăng nhập thất bại -> Hiển thị lỗi cảnh báo
                    lblThongBaoLoi.Text = thongBaoLoi
                    txtMatKhau.SelectAll()
                    txtMatKhau.Focus()
                End If
            Catch ex As Exception
                lblThongBaoLoi.Text = "Lỗi hệ thống: " & ex.Message
            Finally
                btnDangNhap.Enabled = True
                Cursor = Cursors.Default
            End Try
        End Sub

        ''' <summary>
        ''' Ẩn / Hiện mật khẩu khi tick vào ô checkbox.
        ''' </summary>
        Private Sub chkHienMatKhau_CheckedChanged(sender As Object, e As EventArgs) Handles chkHienMatKhau.CheckedChanged
            txtMatKhau.UseSystemPasswordChar = Not chkHienMatKhau.Checked
        End Sub

        ''' <summary>
        ''' Xử lý sự kiện nhấn nút Thoát (hoặc phím ESC).
        ''' </summary>
        Private Sub btnThoat_Click(sender As Object, e As EventArgs) Handles btnThoat.Click
            Dim hoiThoat As DialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            )

            If hoiThoat = DialogResult.Yes Then
                Application.Exit()
            End If
        End Sub

        ''' <summary>
        ''' Khi người dùng gõ phím Enter ở ô Tên đăng nhập, tự động chuyển con trỏ sang ô Mật khẩu.
        ''' </summary>
        Private Sub txtTenDangNhap_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTenDangNhap.KeyDown
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                txtMatKhau.Focus()
                txtMatKhau.SelectAll()
            End If
        End Sub

        ''' <summary>
        ''' Tự động xóa thông báo lỗi khi người dùng bắt đầu nhập lại.
        ''' </summary>
        Private Sub txtInputs_TextChanged(sender As Object, e As EventArgs) Handles txtTenDangNhap.TextChanged, txtMatKhau.TextChanged
            If Not String.IsNullOrEmpty(lblThongBaoLoi.Text) Then
                lblThongBaoLoi.Text = String.Empty
            End If
        End Sub
    End Class
End Namespace
