Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Kitchen

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmNhaBep
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
        Friend WithEvents lblKpiPending As Label
        Friend WithEvents lblKpiUrgent As Label
        Friend WithEvents lblClock As Label
        Friend WithEvents btnDong As Button

        ' Toolbar Filters
        Friend WithEvents pnlToolbar As Panel
        Friend WithEvents btnFilterAll As Button
        Friend WithEvents btnFilterHot As Button
        Friend WithEvents btnFilterCold As Button
        Friend WithEvents btnFilterBar As Button
        Friend WithEvents btnRefresh As Button
        Friend WithEvents lblAutoRefreshHint As Label

        ' Main KDS Cards Board
        Friend WithEvents flpTickets As FlowLayoutPanel
        Friend WithEvents tmrAutoRefresh As Timer
        Friend WithEvents tmrClock As Timer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildToolbar()
            BuildCardsBoard()
            BuildTimers()

            Me.ClientSize = New System.Drawing.Size(1200, 720)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Hệ Thống Điều Phối Chế Biến Nhà Bếp KDS — Phúc Lộc Thọ"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
            Me.BackColor = Color.FromArgb(9, 13, 22)
            Me.ForeColor = Color.White
        End Sub

        Private Sub BuildHeader()
            Me.pnlHeader = New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 64,
                .BackColor = Color.FromArgb(15, 23, 42),
                .Padding = New Padding(16, 8, 16, 8)
            }
            Me.lblIcon = New Label() With {
                .Text = "👨‍🍳", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "HÀNG ĐỢI CHẾ BIẾN NHÀ BẾP (KDS FIFO)",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(251, 191, 36),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Màn hình điều phối chế biến theo thứ tự gọi món • Báo xong món theo thời gian thực",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            BuildHeaderKpis()
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1085, 14), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat
            }
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.lblKpiPending, Me.lblKpiUrgent, Me.lblClock, Me.btnDong})
            Me.Controls.Add(Me.pnlHeader)
        End Sub

        Private Sub BuildHeaderKpis()
            Me.lblKpiPending = New Label() With {
                .Text = "🍳 Chờ nấu: 0", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(251, 191, 36), .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(8, 4, 8, 4), .Location = New Point(620, 16), .AutoSize = True
            }
            Me.lblKpiUrgent = New Label() With {
                .Text = "⚠️ Quá 15p: 0", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(248, 113, 113), .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(8, 4, 8, 4), .Location = New Point(750, 16), .AutoSize = True
            }
            Me.lblClock = New Label() With {
                .Text = "12:00:00", .Font = New Font("Consolas", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(56, 189, 248), .Location = New Point(890, 18), .AutoSize = True
            }
        End Sub

        Private Sub BuildToolbar()
            Me.pnlToolbar = New Panel() With {
                .Dock = DockStyle.Top, .Height = 48,
                .BackColor = Color.FromArgb(19, 27, 46), .Padding = New Padding(16, 6, 16, 6)
            }
            Me.btnFilterAll = TaoNutFilter("Tất Cả Món", True)
            Me.btnFilterHot = TaoNutFilter("🔥 Bếp Nóng", False)
            Me.btnFilterCold = TaoNutFilter("🥗 Bếp Lạnh", False)
            Me.btnFilterBar = TaoNutFilter("🍹 Quầy Nước", False)
            Me.btnRefresh = New Button() With {
                .Text = "🔄 Làm Mới", .Size = New Size(95, 32),
                .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold),
                .Location = New Point(440, 8)
            }
            Me.lblAutoRefreshHint = New Label() With {
                .Text = "Tự động cập nhật mỗi 5 giây", .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic),
                .ForeColor = Color.FromArgb(148, 163, 184), .Location = New Point(550, 14), .AutoSize = True
            }
            Me.pnlToolbar.Controls.AddRange({Me.btnFilterAll, Me.btnFilterHot, Me.btnFilterCold, Me.btnFilterBar, Me.btnRefresh, Me.lblAutoRefreshHint})
            Me.Controls.Add(Me.pnlToolbar)
        End Sub

        Private Function TaoNutFilter(text As String, isActive As Boolean) As Button
            Dim offset = If(text.Contains("Tất Cả"), 16, If(text.Contains("Nóng"), 120, If(text.Contains("Lạnh"), 225, 330)))
            Dim btn As New Button() With {
                .Text = text, .Size = New Size(100, 32),
                .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, If(isActive, FontStyle.Bold, FontStyle.Regular)),
                .BackColor = If(isActive, Color.FromArgb(234, 88, 12), Color.Transparent),
                .ForeColor = If(isActive, Color.White, Color.FromArgb(203, 213, 225)),
                .Location = New Point(offset, 8)
            }
            btn.FlatAppearance.BorderColor = Color.FromArgb(51, 65, 85)
            Return btn
        End Function

        Private Sub BuildCardsBoard()
            Me.flpTickets = New FlowLayoutPanel() With {
                .Dock = DockStyle.Fill, .AutoScroll = True,
                .BackColor = Color.FromArgb(9, 13, 22), .Padding = New Padding(16)
            }
            Me.Controls.Add(Me.flpTickets)
            Me.flpTickets.BringToFront()
        End Sub

        Private Sub BuildTimers()
            Me.tmrAutoRefresh = New Timer(Me.components) With {.Interval = 5000, .Enabled = True}
            Me.tmrClock = New Timer(Me.components) With {.Interval = 1000, .Enabled = True}
        End Sub

    End Class

End Namespace
