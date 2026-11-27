Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Staff

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmChamCongCaNhan
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

        ' Header Controls
        Friend WithEvents pnlHeader As Panel
        Friend WithEvents lblIcon As Label
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents lblClock As Label
        Friend WithEvents btnDong As Button

        ' Split & Layout Containers
        Friend WithEvents pnlMain As TableLayoutPanel
        Friend WithEvents pnlLeft As Panel
        Friend WithEvents pnlRight As Panel

        ' Left Check-in Card Controls
        Friend WithEvents grpCheckIn As GroupBox
        Friend WithEvents lblTrangThaiBadge As Label
        Friend WithEvents lblNhanVienInfo As Label
        Friend WithEvents lblCaHienTaiInfo As Label
        Friend WithEvents lblGioVaoLabel As Label
        Friend WithEvents lblGioVaoVal As Label
        Friend WithEvents lblThoiLuongLabel As Label
        Friend WithEvents lblThoiLuongVal As Label
        Friend WithEvents btnVaoCa As Button
        Friend WithEvents btnRaCa As Button
        Friend WithEvents lblHuongDan As Label

        ' Right Schedule & History Controls
        Friend WithEvents grpLichTuan As GroupBox
        Friend WithEvents pnlTuanNav As Panel
        Friend WithEvents btnTuanTruoc As Button
        Friend WithEvents btnTuanHienTai As Button
        Friend WithEvents btnTuanSau As Button
        Friend WithEvents lblTuanHienTai As Label
        Friend WithEvents dgvLichTuan As DataGridView

        Friend WithEvents grpLichSu As GroupBox
        Friend WithEvents pnlLichSuToolbar As Panel
        Friend WithEvents btnLamMoi As Button
        Friend WithEvents lblLichSuSummary As Label
        Friend WithEvents dgvLichSu As DataGridView

        Friend WithEvents tmrClock As Timer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildLayout()
            BuildLeftCard()
            BuildScheduleSection()
            BuildHistorySection()
            BuildTimers()

            Me.ClientSize = New System.Drawing.Size(1200, 720)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Chấm Công & Lịch Trực Cá Nhân — Phúc Lộc Thọ"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
            Me.BackColor = Color.FromArgb(15, 23, 42)
            Me.ForeColor = Color.White
            Me.KeyPreview = True
        End Sub

        Private Sub BuildHeader()
            Me.pnlHeader = New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 64,
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(16, 8, 16, 8)
            }
            Me.lblIcon = New Label() With {
                .Text = "⏱️", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "CHẤM CÔNG & LỊCH TRỰC CÁ NHÂN",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Điểm danh vào/ra ca làm việc 1-Click • Theo dõi phân ca tuần & lịch sử công đã duyệt",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            Me.lblClock = New Label() With {
                .Text = "🕒 --:--:--", .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(248, 250, 252), .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(850, 20), .Size = New Size(220, 26), .TextAlign = ContentAlignment.MiddleRight
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1085, 14), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.lblClock, Me.btnDong})
            Me.Controls.Add(Me.pnlHeader)
        End Sub

        Private Sub BuildLayout()
            Me.pnlMain = New TableLayoutPanel() With {
                .Dock = DockStyle.Fill,
                .ColumnCount = 2,
                .RowCount = 1,
                .Padding = New Padding(12),
                .BackColor = Color.FromArgb(15, 23, 42)
            }
            Me.pnlMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 380.0F))
            Me.pnlMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))

            Me.pnlLeft = New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(4)}
            Me.pnlRight = New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(4)}

            Me.pnlMain.Controls.Add(Me.pnlLeft, 0, 0)
            Me.pnlMain.Controls.Add(Me.pnlRight, 1, 0)
            Me.Controls.Add(Me.pnlMain)
            Me.pnlMain.BringToFront()
        End Sub

        Private Sub BuildLeftCard()
            Me.grpCheckIn = New GroupBox() With {
                .Text = "  ĐIỂM DANH CA HIỆN TẠI  ",
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(16)
            }
            Me.lblTrangThaiBadge = New Label() With {
                .Text = "CHƯA VÀO CA",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(203, 213, 225),
                .BackColor = Color.FromArgb(51, 65, 85),
                .TextAlign = ContentAlignment.MiddleCenter,
                .Location = New Point(20, 36), .Size = New Size(330, 38)
            }
            Me.lblNhanVienInfo = New Label() With {
                .Text = "👤 Nhân viên: Nguyễn Văn A (Phục vụ)",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .Location = New Point(20, 88), .Size = New Size(330, 24)
            }
            Me.lblCaHienTaiInfo = New Label() With {
                .Text = "📅 Ca hôm nay: Ca Sáng (06:00 - 14:00)",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Regular),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(20, 116), .Size = New Size(330, 24)
            }
            BuildCheckInStats()
            BuildCheckInButtons()
            Me.grpCheckIn.Controls.AddRange({Me.lblTrangThaiBadge, Me.lblNhanVienInfo, Me.lblCaHienTaiInfo, Me.lblGioVaoLabel, Me.lblGioVaoVal, Me.lblThoiLuongLabel, Me.lblThoiLuongVal, Me.btnVaoCa, Me.btnRaCa, Me.lblHuongDan})
            Me.pnlLeft.Controls.Add(Me.grpCheckIn)
        End Sub

        Private Sub BuildCheckInStats()
            Me.lblGioVaoLabel = New Label() With {
                .Text = "Thời điểm vào ca:", .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(20, 150), .Size = New Size(150, 20)
            }
            Me.lblGioVaoVal = New Label() With {
                .Text = "--:--", .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248),
                .Location = New Point(20, 172), .Size = New Size(150, 28)
            }
            Me.lblThoiLuongLabel = New Label() With {
                .Text = "Số giờ đã trực:", .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(180, 150), .Size = New Size(170, 20)
            }
            Me.lblThoiLuongVal = New Label() With {
                .Text = "0.0 giờ", .Font = New Font("Segoe UI", 13.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(34, 197, 94),
                .Location = New Point(180, 172), .Size = New Size(170, 28)
            }
        End Sub

        Private Sub BuildCheckInButtons()
            Me.btnVaoCa = New Button() With {
                .Text = "▶  VÀO CA LÀM VIỆC",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .BackColor = Color.FromArgb(16, 185, 129),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Location = New Point(20, 220), .Size = New Size(330, 52),
                .Cursor = Cursors.Hand
            }
            Me.btnRaCa = New Button() With {
                .Text = "⏹  KẾT THÚC CA (CHECK-OUT)",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .BackColor = Color.FromArgb(239, 68, 68),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Location = New Point(20, 284), .Size = New Size(330, 52),
                .Cursor = Cursors.Hand, .Enabled = False
            }
            Me.lblHuongDan = New Label() With {
                .Text = "💡 Lưu ý: Hãy bấm 'Vào ca' ngay khi bắt đầu làm việc tại nhà hàng và 'Kết thúc ca' trước khi ra về để hệ thống tự động ghi nhận bảng lương.",
                .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(20, 355), .Size = New Size(330, 90)
            }
        End Sub

        Private Sub BuildScheduleSection()
            Me.grpLichTuan = New GroupBox() With {
                .Text = "  LỊCH PHÂN CA 7 NGÀY TRONG TUẦN  ",
                .Dock = DockStyle.Top,
                .Height = 270,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(12)
            }
            BuildScheduleNav()
            BuildScheduleGrid()
            Me.grpLichTuan.Controls.Add(Me.dgvLichTuan)
            Me.grpLichTuan.Controls.Add(Me.pnlTuanNav)
            Me.pnlRight.Controls.Add(Me.grpLichTuan)
        End Sub

        Private Sub BuildScheduleNav()
            Me.pnlTuanNav = New Panel() With {.Dock = DockStyle.Top, .Height = 40}
            Me.btnTuanTruoc = New Button() With {
                .Text = "◀ Tuần trước", .Size = New Size(110, 30),
                .Location = New Point(0, 4), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F),
                .Cursor = Cursors.Hand
            }
            Me.btnTuanHienTai = New Button() With {
                .Text = "Tuần này", .Size = New Size(85, 30),
                .Location = New Point(116, 4), .BackColor = Color.FromArgb(37, 99, 235),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F),
                .Cursor = Cursors.Hand
            }
            Me.btnTuanSau = New Button() With {
                .Text = "Tuần sau ▶", .Size = New Size(110, 30),
                .Location = New Point(207, 4), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F),
                .Cursor = Cursors.Hand
            }
            Me.lblTuanHienTai = New Label() With {
                .Text = "Tuần từ 24/11/2026 đến 30/11/2026",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(251, 191, 36),
                .Location = New Point(330, 8), .Size = New Size(380, 24), .TextAlign = ContentAlignment.MiddleRight,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
            Me.pnlTuanNav.Controls.AddRange({Me.btnTuanTruoc, Me.btnTuanHienTai, Me.btnTuanSau, Me.lblTuanHienTai})
        End Sub

        Private Sub BuildScheduleGrid()
            Me.dgvLichTuan = New DataGridView() With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.FromArgb(15, 23, 42),
                .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvLichTuan.ColumnHeadersHeight = 32
            Me.dgvLichTuan.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvLichTuan.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvLichTuan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.dgvLichTuan.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvLichTuan.RowTemplate.Height = 30
        End Sub

        Private Sub BuildHistorySection()
            Me.grpLichSu = New GroupBox() With {
                .Text = "  LỊCH SỬ CHẤM CÔNG GẦN ĐÂY  ",
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(226, 232, 240),
                .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(12)
            }
            BuildHistoryToolbar()
            BuildHistoryGrid()
            Me.grpLichSu.Controls.Add(Me.dgvLichSu)
            Me.grpLichSu.Controls.Add(Me.pnlLichSuToolbar)
            Me.pnlRight.Controls.Add(Me.grpLichSu)
            Me.grpLichSu.BringToFront()
        End Sub

        Private Sub BuildHistoryToolbar()
            Me.pnlLichSuToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 38}
            Me.btnLamMoi = New Button() With {
                .Text = "🔄 Làm mới dữ liệu", .Size = New Size(140, 30),
                .Location = New Point(0, 4), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F),
                .Cursor = Cursors.Hand
            }
            Me.lblLichSuSummary = New Label() With {
                .Text = "Hiển thị 10 ca làm việc gần nhất",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(150, 8), .Size = New Size(300, 24), .TextAlign = ContentAlignment.MiddleLeft
            }
            Me.pnlLichSuToolbar.Controls.AddRange({Me.btnLamMoi, Me.lblLichSuSummary})
        End Sub

        Private Sub BuildHistoryGrid()
            Me.dgvLichSu = New DataGridView() With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.FromArgb(15, 23, 42),
                .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvLichSu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvLichSu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvLichSu.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvLichSu.ColumnHeadersHeight = 32
            Me.dgvLichSu.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvLichSu.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvLichSu.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.dgvLichSu.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvLichSu.RowTemplate.Height = 30
        End Sub

        Private Sub BuildTimers()
            Me.tmrClock = New Timer(Me.components) With {.Interval = 1000, .Enabled = True}
        End Sub

    End Class

End Namespace
