Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Table

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmBan
        Inherits System.Windows.Forms.Form

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        ' ==============================================================
        ' KHAI BÁO CONTROLS GIAO DIỆN (3 TẦNG + SPLIT-LAYOUT 38:62)
        ' ==============================================================
        Friend WithEvents pnlHeader As Panel
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents btnDong As Button

        Friend WithEvents tlpKpiRow As TableLayoutPanel
        Friend WithEvents pnlKpiTongBan As Panel
        Friend WithEvents lblKpiTongBanTitle As Label
        Friend WithEvents lblKpiTongBanVal As Label
        Friend WithEvents pnlKpiBanTrong As Panel
        Friend WithEvents lblKpiBanTrongTitle As Label
        Friend WithEvents lblKpiBanTrongVal As Label
        Friend WithEvents pnlKpiDangPhucVu As Panel
        Friend WithEvents lblKpiDangPhucVuTitle As Label
        Friend WithEvents lblKpiDangPhucVuVal As Label
        Friend WithEvents pnlKpiSucChua As Panel
        Friend WithEvents lblKpiSucChuaTitle As Label
        Friend WithEvents lblKpiSucChuaVal As Label

        Friend WithEvents tlpMainContent As TableLayoutPanel

        ' Cột trái (38%) - Biểu mẫu Chi tiết Bàn
        Friend WithEvents pnlFormCard As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblModeBadge As Label
        Friend WithEvents lblThongBao As Label
        Friend WithEvents lblMaBan As Label
        Friend WithEvents txtMaBan As TextBox
        Friend WithEvents lblSoThuTu As Label
        Friend WithEvents nudSoThuTu As NumericUpDown
        Friend WithEvents lblTenBan As Label
        Friend WithEvents txtTenBan As TextBox
        Friend WithEvents lblKhuVuc As Label
        Friend WithEvents cboKhuVuc As ComboBox
        Friend WithEvents lblSoNguoiToiDa As Label
        Friend WithEvents nudSoNguoiToiDa As NumericUpDown
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents pnlHoaDonBadge As Panel
        Friend WithEvents lblHoaDonInfo As Label

        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnCapNhat As Button
        Friend WithEvents btnXoa As Button
        Friend WithEvents btnLamMoi As Button

        ' Cột phải (62%) - Danh sách Bàn ăn + Bộ lọc
        Friend WithEvents pnlGridCard As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlFilterBar As Panel
        Friend WithEvents lblLocKhuVuc As Label
        Friend WithEvents cboLocKhuVuc As ComboBox
        Friend WithEvents lblLocTrangThai As Label
        Friend WithEvents cboLocTrangThai As ComboBox
        Friend WithEvents txtTimKiem As TextBox
        Friend WithEvents btnTaiLai As Button
        Friend WithEvents dgvBan As DataGridView
        Friend WithEvents colMaBan As DataGridViewTextBoxColumn
        Friend WithEvents colSoThuTu As DataGridViewTextBoxColumn
        Friend WithEvents colTenBan As DataGridViewTextBoxColumn
        Friend WithEvents colKhuVuc As DataGridViewTextBoxColumn
        Friend WithEvents colSoNguoiToiDa As DataGridViewTextBoxColumn
        Friend WithEvents colTrangThai As DataGridViewTextBoxColumn
        Friend WithEvents colHoaDon As DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnDong = New Button()

            Me.tlpKpiRow = New TableLayoutPanel()
            Me.pnlKpiTongBan = New Panel()
            Me.lblKpiTongBanTitle = New Label()
            Me.lblKpiTongBanVal = New Label()
            Me.pnlKpiBanTrong = New Panel()
            Me.lblKpiBanTrongTitle = New Label()
            Me.lblKpiBanTrongVal = New Label()
            Me.pnlKpiDangPhucVu = New Panel()
            Me.lblKpiDangPhucVuTitle = New Label()
            Me.lblKpiDangPhucVuVal = New Label()
            Me.pnlKpiSucChua = New Panel()
            Me.lblKpiSucChuaTitle = New Label()
            Me.lblKpiSucChuaVal = New Label()

            Me.tlpMainContent = New TableLayoutPanel()

            Me.pnlFormCard = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblModeBadge = New Label()
            Me.lblThongBao = New Label()
            Me.lblMaBan = New Label()
            Me.txtMaBan = New TextBox()
            Me.lblSoThuTu = New Label()
            Me.nudSoThuTu = New NumericUpDown()
            Me.lblTenBan = New Label()
            Me.txtTenBan = New TextBox()
            Me.lblKhuVuc = New Label()
            Me.cboKhuVuc = New ComboBox()
            Me.lblSoNguoiToiDa = New Label()
            Me.nudSoNguoiToiDa = New NumericUpDown()
            Me.lblTrangThai = New Label()
            Me.cboTrangThai = New ComboBox()
            Me.pnlHoaDonBadge = New Panel()
            Me.lblHoaDonInfo = New Label()

            Me.tlpButtons = New TableLayoutPanel()
            Me.btnThem = New Button()
            Me.btnCapNhat = New Button()
            Me.btnXoa = New Button()
            Me.btnLamMoi = New Button()

            Me.pnlGridCard = New Panel()
            Me.lblGridTitle = New Label()
            Me.pnlFilterBar = New Panel()
            Me.lblLocKhuVuc = New Label()
            Me.cboLocKhuVuc = New ComboBox()
            Me.lblLocTrangThai = New Label()
            Me.cboLocTrangThai = New ComboBox()
            Me.txtTimKiem = New TextBox()
            Me.btnTaiLai = New Button()
            Me.dgvBan = New DataGridView()
            Me.colMaBan = New DataGridViewTextBoxColumn()
            Me.colSoThuTu = New DataGridViewTextBoxColumn()
            Me.colTenBan = New DataGridViewTextBoxColumn()
            Me.colKhuVuc = New DataGridViewTextBoxColumn()
            Me.colSoNguoiToiDa = New DataGridViewTextBoxColumn()
            Me.colTrangThai = New DataGridViewTextBoxColumn()
            Me.colHoaDon = New DataGridViewTextBoxColumn()

            Me.pnlHeader.SuspendLayout()
            Me.tlpKpiRow.SuspendLayout()
            Me.pnlKpiTongBan.SuspendLayout()
            Me.pnlKpiBanTrong.SuspendLayout()
            Me.pnlKpiDangPhucVu.SuspendLayout()
            Me.pnlKpiSucChua.SuspendLayout()
            Me.tlpMainContent.SuspendLayout()
            Me.pnlFormCard.SuspendLayout()
            CType(Me.nudSoThuTu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.nudSoNguoiToiDa, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHoaDonBadge.SuspendLayout()
            Me.tlpButtons.SuspendLayout()
            Me.pnlGridCard.SuspendLayout()
            Me.pnlFilterBar.SuspendLayout()
            CType(Me.dgvBan, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()

            ' ==============================================================
            ' 1. HEADER BAR (Dock = Top, Height = 68)
            ' ==============================================================
            Me.pnlHeader.BackColor = Color.FromArgb(26, 82, 118)
            Me.pnlHeader.Dock = DockStyle.Top
            Me.pnlHeader.Height = 68
            Me.pnlHeader.Padding = New Padding(20, 10, 20, 10)

            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
            Me.lblTitle.ForeColor = Color.White
            Me.lblTitle.Location = New Point(18, 10)
            Me.lblTitle.Text = "🪑 QUẢN LÝ DANH SÁCH BÀN ĂN"

            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.lblSubtitle.ForeColor = Color.FromArgb(212, 230, 241)
            Me.lblSubtitle.Location = New Point(20, 39)
            Me.lblSubtitle.Text = "Danh mục chuẩn (5/5) • Thiết lập số thứ tự, khu vực, sức chứa và quản lý trạng thái bàn phục vụ"

            Me.btnDong.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnDong.BackColor = Color.FromArgb(192, 57, 43)
            Me.btnDong.Cursor = Cursors.Hand
            Me.btnDong.FlatAppearance.BorderSize = 0
            Me.btnDong.FlatStyle = FlatStyle.Flat
            Me.btnDong.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.btnDong.ForeColor = Color.White
            Me.btnDong.Location = New Point(992, 16)
            Me.btnDong.Size = New Size(108, 36)
            Me.btnDong.Text = "✖ Đóng"
            Me.btnDong.UseVisualStyleBackColor = False

            Me.pnlHeader.Controls.Add(Me.btnDong)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)

            ' ==============================================================
            ' 2. KPI ROW (Dock = Top, Height = 78, 4 cột 25%)
            ' ==============================================================
            Me.tlpKpiRow.ColumnCount = 4
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.Dock = DockStyle.Top
            Me.tlpKpiRow.Height = 78
            Me.tlpKpiRow.Padding = New Padding(16, 8, 16, 4)
            Me.tlpKpiRow.RowCount = 1
            Me.tlpKpiRow.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

            ' KPI 1: Tổng số bàn
            Me.pnlKpiTongBan.BackColor = Color.White
            Me.pnlKpiTongBan.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongBan.Dock = DockStyle.Fill
            Me.pnlKpiTongBan.Margin = New Padding(0, 0, 6, 0)
            Me.lblKpiTongBanTitle.AutoSize = True
            Me.lblKpiTongBanTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiTongBanTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongBanTitle.Location = New Point(10, 8)
            Me.lblKpiTongBanTitle.Text = "TỔNG SỐ BÀN"
            Me.lblKpiTongBanVal.AutoSize = True
            Me.lblKpiTongBanVal.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblKpiTongBanVal.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblKpiTongBanVal.Location = New Point(10, 28)
            Me.lblKpiTongBanVal.Text = "0 bàn"
            Me.pnlKpiTongBan.Controls.Add(Me.lblKpiTongBanVal)
            Me.pnlKpiTongBan.Controls.Add(Me.lblKpiTongBanTitle)

            ' KPI 2: Bàn đang trống
            Me.pnlKpiBanTrong.BackColor = Color.White
            Me.pnlKpiBanTrong.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiBanTrong.Dock = DockStyle.Fill
            Me.pnlKpiBanTrong.Margin = New Padding(3, 0, 3, 0)
            Me.lblKpiBanTrongTitle.AutoSize = True
            Me.lblKpiBanTrongTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiBanTrongTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiBanTrongTitle.Location = New Point(10, 8)
            Me.lblKpiBanTrongTitle.Text = "BÀN ĐANG TRỐNG"
            Me.lblKpiBanTrongVal.AutoSize = True
            Me.lblKpiBanTrongVal.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblKpiBanTrongVal.ForeColor = Color.FromArgb(39, 174, 96)
            Me.lblKpiBanTrongVal.Location = New Point(10, 28)
            Me.lblKpiBanTrongVal.Text = "0 bàn"
            Me.pnlKpiBanTrong.Controls.Add(Me.lblKpiBanTrongVal)
            Me.pnlKpiBanTrong.Controls.Add(Me.lblKpiBanTrongTitle)

            ' KPI 3: Bàn đang phục vụ
            Me.pnlKpiDangPhucVu.BackColor = Color.White
            Me.pnlKpiDangPhucVu.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiDangPhucVu.Dock = DockStyle.Fill
            Me.pnlKpiDangPhucVu.Margin = New Padding(3, 0, 3, 0)
            Me.lblKpiDangPhucVuTitle.AutoSize = True
            Me.lblKpiDangPhucVuTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiDangPhucVuTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiDangPhucVuTitle.Location = New Point(10, 8)
            Me.lblKpiDangPhucVuTitle.Text = "BÀN ĐANG PHỤC VỤ"
            Me.lblKpiDangPhucVuVal.AutoSize = True
            Me.lblKpiDangPhucVuVal.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblKpiDangPhucVuVal.ForeColor = Color.FromArgb(211, 84, 0)
            Me.lblKpiDangPhucVuVal.Location = New Point(10, 28)
            Me.lblKpiDangPhucVuVal.Text = "0 bàn"
            Me.pnlKpiDangPhucVu.Controls.Add(Me.lblKpiDangPhucVuVal)
            Me.pnlKpiDangPhucVu.Controls.Add(Me.lblKpiDangPhucVuTitle)

            ' KPI 4: Tổng sức chứa
            Me.pnlKpiSucChua.BackColor = Color.White
            Me.pnlKpiSucChua.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiSucChua.Dock = DockStyle.Fill
            Me.pnlKpiSucChua.Margin = New Padding(6, 0, 0, 0)
            Me.lblKpiSucChuaTitle.AutoSize = True
            Me.lblKpiSucChuaTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiSucChuaTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiSucChuaTitle.Location = New Point(10, 8)
            Me.lblKpiSucChuaTitle.Text = "TỔNG SỨC CHỨA"
            Me.lblKpiSucChuaVal.AutoSize = True
            Me.lblKpiSucChuaVal.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblKpiSucChuaVal.ForeColor = Color.FromArgb(142, 68, 173)
            Me.lblKpiSucChuaVal.Location = New Point(10, 28)
            Me.lblKpiSucChuaVal.Text = "0 chỗ ngồi"
            Me.pnlKpiSucChua.Controls.Add(Me.lblKpiSucChuaVal)
            Me.pnlKpiSucChua.Controls.Add(Me.lblKpiSucChuaTitle)

            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongBan, 0, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiBanTrong, 1, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiDangPhucVu, 2, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiSucChua, 3, 0)

            ' ==============================================================
            ' 3. MAIN SPLIT CONTENT (Dock = Fill, 38% : 62%)
            ' ==============================================================
            Me.tlpMainContent.ColumnCount = 2
            Me.tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38.0!))
            Me.tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62.0!))
            Me.tlpMainContent.Dock = DockStyle.Fill
            Me.tlpMainContent.Padding = New Padding(16, 6, 16, 14)
            Me.tlpMainContent.RowCount = 1
            Me.tlpMainContent.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

            ' --------------------------------------------------------------
            ' 3A. CỘT TRÁI (38%): THÔNG TIN BÀN ĂN
            ' --------------------------------------------------------------
            Me.pnlFormCard.BackColor = Color.White
            Me.pnlFormCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlFormCard.Dock = DockStyle.Fill
            Me.pnlFormCard.Margin = New Padding(0, 0, 8, 0)
            Me.pnlFormCard.Padding = New Padding(16, 6, 16, 6)

            Me.lblFormTitle.AutoSize = True
            Me.lblFormTitle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            Me.lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblFormTitle.Location = New Point(16, 8)
            Me.lblFormTitle.Text = "📝 THÔNG TIN CHI TIẾT BÀN"

            Me.lblModeBadge.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.lblModeBadge.BackColor = Color.FromArgb(235, 245, 251)
            Me.lblModeBadge.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblModeBadge.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblModeBadge.Location = New Point(236, 7)
            Me.lblModeBadge.Size = New Size(156, 22)
            Me.lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"
            Me.lblModeBadge.TextAlign = ContentAlignment.MiddleCenter

            Me.lblThongBao.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.lblThongBao.BackColor = Color.FromArgb(234, 242, 248)
            Me.lblThongBao.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblThongBao.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblThongBao.Location = New Point(16, 32)
            Me.lblThongBao.Padding = New Padding(6, 2, 6, 2)
            Me.lblThongBao.Size = New Size(376, 28)
            Me.lblThongBao.Text = "💡 Chọn một bàn bên phải để xem / chỉnh sửa hoặc thêm mới."
            Me.lblThongBao.TextAlign = ContentAlignment.MiddleLeft

            ' Hàng 1: Mã bàn & Số thứ tự
            Me.lblMaBan.AutoSize = True
            Me.lblMaBan.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblMaBan.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblMaBan.Location = New Point(16, 64)
            Me.lblMaBan.Text = "Mã bàn (Tự động):"

            Me.txtMaBan.BackColor = Color.FromArgb(238, 242, 246)
            Me.txtMaBan.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.txtMaBan.ForeColor = Color.FromArgb(93, 109, 126)
            Me.txtMaBan.Location = New Point(16, 80)
            Me.txtMaBan.ReadOnly = True
            Me.txtMaBan.Size = New Size(180, 23)
            Me.txtMaBan.Text = "(Tự động)"

            Me.lblSoThuTu.AutoSize = True
            Me.lblSoThuTu.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblSoThuTu.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblSoThuTu.Location = New Point(210, 64)
            Me.lblSoThuTu.Text = "Số thứ tự (* Duy nhất):"

            Me.nudSoThuTu.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.nudSoThuTu.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.nudSoThuTu.Location = New Point(210, 80)
            Me.nudSoThuTu.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
            Me.nudSoThuTu.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudSoThuTu.Size = New Size(182, 23)
            Me.nudSoThuTu.Value = New Decimal(New Integer() {1, 0, 0, 0})

            ' Hàng 2: Tên bàn & Khu vực
            Me.lblTenBan.AutoSize = True
            Me.lblTenBan.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblTenBan.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblTenBan.Location = New Point(16, 108)
            Me.lblTenBan.Text = "Tên bàn ăn (*):"

            Me.txtTenBan.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.txtTenBan.Location = New Point(16, 124)
            Me.txtTenBan.MaxLength = 50
            Me.txtTenBan.Size = New Size(180, 23)

            Me.lblKhuVuc.AutoSize = True
            Me.lblKhuVuc.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblKhuVuc.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblKhuVuc.Location = New Point(210, 108)
            Me.lblKhuVuc.Text = "Khu vực bố trí bàn (*):"

            Me.cboKhuVuc.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.cboKhuVuc.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.cboKhuVuc.FormattingEnabled = True
            Me.cboKhuVuc.Location = New Point(210, 124)
            Me.cboKhuVuc.Size = New Size(182, 23)

            ' Hàng 3: Sức chứa tối đa & Trạng thái
            Me.lblSoNguoiToiDa.AutoSize = True
            Me.lblSoNguoiToiDa.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblSoNguoiToiDa.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblSoNguoiToiDa.Location = New Point(16, 152)
            Me.lblSoNguoiToiDa.Text = "Sức chứa tối đa (*):"

            Me.nudSoNguoiToiDa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.nudSoNguoiToiDa.Location = New Point(16, 168)
            Me.nudSoNguoiToiDa.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
            Me.nudSoNguoiToiDa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.nudSoNguoiToiDa.Size = New Size(180, 23)
            Me.nudSoNguoiToiDa.Value = New Decimal(New Integer() {4, 0, 0, 0})

            Me.lblTrangThai.AutoSize = True
            Me.lblTrangThai.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblTrangThai.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblTrangThai.Location = New Point(210, 152)
            Me.lblTrangThai.Text = "Trạng thái phục vụ:"

            Me.cboTrangThai.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTrangThai.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.cboTrangThai.Location = New Point(210, 168)
            Me.cboTrangThai.Size = New Size(182, 23)

            ' Hàng 4: Badge thông tin Hóa đơn
            Me.pnlHoaDonBadge.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.pnlHoaDonBadge.BackColor = Color.FromArgb(244, 246, 247)
            Me.pnlHoaDonBadge.BorderStyle = BorderStyle.FixedSingle
            Me.pnlHoaDonBadge.Location = New Point(16, 198)
            Me.pnlHoaDonBadge.Size = New Size(376, 26)

            Me.lblHoaDonInfo.Dock = DockStyle.Fill
            Me.lblHoaDonInfo.Font = New Font("Segoe UI", 8.25!, FontStyle.Bold)
            Me.lblHoaDonInfo.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblHoaDonInfo.Text = "🧾 Phiên phục vụ: Bàn trống"
            Me.lblHoaDonInfo.TextAlign = ContentAlignment.MiddleLeft
            Me.pnlHoaDonBadge.Controls.Add(Me.lblHoaDonInfo)

            ' Cụm 4 nút CRUD
            Me.tlpButtons.ColumnCount = 2
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.Dock = DockStyle.Bottom
            Me.tlpButtons.Height = 72
            Me.tlpButtons.RowCount = 2
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))

            Me.btnThem.BackColor = Color.FromArgb(39, 174, 96)
            Me.btnThem.Cursor = Cursors.Hand
            Me.btnThem.Dock = DockStyle.Fill
            Me.btnThem.FlatAppearance.BorderSize = 0
            Me.btnThem.FlatStyle = FlatStyle.Flat
            Me.btnThem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnThem.ForeColor = Color.White
            Me.btnThem.Margin = New Padding(0, 0, 4, 4)
            Me.btnThem.Text = "➕ Thêm bàn mới"
            Me.btnThem.UseVisualStyleBackColor = False

            Me.btnCapNhat.BackColor = Color.FromArgb(41, 128, 185)
            Me.btnCapNhat.Cursor = Cursors.Hand
            Me.btnCapNhat.Dock = DockStyle.Fill
            Me.btnCapNhat.FlatAppearance.BorderSize = 0
            Me.btnCapNhat.FlatStyle = FlatStyle.Flat
            Me.btnCapNhat.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnCapNhat.ForeColor = Color.White
            Me.btnCapNhat.Margin = New Padding(4, 0, 0, 4)
            Me.btnCapNhat.Text = "💾 Lưu cập nhật"
            Me.btnCapNhat.UseVisualStyleBackColor = False

            Me.btnXoa.BackColor = Color.FromArgb(192, 57, 43)
            Me.btnXoa.Cursor = Cursors.Hand
            Me.btnXoa.Dock = DockStyle.Fill
            Me.btnXoa.FlatAppearance.BorderSize = 0
            Me.btnXoa.FlatStyle = FlatStyle.Flat
            Me.btnXoa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnXoa.ForeColor = Color.White
            Me.btnXoa.Margin = New Padding(0, 4, 4, 0)
            Me.btnXoa.Text = "🗑️ Xóa bàn"
            Me.btnXoa.UseVisualStyleBackColor = False

            Me.btnLamMoi.BackColor = Color.FromArgb(93, 109, 126)
            Me.btnLamMoi.Cursor = Cursors.Hand
            Me.btnLamMoi.Dock = DockStyle.Fill
            Me.btnLamMoi.FlatAppearance.BorderSize = 0
            Me.btnLamMoi.FlatStyle = FlatStyle.Flat
            Me.btnLamMoi.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnLamMoi.ForeColor = Color.White
            Me.btnLamMoi.Margin = New Padding(4, 4, 0, 0)
            Me.btnLamMoi.Text = "🔄 Làm mới"
            Me.btnLamMoi.UseVisualStyleBackColor = False

            Me.tlpButtons.Controls.Add(Me.btnThem, 0, 0)
            Me.tlpButtons.Controls.Add(Me.btnCapNhat, 1, 0)
            Me.tlpButtons.Controls.Add(Me.btnXoa, 0, 1)
            Me.tlpButtons.Controls.Add(Me.btnLamMoi, 1, 1)

            Me.pnlFormCard.Controls.Add(Me.tlpButtons)
            Me.pnlFormCard.Controls.Add(Me.pnlHoaDonBadge)
            Me.pnlFormCard.Controls.Add(Me.cboTrangThai)
            Me.pnlFormCard.Controls.Add(Me.lblTrangThai)
            Me.pnlFormCard.Controls.Add(Me.nudSoNguoiToiDa)
            Me.pnlFormCard.Controls.Add(Me.lblSoNguoiToiDa)
            Me.pnlFormCard.Controls.Add(Me.cboKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.lblKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.txtTenBan)
            Me.pnlFormCard.Controls.Add(Me.lblTenBan)
            Me.pnlFormCard.Controls.Add(Me.nudSoThuTu)
            Me.pnlFormCard.Controls.Add(Me.lblSoThuTu)
            Me.pnlFormCard.Controls.Add(Me.txtMaBan)
            Me.pnlFormCard.Controls.Add(Me.lblMaBan)
            Me.pnlFormCard.Controls.Add(Me.lblThongBao)
            Me.pnlFormCard.Controls.Add(Me.lblModeBadge)
            Me.pnlFormCard.Controls.Add(Me.lblFormTitle)

            ' --------------------------------------------------------------
            ' 3B. CỘT PHẢI (62%): DANH SÁCH BÀN ĂN & BỘ LỌC
            ' --------------------------------------------------------------
            Me.pnlGridCard.BackColor = Color.White
            Me.pnlGridCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlGridCard.Dock = DockStyle.Fill
            Me.pnlGridCard.Margin = New Padding(8, 0, 0, 0)
            Me.pnlGridCard.Padding = New Padding(16, 10, 16, 10)

            Me.lblGridTitle.Dock = DockStyle.Top
            Me.lblGridTitle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            Me.lblGridTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblGridTitle.Height = 26
            Me.lblGridTitle.Text = "📋 DANH SÁCH BÀN ĂN (Click chọn dòng để xem / sửa)"

            Me.pnlFilterBar.BackColor = Color.FromArgb(240, 243, 246)
            Me.pnlFilterBar.Dock = DockStyle.Top
            Me.pnlFilterBar.Height = 44
            Me.pnlFilterBar.Padding = New Padding(8, 8, 8, 8)

            Me.lblLocKhuVuc.AutoSize = True
            Me.lblLocKhuVuc.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblLocKhuVuc.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblLocKhuVuc.Location = New Point(8, 12)
            Me.lblLocKhuVuc.Text = "Khu vực:"

            Me.cboLocKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboLocKhuVuc.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Me.cboLocKhuVuc.Location = New Point(68, 8)
            Me.cboLocKhuVuc.Size = New Size(150, 23)

            Me.lblLocTrangThai.AutoSize = True
            Me.lblLocTrangThai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblLocTrangThai.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblLocTrangThai.Location = New Point(226, 12)
            Me.lblLocTrangThai.Text = "Trạng thái:"

            Me.cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboLocTrangThai.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Me.cboLocTrangThai.Location = New Point(296, 8)
            Me.cboLocTrangThai.Size = New Size(130, 23)

            Me.txtTimKiem.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTimKiem.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Me.txtTimKiem.Location = New Point(434, 8)
            Me.txtTimKiem.PlaceholderText = "🔍 Tên bàn, STT..."
            Me.txtTimKiem.Size = New Size(150, 23)

            Me.btnTaiLai.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTaiLai.BackColor = Color.FromArgb(93, 109, 126)
            Me.btnTaiLai.Cursor = Cursors.Hand
            Me.btnTaiLai.FlatAppearance.BorderSize = 0
            Me.btnTaiLai.FlatStyle = FlatStyle.Flat
            Me.btnTaiLai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.btnTaiLai.ForeColor = Color.White
            Me.btnTaiLai.Location = New Point(592, 7)
            Me.btnTaiLai.Size = New Size(74, 25)
            Me.btnTaiLai.Text = "↻ Tải lại"
            Me.btnTaiLai.UseVisualStyleBackColor = False

            Me.pnlFilterBar.Controls.Add(Me.btnTaiLai)
            Me.pnlFilterBar.Controls.Add(Me.txtTimKiem)
            Me.pnlFilterBar.Controls.Add(Me.cboLocTrangThai)
            Me.pnlFilterBar.Controls.Add(Me.lblLocTrangThai)
            Me.pnlFilterBar.Controls.Add(Me.cboLocKhuVuc)
            Me.pnlFilterBar.Controls.Add(Me.lblLocKhuVuc)

            ' DataGridView Danh sách bàn (7 cột)
            Me.dgvBan.AllowUserToAddRows = False
            Me.dgvBan.AllowUserToDeleteRows = False
            Me.dgvBan.AllowUserToResizeRows = False
            Me.dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvBan.BackgroundColor = Color.White
            Me.dgvBan.BorderStyle = BorderStyle.FixedSingle
            Me.dgvBan.ColumnHeadersHeight = 36
            Me.dgvBan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvBan.Dock = DockStyle.Fill
            Me.dgvBan.EnableHeadersVisualStyles = False
            Me.dgvBan.MultiSelect = False
            Me.dgvBan.ReadOnly = True
            Me.dgvBan.RowHeadersVisible = False
            Me.dgvBan.RowTemplate.Height = 34
            Me.dgvBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Me.colMaBan.DataPropertyName = "MaBan"
            Me.colMaBan.FillWeight = 9.0!
            Me.colMaBan.HeaderText = "Mã"
            Me.colMaBan.Name = "colMaBan"

            Me.colSoThuTu.DataPropertyName = "SoThuTu"
            Me.colSoThuTu.FillWeight = 8.0!
            Me.colSoThuTu.HeaderText = "STT"
            Me.colSoThuTu.Name = "colSoThuTu"

            Me.colTenBan.DataPropertyName = "TenBan"
            Me.colTenBan.FillWeight = 20.0!
            Me.colTenBan.HeaderText = "Tên bàn ăn"
            Me.colTenBan.Name = "colTenBan"

            Me.colKhuVuc.DataPropertyName = "KhuVuc"
            Me.colKhuVuc.FillWeight = 22.0!
            Me.colKhuVuc.HeaderText = "Khu vực"
            Me.colKhuVuc.Name = "colKhuVuc"

            Me.colSoNguoiToiDa.DataPropertyName = "SucChuaText"
            Me.colSoNguoiToiDa.FillWeight = 13.0!
            Me.colSoNguoiToiDa.HeaderText = "Sức chứa"
            Me.colSoNguoiToiDa.Name = "colSoNguoiToiDa"

            Me.colTrangThai.DataPropertyName = "TrangThaiText"
            Me.colTrangThai.FillWeight = 16.0!
            Me.colTrangThai.HeaderText = "Trạng thái"
            Me.colTrangThai.Name = "colTrangThai"

            Me.colHoaDon.DataPropertyName = "ThongTinHoaDon"
            Me.colHoaDon.FillWeight = 18.0!
            Me.colHoaDon.HeaderText = "Hóa đơn phục vụ"
            Me.colHoaDon.Name = "colHoaDon"

            Me.dgvBan.Columns.AddRange(New DataGridViewColumn() {
                Me.colMaBan, Me.colSoThuTu, Me.colTenBan, Me.colKhuVuc, Me.colSoNguoiToiDa, Me.colTrangThai, Me.colHoaDon
            })

            ' Z-Order chuẩn trong pnlGridCard: Fill (0) -> Top (1, 2)
            Me.pnlGridCard.Controls.Add(Me.dgvBan)
            Me.pnlGridCard.Controls.Add(Me.pnlFilterBar)
            Me.pnlGridCard.Controls.Add(Me.lblGridTitle)

            Me.tlpMainContent.Controls.Add(Me.pnlFormCard, 0, 0)
            Me.tlpMainContent.Controls.Add(Me.pnlGridCard, 1, 0)

            ' ==============================================================
            ' CẤU HÌNH FORM CHÍNH (Z-Order: Fill -> Top -> Top)
            ' ==============================================================
            Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.FromArgb(245, 247, 250)
            Me.ClientSize = New Size(1120, 680)
            Me.Controls.Add(Me.tlpMainContent)
            Me.Controls.Add(Me.tlpKpiRow)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.KeyPreview = True
            Me.MinimumSize = New Size(1020, 640)
            Me.Name = "frmBan"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Quản Lý Danh Sách Bàn Ăn - Quán Ăn Hương Việt"

            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tlpKpiRow.ResumeLayout(False)
            Me.pnlKpiTongBan.ResumeLayout(False)
            Me.pnlKpiTongBan.PerformLayout()
            Me.pnlKpiBanTrong.ResumeLayout(False)
            Me.pnlKpiBanTrong.PerformLayout()
            Me.pnlKpiDangPhucVu.ResumeLayout(False)
            Me.pnlKpiDangPhucVu.PerformLayout()
            Me.pnlKpiSucChua.ResumeLayout(False)
            Me.pnlKpiSucChua.PerformLayout()
            Me.tlpMainContent.ResumeLayout(False)
            Me.pnlFormCard.ResumeLayout(False)
            Me.pnlFormCard.PerformLayout()
            CType(Me.nudSoThuTu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.nudSoNguoiToiDa, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHoaDonBadge.ResumeLayout(False)
            Me.tlpButtons.ResumeLayout(False)
            Me.pnlGridCard.ResumeLayout(False)
            Me.pnlFilterBar.ResumeLayout(False)
            Me.pnlFilterBar.PerformLayout()
            CType(Me.dgvBan, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

    End Class

End Namespace
