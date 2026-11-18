Namespace Features.Menu
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmDanhMuc
        Inherits System.Windows.Forms.Form

        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        Private components As System.ComponentModel.IContainer

        ' Header Controls
        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblSubtitle As System.Windows.Forms.Label
        Friend WithEvents pnlHeaderActions As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents btnMoMonAn As System.Windows.Forms.Button
        Friend WithEvents btnDong As System.Windows.Forms.Button

        ' KPI Row Controls (3 columns)
        Friend WithEvents tlpKpiRow As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pnlKpiTongDM As System.Windows.Forms.Panel
        Friend WithEvents lblKpiTongDMLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiTongDMValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiTongMon As System.Windows.Forms.Panel
        Friend WithEvents lblKpiTongMonLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiTongMonValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiDMTrong As System.Windows.Forms.Panel
        Friend WithEvents lblKpiDMTrongLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiDMTrongValue As System.Windows.Forms.Label

        ' Main Split Layout (38% Form : 62% Grid)
        Friend WithEvents tlpMainContent As System.Windows.Forms.TableLayoutPanel

        ' Left Column: Form Card
        Friend WithEvents pnlFormCard As System.Windows.Forms.Panel
        Friend WithEvents lblFormTitle As System.Windows.Forms.Label
        Friend WithEvents lblModeBadge As System.Windows.Forms.Label
        Friend WithEvents lblThongBao As System.Windows.Forms.Label
        Friend WithEvents lblMaDM As System.Windows.Forms.Label
        Friend WithEvents txtMaDM As System.Windows.Forms.TextBox
        Friend WithEvents lblTenDM As System.Windows.Forms.Label
        Friend WithEvents txtTenDM As System.Windows.Forms.TextBox
        Friend WithEvents lblMoTa As System.Windows.Forms.Label
        Friend WithEvents txtMoTa As System.Windows.Forms.TextBox
        Friend WithEvents pnlDishCountBadge As System.Windows.Forms.Panel
        Friend WithEvents lblThongKeMon As System.Windows.Forms.Label
        Friend WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnThem As System.Windows.Forms.Button
        Friend WithEvents btnCapNhat As System.Windows.Forms.Button
        Friend WithEvents btnXoa As System.Windows.Forms.Button
        Friend WithEvents btnLamMoi As System.Windows.Forms.Button

        ' Right Column: Grid Card
        Friend WithEvents pnlGridCard As System.Windows.Forms.Panel
        Friend WithEvents lblGridTitle As System.Windows.Forms.Label
        Friend WithEvents pnlSearchBar As System.Windows.Forms.Panel
        Friend WithEvents txtTimKiem As System.Windows.Forms.TextBox
        Friend WithEvents btnTimKiem As System.Windows.Forms.Button
        Friend WithEvents btnTaiLai As System.Windows.Forms.Button
        Friend WithEvents dgvDanhMuc As System.Windows.Forms.DataGridView
        Friend WithEvents colMaDM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTenDM As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMoTa As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSoLuongMon As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            pnlHeader = New System.Windows.Forms.Panel()
            lblTitle = New System.Windows.Forms.Label()
            lblSubtitle = New System.Windows.Forms.Label()
            pnlHeaderActions = New System.Windows.Forms.FlowLayoutPanel()
            btnMoMonAn = New System.Windows.Forms.Button()
            btnDong = New System.Windows.Forms.Button()

            tlpKpiRow = New System.Windows.Forms.TableLayoutPanel()
            pnlKpiTongDM = New System.Windows.Forms.Panel()
            lblKpiTongDMLabel = New System.Windows.Forms.Label()
            lblKpiTongDMValue = New System.Windows.Forms.Label()
            pnlKpiTongMon = New System.Windows.Forms.Panel()
            lblKpiTongMonLabel = New System.Windows.Forms.Label()
            lblKpiTongMonValue = New System.Windows.Forms.Label()
            pnlKpiDMTrong = New System.Windows.Forms.Panel()
            lblKpiDMTrongLabel = New System.Windows.Forms.Label()
            lblKpiDMTrongValue = New System.Windows.Forms.Label()

            tlpMainContent = New System.Windows.Forms.TableLayoutPanel()
            pnlFormCard = New System.Windows.Forms.Panel()
            lblFormTitle = New System.Windows.Forms.Label()
            lblModeBadge = New System.Windows.Forms.Label()
            lblThongBao = New System.Windows.Forms.Label()
            lblMaDM = New System.Windows.Forms.Label()
            txtMaDM = New System.Windows.Forms.TextBox()
            lblTenDM = New System.Windows.Forms.Label()
            txtTenDM = New System.Windows.Forms.TextBox()
            lblMoTa = New System.Windows.Forms.Label()
            txtMoTa = New System.Windows.Forms.TextBox()
            pnlDishCountBadge = New System.Windows.Forms.Panel()
            lblThongKeMon = New System.Windows.Forms.Label()
            tlpButtons = New System.Windows.Forms.TableLayoutPanel()
            btnThem = New System.Windows.Forms.Button()
            btnCapNhat = New System.Windows.Forms.Button()
            btnXoa = New System.Windows.Forms.Button()
            btnLamMoi = New System.Windows.Forms.Button()

            pnlGridCard = New System.Windows.Forms.Panel()
            lblGridTitle = New System.Windows.Forms.Label()
            pnlSearchBar = New System.Windows.Forms.Panel()
            txtTimKiem = New System.Windows.Forms.TextBox()
            btnTimKiem = New System.Windows.Forms.Button()
            btnTaiLai = New System.Windows.Forms.Button()
            dgvDanhMuc = New System.Windows.Forms.DataGridView()
            colMaDM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colTenDM = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colMoTa = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colSoLuongMon = New System.Windows.Forms.DataGridViewTextBoxColumn()

            pnlHeader.SuspendLayout()
            pnlHeaderActions.SuspendLayout()
            tlpKpiRow.SuspendLayout()
            pnlKpiTongDM.SuspendLayout()
            pnlKpiTongMon.SuspendLayout()
            pnlKpiDMTrong.SuspendLayout()
            tlpMainContent.SuspendLayout()
            pnlFormCard.SuspendLayout()
            pnlDishCountBadge.SuspendLayout()
            tlpButtons.SuspendLayout()
            pnlGridCard.SuspendLayout()
            pnlSearchBar.SuspendLayout()
            CType(dgvDanhMuc, System.ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()

            ' ==========================================
            ' 1. pnlHeader (Dock = Top, Height = 68)
            ' ==========================================
            pnlHeader.BackColor = System.Drawing.Color.White
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            pnlHeader.Location = New System.Drawing.Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Padding = New System.Windows.Forms.Padding(24, 10, 24, 10)
            pnlHeader.Size = New System.Drawing.Size(1060, 68)
            pnlHeader.TabIndex = 0

            lblTitle.AutoSize = True
            lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0F, System.Drawing.FontStyle.Bold)
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblTitle.Location = New System.Drawing.Point(24, 10)
            lblTitle.Name = "lblTitle"
            lblTitle.Size = New System.Drawing.Size(370, 25)
            lblTitle.Text = "📂 QUẢN LÝ DANH MỤC THỰC ĐƠN"

            lblSubtitle.AutoSize = True
            lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblSubtitle.Location = New System.Drawing.Point(26, 38)
            lblSubtitle.Name = "lblSubtitle"
            lblSubtitle.Size = New System.Drawing.Size(420, 15)
            lblSubtitle.Text = "Tổ chức các nhóm phân loại món ăn & thức uống của quán (Cấp Cha của Món ăn)"

            pnlHeaderActions.Dock = System.Windows.Forms.DockStyle.Right
            pnlHeaderActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
            pnlHeaderActions.Location = New System.Drawing.Point(680, 10)
            pnlHeaderActions.Name = "pnlHeaderActions"
            pnlHeaderActions.Size = New System.Drawing.Size(356, 48)
            pnlHeaderActions.WrapContents = False

            btnDong.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            btnDong.Cursor = System.Windows.Forms.Cursors.Hand
            btnDong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
            btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnDong.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnDong.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            btnDong.Margin = New System.Windows.Forms.Padding(8, 6, 0, 6)
            btnDong.Name = "btnDong"
            btnDong.Size = New System.Drawing.Size(105, 36)
            btnDong.Text = "✖ Đóng"
            btnDong.UseVisualStyleBackColor = False

            btnMoMonAn.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
            btnMoMonAn.Cursor = System.Windows.Forms.Cursors.Hand
            btnMoMonAn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(147, 197, 253)
            btnMoMonAn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnMoMonAn.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnMoMonAn.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
            btnMoMonAn.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
            btnMoMonAn.Name = "btnMoMonAn"
            btnMoMonAn.Size = New System.Drawing.Size(210, 36)
            btnMoMonAn.Text = "🍜 Mở Quản lý Món ăn ➔"
            btnMoMonAn.UseVisualStyleBackColor = False

            pnlHeaderActions.Controls.Add(btnDong)
            pnlHeaderActions.Controls.Add(btnMoMonAn)
            pnlHeader.Controls.Add(pnlHeaderActions)
            pnlHeader.Controls.Add(lblSubtitle)
            pnlHeader.Controls.Add(lblTitle)

            ' ==========================================
            ' 2. tlpKpiRow (Dock = Top, Height = 86, 3 Columns 33.33%)
            ' ==========================================
            tlpKpiRow.ColumnCount = 3
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F))
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F))
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F))
            tlpKpiRow.Dock = System.Windows.Forms.DockStyle.Top
            tlpKpiRow.Location = New System.Drawing.Point(0, 68)
            tlpKpiRow.Name = "tlpKpiRow"
            tlpKpiRow.Padding = New System.Windows.Forms.Padding(24, 12, 24, 4)
            tlpKpiRow.RowCount = 1
            tlpKpiRow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
            tlpKpiRow.Size = New System.Drawing.Size(1060, 86)
            tlpKpiRow.TabIndex = 1

            ' Card KPI 1: Tổng số Danh mục
            pnlKpiTongDM.BackColor = System.Drawing.Color.White
            pnlKpiTongDM.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiTongDM.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
            pnlKpiTongDM.Name = "pnlKpiTongDM"
            pnlKpiTongDM.Padding = New System.Windows.Forms.Padding(14, 8, 14, 8)
            lblKpiTongDMLabel.AutoSize = True
            lblKpiTongDMLabel.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblKpiTongDMLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblKpiTongDMLabel.Location = New System.Drawing.Point(14, 8)
            lblKpiTongDMLabel.Name = "lblKpiTongDMLabel"
            lblKpiTongDMLabel.Text = "📁 TỔNG SỐ DANH MỤC ĐANG HOẠT ĐỘNG"
            lblKpiTongDMValue.AutoSize = True
            lblKpiTongDMValue.Font = New System.Drawing.Font("Segoe UI", 15.0F, System.Drawing.FontStyle.Bold)
            lblKpiTongDMValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235)
            lblKpiTongDMValue.Location = New System.Drawing.Point(14, 28)
            lblKpiTongDMValue.Name = "lblKpiTongDMValue"
            lblKpiTongDMValue.Text = "0 nhóm"
            pnlKpiTongDM.Controls.Add(lblKpiTongDMValue)
            pnlKpiTongDM.Controls.Add(lblKpiTongDMLabel)

            ' Card KPI 2: Tổng số Món ăn
            pnlKpiTongMon.BackColor = System.Drawing.Color.White
            pnlKpiTongMon.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiTongMon.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
            pnlKpiTongMon.Name = "pnlKpiTongMon"
            pnlKpiTongMon.Padding = New System.Windows.Forms.Padding(14, 8, 14, 8)
            lblKpiTongMonLabel.AutoSize = True
            lblKpiTongMonLabel.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblKpiTongMonLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblKpiTongMonLabel.Location = New System.Drawing.Point(14, 8)
            lblKpiTongMonLabel.Name = "lblKpiTongMonLabel"
            lblKpiTongMonLabel.Text = "🍲 TỔNG SỐ MÓN TRONG THỰC ĐƠN"
            lblKpiTongMonValue.AutoSize = True
            lblKpiTongMonValue.Font = New System.Drawing.Font("Segoe UI", 15.0F, System.Drawing.FontStyle.Bold)
            lblKpiTongMonValue.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74)
            lblKpiTongMonValue.Location = New System.Drawing.Point(14, 28)
            lblKpiTongMonValue.Name = "lblKpiTongMonValue"
            lblKpiTongMonValue.Text = "0 món"
            pnlKpiTongMon.Controls.Add(lblKpiTongMonValue)
            pnlKpiTongMon.Controls.Add(lblKpiTongMonLabel)

            ' Card KPI 3: Danh mục trống (0 món)
            pnlKpiDMTrong.BackColor = System.Drawing.Color.White
            pnlKpiDMTrong.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiDMTrong.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            pnlKpiDMTrong.Name = "pnlKpiDMTrong"
            pnlKpiDMTrong.Padding = New System.Windows.Forms.Padding(14, 8, 14, 8)
            lblKpiDMTrongLabel.AutoSize = True
            lblKpiDMTrongLabel.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblKpiDMTrongLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblKpiDMTrongLabel.Location = New System.Drawing.Point(14, 8)
            lblKpiDMTrongLabel.Name = "lblKpiDMTrongLabel"
            lblKpiDMTrongLabel.Text = "🧹 DANH MỤC TRỐNG (0 MÓN)"
            lblKpiDMTrongValue.AutoSize = True
            lblKpiDMTrongValue.Font = New System.Drawing.Font("Segoe UI", 15.0F, System.Drawing.FontStyle.Bold)
            lblKpiDMTrongValue.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6)
            lblKpiDMTrongValue.Location = New System.Drawing.Point(14, 28)
            lblKpiDMTrongValue.Name = "lblKpiDMTrongValue"
            lblKpiDMTrongValue.Text = "0 nhóm"
            pnlKpiDMTrong.Controls.Add(lblKpiDMTrongValue)
            pnlKpiDMTrong.Controls.Add(lblKpiDMTrongLabel)

            tlpKpiRow.Controls.Add(pnlKpiTongDM, 0, 0)
            tlpKpiRow.Controls.Add(pnlKpiTongMon, 1, 0)
            tlpKpiRow.Controls.Add(pnlKpiDMTrong, 2, 0)

            ' ==========================================
            ' 3. tlpMainContent (Dock = Fill, 2 Columns: 38% Form : 62% Grid)
            ' ==========================================
            tlpMainContent.ColumnCount = 2
            tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0F))
            tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.0F))
            tlpMainContent.Dock = System.Windows.Forms.DockStyle.Fill
            tlpMainContent.Location = New System.Drawing.Point(0, 154)
            tlpMainContent.Name = "tlpMainContent"
            tlpMainContent.Padding = New System.Windows.Forms.Padding(24, 8, 24, 20)
            tlpMainContent.RowCount = 1
            tlpMainContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
            tlpMainContent.Size = New System.Drawing.Size(1060, 496)
            tlpMainContent.TabIndex = 2

            ' ------------------------------------------
            ' 3.1. Cột trái: pnlFormCard (Thông tin Danh mục)
            ' ------------------------------------------
            pnlFormCard.BackColor = System.Drawing.Color.White
            pnlFormCard.Dock = System.Windows.Forms.DockStyle.Fill
            pnlFormCard.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
            pnlFormCard.Name = "pnlFormCard"
            pnlFormCard.Padding = New System.Windows.Forms.Padding(18)

            lblFormTitle.AutoSize = True
            lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Bold)
            lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblFormTitle.Location = New System.Drawing.Point(18, 16)
            lblFormTitle.Name = "lblFormTitle"
            lblFormTitle.Text = "📝 Thông tin Danh mục"

            lblModeBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            lblModeBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
            lblModeBadge.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblModeBadge.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
            lblModeBadge.Location = New System.Drawing.Point(215, 15)
            lblModeBadge.Name = "lblModeBadge"
            lblModeBadge.Size = New System.Drawing.Size(145, 23)
            lblModeBadge.Text = "Chế độ: Thêm mới"
            lblModeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            lblThongBao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            lblThongBao.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            lblThongBao.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblThongBao.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblThongBao.Location = New System.Drawing.Point(18, 42)
            lblThongBao.Name = "lblThongBao"
            lblThongBao.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
            lblThongBao.Size = New System.Drawing.Size(342, 34)
            lblThongBao.Text = "ℹ️ Chọn 1 dòng trên bảng hoặc nhập Tên danh mục mới."
            lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

            lblMaDM.AutoSize = True
            lblMaDM.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            lblMaDM.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblMaDM.Location = New System.Drawing.Point(18, 82)
            lblMaDM.Name = "lblMaDM"
            lblMaDM.Text = "Mã danh mục (DM_Ma):"

            txtMaDM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtMaDM.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            txtMaDM.Font = New System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold)
            txtMaDM.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            txtMaDM.Location = New System.Drawing.Point(18, 102)
            txtMaDM.Name = "txtMaDM"
            txtMaDM.ReadOnly = True
            txtMaDM.Size = New System.Drawing.Size(342, 25)
            txtMaDM.Text = "Tự động (IDENTITY)"

            lblTenDM.AutoSize = True
            lblTenDM.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            lblTenDM.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblTenDM.Location = New System.Drawing.Point(18, 134)
            lblTenDM.Name = "lblTenDM"
            lblTenDM.Text = "Tên danh mục thực đơn (DM_Ten) *:"

            txtTenDM.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtTenDM.Font = New System.Drawing.Font("Segoe UI", 10.0F)
            txtTenDM.Location = New System.Drawing.Point(18, 154)
            txtTenDM.MaxLength = 100
            txtTenDM.Name = "txtTenDM"
            txtTenDM.PlaceholderText = "VD: Món Khai Vị & Gỏi..."
            txtTenDM.Size = New System.Drawing.Size(342, 25)

            lblMoTa.AutoSize = True
            lblMoTa.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            lblMoTa.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblMoTa.Location = New System.Drawing.Point(18, 186)
            lblMoTa.Name = "lblMoTa"
            lblMoTa.Text = "Mô tả nhóm thực đơn (DM_MoTa):"

            txtMoTa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtMoTa.Font = New System.Drawing.Font("Segoe UI", 9.5F)
            txtMoTa.Location = New System.Drawing.Point(18, 206)
            txtMoTa.MaxLength = 255
            txtMoTa.Multiline = True
            txtMoTa.Name = "txtMoTa"
            txtMoTa.PlaceholderText = "Mô tả đặc điểm các món ăn trong danh mục này..."
            txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            txtMoTa.Size = New System.Drawing.Size(342, 60)

            pnlDishCountBadge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            pnlDishCountBadge.BackColor = System.Drawing.Color.FromArgb(248, 250, 252)
            pnlDishCountBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pnlDishCountBadge.Location = New System.Drawing.Point(18, 274)
            pnlDishCountBadge.Name = "pnlDishCountBadge"
            pnlDishCountBadge.Size = New System.Drawing.Size(342, 32)

            lblThongKeMon.Dock = System.Windows.Forms.DockStyle.Fill
            lblThongKeMon.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            lblThongKeMon.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61)
            lblThongKeMon.Location = New System.Drawing.Point(0, 0)
            lblThongKeMon.Name = "lblThongKeMon"
            lblThongKeMon.Padding = New System.Windows.Forms.Padding(8, 0, 8, 0)
            lblThongKeMon.Size = New System.Drawing.Size(340, 32)
            lblThongKeMon.Text = "🔗 Số món ăn thuộc danh mục này: 0 món"
            lblThongKeMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            pnlDishCountBadge.Controls.Add(lblThongKeMon)

            ' Cụm 4 nút chức năng (2x2 TableLayoutPanel)
            tlpButtons.ColumnCount = 2
            tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            tlpButtons.Location = New System.Drawing.Point(18, 356)
            tlpButtons.Name = "tlpButtons"
            tlpButtons.RowCount = 2
            tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.Size = New System.Drawing.Size(342, 86)

            btnThem.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
            btnThem.Cursor = System.Windows.Forms.Cursors.Hand
            btnThem.Dock = System.Windows.Forms.DockStyle.Fill
            btnThem.FlatAppearance.BorderSize = 0
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnThem.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnThem.ForeColor = System.Drawing.Color.White
            btnThem.Margin = New System.Windows.Forms.Padding(0, 0, 5, 5)
            btnThem.Name = "btnThem"
            btnThem.Text = "➕ Thêm mới"
            btnThem.UseVisualStyleBackColor = False

            btnCapNhat.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand
            btnCapNhat.Dock = System.Windows.Forms.DockStyle.Fill
            btnCapNhat.FlatAppearance.BorderSize = 0
            btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnCapNhat.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnCapNhat.ForeColor = System.Drawing.Color.White
            btnCapNhat.Margin = New System.Windows.Forms.Padding(5, 0, 0, 5)
            btnCapNhat.Name = "btnCapNhat"
            btnCapNhat.Text = "💾 Cập nhật"
            btnCapNhat.UseVisualStyleBackColor = False

            btnXoa.BackColor = System.Drawing.Color.FromArgb(220, 38, 38)
            btnXoa.Cursor = System.Windows.Forms.Cursors.Hand
            btnXoa.Dock = System.Windows.Forms.DockStyle.Fill
            btnXoa.FlatAppearance.BorderSize = 0
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnXoa.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnXoa.ForeColor = System.Drawing.Color.White
            btnXoa.Margin = New System.Windows.Forms.Padding(0, 5, 5, 0)
            btnXoa.Name = "btnXoa"
            btnXoa.Text = "🗑️ Xóa danh mục"
            btnXoa.UseVisualStyleBackColor = False

            btnLamMoi.BackColor = System.Drawing.Color.FromArgb(71, 85, 105)
            btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand
            btnLamMoi.Dock = System.Windows.Forms.DockStyle.Fill
            btnLamMoi.FlatAppearance.BorderSize = 0
            btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnLamMoi.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnLamMoi.ForeColor = System.Drawing.Color.White
            btnLamMoi.Margin = New System.Windows.Forms.Padding(5, 5, 0, 0)
            btnLamMoi.Name = "btnLamMoi"
            btnLamMoi.Text = "🔄 Làm mới ô nhập"
            btnLamMoi.UseVisualStyleBackColor = False

            tlpButtons.Controls.Add(btnThem, 0, 0)
            tlpButtons.Controls.Add(btnCapNhat, 1, 0)
            tlpButtons.Controls.Add(btnXoa, 0, 1)
            tlpButtons.Controls.Add(btnLamMoi, 1, 1)

            pnlFormCard.Controls.Add(tlpButtons)
            pnlFormCard.Controls.Add(pnlDishCountBadge)
            pnlFormCard.Controls.Add(txtMoTa)
            pnlFormCard.Controls.Add(lblMoTa)
            pnlFormCard.Controls.Add(txtTenDM)
            pnlFormCard.Controls.Add(lblTenDM)
            pnlFormCard.Controls.Add(txtMaDM)
            pnlFormCard.Controls.Add(lblMaDM)
            pnlFormCard.Controls.Add(lblThongBao)
            pnlFormCard.Controls.Add(lblModeBadge)
            pnlFormCard.Controls.Add(lblFormTitle)

            ' ------------------------------------------
            ' 3.2. Cột phải: pnlGridCard (Tìm kiếm & Lưới DataGridView)
            '      LƯU Ý Z-ORDER WINFORMS:
            '      - Index 0 (Dock sau cùng): dgvDanhMuc (Dock = Fill)
            '      - Index 1 (Dock thứ hai):  pnlSearchBar (Dock = Top, Height = 46)
            '      - Index 2 (Dock đầu tiên): lblGridTitle (Dock = Top, Height = 32)
            ' ------------------------------------------
            pnlGridCard.BackColor = System.Drawing.Color.White
            pnlGridCard.Dock = System.Windows.Forms.DockStyle.Fill
            pnlGridCard.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            pnlGridCard.Name = "pnlGridCard"
            pnlGridCard.Padding = New System.Windows.Forms.Padding(18)

            lblGridTitle.AutoSize = False
            lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top
            lblGridTitle.Font = New System.Drawing.Font("Segoe UI", 11.0F, System.Drawing.FontStyle.Bold)
            lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblGridTitle.Location = New System.Drawing.Point(18, 18)
            lblGridTitle.Name = "lblGridTitle"
            lblGridTitle.Size = New System.Drawing.Size(580, 32)
            lblGridTitle.Text = "📋 Danh sách Danh mục Thực đơn (Click vào dòng để xem / sửa / xóa)"
            lblGridTitle.TextAlign = System.Drawing.ContentAlignment.TopLeft

            pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top
            pnlSearchBar.Location = New System.Drawing.Point(18, 50)
            pnlSearchBar.Name = "pnlSearchBar"
            pnlSearchBar.Padding = New System.Windows.Forms.Padding(0, 4, 0, 10)
            pnlSearchBar.Size = New System.Drawing.Size(580, 46)

            txtTimKiem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtTimKiem.Font = New System.Drawing.Font("Segoe UI", 10.0F)
            txtTimKiem.Location = New System.Drawing.Point(0, 6)
            txtTimKiem.Name = "txtTimKiem"
            txtTimKiem.PlaceholderText = "🔍 Nhập tên danh mục hoặc mô tả để lọc nhanh..."
            txtTimKiem.Size = New System.Drawing.Size(386, 25)

            btnTimKiem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            btnTimKiem.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand
            btnTimKiem.FlatAppearance.BorderSize = 0
            btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnTimKiem.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            btnTimKiem.ForeColor = System.Drawing.Color.White
            btnTimKiem.Location = New System.Drawing.Point(394, 4)
            btnTimKiem.Name = "btnTimKiem"
            btnTimKiem.Size = New System.Drawing.Size(92, 30)
            btnTimKiem.Text = "Tìm kiếm"
            btnTimKiem.UseVisualStyleBackColor = False

            btnTaiLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            btnTaiLai.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            btnTaiLai.Cursor = System.Windows.Forms.Cursors.Hand
            btnTaiLai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
            btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnTaiLai.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            btnTaiLai.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            btnTaiLai.Location = New System.Drawing.Point(494, 4)
            btnTaiLai.Name = "btnTaiLai"
            btnTaiLai.Size = New System.Drawing.Size(86, 30)
            btnTaiLai.Text = "Tải lại"
            btnTaiLai.UseVisualStyleBackColor = False

            pnlSearchBar.Controls.Add(btnTaiLai)
            pnlSearchBar.Controls.Add(btnTimKiem)
            pnlSearchBar.Controls.Add(txtTimKiem)

            ' DataGridView dgvDanhMuc
            dgvDanhMuc.AllowUserToAddRows = False
            dgvDanhMuc.AllowUserToDeleteRows = False
            dgvDanhMuc.AllowUserToResizeRows = False
            dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            dgvDanhMuc.BackgroundColor = System.Drawing.Color.FromArgb(248, 250, 252)
            dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            dgvDanhMuc.ColumnHeadersHeight = 38
            dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgvDanhMuc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {colMaDM, colTenDM, colMoTa, colSoLuongMon})
            dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill
            dgvDanhMuc.EnableHeadersVisualStyles = False
            dgvDanhMuc.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
            dgvDanhMuc.Location = New System.Drawing.Point(18, 96)
            dgvDanhMuc.MultiSelect = False
            dgvDanhMuc.Name = "dgvDanhMuc"
            dgvDanhMuc.ReadOnly = True
            dgvDanhMuc.RowHeadersVisible = False
            dgvDanhMuc.RowTemplate.Height = 36
            dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            dgvDanhMuc.Size = New System.Drawing.Size(580, 364)

            colMaDM.DataPropertyName = "MaDanhMuc"
            colMaDM.FillWeight = 13.0F
            colMaDM.HeaderText = "Mã DM"
            colMaDM.Name = "colMaDM"
            colMaDM.ReadOnly = True

            colTenDM.DataPropertyName = "TenDanhMuc"
            colTenDM.FillWeight = 33.0F
            colTenDM.HeaderText = "Tên danh mục"
            colTenDM.Name = "colTenDM"
            colTenDM.ReadOnly = True

            colMoTa.DataPropertyName = "MoTa"
            colMoTa.FillWeight = 38.0F
            colMoTa.HeaderText = "Mô tả chi tiết"
            colMoTa.Name = "colMoTa"
            colMoTa.ReadOnly = True

            colSoLuongMon.DataPropertyName = "SoLuongMon"
            colSoLuongMon.FillWeight = 16.0F
            colSoLuongMon.HeaderText = "Số món"
            colSoLuongMon.Name = "colSoLuongMon"
            colSoLuongMon.ReadOnly = True

            ' Z-Order chuẩn trong pnlGridCard: Fill ở Index 0, Top ở Index 1 & 2
            pnlGridCard.Controls.Add(dgvDanhMuc)
            pnlGridCard.Controls.Add(pnlSearchBar)
            pnlGridCard.Controls.Add(lblGridTitle)

            tlpMainContent.Controls.Add(pnlFormCard, 0, 0)
            tlpMainContent.Controls.Add(pnlGridCard, 1, 0)

            ' ==========================================
            ' Form Properties & Root Z-Order
            ' ==========================================
            AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            BackColor = System.Drawing.Color.FromArgb(245, 246, 250)
            ClientSize = New System.Drawing.Size(1060, 650)
            Controls.Add(tlpMainContent)
            Controls.Add(tlpKpiRow)
            Controls.Add(pnlHeader)
            Font = New System.Drawing.Font("Segoe UI", 9.0F)
            KeyPreview = True
            MinimumSize = New System.Drawing.Size(960, 580)
            Name = "frmDanhMuc"
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Quản lý Danh mục Thực đơn — Quán Ăn Gia Đình Hương Việt"

            pnlHeader.ResumeLayout(False)
            pnlHeader.PerformLayout()
            pnlHeaderActions.ResumeLayout(False)
            tlpKpiRow.ResumeLayout(False)
            pnlKpiTongDM.ResumeLayout(False)
            pnlKpiTongDM.PerformLayout()
            pnlKpiTongMon.ResumeLayout(False)
            pnlKpiTongMon.PerformLayout()
            pnlKpiDMTrong.ResumeLayout(False)
            pnlKpiDMTrong.PerformLayout()
            tlpMainContent.ResumeLayout(False)
            pnlFormCard.ResumeLayout(False)
            pnlFormCard.PerformLayout()
            pnlDishCountBadge.ResumeLayout(False)
            tlpButtons.ResumeLayout(False)
            pnlGridCard.ResumeLayout(False)
            pnlSearchBar.ResumeLayout(False)
            pnlSearchBar.PerformLayout()
            CType(dgvDanhMuc, System.ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub
    End Class
End Namespace
