Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Menu

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMenu
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
        ' KHAI BÁO CÁC CONTROLS GIAO DIỆN (3 TẦNG + SPLIT-LAYOUT 40:60)
        ' ==============================================================
        Friend WithEvents pnlHeader As Panel
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents pnlHeaderActions As FlowLayoutPanel
        Friend WithEvents btnMoMonAn As Button
        Friend WithEvents btnDong As Button

        ' Tầng 2: KPI Row (4 cột)
        Friend WithEvents tlpKpiRow As TableLayoutPanel
        Friend WithEvents pnlKpiTongMenu As Panel
        Friend WithEvents lblKpiTongMenuTitle As Label
        Friend WithEvents lblKpiTongMenuVal As Label
        Friend WithEvents pnlKpiDangApDung As Panel
        Friend WithEvents lblKpiDangApDungTitle As Label
        Friend WithEvents lblKpiDangApDungVal As Label
        Friend WithEvents pnlKpiTamNgung As Panel
        Friend WithEvents lblKpiTamNgungTitle As Label
        Friend WithEvents lblKpiTamNgungVal As Label
        Friend WithEvents pnlKpiTongMonGan As Panel
        Friend WithEvents lblKpiTongMonGanTitle As Label
        Friend WithEvents lblKpiTongMonGanVal As Label

        ' Tầng 3: Split-Layout 40:60
        Friend WithEvents tlpMainContent As TableLayoutPanel

        ' Cột trái (40%) - Form Card
        Friend WithEvents pnlFormCard As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblModeBadge As Label
        Friend WithEvents lblThongBao As Label

        ' Hồ sơ Bảng Menu
        Friend WithEvents lblMaMenu As Label
        Friend WithEvents txtMaMenu As TextBox
        Friend WithEvents lblTenMenu As Label
        Friend WithEvents txtTenMenu As TextBox
        Friend WithEvents lblLoaiMenu As Label
        Friend WithEvents cboLoaiMenu As ComboBox
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents lblMoTa As Label
        Friend WithEvents txtMoTa As TextBox

        ' Cụm 4 nút CRUD Menu
        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnCapNhat As Button
        Friend WithEvents btnXoa As Button
        Friend WithEvents btnLamMoi As Button

        ' Khung Gán Món vào Menu
        Friend WithEvents grpGanMon As GroupBox
        Friend WithEvents lblChonMon As Label
        Friend WithEvents cboChonMon As ComboBox
        Friend WithEvents lblDonGiaMenu As Label
        Friend WithEvents nudDonGiaMenu As NumericUpDown
        Friend WithEvents lblThuTu As Label
        Friend WithEvents nudThuTu As NumericUpDown
        Friend WithEvents lblGhiChuMon As Label
        Friend WithEvents txtGhiChuMon As TextBox
        Friend WithEvents btnGanMon As Button

        ' Cột phải (60%) - TabControl & Grids Card
        Friend WithEvents pnlGridCard As Panel
        Friend WithEvents pnlSearchBar As Panel
        Friend WithEvents cboLocLoaiMenu As ComboBox
        Friend WithEvents cboLocTrangThai As ComboBox
        Friend WithEvents txtTimKiem As TextBox
        Friend WithEvents btnTaiLai As Button

        Friend WithEvents tabMenuData As TabControl
        Friend WithEvents tabDanhSachMenu As TabPage
        Friend WithEvents tabChiTietMon As TabPage

        ' Grid Menu
        Friend WithEvents dgvMenu As DataGridView
        Friend WithEvents colMaMenu As DataGridViewTextBoxColumn
        Friend WithEvents colTenMenu As DataGridViewTextBoxColumn
        Friend WithEvents colLoaiMenu As DataGridViewTextBoxColumn
        Friend WithEvents colMoTa As DataGridViewTextBoxColumn
        Friend WithEvents colSoLuongMon As DataGridViewTextBoxColumn
        Friend WithEvents colTrangThaiMenu As DataGridViewTextBoxColumn

        ' Grid Chi Tiết Món Trong Menu
        Friend WithEvents pnlSubHeaderMon As Panel
        Friend WithEvents lblChiTietMenuInfo As Label
        Friend WithEvents btnGoMon As Button
        Friend WithEvents dgvMenuMonAn As DataGridView
        Friend WithEvents colMMA_Ma As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_MaMonAn As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_TenMonAn As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_TenDanhMuc As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_DonGia As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_ThuTu As DataGridViewTextBoxColumn
        Friend WithEvents colMMA_GhiChu As DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dgvCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
            Dim dgvCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
            Dim dgvCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
            Dim dgvCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()

            pnlHeader = New Panel()
            lblTitle = New Label()
            lblSubtitle = New Label()
            pnlHeaderActions = New FlowLayoutPanel()
            btnMoMonAn = New Button()
            btnDong = New Button()

            tlpKpiRow = New TableLayoutPanel()
            pnlKpiTongMenu = New Panel()
            lblKpiTongMenuTitle = New Label()
            lblKpiTongMenuVal = New Label()
            pnlKpiDangApDung = New Panel()
            lblKpiDangApDungTitle = New Label()
            lblKpiDangApDungVal = New Label()
            pnlKpiTamNgung = New Panel()
            lblKpiTamNgungTitle = New Label()
            lblKpiTamNgungVal = New Label()
            pnlKpiTongMonGan = New Panel()
            lblKpiTongMonGanTitle = New Label()
            lblKpiTongMonGanVal = New Label()

            tlpMainContent = New TableLayoutPanel()

            ' Left Form Card
            pnlFormCard = New Panel()
            lblFormTitle = New Label()
            lblModeBadge = New Label()
            lblThongBao = New Label()
            lblMaMenu = New Label()
            txtMaMenu = New TextBox()
            lblTenMenu = New Label()
            txtTenMenu = New TextBox()
            lblLoaiMenu = New Label()
            cboLoaiMenu = New ComboBox()
            lblTrangThai = New Label()
            cboTrangThai = New ComboBox()
            lblMoTa = New Label()
            txtMoTa = New TextBox()

            tlpButtons = New TableLayoutPanel()
            btnThem = New Button()
            btnCapNhat = New Button()
            btnXoa = New Button()
            btnLamMoi = New Button()

            grpGanMon = New GroupBox()
            lblChonMon = New Label()
            cboChonMon = New ComboBox()
            lblDonGiaMenu = New Label()
            nudDonGiaMenu = New NumericUpDown()
            lblThuTu = New Label()
            nudThuTu = New NumericUpDown()
            lblGhiChuMon = New Label()
            txtGhiChuMon = New TextBox()
            btnGanMon = New Button()

            ' Right Grid Card
            pnlGridCard = New Panel()
            pnlSearchBar = New Panel()
            cboLocLoaiMenu = New ComboBox()
            cboLocTrangThai = New ComboBox()
            txtTimKiem = New TextBox()
            btnTaiLai = New Button()

            tabMenuData = New TabControl()
            tabDanhSachMenu = New TabPage()
            tabChiTietMon = New TabPage()

            dgvMenu = New DataGridView()
            colMaMenu = New DataGridViewTextBoxColumn()
            colTenMenu = New DataGridViewTextBoxColumn()
            colLoaiMenu = New DataGridViewTextBoxColumn()
            colMoTa = New DataGridViewTextBoxColumn()
            colSoLuongMon = New DataGridViewTextBoxColumn()
            colTrangThaiMenu = New DataGridViewTextBoxColumn()

            pnlSubHeaderMon = New Panel()
            lblChiTietMenuInfo = New Label()
            btnGoMon = New Button()
            dgvMenuMonAn = New DataGridView()
            colMMA_Ma = New DataGridViewTextBoxColumn()
            colMMA_MaMonAn = New DataGridViewTextBoxColumn()
            colMMA_TenMonAn = New DataGridViewTextBoxColumn()
            colMMA_TenDanhMuc = New DataGridViewTextBoxColumn()
            colMMA_DonGia = New DataGridViewTextBoxColumn()
            colMMA_ThuTu = New DataGridViewTextBoxColumn()
            colMMA_GhiChu = New DataGridViewTextBoxColumn()

            CType(nudDonGiaMenu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(nudThuTu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(dgvMenuMonAn, System.ComponentModel.ISupportInitialize).BeginInit()
            pnlHeader.SuspendLayout()
            pnlHeaderActions.SuspendLayout()
            tlpKpiRow.SuspendLayout()
            pnlKpiTongMenu.SuspendLayout()
            pnlKpiDangApDung.SuspendLayout()
            pnlKpiTamNgung.SuspendLayout()
            pnlKpiTongMonGan.SuspendLayout()
            tlpMainContent.SuspendLayout()
            pnlFormCard.SuspendLayout()
            tlpButtons.SuspendLayout()
            grpGanMon.SuspendLayout()
            pnlGridCard.SuspendLayout()
            pnlSearchBar.SuspendLayout()
            tabMenuData.SuspendLayout()
            tabDanhSachMenu.SuspendLayout()
            tabChiTietMon.SuspendLayout()
            pnlSubHeaderMon.SuspendLayout()
            SuspendLayout()

            ' ==============================================================
            ' 1. pnlHeader
            ' ==============================================================
            pnlHeader.BackColor = Color.FromArgb(26, 82, 118)
            pnlHeader.Controls.Add(lblTitle)
            pnlHeader.Controls.Add(lblSubtitle)
            pnlHeader.Controls.Add(pnlHeaderActions)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Height = 68
            pnlHeader.Padding = New Padding(16, 10, 16, 10)

            lblTitle.AutoSize = True
            lblTitle.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
            lblTitle.ForeColor = Color.White
            lblTitle.Location = New Point(16, 10)
            lblTitle.Text = "📋 QUẢN LÝ BẢNG THỰC ĐƠN KINH DOANH (MENU MASTER)"

            lblSubtitle.AutoSize = True
            lblSubtitle.Font = New Font("Segoe UI", 9.0F)
            lblSubtitle.ForeColor = Color.FromArgb(214, 234, 248)
            lblSubtitle.Location = New Point(18, 38)
            lblSubtitle.Text = "Danh mục chuẩn (7/9) • Thiết lập các gói Menu bán hàng, gán món ăn & định giá theo thực đơn"

            pnlHeaderActions.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            pnlHeaderActions.FlowDirection = FlowDirection.RightToLeft
            pnlHeaderActions.Location = New Point(880, 12)
            pnlHeaderActions.Size = New Size(280, 44)
            pnlHeaderActions.Controls.Add(btnDong)
            pnlHeaderActions.Controls.Add(btnMoMonAn)

            btnDong.BackColor = Color.FromArgb(192, 57, 43)
            btnDong.FlatStyle = FlatStyle.Flat
            btnDong.FlatAppearance.BorderSize = 0
            btnDong.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            btnDong.ForeColor = Color.White
            btnDong.Size = New Size(90, 38)
            btnDong.Text = "✕ Đóng"
            btnDong.Cursor = Cursors.Hand

            btnMoMonAn.BackColor = Color.FromArgb(41, 128, 185)
            btnMoMonAn.FlatStyle = FlatStyle.Flat
            btnMoMonAn.FlatAppearance.BorderSize = 0
            btnMoMonAn.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            btnMoMonAn.ForeColor = Color.White
            btnMoMonAn.Size = New Size(130, 38)
            btnMoMonAn.Text = "🍲 Kho Món Ăn"
            btnMoMonAn.Cursor = Cursors.Hand

            ' ==============================================================
            ' 2. tlpKpiRow (4 Cards)
            ' ==============================================================
            tlpKpiRow.ColumnCount = 4
            tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpKpiRow.Controls.Add(pnlKpiTongMenu, 0, 0)
            tlpKpiRow.Controls.Add(pnlKpiDangApDung, 1, 0)
            tlpKpiRow.Controls.Add(pnlKpiTamNgung, 2, 0)
            tlpKpiRow.Controls.Add(pnlKpiTongMonGan, 3, 0)
            tlpKpiRow.Dock = DockStyle.Top
            tlpKpiRow.Height = 78
            tlpKpiRow.Padding = New Padding(12, 6, 12, 6)

            ' KPI 1
            pnlKpiTongMenu.BackColor = Color.White
            pnlKpiTongMenu.BorderStyle = BorderStyle.FixedSingle
            pnlKpiTongMenu.Controls.Add(lblKpiTongMenuVal)
            pnlKpiTongMenu.Controls.Add(lblKpiTongMenuTitle)
            pnlKpiTongMenu.Dock = DockStyle.Fill
            pnlKpiTongMenu.Margin = New Padding(4)

            lblKpiTongMenuTitle.Dock = DockStyle.Top
            lblKpiTongMenuTitle.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            lblKpiTongMenuTitle.ForeColor = Color.FromArgb(100, 116, 139)
            lblKpiTongMenuTitle.Padding = New Padding(8, 6, 0, 0)
            lblKpiTongMenuTitle.Text = "TỔNG MENU KINH DOANH"

            lblKpiTongMenuVal.Dock = DockStyle.Fill
            lblKpiTongMenuVal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
            lblKpiTongMenuVal.ForeColor = Color.FromArgb(26, 82, 118)
            lblKpiTongMenuVal.Padding = New Padding(8, 0, 0, 6)
            lblKpiTongMenuVal.Text = "4 bảng menu"

            ' KPI 2
            pnlKpiDangApDung.BackColor = Color.White
            pnlKpiDangApDung.BorderStyle = BorderStyle.FixedSingle
            pnlKpiDangApDung.Controls.Add(lblKpiDangApDungVal)
            pnlKpiDangApDung.Controls.Add(lblKpiDangApDungTitle)
            pnlKpiDangApDung.Dock = DockStyle.Fill
            pnlKpiDangApDung.Margin = New Padding(4)

            lblKpiDangApDungTitle.Dock = DockStyle.Top
            lblKpiDangApDungTitle.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            lblKpiDangApDungTitle.ForeColor = Color.FromArgb(100, 116, 139)
            lblKpiDangApDungTitle.Padding = New Padding(8, 6, 0, 0)
            lblKpiDangApDungTitle.Text = "ĐANG ÁP DỤNG"

            lblKpiDangApDungVal.Dock = DockStyle.Fill
            lblKpiDangApDungVal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
            lblKpiDangApDungVal.ForeColor = Color.FromArgb(39, 174, 96)
            lblKpiDangApDungVal.Padding = New Padding(8, 0, 0, 6)
            lblKpiDangApDungVal.Text = "3 bảng menu"

            ' KPI 3
            pnlKpiTamNgung.BackColor = Color.White
            pnlKpiTamNgung.BorderStyle = BorderStyle.FixedSingle
            pnlKpiTamNgung.Controls.Add(lblKpiTamNgungVal)
            pnlKpiTamNgung.Controls.Add(lblKpiTamNgungTitle)
            pnlKpiTamNgung.Dock = DockStyle.Fill
            pnlKpiTamNgung.Margin = New Padding(4)

            lblKpiTamNgungTitle.Dock = DockStyle.Top
            lblKpiTamNgungTitle.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            lblKpiTamNgungTitle.ForeColor = Color.FromArgb(100, 116, 139)
            lblKpiTamNgungTitle.Padding = New Padding(8, 6, 0, 0)
            lblKpiTamNgungTitle.Text = "TẠM NGƯNG / DỰ THẢO"

            lblKpiTamNgungVal.Dock = DockStyle.Fill
            lblKpiTamNgungVal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
            lblKpiTamNgungVal.ForeColor = Color.FromArgb(230, 126, 34)
            lblKpiTamNgungVal.Padding = New Padding(8, 0, 0, 6)
            lblKpiTamNgungVal.Text = "1 bảng menu"

            ' KPI 4
            pnlKpiTongMonGan.BackColor = Color.White
            pnlKpiTongMonGan.BorderStyle = BorderStyle.FixedSingle
            pnlKpiTongMonGan.Controls.Add(lblKpiTongMonGanVal)
            pnlKpiTongMonGan.Controls.Add(lblKpiTongMonGanTitle)
            pnlKpiTongMonGan.Dock = DockStyle.Fill
            pnlKpiTongMonGan.Margin = New Padding(4)

            lblKpiTongMonGanTitle.Dock = DockStyle.Top
            lblKpiTongMonGanTitle.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            lblKpiTongMonGanTitle.ForeColor = Color.FromArgb(100, 116, 139)
            lblKpiTongMonGanTitle.Padding = New Padding(8, 6, 0, 0)
            lblKpiTongMonGanTitle.Text = "TỔNG MÓN ĐÃ GÁN"

            lblKpiTongMonGanVal.Dock = DockStyle.Fill
            lblKpiTongMonGanVal.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
            lblKpiTongMonGanVal.ForeColor = Color.FromArgb(142, 68, 173)
            lblKpiTongMonGanVal.Padding = New Padding(8, 0, 0, 6)
            lblKpiTongMonGanVal.Text = "14 lượt món"

            ' ==============================================================
            ' 3. tlpMainContent (Split 40% : 60%)
            ' ==============================================================
            tlpMainContent.ColumnCount = 2
            tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
            tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
            tlpMainContent.Controls.Add(pnlFormCard, 0, 0)
            tlpMainContent.Controls.Add(pnlGridCard, 1, 0)
            tlpMainContent.Dock = DockStyle.Fill
            tlpMainContent.Padding = New Padding(12, 4, 12, 10)

            ' --------------------------------------------------------------
            ' Left Column: pnlFormCard
            ' --------------------------------------------------------------
            pnlFormCard.BackColor = Color.White
            pnlFormCard.BorderStyle = BorderStyle.FixedSingle
            pnlFormCard.Dock = DockStyle.Fill
            pnlFormCard.Margin = New Padding(4)
            pnlFormCard.AutoScroll = True
            pnlFormCard.Padding = New Padding(14)

            pnlFormCard.Controls.Add(lblFormTitle)
            pnlFormCard.Controls.Add(lblModeBadge)
            pnlFormCard.Controls.Add(lblThongBao)
            pnlFormCard.Controls.Add(lblMaMenu)
            pnlFormCard.Controls.Add(txtMaMenu)
            pnlFormCard.Controls.Add(lblTenMenu)
            pnlFormCard.Controls.Add(txtTenMenu)
            pnlFormCard.Controls.Add(lblLoaiMenu)
            pnlFormCard.Controls.Add(cboLoaiMenu)
            pnlFormCard.Controls.Add(lblTrangThai)
            pnlFormCard.Controls.Add(cboTrangThai)
            pnlFormCard.Controls.Add(lblMoTa)
            pnlFormCard.Controls.Add(txtMoTa)
            pnlFormCard.Controls.Add(tlpButtons)
            pnlFormCard.Controls.Add(grpGanMon)

            ' Form Header
            lblFormTitle.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            lblFormTitle.Location = New Point(14, 12)
            lblFormTitle.Size = New Size(240, 24)
            lblFormTitle.Text = "THÔNG TIN BẢNG MENU"

            lblModeBadge.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            lblModeBadge.BackColor = Color.FromArgb(234, 250, 234)
            lblModeBadge.BorderStyle = BorderStyle.FixedSingle
            lblModeBadge.Font = New Font("Segoe UI", 8.0F, FontStyle.Bold)
            lblModeBadge.ForeColor = Color.FromArgb(39, 174, 96)
            lblModeBadge.Location = New Point(280, 12)
            lblModeBadge.Size = New Size(150, 24)
            lblModeBadge.Text = "Chế độ: Đang chọn"
            lblModeBadge.TextAlign = ContentAlignment.MiddleCenter

            lblThongBao.Font = New Font("Segoe UI", 8.5F, FontStyle.Italic)
            lblThongBao.ForeColor = Color.FromArgb(192, 57, 43)
            lblThongBao.Location = New Point(14, 38)
            lblThongBao.Size = New Size(415, 20)
            lblThongBao.Text = ""

            ' Fields
            lblMaMenu.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            lblMaMenu.Location = New Point(14, 62)
            lblMaMenu.Size = New Size(110, 20)
            lblMaMenu.Text = "Mã Menu:"

            txtMaMenu.BackColor = Color.FromArgb(245, 245, 245)
            txtMaMenu.Location = New Point(130, 59)
            txtMaMenu.ReadOnly = True
            txtMaMenu.Size = New Size(295, 25)

            lblTenMenu.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            lblTenMenu.Location = New Point(14, 95)
            lblTenMenu.Size = New Size(110, 20)
            lblTenMenu.Text = "Tên Menu (*):"

            txtTenMenu.Location = New Point(130, 92)
            txtTenMenu.Size = New Size(295, 25)

            lblLoaiMenu.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            lblLoaiMenu.Location = New Point(14, 128)
            lblLoaiMenu.Size = New Size(110, 20)
            lblLoaiMenu.Text = "Loại Thực Đơn:"

            cboLoaiMenu.DropDownStyle = ComboBoxStyle.DropDownList
            cboLoaiMenu.Location = New Point(130, 125)
            cboLoaiMenu.Size = New Size(295, 25)

            lblTrangThai.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            lblTrangThai.Location = New Point(14, 161)
            lblTrangThai.Size = New Size(110, 20)
            lblTrangThai.Text = "Trạng Thái:"

            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            cboTrangThai.Location = New Point(130, 158)
            cboTrangThai.Size = New Size(295, 25)

            lblMoTa.Font = New Font("Segoe UI", 9.0F)
            lblMoTa.Location = New Point(14, 194)
            lblMoTa.Size = New Size(110, 20)
            lblMoTa.Text = "Mô Tả / Ghi Chú:"

            txtMoTa.Location = New Point(130, 191)
            txtMoTa.Multiline = True
            txtMoTa.Size = New Size(295, 48)

            ' CRUD Buttons
            tlpButtons.ColumnCount = 4
            tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            tlpButtons.Controls.Add(btnThem, 0, 0)
            tlpButtons.Controls.Add(btnCapNhat, 1, 0)
            tlpButtons.Controls.Add(btnXoa, 2, 0)
            tlpButtons.Controls.Add(btnLamMoi, 3, 0)
            tlpButtons.Location = New Point(14, 248)
            tlpButtons.Size = New Size(412, 38)

            btnThem.BackColor = Color.FromArgb(39, 174, 96)
            btnThem.Dock = DockStyle.Fill
            btnThem.FlatStyle = FlatStyle.Flat
            btnThem.FlatAppearance.BorderSize = 0
            btnThem.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnThem.ForeColor = Color.White
            btnThem.Text = "➕ Thêm"
            btnThem.Cursor = Cursors.Hand

            btnCapNhat.BackColor = Color.FromArgb(41, 128, 185)
            btnCapNhat.Dock = DockStyle.Fill
            btnCapNhat.FlatStyle = FlatStyle.Flat
            btnCapNhat.FlatAppearance.BorderSize = 0
            btnCapNhat.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnCapNhat.ForeColor = Color.White
            btnCapNhat.Text = "💾 Sửa"
            btnCapNhat.Cursor = Cursors.Hand

            btnXoa.BackColor = Color.FromArgb(192, 57, 43)
            btnXoa.Dock = DockStyle.Fill
            btnXoa.FlatStyle = FlatStyle.Flat
            btnXoa.FlatAppearance.BorderSize = 0
            btnXoa.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnXoa.ForeColor = Color.White
            btnXoa.Text = "🗑️ Xóa"
            btnXoa.Cursor = Cursors.Hand

            btnLamMoi.BackColor = Color.FromArgb(127, 140, 141)
            btnLamMoi.Dock = DockStyle.Fill
            btnLamMoi.FlatStyle = FlatStyle.Flat
            btnLamMoi.FlatAppearance.BorderSize = 0
            btnLamMoi.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnLamMoi.ForeColor = Color.White
            btnLamMoi.Text = "🔄 Mới"
            btnLamMoi.Cursor = Cursors.Hand

            ' Khung Gán Món (grpGanMon)
            grpGanMon.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            grpGanMon.ForeColor = Color.FromArgb(26, 82, 118)
            grpGanMon.Location = New Point(14, 296)
            grpGanMon.Size = New Size(412, 215)
            grpGanMon.Text = "📌 GÁN MÓN VÀO BẢNG MENU HIỆN TẠI"

            grpGanMon.Controls.Add(lblChonMon)
            grpGanMon.Controls.Add(cboChonMon)
            grpGanMon.Controls.Add(lblDonGiaMenu)
            grpGanMon.Controls.Add(nudDonGiaMenu)
            grpGanMon.Controls.Add(lblThuTu)
            grpGanMon.Controls.Add(nudThuTu)
            grpGanMon.Controls.Add(lblGhiChuMon)
            grpGanMon.Controls.Add(txtGhiChuMon)
            grpGanMon.Controls.Add(btnGanMon)

            lblChonMon.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
            lblChonMon.ForeColor = Color.Black
            lblChonMon.Location = New Point(12, 28)
            lblChonMon.Size = New Size(100, 20)
            lblChonMon.Text = "Chọn Món Ăn:"

            cboChonMon.DropDownStyle = ComboBoxStyle.DropDownList
            cboChonMon.Font = New Font("Segoe UI", 9.0F)
            cboChonMon.Location = New Point(116, 25)
            cboChonMon.Size = New Size(282, 25)

            lblDonGiaMenu.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
            lblDonGiaMenu.ForeColor = Color.Black
            lblDonGiaMenu.Location = New Point(12, 61)
            lblDonGiaMenu.Size = New Size(100, 20)
            lblDonGiaMenu.Text = "Giá Theo Menu:"

            nudDonGiaMenu.Font = New Font("Segoe UI", 9.0F)
            nudDonGiaMenu.Location = New Point(116, 58)
            nudDonGiaMenu.Maximum = New Decimal(New Integer() {50000000, 0, 0, 0})
            nudDonGiaMenu.ThousandsSeparator = True
            nudDonGiaMenu.Size = New Size(130, 25)

            lblThuTu.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
            lblThuTu.ForeColor = Color.Black
            lblThuTu.Location = New Point(255, 61)
            lblThuTu.Size = New Size(60, 20)
            lblThuTu.Text = "Thứ Tự:"

            nudThuTu.Font = New Font("Segoe UI", 9.0F)
            nudThuTu.Location = New Point(318, 58)
            nudThuTu.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            nudThuTu.Value = New Decimal(New Integer() {1, 0, 0, 0})
            nudThuTu.Size = New Size(80, 25)

            lblGhiChuMon.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
            lblGhiChuMon.ForeColor = Color.Black
            lblGhiChuMon.Location = New Point(12, 94)
            lblGhiChuMon.Size = New Size(100, 20)
            lblGhiChuMon.Text = "Ghi Chú Món:"

            txtGhiChuMon.Font = New Font("Segoe UI", 9.0F)
            txtGhiChuMon.Location = New Point(116, 91)
            txtGhiChuMon.Size = New Size(282, 25)

            btnGanMon.BackColor = Color.FromArgb(52, 152, 219)
            btnGanMon.FlatStyle = FlatStyle.Flat
            btnGanMon.FlatAppearance.BorderSize = 0
            btnGanMon.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            btnGanMon.ForeColor = Color.White
            btnGanMon.Location = New Point(116, 126)
            btnGanMon.Size = New Size(282, 36)
            btnGanMon.Text = "➕ Gán Món Vào Menu Này"
            btnGanMon.Cursor = Cursors.Hand

            ' --------------------------------------------------------------
            ' Right Column: pnlGridCard
            ' --------------------------------------------------------------
            pnlGridCard.BackColor = Color.White
            pnlGridCard.BorderStyle = BorderStyle.FixedSingle
            pnlGridCard.Dock = DockStyle.Fill
            pnlGridCard.Margin = New Padding(4)
            pnlGridCard.Padding = New Padding(10)
            pnlGridCard.Controls.Add(tabMenuData)
            pnlGridCard.Controls.Add(pnlSearchBar)

            ' Search Bar
            pnlSearchBar.Dock = DockStyle.Top
            pnlSearchBar.Height = 44
            pnlSearchBar.Padding = New Padding(0, 4, 0, 6)
            pnlSearchBar.Controls.Add(cboLocLoaiMenu)
            pnlSearchBar.Controls.Add(cboLocTrangThai)
            pnlSearchBar.Controls.Add(txtTimKiem)
            pnlSearchBar.Controls.Add(btnTaiLai)

            cboLocLoaiMenu.DropDownStyle = ComboBoxStyle.DropDownList
            cboLocLoaiMenu.Location = New Point(0, 6)
            cboLocLoaiMenu.Size = New Size(160, 25)

            cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            cboLocTrangThai.Location = New Point(168, 6)
            cboLocTrangThai.Size = New Size(150, 25)

            txtTimKiem.Location = New Point(326, 6)
            txtTimKiem.Size = New Size(230, 25)

            btnTaiLai.BackColor = Color.FromArgb(52, 73, 94)
            btnTaiLai.FlatStyle = FlatStyle.Flat
            btnTaiLai.FlatAppearance.BorderSize = 0
            btnTaiLai.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnTaiLai.ForeColor = Color.White
            btnTaiLai.Location = New Point(564, 5)
            btnTaiLai.Size = New Size(90, 27)
            btnTaiLai.Text = "🔄 Tải lại"
            btnTaiLai.Cursor = Cursors.Hand

            ' TabControl
            tabMenuData.Dock = DockStyle.Fill
            tabMenuData.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            tabMenuData.Controls.Add(tabDanhSachMenu)
            tabMenuData.Controls.Add(tabChiTietMon)

            ' Tab 1: Danh Sách Menu
            tabDanhSachMenu.Controls.Add(dgvMenu)
            tabDanhSachMenu.Location = New Point(4, 26)
            tabDanhSachMenu.Padding = New Padding(4)
            tabDanhSachMenu.Size = New Size(660, 430)
            tabDanhSachMenu.Text = "📋 Danh Sách Bảng Menu"
            tabDanhSachMenu.UseVisualStyleBackColor = True

            dgvMenu.AllowUserToAddRows = False
            dgvMenu.AllowUserToDeleteRows = False
            dgvMenu.AllowUserToResizeRows = False
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvMenu.BackgroundColor = Color.White
            dgvMenu.BorderStyle = BorderStyle.None
            dgvMenu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            dgvCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyle1.BackColor = Color.FromArgb(234, 237, 242)
            dgvCellStyle1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            dgvCellStyle1.ForeColor = Color.FromArgb(44, 62, 80)
            dgvCellStyle1.SelectionBackColor = Color.FromArgb(234, 237, 242)
            dgvCellStyle1.SelectionForeColor = Color.FromArgb(44, 62, 80)
            dgvMenu.ColumnHeadersDefaultCellStyle = dgvCellStyle1
            dgvMenu.ColumnHeadersHeight = 32
            dgvMenu.Columns.AddRange(New DataGridViewColumn() {colMaMenu, colTenMenu, colLoaiMenu, colMoTa, colSoLuongMon, colTrangThaiMenu})
            dgvCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyle2.BackColor = Color.White
            dgvCellStyle2.Font = New Font("Segoe UI", 9.0F)
            dgvCellStyle2.ForeColor = Color.Black
            dgvCellStyle2.SelectionBackColor = Color.FromArgb(214, 234, 248)
            dgvCellStyle2.SelectionForeColor = Color.Black
            dgvMenu.DefaultCellStyle = dgvCellStyle2
            dgvMenu.Dock = DockStyle.Fill
            dgvMenu.EnableHeadersVisualStyles = False
            dgvMenu.MultiSelect = False
            dgvMenu.ReadOnly = True
            dgvMenu.RowHeadersVisible = False
            dgvMenu.RowTemplate.Height = 28
            dgvMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            colMaMenu.DataPropertyName = "MaMenu"
            colMaMenu.FillWeight = 40.0F
            colMaMenu.HeaderText = "Mã"
            colMaMenu.Name = "colMaMenu"
            colMaMenu.ReadOnly = True

            colTenMenu.DataPropertyName = "TenMenu"
            colTenMenu.FillWeight = 110.0F
            colTenMenu.HeaderText = "Tên Bảng Thực Đơn"
            colTenMenu.Name = "colTenMenu"
            colTenMenu.ReadOnly = True

            colLoaiMenu.DataPropertyName = "LoaiMenu"
            colLoaiMenu.FillWeight = 60.0F
            colLoaiMenu.HeaderText = "Loại Thực Đơn"
            colLoaiMenu.Name = "colLoaiMenu"
            colLoaiMenu.ReadOnly = True

            colMoTa.DataPropertyName = "MoTa"
            colMoTa.FillWeight = 90.0F
            colMoTa.HeaderText = "Mô Tả"
            colMoTa.Name = "colMoTa"
            colMoTa.ReadOnly = True

            colSoLuongMon.DataPropertyName = "SoLuongMon"
            colSoLuongMon.FillWeight = 50.0F
            colSoLuongMon.HeaderText = "SL Món"
            colSoLuongMon.Name = "colSoLuongMon"
            colSoLuongMon.ReadOnly = True

            colTrangThaiMenu.DataPropertyName = "TrangThai"
            colTrangThaiMenu.FillWeight = 65.0F
            colTrangThaiMenu.HeaderText = "Trạng Thái"
            colTrangThaiMenu.Name = "colTrangThaiMenu"
            colTrangThaiMenu.ReadOnly = True

            ' Tab 2: Chi Tiết Món Trong Menu
            tabChiTietMon.Controls.Add(dgvMenuMonAn)
            tabChiTietMon.Controls.Add(pnlSubHeaderMon)
            tabChiTietMon.Location = New Point(4, 26)
            tabChiTietMon.Padding = New Padding(4)
            tabChiTietMon.Size = New Size(660, 430)
            tabChiTietMon.Text = "🍲 Chi Tiết Món Trong Menu"
            tabChiTietMon.UseVisualStyleBackColor = True

            pnlSubHeaderMon.Dock = DockStyle.Top
            pnlSubHeaderMon.Height = 38
            pnlSubHeaderMon.Controls.Add(lblChiTietMenuInfo)
            pnlSubHeaderMon.Controls.Add(btnGoMon)

            lblChiTietMenuInfo.AutoSize = True
            lblChiTietMenuInfo.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblChiTietMenuInfo.ForeColor = Color.FromArgb(26, 82, 118)
            lblChiTietMenuInfo.Location = New Point(4, 10)
            lblChiTietMenuInfo.Text = "Món trong thực đơn: (Chưa chọn)"

            btnGoMon.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            btnGoMon.BackColor = Color.FromArgb(231, 76, 60)
            btnGoMon.FlatStyle = FlatStyle.Flat
            btnGoMon.FlatAppearance.BorderSize = 0
            btnGoMon.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            btnGoMon.ForeColor = Color.White
            btnGoMon.Location = New Point(530, 4)
            btnGoMon.Size = New Size(125, 30)
            btnGoMon.Text = "🗑️ Gỡ Khỏi Menu"
            btnGoMon.Cursor = Cursors.Hand

            dgvMenuMonAn.AllowUserToAddRows = False
            dgvMenuMonAn.AllowUserToDeleteRows = False
            dgvMenuMonAn.AllowUserToResizeRows = False
            dgvMenuMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvMenuMonAn.BackgroundColor = Color.White
            dgvMenuMonAn.BorderStyle = BorderStyle.None
            dgvMenuMonAn.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            dgvCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyle3.BackColor = Color.FromArgb(234, 237, 242)
            dgvCellStyle3.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            dgvCellStyle3.ForeColor = Color.FromArgb(44, 62, 80)
            dgvCellStyle3.SelectionBackColor = Color.FromArgb(234, 237, 242)
            dgvCellStyle3.SelectionForeColor = Color.FromArgb(44, 62, 80)
            dgvMenuMonAn.ColumnHeadersDefaultCellStyle = dgvCellStyle3
            dgvMenuMonAn.ColumnHeadersHeight = 32
            dgvMenuMonAn.Columns.AddRange(New DataGridViewColumn() {colMMA_Ma, colMMA_MaMonAn, colMMA_TenMonAn, colMMA_TenDanhMuc, colMMA_DonGia, colMMA_ThuTu, colMMA_GhiChu})
            dgvCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyle4.BackColor = Color.White
            dgvCellStyle4.Font = New Font("Segoe UI", 9.0F)
            dgvCellStyle4.ForeColor = Color.Black
            dgvCellStyle4.SelectionBackColor = Color.FromArgb(214, 234, 248)
            dgvCellStyle4.SelectionForeColor = Color.Black
            dgvMenuMonAn.DefaultCellStyle = dgvCellStyle4
            dgvMenuMonAn.Dock = DockStyle.Fill
            dgvMenuMonAn.EnableHeadersVisualStyles = False
            dgvMenuMonAn.MultiSelect = False
            dgvMenuMonAn.ReadOnly = True
            dgvMenuMonAn.RowHeadersVisible = False
            dgvMenuMonAn.RowTemplate.Height = 28
            dgvMenuMonAn.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            colMMA_Ma.DataPropertyName = "MaMMA"
            colMMA_Ma.FillWeight = 35.0F
            colMMA_Ma.HeaderText = "ID"
            colMMA_Ma.Name = "colMMA_Ma"
            colMMA_Ma.ReadOnly = True

            colMMA_MaMonAn.DataPropertyName = "MaMonAn"
            colMMA_MaMonAn.FillWeight = 35.0F
            colMMA_MaMonAn.HeaderText = "Mã Món"
            colMMA_MaMonAn.Name = "colMMA_MaMonAn"
            colMMA_MaMonAn.ReadOnly = True

            colMMA_TenMonAn.DataPropertyName = "TenMonAn"
            colMMA_TenMonAn.FillWeight = 110.0F
            colMMA_TenMonAn.HeaderText = "Tên Món Ăn"
            colMMA_TenMonAn.Name = "colMMA_TenMonAn"
            colMMA_TenMonAn.ReadOnly = True

            colMMA_TenDanhMuc.DataPropertyName = "TenDanhMuc"
            colMMA_TenDanhMuc.FillWeight = 75.0F
            colMMA_TenDanhMuc.HeaderText = "Danh Mục"
            colMMA_TenDanhMuc.Name = "colMMA_TenDanhMuc"
            colMMA_TenDanhMuc.ReadOnly = True

            colMMA_DonGia.DataPropertyName = "DonGiaHienThi"
            colMMA_DonGia.FillWeight = 65.0F
            colMMA_DonGia.HeaderText = "Giá Trong Menu"
            colMMA_DonGia.Name = "colMMA_DonGia"
            colMMA_DonGia.ReadOnly = True

            colMMA_ThuTu.DataPropertyName = "ThuTuHienThi"
            colMMA_ThuTu.FillWeight = 40.0F
            colMMA_ThuTu.HeaderText = "Thứ Tự"
            colMMA_ThuTu.Name = "colMMA_ThuTu"
            colMMA_ThuTu.ReadOnly = True

            colMMA_GhiChu.DataPropertyName = "GhiChu"
            colMMA_GhiChu.FillWeight = 70.0F
            colMMA_GhiChu.HeaderText = "Ghi Chú"
            colMMA_GhiChu.Name = "colMMA_GhiChu"
            colMMA_GhiChu.ReadOnly = True

            ' ==============================================================
            ' Form Settings
            ' ==============================================================
            AutoScaleDimensions = New SizeF(7.0F, 17.0F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.FromArgb(244, 246, 249)
            ClientSize = New Size(1180, 700)
            MinimumSize = New Size(1080, 660)
            StartPosition = FormStartPosition.CenterParent
            Text = "Quản lý Bảng Thực Đơn Kinh Doanh (Menu Master)"
            Font = New Font("Segoe UI", 9.5F)

            Controls.Add(tlpMainContent)
            Controls.Add(tlpKpiRow)
            Controls.Add(pnlHeader)

            CType(nudDonGiaMenu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(nudThuTu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
            CType(dgvMenuMonAn, System.ComponentModel.ISupportInitialize).EndInit()
            pnlHeader.ResumeLayout(False)
            pnlHeader.PerformLayout()
            pnlHeaderActions.ResumeLayout(False)
            tlpKpiRow.ResumeLayout(False)
            pnlKpiTongMenu.ResumeLayout(False)
            pnlKpiDangApDung.ResumeLayout(False)
            pnlKpiTamNgung.ResumeLayout(False)
            pnlKpiTongMonGan.ResumeLayout(False)
            tlpMainContent.ResumeLayout(False)
            pnlFormCard.ResumeLayout(False)
            pnlFormCard.PerformLayout()
            tlpButtons.ResumeLayout(False)
            grpGanMon.ResumeLayout(False)
            grpGanMon.PerformLayout()
            pnlGridCard.ResumeLayout(False)
            pnlSearchBar.ResumeLayout(False)
            pnlSearchBar.PerformLayout()
            tabMenuData.ResumeLayout(False)
            tabDanhSachMenu.ResumeLayout(False)
            tabChiTietMon.ResumeLayout(False)
            pnlSubHeaderMon.ResumeLayout(False)
            pnlSubHeaderMon.PerformLayout()
            ResumeLayout(False)
        End Sub

    End Class

End Namespace
