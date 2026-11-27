Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Analytics

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmBaoCao
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
        Friend WithEvents btnXuatBaoCao As Button
        Friend WithEvents btnDong As Button

        ' KPI Cards Panel
        Friend WithEvents pnlKpi As TableLayoutPanel
        Friend WithEvents pnlKpi1 As Panel
        Friend WithEvents lblKpiDoanhThuVal As Label
        Friend WithEvents lblKpiDoanhThuLbl As Label
        Friend WithEvents pnlKpi2 As Panel
        Friend WithEvents lblKpiHoaDonVal As Label
        Friend WithEvents lblKpiHoaDonLbl As Label
        Friend WithEvents pnlKpi3 As Panel
        Friend WithEvents lblKpiKhachVal As Label
        Friend WithEvents lblKpiKhachLbl As Label
        Friend WithEvents pnlKpi4 As Panel
        Friend WithEvents lblKpiLuongVal As Label
        Friend WithEvents lblKpiLuongLbl As Label

        ' Toolbar Controls
        Friend WithEvents pnlToolbar As Panel
        Friend WithEvents btnHomNay As Button
        Friend WithEvents btn7Ngay As Button
        Friend WithEvents btnThangNay As Button
        Friend WithEvents btnNamNay As Button
        Friend WithEvents lblTuNgay As Label
        Friend WithEvents dtpTuNgay As DateTimePicker
        Friend WithEvents lblDenNgay As Label
        Friend WithEvents dtpDenNgay As DateTimePicker
        Friend WithEvents btnLoc As Button
        Friend WithEvents btnLamMoi As Button

        ' Main TabControl
        Friend WithEvents tabBaoCao As TabControl
        Friend WithEvents tpDoanhThu As TabPage
        Friend WithEvents dgvDoanhThu As DataGridView
        Friend WithEvents tpMonBanChay As TabPage
        Friend WithEvents dgvMonBanChay As DataGridView
        Friend WithEvents tpNhanVien As TabPage
        Friend WithEvents dgvNhanVien As DataGridView

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildKpiCards()
            BuildToolbar()
            BuildTabs()

            Me.ClientSize = New System.Drawing.Size(1260, 740)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Báo Cáo Doanh Thu, Năng Suất & Thống Kê — Phúc Lộc Thọ"
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
                .Text = "📈", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "BÁO CÁO DOANH THU & THỐNG KÊ HOẠT ĐỘNG",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(251, 191, 36),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Phân tích doanh thu, món bán chạy, số lượng khách và năng suất nhân viên • Phúc Lộc Thọ",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            Me.btnXuatBaoCao = New Button() With {
                .Text = "📥 Xuất Báo Cáo", .Size = New Size(130, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1005, 15), .BackColor = Color.FromArgb(37, 99, 235),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1145, 15), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.btnXuatBaoCao, Me.btnDong})
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

            BuildSingleKpi(Me.pnlKpi1, Me.lblKpiDoanhThuVal, Me.lblKpiDoanhThuLbl, "0 đ", "TỔNG DOANH THU", Color.FromArgb(34, 197, 94))
            BuildSingleKpi(Me.pnlKpi2, Me.lblKpiHoaDonVal, Me.lblKpiHoaDonLbl, "0 đơn", "HÓA ĐƠN ĐÃ THANH TOÁN", Color.FromArgb(56, 189, 248))
            BuildSingleKpi(Me.pnlKpi3, Me.lblKpiKhachVal, Me.lblKpiKhachLbl, "0 khách", "LƯỢNG KHÁCH PHỤC VỤ", Color.FromArgb(245, 158, 11))
            BuildSingleKpi(Me.pnlKpi4, Me.lblKpiLuongVal, Me.lblKpiLuongLbl, "0 đ", "QUỸ LƯƠNG NHÂN VIÊN CA", Color.FromArgb(168, 85, 247))

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
            BuildQuickButtons()

            Me.lblTuNgay = New Label() With {.Text = "Từ ngày:", .Location = New Point(365, 14), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.dtpTuNgay = New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Location = New Point(425, 11), .Width = 105, .Value = DateTime.Today.AddDays(-6)}
            Me.lblDenNgay = New Label() With {.Text = "Đến ngày:", .Location = New Point(540, 14), .AutoSize = True, .ForeColor = Color.FromArgb(148, 163, 184)}
            Me.dtpDenNgay = New DateTimePicker() With {.Format = DateTimePickerFormat.Short, .Location = New Point(605, 11), .Width = 105, .Value = DateTime.Today}

            Me.btnLoc = New Button() With {
                .Text = "🔍 Lọc Dữ Liệu", .Location = New Point(725, 9), .Size = New Size(120, 30),
                .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
            Me.btnLamMoi = New Button() With {
                .Text = "🔄 Làm mới [F5]", .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1125, 9), .Size = New Size(115, 30), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }

            Me.pnlToolbar.Controls.AddRange({Me.btnHomNay, Me.btn7Ngay, Me.btnThangNay, Me.btnNamNay, Me.lblTuNgay, Me.dtpTuNgay, Me.lblDenNgay, Me.dtpDenNgay, Me.btnLoc, Me.btnLamMoi})
            Me.Controls.Add(Me.pnlToolbar)
        End Sub

        Private Sub BuildQuickButtons()
            Me.btnHomNay = New Button() With {.Text = "Hôm nay", .Location = New Point(14, 9), .Size = New Size(80, 30), .BackColor = Color.FromArgb(51, 65, 85), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.btn7Ngay = New Button() With {.Text = "7 ngày qua", .Location = New Point(98, 9), .Size = New Size(85, 30), .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.btnThangNay = New Button() With {.Text = "Tháng này", .Location = New Point(187, 9), .Size = New Size(85, 30), .BackColor = Color.FromArgb(51, 65, 85), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
            Me.btnNamNay = New Button() With {.Text = "Năm nay", .Location = New Point(276, 9), .Size = New Size(80, 30), .BackColor = Color.FromArgb(51, 65, 85), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand}
        End Sub

        Private Sub BuildTabs()
            Me.tabBaoCao = New TabControl() With {
                .Dock = DockStyle.Fill, .Padding = New Point(16, 8),
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            }

            Me.tpDoanhThu = New TabPage("  📊 Doanh Thu Theo Mốc Thời Gian  ")
            Me.dgvDoanhThu = TaoGridMau()
            Me.tpDoanhThu.Controls.Add(Me.dgvDoanhThu)

            Me.tpMonBanChay = New TabPage("  🍲 Top Món Bán Chạy (Best Sellers)  ")
            Me.dgvMonBanChay = TaoGridMau()
            Me.tpMonBanChay.Controls.Add(Me.dgvMonBanChay)

            Me.tpNhanVien = New TabPage("  👥 Năng Suất & Quỹ Lương Nhân Viên  ")
            Me.dgvNhanVien = TaoGridMau()
            Me.tpNhanVien.Controls.Add(Me.dgvNhanVien)

            Me.tabBaoCao.TabPages.AddRange({Me.tpDoanhThu, Me.tpMonBanChay, Me.tpNhanVien})
            Me.Controls.Add(Me.tabBaoCao)
            Me.tabBaoCao.BringToFront()
        End Sub

        Private Function TaoGridMau() As DataGridView
            Dim g As New DataGridView() With {
                .Dock = DockStyle.Fill, .BackgroundColor = Color.FromArgb(15, 23, 42), .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            g.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            g.ColumnHeadersHeight = 34
            g.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            g.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            g.DefaultCellStyle.SelectionForeColor = Color.White
            g.RowTemplate.Height = 32
            Return g
        End Function

    End Class

End Namespace
