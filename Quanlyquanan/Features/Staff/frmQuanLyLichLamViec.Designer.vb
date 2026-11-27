Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Staff

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmQuanLyLichLamViec
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
        Friend WithEvents btnDong As Button

        ' KPI Cards Panel
        Friend WithEvents pnlKpi As TableLayoutPanel
        Friend WithEvents pnlKpi1 As Panel
        Friend WithEvents lblKpiTongCaVal As Label
        Friend WithEvents lblKpiTongCaLbl As Label
        Friend WithEvents pnlKpi2 As Panel
        Friend WithEvents lblKpiPhucVuVal As Label
        Friend WithEvents lblKpiPhucVuLbl As Label
        Friend WithEvents pnlKpi3 As Panel
        Friend WithEvents lblKpiNhaBepVal As Label
        Friend WithEvents lblKpiNhaBepLbl As Label
        Friend WithEvents pnlKpi4 As Panel
        Friend WithEvents lblKpiDoPhuVal As Label
        Friend WithEvents lblKpiDoPhuLbl As Label

        ' Week Navigation & Action Toolbar
        Friend WithEvents pnlToolbar As Panel
        Friend WithEvents btnTuanTruoc As Button
        Friend WithEvents btnTuanNay As Button
        Friend WithEvents btnTuanSau As Button
        Friend WithEvents lblWeekInfo As Label
        Friend WithEvents btnLamMoi As Button

        ' Quick Assign Panel
        Friend WithEvents pnlAssign As Panel
        Friend WithEvents lblAssignTitle As Label
        Friend WithEvents lblNhanVien As Label
        Friend WithEvents cboNhanVien As ComboBox
        Friend WithEvents lblNgayLam As Label
        Friend WithEvents dtpNgayLam As DateTimePicker
        Friend WithEvents lblCa As Label
        Friend WithEvents cboCa As ComboBox
        Friend WithEvents btnPhanCa As Button
        Friend WithEvents btnHuyCa As Button

        ' Grid
        Friend WithEvents pnlGrid As Panel
        Friend WithEvents dgvLichTuan As DataGridView

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildKpiCards()
            BuildToolbar()
            BuildAssignPanel()
            BuildGrid()

            Me.ClientSize = New System.Drawing.Size(1280, 740)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Quản Lý Phân Ca & Lịch Làm Việc Tuần — Phúc Lộc Thọ"
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
                .Text = "📅", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "QUẢN LÝ PHÂN CA & LỊCH LÀM VIỆC TUẦN",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Điều phối quân số 7 ngày trong tuần, phân bổ ca trực cho nhân viên phục vụ & đầu bếp • Phúc Lộc Thọ",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1165, 15), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.btnDong})
            Me.Controls.Add(Me.pnlHeader)
        End Sub

        Private Sub BuildKpiCards()
            Me.pnlKpi = New TableLayoutPanel() With {
                .Dock = DockStyle.Top, .Height = 84, .ColumnCount = 4, .RowCount = 1,
                .Padding = New Padding(12, 8, 12, 8), .BackColor = Color.FromArgb(15, 23, 42)
            }
            For i As Integer = 0 To 3
                Me.pnlKpi.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25.0F))
            Next

            BuildSingleKpi(Me.pnlKpi1, Me.lblKpiTongCaVal, Me.lblKpiTongCaLbl, "0 ca", "TỔNG CA ĐÃ PHÂN CÔNG", Color.FromArgb(56, 189, 248))
            BuildSingleKpi(Me.pnlKpi2, Me.lblKpiPhucVuVal, Me.lblKpiPhucVuLbl, "0 ca", "NHÂN SỰ PHỤC VỤ BÀN", Color.FromArgb(34, 197, 94))
            BuildSingleKpi(Me.pnlKpi3, Me.lblKpiNhaBepVal, Me.lblKpiNhaBepLbl, "0 ca", "NHÂN SỰ NHÀ BẾP / PHA CHẾ", Color.FromArgb(245, 158, 11))
            BuildSingleKpi(Me.pnlKpi4, Me.lblKpiDoPhuVal, Me.lblKpiDoPhuLbl, "100%", "ĐỘ PHỦ QUÂN SỐ CHUẨN", Color.FromArgb(168, 85, 247))

            Me.pnlKpi.Controls.Add(Me.pnlKpi1, 0, 0)
            Me.pnlKpi.Controls.Add(Me.pnlKpi2, 1, 0)
            Me.pnlKpi.Controls.Add(Me.pnlKpi3, 2, 0)
            Me.pnlKpi.Controls.Add(Me.pnlKpi4, 3, 0)
            Me.Controls.Add(Me.pnlKpi)
        End Sub

        Private Sub BuildSingleKpi(ByRef pnl As Panel, ByRef val As Label, ByRef lbl As Label, textVal As String, textLbl As String, c As Color)
            pnl = New Panel() With {.Dock = DockStyle.Fill, .BackColor = Color.FromArgb(30, 41, 59), .Margin = New Padding(4), .Padding = New Padding(12, 6, 12, 6)}
            val = New Label() With {.Text = textVal, .Font = New Font("Segoe UI", 15.0F, FontStyle.Bold), .ForeColor = c, .Dock = DockStyle.Top, .Height = 32}
            lbl = New Label() With {.Text = textLbl, .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold), .ForeColor = Color.FromArgb(148, 163, 184), .Dock = DockStyle.Bottom, .Height = 22}
            pnl.Controls.AddRange({val, lbl})
        End Sub

        Private Sub BuildToolbar()
            Me.pnlToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 46, .BackColor = Color.FromArgb(30, 41, 59), .Padding = New Padding(14, 8, 14, 8)}
            Me.btnTuanTruoc = New Button() With {.Text = "◀ Tuần trước", .Location = New Point(14, 8), .Size = New Size(110, 30), .BackColor = Color.FromArgb(51, 65, 85), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.btnTuanNay = New Button() With {.Text = "Tuần hiện tại", .Location = New Point(128, 8), .Size = New Size(100, 30), .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.btnTuanSau = New Button() With {.Text = "Tuần sau ▶", .Location = New Point(232, 8), .Size = New Size(110, 30), .BackColor = Color.FromArgb(51, 65, 85), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.lblWeekInfo = New Label() With {.Text = "Tuần từ 24/11/2026 đến 30/11/2026", .Location = New Point(360, 12), .AutoSize = True, .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold), .ForeColor = Color.FromArgb(251, 191, 36)}

            Me.btnLamMoi = New Button() With {
                .Text = "🔄 Làm mới [F5]", .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1145, 8), .Size = New Size(115, 30), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.pnlToolbar.Controls.AddRange({Me.btnTuanTruoc, Me.btnTuanNay, Me.btnTuanSau, Me.lblWeekInfo, Me.btnLamMoi})
            Me.Controls.Add(Me.pnlToolbar)
        End Sub

        Private Sub BuildAssignPanel()
            Me.pnlAssign = New Panel() With {.Dock = DockStyle.Top, .Height = 52, .BackColor = Color.FromArgb(15, 23, 42), .Padding = New Padding(14, 10, 14, 10)}
            Me.lblAssignTitle = New Label() With {.Text = "➕ Phân Công:", .Location = New Point(14, 15), .AutoSize = True, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .ForeColor = Color.FromArgb(56, 189, 248)}
            Me.lblNhanVien = New Label() With {.Text = "Nhân viên:", .Location = New Point(125, 15), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.cboNhanVien = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(190, 12), .Width = 200}
            Me.lblNgayLam = New Label() With {.Text = "Ngày làm:", .Location = Point.Add(New Point(405, 15), New Size(0, 0)), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.dtpNgayLam = New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Location = New Point(470, 12), .Width = 105, .Value = DateTime.Today}
            Me.lblCa = New Label() With {.Text = "Ca trực:", .Location = New Point(590, 15), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.cboCa = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(640, 12), .Width = 180}

            BuildAssignButtons()
            Me.pnlAssign.Controls.AddRange({Me.lblAssignTitle, Me.lblNhanVien, Me.cboNhanVien, Me.lblNgayLam, Me.dtpNgayLam, Me.lblCa, Me.cboCa, Me.btnPhanCa, Me.btnHuyCa})
            Me.Controls.Add(Me.pnlAssign)
        End Sub

        Private Sub BuildAssignButtons()
            Me.btnPhanCa = New Button() With {
                .Text = "✔ Phân Công Ca", .Location = New Point(835, 10), .Size = New Size(140, 32),
                .BackColor = Color.FromArgb(16, 185, 129), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.btnHuyCa = New Button() With {
                .Text = "✖ Hủy Ca Ngày Này", .Location = New Point(985, 10), .Size = New Size(150, 32),
                .BackColor = Color.FromArgb(239, 68, 68), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
        End Sub

        Private Sub BuildGrid()
            Me.pnlGrid = New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(12), .BackColor = Color.FromArgb(15, 23, 42)}
            Me.dgvLichTuan = New DataGridView() With {
                .Dock = DockStyle.Fill, .BackgroundColor = Color.FromArgb(15, 23, 42), .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvLichTuan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvLichTuan.ColumnHeadersHeight = 36
            Me.dgvLichTuan.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvLichTuan.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvLichTuan.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.dgvLichTuan.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvLichTuan.RowTemplate.Height = 36

            Me.pnlGrid.Controls.Add(Me.dgvLichTuan)
            Me.Controls.Add(Me.pnlGrid)
            Me.pnlGrid.BringToFront()
        End Sub

    End Class

End Namespace
