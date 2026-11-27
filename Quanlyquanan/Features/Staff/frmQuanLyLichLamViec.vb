Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO

Namespace Features.Staff

    ''' <summary>
    ''' Màn hình Quản Lý Phân Ca & Lịch Làm Việc Tuần (Mục 3.5 Checklist Đồ Án).
    ''' </summary>
    Public Class frmQuanLyLichLamViec

        Private _ngayMocHienTai As DateTime = DateTime.Today
        Private _danhSachMaTran As New List(Of MaTranLichTuanDTO)()

        Private Sub frmQuanLyLichLamViec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KhoiTaoComboBoxes()
            KhoiTaoCotBang()
            TaiDuLieuLichTuan()
        End Sub

        Private Sub KhoiTaoComboBoxes()
            cboNhanVien.Items.Clear()
            cboNhanVien.Items.Add(New KeyValuePair(Of Integer, String)(1, "Nguyễn Văn A (Phục vụ bàn)"))
            cboNhanVien.Items.Add(New KeyValuePair(Of Integer, String)(2, "Trần Thị B (Phục vụ bàn)"))
            cboNhanVien.Items.Add(New KeyValuePair(Of Integer, String)(3, "Lê Hoàng C (Nhà bếp)"))
            cboNhanVien.Items.Add(New KeyValuePair(Of Integer, String)(4, "Phạm Hải D (Nhà bếp)"))
            cboNhanVien.DisplayMember = "Value"
            cboNhanVien.ValueMember = "Key"
            cboNhanVien.SelectedIndex = 0

            cboCa.Items.Clear()
            cboCa.Items.Add(New KeyValuePair(Of Integer, String)(1, "Ca Sáng (06:00 - 14:00)"))
            cboCa.Items.Add(New KeyValuePair(Of Integer, String)(2, "Ca Chiều (14:00 - 22:00)"))
            cboCa.DisplayMember = "Value"
            cboCa.ValueMember = "Key"
            cboCa.SelectedIndex = 0
        End Sub

        Private Sub KhoiTaoCotBang()
            Dim tuNgay = LichLamViecBUS.TinhNgayDauTuan(_ngayMocHienTai)
            dgvLichTuan.Columns.Clear()
            dgvLichTuan.Columns.Add("MaNV", "Mã NV")
            dgvLichTuan.Columns.Add("HoTenNV", "Họ Tên Nhân Viên")
            dgvLichTuan.Columns.Add("TenVaiTro", "Bộ Phận")

            Dim tenCacThu As String() = {"Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật"}
            For i As Integer = 0 To 6
                Dim d = tuNgay.AddDays(i)
                dgvLichTuan.Columns.Add($"ColNgay{i}", $"{tenCacThu(i)}{vbCrLf}({d:dd/MM})")
            Next
            dgvLichTuan.Columns.Add("TongCa", "Tổng Ca")

            DinhDangDoRongCot()
        End Sub

        Private Sub DinhDangDoRongCot()
            dgvLichTuan.Columns("MaNV").Width = 75
            dgvLichTuan.Columns("HoTenNV").Width = 180
            dgvLichTuan.Columns("TenVaiTro").Width = 120
            For i As Integer = 0 To 6
                dgvLichTuan.Columns($"ColNgay{i}").Width = 110
                dgvLichTuan.Columns($"ColNgay{i}").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            dgvLichTuan.Columns("TongCa").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgvLichTuan.Columns("TongCa").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End Sub

        Private Sub TaiDuLieuLichTuan()
            Dim tuNgay = LichLamViecBUS.TinhNgayDauTuan(_ngayMocHienTai)
            Dim denNgay = tuNgay.AddDays(6).Date
            lblWeekInfo.Text = $"Tuần từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}"

            _danhSachMaTran = LichLamViecBUS.LayMaTranLichTuan(_ngayMocHienTai)
            dgvLichTuan.Rows.Clear()

            For Each r In _danhSachMaTran
                ThemDongMaTran(r)
            Next

            CapNhatKpis()
        End Sub

        Private Sub ThemDongMaTran(r As MaTranLichTuanDTO)
            Dim idx = dgvLichTuan.Rows.Add(
                $"#NV{r.MaNV}", r.HoTenNV, r.TenVaiTro,
                r.CaThuHai, r.CaThuBa, r.CaThuTu, r.CaThuNam,
                r.CaThuSau, r.CaThuBay, r.CaChuNhat,
                $"{r.TongSoCaTrongTuan} ca"
            )

            For c As Integer = 3 To 9
                ToMauCellCaTruc(dgvLichTuan.Rows(idx).Cells(c))
            Next
        End Sub

        Private Sub ToMauCellCaTruc(cell As DataGridViewCell)
            Dim txt = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
            If txt.Contains("Sáng") Then
                cell.Style.ForeColor = Color.FromArgb(56, 189, 248)
                cell.Style.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            ElseIf txt.Contains("Chiều") Then
                cell.Style.ForeColor = Color.FromArgb(251, 191, 36)
                cell.Style.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Else
                cell.Style.ForeColor = Color.FromArgb(100, 116, 139)
            End If
        End Sub

        Private Sub CapNhatKpis()
            Dim tongCa = _danhSachMaTran.Sum(Function(x) x.TongSoCaTrongTuan)
            Dim phucVu = _danhSachMaTran.Where(Function(x) x.TenVaiTro.Contains("Phục vụ")).Sum(Function(x) x.TongSoCaTrongTuan)
            Dim nhaBep = _danhSachMaTran.Where(Function(x) x.TenVaiTro.Contains("bếp")).Sum(Function(x) x.TongSoCaTrongTuan)

            lblKpiTongCaVal.Text = $"{tongCa} ca"
            lblKpiPhucVuVal.Text = $"{phucVu} ca"
            lblKpiNhaBepVal.Text = $"{nhaBep} ca"
            lblKpiDoPhuVal.Text = "100%"
        End Sub

        Private Sub btnPhanCa_Click(sender As Object, e As EventArgs) Handles btnPhanCa.Click
            If cboNhanVien.SelectedItem Is Nothing OrElse cboCa.SelectedItem Is Nothing Then Return
            Dim maNV = CType(cboNhanVien.SelectedItem, KeyValuePair(Of Integer, String)).Key
            Dim maCa = CType(cboCa.SelectedItem, KeyValuePair(Of Integer, String)).Key
            Dim ngayLam = dtpNgayLam.Value.Date

            Dim msg As String = ""
            If LichLamViecBUS.PhanCongCa(maNV, maCa, ngayLam, msg) Then
                MessageBox.Show(msg, "Phân Ca Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDuLieuLichTuan()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnHuyCa_Click(sender As Object, e As EventArgs) Handles btnHuyCa.Click
            If cboNhanVien.SelectedItem Is Nothing Then Return
            Dim maNV = CType(cboNhanVien.SelectedItem, KeyValuePair(Of Integer, String)).Key
            Dim ngayLam = dtpNgayLam.Value.Date

            Dim msg As String = ""
            If LichLamViecBUS.HuyPhanCa(maNV, ngayLam, msg) Then
                MessageBox.Show(msg, "Hủy Ca Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDuLieuLichTuan()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnTuanTruoc_Click(sender As Object, e As EventArgs) Handles btnTuanTruoc.Click
            _ngayMocHienTai = _ngayMocHienTai.AddDays(-7)
            KhoiTaoCotBang()
            TaiDuLieuLichTuan()
        End Sub

        Private Sub btnTuanNay_Click(sender As Object, e As EventArgs) Handles btnTuanNay.Click
            _ngayMocHienTai = DateTime.Today
            KhoiTaoCotBang()
            TaiDuLieuLichTuan()
        End Sub

        Private Sub btnTuanSau_Click(sender As Object, e As EventArgs) Handles btnTuanSau.Click
            _ngayMocHienTai = _ngayMocHienTai.AddDays(7)
            KhoiTaoCotBang()
            TaiDuLieuLichTuan()
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            TaiDuLieuLichTuan()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmQuanLyLichLamViec_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                TaiDuLieuLichTuan()
            End If
        End Sub

    End Class

End Namespace
