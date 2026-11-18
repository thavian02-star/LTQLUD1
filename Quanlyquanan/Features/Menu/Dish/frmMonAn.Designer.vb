Namespace Features.Menu
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMonAn
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
        Friend WithEvents btnMoDanhMuc As System.Windows.Forms.Button
        Friend WithEvents btnDong As System.Windows.Forms.Button

        ' KPI Row Controls (3 columns)
        Friend WithEvents tlpKpiRow As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pnlKpiTongMon As System.Windows.Forms.Panel
        Friend WithEvents lblKpiTongMonLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiTongMonValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiConMon As System.Windows.Forms.Panel
        Friend WithEvents lblKpiConMonLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiConMonValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiHetMon As System.Windows.Forms.Panel
        Friend WithEvents lblKpiHetMonLabel As System.Windows.Forms.Label
        Friend WithEvents lblKpiHetMonValue As System.Windows.Forms.Label

        ' Main Split Layout (38% Form : 62% Grid)
        Friend WithEvents tlpMainContent As System.Windows.Forms.TableLayoutPanel

        ' Left Column: Form Card
        Friend WithEvents pnlFormCard As System.Windows.Forms.Panel
        Friend WithEvents lblFormTitle As System.Windows.Forms.Label
        Friend WithEvents lblModeBadge As System.Windows.Forms.Label
        Friend WithEvents lblThongBao As System.Windows.Forms.Label
        Friend WithEvents lblMaMon As System.Windows.Forms.Label
        Friend WithEvents txtMaMon As System.Windows.Forms.TextBox
        Friend WithEvents lblDanhMuc As System.Windows.Forms.Label
        Friend WithEvents cboDanhMuc As System.Windows.Forms.ComboBox
        Friend WithEvents lblTenMon As System.Windows.Forms.Label
        Friend WithEvents txtTenMon As System.Windows.Forms.TextBox
        Friend WithEvents lblDonGia As System.Windows.Forms.Label
        Friend WithEvents nudDonGia As System.Windows.Forms.NumericUpDown
        Friend WithEvents pnlTrangThaiBox As System.Windows.Forms.Panel
        Friend WithEvents chkHetMon As System.Windows.Forms.CheckBox
        Friend WithEvents lblMoTa As System.Windows.Forms.Label
        Friend WithEvents txtMoTa As System.Windows.Forms.TextBox
        Friend WithEvents tlpButtons As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnThem As System.Windows.Forms.Button
        Friend WithEvents btnCapNhat As System.Windows.Forms.Button
        Friend WithEvents btnXoa As System.Windows.Forms.Button
        Friend WithEvents btnLamMoi As System.Windows.Forms.Button

        ' Right Column: Grid Card
        Friend WithEvents pnlGridCard As System.Windows.Forms.Panel
        Friend WithEvents lblGridTitle As System.Windows.Forms.Label
        Friend WithEvents pnlSearchBar As System.Windows.Forms.Panel
        Friend WithEvents cboLocDanhMuc As System.Windows.Forms.ComboBox
        Friend WithEvents cboLocTrangThai As System.Windows.Forms.ComboBox
        Friend WithEvents txtTimKiem As System.Windows.Forms.TextBox
        Friend WithEvents btnTaiLai As System.Windows.Forms.Button
        Friend WithEvents dgvMonAn As System.Windows.Forms.DataGridView
        Friend WithEvents colMaMon As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTenMon As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTenDanhMuc As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDonGia As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTrangThai As System.Windows.Forms.DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            pnlHeader = New System.Windows.Forms.Panel()
            lblTitle = New System.Windows.Forms.Label()
            lblSubtitle = New System.Windows.Forms.Label()
            pnlHeaderActions = New System.Windows.Forms.FlowLayoutPanel()
            btnMoDanhMuc = New System.Windows.Forms.Button()
            btnDong = New System.Windows.Forms.Button()

            tlpKpiRow = New System.Windows.Forms.TableLayoutPanel()
            pnlKpiTongMon = New System.Windows.Forms.Panel()
            lblKpiTongMonLabel = New System.Windows.Forms.Label()
            lblKpiTongMonValue = New System.Windows.Forms.Label()
            pnlKpiConMon = New System.Windows.Forms.Panel()
            lblKpiConMonLabel = New System.Windows.Forms.Label()
            lblKpiConMonValue = New System.Windows.Forms.Label()
            pnlKpiHetMon = New System.Windows.Forms.Panel()
            lblKpiHetMonLabel = New System.Windows.Forms.Label()
            lblKpiHetMonValue = New System.Windows.Forms.Label()

            tlpMainContent = New System.Windows.Forms.TableLayoutPanel()
            pnlFormCard = New System.Windows.Forms.Panel()
            lblFormTitle = New System.Windows.Forms.Label()
            lblModeBadge = New System.Windows.Forms.Label()
            lblThongBao = New System.Windows.Forms.Label()
            lblMaMon = New System.Windows.Forms.Label()
            txtMaMon = New System.Windows.Forms.TextBox()
            lblDanhMuc = New System.Windows.Forms.Label()
            cboDanhMuc = New System.Windows.Forms.ComboBox()
            lblTenMon = New System.Windows.Forms.Label()
            txtTenMon = New System.Windows.Forms.TextBox()
            lblDonGia = New System.Windows.Forms.Label()
            nudDonGia = New System.Windows.Forms.NumericUpDown()
            pnlTrangThaiBox = New System.Windows.Forms.Panel()
            chkHetMon = New System.Windows.Forms.CheckBox()
            lblMoTa = New System.Windows.Forms.Label()
            txtMoTa = New System.Windows.Forms.TextBox()
            tlpButtons = New System.Windows.Forms.TableLayoutPanel()
            btnThem = New System.Windows.Forms.Button()
            btnCapNhat = New System.Windows.Forms.Button()
            btnXoa = New System.Windows.Forms.Button()
            btnLamMoi = New System.Windows.Forms.Button()

            pnlGridCard = New System.Windows.Forms.Panel()
            lblGridTitle = New System.Windows.Forms.Label()
            pnlSearchBar = New System.Windows.Forms.Panel()
            cboLocDanhMuc = New System.Windows.Forms.ComboBox()
            cboLocTrangThai = New System.Windows.Forms.ComboBox()
            txtTimKiem = New System.Windows.Forms.TextBox()
            btnTaiLai = New System.Windows.Forms.Button()
            dgvMonAn = New System.Windows.Forms.DataGridView()
            colMaMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colTenMon = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colTenDanhMuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colDonGia = New System.Windows.Forms.DataGridViewTextBoxColumn()
            colTrangThai = New System.Windows.Forms.DataGridViewTextBoxColumn()

            pnlHeader.SuspendLayout()
            pnlHeaderActions.SuspendLayout()
            tlpKpiRow.SuspendLayout()
            pnlKpiTongMon.SuspendLayout()
            pnlKpiConMon.SuspendLayout()
            pnlKpiHetMon.SuspendLayout()
            tlpMainContent.SuspendLayout()
            pnlFormCard.SuspendLayout()
            CType(nudDonGia, System.ComponentModel.ISupportInitialize).BeginInit()
            pnlTrangThaiBox.SuspendLayout()
            tlpButtons.SuspendLayout()
            pnlGridCard.SuspendLayout()
            pnlSearchBar.SuspendLayout()
            CType(dgvMonAn, System.ComponentModel.ISupportInitialize).BeginInit()
            SuspendLayout()

            ' ==========================================
            ' 1. pnlHeader (Dock = Top, Height = 68)
            ' ==========================================
            pnlHeader.BackColor = System.Drawing.Color.White
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            pnlHeader.Location = New System.Drawing.Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Padding = New System.Windows.Forms.Padding(24, 10, 24, 10)
            pnlHeader.Size = New System.Drawing.Size(1120, 68)
            pnlHeader.TabIndex = 0

            lblTitle.AutoSize = True
            lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0F, System.Drawing.FontStyle.Bold)
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblTitle.Location = New System.Drawing.Point(24, 10)
            lblTitle.Name = "lblTitle"
            lblTitle.Size = New System.Drawing.Size(370, 25)
            lblTitle.Text = "🍜 QUẢN LÝ MÓN ĂN & THỨC UỐNG"

            lblSubtitle.AutoSize = True
            lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.0F)
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblSubtitle.Location = New System.Drawing.Point(26, 38)
            lblSubtitle.Name = "lblSubtitle"
            lblSubtitle.Size = New System.Drawing.Size(480, 15)
            lblSubtitle.Text = "Thiết lập thực đơn, định giá bán VNĐ và kiểm soát trạng thái Còn món / Hết món"

            pnlHeaderActions.Dock = System.Windows.Forms.DockStyle.Right
            pnlHeaderActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
            pnlHeaderActions.Location = New System.Drawing.Point(740, 10)
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

            btnMoDanhMuc.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
            btnMoDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand
            btnMoDanhMuc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(147, 197, 253)
            btnMoDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnMoDanhMuc.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnMoDanhMuc.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
            btnMoDanhMuc.Margin = New System.Windows.Forms.Padding(0, 6, 0, 6)
            btnMoDanhMuc.Name = "btnMoDanhMuc"
            btnMoDanhMuc.Size = New System.Drawing.Size(210, 36)
            btnMoDanhMuc.Text = "📂 Quản lý Danh mục"
            btnMoDanhMuc.UseVisualStyleBackColor = False

            pnlHeaderActions.Controls.Add(btnDong)
            pnlHeaderActions.Controls.Add(btnMoDanhMuc)
            pnlHeader.Controls.Add(pnlHeaderActions)
            pnlHeader.Controls.Add(lblSubtitle)
            pnlHeader.Controls.Add(lblTitle)

            ' ==========================================
            ' 2. tlpKpiRow (Dock = Top, Height = 84, 3 Columns 33.33%)
            ' ==========================================
            tlpKpiRow.ColumnCount = 3
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F))
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F))
            tlpKpiRow.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F))
            tlpKpiRow.Dock = System.Windows.Forms.DockStyle.Top
            tlpKpiRow.Location = New System.Drawing.Point(0, 68)
            tlpKpiRow.Name = "tlpKpiRow"
            tlpKpiRow.Padding = New System.Windows.Forms.Padding(24, 10, 24, 4)
            tlpKpiRow.RowCount = 1
            tlpKpiRow.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
            tlpKpiRow.Size = New System.Drawing.Size(1120, 80)
            tlpKpiRow.TabIndex = 1

            ' Card KPI 1: Tổng số Món ăn
            pnlKpiTongMon.BackColor = System.Drawing.Color.White
            pnlKpiTongMon.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiTongMon.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
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
            lblKpiTongMonValue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235)
            lblKpiTongMonValue.Location = New System.Drawing.Point(14, 28)
            lblKpiTongMonValue.Name = "lblKpiTongMonValue"
            lblKpiTongMonValue.Text = "0 món"
            pnlKpiTongMon.Controls.Add(lblKpiTongMonValue)
            pnlKpiTongMon.Controls.Add(lblKpiTongMonLabel)

            ' Card KPI 2: Đang phục vụ (Còn món)
            pnlKpiConMon.BackColor = System.Drawing.Color.White
            pnlKpiConMon.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiConMon.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
            pnlKpiConMon.Name = "pnlKpiConMon"
            pnlKpiConMon.Padding = New System.Windows.Forms.Padding(14, 8, 14, 8)
            lblKpiConMonLabel.AutoSize = True
            lblKpiConMonLabel.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblKpiConMonLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblKpiConMonLabel.Location = New System.Drawing.Point(14, 8)
            lblKpiConMonLabel.Name = "lblKpiConMonLabel"
            lblKpiConMonLabel.Text = "🟢 ĐANG PHỤC VỤ (CÒN MÓN)"
            lblKpiConMonValue.AutoSize = True
            lblKpiConMonValue.Font = New System.Drawing.Font("Segoe UI", 15.0F, System.Drawing.FontStyle.Bold)
            lblKpiConMonValue.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74)
            lblKpiConMonValue.Location = New System.Drawing.Point(14, 28)
            lblKpiConMonValue.Name = "lblKpiConMonValue"
            lblKpiConMonValue.Text = "0 món"
            pnlKpiConMon.Controls.Add(lblKpiConMonValue)
            pnlKpiConMon.Controls.Add(lblKpiConMonLabel)

            ' Card KPI 3: Tạm hết nguyên liệu (Hết món)
            pnlKpiHetMon.BackColor = System.Drawing.Color.White
            pnlKpiHetMon.Dock = System.Windows.Forms.DockStyle.Fill
            pnlKpiHetMon.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            pnlKpiHetMon.Name = "pnlKpiHetMon"
            pnlKpiHetMon.Padding = New System.Windows.Forms.Padding(14, 8, 14, 8)
            lblKpiHetMonLabel.AutoSize = True
            lblKpiHetMonLabel.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblKpiHetMonLabel.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            lblKpiHetMonLabel.Location = New System.Drawing.Point(14, 8)
            lblKpiHetMonLabel.Name = "lblKpiHetMonLabel"
            lblKpiHetMonLabel.Text = "🔴 TẠM HẾT NGUYÊN LIỆU (HẾT MÓN)"
            lblKpiHetMonValue.AutoSize = True
            lblKpiHetMonValue.Font = New System.Drawing.Font("Segoe UI", 15.0F, System.Drawing.FontStyle.Bold)
            lblKpiHetMonValue.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12)
            lblKpiHetMonValue.Location = New System.Drawing.Point(14, 28)
            lblKpiHetMonValue.Name = "lblKpiHetMonValue"
            lblKpiHetMonValue.Text = "0 món"
            pnlKpiHetMon.Controls.Add(lblKpiHetMonValue)
            pnlKpiHetMon.Controls.Add(lblKpiHetMonLabel)

            tlpKpiRow.Controls.Add(pnlKpiTongMon, 0, 0)
            tlpKpiRow.Controls.Add(pnlKpiConMon, 1, 0)
            tlpKpiRow.Controls.Add(pnlKpiHetMon, 2, 0)

            ' ==========================================
            ' 3. tlpMainContent (Dock = Fill, 2 Columns: 38% Form : 62% Grid)
            ' ==========================================
            tlpMainContent.ColumnCount = 2
            tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.0F))
            tlpMainContent.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.0F))
            tlpMainContent.Dock = System.Windows.Forms.DockStyle.Fill
            tlpMainContent.Location = New System.Drawing.Point(0, 152)
            tlpMainContent.Name = "tlpMainContent"
            tlpMainContent.Padding = New System.Windows.Forms.Padding(24, 8, 24, 20)
            tlpMainContent.RowCount = 1
            tlpMainContent.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0F))
            tlpMainContent.Size = New System.Drawing.Size(1120, 528)
            tlpMainContent.TabIndex = 2

            ' ------------------------------------------
            ' 3.1. Cột trái: pnlFormCard (Thông tin Món ăn)
            ' ------------------------------------------
            pnlFormCard.BackColor = System.Drawing.Color.White
            pnlFormCard.Dock = System.Windows.Forms.DockStyle.Fill
            pnlFormCard.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
            pnlFormCard.Name = "pnlFormCard"
            pnlFormCard.Padding = New System.Windows.Forms.Padding(18)

            lblFormTitle.AutoSize = True
            lblFormTitle.Font = New System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold)
            lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblFormTitle.Location = New System.Drawing.Point(18, 14)
            lblFormTitle.Name = "lblFormTitle"
            lblFormTitle.Text = "📝 Thông tin Món ăn / Thức uống"

            lblModeBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            lblModeBadge.BackColor = System.Drawing.Color.FromArgb(239, 246, 255)
            lblModeBadge.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblModeBadge.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
            lblModeBadge.Location = New System.Drawing.Point(244, 13)
            lblModeBadge.Name = "lblModeBadge"
            lblModeBadge.Size = New System.Drawing.Size(142, 22)
            lblModeBadge.Text = "Chế độ: Thêm mới"
            lblModeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

            lblThongBao.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            lblThongBao.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            lblThongBao.Font = New System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold)
            lblThongBao.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblThongBao.Location = New System.Drawing.Point(18, 40)
            lblThongBao.Name = "lblThongBao"
            lblThongBao.Padding = New System.Windows.Forms.Padding(8, 3, 8, 3)
            lblThongBao.Size = New System.Drawing.Size(368, 32)
            lblThongBao.Text = "ℹ️ Chọn 1 món trên bảng hoặc nhập thông tin món mới."
            lblThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft

            lblMaMon.AutoSize = True
            lblMaMon.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblMaMon.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblMaMon.Location = New System.Drawing.Point(18, 76)
            lblMaMon.Name = "lblMaMon"
            lblMaMon.Text = "Mã món (MA_Ma):"

            txtMaMon.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            txtMaMon.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            txtMaMon.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139)
            txtMaMon.Location = New System.Drawing.Point(18, 95)
            txtMaMon.Name = "txtMaMon"
            txtMaMon.ReadOnly = True
            txtMaMon.Size = New System.Drawing.Size(112, 24)
            txtMaMon.Text = "Tự động"

            lblDanhMuc.AutoSize = True
            lblDanhMuc.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblDanhMuc.Location = New System.Drawing.Point(140, 76)
            lblDanhMuc.Name = "lblDanhMuc"
            lblDanhMuc.Text = "Nhóm danh mục (MA_DanhMuc) *:"

            cboDanhMuc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cboDanhMuc.Font = New System.Drawing.Font("Segoe UI", 9.5F)
            cboDanhMuc.FormattingEnabled = True
            cboDanhMuc.Location = New System.Drawing.Point(140, 95)
            cboDanhMuc.Name = "cboDanhMuc"
            cboDanhMuc.Size = New System.Drawing.Size(246, 25)

            lblTenMon.AutoSize = True
            lblTenMon.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblTenMon.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblTenMon.Location = New System.Drawing.Point(18, 125)
            lblTenMon.Name = "lblTenMon"
            lblTenMon.Text = "Tên món ăn / thức uống (MA_Ten) *:"

            txtTenMon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtTenMon.Font = New System.Drawing.Font("Segoe UI", 9.75F)
            txtTenMon.Location = New System.Drawing.Point(18, 144)
            txtTenMon.MaxLength = 100
            txtTenMon.Name = "txtTenMon"
            txtTenMon.PlaceholderText = "VD: Lẩu Thái Tomyum hải sản..."
            txtTenMon.Size = New System.Drawing.Size(368, 25)

            lblDonGia.AutoSize = True
            lblDonGia.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblDonGia.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblDonGia.Location = New System.Drawing.Point(18, 174)
            lblDonGia.Name = "lblDonGia"
            lblDonGia.Text = "Đơn giá bán VNĐ (MA_DonGia) *:"

            nudDonGia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            nudDonGia.Font = New System.Drawing.Font("Segoe UI", 10.0F, System.Drawing.FontStyle.Bold)
            nudDonGia.ForeColor = System.Drawing.Color.FromArgb(29, 78, 216)
            nudDonGia.Increment = New Decimal(New Integer() {5000, 0, 0, 0})
            nudDonGia.Location = New System.Drawing.Point(18, 193)
            nudDonGia.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
            nudDonGia.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
            nudDonGia.Name = "nudDonGia"
            nudDonGia.Size = New System.Drawing.Size(368, 25)
            nudDonGia.ThousandsSeparator = True
            nudDonGia.Value = New Decimal(New Integer() {45000, 0, 0, 0})

            pnlTrangThaiBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            pnlTrangThaiBox.BackColor = System.Drawing.Color.FromArgb(255, 247, 237)
            pnlTrangThaiBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            pnlTrangThaiBox.Location = New System.Drawing.Point(18, 224)
            pnlTrangThaiBox.Name = "pnlTrangThaiBox"
            pnlTrangThaiBox.Size = New System.Drawing.Size(368, 30)

            chkHetMon.AutoSize = True
            chkHetMon.Cursor = System.Windows.Forms.Cursors.Hand
            chkHetMon.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            chkHetMon.ForeColor = System.Drawing.Color.FromArgb(154, 52, 18)
            chkHetMon.Location = New System.Drawing.Point(10, 5)
            chkHetMon.Name = "chkHetMon"
            chkHetMon.Text = "🔴 Báo tạm hết món (MA_HetMon = 1 — Ngừng nhận order)"
            pnlTrangThaiBox.Controls.Add(chkHetMon)

            lblMoTa.AutoSize = True
            lblMoTa.Font = New System.Drawing.Font("Segoe UI", 8.75F, System.Drawing.FontStyle.Bold)
            lblMoTa.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            lblMoTa.Location = New System.Drawing.Point(18, 260)
            lblMoTa.Name = "lblMoTa"
            lblMoTa.Text = "Mô tả thành phần / Định lượng (MA_MoTa):"

            txtMoTa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtMoTa.Font = New System.Drawing.Font("Segoe UI", 9.25F)
            txtMoTa.Location = New System.Drawing.Point(18, 279)
            txtMoTa.MaxLength = 255
            txtMoTa.Multiline = True
            txtMoTa.Name = "txtMoTa"
            txtMoTa.PlaceholderText = "Mô tả nguyên liệu, khẩu phần hoặc ghi chú phục vụ..."
            txtMoTa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            txtMoTa.Size = New System.Drawing.Size(368, 48)

            ' Cụm 4 nút chức năng (2x2 TableLayoutPanel)
            tlpButtons.ColumnCount = 2
            tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            tlpButtons.Location = New System.Drawing.Point(18, 398)
            tlpButtons.Name = "tlpButtons"
            tlpButtons.RowCount = 2
            tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0F))
            tlpButtons.Size = New System.Drawing.Size(368, 80)

            btnThem.BackColor = System.Drawing.Color.FromArgb(22, 163, 74)
            btnThem.Cursor = System.Windows.Forms.Cursors.Hand
            btnThem.Dock = System.Windows.Forms.DockStyle.Fill
            btnThem.FlatAppearance.BorderSize = 0
            btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnThem.Font = New System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold)
            btnThem.ForeColor = System.Drawing.Color.White
            btnThem.Margin = New System.Windows.Forms.Padding(0, 0, 5, 5)
            btnThem.Name = "btnThem"
            btnThem.Text = "➕ Thêm món mới"
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
            btnCapNhat.Text = "💾 Lưu cập nhật"
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
            btnXoa.Text = "🗑️ Xóa món ăn"
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
            pnlFormCard.Controls.Add(txtMoTa)
            pnlFormCard.Controls.Add(lblMoTa)
            pnlFormCard.Controls.Add(pnlTrangThaiBox)
            pnlFormCard.Controls.Add(nudDonGia)
            pnlFormCard.Controls.Add(lblDonGia)
            pnlFormCard.Controls.Add(txtTenMon)
            pnlFormCard.Controls.Add(lblTenMon)
            pnlFormCard.Controls.Add(cboDanhMuc)
            pnlFormCard.Controls.Add(lblDanhMuc)
            pnlFormCard.Controls.Add(txtMaMon)
            pnlFormCard.Controls.Add(lblMaMon)
            pnlFormCard.Controls.Add(lblThongBao)
            pnlFormCard.Controls.Add(lblModeBadge)
            pnlFormCard.Controls.Add(lblFormTitle)

            ' ------------------------------------------
            ' 3.2. Cột phải: pnlGridCard (Bộ lọc đa chiều & Lưới DataGridView)
            '      LƯU Ý Z-ORDER WINFORMS:
            '      - Index 0 (Dock sau cùng): dgvMonAn (Dock = Fill)
            '      - Index 1 (Dock thứ hai):  pnlSearchBar (Dock = Top, Height = 46)
            '      - Index 2 (Dock đầu tiên): lblGridTitle (Dock = Top, Height = 30)
            ' ------------------------------------------
            pnlGridCard.BackColor = System.Drawing.Color.White
            pnlGridCard.Dock = System.Windows.Forms.DockStyle.Fill
            pnlGridCard.Margin = New System.Windows.Forms.Padding(8, 0, 0, 0)
            pnlGridCard.Name = "pnlGridCard"
            pnlGridCard.Padding = New System.Windows.Forms.Padding(18)

            lblGridTitle.AutoSize = False
            lblGridTitle.Dock = System.Windows.Forms.DockStyle.Top
            lblGridTitle.Font = New System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold)
            lblGridTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42)
            lblGridTitle.Location = New System.Drawing.Point(18, 18)
            lblGridTitle.Name = "lblGridTitle"
            lblGridTitle.Size = New System.Drawing.Size(616, 30)
            lblGridTitle.Text = "📋 Danh sách Thực đơn Món ăn & Thức uống (Click vào dòng để xem / sửa / xóa)"
            lblGridTitle.TextAlign = System.Drawing.ContentAlignment.TopLeft

            pnlSearchBar.Dock = System.Windows.Forms.DockStyle.Top
            pnlSearchBar.Location = New System.Drawing.Point(18, 48)
            pnlSearchBar.Name = "pnlSearchBar"
            pnlSearchBar.Padding = New System.Windows.Forms.Padding(0, 4, 0, 10)
            pnlSearchBar.Size = New System.Drawing.Size(616, 46)

            cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cboLocDanhMuc.Font = New System.Drawing.Font("Segoe UI", 9.25F)
            cboLocDanhMuc.FormattingEnabled = True
            cboLocDanhMuc.Location = New System.Drawing.Point(0, 6)
            cboLocDanhMuc.Name = "cboLocDanhMuc"
            cboLocDanhMuc.Size = New System.Drawing.Size(176, 23)

            cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            cboLocTrangThai.Font = New System.Drawing.Font("Segoe UI", 9.25F)
            cboLocTrangThai.FormattingEnabled = True
            cboLocTrangThai.Location = New System.Drawing.Point(182, 6)
            cboLocTrangThai.Name = "cboLocTrangThai"
            cboLocTrangThai.Size = New System.Drawing.Size(142, 23)

            txtTimKiem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            txtTimKiem.Font = New System.Drawing.Font("Segoe UI", 9.5F)
            txtTimKiem.Location = New System.Drawing.Point(330, 6)
            txtTimKiem.Name = "txtTimKiem"
            txtTimKiem.PlaceholderText = "🔍 Tìm tên món hoặc mô tả..."
            txtTimKiem.Size = New System.Drawing.Size(202, 24)

            btnTaiLai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            btnTaiLai.BackColor = System.Drawing.Color.FromArgb(241, 245, 249)
            btnTaiLai.Cursor = System.Windows.Forms.Cursors.Hand
            btnTaiLai.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225)
            btnTaiLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            btnTaiLai.Font = New System.Drawing.Font("Segoe UI", 9.0F, System.Drawing.FontStyle.Bold)
            btnTaiLai.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85)
            btnTaiLai.Location = New System.Drawing.Point(538, 4)
            btnTaiLai.Name = "btnTaiLai"
            btnTaiLai.Size = New System.Drawing.Size(78, 28)
            btnTaiLai.Text = "Tải lại"
            btnTaiLai.UseVisualStyleBackColor = False

            pnlSearchBar.Controls.Add(btnTaiLai)
            pnlSearchBar.Controls.Add(txtTimKiem)
            pnlSearchBar.Controls.Add(cboLocTrangThai)
            pnlSearchBar.Controls.Add(cboLocDanhMuc)

            ' DataGridView dgvMonAn
            dgvMonAn.AllowUserToAddRows = False
            dgvMonAn.AllowUserToDeleteRows = False
            dgvMonAn.AllowUserToResizeRows = False
            dgvMonAn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            dgvMonAn.BackgroundColor = System.Drawing.Color.FromArgb(248, 250, 252)
            dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            dgvMonAn.ColumnHeadersHeight = 38
            dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            dgvMonAn.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {colMaMon, colTenMon, colTenDanhMuc, colDonGia, colTrangThai})
            dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill
            dgvMonAn.EnableHeadersVisualStyles = False
            dgvMonAn.GridColor = System.Drawing.Color.FromArgb(226, 232, 240)
            dgvMonAn.Location = New System.Drawing.Point(18, 94)
            dgvMonAn.MultiSelect = False
            dgvMonAn.Name = "dgvMonAn"
            dgvMonAn.ReadOnly = True
            dgvMonAn.RowHeadersVisible = False
            dgvMonAn.RowTemplate.Height = 36
            dgvMonAn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            dgvMonAn.Size = New System.Drawing.Size(616, 388)

            colMaMon.DataPropertyName = "MaMonAn"
            colMaMon.FillWeight = 10.0F
            colMaMon.HeaderText = "Mã"
            colMaMon.Name = "colMaMon"
            colMaMon.ReadOnly = True

            colTenMon.DataPropertyName = "TenMonAn"
            colTenMon.FillWeight = 34.0F
            colTenMon.HeaderText = "Tên món ăn / thức uống"
            colTenMon.Name = "colTenMon"
            colTenMon.ReadOnly = True

            colTenDanhMuc.DataPropertyName = "TenDanhMuc"
            colTenDanhMuc.FillWeight = 22.0F
            colTenDanhMuc.HeaderText = "Danh mục"
            colTenDanhMuc.Name = "colTenDanhMuc"
            colTenDanhMuc.ReadOnly = True

            colDonGia.DataPropertyName = "DonGia"
            colDonGia.FillWeight = 18.0F
            colDonGia.HeaderText = "Đơn giá"
            colDonGia.Name = "colDonGia"
            colDonGia.ReadOnly = True

            colTrangThai.DataPropertyName = "TrangThaiText"
            colTrangThai.FillWeight = 16.0F
            colTrangThai.HeaderText = "Trạng thái"
            colTrangThai.Name = "colTrangThai"
            colTrangThai.ReadOnly = True

            ' Z-Order chuẩn trong pnlGridCard: Fill ở Index 0, Top ở Index 1 & 2
            pnlGridCard.Controls.Add(dgvMonAn)
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
            ClientSize = New System.Drawing.Size(1120, 680)
            Controls.Add(tlpMainContent)
            Controls.Add(tlpKpiRow)
            Controls.Add(pnlHeader)
            Font = New System.Drawing.Font("Segoe UI", 9.0F)
            KeyPreview = True
            MinimumSize = New System.Drawing.Size(1020, 660)
            Name = "frmMonAn"
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Text = "Quản lý Món ăn & Thức uống — Quán Ăn Gia Đình Hương Việt"

            pnlHeader.ResumeLayout(False)
            pnlHeader.PerformLayout()
            pnlHeaderActions.ResumeLayout(False)
            tlpKpiRow.ResumeLayout(False)
            pnlKpiTongMon.ResumeLayout(False)
            pnlKpiTongMon.PerformLayout()
            pnlKpiConMon.ResumeLayout(False)
            pnlKpiConMon.PerformLayout()
            pnlKpiHetMon.ResumeLayout(False)
            pnlKpiHetMon.PerformLayout()
            tlpMainContent.ResumeLayout(False)
            pnlFormCard.ResumeLayout(False)
            pnlFormCard.PerformLayout()
            CType(nudDonGia, System.ComponentModel.ISupportInitialize).EndInit()
            pnlTrangThaiBox.ResumeLayout(False)
            pnlTrangThaiBox.PerformLayout()
            tlpButtons.ResumeLayout(False)
            pnlGridCard.ResumeLayout(False)
            pnlSearchBar.ResumeLayout(False)
            pnlSearchBar.PerformLayout()
            CType(dgvMonAn, System.ComponentModel.ISupportInitialize).EndInit()
            ResumeLayout(False)
        End Sub
    End Class
End Namespace
