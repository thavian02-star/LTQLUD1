Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Branch

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMenuChiNhanh
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

        Friend WithEvents pnlBranchSelect As Panel
        Friend WithEvents lblSelectBranch As Label
        Friend WithEvents cboMainBranch As ComboBox
        Friend WithEvents lblBranchDetail As Label

        Friend WithEvents tlpMain As TableLayoutPanel
        Friend WithEvents pnlLeft As Panel
        Friend WithEvents lblFormTitle As Label
        Friend WithEvents lblMaCNM As Label
        Friend WithEvents txtMaCNM As TextBox
        Friend WithEvents lblMenu As Label
        Friend WithEvents cboMenuPool As ComboBox
        Friend WithEvents lblNgayBD As Label
        Friend WithEvents dtpNgayBD As DateTimePicker
        Friend WithEvents lblNgayKT As Label
        Friend WithEvents dtpNgayKT As DateTimePicker
        Friend WithEvents chkCoNgayKT As CheckBox
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents lblGhiChu As Label
        Friend WithEvents txtGhiChu As TextBox
        Friend WithEvents tlpButtons As TableLayoutPanel
        Friend WithEvents btnGanMoi As Button
        Friend WithEvents btnLuu As Button
        Friend WithEvents btnGo As Button
        Friend WithEvents btnLamMoi As Button

        Friend WithEvents pnlRight As Panel
        Friend WithEvents lblGridTitle As Label
        Friend WithEvents pnlSearch As Panel
        Friend WithEvents txtSearch As TextBox
        Friend WithEvents cboFilterTrangThai As ComboBox
        Friend WithEvents dgvMenuChiNhanh As DataGridView
        Friend WithEvents ssStatus As StatusStrip
        Friend WithEvents tslStatus As ToolStripStatusLabel

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            InitControls()
            BuildHeader()
            BuildBranchSelect()
            BuildLeftForm()
            BuildRightGrid()
            BuildLayout()
        End Sub

        Private Sub InitControls()
            Me.pnlHeader = New Panel()
            Me.lblTitle = New Label()
            Me.lblSubtitle = New Label()
            Me.btnDong = New Button()
            Me.pnlBranchSelect = New Panel()
            Me.lblSelectBranch = New Label()
            Me.cboMainBranch = New ComboBox()
            Me.lblBranchDetail = New Label()
            Me.tlpMain = New TableLayoutPanel()
            Me.pnlLeft = New Panel()
            Me.lblFormTitle = New Label()
            Me.lblMaCNM = New Label()
            Me.txtMaCNM = New TextBox()
            Me.lblMenu = New Label()
            Me.cboMenuPool = New ComboBox()
            Me.lblNgayBD = New Label()
            Me.dtpNgayBD = New DateTimePicker()
            Me.lblNgayKT = New Label()
            Me.dtpNgayKT = New DateTimePicker()
            Me.chkCoNgayKT = New CheckBox()
            Me.lblTrangThai = New Label()
            Me.cboTrangThai = New ComboBox()
            Me.lblGhiChu = New Label()
            Me.txtGhiChu = New TextBox()
            Me.tlpButtons = New TableLayoutPanel()
            Me.btnGanMoi = New Button()
            Me.btnLuu = New Button()
            Me.btnGo = New Button()
            Me.btnLamMoi = New Button()
            Me.pnlRight = New Panel()
            Me.lblGridTitle = New Label()
            Me.pnlSearch = New Panel()
            Me.txtSearch = New TextBox()
            Me.cboFilterTrangThai = New ComboBox()
            Me.dgvMenuChiNhanh = New DataGridView()
            Me.ssStatus = New StatusStrip()
            Me.tslStatus = New ToolStripStatusLabel()
        End Sub

        Private Sub BuildHeader()
            Me.pnlHeader.BackColor = Color.FromArgb(26, 82, 118)
            Me.pnlHeader.Dock = DockStyle.Top
            Me.pnlHeader.Height = 65
            Me.pnlHeader.Padding = New Padding(15, 8, 15, 8)

            Me.lblTitle.Text = "🏬 PHÂN BỔ THỰC ĐƠN BÁN HÀNG THEO CHI NHÁNH"
            Me.lblTitle.Font = New Font("Segoe UI", 13.0!, FontStyle.Bold)
            Me.lblTitle.ForeColor = Color.White
            Me.lblTitle.Location = New Point(15, 10)
            Me.lblTitle.AutoSize = True

            Me.lblSubtitle.Text = "Quản lý danh sách các gói thực đơn kinh doanh được phép mở bán tại từng cơ sở"
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

        Private Sub BuildBranchSelect()
            Me.pnlBranchSelect.BackColor = Color.FromArgb(226, 232, 240)
            Me.pnlBranchSelect.Dock = DockStyle.Top
            Me.pnlBranchSelect.Height = 46
            Me.pnlBranchSelect.Padding = New Padding(15, 8, 15, 8)

            Me.lblSelectBranch.Text = "🏢 Chọn Chi Nhánh:"
            Me.lblSelectBranch.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.lblSelectBranch.ForeColor = Color.FromArgb(15, 23, 42)
            Me.lblSelectBranch.Location = New Point(15, 12)
            Me.lblSelectBranch.AutoSize = True

            Me.cboMainBranch.Location = New Point(160, 9)
            Me.cboMainBranch.Size = New Size(340, 26)
            Me.cboMainBranch.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboMainBranch.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)

            Me.lblBranchDetail.Location = New Point(520, 13)
            Me.lblBranchDetail.AutoSize = True
            Me.lblBranchDetail.Font = New Font("Segoe UI", 9.0!)
            Me.lblBranchDetail.ForeColor = Color.FromArgb(71, 85, 105)

            Me.pnlBranchSelect.Controls.AddRange({Me.lblSelectBranch, Me.cboMainBranch, Me.lblBranchDetail})
        End Sub

        Private Sub BuildLeftForm()
            Me.pnlLeft.BackColor = Color.White
            Me.pnlLeft.Dock = DockStyle.Fill
            Me.pnlLeft.Padding = New Padding(15)

            Me.lblFormTitle.Text = "📋 GÁN / CẬP NHẬT MENU CHO CHI NHÁNH"
            Me.lblFormTitle.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.lblFormTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblFormTitle.Location = New Point(15, 10)
            Me.lblFormTitle.AutoSize = True

            BuildLeftInputs()
            BuildLeftButtons()

            Me.pnlLeft.Controls.AddRange({Me.lblFormTitle, Me.lblMaCNM, Me.txtMaCNM,
                Me.lblMenu, Me.cboMenuPool, Me.lblNgayBD, Me.dtpNgayBD,
                Me.lblNgayKT, Me.dtpNgayKT, Me.chkCoNgayKT, Me.lblTrangThai,
                Me.cboTrangThai, Me.lblGhiChu, Me.txtGhiChu, Me.tlpButtons})
        End Sub

        Private Sub BuildLeftInputs()
            Me.lblMaCNM.Text = "Mã phân bổ:" : Me.lblMaCNM.Location = New Point(15, 42) : Me.lblMaCNM.AutoSize = True
            Me.txtMaCNM.Location = New Point(15, 60) : Me.txtMaCNM.Size = New Size(365, 25)
            Me.txtMaCNM.ReadOnly = True : Me.txtMaCNM.BackColor = Color.FromArgb(241, 245, 249)

            Me.lblMenu.Text = "Bảng thực đơn (Menu Master) (*):" : Me.lblMenu.Location = New Point(15, 95) : Me.lblMenu.AutoSize = True
            Me.cboMenuPool.Location = New Point(15, 115) : Me.cboMenuPool.Size = New Size(365, 25)
            Me.cboMenuPool.DropDownStyle = ComboBoxStyle.DropDownList

            Me.lblNgayBD.Text = "Ngày bắt đầu áp dụng (*):" : Me.lblNgayBD.Location = New Point(15, 150) : Me.lblNgayBD.AutoSize = True
            Me.dtpNgayBD.Location = New Point(15, 170) : Me.dtpNgayBD.Size = New Size(175, 25) : Me.dtpNgayBD.Format = DateTimePickerFormat.Short

            Me.lblNgayKT.Text = "Ngày kết thúc:" : Me.lblNgayKT.Location = New Point(205, 150) : Me.lblNgayKT.AutoSize = True
            Me.dtpNgayKT.Location = New Point(205, 170) : Me.dtpNgayKT.Size = New Size(175, 25) : Me.dtpNgayKT.Format = DateTimePickerFormat.Short
            Me.dtpNgayKT.Enabled = False

            Me.chkCoNgayKT.Text = "Có thời hạn kết thúc" : Me.chkCoNgayKT.Location = New Point(205, 198) : Me.chkCoNgayKT.AutoSize = True

            Me.lblTrangThai.Text = "Trạng thái tại chi nhánh:" : Me.lblTrangThai.Location = New Point(15, 225) : Me.lblTrangThai.AutoSize = True
            Me.cboTrangThai.Location = New Point(15, 245) : Me.cboTrangThai.Size = New Size(365, 25)
            Me.cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboTrangThai.Items.AddRange({"Đang áp dụng", "Tạm ngưng"})

            Me.lblGhiChu.Text = "Ghi chú phân bổ:" : Me.lblGhiChu.Location = New Point(15, 280) : Me.lblGhiChu.AutoSize = True
            Me.txtGhiChu.Location = New Point(15, 300) : Me.txtGhiChu.Size = New Size(365, 55) : Me.txtGhiChu.Multiline = True
        End Sub

        Private Sub BuildLeftButtons()
            Me.tlpButtons.Location = New Point(15, 370)
            Me.tlpButtons.Size = New Size(365, 38)
            Me.tlpButtons.ColumnCount = 4
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))
            Me.tlpButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0!))

            Me.btnGanMoi.Text = "➕ Gán Mới" : Me.btnGanMoi.Dock = DockStyle.Fill : Me.btnGanMoi.BackColor = Color.FromArgb(26, 82, 118) : Me.btnGanMoi.ForeColor = Color.White : Me.btnGanMoi.FlatStyle = FlatStyle.Flat
            Me.btnLuu.Text = "💾 Lưu" : Me.btnLuu.Dock = DockStyle.Fill : Me.btnLuu.BackColor = Color.FromArgb(39, 174, 96) : Me.btnLuu.ForeColor = Color.White : Me.btnLuu.FlatStyle = FlatStyle.Flat
            Me.btnGo.Text = "🗑️ Gỡ" : Me.btnGo.Dock = DockStyle.Fill : Me.btnGo.BackColor = Color.FromArgb(192, 57, 43) : Me.btnGo.ForeColor = Color.White : Me.btnGo.FlatStyle = FlatStyle.Flat
            Me.btnLamMoi.Text = "🔄 Mới" : Me.btnLamMoi.Dock = DockStyle.Fill : Me.btnLamMoi.BackColor = Color.FromArgb(100, 116, 139) : Me.btnLamMoi.ForeColor = Color.White : Me.btnLamMoi.FlatStyle = FlatStyle.Flat

            Me.tlpButtons.Controls.Add(Me.btnGanMoi, 0, 0)
            Me.tlpButtons.Controls.Add(Me.btnLuu, 1, 0)
            Me.tlpButtons.Controls.Add(Me.btnGo, 2, 0)
            Me.tlpButtons.Controls.Add(Me.btnLamMoi, 3, 0)
        End Sub

        Private Sub BuildRightGrid()
            Me.pnlRight.BackColor = Color.White
            Me.pnlRight.Dock = DockStyle.Fill
            Me.pnlRight.Padding = New Padding(15)

            Me.lblGridTitle.Text = "📋 CÁC THỰC ĐƠN ĐANG KINH DOANH TẠI CƠ SỞ"
            Me.lblGridTitle.Font = New Font("Segoe UI", 10.0!, FontStyle.Bold)
            Me.lblGridTitle.ForeColor = Color.FromArgb(26, 82, 118)
            Me.lblGridTitle.Dock = DockStyle.Top
            Me.lblGridTitle.Height = 28

            Me.pnlSearch.Dock = DockStyle.Top
            Me.pnlSearch.Height = 36
            Me.txtSearch.Location = New Point(0, 4)
            Me.txtSearch.Size = New Size(400, 25)
            Me.txtSearch.PlaceholderText = "🔍 Tìm kiếm theo tên thực đơn, ghi chú..."

            Me.cboFilterTrangThai.Location = New Point(410, 4)
            Me.cboFilterTrangThai.Size = New Size(180, 25)
            Me.cboFilterTrangThai.DropDownStyle = ComboBoxStyle.DropDownList
            Me.cboFilterTrangThai.Items.AddRange({"-- Tất cả trạng thái --", "Đang áp dụng", "Tạm ngưng"})
            Me.cboFilterTrangThai.SelectedIndex = 0

            Me.pnlSearch.Controls.AddRange({Me.txtSearch, Me.cboFilterTrangThai})

            FormatDataGrid()

            Me.pnlRight.Controls.Add(Me.dgvMenuChiNhanh)
            Me.pnlRight.Controls.Add(Me.pnlSearch)
            Me.pnlRight.Controls.Add(Me.lblGridTitle)
        End Sub

        Private Sub FormatDataGrid()
            Me.dgvMenuChiNhanh.Dock = DockStyle.Fill
            Me.dgvMenuChiNhanh.BackgroundColor = Color.White
            Me.dgvMenuChiNhanh.BorderStyle = BorderStyle.Fixed3D
            Me.dgvMenuChiNhanh.ReadOnly = True
            Me.dgvMenuChiNhanh.AllowUserToAddRows = False
            Me.dgvMenuChiNhanh.AllowUserToDeleteRows = False
            Me.dgvMenuChiNhanh.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.dgvMenuChiNhanh.MultiSelect = False
            Me.dgvMenuChiNhanh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvMenuChiNhanh.RowHeadersVisible = False
        End Sub

        Private Sub BuildLayout()
            Me.tlpMain.Dock = DockStyle.Fill
            Me.tlpMain.ColumnCount = 2
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0!))
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0!))
            Me.tlpMain.RowCount = 1
            Me.tlpMain.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0!))
            Me.tlpMain.Controls.Add(Me.pnlLeft, 0, 0)
            Me.tlpMain.Controls.Add(Me.pnlRight, 1, 0)

            Me.ssStatus.Items.Add(Me.tslStatus)
            Me.tslStatus.Text = "Sẵn sàng"

            Me.ClientSize = New Size(1184, 661)
            Me.Controls.Add(Me.tlpMain)
            Me.Controls.Add(Me.pnlBranchSelect)
            Me.Controls.Add(Me.ssStatus)
            Me.Controls.Add(Me.pnlHeader)
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Text = "Phân bổ Thực Đơn Chi Nhánh - Hương Việt"
            Me.Font = New Font("Segoe UI", 9.0!)
        End Sub

    End Class

End Namespace
