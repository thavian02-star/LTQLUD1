Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Menu
    ''' <summary>
    ''' Màn hình 2 (Checklist Ưu tiên): Quản lý Món ăn &amp; Thức uống (Bảng MonAn).
    ''' Bước 2/5: Khởi tạo giao diện WinForms Split-Layout 38:62 và cấu hình bảng dgvMonAn.
    ''' </summary>
    Public Class frmMonAn

        Private Sub frmMonAn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
        End Sub

        ''' <summary>
        ''' Định dạng màu sắc Header, dòng xen kẽ và căn lề các cột trên dgvMonAn.
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            With dgvMonAn
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

            colMaMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaMon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colTenMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colDonGia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            colDonGia.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            colDonGia.DefaultCellStyle.ForeColor = Color.FromArgb(29, 78, 216)

            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colTrangThai.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colTrangThai.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmMonAn_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class
End Namespace
