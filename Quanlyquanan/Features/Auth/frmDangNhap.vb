Namespace Features.Auth
    ''' <summary>
    ''' Màn hình Đăng nhập (Presentation / GUI Layer) cho phân hệ Xác thực.
    ''' Chứa các control: Tên đăng nhập, Mật khẩu, Checkbox hiển thị mật khẩu, nút Đăng nhập và Thoát.
    ''' </summary>
    Public Class frmDangNhap

        Public Sub New()
            ' Hàm khởi tạo nạp các control giao diện
            InitializeComponent()
        End Sub

        Private Sub frmDangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Thiết lập khởi tạo giao diện
            lblThongBaoLoi.Text = String.Empty
        End Sub

    End Class
End Namespace
