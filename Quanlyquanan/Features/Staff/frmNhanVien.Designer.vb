Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Staff

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmNhanVien
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
        ' KHAI BÁO CÁC CONTROLS GIAO DIỆN (3 TẦNG + SPLIT-LAYOUT 42:58)
        ' ==============================================================
        Friend WithEvents pnlHeader As Panel
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents btnDong As Button

        Friend WithEvents tlpKpiRow As TableLayoutPanel
        Friend WithEvents pnlKpiTongNV As Panel
        Friend WithEvents lblKpiTongNVTitle As Label
        Friend WithEvents lblKpiTongNVVal As Label
        Friend WithEvents pnlKpiDangLam As Panel
        Friend WithEvents lblKpiDangLamTitle As Label
        Friend WithEvents lblKpiDangLamVal As Label
        Friend WithEvents pnlKpiNghiViec As Panel
        Friend WithEvents lblKpiNghiViecTitle As Label
        Friend WithEvents lblKpiNghiViecVal As Label
        Friend WithEvents pnlKpiCoTaiKhoan As Panel
        Friend WithEvents lblKpiCoTaiKhoanTitle As Label
        Friend WithEvents lblKpiCoTaiKhoanVal As Label

        Friend WithEvents tlpMainContent As TableLayoutPanel

        ' Cột trái (42%) - Biểu mẫu Hồ sơ Nhân sự
        Friend WithEvents pnlFormCard As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblModeBadge As Label
        Friend WithEvents lblThongBao As Label

        ' Hàng 1: Mã NV + Họ tên
        Friend WithEvents lblMaNV As Label
        Friend WithEvents txtMaNV As TextBox
        Friend WithEvents lblHoTen As Label
        Friend WithEvents txtHoTen As TextBox

        ' Hàng 2: Giới tính + Ngày sinh
        Friend WithEvents lblGioiTinh As Label
        Friend WithEvents pnlGioiTinh As Panel
        Friend WithEvents rdoNam As RadioButton
        Friend WithEvents rdoNu As RadioButton
        Friend WithEvents lblNgaySinh As Label
        Friend WithEvents dtpNgaySinh As DateTimePicker

        ' Hàng 3: Vị trí + Số CCCD
        Friend WithEvents lblViTri As Label
        Friend WithEvents cboViTri As ComboBox
        Friend WithEvents lblCMND As Label
        Friend WithEvents txtCMND As TextBox

        ' Hàng 4: Điện thoại + Email
        Friend WithEvents lblDienThoai As Label
        Friend WithEvents txtDienThoai As TextBox
        Friend WithEvents lblEmail As Label
        Friend WithEvents txtEmail As TextBox

        ' Hàng 5: Địa chỉ
        Friend WithEvents lblDiaChi As Label
        Friend WithEvents txtDiaChi As TextBox

        ' Hàng 6: Học vấn + Tài khoản
        Friend WithEvents lblHocVan As Label
        Friend WithEvents cboHocVan As ComboBox
        Friend WithEvents lblTaiKhoan As Label
        Friend WithEvents cboTaiKhoan As ComboBox

        ' Hàng 7: Trạng thái + Kỹ năng vi tính
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents lblViTinh As Label
        Friend WithEvents clbViTinh As CheckedListBox

        ' Hàng 8: Badge Đồng phục & Tài khoản
        Friend WithEvents pnlUniformBadge As Panel
        Friend WithEvents lblUniformInfo As Label

        ' Cụm 4 nút CRUD
        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnCapNhat As Button
        Friend WithEvents btnThoiViec As Button
        Friend WithEvents btnLamMoi As Button

        ' Cột phải (58%) - Bảng danh sách & Bộ lọc
        Friend WithEvents pnlGridCard As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlFilterBar As Panel
        Friend WithEvents lblLocViTri As Label
        Friend WithEvents cboLocViTri As ComboBox
        Friend WithEvents lblLocTrangThai As Label
        Friend WithEvents cboLocTrangThai As ComboBox
        Friend WithEvents txtTimKiem As TextBox
        Friend WithEvents btnTaiLai As Button
        Friend WithEvents dgvNhanVien As DataGridView

        ' 8 Cột trên DataGridView
        Friend WithEvents colMaNV As DataGridViewTextBoxColumn
        Friend WithEvents colHoTen As DataGridViewTextBoxColumn
        Friend WithEvents colGioiTinh As DataGridViewTextBoxColumn
        Friend WithEvents colViTri As DataGridViewTextBoxColumn
        Friend WithEvents colDienThoai As DataGridViewTextBoxColumn
        Friend WithEvents colCMND As DataGridViewTextBoxColumn
        Friend WithEvents colTrangThai As DataGridViewTextBoxColumn
        Friend WithEvents colTaiKhoan As DataGridViewTextBoxColumn

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim dgvCellStyleHeader As New DataGridViewCellStyle()
            Dim dgvCellStyleRow As New DataGridViewCellStyle()

            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnDong = New Button()

            Me.tlpKpiRow = New TableLayoutPanel()
            Me.pnlKpiTongNV = New Panel()
            Me.lblKpiTongNVTitle = New Label()
            Me.lblKpiTongNVVal = New Label()
            Me.pnlKpiDangLam = New Panel()
            Me.lblKpiDangLamTitle = New Label()
            Me.lblKpiDangLamVal = New Label()
            Me.pnlKpiNghiViec = New Panel()
            Me.lblKpiNghiViecTitle = New Label()
            Me.lblKpiNghiViecVal = New Label()
            Me.pnlKpiCoTaiKhoan = New Panel()
            Me.lblKpiCoTaiKhoanTitle = New Label()
            Me.lblKpiCoTaiKhoanVal = New Label()

            Me.tlpMainContent = New TableLayoutPanel()

            ' Cột trái
            Me.pnlFormCard = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblModeBadge = New Label()
            Me.lblThongBao = New Label()

            Me.lblMaNV = New Label()
            Me.txtMaNV = New TextBox()
            Me.lblHoTen = New Label()
            Me.txtHoTen = New TextBox()

            Me.lblGioiTinh = New Label()
            Me.pnlGioiTinh = New Panel()
            Me.rdoNam = New RadioButton()
            Me.rdoNu = New RadioButton()
            Me.lblNgaySinh = New Label()
            Me.dtpNgaySinh = New DateTimePicker()

            Me.lblViTri = New Label()
            Me.cboViTri = New ComboBox()
            Me.lblCMND = New Label()
            Me.txtCMND = New TextBox()

            Me.lblDienThoai = New Label()
            Me.txtDienThoai = New TextBox()
            Me.lblEmail = New Label()
            Me.txtEmail = New TextBox()

            Me.lblDiaChi = New Label()
            Me.txtDiaChi = New TextBox()

            Me.lblHocVan = New Label()
            Me.cboHocVan = New ComboBox()
            Me.lblTaiKhoan = New Label()
            Me.cboTaiKhoan = New ComboBox()
            Me.lblTrangThai = New Label()
            Me.cboTrangThai = New ComboBox()

            Me.lblViTinh = New Label()
            Me.clbViTinh = New CheckedListBox()

            Me.pnlUniformBadge = New Panel()
            Me.lblUniformInfo = New Label()

            Me.tlpButtons = New TableLayoutPanel()
            Me.btnThem = New Button()
            Me.btnCapNhat = New Button()
            Me.btnThoiViec = New Button()
            Me.btnLamMoi = New Button()

            ' Cột phải
            Me.pnlGridCard = New Panel()
            Me.lblGridTitle = New Label()
            Me.pnlFilterBar = New Panel()
            Me.lblLocViTri = New Label()
            Me.cboLocViTri = New ComboBox()
            Me.lblLocTrangThai = New Label()
            Me.cboLocTrangThai = New ComboBox()
            Me.txtTimKiem = New TextBox()
            Me.btnTaiLai = New Button()
            Me.dgvNhanVien = New DataGridView()

            Me.colMaNV = New DataGridViewTextBoxColumn()
            Me.colHoTen = New DataGridViewTextBoxColumn()
            Me.colGioiTinh = New DataGridViewTextBoxColumn()
            Me.colViTri = New DataGridViewTextBoxColumn()
            Me.colDienThoai = New DataGridViewTextBoxColumn()
            Me.colCMND = New DataGridViewTextBoxColumn()
            Me.colTrangThai = New DataGridViewTextBoxColumn()
            Me.colTaiKhoan = New DataGridViewTextBoxColumn()

            Me.pnlHeader.SuspendLayout()
            Me.tlpKpiRow.SuspendLayout()
            Me.pnlKpiTongNV.SuspendLayout()
            Me.pnlKpiDangLam.SuspendLayout()
            Me.pnlKpiNghiViec.SuspendLayout()
            Me.pnlKpiCoTaiKhoan.SuspendLayout()
            Me.tlpMainContent.SuspendLayout()
            Me.pnlFormCard.SuspendLayout()
            Me.pnlGioiTinh.SuspendLayout()
            Me.pnlUniformBadge.SuspendLayout()
            Me.tlpButtons.SuspendLayout()
            Me.pnlGridCard.SuspendLayout()
            Me.pnlFilterBar.SuspendLayout()
            CType(Me.dgvNhanVien, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()

            ' ==========================================================
            ' 1. TẦNG HEADER (Top 68px, Navy)
            ' ==========================================================
            Me.pnlHeader.BackColor = Color.FromArgb(26, 82, 118)
            Me.pnlHeader.Controls.Add(Me.lblTitle)
            Me.pnlHeader.Controls.Add(Me.lblSubtitle)
            Me.pnlHeader.Controls.Add(Me.btnDong)
            Me.pnlHeader.Dock = DockStyle.Top
            Me.pnlHeader.Location = New Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New Size(1160, 68)
            Me.pnlHeader.TabIndex = 0

            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            Me.lblTitle.ForeColor = Color.White
            Me.lblTitle.Location = New Point(18, 11)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New Size(390, 28)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "👥 QUẢN LÝ DANH SÁCH NHÂN SỰ"

            Me.lblSubtitle.AutoSize = True
            Me.lblSubtitle.Font = New Font("Segoe UI", 8.8!)
            Me.lblSubtitle.ForeColor = Color.FromArgb(174, 214, 241)
            Me.lblSubtitle.Location = New Point(21, 40)
            Me.lblSubtitle.Name = "lblSubtitle"
            Me.lblSubtitle.Size = New Size(620, 15)
            Me.lblSubtitle.TabIndex = 1
            Me.lblSubtitle.Text = "Danh mục chuẩn (6/9) • Hồ sơ nhân viên, vị trí, kỹ năng vi tính, cấp phát đồng phục & tài khoản đăng nhập"

            Me.btnDong.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnDong.BackColor = Color.FromArgb(192, 57, 43)
            Me.btnDong.Cursor = Cursors.Hand
            Me.btnDong.FlatAppearance.BorderSize = 0
            Me.btnDong.FlatStyle = FlatStyle.Flat
            Me.btnDong.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
            Me.btnDong.ForeColor = Color.White
            Me.btnDong.Location = New Point(1055, 17)
            Me.btnDong.Name = "btnDong"
            Me.btnDong.Size = New Size(88, 34)
            Me.btnDong.TabIndex = 2
            Me.btnDong.Text = "✖ Đóng"
            Me.btnDong.UseVisualStyleBackColor = False

            ' ==========================================================
            ' 2. TẦNG KPI CARDS (Top 78px, 4 Thẻ 25%)
            ' ==========================================================
            Me.tlpKpiRow.ColumnCount = 4
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiTongNV, 0, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiDangLam, 1, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiNghiViec, 2, 0)
            Me.tlpKpiRow.Controls.Add(Me.pnlKpiCoTaiKhoan, 3, 0)
            Me.tlpKpiRow.Dock = DockStyle.Top
            Me.tlpKpiRow.Location = New Point(0, 68)
            Me.tlpKpiRow.Name = "tlpKpiRow"
            Me.tlpKpiRow.Padding = New Padding(12, 8, 12, 6)
            Me.tlpKpiRow.RowCount = 1
            Me.tlpKpiRow.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpKpiRow.Size = New Size(1160, 78)
            Me.tlpKpiRow.TabIndex = 1

            ' KPI 1: Tổng nhân viên
            Me.pnlKpiTongNV.BackColor = Color.White
            Me.pnlKpiTongNV.Controls.Add(Me.lblKpiTongNVVal)
            Me.pnlKpiTongNV.Controls.Add(Me.lblKpiTongNVTitle)
            Me.pnlKpiTongNV.Dock = DockStyle.Fill
            Me.pnlKpiTongNV.Location = New Point(15, 11)
            Me.pnlKpiTongNV.Name = "pnlKpiTongNV"
            Me.pnlKpiTongNV.Padding = New Padding(10, 6, 10, 6)
            Me.pnlKpiTongNV.Size = New Size(269, 58)
            Me.pnlKpiTongNV.TabIndex = 0

            Me.lblKpiTongNVTitle.AutoSize = True
            Me.lblKpiTongNVTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiTongNVTitle.ForeColor = Color.FromArgb(108, 117, 125)
            Me.lblKpiTongNVTitle.Location = New Point(10, 7)
            Me.lblKpiTongNVTitle.Name = "lblKpiTongNVTitle"
            Me.lblKpiTongNVTitle.Size = New Size(115, 13)
            Me.lblKpiTongNVTitle.TabIndex = 0
            Me.lblKpiTongNVTitle.Text = "TỔNG SỐ NHÂN VIÊN"

            Me.lblKpiTongNVVal.AutoSize = True
            Me.lblKpiTongNVVal.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            Me.lblKpiTongNVVal.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblKpiTongNVVal.Location = New Point(9, 22)
            Me.lblKpiTongNVVal.Name = "lblKpiTongNVVal"
            Me.lblKpiTongNVVal.Size = New Size(89, 28)
            Me.lblKpiTongNVVal.TabIndex = 1
            Me.lblKpiTongNVVal.Text = "7 người"

            ' KPI 2: Đang làm việc
            Me.pnlKpiDangLam.BackColor = Color.White
            Me.pnlKpiDangLam.Controls.Add(Me.lblKpiDangLamVal)
            Me.pnlKpiDangLam.Controls.Add(Me.lblKpiDangLamTitle)
            Me.pnlKpiDangLam.Dock = DockStyle.Fill
            Me.pnlKpiDangLam.Location = New Point(299, 11)
            Me.pnlKpiDangLam.Name = "pnlKpiDangLam"
            Me.pnlKpiDangLam.Padding = New Padding(10, 6, 10, 6)
            Me.pnlKpiDangLam.Size = New Size(269, 58)
            Me.pnlKpiDangLam.TabIndex = 1

            Me.lblKpiDangLamTitle.AutoSize = True
            Me.lblKpiDangLamTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiDangLamTitle.ForeColor = Color.FromArgb(108, 117, 125)
            Me.lblKpiDangLamTitle.Location = New Point(10, 7)
            Me.lblKpiDangLamTitle.Name = "lblKpiDangLamTitle"
            Me.lblKpiDangLamTitle.Size = New Size(94, 13)
            Me.lblKpiDangLamTitle.TabIndex = 0
            Me.lblKpiDangLamTitle.Text = "ĐANG LÀM VIỆC"

            Me.lblKpiDangLamVal.AutoSize = True
            Me.lblKpiDangLamVal.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            Me.lblKpiDangLamVal.ForeColor = Color.FromArgb(39, 174, 96)
            Me.lblKpiDangLamVal.Location = New Point(9, 22)
            Me.lblKpiDangLamVal.Name = "lblKpiDangLamVal"
            Me.lblKpiDangLamVal.Size = New Size(89, 28)
            Me.lblKpiDangLamVal.TabIndex = 1
            Me.lblKpiDangLamVal.Text = "6 người"

            ' KPI 3: Đã nghỉ việc
            Me.pnlKpiNghiViec.BackColor = Color.White
            Me.pnlKpiNghiViec.Controls.Add(Me.lblKpiNghiViecVal)
            Me.pnlKpiNghiViec.Controls.Add(Me.lblKpiNghiViecTitle)
            Me.pnlKpiNghiViec.Dock = DockStyle.Fill
            Me.pnlKpiNghiViec.Location = New Point(583, 11)
            Me.pnlKpiNghiViec.Name = "pnlKpiNghiViec"
            Me.pnlKpiNghiViec.Padding = New Padding(10, 6, 10, 6)
            Me.pnlKpiNghiViec.Size = New Size(269, 58)
            Me.pnlKpiNghiViec.TabIndex = 2

            Me.lblKpiNghiViecTitle.AutoSize = True
            Me.lblKpiNghiViecTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiNghiViecTitle.ForeColor = Color.FromArgb(108, 117, 125)
            Me.lblKpiNghiViecTitle.Location = New Point(10, 7)
            Me.lblKpiNghiViecTitle.Name = "lblKpiNghiViecTitle"
            Me.lblKpiNghiViecTitle.Size = New Size(84, 13)
            Me.lblKpiNghiViecTitle.TabIndex = 0
            Me.lblKpiNghiViecTitle.Text = "ĐÃ NGHỈ VIỆC"

            Me.lblKpiNghiViecVal.AutoSize = True
            Me.lblKpiNghiViecVal.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            Me.lblKpiNghiViecVal.ForeColor = Color.FromArgb(230, 126, 34)
            Me.lblKpiNghiViecVal.Location = New Point(9, 22)
            Me.lblKpiNghiViecVal.Name = "lblKpiNghiViecVal"
            Me.lblKpiNghiViecVal.Size = New Size(80, 28)
            Me.lblKpiNghiViecVal.TabIndex = 1
            Me.lblKpiNghiViecVal.Text = "1 người"

            ' KPI 4: Đã cấp tài khoản
            Me.pnlKpiCoTaiKhoan.BackColor = Color.White
            Me.pnlKpiCoTaiKhoan.Controls.Add(Me.lblKpiCoTaiKhoanVal)
            Me.pnlKpiCoTaiKhoan.Controls.Add(Me.lblKpiCoTaiKhoanTitle)
            Me.pnlKpiCoTaiKhoan.Dock = DockStyle.Fill
            Me.pnlKpiCoTaiKhoan.Location = New Point(867, 11)
            Me.pnlKpiCoTaiKhoan.Name = "pnlKpiCoTaiKhoan"
            Me.pnlKpiCoTaiKhoan.Padding = New Padding(10, 6, 10, 6)
            Me.pnlKpiCoTaiKhoan.Size = New Size(270, 58)
            Me.pnlKpiCoTaiKhoan.TabIndex = 3

            Me.lblKpiCoTaiKhoanTitle.AutoSize = True
            Me.lblKpiCoTaiKhoanTitle.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblKpiCoTaiKhoanTitle.ForeColor = Color.FromArgb(108, 117, 125)
            Me.lblKpiCoTaiKhoanTitle.Location = New Point(10, 7)
            Me.lblKpiCoTaiKhoanTitle.Name = "lblKpiCoTaiKhoanTitle"
            Me.lblKpiCoTaiKhoanTitle.Size = New Size(111, 13)
            Me.lblKpiCoTaiKhoanTitle.TabIndex = 0
            Me.lblKpiCoTaiKhoanTitle.Text = "ĐÃ CẤP TÀI KHOẢN"

            Me.lblKpiCoTaiKhoanVal.AutoSize = True
            Me.lblKpiCoTaiKhoanVal.Font = New Font("Segoe UI", 15.0!, FontStyle.Bold)
            Me.lblKpiCoTaiKhoanVal.ForeColor = Color.FromArgb(142, 68, 173)
            Me.lblKpiCoTaiKhoanVal.Location = New Point(9, 22)
            Me.lblKpiCoTaiKhoanVal.Name = "lblKpiCoTaiKhoanVal"
            Me.lblKpiCoTaiKhoanVal.Size = New Size(89, 28)
            Me.lblKpiCoTaiKhoanVal.TabIndex = 1
            Me.lblKpiCoTaiKhoanVal.Text = "6 người"

            ' ==========================================================
            ' 3. TẦNG MAIN CONTENT (Split-Layout 42% : 58%)
            ' ==========================================================
            Me.tlpMainContent.ColumnCount = 2
            Me.tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 42.0!))
            Me.tlpMainContent.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 58.0!))
            Me.tlpMainContent.Controls.Add(Me.pnlFormCard, 0, 0)
            Me.tlpMainContent.Controls.Add(Me.pnlGridCard, 1, 0)
            Me.tlpMainContent.Dock = DockStyle.Fill
            Me.tlpMainContent.Location = New Point(0, 146)
            Me.tlpMainContent.Name = "tlpMainContent"
            Me.tlpMainContent.Padding = New Padding(12, 6, 12, 12)
            Me.tlpMainContent.RowCount = 1
            Me.tlpMainContent.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpMainContent.Size = New Size(1160, 554)
            Me.tlpMainContent.TabIndex = 2

            ' ----------------------------------------------------------
            ' 3.1. CỘT TRÁI (42%): BIỂU MẪU HỒ SƠ NHÂN SỰ
            ' ----------------------------------------------------------
            Me.pnlFormCard.BackColor = Color.White
            Me.pnlFormCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlFormCard.Controls.Add(Me.lblFormTitle)
            Me.pnlFormCard.Controls.Add(Me.lblModeBadge)
            Me.pnlFormCard.Controls.Add(Me.lblThongBao)

            Me.pnlFormCard.Controls.Add(Me.lblMaNV)
            Me.pnlFormCard.Controls.Add(Me.txtMaNV)
            Me.pnlFormCard.Controls.Add(Me.lblHoTen)
            Me.pnlFormCard.Controls.Add(Me.txtHoTen)

            Me.pnlFormCard.Controls.Add(Me.lblGioiTinh)
            Me.pnlFormCard.Controls.Add(Me.pnlGioiTinh)
            Me.pnlFormCard.Controls.Add(Me.lblNgaySinh)
            Me.pnlFormCard.Controls.Add(Me.dtpNgaySinh)

            Me.pnlFormCard.Controls.Add(Me.lblViTri)
            Me.pnlFormCard.Controls.Add(Me.cboViTri)
            Me.pnlFormCard.Controls.Add(Me.lblCMND)
            Me.pnlFormCard.Controls.Add(Me.txtCMND)

            Me.pnlFormCard.Controls.Add(Me.lblDienThoai)
            Me.pnlFormCard.Controls.Add(Me.txtDienThoai)
            Me.pnlFormCard.Controls.Add(Me.lblEmail)
            Me.pnlFormCard.Controls.Add(Me.txtEmail)

            Me.pnlFormCard.Controls.Add(Me.lblDiaChi)
            Me.pnlFormCard.Controls.Add(Me.txtDiaChi)

            Me.pnlFormCard.Controls.Add(Me.lblHocVan)
            Me.pnlFormCard.Controls.Add(Me.cboHocVan)
            Me.pnlFormCard.Controls.Add(Me.lblTaiKhoan)
            Me.pnlFormCard.Controls.Add(Me.cboTaiKhoan)
            Me.pnlFormCard.Controls.Add(Me.lblTrangThai)
            Me.pnlFormCard.Controls.Add(Me.cboTrangThai)

            Me.pnlFormCard.Controls.Add(Me.lblViTinh)
            Me.pnlFormCard.Controls.Add(Me.clbViTinh)

            Me.pnlFormCard.Controls.Add(Me.pnlUniformBadge)
            Me.pnlFormCard.Controls.Add(Me.tlpButtons)

            Me.pnlFormCard.Dock = DockStyle.Fill
            Me.pnlFormCard.Location = New Point(15, 9)
            Me.pnlFormCard.Name = "pnlFormCard"
            Me.pnlFormCard.Padding = New Padding(12)
            Me.pnlFormCard.Size = New Size(462, 532)
            Me.pnlFormCard.TabIndex = 0

            ' Tiêu đề form & Badge
            Me.lblFormTitle.AutoSize = True
            Me.lblFormTitle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            Me.lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblFormTitle.Location = New Point(12, 10)
            Me.lblFormTitle.Name = "lblFormTitle"
            Me.lblFormTitle.Size = New Size(225, 19)
            Me.lblFormTitle.TabIndex = 0
            Me.lblFormTitle.Text = "📝 THÔNG TIN HỒ SƠ NHÂN SỰ"

            Me.lblModeBadge.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.lblModeBadge.AutoSize = True
            Me.lblModeBadge.BackColor = Color.FromArgb(232, 248, 245)
            Me.lblModeBadge.BorderStyle = BorderStyle.FixedSingle
            Me.lblModeBadge.Font = New Font("Segoe UI", 8.0!, FontStyle.Bold)
            Me.lblModeBadge.ForeColor = Color.FromArgb(39, 174, 96)
            Me.lblModeBadge.Location = New Point(320, 10)
            Me.lblModeBadge.Name = "lblModeBadge"
            Me.lblModeBadge.Padding = New Padding(4, 2, 4, 2)
            Me.lblModeBadge.Size = New Size(125, 19)
            Me.lblModeBadge.TabIndex = 1
            Me.lblModeBadge.Text = "CHẾ ĐỘ: THÊM MỚI"

            Me.lblThongBao.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Me.lblThongBao.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblThongBao.Location = New Point(12, 33)
            Me.lblThongBao.Name = "lblThongBao"
            Me.lblThongBao.Size = New Size(436, 18)
            Me.lblThongBao.TabIndex = 2
            Me.lblThongBao.Text = "💡 Nhập đầy đủ thông tin nhân sự và bấm [Thêm nhân viên]."

            ' HÀNG 1: Mã NV (Col 1) + Họ tên (Col 2)
            Me.lblMaNV.AutoSize = True
            Me.lblMaNV.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblMaNV.Location = New Point(12, 57)
            Me.lblMaNV.Name = "lblMaNV"
            Me.lblMaNV.Size = New Size(48, 15)
            Me.lblMaNV.TabIndex = 3
            Me.lblMaNV.Text = "Mã NV:"

            Me.txtMaNV.Font = New Font("Segoe UI", 8.5!)
            Me.txtMaNV.Location = New Point(12, 74)
            Me.txtMaNV.Name = "txtMaNV"
            Me.txtMaNV.ReadOnly = True
            Me.txtMaNV.Size = New Size(120, 23)
            Me.txtMaNV.TabIndex = 4
            Me.txtMaNV.Text = "(Tự động sinh)"

            Me.lblHoTen.AutoSize = True
            Me.lblHoTen.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblHoTen.Location = New Point(142, 57)
            Me.lblHoTen.Name = "lblHoTen"
            Me.lblHoTen.Size = New Size(76, 15)
            Me.lblHoTen.TabIndex = 5
            Me.lblHoTen.Text = "Họ và tên (*):"

            Me.txtHoTen.Font = New Font("Segoe UI", 8.5!)
            Me.txtHoTen.Location = New Point(142, 74)
            Me.txtHoTen.Name = "txtHoTen"
            Me.txtHoTen.Size = New Size(306, 23)
            Me.txtHoTen.TabIndex = 6

            ' HÀNG 2: Giới tính (Col 1) + Ngày sinh (Col 2)
            Me.lblGioiTinh.AutoSize = True
            Me.lblGioiTinh.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblGioiTinh.Location = New Point(12, 102)
            Me.lblGioiTinh.Name = "lblGioiTinh"
            Me.lblGioiTinh.Size = New Size(58, 15)
            Me.lblGioiTinh.TabIndex = 7
            Me.lblGioiTinh.Text = "Giới tính:"

            Me.pnlGioiTinh.Controls.Add(Me.rdoNam)
            Me.pnlGioiTinh.Controls.Add(Me.rdoNu)
            Me.pnlGioiTinh.Location = New Point(12, 119)
            Me.pnlGioiTinh.Name = "pnlGioiTinh"
            Me.pnlGioiTinh.Size = New Size(160, 24)
            Me.pnlGioiTinh.TabIndex = 8

            Me.rdoNam.AutoSize = True
            Me.rdoNam.Checked = True
            Me.rdoNam.Font = New Font("Segoe UI", 8.5!)
            Me.rdoNam.Location = New Point(3, 2)
            Me.rdoNam.Name = "rdoNam"
            Me.rdoNam.Size = New Size(51, 19)
            Me.rdoNam.TabIndex = 0
            Me.rdoNam.TabStop = True
            Me.rdoNam.Text = "Nam"
            Me.rdoNam.UseVisualStyleBackColor = True

            Me.rdoNu.AutoSize = True
            Me.rdoNu.Font = New Font("Segoe UI", 8.5!)
            Me.rdoNu.Location = New Point(68, 2)
            Me.rdoNu.Name = "rdoNu"
            Me.rdoNu.Size = New Size(41, 19)
            Me.rdoNu.TabIndex = 1
            Me.rdoNu.Text = "Nữ"
            Me.rdoNu.UseVisualStyleBackColor = True

            Me.lblNgaySinh.AutoSize = True
            Me.lblNgaySinh.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblNgaySinh.Location = New Point(182, 102)
            Me.lblNgaySinh.Name = "lblNgaySinh"
            Me.lblNgaySinh.Size = New Size(63, 15)
            Me.lblNgaySinh.TabIndex = 9
            Me.lblNgaySinh.Text = "Ngày sinh:"

            Me.dtpNgaySinh.CustomFormat = "dd/MM/yyyy"
            Me.dtpNgaySinh.Format = DateTimePickerFormat.Custom
            Me.dtpNgaySinh.Font = New Font("Segoe UI", 8.5!)
            Me.dtpNgaySinh.Location = New Point(182, 119)
            Me.dtpNgaySinh.Name = "dtpNgaySinh"
            Me.dtpNgaySinh.Size = New Size(266, 23)
            Me.dtpNgaySinh.TabIndex = 10

            ' HÀNG 3: Vị trí (Col 1) + Số CCCD (Col 2)
            Me.lblViTri.AutoSize = True
            Me.lblViTri.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblViTri.Location = New Point(12, 148)
            Me.lblViTri.Name = "lblViTri"
            Me.lblViTri.Size = New Size(69, 15)
            Me.lblViTri.TabIndex = 11
            Me.lblViTri.Text = "Vị trí CV (*):"

            Me.cboViTri.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboViTri.Font = New Font("Segoe UI", 8.5!)
            Me.cboViTri.FormattingEnabled = True
            Me.cboViTri.Items.AddRange(New Object() {"Chủ quán", "Quản lý", "Phục vụ", "Đầu bếp chính", "Pha chế", "Tiếp tân"})
            Me.cboViTri.Location = New Point(12, 165)
            Me.cboViTri.Name = "cboViTri"
            Me.cboViTri.Size = New Size(190, 23)
            Me.cboViTri.TabIndex = 12

            Me.lblCMND.AutoSize = True
            Me.lblCMND.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblCMND.Location = New Point(212, 148)
            Me.lblCMND.Name = "lblCMND"
            Me.lblCMND.Size = New Size(100, 15)
            Me.lblCMND.TabIndex = 13
            Me.lblCMND.Text = "Số CCCD / CMND:"

            Me.txtCMND.Font = New Font("Segoe UI", 8.5!)
            Me.txtCMND.Location = New Point(212, 165)
            Me.txtCMND.MaxLength = 20
            Me.txtCMND.Name = "txtCMND"
            Me.txtCMND.Size = New Size(236, 23)
            Me.txtCMND.TabIndex = 14

            ' HÀNG 4: Điện thoại (Col 1) + Email (Col 2)
            Me.lblDienThoai.AutoSize = True
            Me.lblDienThoai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblDienThoai.Location = New Point(12, 193)
            Me.lblDienThoai.Name = "lblDienThoai"
            Me.lblDienThoai.Size = New Size(83, 15)
            Me.lblDienThoai.TabIndex = 15
            Me.lblDienThoai.Text = "Số điện thoại:"

            Me.txtDienThoai.Font = New Font("Segoe UI", 8.5!)
            Me.txtDienThoai.Location = New Point(12, 210)
            Me.txtDienThoai.MaxLength = 20
            Me.txtDienThoai.Name = "txtDienThoai"
            Me.txtDienThoai.Size = New Size(190, 23)
            Me.txtDienThoai.TabIndex = 16

            Me.lblEmail.AutoSize = True
            Me.lblEmail.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblEmail.Location = New Point(212, 193)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New Size(39, 15)
            Me.lblEmail.TabIndex = 17
            Me.lblEmail.Text = "Email:"

            Me.txtEmail.Font = New Font("Segoe UI", 8.5!)
            Me.txtEmail.Location = New Point(212, 210)
            Me.txtEmail.MaxLength = 100
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New Size(236, 23)
            Me.txtEmail.TabIndex = 18

            ' HÀNG 5: Địa chỉ (Full width)
            Me.lblDiaChi.AutoSize = True
            Me.lblDiaChi.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblDiaChi.Location = New Point(12, 238)
            Me.lblDiaChi.Name = "lblDiaChi"
            Me.lblDiaChi.Size = New Size(92, 15)
            Me.lblDiaChi.TabIndex = 19
            Me.lblDiaChi.Text = "Địa chỉ cư trú:"

            Me.txtDiaChi.Font = New Font("Segoe UI", 8.5!)
            Me.txtDiaChi.Location = New Point(12, 255)
            Me.txtDiaChi.MaxLength = 255
            Me.txtDiaChi.Name = "txtDiaChi"
            Me.txtDiaChi.Size = New Size(436, 23)
            Me.txtDiaChi.TabIndex = 20

            ' HÀNG 6: Học vấn (Col 1) + Tài khoản liên kết (Col 2)
            Me.lblHocVan.AutoSize = True
            Me.lblHocVan.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblHocVan.Location = New Point(12, 283)
            Me.lblHocVan.Name = "lblHocVan"
            Me.lblHocVan.Size = New Size(54, 15)
            Me.lblHocVan.TabIndex = 21
            Me.lblHocVan.Text = "Học vấn:"

            Me.cboHocVan.DropDownStyle = ComboBoxStyle.DropDown
            Me.cboHocVan.Font = New Font("Segoe UI", 8.5!)
            Me.cboHocVan.FormattingEnabled = True
            Me.cboHocVan.Items.AddRange(New Object() {"Lớp 12/12", "Trung cấp", "Cao đẳng", "Đại học", "Sinh viên làm thêm"})
            Me.cboHocVan.Location = New Point(12, 300)
            Me.cboHocVan.Name = "cboHocVan"
            Me.cboHocVan.Size = New Size(190, 23)
            Me.cboHocVan.TabIndex = 22

            Me.lblTaiKhoan.AutoSize = True
            Me.lblTaiKhoan.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblTaiKhoan.Location = New Point(212, 283)
            Me.lblTaiKhoan.Name = "lblTaiKhoan"
            Me.lblTaiKhoan.Size = New Size(106, 15)
            Me.lblTaiKhoan.TabIndex = 23
            Me.lblTaiKhoan.Text = "Tài khoản liên kết:"

            Me.cboTaiKhoan.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTaiKhoan.Font = New Font("Segoe UI", 8.5!)
            Me.cboTaiKhoan.FormattingEnabled = True
            Me.cboTaiKhoan.Location = New Point(212, 300)
            Me.cboTaiKhoan.Name = "cboTaiKhoan"
            Me.cboTaiKhoan.Size = New Size(236, 23)
            Me.cboTaiKhoan.TabIndex = 24

            ' HÀNG 7: Trạng thái (Col 1) + Kỹ năng vi tính (Col 2)
            Me.lblTrangThai.AutoSize = True
            Me.lblTrangThai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblTrangThai.Location = New Point(12, 328)
            Me.lblTrangThai.Name = "lblTrangThai"
            Me.lblTrangThai.Size = New Size(66, 15)
            Me.lblTrangThai.TabIndex = 25
            Me.lblTrangThai.Text = "Trạng thái:"

            Me.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTrangThai.Font = New Font("Segoe UI", 8.5!)
            Me.cboTrangThai.FormattingEnabled = True
            Me.cboTrangThai.Items.AddRange(New Object() {"Đang làm việc", "Đã nghỉ việc"})
            Me.cboTrangThai.Location = New Point(12, 345)
            Me.cboTrangThai.Name = "cboTrangThai"
            Me.cboTrangThai.Size = New Size(190, 23)
            Me.cboTrangThai.TabIndex = 26

            Me.lblViTinh.AutoSize = True
            Me.lblViTinh.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblViTinh.Location = New Point(212, 328)
            Me.lblViTinh.Name = "lblViTinh"
            Me.lblViTinh.Size = New Size(140, 15)
            Me.lblViTinh.TabIndex = 27
            Me.lblViTinh.Text = "Kỹ năng vi tính (chọn):"

            Me.clbViTinh.CheckOnClick = True
            Me.clbViTinh.Font = New Font("Segoe UI", 8.5!)
            Me.clbViTinh.FormattingEnabled = True
            Me.clbViTinh.Items.AddRange(New Object() {
                "Microsoft Word (Soạn thảo văn bản)",
                "Microsoft Excel (Bảng tính & Thống kê)",
                "Cài đặt & Sử dụng phần mềm POS bán hàng",
                "Khác (Thiết kế Canva, Quản lý Fanpage)"
            })
            Me.clbViTinh.Location = New Point(212, 345)
            Me.clbViTinh.Name = "clbViTinh"
            Me.clbViTinh.Size = New Size(236, 58)
            Me.clbViTinh.TabIndex = 28

            ' HÀNG 8: Badge Đồng phục & Tài khoản
            Me.pnlUniformBadge.BackColor = Color.FromArgb(244, 246, 247)
            Me.pnlUniformBadge.BorderStyle = BorderStyle.FixedSingle
            Me.pnlUniformBadge.Controls.Add(Me.lblUniformInfo)
            Me.pnlUniformBadge.Location = New Point(12, 410)
            Me.pnlUniformBadge.Name = "pnlUniformBadge"
            Me.pnlUniformBadge.Size = New Size(436, 32)
            Me.pnlUniformBadge.TabIndex = 27

            Me.lblUniformInfo.AutoSize = True
            Me.lblUniformInfo.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular)
            Me.lblUniformInfo.ForeColor = Color.FromArgb(44, 62, 80)
            Me.lblUniformInfo.Location = New Point(6, 7)
            Me.lblUniformInfo.Name = "lblUniformInfo"
            Me.lblUniformInfo.Size = New Size(392, 15)
            Me.lblUniformInfo.TabIndex = 0
            Me.lblUniformInfo.Text = "👕 Cấp phát: Chưa cấp trang phục  |  🔐 Tài khoản: Tự động tạo khi lưu"

            ' CỤM NÚT CRUD (Dock Bottom)
            Me.tlpButtons.ColumnCount = 2
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.Controls.Add(Me.btnThem, 0, 0)
            Me.tlpButtons.Controls.Add(Me.btnCapNhat, 1, 0)
            Me.tlpButtons.Controls.Add(Me.btnThoiViec, 0, 1)
            Me.tlpButtons.Controls.Add(Me.btnLamMoi, 1, 1)
            Me.tlpButtons.Dock = DockStyle.Bottom
            Me.tlpButtons.Location = New Point(12, 448)
            Me.tlpButtons.Name = "tlpButtons"
            Me.tlpButtons.RowCount = 2
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
            Me.tlpButtons.Size = New Size(436, 70)
            Me.tlpButtons.TabIndex = 28

            Me.btnThem.BackColor = Color.FromArgb(39, 174, 96)
            Me.btnThem.Cursor = Cursors.Hand
            Me.btnThem.Dock = DockStyle.Fill
            Me.btnThem.FlatAppearance.BorderSize = 0
            Me.btnThem.FlatStyle = FlatStyle.Flat
            Me.btnThem.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnThem.ForeColor = Color.White
            Me.btnThem.Location = New Point(2, 2)
            Me.btnThem.Margin = New Padding(2)
            Me.btnThem.Name = "btnThem"
            Me.btnThem.Size = New Size(214, 31)
            Me.btnThem.TabIndex = 0
            Me.btnThem.Text = "➕ Thêm nhân viên"
            Me.btnThem.UseVisualStyleBackColor = False

            Me.btnCapNhat.BackColor = Color.FromArgb(41, 128, 185)
            Me.btnCapNhat.Cursor = Cursors.Hand
            Me.btnCapNhat.Dock = DockStyle.Fill
            Me.btnCapNhat.FlatAppearance.BorderSize = 0
            Me.btnCapNhat.FlatStyle = FlatStyle.Flat
            Me.btnCapNhat.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnCapNhat.ForeColor = Color.White
            Me.btnCapNhat.Location = New Point(220, 2)
            Me.btnCapNhat.Margin = New Padding(2)
            Me.btnCapNhat.Name = "btnCapNhat"
            Me.btnCapNhat.Size = New Size(214, 31)
            Me.btnCapNhat.TabIndex = 1
            Me.btnCapNhat.Text = "💾 Lưu cập nhật"
            Me.btnCapNhat.UseVisualStyleBackColor = False

            Me.btnThoiViec.BackColor = Color.FromArgb(230, 126, 34)
            Me.btnThoiViec.Cursor = Cursors.Hand
            Me.btnThoiViec.Dock = DockStyle.Fill
            Me.btnThoiViec.FlatAppearance.BorderSize = 0
            Me.btnThoiViec.FlatStyle = FlatStyle.Flat
            Me.btnThoiViec.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnThoiViec.ForeColor = Color.White
            Me.btnThoiViec.Location = New Point(2, 37)
            Me.btnThoiViec.Margin = New Padding(2)
            Me.btnThoiViec.Name = "btnThoiViec"
            Me.btnThoiViec.Size = New Size(214, 31)
            Me.btnThoiViec.TabIndex = 2
            Me.btnThoiViec.Text = "🛑 Cho thôi việc"
            Me.btnThoiViec.UseVisualStyleBackColor = False

            Me.btnLamMoi.BackColor = Color.FromArgb(127, 140, 141)
            Me.btnLamMoi.Cursor = Cursors.Hand
            Me.btnLamMoi.Dock = DockStyle.Fill
            Me.btnLamMoi.FlatAppearance.BorderSize = 0
            Me.btnLamMoi.FlatStyle = FlatStyle.Flat
            Me.btnLamMoi.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            Me.btnLamMoi.ForeColor = Color.White
            Me.btnLamMoi.Location = New Point(220, 37)
            Me.btnLamMoi.Margin = New Padding(2)
            Me.btnLamMoi.Name = "btnLamMoi"
            Me.btnLamMoi.Size = New Size(214, 31)
            Me.btnLamMoi.TabIndex = 3
            Me.btnLamMoi.Text = "🔄 Làm mới"
            Me.btnLamMoi.UseVisualStyleBackColor = False

            ' ----------------------------------------------------------
            ' 3.2. CỘT PHẢI (58%): BẢNG DANH SÁCH & BỘ LỌC
            ' ----------------------------------------------------------
            Me.pnlGridCard.BackColor = Color.White
            Me.pnlGridCard.BorderStyle = BorderStyle.FixedSingle
            Me.pnlGridCard.Controls.Add(Me.dgvNhanVien)
            Me.pnlGridCard.Controls.Add(Me.pnlFilterBar)
            Me.pnlGridCard.Controls.Add(Me.lblGridTitle)
            Me.pnlGridCard.Dock = DockStyle.Fill
            Me.pnlGridCard.Location = New Point(483, 9)
            Me.pnlGridCard.Name = "pnlGridCard"
            Me.pnlGridCard.Padding = New Padding(12)
            Me.pnlGridCard.Size = New Size(648, 532)
            Me.pnlGridCard.TabIndex = 1

            Me.lblGridTitle.Dock = DockStyle.Top
            Me.lblGridTitle.Font = New Font("Segoe UI", 10.5!, FontStyle.Bold)
            Me.lblGridTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblGridTitle.Location = New Point(12, 12)
            Me.lblGridTitle.Name = "lblGridTitle"
            Me.lblGridTitle.Size = New Size(622, 24)
            Me.lblGridTitle.TabIndex = 0
            Me.lblGridTitle.Text = "📋 DANH SÁCH NHÂN SỰ QUÁN ĂN"

            Me.pnlFilterBar.Controls.Add(Me.lblLocViTri)
            Me.pnlFilterBar.Controls.Add(Me.cboLocViTri)
            Me.pnlFilterBar.Controls.Add(Me.lblLocTrangThai)
            Me.pnlFilterBar.Controls.Add(Me.cboLocTrangThai)
            Me.pnlFilterBar.Controls.Add(Me.txtTimKiem)
            Me.pnlFilterBar.Controls.Add(Me.btnTaiLai)
            Me.pnlFilterBar.Dock = DockStyle.Top
            Me.pnlFilterBar.Location = New Point(12, 36)
            Me.pnlFilterBar.Name = "pnlFilterBar"
            Me.pnlFilterBar.Size = New Size(622, 38)
            Me.pnlFilterBar.TabIndex = 1

            Me.lblLocViTri.AutoSize = True
            Me.lblLocViTri.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblLocViTri.Location = New Point(0, 11)
            Me.lblLocViTri.Name = "lblLocViTri"
            Me.lblLocViTri.Size = New Size(37, 15)
            Me.lblLocViTri.TabIndex = 0
            Me.lblLocViTri.Text = "Vị trí:"

            Me.cboLocViTri.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboLocViTri.Font = New Font("Segoe UI", 8.5!)
            Me.cboLocViTri.FormattingEnabled = True
            Me.cboLocViTri.Items.AddRange(New Object() {"-- Tất cả vị trí --", "Chủ quán", "Quản lý", "Phục vụ", "Đầu bếp chính", "Pha chế", "Tiếp tân"})
            Me.cboLocViTri.Location = New Point(40, 7)
            Me.cboLocViTri.Name = "cboLocViTri"
            Me.cboLocViTri.Size = New Size(115, 23)
            Me.cboLocViTri.TabIndex = 1

            Me.lblLocTrangThai.AutoSize = True
            Me.lblLocTrangThai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.lblLocTrangThai.Location = New Point(160, 11)
            Me.lblLocTrangThai.Name = "lblLocTrangThai"
            Me.lblLocTrangThai.Size = New Size(66, 15)
            Me.lblLocTrangThai.TabIndex = 2
            Me.lblLocTrangThai.Text = "Trạng thái:"

            Me.cboLocTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboLocTrangThai.Font = New Font("Segoe UI", 8.5!)
            Me.cboLocTrangThai.FormattingEnabled = True
            Me.cboLocTrangThai.Items.AddRange(New Object() {"-- Tất cả --", "Đang làm việc", "Đã nghỉ việc"})
            Me.cboLocTrangThai.Location = New Point(230, 7)
            Me.cboLocTrangThai.Name = "cboLocTrangThai"
            Me.cboLocTrangThai.Size = New Size(105, 23)
            Me.cboLocTrangThai.TabIndex = 3

            Me.txtTimKiem.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) Or AnchorStyles.Right), AnchorStyles)
            Me.txtTimKiem.Font = New Font("Segoe UI", 8.5!)
            Me.txtTimKiem.Location = New Point(342, 7)
            Me.txtTimKiem.Name = "txtTimKiem"
            Me.txtTimKiem.PlaceholderText = "🔍 Tìm Tên, SĐT, CCCD..."
            Me.txtTimKiem.Size = New Size(198, 23)
            Me.txtTimKiem.TabIndex = 4

            Me.btnTaiLai.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
            Me.btnTaiLai.BackColor = Color.FromArgb(52, 73, 94)
            Me.btnTaiLai.Cursor = Cursors.Hand
            Me.btnTaiLai.FlatAppearance.BorderSize = 0
            Me.btnTaiLai.FlatStyle = FlatStyle.Flat
            Me.btnTaiLai.Font = New Font("Segoe UI", 8.5!, FontStyle.Bold)
            Me.btnTaiLai.ForeColor = Color.White
            Me.btnTaiLai.Location = New Point(546, 6)
            Me.btnTaiLai.Name = "btnTaiLai"
            Me.btnTaiLai.Size = New Size(74, 25)
            Me.btnTaiLai.TabIndex = 5
            Me.btnTaiLai.Text = "🔄 Tải lại"
            Me.btnTaiLai.UseVisualStyleBackColor = False

            ' DataGridView
            Me.dgvNhanVien.AllowUserToAddRows = False
            Me.dgvNhanVien.AllowUserToDeleteRows = False
            Me.dgvNhanVien.AllowUserToResizeRows = False
            Me.dgvNhanVien.BackgroundColor = Color.White
            Me.dgvNhanVien.BorderStyle = BorderStyle.None

            dgvCellStyleHeader.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyleHeader.BackColor = Color.FromArgb(26, 82, 118)
            dgvCellStyleHeader.Font = New Font("Segoe UI", 9.0!, FontStyle.Bold)
            dgvCellStyleHeader.ForeColor = Color.White
            dgvCellStyleHeader.SelectionBackColor = Color.FromArgb(26, 82, 118)
            dgvCellStyleHeader.SelectionForeColor = Color.White
            Me.dgvNhanVien.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader
            Me.dgvNhanVien.ColumnHeadersHeight = 32
            Me.dgvNhanVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

            Me.dgvNhanVien.Columns.AddRange(New DataGridViewColumn() {
                Me.colMaNV, Me.colHoTen, Me.colGioiTinh, Me.colViTri,
                Me.colDienThoai, Me.colCMND, Me.colTrangThai, Me.colTaiKhoan
            })

            dgvCellStyleRow.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgvCellStyleRow.BackColor = Color.White
            dgvCellStyleRow.Font = New Font("Segoe UI", 8.8!)
            dgvCellStyleRow.ForeColor = Color.FromArgb(44, 62, 80)
            dgvCellStyleRow.SelectionBackColor = Color.FromArgb(214, 234, 248)
            dgvCellStyleRow.SelectionForeColor = Color.FromArgb(26, 82, 118)
            Me.dgvNhanVien.DefaultCellStyle = dgvCellStyleRow

            Me.dgvNhanVien.Dock = DockStyle.Fill
            Me.dgvNhanVien.EnableHeadersVisualStyles = False
            Me.dgvNhanVien.Location = New Point(12, 74)
            Me.dgvNhanVien.MultiSelect = False
            Me.dgvNhanVien.Name = "dgvNhanVien"
            Me.dgvNhanVien.ReadOnly = True
            Me.dgvNhanVien.RowHeadersVisible = False
            Me.dgvNhanVien.RowTemplate.Height = 28
            Me.dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvNhanVien.Size = New Size(622, 444)
            Me.dgvNhanVien.TabIndex = 2

            ' Cột 1: Mã NV
            Me.colMaNV.DataPropertyName = "NV_Ma"
            Me.colMaNV.HeaderText = "Mã"
            Me.colMaNV.Name = "colMaNV"
            Me.colMaNV.ReadOnly = True
            Me.colMaNV.Width = 45

            ' Cột 2: Họ tên
            Me.colHoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Me.colHoTen.DataPropertyName = "NV_HoTen"
            Me.colHoTen.HeaderText = "Họ và tên"
            Me.colHoTen.MinimumWidth = 140
            Me.colHoTen.Name = "colHoTen"
            Me.colHoTen.ReadOnly = True

            ' Cột 3: Giới tính
            Me.colGioiTinh.DataPropertyName = "GioiTinhHienThi"
            Me.colGioiTinh.HeaderText = "Phái"
            Me.colGioiTinh.Name = "colGioiTinh"
            Me.colGioiTinh.ReadOnly = True
            Me.colGioiTinh.Width = 50

            ' Cột 4: Vị trí
            Me.colViTri.DataPropertyName = "NV_ViTri"
            Me.colViTri.HeaderText = "Vị trí"
            Me.colViTri.Name = "colViTri"
            Me.colViTri.ReadOnly = True
            Me.colViTri.Width = 95

            ' Cột 5: Điện thoại
            Me.colDienThoai.DataPropertyName = "NV_DienThoai"
            Me.colDienThoai.HeaderText = "Điện thoại"
            Me.colDienThoai.Name = "colDienThoai"
            Me.colDienThoai.ReadOnly = True
            Me.colDienThoai.Width = 95

            ' Cột 6: CCCD
            Me.colCMND.DataPropertyName = "NV_CMND"
            Me.colCMND.HeaderText = "Số CCCD"
            Me.colCMND.Name = "colCMND"
            Me.colCMND.ReadOnly = True
            Me.colCMND.Width = 100

            ' Cột 7: Trạng thái
            Me.colTrangThai.DataPropertyName = "NV_TrangThai"
            Me.colTrangThai.HeaderText = "Trạng thái"
            Me.colTrangThai.Name = "colTrangThai"
            Me.colTrangThai.ReadOnly = True
            Me.colTrangThai.Width = 95

            ' Cột 8: Tài khoản
            Me.colTaiKhoan.DataPropertyName = "TenTaiKhoanHienThi"
            Me.colTaiKhoan.HeaderText = "Tài khoản"
            Me.colTaiKhoan.Name = "colTaiKhoan"
            Me.colTaiKhoan.ReadOnly = True
            Me.colTaiKhoan.Width = 85

            ' ==========================================================
            ' FORM CHÍNH (frmNhanVien)
            ' ==========================================================
            Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = AutoScaleMode.Font
            Me.BackColor = Color.FromArgb(245, 247, 250)
            Me.ClientSize = New Size(1160, 700)
            Me.Controls.Add(Me.tlpMainContent)
            Me.Controls.Add(Me.tlpKpiRow)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
            Me.MinimumSize = New Size(1060, 660)
            Me.Name = "frmNhanVien"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Quản Lý Danh Sách Nhân Sự"

            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.tlpKpiRow.ResumeLayout(False)
            Me.pnlKpiTongNV.ResumeLayout(False)
            Me.pnlKpiTongNV.PerformLayout()
            Me.pnlKpiDangLam.ResumeLayout(False)
            Me.pnlKpiDangLam.PerformLayout()
            Me.pnlKpiNghiViec.ResumeLayout(False)
            Me.pnlKpiNghiViec.PerformLayout()
            Me.pnlKpiCoTaiKhoan.ResumeLayout(False)
            Me.pnlKpiCoTaiKhoan.PerformLayout()
            Me.tlpMainContent.ResumeLayout(False)
            Me.pnlFormCard.ResumeLayout(False)
            Me.pnlFormCard.PerformLayout()
            Me.pnlGioiTinh.ResumeLayout(False)
            Me.pnlGioiTinh.PerformLayout()
            Me.pnlUniformBadge.ResumeLayout(False)
            Me.pnlUniformBadge.PerformLayout()
            Me.tlpButtons.ResumeLayout(False)
            Me.pnlGridCard.ResumeLayout(False)
            Me.pnlFilterBar.ResumeLayout(False)
            Me.pnlFilterBar.PerformLayout()
            CType(Me.dgvNhanVien, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

    End Class

End Namespace
