Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.POS

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmSoDoBan
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
        Friend WithEvents lblTitle As Label
        Friend WithEvents lblSubtitle As Label
        Friend WithEvents btnDong As Button
        Friend WithEvents lblStatsSummary As Label

        ' Main Layout
        Friend WithEvents tlpMain As TableLayoutPanel

        ' Left Column: Area Filter & Stats
        Friend WithEvents pnlLeft As Panel
        Friend WithEvents lblAreaHeader As Label
        Friend WithEvents btnAreaAll As Button
        Friend WithEvents btnAreaTang1 As Button
        Friend WithEvents btnAreaTang2 As Button
        Friend WithEvents btnAreaVip As Button

        ' Center Column: Table Flow Layout
        Friend WithEvents pnlCenter As Panel
        Friend WithEvents lblTableGridTitle As Label
        Friend WithEvents flpTables As FlowLayoutPanel

        ' Right Column: Bill Details & POS Order
        Friend WithEvents pnlRight As Panel
        Friend WithEvents pnlBillHeader As Panel
        Friend WithEvents lblBillTableName As Label
        Friend WithEvents lblBillTableInfo As Label
        Friend WithEvents dgvOrderItems As DataGridView
        Friend WithEvents colTenMon As DataGridViewTextBoxColumn
        Friend WithEvents colSoLuong As DataGridViewTextBoxColumn
        Friend WithEvents colDonGia As DataGridViewTextBoxColumn
        Friend WithEvents colThanhTien As DataGridViewTextBoxColumn
        Friend WithEvents colTrangThaiBap As DataGridViewTextBoxColumn

        Friend WithEvents pnlBillSummary As Panel
        Friend WithEvents lblTongTienTitle As Label
        Friend WithEvents lblTongTienVal As Label
        Friend WithEvents tlpActionButtons As TableLayoutPanel
        Friend WithEvents btnMoBan As Button
        Friend WithEvents btnGoiMon As Button
        Friend WithEvents btnHuyMon As Button
        Friend WithEvents btnChuyenBan As Button
        Friend WithEvents btnThanhToan As Button

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()

            BuildHeader()
            BuildLeftSidebar()
            BuildCenterTableGrid()
            BuildRightBillPanel()
            BuildMainLayout()

            Me.ClientSize = New System.Drawing.Size(1200, 700)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Hệ Thống Bán Hàng & Sơ Đồ Bàn POS — Quán Ăn Phúc Lộc Thọ"
            Me.StartPosition = FormStartPosition.CenterParent
            Me.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular, GraphicsUnit.Point)
            Me.BackColor = Color.FromArgb(241, 245, 249)
        End Sub

        Private Sub BuildHeader()
            Me.pnlHeader = New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 60,
                .BackColor = Color.FromArgb(15, 23, 42),
                .Padding = New Padding(16, 8, 16, 8)
            }
            Me.lblTitle = New Label() With {
                .Text = "⚡ ĐIỂM BÁN HÀNG & SƠ ĐỒ BÀN (POS ORDER HUB)",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(251, 191, 36),
                .AutoSize = True,
                .Location = New Point(16, 10)
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Giám sát trạng thái bàn thời gian thực • Mở bàn • Gọi món • Chuyển bàn • Thanh toán",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .AutoSize = True,
                .Location = New Point(17, 34)
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]",
                .Size = New Size(95, 36),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1085, 12),
                .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat
            }
            Me.pnlHeader.Controls.AddRange({Me.lblTitle, Me.lblSubtitle, Me.btnDong})
        End Sub

        Private Sub BuildLeftSidebar()
            Me.pnlLeft = New Panel() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.White,
                .Padding = New Padding(10)
            }
            Me.lblAreaHeader = New Label() With {
                .Text = "KHU VỰC PHỤC VỤ",
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(100, 116, 139),
                .Dock = DockStyle.Top,
                .Height = 28
            }
            Me.btnAreaAll = TaoNutKhuVuc("Tất Cả Các Bàn", True)
            Me.btnAreaTang1 = TaoNutKhuVuc("Sảnh Tầng 1", False)
            Me.btnAreaTang2 = TaoNutKhuVuc("Sân Vườn Tầng 2", False)
            Me.btnAreaVip = TaoNutKhuVuc("Phòng VIP Máy Lạnh", False)

            Dim pnlBtnContainer As New Panel() With {.Dock = DockStyle.Fill, .AutoScroll = True}
            pnlBtnContainer.Controls.AddRange({Me.btnAreaVip, Me.btnAreaTang2, Me.btnAreaTang1, Me.btnAreaAll})
            Me.pnlLeft.Controls.Add(pnlBtnContainer)
            Me.pnlLeft.Controls.Add(Me.lblAreaHeader)
        End Sub

        Private Function TaoNutKhuVuc(ten As String, isActive As Boolean) As Button
            Dim btn As New Button() With {
                .Text = ten,
                .Dock = DockStyle.Top,
                .Height = 40,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, If(isActive, FontStyle.Bold, FontStyle.Regular)),
                .BackColor = If(isActive, Color.FromArgb(254, 243, 199), Color.White),
                .ForeColor = If(isActive, Color.FromArgb(180, 83, 9), Color.FromArgb(30, 41, 59)),
                .TextAlign = ContentAlignment.MiddleLeft,
                .Margin = New Padding(0, 0, 0, 4)
            }
            btn.FlatAppearance.BorderSize = If(isActive, 1, 0)
            btn.FlatAppearance.BorderColor = Color.FromArgb(245, 158, 11)
            Return btn
        End Function

        Private Sub BuildCenterTableGrid()
            Me.pnlCenter = New Panel() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.FromArgb(241, 245, 249),
                .Padding = New Padding(12)
            }
            Me.lblTableGridTitle = New Label() With {
                .Text = "SƠ ĐỒ BÀN PHỤC VỤ (Click vào bàn để thao tác)",
                .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(15, 23, 42),
                .Dock = DockStyle.Top,
                .Height = 30
            }
            Me.flpTables = New FlowLayoutPanel() With {
                .Dock = DockStyle.Fill,
                .AutoScroll = True,
                .BackColor = Color.Transparent
            }
            Me.pnlCenter.Controls.Add(Me.flpTables)
            Me.pnlCenter.Controls.Add(Me.lblTableGridTitle)
        End Sub

        Private Sub BuildRightBillPanel()
            Me.pnlRight = New Panel() With {
                .Dock = DockStyle.Fill,
                .BackColor = Color.White,
                .Padding = New Padding(10)
            }
            BuildBillHeader()
            BuildOrderGrid()
            BuildBillFooter()
            Me.pnlRight.Controls.AddRange({Me.dgvOrderItems, Me.pnlBillSummary, Me.pnlBillHeader})
        End Sub

        Private Sub BuildBillHeader()
            Me.pnlBillHeader = New Panel() With {
                .Dock = DockStyle.Top,
                .Height = 65,
                .BackColor = Color.FromArgb(15, 23, 42),
                .Padding = New Padding(12, 8, 12, 8)
            }
            Me.lblBillTableName = New Label() With {
                .Text = "Chưa chọn bàn",
                .Font = New Font("Segoe UI", 11.0F, FontStyle.Bold),
                .ForeColor = Color.White,
                .Dock = DockStyle.Top,
                .Height = 24
            }
            Me.lblBillTableInfo = New Label() With {
                .Text = "Vui lòng chọn 1 bàn bên trái để xem chi tiết",
                .Font = New Font("Segoe UI", 8.5F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Dock = DockStyle.Fill
            }
            Me.pnlBillHeader.Controls.AddRange({Me.lblBillTableInfo, Me.lblBillTableName})
        End Sub

        Private Sub BuildOrderGrid()
            Me.dgvOrderItems = New DataGridView() With {
                .Dock = DockStyle.Fill,
                .BackgroundColor = Color.White,
                .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False,
                .AllowUserToDeleteRows = False,
                .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            }
            Me.colTenMon = New DataGridViewTextBoxColumn() With {.HeaderText = "Món Ăn", .DataPropertyName = "TenMonAn", .FillWeight = 40}
            Me.colSoLuong = New DataGridViewTextBoxColumn() With {.HeaderText = "SL", .DataPropertyName = "CTHD_SoLuong", .FillWeight = 15}
            Me.colDonGia = New DataGridViewTextBoxColumn() With {.HeaderText = "Đơn Giá", .DataPropertyName = "CTHD_DonGia", .FillWeight = 22}
            Me.colThanhTien = New DataGridViewTextBoxColumn() With {.HeaderText = "T.Tiền", .DataPropertyName = "ThanhTien", .FillWeight = 23}
            Me.dgvOrderItems.Columns.AddRange({Me.colTenMon, Me.colSoLuong, Me.colDonGia, Me.colThanhTien})
        End Sub

        Private Sub BuildBillFooter()
            Me.pnlBillSummary = New Panel() With {
                .Dock = DockStyle.Bottom,
                .Height = 160,
                .BackColor = Color.FromArgb(248, 250, 252),
                .Padding = New Padding(8)
            }
            Me.lblTongTienTitle = New Label() With {
                .Text = "TỔNG THANH TOÁN:",
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(15, 23, 42),
                .Location = New Point(10, 10),
                .AutoSize = True
            }
            Me.lblTongTienVal = New Label() With {
                .Text = "0 đ",
                .Font = New Font("Segoe UI", 14.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(220, 38, 38),
                .Location = New Point(170, 8),
                .AutoSize = True
            }
            BuildButtonsTable()
            Me.pnlBillSummary.Controls.AddRange({Me.lblTongTienTitle, Me.lblTongTienVal, Me.tlpActionButtons})
        End Sub

        Private Sub BuildButtonsTable()
            Me.tlpActionButtons = New TableLayoutPanel() With {
                .Dock = DockStyle.Bottom,
                .Height = 110,
                .RowCount = 2,
                .ColumnCount = 3
            }
            Me.tlpActionButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            Me.tlpActionButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            Me.tlpActionButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.34F))
            Me.tlpActionButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))
            Me.tlpActionButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0F))

            Me.btnMoBan = New Button() With {.Text = "🟢 Mở Bàn", .Dock = DockStyle.Fill, .BackColor = Color.FromArgb(34, 197, 94), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
            Me.btnGoiMon = New Button() With {.Text = "➕ Gọi Món", .Dock = DockStyle.Fill, .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
            Me.btnHuyMon = New Button() With {.Text = "✖ Hủy Món", .Dock = DockStyle.Fill, .BackColor = Color.FromArgb(239, 68, 68), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
            Me.btnChuyenBan = New Button() With {.Text = "🔁 Chuyển", .Dock = DockStyle.Fill, .BackColor = Color.FromArgb(245, 158, 11), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)}
            Me.btnThanhToan = New Button() With {.Text = "💳 Thanh Toán [F4]", .Dock = DockStyle.Fill, .BackColor = Color.FromArgb(22, 101, 52), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)}
            
            Me.tlpActionButtons.Controls.Add(Me.btnMoBan, 0, 0)
            Me.tlpActionButtons.Controls.Add(Me.btnGoiMon, 1, 0)
            Me.tlpActionButtons.Controls.Add(Me.btnHuyMon, 2, 0)
            Me.tlpActionButtons.Controls.Add(Me.btnChuyenBan, 0, 1)
            Me.tlpActionButtons.SetColumnSpan(Me.btnThanhToan, 2)
            Me.tlpActionButtons.Controls.Add(Me.btnThanhToan, 1, 1)
        End Sub

        Private Sub BuildMainLayout()
            Me.tlpMain.Dock = DockStyle.Fill
            Me.tlpMain.ColumnCount = 3
            Me.tlpMain.RowCount = 1
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 180.0F))
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 60.0F))
            Me.tlpMain.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 40.0F))
            Me.tlpMain.Controls.Add(Me.pnlLeft, 0, 0)
            Me.tlpMain.Controls.Add(Me.pnlCenter, 1, 0)
            Me.tlpMain.Controls.Add(Me.pnlRight, 2, 0)
            Me.Controls.Add(Me.tlpMain)
            Me.Controls.Add(Me.pnlHeader)
        End Sub

    End Class

End Namespace
