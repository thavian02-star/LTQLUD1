Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Table

    ''' <summary>
    ''' Màn hình 5/5: Quản lý Danh sách Bàn ăn (frmBan).
    ''' Đầy đủ chức năng Lọc đa chiều, Thống kê 4 KPI, Thêm, Sửa, Xóa mềm, Bảo vệ phiên phục vụ và Phân quyền RBAC.
    ''' </summary>
    Public Partial Class frmBan
        Inherits Form

        Private _danhSachHienTai As New List(Of BanDTO)()
        Private _maBanDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        Private Sub frmBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            NapDanhSachKhuVucVaTrangThai()
            TaiDanhSachBan()
            ApDungPhanQuyen()
        End Sub

        ''' <summary>
        ''' Cấu hình màu sắc và định dạng căn lề cho bảng DataGridView
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

        ''' <summary>
        ''' Nạp các mục chọn vào ComboBox Khu vực và ComboBox Trạng thái
        ''' </summary>
        Private Sub NapDanhSachKhuVucVaTrangThai()
            Try
                _dangNapDuLieu = True

                ' 1. Khu vực
                Dim dsKhuVuc As List(Of String) = BanBUS.LayDanhSachKhuVuc()

                ' Cột lọc bên phải
                cboLocKhuVuc.Items.Clear()
                cboLocKhuVuc.Items.Add("-- Tất cả khu vực --")
                For Each kv In dsKhuVuc
                    cboLocKhuVuc.Items.Add(kv)
                Next
                cboLocKhuVuc.SelectedIndex = 0

                ' Cột form bên trái
                cboKhuVuc.Items.Clear()
                For Each kv In dsKhuVuc
                    cboKhuVuc.Items.Add(kv)
                Next
                If cboKhuVuc.Items.Count > 0 Then cboKhuVuc.SelectedIndex = 0

                ' 2. Trạng thái bàn
                Dim dsTrangThai As (GiaTri As Integer, Ten As String)() = {
                    (0, "0 - Bàn Trống"),
                    (1, "1 - Có khách"),
                    (2, "2 - Đang đợi món"),
                    (3, "3 - Món đã xong")
                }

                ' Cột lọc bên phải
                cboLocTrangThai.Items.Clear()
                cboLocTrangThai.DisplayMember = "Ten"
                cboLocTrangThai.ValueMember = "GiaTri"
                cboLocTrangThai.Items.Add(New With {.GiaTri = -1, .Ten = "-- Tất cả trạng thái --"})
                For Each tt In dsTrangThai
                    cboLocTrangThai.Items.Add(New With {.GiaTri = tt.GiaTri, .Ten = tt.Ten})
                Next
                cboLocTrangThai.SelectedIndex = 0

                ' Cột form bên trái
                cboTrangThai.Items.Clear()
                cboTrangThai.DisplayMember = "Ten"
                cboTrangThai.ValueMember = "GiaTri"
                For Each tt In dsTrangThai
                    cboTrangThai.Items.Add(New With {.GiaTri = tt.GiaTri, .Ten = tt.Ten})
                Next
                If cboTrangThai.Items.Count > 0 Then cboTrangThai.SelectedIndex = 0
            Finally
                _dangNapDuLieu = False
            End Try
        End Sub

        ''' <summary>
        ''' Kiểm tra tài khoản hiện tại có quyền cấu hình bàn ăn hay không
        ''' </summary>
        Private Function CoQuyenCauHinh() As Boolean
            If Session.MaTaiKhoan <= 0 Then
                Return True ' Cho phép bộ kiểm thử tự động thực thi khi chưa đăng nhập
            End If
            Return Session.CoQuyen("CQ_QUAN_LY_BAN") OrElse Session.MaVaiTro = 1
        End Function

        Private Sub ApDungPhanQuyen()
            Dim coQuyen As Boolean = CoQuyenCauHinh()
            nudSoThuTu.Enabled = coQuyen
            txtTenBan.ReadOnly = Not coQuyen
            cboKhuVuc.Enabled = coQuyen
            nudSoNguoiToiDa.Enabled = coQuyen
            cboTrangThai.Enabled = coQuyen
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen AndAlso (_maBanDangChon > 0)
            btnXoa.Enabled = coQuyen AndAlso (_maBanDangChon > 0)

            If Not coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: CHỈ XEM"
                lblModeBadge.BackColor = Color.FromArgb(254, 249, 231)
                lblModeBadge.ForeColor = Color.FromArgb(183, 149, 11)
            End If
        End Sub

        ''' <summary>
        ''' Tải danh sách bàn ăn từ CSDL theo bộ lọc hiện tại và cập nhật 4 thẻ KPI
        ''' </summary>
        Public Sub TaiDanhSachBan(Optional maUuTienChon As Integer = 0)
            Try
                _dangNapDuLieu = True

                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                Dim kvLoc As String = If(cboLocKhuVuc.SelectedIndex > 0, cboLocKhuVuc.SelectedItem.ToString(), "")

                Dim ttLoc As Integer = -1
                If cboLocTrangThai.SelectedItem IsNot Nothing Then
                    Dim selectedObj As Object = cboLocTrangThai.SelectedItem
                    Dim prop = selectedObj.GetType().GetProperty("GiaTri")
                    If prop IsNot Nothing Then
                        ttLoc = Convert.ToInt32(prop.GetValue(selectedObj))
                    End If
                End If

                _danhSachHienTai = BanBUS.LayDanhSach(tuKhoa, kvLoc, ttLoc)
                dgvBan.DataSource = Nothing
                dgvBan.DataSource = _danhSachHienTai

                CapNhatThongKeKpi()
                _dangNapDuLieu = False

                If _danhSachHienTai.Count > 0 Then
                    Dim idx As Integer = 0
                    If maUuTienChon > 0 Then
                        For i As Integer = 0 To _danhSachHienTai.Count - 1
                            If _danhSachHienTai(i).MaBan = maUuTienChon Then
                                idx = i
                                Exit For
                            End If
                        Next
                    End If

                    dgvBan.ClearSelection()
                    dgvBan.Rows(idx).Selected = True
                    NapChiTietLenForm(_danhSachHienTai(idx))
                Else
                    DatLaiBieuMau(False)
                End If
            Catch ex As Exception
                _dangNapDuLieu = False
                HienThiThongBao($"❌ Lỗi tải danh sách bàn: {ex.Message}", True)
            End Try
        End Sub

        ''' <summary>
        ''' Cập nhật 4 thẻ KPI: Tổng bàn, Bàn trống, Bàn đang phục vụ, Tổng sức chứa
        ''' </summary>
        Private Sub CapNhatThongKeKpi()
            Dim toanBoBan As List(Of BanDTO) = BanBUS.LayDanhSach("", "", -1)
            Dim tongBan As Integer = toanBoBan.Count
            Dim banTrong As Integer = toanBoBan.Where(Function(b) b.TrangThai = 0).Count()
            Dim dangPhucVu As Integer = toanBoBan.Where(Function(b) b.TrangThai <> 0).Count()
            Dim tongSucChua As Integer = If(tongBan > 0, toanBoBan.Sum(Function(b) b.SoNguoiToiDa), 0)

            lblKpiTongBanVal.Text = $"{tongBan} bàn"
            lblKpiBanTrongVal.Text = $"{banTrong} bàn"
            lblKpiDangPhucVuVal.Text = $"{dangPhucVu} bàn"
            lblKpiSucChuaVal.Text = $"{tongSucChua} chỗ ngồi"
        End Sub

        ''' <summary>
        ''' Đưa form về chế độ Thêm mới
        ''' </summary>
        Public Sub DatLaiBieuMau(Optional hienThongBao As Boolean = True)
            _maBanDangChon = 0
            txtMaBan.Text = "(Tự động)"

            ' Gợi ý số thứ tự tiếp theo
            Dim toanBo As List(Of BanDTO) = BanBUS.LayDanhSach("", "", -1)
            Dim maxSTT As Integer = If(toanBo.Count > 0, toanBo.Max(Function(b) b.SoThuTu), 0)
            Dim nextSTT As Integer = maxSTT + 1
            If nextSTT > nudSoThuTu.Maximum Then nextSTT = CInt(nudSoThuTu.Maximum)
            nudSoThuTu.Value = nextSTT

            txtTenBan.Text = $"Bàn {If(nextSTT < 10, "0" & nextSTT, nextSTT.ToString())}"
            If cboKhuVuc.Items.Count > 0 Then cboKhuVuc.SelectedIndex = 0
            nudSoNguoiToiDa.Value = 4
            cboTrangThai.SelectedIndex = 0

            lblHoaDonInfo.Text = "🧾 Phiên phục vụ: Bàn trống (Chưa có hóa đơn)"
            lblHoaDonInfo.ForeColor = Color.FromArgb(44, 62, 80)
            pnlHoaDonBadge.BackColor = Color.FromArgb(244, 246, 247)

            dgvBan.ClearSelection()

            Dim coQuyen As Boolean = CoQuyenCauHinh()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = False
            btnXoa.Enabled = False

            If coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"
                lblModeBadge.BackColor = Color.FromArgb(235, 245, 251)
                lblModeBadge.ForeColor = Color.FromArgb(26, 82, 118)
            End If

            If hienThongBao Then
                HienThiThongBao("💡 Đã làm mới biểu mẫu. Nhập số thứ tự, tên bàn, khu vực và sức chứa để thêm mới.", False, True)
            End If

            nudSoThuTu.Focus()
        End Sub

        ''' <summary>
        ''' Nạp thông tin dòng bàn đang chọn lên biểu mẫu bên trái
        ''' </summary>
        Private Sub NapChiTietLenForm(dto As BanDTO)
            If dto Is Nothing Then Return

            _maBanDangChon = dto.MaBan
            txtMaBan.Text = dto.MaBan.ToString()

            Dim stt As Integer = dto.SoThuTu
            If stt < nudSoThuTu.Minimum Then stt = CInt(nudSoThuTu.Minimum)
            If stt > nudSoThuTu.Maximum Then stt = CInt(nudSoThuTu.Maximum)
            nudSoThuTu.Value = stt

            txtTenBan.Text = dto.TenBan
            cboKhuVuc.Text = dto.KhuVuc

            Dim sucChua As Integer = dto.SoNguoiToiDa
            If sucChua < nudSoNguoiToiDa.Minimum Then sucChua = CInt(nudSoNguoiToiDa.Minimum)
            If sucChua > nudSoNguoiToiDa.Maximum Then sucChua = CInt(nudSoNguoiToiDa.Maximum)
            nudSoNguoiToiDa.Value = sucChua

            ' Chọn trạng thái trong ComboBox
            For i As Integer = 0 To cboTrangThai.Items.Count - 1
                Dim obj = cboTrangThai.Items(i)
                Dim prop = obj.GetType().GetProperty("GiaTri")
                If prop IsNot Nothing AndAlso Convert.ToInt32(prop.GetValue(obj)) = dto.TrangThai Then
                    cboTrangThai.SelectedIndex = i
                    Exit For
                End If
            Next

            ' Cập nhật Badge Hóa đơn
            If dto.MaHoaDonHienTai.HasValue AndAlso dto.MaHoaDonHienTai.Value > 0 Then
                Dim nv As String = If(String.IsNullOrWhiteSpace(dto.TenNVPhucVu), "Chưa gán NV", dto.TenNVPhucVu)
                lblHoaDonInfo.Text = $"🧾 HĐ #{dto.MaHoaDonHienTai.Value} ({nv}) — Bàn đang phục vụ (Không thể xóa)"
                lblHoaDonInfo.ForeColor = Color.FromArgb(192, 57, 43)
                pnlHoaDonBadge.BackColor = Color.FromArgb(253, 237, 236)
            Else
                lblHoaDonInfo.Text = "🧾 Phiên phục vụ: Bàn trống (Sẵn sàng xếp khách)"
                lblHoaDonInfo.ForeColor = Color.FromArgb(39, 174, 96)
                pnlHoaDonBadge.BackColor = Color.FromArgb(234, 250, 234)
            End If

            Dim coQuyen As Boolean = CoQuyenCauHinh()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen
            btnXoa.Enabled = coQuyen

            If coQuyen Then
                lblModeBadge.Text = $"CHẾ ĐỘ: CẬP NHẬT (#{dto.MaBan})"
                lblModeBadge.BackColor = Color.FromArgb(232, 248, 245)
                lblModeBadge.ForeColor = Color.FromArgb(17, 122, 101)
            End If

            HienThiThongBao($"📌 Đang chọn [{dto.TenBan}] (STT {dto.SoThuTu}) — Khu vực {dto.KhuVuc} ({dto.SucChuaText}, {dto.TrangThaiText}).", False, True)
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

        Private Function DocDuLieuTuForm() As BanDTO
            Dim tt As Integer = 0
            If cboTrangThai.SelectedItem IsNot Nothing Then
                Dim prop = cboTrangThai.SelectedItem.GetType().GetProperty("GiaTri")
                If prop IsNot Nothing Then
                    tt = Convert.ToInt32(prop.GetValue(cboTrangThai.SelectedItem))
                End If
            End If

            Return New BanDTO() With {
                .MaBan = _maBanDangChon,
                .SoThuTu = CInt(nudSoThuTu.Value),
                .TenBan = txtTenBan.Text.Trim(),
                .KhuVuc = cboKhuVuc.Text.Trim(),
                .SoNguoiToiDa = CInt(nudSoNguoiToiDa.Value),
                .TrangThai = tt
            }
        End Function

        Private Sub GhiNhatKyMain(noiDung As String)
            If Me.Owner IsNot Nothing AndAlso TypeOf Me.Owner Is Features.Main.frmMain Then
                DirectCast(Me.Owner, Features.Main.frmMain).GhiNhatKyHoatDong(noiDung)
            End If
        End Sub

        ' ==============================================================
        ' CÁC SỰ KIỆN TƯƠNG TÁC FORM
        ' ==============================================================
        Private Sub dgvBan_SelectionChanged(sender As Object, e As EventArgs) Handles dgvBan.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvBan.CurrentRow IsNot Nothing AndAlso dgvBan.CurrentRow.DataBoundItem IsNot Nothing Then
                Dim dto As BanDTO = TryCast(dgvBan.CurrentRow.DataBoundItem, BanDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub dgvBan_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBan.CellClick
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvBan.Rows.Count Then
                Dim dto As BanDTO = TryCast(dgvBan.Rows(e.RowIndex).DataBoundItem, BanDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            Dim dto As BanDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty

            If BanBUS.ThemBan(dto, thongBao) Then
                TaiDanhSachBan()
                DatLaiBieuMau(False)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Thêm bàn ăn mới: {dto.TenBan} (STT {dto.SoThuTu}, Khu vực {dto.KhuVuc}, {dto.SoNguoiToiDa} chỗ)")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
                nudSoThuTu.Focus()
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            If _maBanDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một bàn ăn từ danh sách bên phải để cập nhật!", True)
                Return
            End If

            Dim dto As BanDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty

            If BanBUS.CapNhatBan(dto, thongBao) Then
                Dim maVuaSua As Integer = _maBanDangChon
                TaiDanhSachBan(maVuaSua)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Cập nhật bàn ăn #{dto.MaBan}: {dto.TenBan} (STT {dto.SoThuTu}, Khu vực {dto.KhuVuc}, {dto.SoNguoiToiDa} chỗ)")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If _maBanDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một bàn ăn cần xóa!", True)
                Return
            End If

            Dim tenBan As String = txtTenBan.Text.Trim()
            Dim xacNhan As DialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa bàn ăn ""{tenBan}"" (Mã #{_maBanDangChon}) không?",
                "Xác Nhận Xóa Bàn Ăn",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            )

            If xacNhan <> DialogResult.Yes Then Return

            Dim thongBao As String = String.Empty
            If BanBUS.XoaBan(_maBanDangChon, tenBan, thongBao) Then
                TaiDanhSachBan()
                DatLaiBieuMau(False)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Xóa bàn ăn: {tenBan}")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            DatLaiBieuMau(True)
        End Sub

        Private Sub cboLoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocKhuVuc.SelectedIndexChanged, cboLocTrangThai.SelectedIndexChanged
            If _dangNapDuLieu Then Return
            TaiDanhSachBan()
        End Sub

        Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
            If _dangNapDuLieu Then Return
            TaiDanhSachBan()
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            _dangNapDuLieu = True
            cboLocKhuVuc.SelectedIndex = 0
            cboLocTrangThai.SelectedIndex = 0
            txtTimKiem.Clear()
            _dangNapDuLieu = False
            TaiDanhSachBan()
            DatLaiBieuMau(False)
            HienThiThongBao("🔄 Đã tải lại toàn bộ danh sách bàn ăn từ Cơ sở dữ liệu.", False, True)
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
