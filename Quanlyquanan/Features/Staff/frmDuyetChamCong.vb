Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Staff

    ''' <summary>
    ''' Màn hình Quản Lý Duyệt Chấm Công & Bảng Lương Ca (Mục 3.5 Checklist Đồ Án).
    ''' </summary>
    Public Class frmDuyetChamCong

        Private _danhSachHienTai As New List(Of BaoCaoChamCongDTO)()

        Private Sub frmDuyetChamCong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KhoiTaoThongTinNguoiDung()
            KhoiTaoCotBang()
            TaiDanhSach()
        End Sub

        Private Sub KhoiTaoThongTinNguoiDung()
            If Session.MaNhanVien > 0 Then
                lblRoleBadge.Text = $"👤 {Session.HoTenNhanVien} ({Session.TenVaiTro})"
            Else
                lblRoleBadge.Text = "👤 Quản Lý / Chủ Quán (Admin)"
            End If
        End Sub

        Private Sub KhoiTaoCotBang()
            dgvChamCong.Columns.Clear()
            dgvChamCong.Columns.Add("CC_Ma", "Mã CC")
            dgvChamCong.Columns.Add("NhanVien", "Nhân Viên")
            dgvChamCong.Columns.Add("VaiTro", "Bộ Phận")
            dgvChamCong.Columns.Add("TenCa", "Ca Trực")
            dgvChamCong.Columns.Add("GioVao", "Giờ Vào")
            dgvChamCong.Columns.Add("GioRa", "Giờ Ra")
            dgvChamCong.Columns.Add("ThoiLuong", "Tổng Giờ")
            dgvChamCong.Columns.Add("TienLuong", "Lương Dự Kiến")
            dgvChamCong.Columns.Add("TrangThai", "Trạng Thái")
            dgvChamCong.Columns.Add("NguoiDuyet", "Người Duyệt")

            dgvChamCong.Columns("CC_Ma").Width = 80
            dgvChamCong.Columns("NhanVien").Width = 160
            dgvChamCong.Columns("VaiTro").Width = 120
            dgvChamCong.Columns("TenCa").Width = 160
            dgvChamCong.Columns("GioVao").Width = 85
            dgvChamCong.Columns("GioRa").Width = 85
            dgvChamCong.Columns("ThoiLuong").Width = 90
            dgvChamCong.Columns("TienLuong").Width = 120
            dgvChamCong.Columns("TrangThai").Width = 140
            dgvChamCong.Columns("NguoiDuyet").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub TaiDanhSach()
            Dim tuNgay = dtpTuNgay.Value.Date
            Dim denNgay = dtpDenNgay.Value.Date
            Dim locTrangThai = LayMaLocTrangThai()

            _danhSachHienTai = DuyetChamCongBUS.LayDanhSach(tuNgay, denNgay, locTrangThai)
            dgvChamCong.Rows.Clear()

            For Each itm In _danhSachHienTai
                ThemDongDuLieu(itm)
            Next

            CapNhatKpiCards()
        End Sub

        Private Function LayMaLocTrangThai() As String
            Select Case cboTrangThai.SelectedIndex
                Case 1 : Return "PENDING"
                Case 2 : Return "APPROVED"
                Case Else : Return "ALL"
            End Select
        End Function

        Private Sub ThemDongDuLieu(itm As BaoCaoChamCongDTO)
            Dim vaoStr = If(itm.CC_GioBatDau.HasValue, itm.CC_GioBatDau.Value.ToString("HH:mm"), "--")
            Dim raStr = If(itm.CC_GioKetThuc.HasValue, itm.CC_GioKetThuc.Value.ToString("HH:mm"), "--")
            Dim thoiLuongStr = If(itm.CC_GioKetThuc.HasValue, $"{itm.ThoiLuongGio} giờ", "Đang trực")
            Dim luongStr = $"{itm.TienLuongDuKien:N0} đ"
            Dim nguoiDuyetStr = If(itm.CC_DaDuyet, If(Not String.IsNullOrEmpty(itm.TenNguoiDuyet), itm.TenNguoiDuyet, "Quản lý"), "—")

            Dim idx = dgvChamCong.Rows.Add(
                itm.CC_Ma, itm.HoTenNV, itm.VaiTroNV, itm.TenCa,
                vaoStr, raStr, thoiLuongStr, luongStr, itm.TrangThaiText, nguoiDuyetStr
            )

            If Not itm.CC_DaDuyet Then
                dgvChamCong.Rows(idx).DefaultCellStyle.ForeColor = Color.FromArgb(251, 191, 36)
            Else
                dgvChamCong.Rows(idx).DefaultCellStyle.ForeColor = Color.FromArgb(187, 247, 208)
            End If
        End Sub

        Private Sub CapNhatKpiCards()
            Dim tongCa = _danhSachHienTai.Count
            Dim choDuyet = _danhSachHienTai.Where(Function(x) Not x.CC_DaDuyet AndAlso x.CC_GioKetThuc.HasValue).Count()
            Dim daDuyet = _danhSachHienTai.Where(Function(x) x.CC_DaDuyet).Count()
            Dim tongLuong = _danhSachHienTai.Sum(Function(x) x.TienLuongDuKien)

            lblKpiTongCaVal.Text = $"{tongCa} ca"
            lblKpiChoDuyetVal.Text = $"{choDuyet} ca"
            lblKpiDaDuyetVal.Text = $"{daDuyet} ca"
            lblKpiLuongVal.Text = $"{tongLuong:N0} đ"
        End Sub

        Private Sub btnDuyetChon_Click(sender As Object, e As EventArgs) Handles btnDuyetChon.Click
            If dgvChamCong.CurrentRow Is Nothing Then Return
            Dim maCC = Convert.ToInt32(dgvChamCong.CurrentRow.Cells("CC_Ma").Value)
            Dim nguoiDuyet = If(Session.MaNhanVien > 0, Session.MaNhanVien, 1)

            Dim msg As String = ""
            If DuyetChamCongBUS.DuyetCa(maCC, nguoiDuyet, msg) Then
                MessageBox.Show(msg, "Duyệt Công Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDanhSach()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnHuyDuyetChon_Click(sender As Object, e As EventArgs) Handles btnHuyDuyetChon.Click
            If dgvChamCong.CurrentRow Is Nothing Then Return
            Dim maCC = Convert.ToInt32(dgvChamCong.CurrentRow.Cells("CC_Ma").Value)

            Dim msg As String = ""
            If DuyetChamCongBUS.HuyDuyetCa(maCC, msg) Then
                MessageBox.Show(msg, "Hoàn Tác Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDanhSach()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnDuyetHangLoat_Click(sender As Object, e As EventArgs) Handles btnDuyetHangLoat.Click
            Dim dsChoDuyet = _danhSachHienTai.Where(Function(x) Not x.CC_DaDuyet AndAlso x.CC_GioKetThuc.HasValue).Select(Function(x) x.CC_Ma).ToList()
            If dsChoDuyet.Count = 0 Then
                MessageBox.Show("Hiện không có ca nào đang chờ duyệt trong khoảng thời gian đã lọc!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim hoi = MessageBox.Show($"Bạn có chắc chắn muốn duyệt nhanh toàn bộ {dsChoDuyet.Count} ca đang chờ?", "Xác Nhận Duyệt Hàng Loạt", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If hoi <> DialogResult.Yes Then Return

            Dim nguoiDuyet = If(Session.MaNhanVien > 0, Session.MaNhanVien, 1)
            Dim msg As String = ""
            DuyetChamCongBUS.DuyetHangLoat(dsChoDuyet, nguoiDuyet, msg)
            MessageBox.Show(msg, "Duyệt Hàng Loạt", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TaiDanhSach()
        End Sub

        Private Sub btnLoc_Click(sender As Object, e As EventArgs) Handles btnLoc.Click
            TaiDanhSach()
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            TaiDanhSach()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmDuyetChamCong_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                TaiDanhSach()
            ElseIf e.KeyCode = Keys.F6 Then
                btnDuyetHangLoat.PerformClick()
            End If
        End Sub

    End Class

End Namespace
