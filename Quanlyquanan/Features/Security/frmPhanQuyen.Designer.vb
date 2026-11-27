Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Security

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmPhanQuyen
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
        Friend WithEvents btnLuuPhanQuyen As Button
        Friend WithEvents btnDong As Button

        ' Split Layout
        Friend WithEvents splitMain As SplitContainer

        ' Left Roles Panel
        Friend WithEvents pnlLeftTop As Panel
        Friend WithEvents lblRoleListTitle As Label
        Friend WithEvents dgvVaiTro As DataGridView
        Friend WithEvents grpThemVaiTro As GroupBox
        Friend WithEvents lblTenVT As Label
        Friend WithEvents txtTenVT As TextBox
        Friend WithEvents lblMoTaVT As Label
        Friend WithEvents txtMoTaVT As TextBox
        Friend WithEvents btnThemVaiTro As Button

        ' Right Permissions Panel
        Friend WithEvents pnlRightToolbar As Panel
        Friend WithEvents lblCurrentRole As Label
        Friend WithEvents btnChonTatCa As Button
        Friend WithEvents btnBoChonTatCa As Button
        Friend WithEvents dgvQuyen As DataGridView

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            BuildHeader()
            BuildLayout()
            BuildLeftPanel()
            BuildRightPanel()

            Me.ClientSize = New System.Drawing.Size(1260, 740)
            Me.MinimumSize = New System.Drawing.Size(1024, 600)
            Me.Text = "Quản Lý Vai Trò & Phân Quyền Người Dùng — Phúc Lộc Thọ"
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
                .Text = "🛡️", .Font = New Font("Segoe UI", 20.0F),
                .Location = New Point(12, 10), .AutoSize = True
            }
            Me.lblTitle = New Label() With {
                .Text = "QUẢN LÝ VAI TRÒ & PHÂN QUYỀN NGƯỜI DÙNG ĐỘNG",
                .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(168, 85, 247),
                .Location = New Point(60, 10), .AutoSize = True
            }
            Me.lblSubtitle = New Label() With {
                .Text = "Thiết lập danh mục vai trò chức danh và phân bổ quyền truy cập chức năng hệ thống • Phúc Lộc Thọ",
                .Font = New Font("Segoe UI", 9.0F),
                .ForeColor = Color.FromArgb(148, 163, 184),
                .Location = New Point(62, 34), .AutoSize = True
            }
            BuildHeaderButtons()
            Me.pnlHeader.Controls.AddRange({Me.lblIcon, Me.lblTitle, Me.lblSubtitle, Me.btnLuuPhanQuyen, Me.btnDong})
            Me.Controls.Add(Me.pnlHeader)
        End Sub

        Private Sub BuildHeaderButtons()
            Me.btnLuuPhanQuyen = New Button() With {
                .Text = "💾 Lưu Phân Quyền [F2]", .Size = New Size(175, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(960, 15), .BackColor = Color.FromArgb(16, 185, 129),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.btnDong = New Button() With {
                .Text = "Đóng [Esc]", .Size = New Size(95, 34),
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(1145, 15), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Cursor = Cursors.Hand
            }
        End Sub

        Private Sub BuildLayout()
            Me.splitMain = New SplitContainer() With {
                .Dock = DockStyle.Fill, .SplitterDistance = 380, .FixedPanel = FixedPanel.Panel1,
                .BackColor = Color.FromArgb(51, 65, 85), .Padding = New Padding(4)
            }
            Me.Controls.Add(Me.splitMain)
            Me.splitMain.BringToFront()
        End Sub

        Private Sub BuildLeftPanel()
            Me.pnlLeftTop = New Panel() With {.Dock = DockStyle.Top, .Height = 36, .BackColor = Color.FromArgb(30, 41, 59)}
            Me.lblRoleListTitle = New Label() With {
                .Text = "DANH SÁCH VAI TRÒ CHỨC DANH", .Font = New Font("Segoe UI", 9.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(226, 232, 240), .Location = New Point(12, 8), .AutoSize = True
            }
            Me.pnlLeftTop.Controls.Add(Me.lblRoleListTitle)

            BuildRolesGrid()
            BuildAddRoleBox()

            Me.splitMain.Panel1.Controls.Add(Me.dgvVaiTro)
            Me.splitMain.Panel1.Controls.Add(Me.grpThemVaiTro)
            Me.splitMain.Panel1.Controls.Add(Me.pnlLeftTop)
        End Sub

        Private Sub BuildRolesGrid()
            Me.dgvVaiTro = New DataGridView() With {
                .Dock = DockStyle.Fill, .BackgroundColor = Color.FromArgb(15, 23, 42), .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False, .ReadOnly = True,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvVaiTro.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvVaiTro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvVaiTro.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvVaiTro.ColumnHeadersHeight = 32
            Me.dgvVaiTro.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvVaiTro.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvVaiTro.DefaultCellStyle.SelectionBackColor = Color.FromArgb(126, 34, 206)
            Me.dgvVaiTro.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvVaiTro.RowTemplate.Height = 32
        End Sub

        Private Sub BuildAddRoleBox()
            Me.grpThemVaiTro = New GroupBox() With {
                .Text = "  Thêm Vai Trò Mới  ", .Dock = DockStyle.Bottom, .Height = 160,
                .ForeColor = Color.FromArgb(203, 213, 225), .BackColor = Color.FromArgb(30, 41, 59),
                .Padding = New Padding(12), .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            }
            Me.lblTenVT = New Label() With {.Text = "Tên vai trò:", .Location = New Point(12, 28), .AutoSize = True, .Font = New Font("Segoe UI", 8.5F)}
            Me.txtTenVT = New TextBox() With {.Location = New Point(90, 25), .Width = 265, .Font = New Font("Segoe UI", 9.0F)}
            Me.lblMoTaVT = New Label() With {.Text = "Mô tả vai trò:", .Location = New Point(12, 62), .AutoSize = True, .Font = New Font("Segoe UI", 8.5F)}
            Me.txtMoTaVT = New TextBox() With {.Location = New Point(90, 59), .Width = 265, .Font = New Font("Segoe UI", 9.0F)}
            Me.btnThemVaiTro = New Button() With {
                .Text = "➕ Thêm Vai Trò [F3]", .Location = New Point(90, 100), .Size = New Size(160, 32),
                .BackColor = Color.FromArgb(37, 99, 235), .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold), .Cursor = Cursors.Hand
            }
            Me.grpThemVaiTro.Controls.AddRange({Me.lblTenVT, Me.txtTenVT, Me.lblMoTaVT, Me.txtMoTaVT, Me.btnThemVaiTro})
        End Sub

        Private Sub BuildRightPanel()
            Me.pnlRightToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 44, .BackColor = Color.FromArgb(30, 41, 59), .Padding = New Padding(14, 6, 14, 6)}
            Me.lblCurrentRole = New Label() With {
                .Text = "Đang cấu hình: Quản Lý Cơ Sở", .Location = New Point(12, 12), .AutoSize = True,
                .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold), .ForeColor = Color.FromArgb(192, 132, 252)
            }
            Me.btnChonTatCa = New Button() With {
                .Text = "✔ Chọn tất cả", .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(630, 7), .Size = New Size(110, 28), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F), .Cursor = Cursors.Hand
            }
            Me.btnBoChonTatCa = New Button() With {
                .Text = "✖ Bỏ chọn tất cả", .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
                .Location = New Point(748, 7), .Size = New Size(115, 28), .BackColor = Color.FromArgb(51, 65, 85),
                .ForeColor = Color.White, .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 8.5F), .Cursor = Cursors.Hand
            }
            Me.pnlRightToolbar.Controls.AddRange({Me.lblCurrentRole, Me.btnChonTatCa, Me.btnBoChonTatCa})

            BuildPermissionsGrid()
            Me.splitMain.Panel2.Controls.Add(Me.dgvQuyen)
            Me.splitMain.Panel2.Controls.Add(Me.pnlRightToolbar)
        End Sub

        Private Sub BuildPermissionsGrid()
            Me.dgvQuyen = New DataGridView() With {
                .Dock = DockStyle.Fill, .BackgroundColor = Color.FromArgb(15, 23, 42), .BorderStyle = BorderStyle.None,
                .AllowUserToAddRows = False, .AllowUserToDeleteRows = False,
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect, .RowHeadersVisible = False,
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill, .EnableHeadersVisualStyles = False,
                .Font = New Font("Segoe UI", 9.0F)
            }
            Me.dgvQuyen.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85)
            Me.dgvQuyen.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            Me.dgvQuyen.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            Me.dgvQuyen.ColumnHeadersHeight = 32
            Me.dgvQuyen.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
            Me.dgvQuyen.DefaultCellStyle.ForeColor = Color.FromArgb(241, 245, 249)
            Me.dgvQuyen.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235)
            Me.dgvQuyen.DefaultCellStyle.SelectionForeColor = Color.White
            Me.dgvQuyen.RowTemplate.Height = 32
        End Sub

    End Class

End Namespace
