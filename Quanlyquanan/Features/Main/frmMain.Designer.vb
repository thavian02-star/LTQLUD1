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
            components = New System.ComponentModel.Container()
            pnlHeader = New Panel()
            pnlBrand = New Panel()
            lblBrandSubtitle = New Label()
            lblBrandTitle = New Label()
            lblBrandIcon = New Label()
            pnlUserSection = New Panel()
            btnDangXuat = New Button()
            pnlUserProfile = New Panel()
            lblUserRole = New Label()
            lblUserName = New Label()
            lblUserAvatar = New Label()
            lblClock = New Label()
            pnlSidebar = New Panel()
            btnDoiMatKhau = New Button()
            btnChamCongCaNhan = New Button()
            lblGroupCaNhan = New Label()
            btnBaoCao = New Button()
            btnQuanLyThucDon = New Button()
            btnQuanLyNhanSu = New Button()
            btnDuyetChamCong = New Button()
            lblGroupQuanLy = New Label()
            btnNhaBep = New Button()
            btnSoDoBan = New Button()
            lblGroupBanHang = New Label()
            appStatusStrip = New StatusStrip()
            lblStatusDb = New ToolStripStatusLabel()
            lblStatusSpring = New ToolStripStatusLabel()
            lblStatusSession = New ToolStripStatusLabel()
            lblStatusVersion = New ToolStripStatusLabel()
            pnlContent = New Panel()
            pnlDashboardHome = New Panel()
            pnlDashboardRow = New TableLayoutPanel()
            pnlActivity = New Panel()
            lblActivityHeader = New Label()
            lstActivity = New ListBox()
            pnlQuickActions = New Panel()
            tlpQuickButtons = New TableLayoutPanel()
            btnQuickDatBan = New Button()
            btnQuickNhaBep = New Button()
            btnQuickChamCong = New Button()
            btnQuickDuyetCong = New Button()
            btnQuickThucDon = New Button()
            btnQuickBaoCao = New Button()
            lblQuickHeader = New Label()
            tlpKpiGrid = New TableLayoutPanel()
            pnlKpiDoanhThu = New Panel()
            lblKpiDoanhThuValue = New Label()
            lblKpiDoanhThuTitle = New Label()
            pnlKpiNhanSu = New Panel()
            lblKpiNhanSuValue = New Label()
            lblKpiNhanSuTitle = New Label()
            pnlKpiMonCho = New Panel()
            lblKpiMonChoValue = New Label()
            lblKpiMonChoTitle = New Label()
            pnlKpiBan = New Panel()
            lblKpiBanValue = New Label()
            lblKpiBanTitle = New Label()
            pnlWelcome = New Panel()
            btnQuickOpenSoDoBan = New Button()
            lblWelcomeSubtitle = New Label()
            lblWelcomeGreeting = New Label()
            tmrClock = New Timer(components)
            pnlHeader.SuspendLayout()
            pnlBrand.SuspendLayout()
            pnlUserSection.SuspendLayout()
            pnlUserProfile.SuspendLayout()
            pnlSidebar.SuspendLayout()
            appStatusStrip.SuspendLayout()
            pnlContent.SuspendLayout()
            pnlDashboardHome.SuspendLayout()
            pnlDashboardRow.SuspendLayout()
            pnlActivity.SuspendLayout()
            pnlQuickActions.SuspendLayout()
            tlpQuickButtons.SuspendLayout()
            tlpKpiGrid.SuspendLayout()
            pnlKpiDoanhThu.SuspendLayout()
            pnlKpiNhanSu.SuspendLayout()
            pnlKpiMonCho.SuspendLayout()
            pnlKpiBan.SuspendLayout()
            pnlWelcome.SuspendLayout()
            SuspendLayout()
            ' 
            ' pnlHeader
            ' 
            pnlHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            pnlHeader.Controls.Add(pnlBrand)
            pnlHeader.Controls.Add(pnlUserSection)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Location = New Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New Size(1264, 65)
            pnlHeader.TabIndex = 0
            ' 
            ' pnlBrand
            ' 
            pnlBrand.Controls.Add(lblBrandSubtitle)
            pnlBrand.Controls.Add(lblBrandTitle)
            pnlBrand.Controls.Add(lblBrandIcon)
            pnlBrand.Dock = DockStyle.Left
            pnlBrand.Location = New Point(0, 0)
            pnlBrand.Name = "pnlBrand"
            pnlBrand.Size = New Size(420, 65)
            pnlBrand.TabIndex = 0
            ' 
            ' lblBrandSubtitle
            ' 
            lblBrandSubtitle.AutoSize = True
            lblBrandSubtitle.Font = New Font("Segoe UI", 8.5F)
            lblBrandSubtitle.ForeColor = Color.FromArgb(CByte(214), CByte(234), CByte(248))
            lblBrandSubtitle.Location = New Point(62, 36)
            lblBrandSubtitle.Name = "lblBrandSubtitle"
            lblBrandSubtitle.Size = New Size(258, 15)
            lblBrandSubtitle.TabIndex = 2
            lblBrandSubtitle.Text = "PHÂN HỆ ĐIỀU HÀNH & BÁN HÀNG TẬP TRUNG"
            ' 
            ' lblBrandTitle
            ' 
            lblBrandTitle.AutoSize = True
            lblBrandTitle.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
            lblBrandTitle.ForeColor = Color.White
            lblBrandTitle.Location = New Point(60, 12)
            lblBrandTitle.Name = "lblBrandTitle"
            lblBrandTitle.Size = New Size(281, 25)
            lblBrandTitle.TabIndex = 1
            lblBrandTitle.Text = "HỆ THỐNG QUẢN LÝ QUÁN ĂN"
            ' 
            ' lblBrandIcon
            ' 
            lblBrandIcon.Font = New Font("Segoe UI", 20F)
            lblBrandIcon.ForeColor = Color.White
            lblBrandIcon.Location = New Point(12, 10)
            lblBrandIcon.Name = "lblBrandIcon"
            lblBrandIcon.Size = New Size(44, 44)
            lblBrandIcon.TabIndex = 0
            lblBrandIcon.Text = "🏪"
            lblBrandIcon.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' pnlUserSection
            ' 
            pnlUserSection.Controls.Add(btnDangXuat)
            pnlUserSection.Controls.Add(pnlUserProfile)
            pnlUserSection.Controls.Add(lblClock)
            pnlUserSection.Dock = DockStyle.Right
            pnlUserSection.Location = New Point(604, 0)
            pnlUserSection.Name = "pnlUserSection"
            pnlUserSection.Size = New Size(660, 65)
            pnlUserSection.TabIndex = 1
            ' 
            ' btnDangXuat
            ' 
            btnDangXuat.BackColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
            btnDangXuat.Cursor = Cursors.Hand
            btnDangXuat.FlatAppearance.BorderSize = 0
            btnDangXuat.FlatStyle = FlatStyle.Flat
            btnDangXuat.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnDangXuat.ForeColor = Color.White
            btnDangXuat.Location = New Point(535, 15)
            btnDangXuat.Name = "btnDangXuat"
            btnDangXuat.Size = New Size(115, 36)
            btnDangXuat.TabIndex = 2
            btnDangXuat.Text = "🚪 ĐĂNG XUẤT"
            btnDangXuat.UseVisualStyleBackColor = False
            ' 
            ' pnlUserProfile
            ' 
            pnlUserProfile.BackColor = Color.FromArgb(CByte(31), CByte(97), CByte(141))
            pnlUserProfile.Controls.Add(lblUserRole)
            pnlUserProfile.Controls.Add(lblUserName)
            pnlUserProfile.Controls.Add(lblUserAvatar)
            pnlUserProfile.Location = New Point(265, 12)
            pnlUserProfile.Name = "pnlUserProfile"
            pnlUserProfile.Size = New Size(255, 42)
            pnlUserProfile.TabIndex = 1
            ' 
            ' lblUserRole
            ' 
            lblUserRole.AutoSize = True
            lblUserRole.BackColor = Color.FromArgb(CByte(243), CByte(156), CByte(18))
            lblUserRole.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
            lblUserRole.ForeColor = Color.White
            lblUserRole.Location = New Point(48, 22)
            lblUserRole.Name = "lblUserRole"
            lblUserRole.Padding = New Padding(3, 1, 3, 1)
            lblUserRole.Size = New Size(65, 14)
            lblUserRole.TabIndex = 2
            lblUserRole.Text = "CHỦ QUÁN"
            ' 
            ' lblUserName
            ' 
            lblUserName.AutoSize = True
            lblUserName.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblUserName.ForeColor = Color.White
            lblUserName.Location = New Point(46, 5)
            lblUserName.Name = "lblUserName"
            lblUserName.Size = New Size(129, 15)
            lblUserName.TabIndex = 1
            lblUserName.Text = "Nguyễn Văn Chủ Quán"
            ' 
            ' lblUserAvatar
            ' 
            lblUserAvatar.BackColor = Color.White
            lblUserAvatar.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            lblUserAvatar.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            lblUserAvatar.Location = New Point(6, 6)
            lblUserAvatar.Name = "lblUserAvatar"
            lblUserAvatar.Size = New Size(32, 30)
            lblUserAvatar.TabIndex = 0
            lblUserAvatar.Text = "CQ"
            lblUserAvatar.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' lblClock
            ' 
            lblClock.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblClock.ForeColor = Color.FromArgb(CByte(235), CByte(245), CByte(251))
            lblClock.Location = New Point(10, 16)
            lblClock.Name = "lblClock"
            lblClock.Size = New Size(245, 34)
            lblClock.TabIndex = 0
            lblClock.Text = "🕒 17:00:00 - Thứ Tư, 04/11/2026"
            lblClock.TextAlign = ContentAlignment.MiddleRight
            ' 
            ' pnlSidebar
            ' 
            pnlSidebar.AutoScroll = True
            pnlSidebar.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            pnlSidebar.Controls.Add(btnDoiMatKhau)
            pnlSidebar.Controls.Add(btnChamCongCaNhan)
            pnlSidebar.Controls.Add(lblGroupCaNhan)
            pnlSidebar.Controls.Add(btnBaoCao)
            pnlSidebar.Controls.Add(btnQuanLyThucDon)
            pnlSidebar.Controls.Add(btnQuanLyNhanSu)
            pnlSidebar.Controls.Add(btnDuyetChamCong)
            pnlSidebar.Controls.Add(lblGroupQuanLy)
            pnlSidebar.Controls.Add(btnNhaBep)
            pnlSidebar.Controls.Add(btnSoDoBan)
            pnlSidebar.Controls.Add(lblGroupBanHang)
            pnlSidebar.Dock = DockStyle.Left
            pnlSidebar.Location = New Point(0, 65)
            pnlSidebar.Name = "pnlSidebar"
            pnlSidebar.Padding = New Padding(0, 10, 0, 15)
            pnlSidebar.Size = New Size(250, 668)
            pnlSidebar.TabIndex = 1
            ' 
            ' btnDoiMatKhau
            ' 
            btnDoiMatKhau.Cursor = Cursors.Hand
            btnDoiMatKhau.Dock = DockStyle.Top
            btnDoiMatKhau.FlatAppearance.BorderSize = 0
            btnDoiMatKhau.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnDoiMatKhau.FlatStyle = FlatStyle.Flat
            btnDoiMatKhau.Font = New Font("Segoe UI", 9.5F)
            btnDoiMatKhau.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnDoiMatKhau.Location = New Point(0, 408)
            btnDoiMatKhau.Name = "btnDoiMatKhau"
            btnDoiMatKhau.Padding = New Padding(18, 0, 0, 0)
            btnDoiMatKhau.Size = New Size(250, 44)
            btnDoiMatKhau.TabIndex = 10
            btnDoiMatKhau.Tag = ""
            btnDoiMatKhau.Text = "🔑  Đổi Mật Khẩu"
            btnDoiMatKhau.TextAlign = ContentAlignment.MiddleLeft
            btnDoiMatKhau.UseVisualStyleBackColor = True
            ' 
            ' btnChamCongCaNhan
            ' 
            btnChamCongCaNhan.Cursor = Cursors.Hand
            btnChamCongCaNhan.Dock = DockStyle.Top
            btnChamCongCaNhan.FlatAppearance.BorderSize = 0
            btnChamCongCaNhan.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnChamCongCaNhan.FlatStyle = FlatStyle.Flat
            btnChamCongCaNhan.Font = New Font("Segoe UI", 9.5F)
            btnChamCongCaNhan.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnChamCongCaNhan.Location = New Point(0, 364)
            btnChamCongCaNhan.Name = "btnChamCongCaNhan"
            btnChamCongCaNhan.Padding = New Padding(18, 0, 0, 0)
            btnChamCongCaNhan.Size = New Size(250, 44)
            btnChamCongCaNhan.TabIndex = 9
            btnChamCongCaNhan.Tag = "CA_NHAN_CHAM_CONG"
            btnChamCongCaNhan.Text = "⏱️  Chấm Công Của Tôi"
            btnChamCongCaNhan.TextAlign = ContentAlignment.MiddleLeft
            btnChamCongCaNhan.UseVisualStyleBackColor = True
            ' 
            ' lblGroupCaNhan
            ' 
            lblGroupCaNhan.Dock = DockStyle.Top
            lblGroupCaNhan.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
            lblGroupCaNhan.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            lblGroupCaNhan.Location = New Point(0, 334)
            lblGroupCaNhan.Name = "lblGroupCaNhan"
            lblGroupCaNhan.Padding = New Padding(16, 12, 0, 0)
            lblGroupCaNhan.Size = New Size(250, 30)
            lblGroupCaNhan.TabIndex = 8
            lblGroupCaNhan.Text = "CÁ NHÂN & CÀI ĐẶT"
            ' 
            ' btnBaoCao
            ' 
            btnBaoCao.Cursor = Cursors.Hand
            btnBaoCao.Dock = DockStyle.Top
            btnBaoCao.FlatAppearance.BorderSize = 0
            btnBaoCao.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnBaoCao.FlatStyle = FlatStyle.Flat
            btnBaoCao.Font = New Font("Segoe UI", 9.5F)
            btnBaoCao.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnBaoCao.Location = New Point(0, 290)
            btnBaoCao.Name = "btnBaoCao"
            btnBaoCao.Padding = New Padding(18, 0, 0, 0)
            btnBaoCao.Size = New Size(250, 44)
            btnBaoCao.TabIndex = 7
            btnBaoCao.Tag = "CQ_BAO_CAO_THONG_KE"
            btnBaoCao.Text = "📊  Báo Cáo Doanh Thu"
            btnBaoCao.TextAlign = ContentAlignment.MiddleLeft
            btnBaoCao.UseVisualStyleBackColor = True
            ' 
            ' btnQuanLyThucDon
            ' 
            btnQuanLyThucDon.Cursor = Cursors.Hand
            btnQuanLyThucDon.Dock = DockStyle.Top
            btnQuanLyThucDon.FlatAppearance.BorderSize = 0
            btnQuanLyThucDon.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnQuanLyThucDon.FlatStyle = FlatStyle.Flat
            btnQuanLyThucDon.Font = New Font("Segoe UI", 9.5F)
            btnQuanLyThucDon.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnQuanLyThucDon.Location = New Point(0, 246)
            btnQuanLyThucDon.Name = "btnQuanLyThucDon"
            btnQuanLyThucDon.Padding = New Padding(18, 0, 0, 0)
            btnQuanLyThucDon.Size = New Size(250, 44)
            btnQuanLyThucDon.TabIndex = 6
            btnQuanLyThucDon.Tag = "CQ_QUAN_LY_THUC_DON"
            btnQuanLyThucDon.Text = "📋  Thực Đơn & Bàn Ghế"
            btnQuanLyThucDon.TextAlign = ContentAlignment.MiddleLeft
            btnQuanLyThucDon.UseVisualStyleBackColor = True
            ' 
            ' btnQuanLyNhanSu
            ' 
            btnQuanLyNhanSu.Cursor = Cursors.Hand
            btnQuanLyNhanSu.Dock = DockStyle.Top
            btnQuanLyNhanSu.FlatAppearance.BorderSize = 0
            btnQuanLyNhanSu.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnQuanLyNhanSu.FlatStyle = FlatStyle.Flat
            btnQuanLyNhanSu.Font = New Font("Segoe UI", 9.5F)
            btnQuanLyNhanSu.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnQuanLyNhanSu.Location = New Point(0, 202)
            btnQuanLyNhanSu.Name = "btnQuanLyNhanSu"
            btnQuanLyNhanSu.Padding = New Padding(18, 0, 0, 0)
            btnQuanLyNhanSu.Size = New Size(250, 44)
            btnQuanLyNhanSu.TabIndex = 5
            btnQuanLyNhanSu.Tag = "CQ_QUAN_LY_NHAN_VIEN"
            btnQuanLyNhanSu.Text = "👥  Quản Lý Nhân Sự"
            btnQuanLyNhanSu.TextAlign = ContentAlignment.MiddleLeft
            btnQuanLyNhanSu.UseVisualStyleBackColor = True
            ' 
            ' btnDuyetChamCong
            ' 
            btnDuyetChamCong.Cursor = Cursors.Hand
            btnDuyetChamCong.Dock = DockStyle.Top
            btnDuyetChamCong.FlatAppearance.BorderSize = 0
            btnDuyetChamCong.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnDuyetChamCong.FlatStyle = FlatStyle.Flat
            btnDuyetChamCong.Font = New Font("Segoe UI", 9.5F)
            btnDuyetChamCong.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnDuyetChamCong.Location = New Point(0, 158)
            btnDuyetChamCong.Name = "btnDuyetChamCong"
            btnDuyetChamCong.Padding = New Padding(18, 0, 0, 0)
            btnDuyetChamCong.Size = New Size(250, 44)
            btnDuyetChamCong.TabIndex = 4
            btnDuyetChamCong.Tag = "QL_DUYET_CHAM_CONG"
            btnDuyetChamCong.Text = "🕒  Duyệt Chấm Công"
            btnDuyetChamCong.TextAlign = ContentAlignment.MiddleLeft
            btnDuyetChamCong.UseVisualStyleBackColor = True
            ' 
            ' lblGroupQuanLy
            ' 
            lblGroupQuanLy.Dock = DockStyle.Top
            lblGroupQuanLy.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
            lblGroupQuanLy.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            lblGroupQuanLy.Location = New Point(0, 128)
            lblGroupQuanLy.Name = "lblGroupQuanLy"
            lblGroupQuanLy.Padding = New Padding(16, 12, 0, 0)
            lblGroupQuanLy.Size = New Size(250, 30)
            lblGroupQuanLy.TabIndex = 3
            lblGroupQuanLy.Text = "QUẢN LÝ & VẬN HÀNH"
            ' 
            ' btnNhaBep
            ' 
            btnNhaBep.Cursor = Cursors.Hand
            btnNhaBep.Dock = DockStyle.Top
            btnNhaBep.FlatAppearance.BorderSize = 0
            btnNhaBep.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnNhaBep.FlatStyle = FlatStyle.Flat
            btnNhaBep.Font = New Font("Segoe UI", 9.5F)
            btnNhaBep.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnNhaBep.Location = New Point(0, 84)
            btnNhaBep.Name = "btnNhaBep"
            btnNhaBep.Padding = New Padding(18, 0, 0, 0)
            btnNhaBep.Size = New Size(250, 44)
            btnNhaBep.TabIndex = 2
            btnNhaBep.Tag = "BEP_HANG_DOI_MON"
            btnNhaBep.Text = "🍳  Nhà Bếp & Pha Chế"
            btnNhaBep.TextAlign = ContentAlignment.MiddleLeft
            btnNhaBep.UseVisualStyleBackColor = True
            ' 
            ' btnSoDoBan
            ' 
            btnSoDoBan.Cursor = Cursors.Hand
            btnSoDoBan.Dock = DockStyle.Top
            btnSoDoBan.FlatAppearance.BorderSize = 0
            btnSoDoBan.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(52), CByte(73), CByte(94))
            btnSoDoBan.FlatStyle = FlatStyle.Flat
            btnSoDoBan.Font = New Font("Segoe UI", 9.5F)
            btnSoDoBan.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            btnSoDoBan.Location = New Point(0, 40)
            btnSoDoBan.Name = "btnSoDoBan"
            btnSoDoBan.Padding = New Padding(18, 0, 0, 0)
            btnSoDoBan.Size = New Size(250, 44)
            btnSoDoBan.TabIndex = 1
            btnSoDoBan.Tag = "POS_SO_DO_BAN"
            btnSoDoBan.Text = "🍽️  Sơ Đồ Bàn Ăn"
            btnSoDoBan.TextAlign = ContentAlignment.MiddleLeft
            btnSoDoBan.UseVisualStyleBackColor = True
            ' 
            ' lblGroupBanHang
            ' 
            lblGroupBanHang.Dock = DockStyle.Top
            lblGroupBanHang.Font = New Font("Segoe UI", 7.5F, FontStyle.Bold)
            lblGroupBanHang.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            lblGroupBanHang.Location = New Point(0, 10)
            lblGroupBanHang.Name = "lblGroupBanHang"
            lblGroupBanHang.Padding = New Padding(16, 8, 0, 0)
            lblGroupBanHang.Size = New Size(250, 30)
            lblGroupBanHang.TabIndex = 0
            lblGroupBanHang.Text = "BÁN HÀNG & PHỤC VỤ"
            ' 
            ' appStatusStrip
            ' 
            appStatusStrip.BackColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            appStatusStrip.Font = New Font("Segoe UI", 8.5F)
            appStatusStrip.Items.AddRange(New ToolStripItem() {lblStatusDb, lblStatusSpring, lblStatusSession, lblStatusVersion})
            appStatusStrip.Location = New Point(250, 711)
            appStatusStrip.Name = "appStatusStrip"
            appStatusStrip.Size = New Size(1014, 22)
            appStatusStrip.TabIndex = 2
            ' 
            ' lblStatusDb
            ' 
            lblStatusDb.ForeColor = Color.FromArgb(CByte(189), CByte(195), CByte(199))
            lblStatusDb.Name = "lblStatusDb"
            lblStatusDb.Size = New Size(464, 17)
            lblStatusDb.Text = ChrW(55357) & ChrW(57314) & " CSDL: Microsoft SQL Server 2022 (Docker) - 172.20.218.246:1433 [QuanLyQuanAnDB]"
            ' 
            ' lblStatusSpring
            ' 
            lblStatusSpring.Name = "lblStatusSpring"
            lblStatusSpring.Size = New Size(303, 17)
            lblStatusSpring.Spring = True
            ' 
            ' lblStatusSession
            ' 
            lblStatusSession.ForeColor = Color.FromArgb(CByte(241), CByte(196), CByte(15))
            lblStatusSession.Name = "lblStatusSession"
            lblStatusSession.Size = New Size(138, 17)
            lblStatusSession.Text = "Phiên: TK_001 (chuquan)"
            ' 
            ' lblStatusVersion
            ' 
            lblStatusVersion.ForeColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            lblStatusVersion.Name = "lblStatusVersion"
            lblStatusVersion.Size = New Size(94, 17)
            lblStatusVersion.Text = "| v1.0.0 (.NET 10)"
            ' 
            ' pnlContent
            ' 
            pnlContent.BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(249))
            pnlContent.Controls.Add(pnlDashboardHome)
            pnlContent.Dock = DockStyle.Fill
            pnlContent.Location = New Point(250, 65)
            pnlContent.Name = "pnlContent"
            pnlContent.Padding = New Padding(20)
            pnlContent.Size = New Size(1014, 646)
            pnlContent.TabIndex = 3
            ' 
            ' pnlDashboardHome
            ' 
            pnlDashboardHome.AutoScroll = True
            pnlDashboardHome.Controls.Add(pnlDashboardRow)
            pnlDashboardHome.Controls.Add(tlpKpiGrid)
            pnlDashboardHome.Controls.Add(pnlWelcome)
            pnlDashboardHome.Dock = DockStyle.Fill
            pnlDashboardHome.Location = New Point(20, 20)
            pnlDashboardHome.Name = "pnlDashboardHome"
            pnlDashboardHome.Size = New Size(974, 606)
            pnlDashboardHome.TabIndex = 0
            ' 
            ' pnlDashboardRow
            ' 
            pnlDashboardRow.ColumnCount = 2
            pnlDashboardRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60F))
            pnlDashboardRow.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40F))
            pnlDashboardRow.Controls.Add(pnlQuickActions, 0, 0)
            pnlDashboardRow.Controls.Add(pnlActivity, 1, 0)
            pnlDashboardRow.RowCount = 1
            pnlDashboardRow.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
            pnlDashboardRow.Dock = DockStyle.Fill
            pnlDashboardRow.Location = New Point(0, 185)
            pnlDashboardRow.Name = "pnlDashboardRow"
            pnlDashboardRow.Padding = New Padding(0, 15, 0, 0)
            pnlDashboardRow.Size = New Size(974, 421)
            pnlDashboardRow.TabIndex = 2
            ' 
            ' pnlActivity
            ' 
            pnlActivity.BackColor = Color.White
            pnlActivity.Controls.Add(lstActivity) ' Index 0: Dock = Fill (nam duoi Header)
            pnlActivity.Controls.Add(lblActivityHeader) ' Index 1: Dock = Top (nam tren cung)
            pnlActivity.Dock = DockStyle.Fill
            pnlActivity.Location = New Point(592, 15)
            pnlActivity.Margin = New Padding(8, 0, 0, 0)
            pnlActivity.Name = "pnlActivity"
            pnlActivity.Padding = New Padding(16)
            pnlActivity.Size = New Size(382, 406)
            pnlActivity.TabIndex = 1
            ' 
            ' lblActivityHeader
            ' 
            lblActivityHeader.AutoSize = False
            lblActivityHeader.Dock = DockStyle.Top
            lblActivityHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            lblActivityHeader.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblActivityHeader.Location = New Point(16, 16)
            lblActivityHeader.Name = "lblActivityHeader"
            lblActivityHeader.Padding = New Padding(0, 0, 0, 8)
            lblActivityHeader.Size = New Size(350, 32)
            lblActivityHeader.TextAlign = ContentAlignment.MiddleLeft
            lblActivityHeader.TabIndex = 0
            lblActivityHeader.Text = "🔔 Hoạt Động Gần Đây"
            ' 
            ' lstActivity
            ' 
            lstActivity.BorderStyle = BorderStyle.None
            lstActivity.Dock = DockStyle.Fill
            lstActivity.Font = New Font("Segoe UI", 9.5F)
            lstActivity.ItemHeight = 20
            lstActivity.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lstActivity.FormattingEnabled = True
            lstActivity.Items.AddRange(New Object() {"• [16:48] Bàn 05 gọi thêm 2 Lẩu Hải Sản", "• [16:42] Bếp báo xong món Bò Lúc Lắc (Bàn 02)", "• [16:30] Bàn 01 thanh toán thành công: 620.000 đ", "• [16:00] NV Lê Văn Phục Vụ 1 chấm công vào ca chiều", "• [15:45] Quản lý duyệt 3 bảng chấm công ca trưa"})
            lstActivity.Location = New Point(16, 48)
            lstActivity.Name = "lstActivity"
            lstActivity.Size = New Size(350, 342)
            lstActivity.TabIndex = 1
            ' 
            ' pnlQuickActions
            ' 
            pnlQuickActions.BackColor = Color.White
            pnlQuickActions.Controls.Add(tlpQuickButtons)
            pnlQuickActions.Controls.Add(lblQuickHeader)
            pnlQuickActions.Dock = DockStyle.Fill
            pnlQuickActions.Margin = New Padding(0, 0, 8, 0)
            pnlQuickActions.Location = New Point(0, 15)
            pnlQuickActions.Name = "pnlQuickActions"
            pnlQuickActions.Padding = New Padding(16)
            pnlQuickActions.Size = New Size(576, 406)
            pnlQuickActions.TabIndex = 0
            ' 
            ' tlpQuickButtons
            ' 
            tlpQuickButtons.ColumnCount = 3
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33333F))
            tlpQuickButtons.Controls.Add(btnQuickDatBan, 0, 0)
            tlpQuickButtons.Controls.Add(btnQuickNhaBep, 1, 0)
            tlpQuickButtons.Controls.Add(btnQuickChamCong, 2, 0)
            tlpQuickButtons.Controls.Add(btnQuickDuyetCong, 0, 1)
            tlpQuickButtons.Controls.Add(btnQuickThucDon, 1, 1)
            tlpQuickButtons.Controls.Add(btnQuickBaoCao, 2, 1)
            tlpQuickButtons.Dock = DockStyle.Fill
            tlpQuickButtons.Location = New Point(16, 48)
            tlpQuickButtons.Name = "tlpQuickButtons"
            tlpQuickButtons.RowCount = 2
            tlpQuickButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
            tlpQuickButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
            tlpQuickButtons.Size = New Size(544, 342)
            tlpQuickButtons.TabIndex = 1
            ' 
            ' btnQuickDatBan
            ' 
            btnQuickDatBan.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickDatBan.Cursor = Cursors.Hand
            btnQuickDatBan.Dock = DockStyle.Fill
            btnQuickDatBan.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickDatBan.FlatStyle = FlatStyle.Flat
            btnQuickDatBan.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickDatBan.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickDatBan.Location = New Point(4, 4)
            btnQuickDatBan.Margin = New Padding(4)
            btnQuickDatBan.Name = "btnQuickDatBan"
            btnQuickDatBan.Size = New Size(169, 163)
            btnQuickDatBan.TabIndex = 0
            btnQuickDatBan.Tag = "POS_SO_DO_BAN"
            btnQuickDatBan.Text = "🍽️" & vbCrLf & vbCrLf & "Sơ Đồ Bàn / Gọi Món"
            btnQuickDatBan.UseVisualStyleBackColor = False
            ' 
            ' btnQuickNhaBep
            ' 
            btnQuickNhaBep.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickNhaBep.Cursor = Cursors.Hand
            btnQuickNhaBep.Dock = DockStyle.Fill
            btnQuickNhaBep.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickNhaBep.FlatStyle = FlatStyle.Flat
            btnQuickNhaBep.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickNhaBep.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickNhaBep.Location = New Point(181, 4)
            btnQuickNhaBep.Margin = New Padding(4)
            btnQuickNhaBep.Name = "btnQuickNhaBep"
            btnQuickNhaBep.Size = New Size(169, 163)
            btnQuickNhaBep.TabIndex = 1
            btnQuickNhaBep.Tag = "BEP_HANG_DOI_MON"
            btnQuickNhaBep.Text = "🍳" & vbCrLf & vbCrLf & "Hàng Đợi Nhà Bếp"
            btnQuickNhaBep.UseVisualStyleBackColor = False
            ' 
            ' btnQuickChamCong
            ' 
            btnQuickChamCong.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickChamCong.Cursor = Cursors.Hand
            btnQuickChamCong.Dock = DockStyle.Fill
            btnQuickChamCong.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickChamCong.FlatStyle = FlatStyle.Flat
            btnQuickChamCong.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickChamCong.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickChamCong.Location = New Point(358, 4)
            btnQuickChamCong.Margin = New Padding(4)
            btnQuickChamCong.Name = "btnQuickChamCong"
            btnQuickChamCong.Size = New Size(171, 163)
            btnQuickChamCong.TabIndex = 2
            btnQuickChamCong.Tag = "CA_NHAN_CHAM_CONG"
            btnQuickChamCong.Text = "⏱️" & vbCrLf & vbCrLf & "Chấm Công Vào Ca"
            btnQuickChamCong.UseVisualStyleBackColor = False
            ' 
            ' btnQuickDuyetCong
            ' 
            btnQuickDuyetCong.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickDuyetCong.Cursor = Cursors.Hand
            btnQuickDuyetCong.Dock = DockStyle.Fill
            btnQuickDuyetCong.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickDuyetCong.FlatStyle = FlatStyle.Flat
            btnQuickDuyetCong.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickDuyetCong.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickDuyetCong.Location = New Point(4, 175)
            btnQuickDuyetCong.Margin = New Padding(4)
            btnQuickDuyetCong.Name = "btnQuickDuyetCong"
            btnQuickDuyetCong.Size = New Size(169, 164)
            btnQuickDuyetCong.TabIndex = 3
            btnQuickDuyetCong.Tag = "QL_DUYET_CHAM_CONG"
            btnQuickDuyetCong.Text = "🕒" & vbCrLf & vbCrLf & "Duyệt Công Ca"
            btnQuickDuyetCong.UseVisualStyleBackColor = False
            ' 
            ' btnQuickThucDon
            ' 
            btnQuickThucDon.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickThucDon.Cursor = Cursors.Hand
            btnQuickThucDon.Dock = DockStyle.Fill
            btnQuickThucDon.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickThucDon.FlatStyle = FlatStyle.Flat
            btnQuickThucDon.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickThucDon.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickThucDon.Location = New Point(181, 175)
            btnQuickThucDon.Margin = New Padding(4)
            btnQuickThucDon.Name = "btnQuickThucDon"
            btnQuickThucDon.Size = New Size(169, 164)
            btnQuickThucDon.TabIndex = 4
            btnQuickThucDon.Tag = "CQ_QUAN_LY_THUC_DON"
            btnQuickThucDon.Text = "🍲" & vbCrLf & vbCrLf & "Cập Nhật Thực Đơn"
            btnQuickThucDon.UseVisualStyleBackColor = False
            ' 
            ' btnQuickBaoCao
            ' 
            btnQuickBaoCao.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            btnQuickBaoCao.Cursor = Cursors.Hand
            btnQuickBaoCao.Dock = DockStyle.Fill
            btnQuickBaoCao.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnQuickBaoCao.FlatStyle = FlatStyle.Flat
            btnQuickBaoCao.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnQuickBaoCao.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            btnQuickBaoCao.Location = New Point(358, 175)
            btnQuickBaoCao.Margin = New Padding(4)
            btnQuickBaoCao.Name = "btnQuickBaoCao"
            btnQuickBaoCao.Size = New Size(171, 164)
            btnQuickBaoCao.TabIndex = 5
            btnQuickBaoCao.Tag = "CQ_BAO_CAO_THONG_KE"
            btnQuickBaoCao.Text = "📈" & vbCrLf & vbCrLf & "Báo Cáo Thống Kê"
            btnQuickBaoCao.UseVisualStyleBackColor = False
            ' 
            ' lblQuickHeader
            ' 
            lblQuickHeader.AutoSize = False
            lblQuickHeader.Dock = DockStyle.Top
            lblQuickHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            lblQuickHeader.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblQuickHeader.Location = New Point(16, 16)
            lblQuickHeader.Name = "lblQuickHeader"
            lblQuickHeader.Padding = New Padding(0, 0, 0, 8)
            lblQuickHeader.Size = New Size(544, 32)
            lblQuickHeader.TextAlign = ContentAlignment.MiddleLeft
            lblQuickHeader.TabIndex = 0
            lblQuickHeader.Text = "⚡ Thao Tác Nghiệp Vụ Nhanh"
            ' 
            ' tlpKpiGrid
            ' 
            tlpKpiGrid.ColumnCount = 4
            tlpKpiGrid.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
            tlpKpiGrid.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
            tlpKpiGrid.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
            tlpKpiGrid.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
            tlpKpiGrid.Controls.Add(pnlKpiDoanhThu, 3, 0)
            tlpKpiGrid.Controls.Add(pnlKpiNhanSu, 2, 0)
            tlpKpiGrid.Controls.Add(pnlKpiMonCho, 1, 0)
            tlpKpiGrid.Controls.Add(pnlKpiBan, 0, 0)
            tlpKpiGrid.Dock = DockStyle.Top
            tlpKpiGrid.Location = New Point(0, 85)
            tlpKpiGrid.Name = "tlpKpiGrid"
            tlpKpiGrid.RowCount = 1
            tlpKpiGrid.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
            tlpKpiGrid.Size = New Size(974, 100)
            tlpKpiGrid.TabIndex = 1
            ' 
            ' pnlKpiDoanhThu
            ' 
            pnlKpiDoanhThu.BackColor = Color.White
            pnlKpiDoanhThu.Controls.Add(lblKpiDoanhThuValue)
            pnlKpiDoanhThu.Controls.Add(lblKpiDoanhThuTitle)
            pnlKpiDoanhThu.Dock = DockStyle.Fill
            pnlKpiDoanhThu.Location = New Point(733, 4)
            pnlKpiDoanhThu.Margin = New Padding(4)
            pnlKpiDoanhThu.Name = "pnlKpiDoanhThu"
            pnlKpiDoanhThu.Padding = New Padding(16)
            pnlKpiDoanhThu.Size = New Size(237, 92)
            pnlKpiDoanhThu.TabIndex = 3
            ' 
            ' lblKpiDoanhThuValue
            ' 
            lblKpiDoanhThuValue.AutoSize = True
            lblKpiDoanhThuValue.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
            lblKpiDoanhThuValue.ForeColor = Color.FromArgb(CByte(142), CByte(68), CByte(173))
            lblKpiDoanhThuValue.Location = New Point(12, 42)
            lblKpiDoanhThuValue.Name = "lblKpiDoanhThuValue"
            lblKpiDoanhThuValue.Size = New Size(116, 25)
            lblKpiDoanhThuValue.TabIndex = 1
            lblKpiDoanhThuValue.Text = "4.850.000 đ"
            ' 
            ' lblKpiDoanhThuTitle
            ' 
            lblKpiDoanhThuTitle.AutoSize = True
            lblKpiDoanhThuTitle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblKpiDoanhThuTitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            lblKpiDoanhThuTitle.Location = New Point(12, 16)
            lblKpiDoanhThuTitle.Name = "lblKpiDoanhThuTitle"
            lblKpiDoanhThuTitle.Size = New Size(153, 15)
            lblKpiDoanhThuTitle.TabIndex = 0
            lblKpiDoanhThuTitle.Text = "💰 DOANH THU HÔM NAY"
            ' 
            ' pnlKpiNhanSu
            ' 
            pnlKpiNhanSu.BackColor = Color.White
            pnlKpiNhanSu.Controls.Add(lblKpiNhanSuValue)
            pnlKpiNhanSu.Controls.Add(lblKpiNhanSuTitle)
            pnlKpiNhanSu.Dock = DockStyle.Fill
            pnlKpiNhanSu.Location = New Point(490, 4)
            pnlKpiNhanSu.Margin = New Padding(4)
            pnlKpiNhanSu.Name = "pnlKpiNhanSu"
            pnlKpiNhanSu.Padding = New Padding(16)
            pnlKpiNhanSu.Size = New Size(235, 92)
            pnlKpiNhanSu.TabIndex = 2
            ' 
            ' lblKpiNhanSuValue
            ' 
            lblKpiNhanSuValue.AutoSize = True
            lblKpiNhanSuValue.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
            lblKpiNhanSuValue.ForeColor = Color.FromArgb(CByte(39), CByte(174), CByte(96))
            lblKpiNhanSuValue.Location = New Point(12, 42)
            lblKpiNhanSuValue.Name = "lblKpiNhanSuValue"
            lblKpiNhanSuValue.Size = New Size(85, 25)
            lblKpiNhanSuValue.TabIndex = 1
            lblKpiNhanSuValue.Text = "6 Người"
            ' 
            ' lblKpiNhanSuTitle
            ' 
            lblKpiNhanSuTitle.AutoSize = True
            lblKpiNhanSuTitle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblKpiNhanSuTitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            lblKpiNhanSuTitle.Location = New Point(12, 16)
            lblKpiNhanSuTitle.Name = "lblKpiNhanSuTitle"
            lblKpiNhanSuTitle.Size = New Size(140, 15)
            lblKpiNhanSuTitle.TabIndex = 0
            lblKpiNhanSuTitle.Text = "👨‍🍳 NHÂN SỰ TRONG CA"
            ' 
            ' pnlKpiMonCho
            ' 
            pnlKpiMonCho.BackColor = Color.White
            pnlKpiMonCho.Controls.Add(lblKpiMonChoValue)
            pnlKpiMonCho.Controls.Add(lblKpiMonChoTitle)
            pnlKpiMonCho.Dock = DockStyle.Fill
            pnlKpiMonCho.Location = New Point(247, 4)
            pnlKpiMonCho.Margin = New Padding(4)
            pnlKpiMonCho.Name = "pnlKpiMonCho"
            pnlKpiMonCho.Padding = New Padding(16)
            pnlKpiMonCho.Size = New Size(235, 92)
            pnlKpiMonCho.TabIndex = 1
            ' 
            ' lblKpiMonChoValue
            ' 
            lblKpiMonChoValue.AutoSize = True
            lblKpiMonChoValue.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
            lblKpiMonChoValue.ForeColor = Color.FromArgb(CByte(230), CByte(126), CByte(34))
            lblKpiMonChoValue.Location = New Point(12, 42)
            lblKpiMonChoValue.Name = "lblKpiMonChoValue"
            lblKpiMonChoValue.Size = New Size(70, 25)
            lblKpiMonChoValue.TabIndex = 1
            lblKpiMonChoValue.Text = "5 Món"
            ' 
            ' lblKpiMonChoTitle
            ' 
            lblKpiMonChoTitle.AutoSize = True
            lblKpiMonChoTitle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblKpiMonChoTitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            lblKpiMonChoTitle.Location = New Point(12, 16)
            lblKpiMonChoTitle.Name = "lblKpiMonChoTitle"
            lblKpiMonChoTitle.Size = New Size(135, 15)
            lblKpiMonChoTitle.TabIndex = 0
            lblKpiMonChoTitle.Text = "🍜 MÓN CHỜ CHẾ BIẾN"
            ' 
            ' pnlKpiBan
            ' 
            pnlKpiBan.BackColor = Color.White
            pnlKpiBan.Controls.Add(lblKpiBanValue)
            pnlKpiBan.Controls.Add(lblKpiBanTitle)
            pnlKpiBan.Dock = DockStyle.Fill
            pnlKpiBan.Location = New Point(4, 4)
            pnlKpiBan.Margin = New Padding(4)
            pnlKpiBan.Name = "pnlKpiBan"
            pnlKpiBan.Padding = New Padding(16)
            pnlKpiBan.Size = New Size(235, 92)
            pnlKpiBan.TabIndex = 0
            ' 
            ' lblKpiBanValue
            ' 
            lblKpiBanValue.AutoSize = True
            lblKpiBanValue.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
            lblKpiBanValue.ForeColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            lblKpiBanValue.Location = New Point(12, 42)
            lblKpiBanValue.Name = "lblKpiBanValue"
            lblKpiBanValue.Size = New Size(63, 25)
            lblKpiBanValue.TabIndex = 1
            lblKpiBanValue.Text = "8 / 20"
            ' 
            ' lblKpiBanTitle
            ' 
            lblKpiBanTitle.AutoSize = True
            lblKpiBanTitle.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            lblKpiBanTitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            lblKpiBanTitle.Location = New Point(12, 16)
            lblKpiBanTitle.Name = "lblKpiBanTitle"
            lblKpiBanTitle.Size = New Size(141, 15)
            lblKpiBanTitle.TabIndex = 0
            lblKpiBanTitle.Text = ChrW(55358) & ChrW(56977) & " BÀN ĐANG PHỤC VỤ"
            ' 
            ' pnlWelcome
            ' 
            pnlWelcome.BackColor = Color.White
            pnlWelcome.Controls.Add(btnQuickOpenSoDoBan)
            pnlWelcome.Controls.Add(lblWelcomeSubtitle)
            pnlWelcome.Controls.Add(lblWelcomeGreeting)
            pnlWelcome.Dock = DockStyle.Top
            pnlWelcome.Location = New Point(0, 0)
            pnlWelcome.Name = "pnlWelcome"
            pnlWelcome.Padding = New Padding(18)
            pnlWelcome.Size = New Size(974, 85)
            pnlWelcome.TabIndex = 0
            ' 
            ' btnQuickOpenSoDoBan
            ' 
            btnQuickOpenSoDoBan.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            btnQuickOpenSoDoBan.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            btnQuickOpenSoDoBan.Cursor = Cursors.Hand
            btnQuickOpenSoDoBan.FlatAppearance.BorderSize = 0
            btnQuickOpenSoDoBan.FlatStyle = FlatStyle.Flat
            btnQuickOpenSoDoBan.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            btnQuickOpenSoDoBan.ForeColor = Color.White
            btnQuickOpenSoDoBan.Location = New Point(784, 22)
            btnQuickOpenSoDoBan.Name = "btnQuickOpenSoDoBan"
            btnQuickOpenSoDoBan.Size = New Size(175, 40)
            btnQuickOpenSoDoBan.TabIndex = 2
            btnQuickOpenSoDoBan.Tag = "POS_SO_DO_BAN"
            btnQuickOpenSoDoBan.Text = "⚡ Mở Sơ Đồ Bàn"
            btnQuickOpenSoDoBan.UseVisualStyleBackColor = False
            ' 
            ' lblWelcomeSubtitle
            ' 
            lblWelcomeSubtitle.AutoSize = True
            lblWelcomeSubtitle.Font = New Font("Segoe UI", 9.5F)
            lblWelcomeSubtitle.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            lblWelcomeSubtitle.Location = New Point(18, 47)
            lblWelcomeSubtitle.Name = "lblWelcomeSubtitle"
            lblWelcomeSubtitle.Size = New Size(458, 17)
            lblWelcomeSubtitle.TabIndex = 1
            lblWelcomeSubtitle.Text = "Hôm nay hệ thống hoạt động ổn định. Chúc bạn một ngày làm việc hiệu quả!"
            ' 
            ' lblWelcomeGreeting
            ' 
            lblWelcomeGreeting.AutoSize = True
            lblWelcomeGreeting.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
            lblWelcomeGreeting.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblWelcomeGreeting.Location = New Point(16, 16)
            lblWelcomeGreeting.Name = "lblWelcomeGreeting"
            lblWelcomeGreeting.Size = New Size(359, 28)
            lblWelcomeGreeting.TabIndex = 0
            lblWelcomeGreeting.Text = "Xin chào, Nguyễn Văn Chủ Quán! 👋"
            ' 
            ' tmrClock
            ' 
            tmrClock.Enabled = True
            tmrClock.Interval = 1000
            ' 
            ' frmMain
            ' 
            AutoScaleDimensions = New SizeF(7F, 17F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.FromArgb(CByte(244), CByte(246), CByte(249))
            ClientSize = New Size(1264, 733)
            Controls.Add(pnlContent)
            Controls.Add(appStatusStrip)
            Controls.Add(pnlSidebar)
            Controls.Add(pnlHeader)
            Font = New Font("Segoe UI", 9.5F)
            MinimumSize = New Size(1150, 700)
            Name = "frmMain"
            StartPosition = FormStartPosition.CenterScreen
            Text = "Hệ Thống Quản Lý Quán Ăn - [Màn Hình Chính]"
            WindowState = FormWindowState.Maximized
            pnlHeader.ResumeLayout(False)
            pnlBrand.ResumeLayout(False)
            pnlBrand.PerformLayout()
            pnlUserSection.ResumeLayout(False)
            pnlUserProfile.ResumeLayout(False)
            pnlUserProfile.PerformLayout()
            pnlSidebar.ResumeLayout(False)
            appStatusStrip.ResumeLayout(False)
            appStatusStrip.PerformLayout()
            pnlContent.ResumeLayout(False)
            pnlDashboardHome.ResumeLayout(False)
            pnlDashboardRow.ResumeLayout(False)
            pnlActivity.ResumeLayout(False)
            pnlActivity.PerformLayout()
            pnlQuickActions.ResumeLayout(False)
            pnlQuickActions.PerformLayout()
            tlpQuickButtons.ResumeLayout(False)
            tlpKpiGrid.ResumeLayout(False)
            pnlKpiDoanhThu.ResumeLayout(False)
            pnlKpiDoanhThu.PerformLayout()
            pnlKpiNhanSu.ResumeLayout(False)
            pnlKpiNhanSu.PerformLayout()
            pnlKpiMonCho.ResumeLayout(False)
            pnlKpiMonCho.PerformLayout()
            pnlKpiBan.ResumeLayout(False)
            pnlKpiBan.PerformLayout()
            pnlWelcome.ResumeLayout(False)
            pnlWelcome.PerformLayout()
            ResumeLayout(False)
            PerformLayout()

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
        Friend WithEvents pnlDashboardRow As System.Windows.Forms.TableLayoutPanel
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
