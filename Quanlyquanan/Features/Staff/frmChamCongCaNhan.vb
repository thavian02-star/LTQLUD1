Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Staff

    ''' <summary>
    ''' Màn hình Chấm Công & Lịch Trực Cá Nhân (Mục 3.2 Checklist Đồ Án).
    ''' </summary>
    Public Class frmChamCongCaNhan

        Private _maNVHienTai As Integer = 1
        Private _ngayMocTuan As DateTime = DateTime.Today
        Private _phienChamCongHienTai As ChamCongDTO = Nothing

        Private Sub frmChamCongCaNhan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KhoiTaoThongTinNguoiDung()
            KhoiTaoCotBangLichTuan()
            KhoiTaoCotBangLichSu()
            LamMoiToanBoDuLieu()
        End Sub

        Private Sub KhoiTaoThongTinNguoiDung()
            If Session.MaNhanVien > 0 Then
                _maNVHienTai = Session.MaNhanVien
                lblNhanVienInfo.Text = $"👤 Nhân viên: {Session.HoTenNhanVien} ({Session.TenVaiTro})"
            Else
                _maNVHienTai = 1
                lblNhanVienInfo.Text = "👤 Nhân viên: Nguyễn Văn A (Phục vụ bàn)"
            End If
        End Sub

        Private Sub KhoiTaoCotBangLichTuan()
            dgvLichTuan.Columns.Clear()
            dgvLichTuan.Columns.Add("Ngay", "Ngày")
            dgvLichTuan.Columns.Add("Thu", "Thứ")
            dgvLichTuan.Columns.Add("Ca", "Ca Làm Việc")
            dgvLichTuan.Columns.Add("KhungGio", "Khung Giờ")
            dgvLichTuan.Columns.Add("TrangThai", "Trạng Thái")

            dgvLichTuan.Columns("Ngay").Width = 110
            dgvLichTuan.Columns("Thu").Width = 100
            dgvLichTuan.Columns("Ca").Width = 140
            dgvLichTuan.Columns("KhungGio").Width = 160
            dgvLichTuan.Columns("TrangThai").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub KhoiTaoCotBangLichSu()
            dgvLichSu.Columns.Clear()
            dgvLichSu.Columns.Add("NgayLam", "Ngày Làm")
            dgvLichSu.Columns.Add("CaLam", "Ca Trực")
            dgvLichSu.Columns.Add("GioVao", "Giờ Vào")
            dgvLichSu.Columns.Add("GioRa", "Giờ Ra")
            dgvLichSu.Columns.Add("ThoiLuong", "Tổng Giờ")
            dgvLichSu.Columns.Add("TrangThaiDuyet", "Tình Trạng Duyệt")

            dgvLichSu.Columns("NgayLam").Width = 110
            dgvLichSu.Columns("CaLam").Width = 130
            dgvLichSu.Columns("GioVao").Width = 100
            dgvLichSu.Columns("GioRa").Width = 100
            dgvLichSu.Columns("ThoiLuong").Width = 110
            dgvLichSu.Columns("TrangThaiDuyet").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub LamMoiToanBoDuLieu()
            CapNhatTrangThaiCaHienTai()
            TaiLichTuan()
            TaiLichSu()
        End Sub

        Private Sub CapNhatTrangThaiCaHienTai()
            _phienChamCongHienTai = ChamCongBUS.LayChamCongHomNay(_maNVHienTai)
            If _phienChamCongHienTai Is Nothing Then
                lblTrangThaiBadge.Text = "CHƯA VÀO CA"
                lblTrangThaiBadge.BackColor = Color.FromArgb(71, 85, 105)
                lblGioVaoVal.Text = "--:--"
                lblThoiLuongVal.Text = "0.0 giờ"
                btnVaoCa.Enabled = True
                btnRaCa.Enabled = False
            ElseIf Not _phienChamCongHienTai.CC_GioKetThuc.HasValue Then
                lblTrangThaiBadge.Text = "ĐANG TRONG CA TRỰC"
                lblTrangThaiBadge.BackColor = Color.FromArgb(16, 185, 129)
                lblGioVaoVal.Text = _phienChamCongHienTai.CC_GioBatDau.Value.ToString("HH:mm")
                btnVaoCa.Enabled = False
                btnRaCa.Enabled = True
                CapNhatThoiLuongTrucTiep()
            Else
                lblTrangThaiBadge.Text = "ĐÃ KẾT THÚC CA HÔM NAY"
                lblTrangThaiBadge.BackColor = Color.FromArgb(37, 99, 235)
                lblGioVaoVal.Text = _phienChamCongHienTai.CC_GioBatDau.Value.ToString("HH:mm")
                lblThoiLuongVal.Text = $"{_phienChamCongHienTai.ThoiLuongGio} giờ"
                btnVaoCa.Enabled = False
                btnRaCa.Enabled = False
            End If
        End Sub

        Private Sub CapNhatThoiLuongTrucTiep()
            If _phienChamCongHienTai IsNot Nothing AndAlso _phienChamCongHienTai.CC_GioBatDau.HasValue AndAlso Not _phienChamCongHienTai.CC_GioKetThuc.HasValue Then
                Dim diff = DateTime.Now - _phienChamCongHienTai.CC_GioBatDau.Value
                lblThoiLuongVal.Text = $"{Math.Round(diff.TotalHours, 1)} giờ ({diff.Hours}h {diff.Minutes}p)"
            End If
        End Sub

        Private Sub TaiLichTuan()
            Dim delta = DayOfWeek.Monday - _ngayMocTuan.DayOfWeek
            If delta > 0 Then delta -= 7
            Dim thuHai = _ngayMocTuan.AddDays(delta).Date
            Dim chuNhat = thuHai.AddDays(6).Date
            lblTuanHienTai.Text = $"Tuần từ {thuHai:dd/MM/yyyy} đến {chuNhat:dd/MM/yyyy}"

            Dim ds = ChamCongBUS.LayLichTuan(_maNVHienTai, _ngayMocTuan)
            dgvLichTuan.Rows.Clear()
            For i As Integer = 0 To 6
                Dim ngay = thuHai.AddDays(i)
                Dim lich = ds.FirstOrDefault(Function(x) x.LLV_NgayLam.Date = ngay.Date)
                ThemDongLichTuan(ngay, lich)
            Next
        End Sub

        Private Sub ThemDongLichTuan(ngay As DateTime, lich As LichLamViecDTO)
            Dim tenThu = LayTenThuTiengViet(ngay.DayOfWeek)
            If lich IsNot Nothing Then
                dgvLichTuan.Rows.Add(ngay.ToString("dd/MM/yyyy"), tenThu, lich.TenCa, lich.KhungGioText, lich.LLV_TrangThai)
            Else
                Dim idx = dgvLichTuan.Rows.Add(ngay.ToString("dd/MM/yyyy"), tenThu, "—", "—", "Nghỉ ca")
                dgvLichTuan.Rows(idx).DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184)
            End If
        End Sub

        Private Function LayTenThuTiengViet(dow As DayOfWeek) As String
            Select Case dow
                Case DayOfWeek.Monday : Return "Thứ Hai"
                Case DayOfWeek.Tuesday : Return "Thứ Ba"
                Case DayOfWeek.Wednesday : Return "Thứ Tư"
                Case DayOfWeek.Thursday : Return "Thứ Năm"
                Case DayOfWeek.Friday : Return "Thứ Sáu"
                Case DayOfWeek.Saturday : Return "Thứ Bảy"
                Case Else : Return "Chủ Nhật"
            End Select
        End Function

        Private Sub TaiLichSu()
            Dim ds = ChamCongBUS.LayLichSu(_maNVHienTai, 10)
            dgvLichSu.Rows.Clear()
            For Each cc In ds
                Dim ngay = If(cc.CC_GioBatDau.HasValue, cc.CC_GioBatDau.Value.ToString("dd/MM/yyyy"), "--")
                Dim vao = If(cc.CC_GioBatDau.HasValue, cc.CC_GioBatDau.Value.ToString("HH:mm"), "--")
                Dim ra = If(cc.CC_GioKetThuc.HasValue, cc.CC_GioKetThuc.Value.ToString("HH:mm"), "--")
                Dim thoiLuong = If(cc.CC_GioKetThuc.HasValue, $"{cc.ThoiLuongGio} giờ", "Đang trực")
                dgvLichSu.Rows.Add(ngay, cc.TenCa, vao, ra, thoiLuong, cc.TrangThaiDuyetText)
            Next
        End Sub

        Private Sub btnVaoCa_Click(sender As Object, e As EventArgs) Handles btnVaoCa.Click
            Dim msg As String = ""
            Dim cc = ChamCongBUS.VaoCa(_maNVHienTai, Nothing, msg)
            If cc IsNot Nothing Then
                MessageBox.Show(msg, "Thông Báo Điểm Danh", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LamMoiToanBoDuLieu()
            Else
                MessageBox.Show(msg, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnRaCa_Click(sender As Object, e As EventArgs) Handles btnRaCa.Click
            If _phienChamCongHienTai Is Nothing Then Return
            Dim hoi = MessageBox.Show("Bạn có chắc chắn muốn kết thúc ca trực hôm nay không?", "Xác Nhận Hết Ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If hoi <> DialogResult.Yes Then Return

            Dim msg As String = ""
            If ChamCongBUS.RaCa(_phienChamCongHienTai.CC_Ma, msg) Then
                MessageBox.Show(msg, "Kết Thúc Ca Trực", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LamMoiToanBoDuLieu()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnTuanTruoc_Click(sender As Object, e As EventArgs) Handles btnTuanTruoc.Click
            _ngayMocTuan = _ngayMocTuan.AddDays(-7)
            TaiLichTuan()
        End Sub

        Private Sub btnTuanHienTai_Click(sender As Object, e As EventArgs) Handles btnTuanHienTai.Click
            _ngayMocTuan = DateTime.Today
            TaiLichTuan()
        End Sub

        Private Sub btnTuanSau_Click(sender As Object, e As EventArgs) Handles btnTuanSau.Click
            _ngayMocTuan = _ngayMocTuan.AddDays(7)
            TaiLichTuan()
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            LamMoiToanBoDuLieu()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
            lblClock.Text = $"🕒 {DateTime.Now:HH:mm:ss dd/MM/yyyy}"
            CapNhatThoiLuongTrucTiep()
        End Sub

        Private Sub frmChamCongCaNhan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then Me.Close()
        End Sub

    End Class

End Namespace
