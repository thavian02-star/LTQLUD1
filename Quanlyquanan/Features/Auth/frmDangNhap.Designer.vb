Namespace Features.Auth
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmDangNhap
        Inherits System.Windows.Forms.Form

        ' Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(disposing As Boolean)
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

        ' Declarations of Form Controls
        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTieuDeChinh As System.Windows.Forms.Label
        Friend WithEvents lblTieuDePhu As System.Windows.Forms.Label
        Friend WithEvents lblTenDangNhap As System.Windows.Forms.Label
        Friend WithEvents txtTenDangNhap As System.Windows.Forms.TextBox
        Friend WithEvents lblMatKhau As System.Windows.Forms.Label
        Friend WithEvents txtMatKhau As System.Windows.Forms.TextBox
        Friend WithEvents chkHienMatKhau As System.Windows.Forms.CheckBox
        Friend WithEvents lblThongBaoLoi As System.Windows.Forms.Label
        Friend WithEvents btnDangNhap As System.Windows.Forms.Button
        Friend WithEvents btnThoat As System.Windows.Forms.Button

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblTieuDeChinh = New System.Windows.Forms.Label()
            Me.lblTieuDePhu = New System.Windows.Forms.Label()
            Me.lblTenDangNhap = New System.Windows.Forms.Label()
            Me.txtTenDangNhap = New System.Windows.Forms.TextBox()
            Me.lblMatKhau = New System.Windows.Forms.Label()
            Me.txtMatKhau = New System.Windows.Forms.TextBox()
            Me.chkHienMatKhau = New System.Windows.Forms.CheckBox()
            Me.lblThongBaoLoi = New System.Windows.Forms.Label()
            Me.btnDangNhap = New System.Windows.Forms.Button()
            Me.btnThoat = New System.Windows.Forms.Button()
            Me.pnlHeader.SuspendLayout()
            Me.SuspendLayout()
            '
            ' pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.pnlHeader.Controls.Add(Me.lblTieuDePhu)
            Me.pnlHeader.Controls.Add(Me.lblTieuDeChinh)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(464, 80)
            Me.pnlHeader.TabIndex = 0
            '
            ' lblTieuDeChinh
            '
            Me.lblTieuDeChinh.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblTieuDeChinh.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTieuDeChinh.ForeColor = System.Drawing.Color.White
            Me.lblTieuDeChinh.Location = New System.Drawing.Point(0, 0)
            Me.lblTieuDeChinh.Name = "lblTieuDeChinh"
            Me.lblTieuDeChinh.Padding = New System.Windows.Forms.Padding(0, 14, 0, 0)
            Me.lblTieuDeChinh.Size = New System.Drawing.Size(464, 42)
            Me.lblTieuDeChinh.TabIndex = 0
            Me.lblTieuDeChinh.Text = "HỆ THỐNG QUẢN LÝ QUÁN ĂN"
            Me.lblTieuDeChinh.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            ' lblTieuDePhu
            '
            Me.lblTieuDePhu.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.lblTieuDePhu.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.lblTieuDePhu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(241, Byte), Integer))
            Me.lblTieuDePhu.Location = New System.Drawing.Point(0, 44)
            Me.lblTieuDePhu.Name = "lblTieuDePhu"
            Me.lblTieuDePhu.Size = New System.Drawing.Size(464, 36)
            Me.lblTieuDePhu.TabIndex = 1
            Me.lblTieuDePhu.Text = "ĐĂNG NHẬP TÀI KHOẢN HỆ THỐNG"
            Me.lblTieuDePhu.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            ' lblTenDangNhap
            '
            Me.lblTenDangNhap.AutoSize = True
            Me.lblTenDangNhap.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lblTenDangNhap.Location = New System.Drawing.Point(48, 102)
            Me.lblTenDangNhap.Name = "lblTenDangNhap"
            Me.lblTenDangNhap.Size = New System.Drawing.Size(107, 19)
            Me.lblTenDangNhap.TabIndex = 1
            Me.lblTenDangNhap.Text = "Tên đăng nhập:"
            '
            ' txtTenDangNhap
            '
            Me.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTenDangNhap.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtTenDangNhap.Location = New System.Drawing.Point(52, 126)
            Me.txtTenDangNhap.MaxLength = 50
            Me.txtTenDangNhap.Name = "txtTenDangNhap"
            Me.txtTenDangNhap.Size = New System.Drawing.Size(360, 27)
            Me.txtTenDangNhap.TabIndex = 2
            '
            ' lblMatKhau
            '
            Me.lblMatKhau.AutoSize = True
            Me.lblMatKhau.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.lblMatKhau.Location = New System.Drawing.Point(48, 168)
            Me.lblMatKhau.Name = "lblMatKhau"
            Me.lblMatKhau.Size = New System.Drawing.Size(71, 19)
            Me.lblMatKhau.TabIndex = 3
            Me.lblMatKhau.Text = "Mật khẩu:"
            '
            ' txtMatKhau
            '
            Me.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMatKhau.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.txtMatKhau.Location = New System.Drawing.Point(52, 192)
            Me.txtMatKhau.MaxLength = 100
            Me.txtMatKhau.Name = "txtMatKhau"
            Me.txtMatKhau.Size = New System.Drawing.Size(360, 27)
            Me.txtMatKhau.TabIndex = 4
            Me.txtMatKhau.UseSystemPasswordChar = True
            '
            ' chkHienMatKhau
            '
            Me.chkHienMatKhau.AutoSize = True
            Me.chkHienMatKhau.Cursor = System.Windows.Forms.Cursors.Hand
            Me.chkHienMatKhau.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.chkHienMatKhau.ForeColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.chkHienMatKhau.Location = New System.Drawing.Point(52, 226)
            Me.chkHienMatKhau.Name = "chkHienMatKhau"
            Me.chkHienMatKhau.Size = New System.Drawing.Size(104, 19)
            Me.chkHienMatKhau.TabIndex = 5
            Me.chkHienMatKhau.Text = "Hiện mật khẩu"
            Me.chkHienMatKhau.UseVisualStyleBackColor = True
            '
            ' lblThongBaoLoi
            '
            Me.lblThongBaoLoi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.lblThongBaoLoi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(60, Byte), Integer))
            Me.lblThongBaoLoi.Location = New System.Drawing.Point(52, 252)
            Me.lblThongBaoLoi.Name = "lblThongBaoLoi"
            Me.lblThongBaoLoi.Size = New System.Drawing.Size(360, 36)
            Me.lblThongBaoLoi.TabIndex = 6
            Me.lblThongBaoLoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            ' btnDangNhap
            '
            Me.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(185, Byte), Integer))
            Me.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnDangNhap.FlatAppearance.BorderSize = 0
            Me.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDangNhap.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnDangNhap.ForeColor = System.Drawing.Color.White
            Me.btnDangNhap.Location = New System.Drawing.Point(52, 298)
            Me.btnDangNhap.Name = "btnDangNhap"
            Me.btnDangNhap.Size = New System.Drawing.Size(215, 38)
            Me.btnDangNhap.TabIndex = 7
            Me.btnDangNhap.Text = "ĐĂNG NHẬP"
            Me.btnDangNhap.UseVisualStyleBackColor = False
            '
            ' btnThoat
            '
            Me.btnThoat.BackColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(166, Byte), Integer))
            Me.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnThoat.FlatAppearance.BorderSize = 0
            Me.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnThoat.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
            Me.btnThoat.ForeColor = System.Drawing.Color.White
            Me.btnThoat.Location = New System.Drawing.Point(277, 298)
            Me.btnThoat.Name = "btnThoat"
            Me.btnThoat.Size = New System.Drawing.Size(135, 38)
            Me.btnThoat.TabIndex = 8
            Me.btnThoat.Text = "THOÁT"
            Me.btnThoat.UseVisualStyleBackColor = False
            '
            ' frmDangNhap
            '
            Me.AcceptButton = Me.btnDangNhap
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.CancelButton = Me.btnThoat
            Me.ClientSize = New System.Drawing.Size(464, 361)
            Me.Controls.Add(Me.btnThoat)
            Me.Controls.Add(Me.btnDangNhap)
            Me.Controls.Add(Me.lblThongBaoLoi)
            Me.Controls.Add(Me.chkHienMatKhau)
            Me.Controls.Add(Me.txtMatKhau)
            Me.Controls.Add(Me.lblMatKhau)
            Me.Controls.Add(Me.txtTenDangNhap)
            Me.Controls.Add(Me.lblTenDangNhap)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.Name = "frmDangNhap"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Đăng Nhập - Quản Lý Quán Ăn"
            Me.pnlHeader.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    End Class
End Namespace
