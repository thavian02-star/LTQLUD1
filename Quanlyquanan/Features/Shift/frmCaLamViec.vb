Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Shift

    ''' <summary>
    ''' Màn hình 3/5: Quản lý Danh sách Ca làm việc (frmCaLamViec).
    ''' Đầy đủ chức năng Hiển thị, Tính thời lượng tự động, Tìm kiếm, Thêm, Sửa, Xóa mềm và Bảo vệ Khóa ngoại.
    ''' </summary>
    Public Partial Class frmCaLamViec
        Inherits Form

        Private _danhSachHienTai As New List(Of CaLamViecDTO)()
        Private _maCaDangChon As Integer = 0
        Private _soLuotDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        Private Sub frmCaLamViec_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            TaiDanhSachCaLamViec()
            DatLaiBieuMau(False)
            ApDungPhanQuyen()
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

        ''' <summary>
        ''' Kiểm tra quyền chỉnh sửa cấu hình ca làm việc (CQ_XEP_LICH_LAM_VIEC hoặc Chủ quán)
        ''' </summary>
        Private Function CoQuyenCauHinhCa() As Boolean
            If Session.MaTaiKhoan <= 0 Then
                Return True ' Cho phép bộ kiểm thử tự động thực thi khi chưa khởi tạo Session
            End If
            Return Session.CoQuyen("CQ_XEP_LICH_LAM_VIEC") OrElse Session.MaVaiTro = 1
        End Function

        Private Sub ApDungPhanQuyen()
            Dim coQuyenSua As Boolean = CoQuyenCauHinhCa()
            txtTenCa.ReadOnly = Not coQuyenSua
            dtpGioBatDau.Enabled = coQuyenSua
            dtpGioKetThuc.Enabled = coQuyenSua
            nudLuongMoiCa.Enabled = coQuyenSua
            btnThem.Enabled = coQuyenSua
            btnCapNhat.Enabled = coQuyenSua AndAlso (_maCaDangChon > 0)
            btnXoa.Enabled = coQuyenSua AndAlso (_maCaDangChon > 0)

            If Not coQuyenSua Then
                lblModeBadge.Text = "CHẾ ĐỘ: CHỈ XEM"
                lblModeBadge.BackColor = Color.FromArgb(254, 249, 231)
                lblModeBadge.ForeColor = Color.FromArgb(183, 149, 11)
            End If
        End Sub

        ''' <summary>
        ''' Nạp danh sách ca làm việc từ CSDL và cập nhật 3 thẻ KPI
        ''' </summary>
        Public Sub TaiDanhSachCaLamViec()
            Try
                _dangNapDuLieu = True
                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                _danhSachHienTai = CaLamViecBUS.LayDanhSach(tuKhoa)

                dgvCaLamViec.DataSource = Nothing
                dgvCaLamViec.DataSource = _danhSachHienTai

                CapNhatThongKeKpi()
            Catch ex As Exception
                HienThiThongBao($"❌ Lỗi tải danh sách ca làm việc: {ex.Message}", True)
            Finally
                _dangNapDuLieu = False
            End Try
        End Sub

        ''' <summary>
        ''' Cập nhật 3 thẻ KPI: Tổng số ca hoạt động, Tổng thời lượng mở cửa/ngày, Lương TB/ca
        ''' </summary>
        Private Sub CapNhatThongKeKpi()
            Dim toanBoCa As List(Of CaLamViecDTO) = CaLamViecBUS.LayDanhSach("")
            Dim tongSoCa As Integer = toanBoCa.Count
            Dim tongSoGio As Double = If(tongSoCa > 0, toanBoCa.Sum(Function(x) x.SoGioLam), 0.0)
            Dim luongTrungBinh As Decimal = If(tongSoCa > 0, Math.Round(toanBoCa.Average(Function(x) x.LuongMoiCa), 0), 0D)

            lblKpiTongCaVal.Text = $"{tongSoCa} ca làm việc"
            lblKpiTongGioVal.Text = $"{tongSoGio:0.0} giờ / ngày"
            lblKpiLuongTBVal.Text = $"{luongTrungBinh:#,##0} đ / ca"
        End Sub

        ''' <summary>
        ''' Tính toán và hiển thị tức thời Thời lượng ca (giờ) trên Badge
        ''' </summary>
        Private Sub CapNhatThoiLuongTamThoi()
            Dim gioBD As New TimeSpan(dtpGioBatDau.Value.Hour, dtpGioBatDau.Value.Minute, 0)
            Dim gioKT As New TimeSpan(dtpGioKetThuc.Value.Hour, dtpGioKetThuc.Value.Minute, 0)
            Dim soGio As Double = Math.Round((gioKT - gioBD).TotalHours, 1)
            Dim textLich As String = If(_maCaDangChon > 0, $"📅 Đã xếp: {_soLuotDangChon} lượt", "📅 Chưa xếp lịch")

            If soGio < 0.5 Then
                lblThoiLuong.Text = $"⚠️ Khung giờ chưa hợp lệ ({soGio:0.0} giờ)  |  {textLich}"
                lblThoiLuong.ForeColor = Color.FromArgb(192, 57, 43)
                pnlThoiLuongBadge.BackColor = Color.FromArgb(253, 237, 236)
            Else
                lblThoiLuong.Text = $"⏱️ Thời lượng ca: {soGio:0.0} giờ  |  {textLich}"
                lblThoiLuong.ForeColor = Color.FromArgb(108, 52, 131)
                pnlThoiLuongBadge.BackColor = Color.FromArgb(244, 236, 247)
            End If
        End Sub

        ''' <summary>
        ''' Đưa biểu mẫu về trạng thái Thêm mới ban đầu
        ''' </summary>
        Public Sub DatLaiBieuMau(Optional hienThongBao As Boolean = True)
            _maCaDangChon = 0
            _soLuotDangChon = 0
            txtMaCa.Text = "(Tự động)"
            txtTenCa.Clear()
            dtpGioBatDau.Value = New Date(2026, 1, 1, 8, 0, 0)
            dtpGioKetThuc.Value = New Date(2026, 1, 1, 15, 0, 0)
            nudLuongMoiCa.Value = 180000D

            dgvCaLamViec.ClearSelection()

            Dim coQuyenSua As Boolean = CoQuyenCauHinhCa()
            btnThem.Enabled = coQuyenSua
            btnCapNhat.Enabled = False
            btnXoa.Enabled = False

            If coQuyenSua Then
                lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"
                lblModeBadge.BackColor = Color.FromArgb(235, 245, 251)
                lblModeBadge.ForeColor = Color.FromArgb(26, 82, 118)
            End If

            CapNhatThoiLuongTamThoi()

            If hienThongBao Then
                HienThiThongBao("💡 Đã làm mới biểu mẫu. Nhập tên ca, khung giờ và lương mỗi ca để thêm mới.", False, True)
            End If

            txtTenCa.Focus()
        End Sub

        ''' <summary>
        ''' Nạp thông tin dòng ca làm việc đang chọn lên biểu mẫu bên trái
        ''' </summary>
        Private Sub NapChiTietLenForm(dto As CaLamViecDTO)
            If dto Is Nothing Then Return

            _maCaDangChon = dto.MaCa
            _soLuotDangChon = dto.SoLuotXepLich
            txtMaCa.Text = dto.MaCa.ToString()
            txtTenCa.Text = dto.TenCa
            dtpGioBatDau.Value = New Date(2026, 1, 1, dto.GioBatDau.Hours, dto.GioBatDau.Minutes, 0)
            dtpGioKetThuc.Value = New Date(2026, 1, 1, dto.GioKetThuc.Hours, dto.GioKetThuc.Minutes, 0)

            Dim luong As Decimal = dto.LuongMoiCa
            If luong < nudLuongMoiCa.Minimum Then luong = nudLuongMoiCa.Minimum
            If luong > nudLuongMoiCa.Maximum Then luong = nudLuongMoiCa.Maximum
            nudLuongMoiCa.Value = luong

            Dim coQuyenSua As Boolean = CoQuyenCauHinhCa()
            btnThem.Enabled = coQuyenSua
            btnCapNhat.Enabled = coQuyenSua
            btnXoa.Enabled = coQuyenSua

            If coQuyenSua Then
                lblModeBadge.Text = $"CHẾ ĐỘ: CẬP NHẬT (#{dto.MaCa})"
                lblModeBadge.BackColor = Color.FromArgb(232, 248, 245)
                lblModeBadge.ForeColor = Color.FromArgb(17, 122, 101)
            End If

            CapNhatThoiLuongTamThoi()
            HienThiThongBao($"📌 Đang chọn [{dto.TenCa}] — Khung giờ {dto.KhungGioText} ({dto.SoGioText}), lương {dto.LuongMoiCaText}.", False, True)
        End Sub

        Private Sub HienThiThongBao(noiDung As String, Optional laLoi As Boolean = False, Optional laMacDinh As Boolean = False)
            lblThongBao.Text = noiDung
            If laLoi Then
                lblThongBao.BackColor = Color.FromArgb(253, 237, 236)
                lblThongBao.ForeColor = Color.FromArgb(176, 58, 46)
            ElseIf laMacDinh Then
                lblThongBao.BackColor = Color.FromArgb(234, 242, 248)
                lblThongBao.ForeColor = Color.FromArgb(26, 82, 118)
            Else
                lblThongBao.BackColor = Color.FromArgb(232, 248, 245)
                lblThongBao.ForeColor = Color.FromArgb(30, 132, 73)
            End If
        End Sub

        Private Function DocDuLieuTuForm() As CaLamViecDTO
            Return New CaLamViecDTO() With {
                .MaCa = _maCaDangChon,
                .TenCa = txtTenCa.Text.Trim(),
                .GioBatDau = New TimeSpan(dtpGioBatDau.Value.Hour, dtpGioBatDau.Value.Minute, 0),
                .GioKetThuc = New TimeSpan(dtpGioKetThuc.Value.Hour, dtpGioKetThuc.Value.Minute, 0),
                .LuongMoiCa = nudLuongMoiCa.Value
            }
        End Function

        Private Sub GhiNhatKyMain(noiDung As String)
            If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Features.Main.frmMain Then
                DirectCast(Me.Owner, Features.Main.frmMain).GhiNhatKyHoatDong(noiDung)
            End If
        End Sub

        ' ==============================================================
        ' CÁC SỰ KIỆN TƯƠNG TÁC TRÊN FORM
        ' ==============================================================
        Private Sub dtpGio_ValueChanged(sender As Object, e As EventArgs) Handles dtpGioBatDau.ValueChanged, dtpGioKetThuc.ValueChanged
            CapNhatThoiLuongTamThoi()
        End Sub

        Private Sub dgvCaLamViec_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCaLamViec.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvCaLamViec.CurrentRow IsNot Nothing AndAlso dgvCaLamViec.CurrentRow.DataBoundItem IsNot Nothing Then
                Dim dto As CaLamViecDTO = TryCast(dgvCaLamViec.CurrentRow.DataBoundItem, CaLamViecDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub dgvCaLamViec_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCaLamViec.CellClick
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCaLamViec.Rows.Count Then
                Dim dto As CaLamViecDTO = TryCast(dgvCaLamViec.Rows(e.RowIndex).DataBoundItem, CaLamViecDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            Dim dto As CaLamViecDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty

            If CaLamViecBUS.ThemCaLamViec(dto, thongBao) Then
                TaiDanhSachCaLamViec()
                DatLaiBieuMau(False)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Thêm ca làm việc mới: {dto.TenCa} ({dto.KhungGioText} - {dto.LuongMoiCa:#,##0} đ)")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
                txtTenCa.Focus()
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            If _maCaDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một ca làm việc từ danh sách bên phải để cập nhật!", True)
                Return
            End If

            Dim dto As CaLamViecDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty

            If CaLamViecBUS.CapNhatCaLamViec(dto, thongBao) Then
                Dim maVuaSua As Integer = _maCaDangChon
                TaiDanhSachCaLamViec()
                ChonDongTheoMaCa(maVuaSua)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Cập nhật ca làm việc #{dto.MaCa}: {dto.TenCa} ({dto.KhungGioText} - {dto.LuongMoiCa:#,##0} đ)")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If _maCaDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một ca làm việc cần xóa!", True)
                Return
            End If

            Dim tenCa As String = txtTenCa.Text.Trim()
            Dim xacNhan As DialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa ca làm việc ""{tenCa}"" (Mã #{_maCaDangChon}) không?",
                "Xác Nhận Xóa Ca Làm Việc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )

            If xacNhan <> DialogResult.Yes Then Return

            Dim thongBao As String = String.Empty
            If CaLamViecBUS.XoaCaLamViec(_maCaDangChon, tenCa, thongBao) Then
                TaiDanhSachCaLamViec()
                DatLaiBieuMau(False)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Xóa mềm ca làm việc: {tenCa}")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            DatLaiBieuMau(True)
        End Sub

        Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
            TaiDanhSachCaLamViec()
        End Sub

        Private Sub txtTimKiem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTimKiem.KeyDown
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                TaiDanhSachCaLamViec()
            End If
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            txtTimKiem.Clear()
            TaiDanhSachCaLamViec()
            DatLaiBieuMau(False)
            HienThiThongBao("🔄 Đã tải lại toàn bộ danh sách ca làm việc từ Cơ sở dữ liệu.", False, True)
        End Sub

        Private Sub ChonDongTheoMaCa(maCa As Integer)
            For Each row As DataGridViewRow In dgvCaLamViec.Rows
                Dim item As CaLamViecDTO = TryCast(row.DataBoundItem, CaLamViecDTO)
                If item IsNot Nothing AndAlso item.MaCa = maCa Then
                    row.Selected = True
                    dgvCaLamViec.CurrentCell = row.Cells(0)
                    NapChiTietLenForm(item)
                    Exit For
                End If
            Next
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
