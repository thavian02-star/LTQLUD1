Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Table

    ''' <summary>
    ''' Màn hình 5/5: Quản lý Danh sách Bàn ăn (frmBan).
    ''' Bước 2/5: Khởi tạo khung giao diện Split-Layout 38:62 và định dạng DataGridView.
    ''' </summary>
    Public Partial Class frmBan
        Inherits Form

        Private Sub frmBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
        End Sub

        ''' <summary>
        ''' Định dạng bảng DataGridView đồng bộ màu Navy chuẩn
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            dgvBan.AutoGenerateColumns = False

            With dgvBan.ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(26, 82, 118)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With dgvBan.DefaultCellStyle
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(44, 62, 80)
                .Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
                .SelectionBackColor = Color.FromArgb(214, 234, 248)
                .SelectionForeColor = Color.FromArgb(26, 82, 118)
            End With

            dgvBan.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)

            colMaBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaBan.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            colSoThuTu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoThuTu.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoThuTu.DefaultCellStyle.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)

            colSoNguoiToiDa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoNguoiToiDa.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colTrangThai.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmBan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class

End Namespace
