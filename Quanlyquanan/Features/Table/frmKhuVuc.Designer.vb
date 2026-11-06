Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Table

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmKhuVuc
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
        Friend WithEvents btnMoBan As Button
        Friend WithEvents btnDong As Button

        Friend WithEvents tlpKpiRow As TableLayoutPanel
        Friend WithEvents pnlKpiTongKhuVuc As Panel
        Friend WithEvents lblKpiTongKhuVucTitle As Label
        Friend WithEvents lblKpiTongKhuVucVal As Label
        Friend WithEvents pnlKpiTongBan As Panel
        Friend WithEvents lblKpiTongBanTitle As Label
        Friend WithEvents lblKpiTongBanVal As Label
        Friend WithEvents pnlKpiTongCho As Panel
        Friend WithEvents lblKpiTongChoTitle As Label
        Friend WithEvents lblKpiTongChoVal As Label

        Friend WithEvents tlpMainContent As TableLayoutPanel

        ' Cột trái (38%) - Biểu mẫu Chi tiết Khu vực bàn
        Friend WithEvents pnlFormCard As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblModeBadge As Label
        Friend WithEvents lblThongBao As Label
        Friend WithEvents lblMaKhuVuc As Label
        Friend WithEvents txtMaKhuVuc As TextBox
        Friend WithEvents lblTenKhuVuc As Label
        Friend WithEvents txtTenKhuVuc As TextBox
        Friend WithEvents lblMoTa As Label
        Friend WithEvents txtMoTa As TextBox
        Friend WithEvents pnlThongKeBanBadge As Panel
        Friend WithEvents lblThongKeBan As Label

        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnCapNhat As Button
        Friend WithEvents btnXoa As Button
        Friend WithEvents btnLamMoi As Button

        ' Cột phải (62%) - Danh sách Khu vực + Thanh tìm kiếm
        Friend WithEvents pnlGridCard As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlSearchBar As Panel
        Friend WithEvents lblTimKiem As Label
        Friend WithEvents txtTimKiem As TextBox
        Friend WithEvents btnTimKiem As Button
        Friend WithEvents btnTaiLai As Button
        Friend WithEvents dgvKhuVuc As DataGridView
        Friend WithEvents colMaKV As DataGridViewTextBoxColumn
        Friend WithEvents colTenKV As DataGridViewTextBoxColumn
        Friend WithEvents colMoTa As DataGridViewTextBoxColumn
        Friend WithEvents colSoBan As DataGridViewTextBoxColumn
        Friend WithEvents colTongCho As DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnMoBan = New Button()
            Me.btnDong = New Button()

            Me.tlpKpiRow = New TableLayoutPanel()
            Me.pnlKpiTongKhuVuc = New Panel()
            Me.lblKpiTongKhuVucTitle = New Label()
            Me.lblKpiTongKhuVucVal = New Label()
            Me.pnlKpiTongBan = New Panel()
            Me.lblKpiTongBanTitle = New Label()
            Me.lblKpiTongBanVal = New Label()
            Me.pnlKpiTongCho = New Panel()
            Me.lblKpiTongChoTitle = New Label()
            Me.lblKpiTongChoVal = New Label()

            Me.tlpMainContent = New TableLayoutPanel()

            Me.pnlFormCard = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblModeBadge = New Label()
            Me.lblThongBao = New Label()
            Me.lblMaKhuVuc = New Label()
            Me.txtMaKhuVuc = New TextBox()
            Me.lblTenKhuVuc = New Label()
            Me.txtTenKhuVuc = New TextBox()
            Me.lblMoTa = New Label()
            Me.txtMoTa = New TextBox()
            Me.pnlThongKeBanBadge = New Panel()
            Me.lblThongKeBan = New Label()

            Me.tlpButtons = New TableLayoutPanel()
            Me.btnThem = New Button()
            Me.btnCapNhat = New Button()
            Me.btnXoa = New Button()
            Me.btnLamMoi = New Button()

            Me.pnlGridCard = New Panel()
            Me.lblGridTitle = New Label()
            Me.pnlSearchBar = New Panel()
            Me.lblTimKiem = New Label()
            Me.txtTimKiem = New TextBox()
            Me.btnTimKiem = New Button()
            Me.btnTaiLai = New Button()
            Me.dgvKhuVuc = New DataGridView()
            Me.colMaKV = New DataGridViewTextBoxColumn()
            Me.colTenKV = New DataGridViewTextBoxColumn()
            Me.colMoTa = New DataGridViewTextBoxColumn()
            Me.colSoBan = New DataGridViewTextBoxColumn()
            Me.colTongCho = New DataGridViewTextBoxColumn()

            Me.pnlHeader.SuspendLayout()
            Me.tlpKpiRow.SuspendLayout()
            Me.pnlKpiTongKhuVuc.SuspendLayout()
            Me.pnlKpiTongBan.SuspendLayout()
            Me.pnlKpiTongCho.SuspendLayout()
            Me.tlpMainContent.SuspendLayout()
            Me.pnlFormCard.SuspendLayout()
            Me.pnlThongKeBanBadge.SuspendLayout()
            Me.tlpButtons.SuspendLayout()
            Me.pnlGridCard.SuspendLayout()
            Me.pnlSearchBar.SuspendLayout()
            CType(Me.dgvKhuVuc, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblTitle.Text = "🏢 QUẢN LÝ KHU VỰC BÀN ĂN"

            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.lblSubtitle.ForeColor = Color.FromArgb(212, 230, 241)
            Me.lblSubtitle.Location = New Point(20, 39)
            Me.lblSubtitle.Text = "Danh mục chuẩn (4/5) • Phân loại không gian sảnh, phòng VIP, sân vườn & đồng bộ sơ đồ bàn"

            Me.btnMoBan.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnMoBan.BackColor = Color.FromArgb(41, 128, 185)
            Me.btnMoBan.Cursor = Cursors.Hand
            Me.btnMoBan.FlatAppearance.BorderSize = 0
            Me.btnMoBan.FlatStyle = FlatStyle.Flat
            Me.btnMoBan.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.btnMoBan.ForeColor = Color.White
            Me.btnMoBan.Location = New Point(804, 16)
            Me.btnMoBan.Size = New Size(140, 36)
            Me.btnMoBan.Text = "🪑 Quản lý Bàn"
            Me.btnMoBan.UseVisualStyleBackColor = False

            Me.btnDong.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnDong.BackColor = Color.FromArgb(192, 57, 43)
            Me.btnDong.Cursor = Cursors.Hand
            Me.btnDong.FlatAppearance.BorderSize = 0
            Me.btnDong.FlatStyle = FlatStyle.Flat
            Me.btnDong.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.btnDong.ForeColor = Color.White
            Me.btnDong.Location = New Point(952, 16)
            Me.btnDong.Size = New Size(108, 36)
            Me.btnDong.Text = "✖ Đóng"
            Me.btnDong.UseVisualStyleBackColor = False

            Me.pnlHeader.Controls.Add(Me.btnMoBan)
            Me.pnlHeader.Controls.Add(Me.btnDong)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.lblTitle)

            ' ==============================================================
            ' 2. KPI ROW (Dock = Top, Height = 78, 3 cột 33.33%)
            ' ==============================================================
            Me.tlpKpiRow.ColumnCount = 3
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.34!))
            Me.tlpKpiRow.Dock = DockStyle.Top
            Me.tlpKpiRow.Height = 78
            Me.tlpKpiRow.Padding = New Padding(16, 8, 16, 4)
            Me.tlpKpiRow.RowCount = 1
            Me.tlpKpiRow.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))

            ' KPI 1: Tổng số khu vực hoạt động
            Me.pnlKpiTongKhuVuc.BackColor = Color.White
            Me.pnlKpiTongKhuVuc.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongKhuVuc.Dock = DockStyle.Fill
            Me.pnlKpiTongKhuVuc.Margin = New Padding(0, 0, 8, 0)
            Me.lblKpiTongKhuVucTitle.AutoSize = True
            Me.lblKpiTongKhuVucTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiTongKhuVucTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongKhuVucTitle.Location = New Point(12, 8)
            Me.lblKpiTongKhuVucTitle.Text = "TỔNG SỐ KHU VỰC HOẠT ĐỘNG"
            Me.lblKpiTongKhuVucVal.AutoSize = True
            Me.lblKpiTongKhuVucVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiTongKhuVucVal.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblKpiTongKhuVucVal.Location = New Point(12, 28)
            Me.lblKpiTongKhuVucVal.Text = "0 khu vực"
            Me.pnlKpiTongKhuVuc.Controls.Add(Me.lblKpiTongKhuVucVal)
            Me.pnlKpiTongKhuVuc.Controls.Add(Me.lblKpiTongKhuVucTitle)

            ' KPI 2: Tổng số bàn đã bố trí
            Me.pnlKpiTongBan.BackColor = Color.White
            Me.pnlKpiTongBan.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongBan.Dock = DockStyle.Fill
            Me.pnlKpiTongBan.Margin = New Padding(4, 0, 4, 0)
            Me.lblKpiTongBanTitle.AutoSize = True
            Me.lblKpiTongBanTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiTongBanTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongBanTitle.Location = New Point(12, 8)
            Me.lblKpiTongBanTitle.Text = "TỔNG SỐ BÀN ĐÃ BỐ TRÍ"
            Me.lblKpiTongBanVal.AutoSize = True
            Me.lblKpiTongBanVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiTongBanVal.ForeColor = Color.FromArgb(39, 174, 96)
            Me.lblKpiTongBanVal.Location = New Point(12, 28)
            Me.lblKpiTongBanVal.Text = "0 bàn"
            Me.pnlKpiTongBan.Controls.Add(Me.lblKpiTongBanVal)
            Me.pnlKpiTongBan.Controls.Add(Me.lblKpiTongBanTitle)

            ' KPI 3: Tổng sức chứa khách tối đa
            Me.pnlKpiTongCho.BackColor = Color.White
            Me.pnlKpiTongCho.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongCho.Dock = DockStyle.Fill
            Me.pnlKpiTongCho.Margin = New Padding(8, 0, 0, 0)
            Me.lblKpiTongChoTitle.AutoSize = True
            Me.lblKpiTongChoTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiTongChoTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongChoTitle.Location = New Point(12, 8)
            Me.lblKpiTongChoTitle.Text = "TỔNG SỨC CHỨA KHÁCH TỐI ĐA"
            Me.lblKpiTongChoVal.AutoSize = True
            Me.lblKpiTongChoVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiTongChoVal.ForeColor = Color.FromArgb(211, 84, 0)
            Me.lblKpiTongChoVal.Location = New Point(12, 28)
            Me.lblKpiTongChoVal.Text = "0 chỗ ngồi"
            Me.pnlKpiTongCho.Controls.Add(Me.lblKpiTongChoVal)
            Me.pnlKpiTongCho.Controls.Add(Me.lblKpiTongChoTitle)

            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongKhuVuc, 0, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongBan, 1, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongCho, 2, 0)

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
            ' 3A. CỘT TRÁI (38%): THÔNG TIN KHU VỰC
            ' --------------------------------------------------------------
            Me.pnlFormCard.BackColor = Color.White
            Me.pnlFormCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlFormCard.Dock = DockStyle.Fill
            Me.pnlFormCard.Margin = New Padding(0, 0, 8, 0)
            Me.pnlFormCard.Padding = New Padding(16, 12, 16, 12)

            Me.lblFormTitle.AutoSize = True
            Me.lblFormTitle.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
            Me.lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblFormTitle.Location = New Point(16, 12)
            Me.lblFormTitle.Text = "📝 THÔNG TIN KHU VỰC"

            Me.lblModeBadge.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.lblModeBadge.BackColor = Color.FromArgb(235, 245, 251)
            Me.lblModeBadge.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblModeBadge.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblModeBadge.Location = New Point(222, 11)
            Me.lblModeBadge.Size = New Size(154, 24)
            Me.lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"
            Me.lblModeBadge.TextAlign = ContentAlignment.MiddleCenter

            Me.lblThongBao.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.lblThongBao.BackColor = Color.FromArgb(234, 242, 248)
            Me.lblThongBao.Font = New Font("Segoe UI", 8.75!, FontStyle.Bold)
            Me.lblThongBao.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblThongBao.Location = New Point(16, 40)
            Me.lblThongBao.Padding = New Padding(8, 4, 8, 4)
            Me.lblThongBao.Size = New Size(360, 36)
            Me.lblThongBao.Text = "💡 Chọn một khu vực bên phải để chỉnh sửa hoặc nhập khu vực mới."
            Me.lblThongBao.TextAlign = ContentAlignment.MiddleLeft

            ' Mã khu vực
            Me.lblMaKhuVuc.AutoSize = True
            Me.lblMaKhuVuc.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblMaKhuVuc.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblMaKhuVuc.Location = New Point(16, 82)
            Me.lblMaKhuVuc.Text = "Mã khu vực (Tự động):"

            Me.txtMaKhuVuc.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtMaKhuVuc.BackColor = Color.FromArgb(238, 242, 246)
            Me.txtMaKhuVuc.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.txtMaKhuVuc.ForeColor = Color.FromArgb(93, 109, 126)
            Me.txtMaKhuVuc.Location = New Point(16, 102)
            Me.txtMaKhuVuc.ReadOnly = True
            Me.txtMaKhuVuc.Size = New Size(360, 26)
            Me.txtMaKhuVuc.Text = "(Tự động)"

            ' Tên khu vực
            Me.lblTenKhuVuc.AutoSize = True
            Me.lblTenKhuVuc.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblTenKhuVuc.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblTenKhuVuc.Location = New Point(16, 134)
            Me.lblTenKhuVuc.Text = "Tên khu vực (*):"

            Me.txtTenKhuVuc.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTenKhuVuc.Font = New Font("Segoe UI", 9.75!, FontStyle.Regular)
            Me.txtTenKhuVuc.Location = New Point(16, 154)
            Me.txtTenKhuVuc.MaxLength = 50
            Me.txtTenKhuVuc.Size = New Size(360, 26)

            ' Mô tả không gian & Tiện ích
            Me.lblMoTa.AutoSize = True
            Me.lblMoTa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblMoTa.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblMoTa.Location = New Point(16, 186)
            Me.lblMoTa.Text = "Mô tả không gian & Tiện ích:"

            Me.txtMoTa.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtMoTa.Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
            Me.txtMoTa.Location = New Point(16, 206)
            Me.txtMoTa.MaxLength = 255
            Me.txtMoTa.Multiline = True
            Me.txtMoTa.Size = New Size(360, 75)

            ' Badge Thống kê số bàn thuộc khu vực
            Me.pnlThongKeBanBadge.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.pnlThongKeBanBadge.BackColor = Color.FromArgb(244, 236, 247)
            Me.pnlThongKeBanBadge.BorderStyle = BorderStyle.FixedSingle
            Me.pnlThongKeBanBadge.Location = New Point(16, 290)
            Me.pnlThongKeBanBadge.Size = New Size(360, 34)

            Me.lblThongKeBan.Dock = DockStyle.Fill
            Me.lblThongKeBan.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblThongKeBan.ForeColor = Color.FromArgb(108, 52, 131)
            Me.lblThongKeBan.Text = "🪑 Số bàn hiện có: 0 bàn  |  👥 Sức chứa: 0 chỗ"
            Me.lblThongKeBan.TextAlign = ContentAlignment.MiddleCenter
            Me.pnlThongKeBanBadge.Controls.Add(Me.lblThongKeBan)

            ' Cụm 4 nút CRUD (2x2) ở đáy pnlFormCard
            Me.tlpButtons.ColumnCount = 2
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.Dock = DockStyle.Bottom
            Me.tlpButtons.Height = 78
            Me.tlpButtons.RowCount = 2
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))

            Me.btnThem.BackColor = Color.FromArgb(39, 174, 96)
            Me.btnThem.Cursor = Cursors.Hand
            Me.btnThem.Dock = DockStyle.Fill
            Me.btnThem.FlatAppearance.BorderSize = 0
            Me.btnThem.FlatStyle = FlatStyle.Flat
            Me.btnThem.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            Me.btnThem.ForeColor = Color.White
            Me.btnThem.Margin = New Padding(0, 0, 4, 4)
            Me.btnThem.Text = "➕ Thêm mới"
            Me.btnThem.UseVisualStyleBackColor = False

            Me.btnCapNhat.BackColor = Color.FromArgb(41, 128, 185)
            Me.btnCapNhat.Cursor = Cursors.Hand
            Me.btnCapNhat.Dock = DockStyle.Fill
            Me.btnCapNhat.FlatAppearance.BorderSize = 0
            Me.btnCapNhat.FlatStyle = FlatStyle.Flat
            Me.btnCapNhat.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            Me.btnCapNhat.ForeColor = Color.White
            Me.btnCapNhat.Margin = New Padding(4, 0, 0, 4)
            Me.btnCapNhat.Text = "💾 Cập nhật"
            Me.btnCapNhat.UseVisualStyleBackColor = False

            Me.btnXoa.BackColor = Color.FromArgb(192, 57, 43)
            Me.btnXoa.Cursor = Cursors.Hand
            Me.btnXoa.Dock = DockStyle.Fill
            Me.btnXoa.FlatAppearance.BorderSize = 0
            Me.btnXoa.FlatStyle = FlatStyle.Flat
            Me.btnXoa.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            Me.btnXoa.ForeColor = Color.White
            Me.btnXoa.Margin = New Padding(0, 4, 4, 0)
            Me.btnXoa.Text = "🗑️ Xóa khu vực"
            Me.btnXoa.UseVisualStyleBackColor = False

            Me.btnLamMoi.BackColor = Color.FromArgb(93, 109, 126)
            Me.btnLamMoi.Cursor = Cursors.Hand
            Me.btnLamMoi.Dock = DockStyle.Fill
            Me.btnLamMoi.FlatAppearance.BorderSize = 0
            Me.btnLamMoi.FlatStyle = FlatStyle.Flat
            Me.btnLamMoi.Font = New Font("Segoe UI", 9.25!, FontStyle.Bold)
            Me.btnLamMoi.ForeColor = Color.White
            Me.btnLamMoi.Margin = New Padding(4, 4, 0, 0)
            Me.btnLamMoi.Text = "🔄 Làm mới"
            Me.btnLamMoi.UseVisualStyleBackColor = False

            Me.tlpButtons.Controls.Add(Me.btnThem, 0, 0)
            Me.tlpButtons.Controls.Add(Me.btnCapNhat, 1, 0)
            Me.tlpButtons.Controls.Add(Me.btnXoa, 0, 1)
            Me.tlpButtons.Controls.Add(Me.btnLamMoi, 1, 1)

            Me.pnlFormCard.Controls.Add(Me.tlpButtons)
            Me.pnlFormCard.Controls.Add(Me.pnlThongKeBanBadge)
            Me.pnlFormCard.Controls.Add(Me.txtMoTa)
            Me.pnlFormCard.Controls.Add(Me.lblMoTa)
            Me.pnlFormCard.Controls.Add(Me.txtTenKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.lblTenKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.txtMaKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.lblMaKhuVuc)
            Me.pnlFormCard.Controls.Add(Me.lblThongBao)
            Me.pnlFormCard.Controls.Add(Me.lblModeBadge)
            Me.pnlFormCard.Controls.Add(Me.lblFormTitle)

            ' --------------------------------------------------------------
            ' 3B. CỘT PHẢI (62%): DANH SÁCH KHU VỰC BÀN ĂN & TÌM KIẾM
            ' --------------------------------------------------------------
            Me.pnlGridCard.BackColor = Color.White
            Me.pnlGridCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlGridCard.Dock = DockStyle.Fill
            Me.pnlGridCard.Margin = New Padding(8, 0, 0, 0)
            Me.pnlGridCard.Padding = New Padding(16, 12, 16, 12)

            Me.lblGridTitle.Dock = DockStyle.Top
            Me.lblGridTitle.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
            Me.lblGridTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblGridTitle.Height = 28
            Me.lblGridTitle.Text = "📋 DANH SÁCH KHU VỰC BÀN ĂN (Click chọn dòng để xem / sửa)"

            Me.pnlSearchBar.BackColor = Color.FromArgb(240, 243, 246)
            Me.pnlSearchBar.Dock = DockStyle.Top
            Me.pnlSearchBar.Height = 46
            Me.pnlSearchBar.Padding = New Padding(10, 8, 10, 8)

            Me.lblTimKiem.AutoSize = True
            Me.lblTimKiem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblTimKiem.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblTimKiem.Location = New Point(10, 14)
            Me.lblTimKiem.Text = "🔍 Tìm kiếm:"

            Me.txtTimKiem.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTimKiem.Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
            Me.txtTimKiem.Location = New Point(95, 10)
            Me.txtTimKiem.Size = New Size(340, 26)

            Me.btnTimKiem.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTimKiem.BackColor = Color.FromArgb(26, 82, 118)
            Me.btnTimKiem.Cursor = Cursors.Hand
            Me.btnTimKiem.FlatAppearance.BorderSize = 0
            Me.btnTimKiem.FlatStyle = FlatStyle.Flat
            Me.btnTimKiem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnTimKiem.ForeColor = Color.White
            Me.btnTimKiem.Location = New Point(445, 9)
            Me.btnTimKiem.Size = New Size(95, 28)
            Me.btnTimKiem.Text = "Tìm kiếm"
            Me.btnTimKiem.UseVisualStyleBackColor = False

            Me.btnTaiLai.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTaiLai.BackColor = Color.FromArgb(100, 116, 139)
            Me.btnTaiLai.Cursor = Cursors.Hand
            Me.btnTaiLai.FlatAppearance.BorderSize = 0
            Me.btnTaiLai.FlatStyle = FlatStyle.Flat
            Me.btnTaiLai.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnTaiLai.ForeColor = Color.White
            Me.btnTaiLai.Location = New Point(546, 9)
            Me.btnTaiLai.Size = New Size(85, 28)
            Me.btnTaiLai.Text = "🔄 Tải lại"
            Me.btnTaiLai.UseVisualStyleBackColor = False

            Me.pnlSearchBar.Controls.Add(Me.btnTaiLai)
            Me.pnlSearchBar.Controls.Add(Me.btnTimKiem)
            Me.pnlSearchBar.Controls.Add(Me.txtTimKiem)
            Me.pnlSearchBar.Controls.Add(Me.lblTimKiem)

            ' Cấu hình DataGridView dgvKhuVuc
            Me.dgvKhuVuc.AllowUserToAddRows = False
            Me.dgvKhuVuc.AllowUserToDeleteRows = False
            Me.dgvKhuVuc.AllowUserToResizeRows = False
            Me.dgvKhuVuc.BackgroundColor = Color.White
            Me.dgvKhuVuc.BorderStyle = BorderStyle.Fixed3D
            Me.dgvKhuVuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvKhuVuc.ColumnHeadersHeight = 36
            Me.dgvKhuVuc.Dock = DockStyle.Fill
            Me.dgvKhuVuc.EnableHeadersVisualStyles = False
            Me.dgvKhuVuc.MultiSelect = False
            Me.dgvKhuVuc.ReadOnly = True
            Me.dgvKhuVuc.RowHeadersVisible = False
            Me.dgvKhuVuc.RowTemplate.Height = 32
            Me.dgvKhuVuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Me.colMaKV.DataPropertyName = "KV_Ma"
            Me.colMaKV.HeaderText = "Mã KV"
            Me.colMaKV.Width = 75

            Me.colTenKV.DataPropertyName = "KV_Ten"
            Me.colTenKV.HeaderText = "Tên khu vực"
            Me.colTenKV.Width = 170

            Me.colMoTa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.colMoTa.DataPropertyName = "KV_MoTa"
            Me.colMoTa.HeaderText = "Mô tả không gian"

            Me.colSoBan.DataPropertyName = "SoLuongBan"
            Me.colSoBan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.colSoBan.HeaderText = "Số bàn hiện có"
            Me.colSoBan.Width = 110

            Me.colTongCho.DataPropertyName = "TongSucChua"
            Me.colTongCho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Me.colTongCho.HeaderText = "Tổng chỗ ngồi"
            Me.colTongCho.Width = 115

            Me.dgvKhuVuc.Columns.AddRange(New DataGridViewColumn() {
                Me.colMaKV,
                Me.colTenKV,
                Me.colMoTa,
                Me.colSoBan,
                Me.colTongCho
            })

            Me.pnlGridCard.Controls.Add(Me.dgvKhuVuc)
            Me.pnlGridCard.Controls.Add(Me.pnlSearchBar)
            Me.pnlGridCard.Controls.Add(Me.lblGridTitle)

            Me.tlpMainContent.Controls.Add(Me.pnlFormCard, 0, 0)
            Me.tlpMainContent.Controls.Add(Me.pnlGridCard, 1, 0)

            ' ==============================================================
            ' 4. FORM ROOT PROPERTIES
            ' ==============================================================
            Me.AutoScaleDimensions = New SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.FromArgb(245, 247, 250)
            Me.ClientSize = New Size(1080, 660)
            Me.Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
            Me.MinimumSize = New Size(1000, 640)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Quản Lý Khu Vực Bàn Ăn - Hệ Thống Quản Lý Quán Ăn Hương Việt"

            Me.Controls.Add(Me.tlpMainContent)
            Me.Controls.Add(Me.tlpKpiRow)
            Me.Controls.Add(Me.pnlHeader)

            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tlpKpiRow.ResumeLayout(False)
            Me.pnlKpiTongKhuVuc.ResumeLayout(False)
            Me.pnlKpiTongKhuVuc.PerformLayout()
            Me.pnlKpiTongBan.ResumeLayout(False)
            Me.pnlKpiTongBan.PerformLayout()
            Me.pnlKpiTongCho.ResumeLayout(False)
            Me.pnlKpiTongCho.PerformLayout()
            Me.tlpMainContent.ResumeLayout(False)
            Me.pnlFormCard.ResumeLayout(False)
            Me.pnlFormCard.PerformLayout()
            Me.pnlThongKeBanBadge.ResumeLayout(False)
            Me.tlpButtons.ResumeLayout(False)
            Me.pnlGridCard.ResumeLayout(False)
            Me.pnlSearchBar.ResumeLayout(False)
            Me.pnlSearchBar.PerformLayout()
            CType(Me.dgvKhuVuc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

    End Class

End Namespace
