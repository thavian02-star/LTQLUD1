Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Branch

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmChiNhanh
        Inherits Form

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

        Friend WithEvents pnlHeader As Panel
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents btnDong As Button
        Friend WithEvents tlpMain As TableLayoutPanel
        Friend WithEvents pnlLeft As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblMaCN As Label
        Friend WithEvents txtMaCN As TextBox
        Friend WithEvents lblTenCN As Label
        Friend WithEvents txtTenCN As TextBox
        Friend WithEvents lblDiaChi As Label
        Friend WithEvents txtDiaChi As TextBox
        Friend WithEvents lblSDT As Label
        Friend WithEvents txtSDT As TextBox
        Friend WithEvents lblQuanLy As Label
        Friend WithEvents cboQuanLy As ComboBox
        Friend WithEvents lblSucChua As Label
        Friend WithEvents nudSucChua As NumericUpDown
        Friend WithEvents lblGioMoCua As Label
        Friend WithEvents txtGioMoCua As TextBox
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents lblMoTa As Label
        Friend WithEvents txtMoTa As TextBox
        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnThem As Button
        Friend WithEvents btnLuu As Button
        Friend WithEvents btnXoa As Button
        Friend WithEvents btnLamMoi As Button
        Friend WithEvents pnlRight As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlSearch As Panel
        Friend WithEvents txtSearch As TextBox
        Friend WithEvents cboFilterTrangThai As ComboBox
        Friend WithEvents dgvChiNhanh As DataGridView
        Friend WithEvents ssStatus As StatusStrip
        Friend WithEvents tslStatus As ToolStripStatusLabel

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            InitControls()
            BuildHeader()
            BuildLeftForm()
            BuildRightGrid()
            BuildLayout()
        End Sub

        Private Sub InitControls()
            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnDong = New Button()
            Me.tlpMain = New TableLayoutPanel()
            Me.pnlLeft = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblMaCN = New Label()
            Me.txtMaCN = New TextBox()
            Me.lblTenCN = New Label()
            Me.txtTenCN = New TextBox()
            Me.lblDiaChi = New Label()
            Me.txtDiaChi = New TextBox()
            Me.lblSDT = New Label()
            Me.txtSDT = New TextBox()
            Me.lblQuanLy = New Label()
            Me.cboQuanLy = New ComboBox()
            Me.lblSucChua = New Label()
            Me.nudSucChua = New NumericUpDown()
            Me.lblGioMoCua = New Label()
            Me.txtGioMoCua = New TextBox()
            Me.lblTrangThai = New Label()
            Me.cboTrangThai = New ComboBox()
            Me.lblMoTa = New Label()
            Me.txtMoTa = New TextBox()
            Me.tlpButtons = New TableLayoutPanel()
            Me.btnThem = New Button()
            Me.btnLuu = New Button()
            Me.btnXoa = New Button()
            Me.btnLamMoi = New Button()
            Me.pnlRight = New Panel()
            Me.lblGridTitle = New Label()
            Me.pnlSearch = New Panel()
            Me.txtSearch = New TextBox()
            Me.cboFilterTrangThai = New ComboBox()
            Me.dgvChiNhanh = New DataGridView()
            Me.ssStatus = New StatusStrip()
            Me.tslStatus = New ToolStripStatusLabel()
        End Sub

        Private Sub BuildHeader()
            Me.pnlHeader.BackColor = Color.FromArgb(26, 82, 118)
            Me.pnlHeader.Dock = DockStyle.Top
            Me.pnlHeader.Height = 65
            Me.pnlHeader.Padding = New Padding(15, 8, 15, 8)

            Me.lblTitle.Text = "🏢 QUẢN LÝ CHUỖI CHI NHÁNH & CƠ SỞ"
            Me.lblTitle.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblTitle.ForeColor = Color.White
            Me.lblTitle.Location = New Point(15, 10)
            Me.lblTitle.AutoSize = True

            Me.lblSubtitle.Text = "Hệ thống thiết lập cơ sở kinh doanh, sức chứa, quản lý cơ sở và trạng thái"
            Me.lblSubtitle.Font = New Font("Segoe UI", 9.0!)
            Me.lblSubtitle.ForeColor = Color.FromArgb(214, 234, 248)
            Me.lblSubtitle.Location = New Point(16, 36)
            Me.lblSubtitle.AutoSize = True

            Me.btnDong.Text = "✕ Đóng"
            Me.btnDong.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            Me.btnDong.Location = New Point(1080, 15)
            Me.btnDong.Size = New Size(90, 32)
            Me.btnDong.BackColor = Color.FromArgb(41, 128, 185)
            Me.btnDong.ForeColor = Color.White
            Me.btnDong.FlatStyle = FlatStyle.Flat

            Me.pnlHeader.Controls.AddRange({Me.lblTitle, Me.lblSubtitle, Me.btnDong})
        End Sub

        Private Sub BuildLeftForm()
            Me.pnlLeft.BackColor = Color.White
            Me.pnlLeft.Dock = DockStyle.Fill
            Me.pnlLeft.Padding = New Padding(15)

            Me.lblFormTitle.Text = "📝 THÔNG TIN CHI NHÁNH"
            Me.lblFormTitle.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblFormTitle.Location = New Point(15, 10)
            Me.lblFormTitle.AutoSize = True

            BuildLeftInputs()
            BuildLeftButtons()

            Me.pnlLeft.Controls.AddRange({Me.lblFormTitle, Me.lblMaCN, Me.txtMaCN,
                Me.lblTenCN, Me.txtTenCN, Me.lblDiaChi, Me.txtDiaChi,
                Me.lblSDT, Me.txtSDT, Me.lblQuanLy, Me.cboQuanLy,
                Me.lblSucChua, Me.nudSucChua, Me.lblGioMoCua, Me.txtGioMoCua,
                Me.lblTrangThai, Me.cboTrangThai, Me.lblMoTa, Me.txtMoTa, Me.tlpButtons})
        End Sub

        Private Sub BuildLeftInputs()
            Me.lblMaCN.Text = "Mã CN:" : Me.lblMaCN.Location = New Point(15, 42) : Me.lblMaCN.AutoSize = True
            Me.txtMaCN.Location = New Point(15, 60) : Me.txtMaCN.Size = New Size(160, 25)
            Me.txtMaCN.ReadOnly = True : Me.txtMaCN.BackColor = Color.FromArgb(241, 245, 249)

            Me.lblSucChua.Text = "Sức chứa (khách):" : Me.lblSucChua.Location = New Point(190, 42) : Me.lblSucChua.AutoSize = True
            Me.nudSucChua.Location = New Point(190, 60) : Me.nudSucChua.Size = New Size(170, 25)
            Me.nudSucChua.Minimum = 1 : Me.nudSucChua.Maximum = 5000 : Me.nudSucChua.Value = 50

            Me.lblTenCN.Text = "Tên chi nhánh (*):" : Me.lblTenCN.Location = New Point(15, 92) : Me.lblTenCN.AutoSize = True
            Me.txtTenCN.Location = New Point(15, 110) : Me.txtTenCN.Size = New Size(345, 25)

            Me.lblDiaChi.Text = "Địa chỉ (*):" : Me.lblDiaChi.Location = New Point(15, 142) : Me.lblDiaChi.AutoSize = True
            Me.txtDiaChi.Location = New Point(15, 160) : Me.txtDiaChi.Size = New Size(345, 25)

            Me.lblSDT.Text = "Hotline / SĐT:" : Me.lblSDT.Location = New Point(15, 192) : Me.lblSDT.AutoSize = True
            Me.txtSDT.Location = New Point(15, 210) : Me.txtSDT.Size = New Size(160, 25)

            Me.lblQuanLy.Text = "Người quản lý:" : Me.lblQuanLy.Location = New Point(190, 192) : Me.lblQuanLy.AutoSize = True
            Me.cboQuanLy.Location = New Point(190, 210) : Me.cboQuanLy.Size = New Size(170, 25)
            Me.cboQuanLy.DropDownStyle = ComboBoxStyle.DropDownList

            Me.lblGioMoCua.Text = "Giờ mở cửa:" : Me.lblGioMoCua.Location = New Point(15, 242) : Me.lblGioMoCua.AutoSize = True
            Me.txtGioMoCua.Location = New Point(15, 260) : Me.txtGioMoCua.Size = New Size(160, 25)
            Me.txtGioMoCua.Text = "07:00 - 22:00"

            Me.lblTrangThai.Text = "Trạng thái:" : Me.lblTrangThai.Location = New Point(190, 242) : Me.lblTrangThai.AutoSize = True
            Me.cboTrangThai.Location = New Point(190, 260) : Me.cboTrangThai.Size = New Size(170, 25)
            Me.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTrangThai.Items.AddRange({"Đang mở cửa", "Tạm đóng cửa", "Đang sửa chữa"})

            Me.lblMoTa.Text = "Ghi chú mặt bằng:" : Me.lblMoTa.Location = New Point(15, 292) : Me.lblMoTa.AutoSize = True
            Me.txtMoTa.Location = New Point(15, 310) : Me.txtMoTa.Size = New Size(345, 45) : Me.txtMoTa.Multiline = True
        End Sub

        Private Sub BuildLeftButtons()
            Me.tlpButtons.Location = New Point(15, 370)
            Me.tlpButtons.Size = New Size(345, 38)
            Me.tlpButtons.ColumnCount = 4
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))

            Me.btnThem.Text = "➕ Thêm" : Me.btnThem.Dock = DockStyle.Fill : Me.btnThem.BackColor = Color.FromArgb(26, 82, 118) : Me.btnThem.ForeColor = Color.White : Me.btnThem.FlatStyle = FlatStyle.Flat
            Me.btnLuu.Text = "💾 Lưu" : Me.btnLuu.Dock = DockStyle.Fill : Me.btnLuu.BackColor = Color.FromArgb(39, 174, 96) : Me.btnLuu.ForeColor = Color.White : Me.btnLuu.FlatStyle = FlatStyle.Flat
            Me.btnXoa.Text = "🗑️ Xóa" : Me.btnXoa.Dock = DockStyle.Fill : Me.btnXoa.BackColor = Color.FromArgb(192, 57, 43) : Me.btnXoa.ForeColor = Color.White : Me.btnXoa.FlatStyle = FlatStyle.Flat
            Me.btnLamMoi.Text = "🔄 Mới" : Me.btnLamMoi.Dock = DockStyle.Fill : Me.btnLamMoi.BackColor = Color.FromArgb(100, 116, 139) : Me.btnLamMoi.ForeColor = Color.White : Me.btnLamMoi.FlatStyle = FlatStyle.Flat

            Me.tlpButtons.Controls.Add(Me.btnThem, 0, 0)
            Me.tlpButtons.Controls.Add(Me.btnLuu, 1, 0)
            Me.tlpButtons.Controls.Add(Me.btnXoa, 2, 0)
            Me.tlpButtons.Controls.Add(Me.btnLamMoi, 3, 0)
        End Sub

        Private Sub BuildRightGrid()
            Me.pnlRight.BackColor = Color.White
            Me.pnlRight.Dock = DockStyle.Fill
            Me.pnlRight.Padding = New Padding(15)

            Me.lblGridTitle.Text = "📋 DANH SÁCH CHI NHÁNH CHUỖI NHÀ HÀNG"
            Me.lblGridTitle.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.lblGridTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblGridTitle.Dock = DockStyle.Top
            Me.lblGridTitle.Height = 28

            Me.pnlSearch.Dock = DockStyle.Top
            Me.pnlSearch.Height = 36
            Me.txtSearch.Location = New Point(0, 4)
            Me.txtSearch.Size = New Size(420, 25)
            Me.txtSearch.PlaceholderText = "🔍 Tìm kiếm theo tên chi nhánh, địa chỉ, hotline..."

            Me.cboFilterTrangThai.Location = New Point(430, 4)
            Me.cboFilterTrangThai.Size = New Size(180, 25)
            Me.cboFilterTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboFilterTrangThai.Items.AddRange({"-- Tất cả trạng thái --", "Đang mở cửa", "Tạm đóng cửa", "Đang sửa chữa"})
            Me.cboFilterTrangThai.SelectedIndex = 0

            Me.pnlSearch.Controls.AddRange({Me.txtSearch, Me.cboFilterTrangThai})

            FormatDataGrid()

            Me.pnlRight.Controls.Add(Me.dgvChiNhanh)
            Me.pnlRight.Controls.Add(Me.pnlSearch)
            Me.pnlRight.Controls.Add(Me.lblGridTitle)
        End Sub

        Private Sub FormatDataGrid()
            Me.dgvChiNhanh.Dock = DockStyle.Fill
            Me.dgvChiNhanh.BackgroundColor = Color.White
            Me.dgvChiNhanh.BorderStyle = BorderStyle.Fixed3D
            Me.dgvChiNhanh.ReadOnly = True
            Me.dgvChiNhanh.AllowUserToAddRows = False
            Me.dgvChiNhanh.AllowUserToDeleteRows = False
            Me.dgvChiNhanh.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvChiNhanh.MultiSelect = False
            Me.dgvChiNhanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvChiNhanh.RowHeadersVisible = False
        End Sub

        Private Sub BuildLayout()
            Me.tlpMain.Dock = DockStyle.Fill
            Me.tlpMain.ColumnCount = 2
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 38.0!))
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 62.0!))
            Me.tlpMain.RowCount = 1
            Me.tlpMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpMain.Controls.Add(Me.pnlLeft, 0, 0)
            Me.tlpMain.Controls.Add(Me.pnlRight, 1, 0)

            Me.ssStatus.Items.Add(Me.tslStatus)
            Me.tslStatus.Text = "Sẵn sàng"

            Me.ClientSize = New Size(1184, 661)
            Me.Controls.Add(Me.tlpMain)
            Me.Controls.Add(Me.ssStatus)
            Me.Controls.Add(Me.pnlHeader)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Quản lý Chuỗi Chi Nhánh - Hương Việt"
            Me.Font = New Font("Segoe UI", 9.0!)
        End Sub

    End Class

End Namespace
