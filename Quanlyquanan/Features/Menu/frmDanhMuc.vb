Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Menu
    ''' <summary>
    ''' Màn hình 1 (Checklist Ưu tiên): Quản lý Danh mục Thực đơn (Bảng DanhMuc).
    ''' Bước 2/5: Khởi tạo giao diện chuẩn Split-Layout 38%:62% & cấu hình DataGridView.
    ''' </summary>
    Public Class frmDanhMuc

        Private Sub frmDanhMuc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
        End Sub

        ''' <summary>
        ''' Định dạng màu sắc Header, dòng xen kẽ và căn lề cột trên dgvDanhMuc.
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            With dgvDanhMuc
                .AutoGenerateColumns = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
                .ColumnHeadersDefaultCellStyle.Padding = New Padding(6, 0, 6, 0)

                .DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
                .DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)
                .DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42)
                .DefaultCellStyle.Padding = New Padding(6, 0, 6, 0)

                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
            End With

            colMaDM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaDM.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaDM.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colTenDM.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colSoLuongMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoLuongMon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoLuongMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmDanhMuc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class
End Namespace
