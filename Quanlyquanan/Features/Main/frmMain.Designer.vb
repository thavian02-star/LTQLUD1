Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Main
    <Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmMain
        Inherits System.Windows.Forms.Form

        ' Form overrides dispose to clean up the component list.
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

        ' Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        ' NOTE: The following procedure is required by the Windows Form Designer
        ' It can be modified using the Windows Form Designer.  
        ' Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.pnlBrand = New System.Windows.Forms.Panel()
            Me.lblBrandSubtitle = New System.Windows.Forms.Label()
            Me.lblBrandTitle = New System.Windows.Forms.Label()
            Me.lblBrandIcon = New System.Windows.Forms.Label()
            Me.pnlUserSection = New System.Windows.Forms.Panel()
            Me.btnDangXuat = New System.Windows.Forms.Button()
            Me.pnlUserProfile = New System.Windows.Forms.Panel()
            Me.lblUserRole = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblUserAvatar = New System.Windows.Forms.Label()
            Me.lblClock = New System.Windows.Forms.Label()
            Me.pnlSidebar = New System.Windows.Forms.Panel()
            Me.btnDoiMatKhau = New System.Windows.Forms.Button()
            Me.btnChamCongCaNhan = New System.Windows.Forms.Button()
            Me.lblGroupCaNhan = New System.Windows.Forms.Label()
            Me.btnBaoCao = New System.Windows.Forms.Button()
            Me.btnQuanLyThucDon = New System.Windows.Forms.Button()
            Me.btnQuanLyNhanSu = New System.Windows.Forms.Button()
            Me.btnDuyetChamCong = New System.Windows.Forms.Button()
            Me.lblGroupQuanLy = New System.Windows.Forms.Label()
            Me.btnNhaBep = New System.Windows.Forms.Button()
            Me.btnSoDoBan = New System.Windows.Forms.Button()
            Me.lblGroupBanHang = New System.Windows.Forms.Label()
            Me.appStatusStrip = New System.Windows.Forms.StatusStrip()
            Me.lblStatusDb = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblStatusSpring = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblStatusSession = New System.Windows.Forms.ToolStripStatusLabel()
            Me.lblStatusVersion = New System.Windows.Forms.ToolStripStatusLabel()
            Me.pnlContent = New System.Windows.Forms.Panel()
            Me.pnlDashboardHome = New System.Windows.Forms.Panel()
            Me.pnlDashboardRow = New System.Windows.Forms.Panel()
            Me.pnlActivity = New System.Windows.Forms.Panel()
            Me.lblActivityHeader = New System.Windows.Forms.Label()
            Me.lstActivity = New System.Windows.Forms.ListBox()
            Me.pnlQuickActions = New System.Windows.Forms.Panel()
            Me.tlpQuickButtons = New System.Windows.Forms.TableLayoutPanel()
            Me.btnQuickDatBan = New System.Windows.Forms.Button()
            Me.btnQuickNhaBep = New System.Windows.Forms.Button()
            Me.btnQuickChamCong = New System.Windows.Forms.Button()
            Me.btnQuickDuyetCong = New System.Windows.Forms.Button()
            Me.btnQuickThucDon = New System.Windows.Forms.Button()
            Me.btnQuickBaoCao = New System.Windows.Forms.Button()
            Me.lblQuickHeader = New System.Windows.Forms.Label()
            Me.tlpKpiGrid = New System.Windows.Forms.TableLayoutPanel()
            Me.pnlKpiDoanhThu = New System.Windows.Forms.Panel()
            Me.lblKpiDoanhThuValue = New System.Windows.Forms.Label()
            Me.lblKpiDoanhThuTitle = New System.Windows.Forms.Label()
            Me.pnlKpiNhanSu = New System.Windows.Forms.Panel()
            Me.lblKpiNhanSuValue = New System.Windows.Forms.Label()
            Me.lblKpiNhanSuTitle = New System.Windows.Forms.Label()
            Me.pnlKpiMonCho = New System.Windows.Forms.Panel()
            Me.lblKpiMonChoValue = New System.Windows.Forms.Label()
            Me.lblKpiMonChoTitle = New System.Windows.Forms.Label()
            Me.pnlKpiBan = New System.Windows.Forms.Panel()
            Me.lblKpiBanValue = New System.Windows.Forms.Label()
            Me.lblKpiBanTitle = New System.Windows.Forms.Label()
            Me.pnlWelcome = New System.Windows.Forms.Panel()
            Me.btnQuickOpenSoDoBan = New System.Windows.Forms.Button()
            Me.lblWelcomeSubtitle = New System.Windows.Forms.Label()
            Me.lblWelcomeGreeting = New System.Windows.Forms.Label()
            Me.tmrClock = New System.Windows.Forms.Timer(Me.components)
            Me.pnlHeader.SuspendLayout()
            Me.pnlBrand.SuspendLayout()
            Me.pnlUserSection.SuspendLayout()
            Me.pnlUserProfile.SuspendLayout()
            Me.pnlSidebar.SuspendLayout()
            Me.appStatusStrip.SuspendLayout()
            Me.pnlContent.SuspendLayout()
            Me.pnlDashboardHome.SuspendLayout()
            Me.pnlDashboardRow.SuspendLayout()
            Me.pnlActivity.SuspendLayout()
            Me.pnlQuickActions.SuspendLayout()
            Me.tlpQuickButtons.SuspendLayout()
            Me.tlpKpiGrid.SuspendLayout()
            Me.pnlKpiDoanhThu.SuspendLayout()
            Me.pnlKpiNhanSu.SuspendLayout()
            Me.pnlKpiMonCho.SuspendLayout()
            Me.pnlKpiBan.SuspendLayout()
            Me.pnlWelcome.SuspendLayout()
            Me.SuspendLayout()
            '
            ' pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.pnlBrand)
            Me.pnlHeader.Controls.Add(Me.pnlUserSection)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(1264, 65)
            Me.pnlHeader.TabIndex = 0
            '
            ' pnlBrand
            '
            Me.pnlBrand.Controls.Add(Me.lblBrandSubtitle)
            Me.pnlBrand.Controls.Add(Me.lblBrandTitle)
            Me.pnlBrand.Controls.Add(Me.lblBrandIcon)
            Me.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlBrand.Location = New System.Drawing.Point(0, 0)
            Me.pnlBrand.Name = "pnlBrand"
            Me.pnlBrand.Size = New System.Drawing.Size(420, 65)
            Me.pnlBrand.TabIndex = 0
            '
            ' lblBrandSubtitle
            '
            Me.lblBrandSubtitle.AutoSize = True
            Me.lblBrandSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(248, Byte), Integer))
            Me.lblBrandSubtitle.Location = New System.Drawing.Point(62, 36)
            Me.lblBrandSubtitle.Name = "lblBrandSubtitle"
            Me.lblBrandSubtitle.Size = New System.Drawing.Size(258, 15)
            Me.lblBrandSubtitle.TabIndex = 2
            Me.lblBrandSubtitle.Text = "PHÂN HỆ ĐIỀU HÀNH & BÁN HÀNG TẬP TRUNG"
            '
            ' lblBrandTitle
            '
            Me.lblBrandTitle.AutoSize = True
            Me.lblBrandTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblBrandTitle.ForeColor = System.Drawing.Color.White
            Me.lblBrandTitle.Location = New System.Drawing.Point(60, 12)
            Me.lblBrandTitle.Name = "lblBrandTitle"
            Me.lblBrandTitle.Size = New System.Drawing.Size(280, 25)
            Me.lblBrandTitle.TabIndex = 1
            Me.lblBrandTitle.Text = "HỆ THỐNG QUẢN LÝ QUÁN ĂN"
            '
            ' lblBrandIcon
            '
            Me.lblBrandIcon.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblBrandIcon.ForeColor = System.Drawing.Color.White
            Me.lblBrandIcon.Location = New System.Drawing.Point(12, 10)
            Me.lblBrandIcon.Name = "lblBrandIcon"
            Me.lblBrandIcon.Size = New System.Drawing.Size(44, 44)
            Me.lblBrandIcon.TabIndex = 0
            Me.lblBrandIcon.Text = "🏪"
            Me.lblBrandIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' pnlUserSection
            '
            Me.pnlUserSection.Controls.Add(Me.btnDangXuat)
            Me.pnlUserSection.Controls.Add(Me.pnlUserProfile)
            Me.pnlUserSection.Controls.Add(Me.lblClock)
            Me.pnlUserSection.Dock = System.Windows.Forms.DockStyle.Right
            Me.pnlUserSection.Location = New System.Drawing.Point(604, 0)
            Me.pnlUserSection.Name = "pnlUserSection"
            Me.pnlUserSection.Size = New System.Drawing.Size(660, 65)
            Me.pnlUserSection.TabIndex = 1
            '
            ' btnDangXuat
            '
            Me.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDangXuat.FlatAppearance.BorderSize = 0
            Me.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDangXuat.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnDangXuat.ForeColor = System.Drawing.Color.White
            Me.btnDangXuat.Location = New System.Drawing.Point(535, 15)
            Me.btnDangXuat.Name = "btnDangXuat"
            Me.btnDangXuat.Size = New System.Drawing.Size(115, 36)
            Me.btnDangXuat.TabIndex = 2
            Me.btnDangXuat.Text = "🚪 ĐĂNG XUẤT"
            Me.btnDangXuat.UseVisualStyleBackColor = False
            '
            ' pnlUserProfile
            '
            Me.pnlUserProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.pnlUserProfile.Controls.Add(Me.lblUserRole)
            Me.pnlUserProfile.Controls.Add(Me.lblUserName)
            Me.pnlUserProfile.Controls.Add(Me.lblUserAvatar)
            Me.pnlUserProfile.Location = New System.Drawing.Point(265, 12)
            Me.pnlUserProfile.Name = "pnlUserProfile"
            Me.pnlUserProfile.Size = New System.Drawing.Size(255, 42)
            Me.pnlUserProfile.TabIndex = 1
            '
            ' lblUserRole
            '
            Me.lblUserRole.AutoSize = True
            Me.lblUserRole.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(156, Byte), Integer), CType(CType(18, Byte), Integer))
            Me.lblUserRole.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUserRole.ForeColor = System.Drawing.Color.White
            Me.lblUserRole.Location = New System.Drawing.Point(48, 22)
            Me.lblUserRole.Name = "lblUserRole"
            Me.lblUserRole.Padding = New System.Windows.Forms.Padding(3, 1, 3, 1)
            Me.lblUserRole.Size = New System.Drawing.Size(65, 14)
            Me.lblUserRole.TabIndex = 2
            Me.lblUserRole.Text = "CHỦ QUÁN"
            '
            ' lblUserName
            '
            Me.lblUserName.AutoSize = True
            Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUserName.ForeColor = System.Drawing.Color.White
            Me.lblUserName.Location = New System.Drawing.Point(46, 5)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(128, 15)
            Me.lblUserName.TabIndex = 1
            Me.lblUserName.Text = "Nguyễn Văn Chủ Quán"
            '
            ' lblUserAvatar
            '
            Me.lblUserAvatar.BackColor = System.Drawing.Color.White
            Me.lblUserAvatar.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblUserAvatar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.lblUserAvatar.Location = New System.Drawing.Point(6, 6)
            Me.lblUserAvatar.Name = "lblUserAvatar"
            Me.lblUserAvatar.Size = New System.Drawing.Size(32, 30)
            Me.lblUserAvatar.TabIndex = 0
            Me.lblUserAvatar.Text = "CQ"
            Me.lblUserAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            ' lblClock
            '
            Me.lblClock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblClock.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(251, Byte), Integer))
            Me.lblClock.Location = New System.Drawing.Point(10, 16)
            Me.lblClock.Name = "lblClock"
            Me.lblClock.Size = New System.Drawing.Size(245, 34)
            Me.lblClock.TabIndex = 0
            Me.lblClock.Text = "🕒 17:00:00 - Thứ Tư, 04/11/2026"
            Me.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            ' pnlSidebar
            '
            Me.pnlSidebar.AutoScroll = True
            Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.pnlSidebar.Controls.Add(Me.btnDoiMatKhau)
            Me.pnlSidebar.Controls.Add(Me.btnChamCongCaNhan)
            Me.pnlSidebar.Controls.Add(Me.lblGroupCaNhan)
            Me.pnlSidebar.Controls.Add(Me.btnBaoCao)
            Me.pnlSidebar.Controls.Add(Me.btnQuanLyThucDon)
            Me.pnlSidebar.Controls.Add(Me.btnQuanLyNhanSu)
            Me.pnlSidebar.Controls.Add(Me.btnDuyetChamCong)
            Me.pnlSidebar.Controls.Add(Me.lblGroupQuanLy)
            Me.pnlSidebar.Controls.Add(Me.btnNhaBep)
            Me.pnlSidebar.Controls.Add(Me.btnSoDoBan)
            Me.pnlSidebar.Controls.Add(Me.lblGroupBanHang)
            Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlSidebar.Location = New System.Drawing.Point(0, 65)
            Me.pnlSidebar.Name = "pnlSidebar"
            Me.pnlSidebar.Padding = New System.Windows.Forms.Padding(0, 10, 0, 15)
            Me.pnlSidebar.Size = New System.Drawing.Size(250, 668)
            Me.pnlSidebar.TabIndex = 1
            '
            ' btnDoiMatKhau
            '
            Me.btnDoiMatKhau.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDoiMatKhau.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnDoiMatKhau.FlatAppearance.BorderSize = 0
            Me.btnDoiMatKhau.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDoiMatKhau.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnDoiMatKhau.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnDoiMatKhau.Location = New System.Drawing.Point(0, 422)
            Me.btnDoiMatKhau.Name = "btnDoiMatKhau"
            Me.btnDoiMatKhau.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnDoiMatKhau.Size = New System.Drawing.Size(250, 44)
            Me.btnDoiMatKhau.TabIndex = 10
            Me.btnDoiMatKhau.Tag = ""
            Me.btnDoiMatKhau.Text = "🔑  Đổi Mật Khẩu"
            Me.btnDoiMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnDoiMatKhau.UseVisualStyleBackColor = True
            '
            ' btnChamCongCaNhan
            '
            Me.btnChamCongCaNhan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnChamCongCaNhan.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnChamCongCaNhan.FlatAppearance.BorderSize = 0
            Me.btnChamCongCaNhan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnChamCongCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnChamCongCaNhan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnChamCongCaNhan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnChamCongCaNhan.Location = New System.Drawing.Point(0, 378)
            Me.btnChamCongCaNhan.Name = "btnChamCongCaNhan"
            Me.btnChamCongCaNhan.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnChamCongCaNhan.Size = New System.Drawing.Size(250, 44)
            Me.btnChamCongCaNhan.TabIndex = 9
            Me.btnChamCongCaNhan.Tag = "CA_NHAN_CHAM_CONG"
            Me.btnChamCongCaNhan.Text = "⏱️  Chấm Công Của Tôi"
            Me.btnChamCongCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnChamCongCaNhan.UseVisualStyleBackColor = True
            '
            ' lblGroupCaNhan
            '
            Me.lblGroupCaNhan.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblGroupCaNhan.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGroupCaNhan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
            Me.lblGroupCaNhan.Location = New System.Drawing.Point(0, 348)
            Me.lblGroupCaNhan.Name = "lblGroupCaNhan"
            Me.lblGroupCaNhan.Padding = New System.Windows.Forms.Padding(16, 12, 0, 0)
            Me.lblGroupCaNhan.Size = New System.Drawing.Size(250, 30)
            Me.lblGroupCaNhan.TabIndex = 8
            Me.lblGroupCaNhan.Text = "CÁ NHÂN & CÀI ĐẶT"
            '
            ' btnBaoCao
            '
            Me.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnBaoCao.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnBaoCao.FlatAppearance.BorderSize = 0
            Me.btnBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBaoCao.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnBaoCao.Location = New System.Drawing.Point(0, 304)
            Me.btnBaoCao.Name = "btnBaoCao"
            Me.btnBaoCao.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnBaoCao.Size = New System.Drawing.Size(250, 44)
            Me.btnBaoCao.TabIndex = 7
            Me.btnBaoCao.Tag = "CQ_BAO_CAO_THONG_KE"
            Me.btnBaoCao.Text = "📊  Báo Cáo Doanh Thu"
            Me.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBaoCao.UseVisualStyleBackColor = True
            '
            ' btnQuanLyThucDon
            '
            Me.btnQuanLyThucDon.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuanLyThucDon.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnQuanLyThucDon.FlatAppearance.BorderSize = 0
            Me.btnQuanLyThucDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnQuanLyThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuanLyThucDon.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnQuanLyThucDon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnQuanLyThucDon.Location = New System.Drawing.Point(0, 260)
            Me.btnQuanLyThucDon.Name = "btnQuanLyThucDon"
            Me.btnQuanLyThucDon.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnQuanLyThucDon.Size = New System.Drawing.Size(250, 44)
            Me.btnQuanLyThucDon.TabIndex = 6
            Me.btnQuanLyThucDon.Tag = "CQ_QUAN_LY_THUC_DON"
            Me.btnQuanLyThucDon.Text = "📋  Thực Đơn & Bàn Ghế"
            Me.btnQuanLyThucDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnQuanLyThucDon.UseVisualStyleBackColor = True
            '
            ' btnQuanLyNhanSu
            '
            Me.btnQuanLyNhanSu.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuanLyNhanSu.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnQuanLyNhanSu.FlatAppearance.BorderSize = 0
            Me.btnQuanLyNhanSu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnQuanLyNhanSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuanLyNhanSu.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnQuanLyNhanSu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnQuanLyNhanSu.Location = New System.Drawing.Point(0, 216)
            Me.btnQuanLyNhanSu.Name = "btnQuanLyNhanSu"
            Me.btnQuanLyNhanSu.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnQuanLyNhanSu.Size = New System.Drawing.Size(250, 44)
            Me.btnQuanLyNhanSu.TabIndex = 5
            Me.btnQuanLyNhanSu.Tag = "CQ_QUAN_LY_NHAN_VIEN"
            Me.btnQuanLyNhanSu.Text = "👥  Quản Lý Nhân Sự"
            Me.btnQuanLyNhanSu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnQuanLyNhanSu.UseVisualStyleBackColor = True
            '
            ' btnDuyetChamCong
            '
            Me.btnDuyetChamCong.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDuyetChamCong.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnDuyetChamCong.FlatAppearance.BorderSize = 0
            Me.btnDuyetChamCong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnDuyetChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDuyetChamCong.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnDuyetChamCong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnDuyetChamCong.Location = New System.Drawing.Point(0, 172)
            Me.btnDuyetChamCong.Name = "btnDuyetChamCong"
            Me.btnDuyetChamCong.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnDuyetChamCong.Size = New System.Drawing.Size(250, 44)
            Me.btnDuyetChamCong.TabIndex = 4
            Me.btnDuyetChamCong.Tag = "QL_DUYET_CHAM_CONG"
            Me.btnDuyetChamCong.Text = "🕒  Duyệt Chấm Công"
            Me.btnDuyetChamCong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnDuyetChamCong.UseVisualStyleBackColor = True
            '
            ' lblGroupQuanLy
            '
            Me.lblGroupQuanLy.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblGroupQuanLy.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGroupQuanLy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
            Me.lblGroupQuanLy.Location = New System.Drawing.Point(0, 142)
            Me.lblGroupQuanLy.Name = "lblGroupQuanLy"
            Me.lblGroupQuanLy.Padding = New System.Windows.Forms.Padding(16, 12, 0, 0)
            Me.lblGroupQuanLy.Size = New System.Drawing.Size(250, 30)
            Me.lblGroupQuanLy.TabIndex = 3
            Me.lblGroupQuanLy.Text = "QUẢN LÝ & VẬN HÀNH"
            '
            ' btnNhaBep
            '
            Me.btnNhaBep.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNhaBep.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnNhaBep.FlatAppearance.BorderSize = 0
            Me.btnNhaBep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnNhaBep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNhaBep.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnNhaBep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnNhaBep.Location = New System.Drawing.Point(0, 98)
            Me.btnNhaBep.Name = "btnNhaBep"
            Me.btnNhaBep.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnNhaBep.Size = New System.Drawing.Size(250, 44)
            Me.btnNhaBep.TabIndex = 2
            Me.btnNhaBep.Tag = "BEP_HANG_DOI_MON"
            Me.btnNhaBep.Text = "🍳  Nhà Bếp & Pha Chế"
            Me.btnNhaBep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnNhaBep.UseVisualStyleBackColor = True
            '
            ' btnSoDoBan
            '
            Me.btnSoDoBan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSoDoBan.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnSoDoBan.FlatAppearance.BorderSize = 0
            Me.btnSoDoBan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.btnSoDoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSoDoBan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.btnSoDoBan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.btnSoDoBan.Location = New System.Drawing.Point(0, 54)
            Me.btnSoDoBan.Name = "btnSoDoBan"
            Me.btnSoDoBan.Padding = New System.Windows.Forms.Padding(18, 0, 0, 0)
            Me.btnSoDoBan.Size = New System.Drawing.Size(250, 44)
            Me.btnSoDoBan.TabIndex = 1
            Me.btnSoDoBan.Tag = "POS_SO_DO_BAN"
            Me.btnSoDoBan.Text = "🍽️  Sơ Đồ Bàn Ăn"
            Me.btnSoDoBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSoDoBan.UseVisualStyleBackColor = True
            '
            ' lblGroupBanHang
            '
            Me.lblGroupBanHang.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblGroupBanHang.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblGroupBanHang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
            Me.lblGroupBanHang.Location = New System.Drawing.Point(0, 10)
            Me.lblGroupBanHang.Name = "lblGroupBanHang"
            Me.lblGroupBanHang.Padding = New System.Windows.Forms.Padding(16, 8, 0, 0)
            Me.lblGroupBanHang.Size = New System.Drawing.Size(250, 30)
            Me.lblGroupBanHang.TabIndex = 0
            Me.lblGroupBanHang.Text = "BÁN HÀNG & PHỤC VỤ"
            '
            ' appStatusStrip
            '
            Me.appStatusStrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.appStatusStrip.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.appStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatusDb, Me.lblStatusSpring, Me.lblStatusSession, Me.lblStatusVersion})
            Me.appStatusStrip.Location = New System.Drawing.Point(250, 709)
            Me.appStatusStrip.Name = "appStatusStrip"
            Me.appStatusStrip.Padding = New System.Windows.Forms.Padding(1, 0, 14, 0)
            Me.appStatusStrip.Size = New System.Drawing.Size(1014, 24)
            Me.appStatusStrip.TabIndex = 2
            '
            ' lblStatusDb
            '
            Me.lblStatusDb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(189, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.lblStatusDb.Name = "lblStatusDb"
            Me.lblStatusDb.Size = New System.Drawing.Size(430, 19)
            Me.lblStatusDb.Text = "🟢 CSDL: Microsoft SQL Server 2022 (Docker) - 172.20.218.246:1433 [QuanLyQuanAnDB]"
            '
            ' lblStatusSpring
            '
            Me.lblStatusSpring.Name = "lblStatusSpring"
            Me.lblStatusSpring.Size = New System.Drawing.Size(374, 19)
            Me.lblStatusSpring.Spring = True
            '
            ' lblStatusSession
            '
            Me.lblStatusSession.ForeColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(196, Byte), Integer), CType(CType(15, Byte), Integer))
            Me.lblStatusSession.Name = "lblStatusSession"
            Me.lblStatusSession.Size = New System.Drawing.Size(115, 19)
            Me.lblStatusSession.Text = "Phiên: TK_001 (chuquan)"
            '
            ' lblStatusVersion
            '
            Me.lblStatusVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
            Me.lblStatusVersion.Name = "lblStatusVersion"
            Me.lblStatusVersion.Size = New System.Drawing.Size(80, 19)
            Me.lblStatusVersion.Text = "| v1.0.0 (.NET 10)"
            '
            ' pnlContent
            '
            Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.pnlContent.Controls.Add(Me.pnlDashboardHome)
            Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContent.Location = New System.Drawing.Point(250, 65)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
            Me.pnlContent.Size = New System.Drawing.Size(1014, 644)
            Me.pnlContent.TabIndex = 3
            '
            ' pnlDashboardHome
            '
            Me.pnlDashboardHome.AutoScroll = True
            Me.pnlDashboardHome.Controls.Add(Me.pnlDashboardRow)
            Me.pnlDashboardHome.Controls.Add(Me.tlpKpiGrid)
            Me.pnlDashboardHome.Controls.Add(Me.pnlWelcome)
            Me.pnlDashboardHome.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlDashboardHome.Location = New System.Drawing.Point(20, 20)
            Me.pnlDashboardHome.Name = "pnlDashboardHome"
            Me.pnlDashboardHome.Size = New System.Drawing.Size(974, 604)
            Me.pnlDashboardHome.TabIndex = 0
            '
            ' pnlDashboardRow
            '
            Me.pnlDashboardRow.Controls.Add(Me.pnlActivity)
            Me.pnlDashboardRow.Controls.Add(Me.pnlQuickActions)
            Me.pnlDashboardRow.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlDashboardRow.Location = New System.Drawing.Point(0, 185)
            Me.pnlDashboardRow.Name = "pnlDashboardRow"
            Me.pnlDashboardRow.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
            Me.pnlDashboardRow.Size = New System.Drawing.Size(974, 419)
            Me.pnlDashboardRow.TabIndex = 2
            '
            ' pnlActivity
            '
            Me.pnlActivity.BackColor = System.Drawing.Color.White
            Me.pnlActivity.Controls.Add(Me.lblActivityHeader)
            Me.pnlActivity.Controls.Add(Me.lstActivity)
            Me.pnlActivity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlActivity.Location = New System.Drawing.Point(580, 15)
            Me.pnlActivity.Name = "pnlActivity"
            Me.pnlActivity.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlActivity.Size = New System.Drawing.Size(394, 404)
            Me.pnlActivity.TabIndex = 1
            '
            ' lblActivityHeader
            '
            Me.lblActivityHeader.AutoSize = True
            Me.lblActivityHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblActivityHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblActivityHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lblActivityHeader.Location = New System.Drawing.Point(16, 16)
            Me.lblActivityHeader.Name = "lblActivityHeader"
            Me.lblActivityHeader.Padding = New System.Windows.Forms.Padding(0, 0, 0, 12)
            Me.lblActivityHeader.Size = New System.Drawing.Size(161, 31)
            Me.lblActivityHeader.TabIndex = 0
            Me.lblActivityHeader.Text = "🔔 Hoạt Động Gần Đây"
            '
            ' lstActivity
            '
            Me.lstActivity.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lstActivity.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lstActivity.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lstActivity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lstActivity.FormattingEnabled = True
            Me.lstActivity.ItemHeight = 15
            Me.lstActivity.Items.AddRange(New Object() {
                "• [16:48] Bàn 05 gọi thêm 2 Lẩu Hải Sản",
                "• [16:42] Bếp báo xong món Bò Lúc Lắc (Bàn 02)",
                "• [16:30] Bàn 01 thanh toán thành công: 620.000 đ",
                "• [16:00] NV Lê Văn Phục Vụ 1 chấm công vào ca chiều",
                "• [15:45] Quản lý duyệt 3 bảng chấm công ca trưa"
            })
            Me.lstActivity.Location = New System.Drawing.Point(16, 47)
            Me.lstActivity.Name = "lstActivity"
            Me.lstActivity.Size = New System.Drawing.Size(362, 341)
            Me.lstActivity.TabIndex = 1
            '
            ' pnlQuickActions
            '
            Me.pnlQuickActions.BackColor = System.Drawing.Color.White
            Me.pnlQuickActions.Controls.Add(Me.tlpQuickButtons)
            Me.pnlQuickActions.Controls.Add(Me.lblQuickHeader)
            Me.pnlQuickActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.pnlQuickActions.Location = New System.Drawing.Point(0, 15)
            Me.pnlQuickActions.Name = "pnlQuickActions"
            Me.pnlQuickActions.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlQuickActions.Size = New System.Drawing.Size(565, 404)
            Me.pnlQuickActions.TabIndex = 0
            '
            ' tlpQuickButtons
            '
            Me.tlpQuickButtons.ColumnCount = 3
            Me.tlpQuickButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.tlpQuickButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.tlpQuickButtons.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickDatBan, 0, 0)
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickNhaBep, 1, 0)
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickChamCong, 2, 0)
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickDuyetCong, 0, 1)
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickThucDon, 1, 1)
            Me.tlpQuickButtons.Controls.Add(Me.btnQuickBaoCao, 2, 1)
            Me.tlpQuickButtons.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tlpQuickButtons.Location = New System.Drawing.Point(16, 47)
            Me.tlpQuickButtons.Name = "tlpQuickButtons"
            Me.tlpQuickButtons.RowCount = 2
            Me.tlpQuickButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlpQuickButtons.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.tlpQuickButtons.Size = New System.Drawing.Size(533, 341)
            Me.tlpQuickButtons.TabIndex = 1
            '
            ' btnQuickDatBan
            '
            Me.btnQuickDatBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickDatBan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickDatBan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickDatBan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickDatBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickDatBan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickDatBan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickDatBan.Location = New System.Drawing.Point(4, 4)
            Me.btnQuickDatBan.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickDatBan.Name = "btnQuickDatBan"
            Me.btnQuickDatBan.Size = New System.Drawing.Size(169, 162)
            Me.btnQuickDatBan.TabIndex = 0
            Me.btnQuickDatBan.Tag = "POS_SO_DO_BAN"
            Me.btnQuickDatBan.Text = "🍽️" & vbCrLf & vbCrLf & "Sơ Đồ Bàn / Gọi Món"
            Me.btnQuickDatBan.UseVisualStyleBackColor = False
            '
            ' btnQuickNhaBep
            '
            Me.btnQuickNhaBep.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickNhaBep.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickNhaBep.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickNhaBep.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickNhaBep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickNhaBep.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickNhaBep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickNhaBep.Location = New System.Drawing.Point(181, 4)
            Me.btnQuickNhaBep.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickNhaBep.Name = "btnQuickNhaBep"
            Me.btnQuickNhaBep.Size = New System.Drawing.Size(169, 162)
            Me.btnQuickNhaBep.TabIndex = 1
            Me.btnQuickNhaBep.Tag = "BEP_HANG_DOI_MON"
            Me.btnQuickNhaBep.Text = "🍳" & vbCrLf & vbCrLf & "Hàng Đợi Nhà Bếp"
            Me.btnQuickNhaBep.UseVisualStyleBackColor = False
            '
            ' btnQuickChamCong
            '
            Me.btnQuickChamCong.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickChamCong.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickChamCong.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickChamCong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickChamCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickChamCong.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickChamCong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickChamCong.Location = New System.Drawing.Point(358, 4)
            Me.btnQuickChamCong.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickChamCong.Name = "btnQuickChamCong"
            Me.btnQuickChamCong.Size = New System.Drawing.Size(171, 162)
            Me.btnQuickChamCong.TabIndex = 2
            Me.btnQuickChamCong.Tag = "CA_NHAN_CHAM_CONG"
            Me.btnQuickChamCong.Text = "⏱️" & vbCrLf & vbCrLf & "Chấm Công Vào Ca"
            Me.btnQuickChamCong.UseVisualStyleBackColor = False
            '
            ' btnQuickDuyetCong
            '
            Me.btnQuickDuyetCong.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickDuyetCong.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickDuyetCong.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickDuyetCong.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickDuyetCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickDuyetCong.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickDuyetCong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickDuyetCong.Location = New System.Drawing.Point(4, 174)
            Me.btnQuickDuyetCong.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickDuyetCong.Name = "btnQuickDuyetCong"
            Me.btnQuickDuyetCong.Size = New System.Drawing.Size(169, 163)
            Me.btnQuickDuyetCong.TabIndex = 3
            Me.btnQuickDuyetCong.Tag = "QL_DUYET_CHAM_CONG"
            Me.btnQuickDuyetCong.Text = "🕒" & vbCrLf & vbCrLf & "Duyệt Công Ca"
            Me.btnQuickDuyetCong.UseVisualStyleBackColor = False
            '
            ' btnQuickThucDon
            '
            Me.btnQuickThucDon.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickThucDon.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickThucDon.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickThucDon.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickThucDon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickThucDon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickThucDon.Location = New System.Drawing.Point(181, 174)
            Me.btnQuickThucDon.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickThucDon.Name = "btnQuickThucDon"
            Me.btnQuickThucDon.Size = New System.Drawing.Size(169, 163)
            Me.btnQuickThucDon.TabIndex = 4
            Me.btnQuickThucDon.Tag = "CQ_QUAN_LY_THUC_DON"
            Me.btnQuickThucDon.Text = "🍲" & vbCrLf & vbCrLf & "Cập Nhật Thực Đơn"
            Me.btnQuickThucDon.UseVisualStyleBackColor = False
            '
            ' btnQuickBaoCao
            '
            Me.btnQuickBaoCao.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
            Me.btnQuickBaoCao.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickBaoCao.Dock = System.Windows.Forms.DockStyle.Fill
            Me.btnQuickBaoCao.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
            Me.btnQuickBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickBaoCao.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickBaoCao.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnQuickBaoCao.Location = New System.Drawing.Point(358, 174)
            Me.btnQuickBaoCao.Margin = New System.Windows.Forms.Padding(4)
            Me.btnQuickBaoCao.Name = "btnQuickBaoCao"
            Me.btnQuickBaoCao.Size = New System.Drawing.Size(171, 163)
            Me.btnQuickBaoCao.TabIndex = 5
            Me.btnQuickBaoCao.Tag = "CQ_BAO_CAO_THONG_KE"
            Me.btnQuickBaoCao.Text = "📈" & vbCrLf & vbCrLf & "Báo Cáo Thống Kê"
            Me.btnQuickBaoCao.UseVisualStyleBackColor = False
            '
            ' lblQuickHeader
            '
            Me.lblQuickHeader.AutoSize = True
            Me.lblQuickHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblQuickHeader.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblQuickHeader.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lblQuickHeader.Location = New System.Drawing.Point(16, 16)
            Me.lblQuickHeader.Name = "lblQuickHeader"
            Me.lblQuickHeader.Padding = New System.Windows.Forms.Padding(0, 0, 0, 12)
            Me.lblQuickHeader.Size = New System.Drawing.Size(206, 31)
            Me.lblQuickHeader.TabIndex = 0
            Me.lblQuickHeader.Text = "⚡ Thao Tác Nghiệp Vụ Nhanh"
            '
            ' tlpKpiGrid
            '
            Me.tlpKpiGrid.ColumnCount = 4
            Me.tlpKpiGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.tlpKpiGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.tlpKpiGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.tlpKpiGrid.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
            Me.tlpKpiGrid.Controls.Add(Me.pnlKpiDoanhThu, 3, 0)
            Me.tlpKpiGrid.Controls.Add(Me.pnlKpiNhanSu, 2, 0)
            Me.tlpKpiGrid.Controls.Add(Me.pnlKpiMonCho, 1, 0)
            Me.tlpKpiGrid.Controls.Add(Me.pnlKpiBan, 0, 0)
            Me.tlpKpiGrid.Dock = System.Windows.Forms.DockStyle.Top
            Me.tlpKpiGrid.Location = New System.Drawing.Point(0, 85)
            Me.tlpKpiGrid.Name = "tlpKpiGrid"
            Me.tlpKpiGrid.RowCount = 1
            Me.tlpKpiGrid.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.tlpKpiGrid.Size = New System.Drawing.Size(974, 100)
            Me.tlpKpiGrid.TabIndex = 1
            '
            ' pnlKpiDoanhThu
            '
            Me.pnlKpiDoanhThu.BackColor = System.Drawing.Color.White
            Me.pnlKpiDoanhThu.Controls.Add(Me.lblKpiDoanhThuValue)
            Me.pnlKpiDoanhThu.Controls.Add(Me.lblKpiDoanhThuTitle)
            Me.pnlKpiDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiDoanhThu.Location = New System.Drawing.Point(733, 4)
            Me.pnlKpiDoanhThu.Margin = New System.Windows.Forms.Padding(4)
            Me.pnlKpiDoanhThu.Name = "pnlKpiDoanhThu"
            Me.pnlKpiDoanhThu.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlKpiDoanhThu.Size = New System.Drawing.Size(237, 92)
            Me.pnlKpiDoanhThu.TabIndex = 3
            '
            ' lblKpiDoanhThuValue
            '
            Me.lblKpiDoanhThuValue.AutoSize = True
            Me.lblKpiDoanhThuValue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiDoanhThuValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(173, Byte), Integer))
            Me.lblKpiDoanhThuValue.Location = New System.Drawing.Point(12, 42)
            Me.lblKpiDoanhThuValue.Name = "lblKpiDoanhThuValue"
            Me.lblKpiDoanhThuValue.Size = New System.Drawing.Size(130, 25)
            Me.lblKpiDoanhThuValue.TabIndex = 1
            Me.lblKpiDoanhThuValue.Text = "4.850.000 đ"
            '
            ' lblKpiDoanhThuTitle
            '
            Me.lblKpiDoanhThuTitle.AutoSize = True
            Me.lblKpiDoanhThuTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiDoanhThuTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.lblKpiDoanhThuTitle.Location = New System.Drawing.Point(12, 16)
            Me.lblKpiDoanhThuTitle.Name = "lblKpiDoanhThuTitle"
            Me.lblKpiDoanhThuTitle.Size = New System.Drawing.Size(149, 15)
            Me.lblKpiDoanhThuTitle.TabIndex = 0
            Me.lblKpiDoanhThuTitle.Text = "💰 DOANH THU HÔM NAY"
            '
            ' pnlKpiNhanSu
            '
            Me.pnlKpiNhanSu.BackColor = System.Drawing.Color.White
            Me.pnlKpiNhanSu.Controls.Add(Me.lblKpiNhanSuValue)
            Me.pnlKpiNhanSu.Controls.Add(Me.lblKpiNhanSuTitle)
            Me.pnlKpiNhanSu.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiNhanSu.Location = New System.Drawing.Point(490, 4)
            Me.pnlKpiNhanSu.Margin = New System.Windows.Forms.Padding(4)
            Me.pnlKpiNhanSu.Name = "pnlKpiNhanSu"
            Me.pnlKpiNhanSu.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlKpiNhanSu.Size = New System.Drawing.Size(235, 92)
            Me.pnlKpiNhanSu.TabIndex = 2
            '
            ' lblKpiNhanSuValue
            '
            Me.lblKpiNhanSuValue.AutoSize = True
            Me.lblKpiNhanSuValue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiNhanSuValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(39, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(96, Byte), Integer))
            Me.lblKpiNhanSuValue.Location = New System.Drawing.Point(12, 42)
            Me.lblKpiNhanSuValue.Name = "lblKpiNhanSuValue"
            Me.lblKpiNhanSuValue.Size = New System.Drawing.Size(86, 25)
            Me.lblKpiNhanSuValue.TabIndex = 1
            Me.lblKpiNhanSuValue.Text = "6 Người"
            '
            ' lblKpiNhanSuTitle
            '
            Me.lblKpiNhanSuTitle.AutoSize = True
            Me.lblKpiNhanSuTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiNhanSuTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.lblKpiNhanSuTitle.Location = New System.Drawing.Point(12, 16)
            Me.lblKpiNhanSuTitle.Name = "lblKpiNhanSuTitle"
            Me.lblKpiNhanSuTitle.Size = New System.Drawing.Size(147, 15)
            Me.lblKpiNhanSuTitle.TabIndex = 0
            Me.lblKpiNhanSuTitle.Text = "👨‍🍳 NHÂN SỰ TRONG CA"
            '
            ' pnlKpiMonCho
            '
            Me.pnlKpiMonCho.BackColor = System.Drawing.Color.White
            Me.pnlKpiMonCho.Controls.Add(Me.lblKpiMonChoValue)
            Me.pnlKpiMonCho.Controls.Add(Me.lblKpiMonChoTitle)
            Me.pnlKpiMonCho.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiMonCho.Location = New System.Drawing.Point(247, 4)
            Me.pnlKpiMonCho.Margin = New System.Windows.Forms.Padding(4)
            Me.pnlKpiMonCho.Name = "pnlKpiMonCho"
            Me.pnlKpiMonCho.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlKpiMonCho.Size = New System.Drawing.Size(235, 92)
            Me.pnlKpiMonCho.TabIndex = 1
            '
            ' lblKpiMonChoValue
            '
            Me.lblKpiMonChoValue.AutoSize = True
            Me.lblKpiMonChoValue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiMonChoValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(34, Byte), Integer))
            Me.lblKpiMonChoValue.Location = New System.Drawing.Point(12, 42)
            Me.lblKpiMonChoValue.Name = "lblKpiMonChoValue"
            Me.lblKpiMonChoValue.Size = New System.Drawing.Size(76, 25)
            Me.lblKpiMonChoValue.TabIndex = 1
            Me.lblKpiMonChoValue.Text = "5 Món"
            '
            ' lblKpiMonChoTitle
            '
            Me.lblKpiMonChoTitle.AutoSize = True
            Me.lblKpiMonChoTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiMonChoTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.lblKpiMonChoTitle.Location = New System.Drawing.Point(12, 16)
            Me.lblKpiMonChoTitle.Name = "lblKpiMonChoTitle"
            Me.lblKpiMonChoTitle.Size = New System.Drawing.Size(147, 15)
            Me.lblKpiMonChoTitle.TabIndex = 0
            Me.lblKpiMonChoTitle.Text = "🍜 MÓN CHỜ CHẾ BIẾN"
            '
            ' pnlKpiBan
            '
            Me.pnlKpiBan.BackColor = System.Drawing.Color.White
            Me.pnlKpiBan.Controls.Add(Me.lblKpiBanValue)
            Me.pnlKpiBan.Controls.Add(Me.lblKpiBanTitle)
            Me.pnlKpiBan.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlKpiBan.Location = New System.Drawing.Point(4, 4)
            Me.pnlKpiBan.Margin = New System.Windows.Forms.Padding(4)
            Me.pnlKpiBan.Name = "pnlKpiBan"
            Me.pnlKpiBan.Padding = New System.Windows.Forms.Padding(16)
            Me.pnlKpiBan.Size = New System.Drawing.Size(235, 92)
            Me.pnlKpiBan.TabIndex = 0
            '
            ' lblKpiBanValue
            '
            Me.lblKpiBanValue.AutoSize = True
            Me.lblKpiBanValue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiBanValue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.lblKpiBanValue.Location = New System.Drawing.Point(12, 42)
            Me.lblKpiBanValue.Name = "lblKpiBanValue"
            Me.lblKpiBanValue.Size = New System.Drawing.Size(78, 25)
            Me.lblKpiBanValue.TabIndex = 1
            Me.lblKpiBanValue.Text = "8 / 20"
            '
            ' lblKpiBanTitle
            '
            Me.lblKpiBanTitle.AutoSize = True
            Me.lblKpiBanTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblKpiBanTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.lblKpiBanTitle.Location = New System.Drawing.Point(12, 16)
            Me.lblKpiBanTitle.Name = "lblKpiBanTitle"
            Me.lblKpiBanTitle.Size = New System.Drawing.Size(155, 15)
            Me.lblKpiBanTitle.TabIndex = 0
            Me.lblKpiBanTitle.Text = "🪑 BÀN ĐANG PHỤC VỤ"
            '
            ' pnlWelcome
            '
            Me.pnlWelcome.BackColor = System.Drawing.Color.White
            Me.pnlWelcome.Controls.Add(Me.btnQuickOpenSoDoBan)
            Me.pnlWelcome.Controls.Add(Me.lblWelcomeSubtitle)
            Me.pnlWelcome.Controls.Add(Me.lblWelcomeGreeting)
            Me.pnlWelcome.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlWelcome.Location = New System.Drawing.Point(0, 0)
            Me.pnlWelcome.Name = "pnlWelcome"
            Me.pnlWelcome.Padding = New System.Windows.Forms.Padding(18)
            Me.pnlWelcome.Size = New System.Drawing.Size(974, 85)
            Me.pnlWelcome.TabIndex = 0
            '
            ' btnQuickOpenSoDoBan
            '
            Me.btnQuickOpenSoDoBan.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnQuickOpenSoDoBan.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.btnQuickOpenSoDoBan.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnQuickOpenSoDoBan.FlatAppearance.BorderSize = 0
            Me.btnQuickOpenSoDoBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickOpenSoDoBan.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnQuickOpenSoDoBan.ForeColor = System.Drawing.Color.White
            Me.btnQuickOpenSoDoBan.Location = New System.Drawing.Point(784, 22)
            Me.btnQuickOpenSoDoBan.Name = "btnQuickOpenSoDoBan"
            Me.btnQuickOpenSoDoBan.Size = New System.Drawing.Size(175, 40)
            Me.btnQuickOpenSoDoBan.TabIndex = 2
            Me.btnQuickOpenSoDoBan.Tag = "POS_SO_DO_BAN"
            Me.btnQuickOpenSoDoBan.Text = "⚡ Mở Sơ Đồ Bàn"
            Me.btnQuickOpenSoDoBan.UseVisualStyleBackColor = False
            '
            ' lblWelcomeSubtitle
            '
            Me.lblWelcomeSubtitle.AutoSize = True
            Me.lblWelcomeSubtitle.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.lblWelcomeSubtitle.Location = New System.Drawing.Point(18, 47)
            Me.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle"
            Me.lblWelcomeSubtitle.Size = New System.Drawing.Size(434, 17)
            Me.lblWelcomeSubtitle.TabIndex = 1
            Me.lblWelcomeSubtitle.Text = "Hôm nay hệ thống hoạt động ổn định. Chúc bạn một ngày làm việc hiệu quả!"
            '
            ' lblWelcomeGreeting
            '
            Me.lblWelcomeGreeting.AutoSize = True
            Me.lblWelcomeGreeting.Font = New System.Drawing.Font("Segoe UI", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblWelcomeGreeting.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lblWelcomeGreeting.Location = New System.Drawing.Point(16, 16)
            Me.lblWelcomeGreeting.Name = "lblWelcomeGreeting"
            Me.lblWelcomeGreeting.Size = New System.Drawing.Size(364, 28)
            Me.lblWelcomeGreeting.TabIndex = 0
            Me.lblWelcomeGreeting.Text = "Xin chào, Nguyễn Văn Chủ Quán! 👋"
            '
            ' tmrClock
            '
            Me.tmrClock.Enabled = True
            Me.tmrClock.Interval = 1000
            '
            ' frmMain
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(249, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1264, 733)
            Me.Controls.Add(Me.pnlContent)
            Me.Controls.Add(Me.appStatusStrip)
            Me.Controls.Add(Me.pnlSidebar)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.MinimumSize = New System.Drawing.Size(1150, 700)
            Me.Name = "frmMain"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Hệ Thống Quản Lý Quán Ăn - [Màn Hình Chính]"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlBrand.ResumeLayout(False)
            Me.pnlBrand.PerformLayout()
            Me.pnlUserSection.ResumeLayout(False)
            Me.pnlUserProfile.ResumeLayout(False)
            Me.pnlUserProfile.PerformLayout()
            Me.pnlSidebar.ResumeLayout(False)
            Me.appStatusStrip.ResumeLayout(False)
            Me.appStatusStrip.PerformLayout()
            Me.pnlContent.ResumeLayout(False)
            Me.pnlDashboardHome.ResumeLayout(False)
            Me.pnlDashboardRow.ResumeLayout(False)
            Me.pnlActivity.ResumeLayout(False)
            Me.pnlActivity.PerformLayout()
            Me.pnlQuickActions.ResumeLayout(False)
            Me.pnlQuickActions.PerformLayout()
            Me.tlpQuickButtons.ResumeLayout(False)
            Me.tlpKpiGrid.ResumeLayout(False)
            Me.pnlKpiDoanhThu.ResumeLayout(False)
            Me.pnlKpiDoanhThu.PerformLayout()
            Me.pnlKpiNhanSu.ResumeLayout(False)
            Me.pnlKpiNhanSu.PerformLayout()
            Me.pnlKpiMonCho.ResumeLayout(False)
            Me.pnlKpiMonCho.PerformLayout()
            Me.pnlKpiBan.ResumeLayout(False)
            Me.pnlKpiBan.PerformLayout()
            Me.pnlWelcome.ResumeLayout(False)
            Me.pnlWelcome.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents pnlBrand As System.Windows.Forms.Panel
        Friend WithEvents lblBrandIcon As System.Windows.Forms.Label
        Friend WithEvents lblBrandTitle As System.Windows.Forms.Label
        Friend WithEvents lblBrandSubtitle As System.Windows.Forms.Label
        Friend WithEvents pnlUserSection As System.Windows.Forms.Panel
        Friend WithEvents lblClock As System.Windows.Forms.Label
        Friend WithEvents pnlUserProfile As System.Windows.Forms.Panel
        Friend WithEvents lblUserAvatar As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblUserRole As System.Windows.Forms.Label
        Friend WithEvents btnDangXuat As System.Windows.Forms.Button
        Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
        Friend WithEvents lblGroupBanHang As System.Windows.Forms.Label
        Friend WithEvents btnSoDoBan As System.Windows.Forms.Button
        Friend WithEvents btnNhaBep As System.Windows.Forms.Button
        Friend WithEvents lblGroupQuanLy As System.Windows.Forms.Label
        Friend WithEvents btnDuyetChamCong As System.Windows.Forms.Button
        Friend WithEvents btnQuanLyNhanSu As System.Windows.Forms.Button
        Friend WithEvents btnQuanLyThucDon As System.Windows.Forms.Button
        Friend WithEvents btnBaoCao As System.Windows.Forms.Button
        Friend WithEvents lblGroupCaNhan As System.Windows.Forms.Label
        Friend WithEvents btnChamCongCaNhan As System.Windows.Forms.Button
        Friend WithEvents btnDoiMatKhau As System.Windows.Forms.Button
        Friend WithEvents appStatusStrip As System.Windows.Forms.StatusStrip
        Friend WithEvents lblStatusDb As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblStatusSpring As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblStatusSession As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents lblStatusVersion As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents pnlDashboardHome As System.Windows.Forms.Panel
        Friend WithEvents pnlWelcome As System.Windows.Forms.Panel
        Friend WithEvents lblWelcomeGreeting As System.Windows.Forms.Label
        Friend WithEvents lblWelcomeSubtitle As System.Windows.Forms.Label
        Friend WithEvents btnQuickOpenSoDoBan As System.Windows.Forms.Button
        Friend WithEvents tlpKpiGrid As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents pnlKpiBan As System.Windows.Forms.Panel
        Friend WithEvents lblKpiBanTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiBanValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiMonCho As System.Windows.Forms.Panel
        Friend WithEvents lblKpiMonChoTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiMonChoValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiNhanSu As System.Windows.Forms.Panel
        Friend WithEvents lblKpiNhanSuTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiNhanSuValue As System.Windows.Forms.Label
        Friend WithEvents pnlKpiDoanhThu As System.Windows.Forms.Panel
        Friend WithEvents lblKpiDoanhThuTitle As System.Windows.Forms.Label
        Friend WithEvents lblKpiDoanhThuValue As System.Windows.Forms.Label
        Friend WithEvents pnlDashboardRow As System.Windows.Forms.Panel
        Friend WithEvents pnlQuickActions As System.Windows.Forms.Panel
        Friend WithEvents lblQuickHeader As System.Windows.Forms.Label
        Friend WithEvents tlpQuickButtons As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents btnQuickDatBan As System.Windows.Forms.Button
        Friend WithEvents btnQuickNhaBep As System.Windows.Forms.Button
        Friend WithEvents btnQuickChamCong As System.Windows.Forms.Button
        Friend WithEvents btnQuickDuyetCong As System.Windows.Forms.Button
        Friend WithEvents btnQuickThucDon As System.Windows.Forms.Button
        Friend WithEvents btnQuickBaoCao As System.Windows.Forms.Button
        Friend WithEvents pnlActivity As System.Windows.Forms.Panel
        Friend WithEvents lblActivityHeader As System.Windows.Forms.Label
        Friend WithEvents lstActivity As System.Windows.Forms.ListBox
        Friend WithEvents tmrClock As System.Windows.Forms.Timer
    End Class
End Namespace
