Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Staff

    ''' <summary>
    ''' Màn hình 6/9: Quản lý Danh sách Nhân sự (frmNhanVien).
    ''' Đầy đủ chức năng Tiếp nhận hồ sơ, Kỹ năng vi tính, Quản lý đồng phục cấp phát,
    ''' Liên kết tài khoản đăng nhập (RBAC), Thôi việc và Tìm kiếm lọc đa chiều.
    ''' </summary>
    Public Partial Class frmNhanVien
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmNhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' Khởi tạo giao diện ban đầu
            cboLocViTri.SelectedIndex = 0
            cboLocTrangThai.SelectedIndex = 0
            cboViTri.SelectedIndex = 2 ' Mặc định Phục vụ
            cboTrangThai.SelectedIndex = 0 ' Mặc định Đang làm việc
            cboHocVan.SelectedIndex = 0
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmNhanVien_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class

End Namespace
