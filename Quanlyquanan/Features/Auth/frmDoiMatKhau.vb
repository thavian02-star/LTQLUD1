Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.Security

Namespace Features.Auth
    ''' <summary>
    ''' Màn hình Đổi Mật Khẩu (Modal Dialog) cho tài khoản đang đăng nhập trong hệ thống.
    ''' Thực hiện kiểm tra tính hợp lệ đa tầng (Client-side & BUS), băm MD5 và lưu vào SQL Server.
    ''' </summary>
    Public Class frmDoiMatKhau

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Nạp thông tin phiên người dùng hiện tại lên Form và khởi tạo trạng thái ban đầu.
        ''' </summary>
        Private Sub frmDoiMatKhau_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Nạp thông tin người dùng từ Session
            If Not String.IsNullOrEmpty(Session.HoTenNhanVien) Then
                lblCurrentAccount.Text = "👤 " & Session.TenDangNhap & " (" & Session.HoTenNhanVien & ")"
            Else
                lblCurrentAccount.Text = "👤 " & Session.TenDangNhap
            End If

            lblCurrentRole.Text = If(String.IsNullOrEmpty(Session.TenVaiTro), "NHÂN VIÊN", Session.TenVaiTro.ToUpper())

            ' Đổi màu huy hiệu vai trò đồng bộ với frmMain
            Select Case Session.MaVaiTro
                Case 1 ' Chủ quán
                    lblCurrentRole.BackColor = Color.FromArgb(243, 156, 18) ' Cam
                Case 2 ' Quản lý
                    lblCurrentRole.BackColor = Color.FromArgb(155, 89, 182) ' Tím
                Case 3 ' Phục vụ
                    lblCurrentRole.BackColor = Color.FromArgb(46, 204, 113) ' Xanh lá
                Case 4 ' Nhà bếp / Pha chế
                    lblCurrentRole.BackColor = Color.FromArgb(230, 126, 34) ' Cam đậm
                Case Else
                    lblCurrentRole.BackColor = Color.FromArgb(41, 128, 185) ' Xanh dương
            End Select

            ' 2. Xóa trống các ô nhập và ẩn nhãn lỗi
            txtMatKhauCu.Clear()
            txtMatKhauMoi.Clear()
            txtXacNhanMoi.Clear()
            chkHienMatKhau.Checked = False
            AnThongBaoLoi()

            ' 3. Đặt con trỏ vào ô Mật khẩu cũ
            txtMatKhauCu.Focus()
        End Sub

        ''' <summary>
        ''' Bật / Tắt chế độ hiển thị ký tự mật khẩu cho cả 3 ô nhập.
        ''' </summary>
        Private Sub chkHienMatKhau_CheckedChanged(sender As Object, e As EventArgs) Handles chkHienMatKhau.CheckedChanged
            Dim anMatKhau As Boolean = Not chkHienMatKhau.Checked
            txtMatKhauCu.UseSystemPasswordChar = anMatKhau
            txtMatKhauMoi.UseSystemPasswordChar = anMatKhau
            txtXacNhanMoi.UseSystemPasswordChar = anMatKhau
        End Sub

        ''' <summary>
        ''' Tự động ẩn thông báo lỗi khi người dùng bắt đầu nhập lại dữ liệu.
        ''' </summary>
        Private Sub MatKhau_TextChanged(sender As Object, e As EventArgs) Handles txtMatKhauCu.TextChanged, txtMatKhauMoi.TextChanged, txtXacNhanMoi.TextChanged
            If lblThongBaoLoi.Visible Then
                AnThongBaoLoi()
            End If
        End Sub

        ''' <summary>
        ''' Xử lý lưu mật khẩu mới khi người dùng nhấn nút Lưu Mới (hoặc phím Enter).
        ''' </summary>
        Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
            Dim matKhauCu As String = txtMatKhauCu.Text.Trim()
            Dim matKhauMoi As String = txtMatKhauMoi.Text.Trim()
            Dim xacNhanMoi As String = txtXacNhanMoi.Text.Trim()

            ' 1. Kiểm tra Client-side Validation (ERR-01 -> ERR-05)
            If String.IsNullOrEmpty(matKhauCu) Then
                HienThongBaoLoi("⚠️ Vui lòng nhập mật khẩu cũ (hiện tại)!")
                txtMatKhauCu.Focus()
                Return
            End If

            If String.IsNullOrEmpty(matKhauMoi) Then
                HienThongBaoLoi("⚠️ Vui lòng nhập mật khẩu mới!")
                txtMatKhauMoi.Focus()
                Return
            End If

            If matKhauMoi.Length < 6 Then
                HienThongBaoLoi("⚠️ Mật khẩu mới phải có ít nhất 6 ký tự!")
                txtMatKhauMoi.Focus()
                txtMatKhauMoi.SelectAll()
                Return
            End If

            If matKhauMoi = matKhauCu Then
                HienThongBaoLoi("⚠️ Mật khẩu mới không được trùng với mật khẩu cũ!")
                txtMatKhauMoi.Focus()
                txtMatKhauMoi.SelectAll()
                Return
            End If

            If matKhauMoi <> xacNhanMoi Then
                HienThongBaoLoi("⚠️ Mật khẩu mới và xác nhận mật khẩu không khớp!")
                txtXacNhanMoi.Focus()
                txtXacNhanMoi.SelectAll()
                Return
            End If

            ' 2. Gọi tầng nghiệp vụ AuthBUS để xác thực mật khẩu cũ và cập nhật CSDL
            Dim thongBaoLoi As String = ""
            Dim thanhCong As Boolean = AuthBUS.DoiMatKhau(matKhauCu, matKhauMoi, xacNhanMoi, thongBaoLoi)

            If Not thanhCong Then
                HienThongBaoLoi("⚠️ " & thongBaoLoi)
                If thongBaoLoi.Contains("cũ") Then
                    txtMatKhauCu.Focus()
                    txtMatKhauCu.SelectAll()
                Else
                    txtMatKhauMoi.Focus()
                    txtMatKhauMoi.SelectAll()
                End If
                Return
            End If

            ' 3. Đổi mật khẩu thành công (SUCCESS)
            AnThongBaoLoi()
            MessageBox.Show(
                "Đổi mật khẩu thành công!" & vbCrLf & "Mật khẩu mới đã được cập nhật an toàn vào hệ thống.",
                "Thông Báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )

            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        ''' <summary>
        ''' Xử lý khi nhấn nút Hủy Bỏ (hoặc phím Esc).
        ''' </summary>
        Private Sub btnHuy_Click(sender As Object, e As EventArgs) Handles btnHuy.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        ''' <summary>
        ''' Cơ chế dọn dẹp bộ nhớ RAM bảo mật khi đóng Form.
        ''' </summary>
        Private Sub frmDoiMatKhau_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
            txtMatKhauCu.Clear()
            txtMatKhauMoi.Clear()
            txtXacNhanMoi.Clear()
        End Sub

        Private Sub HienThongBaoLoi(noiDung As String)
            lblThongBaoLoi.Text = noiDung
            lblThongBaoLoi.Visible = True
        End Sub

        Private Sub AnThongBaoLoi()
            lblThongBaoLoi.Text = ""
            lblThongBaoLoi.Visible = False
        End Sub
    End Class
End Namespace
