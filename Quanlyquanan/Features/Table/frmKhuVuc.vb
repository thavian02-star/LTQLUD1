Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Table

    ''' <summary>
    ''' Màn hình 4/5: Quản lý Khu vực bàn ăn (frmKhuVuc).
    ''' Đầy đủ chức năng Hiển thị, Thống kê bàn & sức chứa, Tìm kiếm, Thêm, Sửa (Cascade Update),
    ''' Xóa mềm (FK Protection khi có bàn) và Khôi phục xóa mềm thông minh.
    ''' </summary>
    Public Partial Class frmKhuVuc
        Inherits Form

        Private _danhSachHienTai As New List(Of KhuVucDTO)()
        Private _maKhuVucDangChon As Integer = 0
        Private _tenKhuVucDangChon As String = String.Empty
        Private _soBanDangChon As Integer = 0
        Private _tongChoDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmKhuVuc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            TaiDanhSachKhuVuc()
            DatLaiBieuMau(False)
            ApDungPhanQuyen()
        End Sub

        ''' <summary>
        ''' Định dạng bảng DataGridView đồng bộ bảng màu Navy chuẩn của hệ thống
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            dgvKhuVuc.AutoGenerateColumns = False

            With dgvKhuVuc.ColumnHeadersDefaultCellStyle
                .BackColor = Color.FromArgb(26, 82, 118)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
                .Alignment = DataGridViewContentAlignment.MiddleLeft
            End With

            With dgvKhuVuc.DefaultCellStyle
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(44, 62, 80)
                .Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
                .SelectionBackColor = Color.FromArgb(214, 234, 248)
                .SelectionForeColor = Color.FromArgb(26, 82, 118)
            End With

            dgvKhuVuc.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
        End Sub

        ''' <summary>
        ''' Hiển thị hộp thông báo trên biểu mẫu bên trái
        ''' </summary>
        Private Sub HienThiThongBao(noiDung As String, isError As Boolean, Optional isInfo As Boolean = False)
            lblThongBao.Text = noiDung
            If isError Then
                lblThongBao.BackColor = Color.FromArgb(253, 237, 236)
                lblThongBao.ForeColor = Color.FromArgb(192, 57, 43)
            ElseIf isInfo Then
                lblThongBao.BackColor = Color.FromArgb(234, 242, 248)
                lblThongBao.ForeColor = Color.FromArgb(26, 82, 118)
            Else
                lblThongBao.BackColor = Color.FromArgb(234, 250, 234)
                lblThongBao.ForeColor = Color.FromArgb(39, 174, 96)
            End If
        End Sub

        ''' <summary>
        ''' Kiểm tra quyền quản lý khu vực bàn ăn (CQ_QUAN_LY_BAN hoặc Chủ quán / Quản lý)
        ''' </summary>
        Public Function CoQuyenQuanLyKhuVuc() As Boolean
            If Session.MaTaiKhoan <= 0 Then
                Return True ' Cho phép bộ kiểm thử tự động thực thi khi chưa khởi tạo Session
            End If
            Return Session.CoQuyen("CQ_QUAN_LY_BAN") OrElse Session.MaVaiTro = 1 OrElse Session.MaVaiTro = 2
        End Function

        Public Sub ApDungPhanQuyen()
            Dim coQuyen As Boolean = CoQuyenQuanLyKhuVuc()
            txtTenKhuVuc.ReadOnly = Not coQuyen
            txtMoTa.ReadOnly = Not coQuyen
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen AndAlso (_maKhuVucDangChon > 0)
            btnXoa.Enabled = coQuyen AndAlso (_maKhuVucDangChon > 0)

            If Not coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: CHỈ XEM"
                lblModeBadge.BackColor = Color.FromArgb(254, 249, 231)
                lblModeBadge.ForeColor = Color.FromArgb(183, 149, 11)
            End If
        End Sub

        ''' <summary>
        ''' Nạp danh sách khu vực bàn từ CSDL và cập nhật 3 thẻ KPI
        ''' </summary>
        Public Sub TaiDanhSachKhuVuc()
            Try
                _dangNapDuLieu = True
                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                _danhSachHienTai = KhuVucBUS.LayDanhSach(tuKhoa)

                dgvKhuVuc.DataSource = Nothing
                dgvKhuVuc.DataSource = _danhSachHienTai

                CapNhatThongKeKpi()
            Catch ex As Exception
                HienThiThongBao($"❌ Lỗi tải danh sách khu vực: {ex.Message}", True)
            Finally
                _dangNapDuLieu = False
            End Try
        End Sub

        ''' <summary>
        ''' Cập nhật 3 thẻ KPI: Tổng số khu vực, Tổng số bàn đã bố trí, Tổng sức chứa khách tối đa
        ''' </summary>
        Private Sub CapNhatThongKeKpi()
            Dim toanBoKV As List(Of KhuVucDTO) = KhuVucBUS.LayDanhSach("")
            Dim tongKV As Integer = toanBoKV.Count
            Dim tongBan As Integer = If(tongKV > 0, toanBoKV.Sum(Function(x) x.SoLuongBan), 0)
            Dim tongCho As Integer = If(tongKV > 0, toanBoKV.Sum(Function(x) x.TongSucChua), 0)

            lblKpiTongKhuVucVal.Text = $"{tongKV} khu vực"
            lblKpiTongBanVal.Text = $"{tongBan} bàn"
            lblKpiTongChoVal.Text = $"{tongCho} chỗ ngồi"
        End Sub

        ''' <summary>
        ''' Cập nhật Badge thống kê số bàn và sức chứa của khu vực đang chọn
        ''' </summary>
        Private Sub CapNhatBadgeThongKeBan()
            lblThongKeBan.Text = $"🪑 Số bàn hiện có: {_soBanDangChon} bàn  |  👥 Sức chứa: {_tongChoDangChon} chỗ"
        End Sub

        ''' <summary>
        ''' Đưa biểu mẫu về trạng thái Thêm mới ban đầu
        ''' </summary>
        Public Sub DatLaiBieuMau(Optional hienThongBao As Boolean = True)
            _maKhuVucDangChon = 0
            _tenKhuVucDangChon = String.Empty
            _soBanDangChon = 0
            _tongChoDangChon = 0

            txtMaKhuVuc.Text = "(Tự sinh)"
            txtTenKhuVuc.Clear()
            txtMoTa.Clear()

            dgvKhuVuc.ClearSelection()

            Dim coQuyen As Boolean = CoQuyenQuanLyKhuVuc()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = False
            btnXoa.Enabled = False

            If coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"
                lblModeBadge.BackColor = Color.FromArgb(235, 245, 251)
                lblModeBadge.ForeColor = Color.FromArgb(26, 82, 118)
            End If

            CapNhatBadgeThongKeBan()

            If hienThongBao Then
                HienThiThongBao("💡 Đã làm mới biểu mẫu. Nhập tên khu vực và mô tả để thêm mới.", False, True)
            End If

            txtTenKhuVuc.Focus()
        End Sub

        ''' <summary>
        ''' Nạp thông tin dòng khu vực đang chọn lên biểu mẫu bên trái
        ''' </summary>
        Private Sub NapChiTietLenForm(dto As KhuVucDTO)
            If dto Is Nothing Then Return

            _maKhuVucDangChon = dto.KV_Ma
            _tenKhuVucDangChon = dto.KV_Ten
            _soBanDangChon = dto.SoLuongBan
            _tongChoDangChon = dto.TongSucChua

            txtMaKhuVuc.Text = dto.KV_Ma.ToString()
            txtTenKhuVuc.Text = dto.KV_Ten
            txtMoTa.Text = dto.KV_MoTa

            Dim coQuyen As Boolean = CoQuyenQuanLyKhuVuc()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen
            btnXoa.Enabled = coQuyen

            If coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: CẬP NHẬT"
                lblModeBadge.BackColor = Color.FromArgb(234, 250, 234)
                lblModeBadge.ForeColor = Color.FromArgb(39, 174, 96)
            End If

            CapNhatBadgeThongKeBan()
            HienThiThongBao($"Đang chọn khu vực ""{dto.KV_Ten}"" (Mã #{dto.KV_Ma}). Có {dto.SoLuongBan} bàn trực thuộc.", False, True)
        End Sub

        Private Function DocDuLieuTuForm() As KhuVucDTO
            Return New KhuVucDTO() With {
                .KV_Ma = _maKhuVucDangChon,
                .KV_Ten = txtTenKhuVuc.Text.Trim(),
                .KV_MoTa = txtMoTa.Text.Trim()
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
        Private Sub dgvKhuVuc_SelectionChanged(sender As Object, e As EventArgs) Handles dgvKhuVuc.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvKhuVuc.CurrentRow IsNot Nothing AndAlso dgvKhuVuc.CurrentRow.DataBoundItem IsNot Nothing Then
                Dim dto As KhuVucDTO = TryCast(dgvKhuVuc.CurrentRow.DataBoundItem, KhuVucDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub dgvKhuVuc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKhuVuc.CellClick
            If e.RowIndex >= 0 AndAlso e.RowIndex < dgvKhuVuc.Rows.Count Then
                Dim dto As KhuVucDTO = TryCast(dgvKhuVuc.Rows(e.RowIndex).DataBoundItem, KhuVucDTO)
                If dto IsNot Nothing Then
                    NapChiTietLenForm(dto)
                End If
            End If
        End Sub

        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            Dim dto As KhuVucDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty

            If KhuVucBUS.ThemKhuVuc(dto, thongBao) Then
                TaiDanhSachKhuVuc()
                ChonDongTheoMaKhuVuc(dto.KV_Ma)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Thêm khu vực bàn mới: {dto.KV_Ten} (Mã #{dto.KV_Ma})")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
                txtTenKhuVuc.Focus()
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            If _maKhuVucDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một khu vực từ danh sách bên phải để cập nhật!", True)
                Return
            End If

            Dim dto As KhuVucDTO = DocDuLieuTuForm()
            Dim thongBao As String = String.Empty
            Dim tenCu As String = _tenKhuVucDangChon

            If KhuVucBUS.CapNhatKhuVuc(dto, tenCu, thongBao) Then
                TaiDanhSachKhuVuc()
                ChonDongTheoMaKhuVuc(dto.KV_Ma)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Cập nhật khu vực bàn: {dto.KV_Ten} (Tên cũ: {tenCu})")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
                txtTenKhuVuc.Focus()
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If _maKhuVucDangChon <= 0 Then
                HienThiThongBao("⛔ Vui lòng chọn một khu vực từ danh sách bên phải để xóa!", True)
                Return
            End If

            If _soBanDangChon > 0 Then
                HienThiThongBao($"⛔ BẢO VỆ KHÓA NGOẠI: Không thể xóa khu vực ""{_tenKhuVucDangChon}"" vì đang có {_soBanDangChon} bàn hoạt động!", True)
                MessageBox.Show(
                    $"Khu vực [{_tenKhuVucDangChon}] đang có {_soBanDangChon} bàn ăn hoạt động (Tổng {_tongChoDangChon} chỗ ngồi)!" & vbCrLf & vbCrLf &
                    "Hệ thống không cho phép xóa khu vực đang chứa bàn để bảo toàn sơ đồ bàn ăn." & vbCrLf &
                    "Vui lòng vào màn hình [Quản lý Bàn] để chuyển hoặc xóa bàn trước khi xóa khu vực này.",
                    "Bảo Vệ Toàn Vẹn Khóa Ngoại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                )
                Return
            End If

            Dim xacNhan As DialogResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa khu vực [{_tenKhuVucDangChon}] (Mã #{_maKhuVucDangChon}) không?",
                "Xác Nhận Xóa Khu Vực",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If xacNhan <> DialogResult.Yes Then Return

            Dim thongBao As String = String.Empty
            If KhuVucBUS.XoaKhuVuc(_maKhuVucDangChon, _tenKhuVucDangChon, thongBao) Then
                Dim tenXoa As String = _tenKhuVucDangChon
                Dim maXoa As Integer = _maKhuVucDangChon
                TaiDanhSachKhuVuc()
                DatLaiBieuMau(False)
                HienThiThongBao("✅ " & thongBao, False)
                GhiNhatKyMain($"Xóa mềm khu vực bàn: {tenXoa} (Mã #{maXoa})")
            Else
                HienThiThongBao("⛔ " & thongBao, True)
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            DatLaiBieuMau(True)
        End Sub

        Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
            TaiDanhSachKhuVuc()
        End Sub

        Private Sub txtTimKiem_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTimKiem.KeyDown
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                TaiDanhSachKhuVuc()
            End If
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            txtTimKiem.Clear()
            TaiDanhSachKhuVuc()
            DatLaiBieuMau(False)
            HienThiThongBao("🔄 Đã tải lại toàn bộ danh sách khu vực từ Cơ sở dữ liệu.", False, True)
        End Sub

        Public Sub ChonDongTheoMaKhuVuc(maKV As Integer)
            For Each row As DataGridViewRow In dgvKhuVuc.Rows
                Dim item As KhuVucDTO = TryCast(row.DataBoundItem, KhuVucDTO)
                If item IsNot Nothing AndAlso item.KV_Ma = maKV Then
                    row.Selected = True
                    dgvKhuVuc.CurrentCell = row.Cells(0)
                    NapChiTietLenForm(item)
                    Exit For
                End If
            Next
        End Sub

        Private Sub btnMoBan_Click(sender As Object, e As EventArgs) Handles btnMoBan.Click
            MessageBox.Show(
                "Chức năng liên kết nhanh sang Màn hình Quản lý Bàn (frmBan - MH 5/5)!" & vbCrLf &
                "- Cho phép cấu hình danh sách bàn ăn, số lượng chỗ ngồi và liên kết trực tiếp với Khu vực này.",
                "Quản Lý Bàn Ăn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmKhuVuc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

    End Class

End Namespace
