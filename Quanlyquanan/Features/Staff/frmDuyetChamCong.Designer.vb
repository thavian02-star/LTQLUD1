Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Staff

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmDuyetChamCong
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
        Friend WithEvents lblRoleBadge As Label
        Friend WithEvents btnDong As Button

        ' KPI Cards Panel
        Friend WithEvents pnlKpi As TableLayoutPanel
        Friend WithEvents pnlKpi1 As Panel
        Friend WithEvents lblKpiTongCaVal As Label
        Friend WithEvents lblKpiTongCaLbl As Label
        Friend WithEvents pnlKpi2 As Panel
        Friend WithEvents lblKpiChoDuyetVal As Label
        Friend WithEvents lblKpiChoDuyetLbl As Label
        Friend WithEvents pnlKpi3 As Panel
        Friend WithEvents lblKpiDaDuyetVal As Label
        Friend WithEvents lblKpiDaDuyetLbl As Label
        Friend WithEvents pnlKpi4 As Panel
        Friend WithEvents lblKpiLuongVal As Label
        Friend WithEvents lblKpiLuongLbl As Label

        ' Toolbar Controls
        Friend WithEvents pnlToolbar As Panel
        Friend WithEvents lblTuNgay As Label
        Friend WithEvents dtpTuNgay As DateTimePicker
        Friend WithEvents lblDenNgay As Label
        Friend WithEvents dtpDenNgay As DateTimePicker
        Friend WithEvents lblTrangThai As Label
        Friend WithEvents cboTrangThai As ComboBox
        Friend WithEvents btnLoc As Button
        Friend WithEvents btnDuyetHangLoat As Button
        Friend WithEvents btnLamMoi As Button

        ' Grid & Bottom Actions
        Friend WithEvents pnlGrid As Panel
        Friend WithEvents dgvChamCong As DataGridView
        Friend WithEvents pnlBottom As Panel
        Friend WithEvents btnDuyetChon As Button
        Friend WithEvents btnHuyDuyetChon As Button
        Friend WithEvents lblDongHuongDan As Label

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildKpiCards()
            BuildToolbar()
            BuildGrid()
            BuildBottomActions()

            Me.ClientSize = New System.Drawing.Size(1260, 740)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Quản Lý Duyệt Chấm Công & Bảng Lương Ca — Phúc Lộc Thọ"
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
                .Text = "📋", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "DUYỆT CHẤM CÔNG & BẢNG CÔNG NHÂN SỰ",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Kiểm tra giờ vào/ra thực tế, phê duyệt bảng chấm công ca và dự toán quỹ lương • Phúc Lộc Thọ",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            Me.lblRoleBadge = New Label() With {
                .Text = "👤 Quản Lý / Chủ Quán", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248), .BackColor = Color.FromArgb(15, 23, 42),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .Location = New Point(900, 16),
                .Size = New Size(230, 32), .TextAlign = ContentAlignment.MiddleCenter
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1145, 15), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.lblRoleBadge, Me.btnDong})
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

            BuildSingleKpi(Me.pnlKpi1, Me.lblKpiTongCaVal, Me.lblKpiTongCaLbl, "0 ca", "TỔNG CA LÀM VIỆC", Color.FromArgb(56, 189, 248))
            BuildSingleKpi(Me.pnlKpi2, Me.lblKpiChoDuyetVal, Me.lblKpiChoDuyetLbl, "0 ca", "CHỜ PHÊ DUYỆT", Color.FromArgb(245, 158, 11))
            BuildSingleKpi(Me.pnlKpi3, Me.lblKpiDaDuyetVal, Me.lblKpiDaDuyetLbl, "0 ca", "ĐÃ PHÊ DUYỆT", Color.FromArgb(34, 197, 94))
            BuildSingleKpi(Me.pnlKpi4, Me.lblKpiLuongVal, Me.lblKpiLuongLbl, "0 đ", "DỰ TOÁN TIỀN LƯƠNG", Color.FromArgb(168, 85, 247))

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
            Me.pnlToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 50, .BackColor = Color.FromArgb(30, 41, 59), .Padding = New Padding(14, 8, 14, 8)}
            Me.lblTuNgay = New Label() With {.Text = "Từ ngày:", .Location = New Point(14, 14), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.dtpTuNgay = New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Location = New Point(74, 11), .Width = 105, .Value = DateTime.Today.AddDays(-6)}
            Me.lblDenNgay = New Label() With {.Text = "Đến ngày:", .Location = New Point(188, 14), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.dtpDenNgay = New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Location = New Point(255, 11), .Width = 105, .Value = DateTime.Today}
            Me.lblTrangThai = New Label() With {.Text = "Trạng thái:", .Location = New Point(370, 14), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.cboTrangThai = New ComboBox() With {.DropDownStyle = ComboBoxStyle.DropDownList, .Location = New Point(440, 11), .Width = 160}
            Me.cboTrangThai.Items.AddRange({"Tất cả trạng thái", "⏳ Chờ quản lý duyệt", "✅ Đã phê duyệt"})
            Me.cboTrangThai.SelectedIndex = 0

            BuildToolbarButtons()
            Me.pnlToolbar.Controls.AddRange({Me.lblTuNgay, Me.dtpTuNgay, Me.lblDenNgay, Me.dtpDenNgay, Me.lblTrangThai, Me.cboTrangThai, Me.btnLoc, Me.btnDuyetHangLoat, Me.btnLamMoi})
            Me.Controls.Add(Me.pnlToolbar)
        End Sub

        Private Sub BuildToolbarButtons()
            Me.btnLoc = New Button() With {
                .Text = "🔍 Lọc", .Location = New Point(610, 9), .Size = New Size(70, 30),
                .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.btnDuyetHangLoat = New Button() With {
                .Text = "⚡ Duyệt Tất Cả Ca Chờ [F6]", .Location = New Point(690, 9), .Size = New Size(210, 30),
                .BackColor = Color.FromArgb(16, 185, 129), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.btnLamMoi = New Button() With {
                .Text = "🔄 Làm mới [F5]", .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1125, 9), .Size = New Size(115, 30), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
        End Sub

        Private Sub BuildGrid()
            Me.pnlGrid = New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(12), .BackColor = Color.FromArgb(15, 23, 42)}
            Me.dgvChamCong = New DataGridView() With {
                .Dock = DockStyle.Fill, .BackgroundColor = Color.FromArgb(15, 23, 42), .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvChamCong.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvChamCong.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvChamCong.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvChamCong.ColumnHeadersHeight = 34
            Me.dgvChamCong.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvChamCong.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvChamCong.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.dgvChamCong.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvChamCong.RowTemplate.Height = 32

            Me.pnlGrid.Controls.Add(Me.dgvChamCong)
            Me.Controls.Add(Me.pnlGrid)
            Me.pnlGrid.BringToFront()
        End Sub

        Private Sub BuildBottomActions()
            Me.pnlBottom = New Panel() With {.Dock = DockStyle.Bottom, .Height = 54, .BackColor = Color.FromArgb(30, 41, 59), .Padding = New Padding(14, 10, 14, 10)}
            Me.btnDuyetChon = New Button() With {
                .Text = "✅ Duyệt Ca Đang Chọn", .Location = New Point(14, 10), .Size = New Size(180, 34),
                .BackColor = Color.FromArgb(16, 185, 129), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.btnHuyDuyetChon = New Button() With {
                .Text = "↩️ Hoàn Tác Duyệt", .Location = New Point(202, 10), .Size = New Size(160, 34),
                .BackColor = Color.FromArgb(239, 68, 68), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.lblDongHuongDan = New Label() With {
                .Text = "💡 Phím tắt: [F5] Làm mới danh sách • [F6] Duyệt nhanh toàn bộ ca đang chờ • [Esc] Đóng màn hình",
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right, .Location = New Point(450, 16),
                .Size = New Size(790, 24), .TextAlign = ContentAlignment.MiddleRight,
                .ForeColor = Color.FromArgb(148, 163, 184), .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic)
            }
            Me.pnlBottom.Controls.AddRange({Me.btnDuyetChon, Me.btnHuyDuyetChon, Me.lblDongHuongDan})
            Me.Controls.Add(Me.pnlBottom)
            Me.pnlBottom.BringToFront()
        End Sub

    End Class

End Namespace
