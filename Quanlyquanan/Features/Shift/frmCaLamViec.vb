Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Shift

    ''' <summary>
    ''' Màn hình 3/5: Quản lý Danh sách Ca làm việc (frmCaLamViec).
    ''' Bước 2/5: Khởi tạo khung giao diện Split-Layout 38:62 và định dạng DataGridView.
    ''' </summary>
    Public Partial Class frmCaLamViec
        Inherits Form

        Private Sub frmCaLamViec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            CapNhatThoiLuongTamThoi()
        End Sub

        ''' <summary>
        ''' Định dạng bảng DataGridView đồng bộ bảng màu Navy chuẩn của hệ thống
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            dgvCaLamViec.AutoGenerateColumns = False

            With dgvCaLamViec.ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(26, 82, 118)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With dgvCaLamViec.DefaultCellStyle
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(44, 62, 80)
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
                .SelectionBackColor = Color.FromArgb(214, 234, 248)
                .SelectionForeColor = Color.FromArgb(26, 82, 118)
            End With

            dgvCaLamViec.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)

            colMaCa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaCa.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            colKhungGio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colKhungGio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            colSoGio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoGio.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            colLuongMoiCa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colLuongMoiCa.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            colLuongMoiCa.DefaultCellStyle.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)

            colSoLuotXep.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoLuotXep.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Sub

        Private Sub CapNhatThoiLuongTamThoi()
            Dim gioBD As New TimeSpan(dtpGioBatDau.Value.Hour, dtpGioBatDau.Value.Minute, 0)
            Dim gioKT As New TimeSpan(dtpGioKetThuc.Value.Hour, dtpGioKetThuc.Value.Minute, 0)
            Dim soGio As Double = Math.Round((gioKT - gioBD).TotalHours, 1)
            If soGio <= 0 Then
                lblThoiLuong.Text = $"⚠️ Khung giờ chưa hợp lệ ({soGio:0.0} giờ)"
                lblThoiLuong.ForeColor = Color.FromArgb(192, 57, 43)
            Else
                lblThoiLuong.Text = $"⏱️ Thời lượng ca: {soGio:0.0} giờ"
                lblThoiLuong.ForeColor = Color.FromArgb(108, 52, 131)
            End If
        End Sub

        Private Sub dtpGio_ValueChanged(sender As Object, e As EventArgs) Handles dtpGioBatDau.ValueChanged, dtpGioKetThuc.ValueChanged
            CapNhatThoiLuongTamThoi()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmCaLamViec_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class

End Namespace
