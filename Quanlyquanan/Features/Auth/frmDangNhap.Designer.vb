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
            pnlHeader = New Panel()
            lblTieuDePhu = New Label()
            lblTieuDeChinh = New Label()
            lblTenDangNhap = New Label()
            txtTenDangNhap = New TextBox()
            lblMatKhau = New Label()
            txtMatKhau = New TextBox()
            chkHienMatKhau = New CheckBox()
            lblThongBaoLoi = New Label()
            btnDangNhap = New Button()
            btnThoat = New Button()
            pnlHeader.SuspendLayout()
            SuspendLayout()
            ' 
            ' pnlHeader
            ' 
            pnlHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            pnlHeader.Controls.Add(lblTieuDePhu)
            pnlHeader.Controls.Add(lblTieuDeChinh)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Location = New Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New Size(464, 80)
            pnlHeader.TabIndex = 0
            ' 
            ' lblTieuDePhu
            ' 
            lblTieuDePhu.Dock = DockStyle.Bottom
            lblTieuDePhu.Font = New Font("Segoe UI", 10F)
            lblTieuDePhu.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            lblTieuDePhu.Location = New Point(0, 44)
            lblTieuDePhu.Name = "lblTieuDePhu"
            lblTieuDePhu.Size = New Size(464, 36)
            lblTieuDePhu.TabIndex = 1
            lblTieuDePhu.Text = "ĐĂNG NHẬP TÀI KHOẢN HỆ THỐNG"
            lblTieuDePhu.TextAlign = ContentAlignment.TopCenter
            ' 
            ' lblTieuDeChinh
            ' 
            lblTieuDeChinh.Dock = DockStyle.Top
            lblTieuDeChinh.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
            lblTieuDeChinh.ForeColor = Color.White
            lblTieuDeChinh.Location = New Point(0, 0)
            lblTieuDeChinh.Name = "lblTieuDeChinh"
            lblTieuDeChinh.Padding = New Padding(0, 14, 0, 0)
            lblTieuDeChinh.Size = New Size(464, 42)
            lblTieuDeChinh.TabIndex = 0
            lblTieuDeChinh.Text = "HỆ THỐNG QUẢN LÝ QUÁN ĂN"
            lblTieuDeChinh.TextAlign = ContentAlignment.TopCenter
            ' 
            ' lblTenDangNhap
            ' 
            lblTenDangNhap.AutoSize = True
            lblTenDangNhap.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
            lblTenDangNhap.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblTenDangNhap.Location = New Point(48, 102)
            lblTenDangNhap.Name = "lblTenDangNhap"
            lblTenDangNhap.Size = New Size(105, 19)
            lblTenDangNhap.TabIndex = 1
            lblTenDangNhap.Text = "Tên đăng nhập:"
            ' 
            ' txtTenDangNhap
            ' 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle
            txtTenDangNhap.Font = New Font("Segoe UI", 11F)
            txtTenDangNhap.Location = New Point(52, 126)
            txtTenDangNhap.MaxLength = 50
            txtTenDangNhap.Name = "txtTenDangNhap"
            txtTenDangNhap.Size = New Size(360, 27)
            txtTenDangNhap.TabIndex = 2
            ' 
            ' lblMatKhau
            ' 
            lblMatKhau.AutoSize = True
            lblMatKhau.Font = New Font("Segoe UI Semibold", 10F, FontStyle.Bold)
            lblMatKhau.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblMatKhau.Location = New Point(48, 168)
            lblMatKhau.Name = "lblMatKhau"
            lblMatKhau.Size = New Size(71, 19)
            lblMatKhau.TabIndex = 3
            lblMatKhau.Text = "Mật khẩu:"
            ' 
            ' txtMatKhau
            ' 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle
            txtMatKhau.Font = New Font("Segoe UI", 11F)
            txtMatKhau.Location = New Point(52, 192)
            txtMatKhau.MaxLength = 100
            txtMatKhau.Name = "txtMatKhau"
            txtMatKhau.Size = New Size(360, 27)
            txtMatKhau.TabIndex = 4
            txtMatKhau.UseSystemPasswordChar = True
            ' 
            ' chkHienMatKhau
            ' 
            chkHienMatKhau.AutoSize = True
            chkHienMatKhau.Cursor = Cursors.Hand
            chkHienMatKhau.Font = New Font("Segoe UI", 9F)
            chkHienMatKhau.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            chkHienMatKhau.Location = New Point(52, 226)
            chkHienMatKhau.Name = "chkHienMatKhau"
            chkHienMatKhau.Size = New Size(104, 19)
            chkHienMatKhau.TabIndex = 5
            chkHienMatKhau.Text = "Hiện mật khẩu"
            chkHienMatKhau.UseVisualStyleBackColor = True
            ' 
            ' lblThongBaoLoi
            ' 
            lblThongBaoLoi.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
            lblThongBaoLoi.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
            lblThongBaoLoi.Location = New Point(52, 252)
            lblThongBaoLoi.Name = "lblThongBaoLoi"
            lblThongBaoLoi.Size = New Size(360, 36)
            lblThongBaoLoi.TabIndex = 6
            lblThongBaoLoi.TextAlign = ContentAlignment.MiddleLeft
            ' 
            ' btnDangNhap
            ' 
            btnDangNhap.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            btnDangNhap.Cursor = Cursors.Hand
            btnDangNhap.FlatAppearance.BorderSize = 0
            btnDangNhap.FlatStyle = FlatStyle.Flat
            btnDangNhap.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            btnDangNhap.ForeColor = Color.White
            btnDangNhap.Location = New Point(52, 298)
            btnDangNhap.Name = "btnDangNhap"
            btnDangNhap.Size = New Size(215, 38)
            btnDangNhap.TabIndex = 7
            btnDangNhap.Text = "ĐĂNG NHẬP"
            btnDangNhap.UseVisualStyleBackColor = False
            ' 
            ' btnThoat
            ' 
            btnThoat.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            btnThoat.Cursor = Cursors.Hand
            btnThoat.FlatAppearance.BorderSize = 0
            btnThoat.FlatStyle = FlatStyle.Flat
            btnThoat.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            btnThoat.ForeColor = Color.White
            btnThoat.Location = New Point(277, 298)
            btnThoat.Name = "btnThoat"
            btnThoat.Size = New Size(135, 38)
            btnThoat.TabIndex = 8
            btnThoat.Text = "THOÁT"
            btnThoat.UseVisualStyleBackColor = False
            ' 
            ' frmDangNhap
            ' 
            AcceptButton = btnDangNhap
            AutoScaleDimensions = New SizeF(7F, 15F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.White
            CancelButton = btnThoat
            ClientSize = New Size(464, 361)
            Controls.Add(btnThoat)
            Controls.Add(btnDangNhap)
            Controls.Add(lblThongBaoLoi)
            Controls.Add(chkHienMatKhau)
            Controls.Add(txtMatKhau)
            Controls.Add(lblMatKhau)
            Controls.Add(txtTenDangNhap)
            Controls.Add(lblTenDangNhap)
            Controls.Add(pnlHeader)
            Font = New Font("Segoe UI", 9F)
            FormBorderStyle = FormBorderStyle.FixedDialog
            MaximizeBox = False
            Name = "frmDangNhap"
            StartPosition = FormStartPosition.CenterScreen
            Text = "Đăng Nhập - Quản Lý Quán Ăn"
            pnlHeader.ResumeLayout(False)
            ResumeLayout(False)
            PerformLayout()

        End Sub
    End Class
End Namespace
