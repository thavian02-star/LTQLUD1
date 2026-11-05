Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Shift

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmCaLamViec
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
        Friend WithEvents pnlKpiTongCa As Panel
        Friend WithEvents lblKpiTongCaTitle As Label
        Friend WithEvents lblKpiTongCaVal As Label
        Friend WithEvents pnlKpiTongGio As Panel
        Friend WithEvents lblKpiTongGioTitle As Label
        Friend WithEvents lblKpiTongGioVal As Label
        Friend WithEvents pnlKpiLuongTB As Panel
        Friend WithEvents lblKpiLuongTBTitle As Label
        Friend WithEvents lblKpiLuongTBVal As Label

        Friend WithEvents tlpMainContent As TableLayoutPanel

        ' Cột trái (38%) - Biểu mẫu Chi tiết Ca làm việc
        Friend WithEvents pnlFormCard As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblModeBadge As Label
        Friend WithEvents lblThongBao As Label
        Friend WithEvents lblMaCa As Label
        Friend WithEvents txtMaCa As TextBox
        Friend WithEvents lblTenCa As Label
        Friend WithEvents txtTenCa As TextBox
        Friend WithEvents lblGioBatDau As Label
        Friend WithEvents dtpGioBatDau As DateTimePicker
        Friend WithEvents lblGioKetThuc As Label
        Friend WithEvents dtpGioKetThuc As DateTimePicker
        Friend WithEvents pnlThoiLuongBadge As Panel
        Friend WithEvents lblThoiLuong As Label
        Friend WithEvents lblLuongMoiCa As Label
        Friend WithEvents nudLuongMoiCa As NumericUpDown

        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnCapNhat As Button
        Friend WithEvents btnXoa As Button
        Friend WithEvents btnLamMoi As Button

        ' Cột phải (62%) - Danh sách Ca làm việc + Thanh tìm kiếm
        Friend WithEvents pnlGridCard As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlSearchBar As Panel
        Friend WithEvents lblTimKiem As Label
        Friend WithEvents txtTimKiem As TextBox
        Friend WithEvents btnTimKiem As Button
        Friend WithEvents btnTaiLai As Button
        Friend WithEvents dgvCaLamViec As DataGridView
        Friend WithEvents colMaCa As DataGridViewTextBoxColumn
        Friend WithEvents colTenCa As DataGridViewTextBoxColumn
        Friend WithEvents colKhungGio As DataGridViewTextBoxColumn
        Friend WithEvents colSoGio As DataGridViewTextBoxColumn
        Friend WithEvents colLuongMoiCa As DataGridViewTextBoxColumn
        Friend WithEvents colSoLuotXep As DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnDong = New Button()

            Me.tlpKpiRow = New TableLayoutPanel()
            Me.pnlKpiTongCa = New Panel()
            Me.lblKpiTongCaTitle = New Label()
            Me.lblKpiTongCaVal = New Label()
            Me.pnlKpiTongGio = New Panel()
            Me.lblKpiTongGioTitle = New Label()
            Me.lblKpiTongGioVal = New Label()
            Me.pnlKpiLuongTB = New Panel()
            Me.lblKpiLuongTBTitle = New Label()
            Me.lblKpiLuongTBVal = New Label()

            Me.tlpMainContent = New TableLayoutPanel()

            Me.pnlFormCard = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblModeBadge = New Label()
            Me.lblThongBao = New Label()
            Me.lblMaCa = New Label()
            Me.txtMaCa = New TextBox()
            Me.lblTenCa = New Label()
            Me.txtTenCa = New TextBox()
            Me.lblGioBatDau = New Label()
            Me.dtpGioBatDau = New DateTimePicker()
            Me.lblGioKetThuc = New Label()
            Me.dtpGioKetThuc = New DateTimePicker()
            Me.pnlThoiLuongBadge = New Panel()
            Me.lblThoiLuong = New Label()
            Me.lblLuongMoiCa = New Label()
            Me.nudLuongMoiCa = New NumericUpDown()

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
            Me.dgvCaLamViec = New DataGridView()
            Me.colMaCa = New DataGridViewTextBoxColumn()
            Me.colTenCa = New DataGridViewTextBoxColumn()
            Me.colKhungGio = New DataGridViewTextBoxColumn()
            Me.colSoGio = New DataGridViewTextBoxColumn()
            Me.colLuongMoiCa = New DataGridViewTextBoxColumn()
            Me.colSoLuotXep = New DataGridViewTextBoxColumn()

            Me.pnlHeader.SuspendLayout()
            Me.tlpKpiRow.SuspendLayout()
            Me.pnlKpiTongCa.SuspendLayout()
            Me.pnlKpiTongGio.SuspendLayout()
            Me.pnlKpiLuongTB.SuspendLayout()
            Me.tlpMainContent.SuspendLayout()
            Me.pnlFormCard.SuspendLayout()
            Me.pnlThoiLuongBadge.SuspendLayout()
            CType(Me.nudLuongMoiCa, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tlpButtons.SuspendLayout()
            Me.pnlGridCard.SuspendLayout()
            Me.pnlSearchBar.SuspendLayout()
            CType(Me.dgvCaLamViec, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.lblTitle.Text = "⏰ QUẢN LÝ DANH SÁCH CA LÀM VIỆC"

            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.lblSubtitle.ForeColor = Color.FromArgb(212, 230, 241)
            Me.lblSubtitle.Location = New Point(20, 39)
            Me.lblSubtitle.Text = "Danh mục chuẩn (3/5) • Cấu hình khung giờ hoạt động, tính thời lượng tự động và định mức lương mỗi ca"

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

            ' KPI 1: Tổng số ca hoạt động
            Me.pnlKpiTongCa.BackColor = Color.White
            Me.pnlKpiTongCa.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongCa.Dock = DockStyle.Fill
            Me.pnlKpiTongCa.Margin = New Padding(0, 0, 8, 0)
            Me.lblKpiTongCaTitle.AutoSize = True
            Me.lblKpiTongCaTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiTongCaTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongCaTitle.Location = New Point(12, 8)
            Me.lblKpiTongCaTitle.Text = "TỔNG SỐ CA HOẠT ĐỘNG"
            Me.lblKpiTongCaVal.AutoSize = True
            Me.lblKpiTongCaVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiTongCaVal.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblKpiTongCaVal.Location = New Point(12, 28)
            Me.lblKpiTongCaVal.Text = "0 ca làm việc"
            Me.pnlKpiTongCa.Controls.Add(Me.lblKpiTongCaVal)
            Me.pnlKpiTongCa.Controls.Add(Me.lblKpiTongCaTitle)

            ' KPI 2: Tổng thời lượng mở cửa / ngày
            Me.pnlKpiTongGio.BackColor = Color.White
            Me.pnlKpiTongGio.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiTongGio.Dock = DockStyle.Fill
            Me.pnlKpiTongGio.Margin = New Padding(4, 0, 4, 0)
            Me.lblKpiTongGioTitle.AutoSize = True
            Me.lblKpiTongGioTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiTongGioTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiTongGioTitle.Location = New Point(12, 8)
            Me.lblKpiTongGioTitle.Text = "TỔNG THỜI LƯỢNG MỞ CỬA / NGÀY"
            Me.lblKpiTongGioVal.AutoSize = True
            Me.lblKpiTongGioVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiTongGioVal.ForeColor = Color.FromArgb(39, 174, 96)
            Me.lblKpiTongGioVal.Location = New Point(12, 28)
            Me.lblKpiTongGioVal.Text = "0.0 giờ / ngày"
            Me.pnlKpiTongGio.Controls.Add(Me.lblKpiTongGioVal)
            Me.pnlKpiTongGio.Controls.Add(Me.lblKpiTongGioTitle)

            ' KPI 3: Định mức lương TB / ca
            Me.pnlKpiLuongTB.BackColor = Color.White
            Me.pnlKpiLuongTB.BorderStyle = BorderStyle.FixedSingle
            Me.pnlKpiLuongTB.Dock = DockStyle.Fill
            Me.pnlKpiLuongTB.Margin = New Padding(8, 0, 0, 0)
            Me.lblKpiLuongTBTitle.AutoSize = True
            Me.lblKpiLuongTBTitle.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblKpiLuongTBTitle.ForeColor = Color.FromArgb(100, 116, 139)
            Me.lblKpiLuongTBTitle.Location = New Point(12, 8)
            Me.lblKpiLuongTBTitle.Text = "ĐỊNH MỨC LƯƠNG TB / CA"
            Me.lblKpiLuongTBVal.AutoSize = True
            Me.lblKpiLuongTBVal.Font = New Font("Segoe UI", 13.5!, FontStyle.Bold)
            Me.lblKpiLuongTBVal.ForeColor = Color.FromArgb(211, 84, 0)
            Me.lblKpiLuongTBVal.Location = New Point(12, 28)
            Me.lblKpiLuongTBVal.Text = "0 đ / ca"
            Me.pnlKpiLuongTB.Controls.Add(Me.lblKpiLuongTBVal)
            Me.pnlKpiLuongTB.Controls.Add(Me.lblKpiLuongTBTitle)

            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongCa, 0, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongGio, 1, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiLuongTB, 2, 0)

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
            ' 3A. CỘT TRÁI (38%): THÔNG TIN CA LÀM VIỆC
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
            Me.lblFormTitle.Text = "📝 THÔNG TIN CA LÀM VIỆC"

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
            Me.lblThongBao.Text = "💡 Chọn một ca bên phải để chỉnh sửa hoặc nhập ca mới."
            Me.lblThongBao.TextAlign = ContentAlignment.MiddleLeft

            ' Mã ca
            Me.lblMaCa.AutoSize = True
            Me.lblMaCa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblMaCa.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblMaCa.Location = New Point(16, 82)
            Me.lblMaCa.Text = "Mã ca làm việc (Tự động):"

            Me.txtMaCa.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtMaCa.BackColor = Color.FromArgb(238, 242, 246)
            Me.txtMaCa.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.txtMaCa.ForeColor = Color.FromArgb(93, 109, 126)
            Me.txtMaCa.Location = New Point(16, 102)
            Me.txtMaCa.ReadOnly = True
            Me.txtMaCa.Size = New Size(360, 26)
            Me.txtMaCa.Text = "(Tự động)"

            ' Tên ca làm việc
            Me.lblTenCa.AutoSize = True
            Me.lblTenCa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblTenCa.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblTenCa.Location = New Point(16, 134)
            Me.lblTenCa.Text = "Tên ca làm việc (*):"

            Me.txtTenCa.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTenCa.Font = New Font("Segoe UI", 9.75!, FontStyle.Regular)
            Me.txtTenCa.Location = New Point(16, 154)
            Me.txtTenCa.MaxLength = 50
            Me.txtTenCa.Size = New Size(360, 26)

            ' Giờ bắt đầu & Giờ kết thúc (2 cột song song)
            Me.lblGioBatDau.AutoSize = True
            Me.lblGioBatDau.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblGioBatDau.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblGioBatDau.Location = New Point(16, 186)
            Me.lblGioBatDau.Text = "Giờ bắt đầu (HH:mm) (*):"

            Me.dtpGioBatDau.CustomFormat = "HH:mm"
            Me.dtpGioBatDau.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.dtpGioBatDau.Format = DateTimePickerFormat.Custom
            Me.dtpGioBatDau.Location = New Point(16, 206)
            Me.dtpGioBatDau.ShowUpDown = True
            Me.dtpGioBatDau.Size = New Size(172, 27)
            Me.dtpGioBatDau.Value = New Date(2026, 1, 1, 8, 0, 0)

            Me.lblGioKetThuc.AutoSize = True
            Me.lblGioKetThuc.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblGioKetThuc.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblGioKetThuc.Location = New Point(204, 186)
            Me.lblGioKetThuc.Text = "Giờ kết thúc (HH:mm) (*):"

            Me.dtpGioKetThuc.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.dtpGioKetThuc.CustomFormat = "HH:mm"
            Me.dtpGioKetThuc.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.dtpGioKetThuc.Format = DateTimePickerFormat.Custom
            Me.dtpGioKetThuc.Location = New Point(204, 206)
            Me.dtpGioKetThuc.ShowUpDown = True
            Me.dtpGioKetThuc.Size = New Size(172, 27)
            Me.dtpGioKetThuc.Value = New Date(2026, 1, 1, 15, 0, 0)

            ' Badge Thời lượng ca tự động
            Me.pnlThoiLuongBadge.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.pnlThoiLuongBadge.BackColor = Color.FromArgb(244, 236, 247)
            Me.pnlThoiLuongBadge.BorderStyle = BorderStyle.FixedSingle
            Me.pnlThoiLuongBadge.Location = New Point(16, 240)
            Me.pnlThoiLuongBadge.Size = New Size(360, 32)

            Me.lblThoiLuong.Dock = DockStyle.Fill
            Me.lblThoiLuong.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblThoiLuong.ForeColor = Color.FromArgb(108, 52, 131)
            Me.lblThoiLuong.Text = "⏱️ Thời lượng ca: 7.0 giờ  |  📅 Chưa xếp lịch"
            Me.lblThoiLuong.TextAlign = ContentAlignment.MiddleCenter
            Me.pnlThoiLuongBadge.Controls.Add(Me.lblThoiLuong)

            ' Định mức lương mỗi ca (VNĐ)
            Me.lblLuongMoiCa.AutoSize = True
            Me.lblLuongMoiCa.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblLuongMoiCa.ForeColor = Color.FromArgb(52, 73, 94)
            Me.lblLuongMoiCa.Location = New Point(16, 278)
            Me.lblLuongMoiCa.Text = "Định mức lương mỗi ca (VNĐ) (*):"

            Me.nudLuongMoiCa.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.nudLuongMoiCa.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.nudLuongMoiCa.ForeColor = Color.FromArgb(192, 57, 43)
            Me.nudLuongMoiCa.Increment = New Decimal(New Integer() {10000, 0, 0, 0})
            Me.nudLuongMoiCa.Location = New Point(16, 298)
            Me.nudLuongMoiCa.Maximum = New Decimal(New Integer() {100000000, 0, 0, 0})
            Me.nudLuongMoiCa.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
            Me.nudLuongMoiCa.Size = New Size(360, 27)
            Me.nudLuongMoiCa.ThousandsSeparator = True
            Me.nudLuongMoiCa.Value = New Decimal(New Integer() {180000, 0, 0, 0})

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
            Me.btnXoa.Text = "🗑️ Xóa ca"
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
            Me.pnlFormCard.Controls.Add(Me.nudLuongMoiCa)
            Me.pnlFormCard.Controls.Add(Me.lblLuongMoiCa)
            Me.pnlFormCard.Controls.Add(Me.pnlThoiLuongBadge)
            Me.pnlFormCard.Controls.Add(Me.dtpGioKetThuc)
            Me.pnlFormCard.Controls.Add(Me.lblGioKetThuc)
            Me.pnlFormCard.Controls.Add(Me.dtpGioBatDau)
            Me.pnlFormCard.Controls.Add(Me.lblGioBatDau)
            Me.pnlFormCard.Controls.Add(Me.txtTenCa)
            Me.pnlFormCard.Controls.Add(Me.lblTenCa)
            Me.pnlFormCard.Controls.Add(Me.txtMaCa)
            Me.pnlFormCard.Controls.Add(Me.lblMaCa)
            Me.pnlFormCard.Controls.Add(Me.lblThongBao)
            Me.pnlFormCard.Controls.Add(Me.lblModeBadge)
            Me.pnlFormCard.Controls.Add(Me.lblFormTitle)

            ' --------------------------------------------------------------
            ' 3B. CỘT PHẢI (62%): DANH SÁCH CA LÀM VIỆC & TÌM KIẾM
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
            Me.lblGridTitle.Text = "📋 DANH SÁCH CA LÀM VIỆC TRONG NGÀY (Click chọn dòng để xem / sửa)"

            Me.pnlSearchBar.BackColor = Color.FromArgb(240, 243, 246)
            Me.pnlSearchBar.Dock = DockStyle.Top
            Me.pnlSearchBar.Height = 46
            Me.pnlSearchBar.Padding = New Padding(10, 8, 10, 8)

            Me.lblTimKiem.AutoSize = True
            Me.lblTimKiem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.lblTimKiem.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblTimKiem.Location = New Point(10, 14)
            Me.lblTimKiem.Text = "🔍 Tìm tên ca:"

            Me.txtTimKiem.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTimKiem.Font = New Font("Segoe UI", 9.5!, FontStyle.Regular)
            Me.txtTimKiem.Location = New Point(106, 10)
            Me.txtTimKiem.PlaceholderText = "Nhập tên ca (VD: Ca Sáng, Ca Chiều)..."
            Me.txtTimKiem.Size = New Size(310, 26)

            Me.btnTimKiem.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTimKiem.BackColor = Color.FromArgb(26, 82, 118)
            Me.btnTimKiem.Cursor = Cursors.Hand
            Me.btnTimKiem.FlatAppearance.BorderSize = 0
            Me.btnTimKiem.FlatStyle = FlatStyle.Flat
            Me.btnTimKiem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnTimKiem.ForeColor = Color.White
            Me.btnTimKiem.Location = New Point(424, 9)
            Me.btnTimKiem.Size = New Size(76, 28)
            Me.btnTimKiem.Text = "Tìm"
            Me.btnTimKiem.UseVisualStyleBackColor = False

            Me.btnTaiLai.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTaiLai.BackColor = Color.FromArgb(93, 109, 126)
            Me.btnTaiLai.Cursor = Cursors.Hand
            Me.btnTaiLai.FlatAppearance.BorderSize = 0
            Me.btnTaiLai.FlatStyle = FlatStyle.Flat
            Me.btnTaiLai.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnTaiLai.ForeColor = Color.White
            Me.btnTaiLai.Location = New Point(506, 9)
            Me.btnTaiLai.Size = New Size(86, 28)
            Me.btnTaiLai.Text = "↻ Tải lại"
            Me.btnTaiLai.UseVisualStyleBackColor = False

            Me.pnlSearchBar.Controls.Add(Me.btnTaiLai)
            Me.pnlSearchBar.Controls.Add(Me.btnTimKiem)
            Me.pnlSearchBar.Controls.Add(Me.txtTimKiem)
            Me.pnlSearchBar.Controls.Add(Me.lblTimKiem)

            ' DataGridView Danh sách ca (6 cột)
            Me.dgvCaLamViec.AllowUserToAddRows = False
            Me.dgvCaLamViec.AllowUserToDeleteRows = False
            Me.dgvCaLamViec.AllowUserToResizeRows = False
            Me.dgvCaLamViec.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvCaLamViec.BackgroundColor = Color.White
            Me.dgvCaLamViec.BorderStyle = BorderStyle.FixedSingle
            Me.dgvCaLamViec.ColumnHeadersHeight = 38
            Me.dgvCaLamViec.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            Me.dgvCaLamViec.Dock = DockStyle.Fill
            Me.dgvCaLamViec.EnableHeadersVisualStyles = False
            Me.dgvCaLamViec.MultiSelect = False
            Me.dgvCaLamViec.ReadOnly = True
            Me.dgvCaLamViec.RowHeadersVisible = False
            Me.dgvCaLamViec.RowTemplate.Height = 36
            Me.dgvCaLamViec.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Me.colMaCa.DataPropertyName = "MaCa"
            Me.colMaCa.FillWeight = 11.0!
            Me.colMaCa.HeaderText = "Mã ca"
            Me.colMaCa.Name = "colMaCa"

            Me.colTenCa.DataPropertyName = "TenCa"
            Me.colTenCa.FillWeight = 29.0!
            Me.colTenCa.HeaderText = "Tên ca làm việc"
            Me.colTenCa.Name = "colTenCa"

            Me.colKhungGio.DataPropertyName = "KhungGioText"
            Me.colKhungGio.FillWeight = 18.0!
            Me.colKhungGio.HeaderText = "Khung giờ"
            Me.colKhungGio.Name = "colKhungGio"

            Me.colSoGio.DataPropertyName = "SoGioText"
            Me.colSoGio.FillWeight = 13.0!
            Me.colSoGio.HeaderText = "Thời lượng"
            Me.colSoGio.Name = "colSoGio"

            Me.colLuongMoiCa.DataPropertyName = "LuongMoiCaText"
            Me.colLuongMoiCa.FillWeight = 16.0!
            Me.colLuongMoiCa.HeaderText = "Lương / ca"
            Me.colLuongMoiCa.Name = "colLuongMoiCa"

            Me.colSoLuotXep.DataPropertyName = "SoLuotXepText"
            Me.colSoLuotXep.FillWeight = 13.0!
            Me.colSoLuotXep.HeaderText = "Lịch đã xếp"
            Me.colSoLuotXep.Name = "colSoLuotXep"

            Me.dgvCaLamViec.Columns.AddRange(New DataGridViewColumn() {
                Me.colMaCa, Me.colTenCa, Me.colKhungGio, Me.colSoGio, Me.colLuongMoiCa, Me.colSoLuotXep
            })

            ' Z-Order chuẩn trong pnlGridCard: Fill (0) -> Top (1, 2)
            Me.pnlGridCard.Controls.Add(Me.dgvCaLamViec)
            Me.pnlGridCard.Controls.Add(Me.pnlSearchBar)
            Me.pnlGridCard.Controls.Add(Me.lblGridTitle)

            Me.tlpMainContent.Controls.Add(Me.pnlFormCard, 0, 0)
            Me.tlpMainContent.Controls.Add(Me.pnlGridCard, 1, 0)

            ' ==============================================================
            ' CẤU HÌNH FORM CHÍNH (Z-Order: Fill -> Top -> Top)
            ' ==============================================================
            Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.FromArgb(245, 247, 250)
            Me.ClientSize = New Size(1080, 660)
            Me.Controls.Add(Me.tlpMainContent)
            Me.Controls.Add(Me.tlpKpiRow)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.KeyPreview = True
            Me.MinimumSize = New Size(1000, 640)
            Me.Name = "frmCaLamViec"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Quản Lý Danh Sách Ca Làm Việc - Quán Ăn Hương Việt"

            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tlpKpiRow.ResumeLayout(False)
            Me.pnlKpiTongCa.ResumeLayout(False)
            Me.pnlKpiTongCa.PerformLayout()
            Me.pnlKpiTongGio.ResumeLayout(False)
            Me.pnlKpiTongGio.PerformLayout()
            Me.pnlKpiLuongTB.ResumeLayout(False)
            Me.pnlKpiLuongTB.PerformLayout()
            Me.tlpMainContent.ResumeLayout(False)
            Me.pnlFormCard.ResumeLayout(False)
            Me.pnlFormCard.PerformLayout()
            Me.pnlThoiLuongBadge.ResumeLayout(False)
            CType(Me.nudLuongMoiCa, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tlpButtons.ResumeLayout(False)
            Me.pnlGridCard.ResumeLayout(False)
            Me.pnlSearchBar.ResumeLayout(False)
            Me.pnlSearchBar.PerformLayout()
            CType(Me.dgvCaLamViec, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

    End Class

End Namespace
