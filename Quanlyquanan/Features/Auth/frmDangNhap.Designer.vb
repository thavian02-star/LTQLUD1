Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Auth
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmDangNhap
        Inherits System.Windows.Forms.Form

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

        Private components As System.ComponentModel.IContainer

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblTieuDeChinh As System.Windows.Forms.Label
        Friend WithEvents lblTieuDePhu As System.Windows.Forms.Label
        Friend WithEvents lblChonTaiKhoan As System.Windows.Forms.Label
        Friend WithEvents cboTaiKhoanMau As System.Windows.Forms.ComboBox
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
            InitControls()
            BuildHeader()
            BuildQuickSelect()
            BuildInputs()
            BuildLabelsAndFeedback()
            BuildButtons()
            BuildLayout()
        End Sub

        Private Sub InitControls()
            pnlHeader = New Panel()
            lblTieuDePhu = New Label()
            lblTieuDeChinh = New Label()
            lblChonTaiKhoan = New Label()
            cboTaiKhoanMau = New ComboBox()
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
        End Sub

        Private Sub BuildHeader()
            pnlHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            pnlHeader.Controls.Add(lblTieuDePhu)
            pnlHeader.Controls.Add(lblTieuDeChinh)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Location = New Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New Size(464, 80)
            pnlHeader.TabIndex = 0

            lblTieuDePhu.Dock = DockStyle.Bottom
            lblTieuDePhu.Font = New Font("Segoe UI", 9.5F)
            lblTieuDePhu.ForeColor = Color.FromArgb(CByte(236), CByte(240), CByte(241))
            lblTieuDePhu.Location = New Point(0, 44)
            lblTieuDePhu.Name = "lblTieuDePhu"
            lblTieuDePhu.Size = New Size(464, 36)
            lblTieuDePhu.TabIndex = 1
            lblTieuDePhu.Text = "ĐĂNG NHẬP TÀI KHOẢN HỆ THỐNG"
            lblTieuDePhu.TextAlign = ContentAlignment.TopCenter

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
        End Sub

        Private Sub BuildQuickSelect()
            lblChonTaiKhoan.AutoSize = True
            lblChonTaiKhoan.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            lblChonTaiKhoan.ForeColor = Color.FromArgb(CByte(26), CByte(82), CByte(118))
            lblChonTaiKhoan.Location = New Point(48, 92)
            lblChonTaiKhoan.Name = "lblChonTaiKhoan"
            lblChonTaiKhoan.Size = New Size(245, 17)
            lblChonTaiKhoan.TabIndex = 1
            lblChonTaiKhoan.Text = "⚡ Chọn nhanh tài khoản mẫu (Click để điền):"

            cboTaiKhoanMau.DropDownStyle = ComboBoxStyle.DropDownList
            cboTaiKhoanMau.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
            cboTaiKhoanMau.ForeColor = Color.FromArgb(CByte(30), CByte(41), CByte(59))
            cboTaiKhoanMau.Location = New Point(52, 114)
            cboTaiKhoanMau.Name = "cboTaiKhoanMau"
            cboTaiKhoanMau.Size = New Size(360, 25)
            cboTaiKhoanMau.TabIndex = 2
        End Sub

        Private Sub BuildInputs()
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle
            txtTenDangNhap.Font = New Font("Segoe UI", 10.5F)
            txtTenDangNhap.Location = New Point(52, 172)
            txtTenDangNhap.MaxLength = 50
            txtTenDangNhap.Name = "txtTenDangNhap"
            txtTenDangNhap.Size = New Size(360, 26)
            txtTenDangNhap.TabIndex = 4

            txtMatKhau.BorderStyle = BorderStyle.FixedSingle
            txtMatKhau.Font = New Font("Segoe UI", 10.5F)
            txtMatKhau.Location = New Point(52, 230)
            txtMatKhau.MaxLength = 100
            txtMatKhau.Name = "txtMatKhau"
            txtMatKhau.Size = New Size(360, 26)
            txtMatKhau.TabIndex = 6
            txtMatKhau.UseSystemPasswordChar = True
        End Sub

        Private Sub BuildLabelsAndFeedback()
            lblTenDangNhap.AutoSize = True
            lblTenDangNhap.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            lblTenDangNhap.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblTenDangNhap.Location = New Point(48, 150)
            lblTenDangNhap.Name = "lblTenDangNhap"
            lblTenDangNhap.Size = New Size(103, 17)
            lblTenDangNhap.TabIndex = 3
            lblTenDangNhap.Text = "Tên đăng nhập:"

            lblMatKhau.AutoSize = True
            lblMatKhau.Font = New Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
            lblMatKhau.ForeColor = Color.FromArgb(CByte(44), CByte(62), CByte(80))
            lblMatKhau.Location = New Point(48, 208)
            lblMatKhau.Name = "lblMatKhau"
            lblMatKhau.Size = New Size(69, 17)
            lblMatKhau.TabIndex = 5
            lblMatKhau.Text = "Mật khẩu:"

            chkHienMatKhau.AutoSize = True
            chkHienMatKhau.Cursor = Cursors.Hand
            chkHienMatKhau.Font = New Font("Segoe UI", 9F)
            chkHienMatKhau.ForeColor = Color.FromArgb(CByte(127), CByte(140), CByte(141))
            chkHienMatKhau.Location = New Point(52, 262)
            chkHienMatKhau.Name = "chkHienMatKhau"
            chkHienMatKhau.Size = New Size(104, 19)
            chkHienMatKhau.TabIndex = 7
            chkHienMatKhau.Text = "Hiện mật khẩu"
            chkHienMatKhau.UseVisualStyleBackColor = True

            lblThongBaoLoi.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
            lblThongBaoLoi.ForeColor = Color.FromArgb(CByte(231), CByte(76), CByte(60))
            lblThongBaoLoi.Location = New Point(52, 288)
            lblThongBaoLoi.Name = "lblThongBaoLoi"
            lblThongBaoLoi.Size = New Size(360, 36)
            lblThongBaoLoi.TabIndex = 8
            lblThongBaoLoi.TextAlign = ContentAlignment.MiddleLeft
        End Sub

        Private Sub BuildButtons()
            btnDangNhap.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            btnDangNhap.Cursor = Cursors.Hand
            btnDangNhap.FlatAppearance.BorderSize = 0
            btnDangNhap.FlatStyle = FlatStyle.Flat
            btnDangNhap.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            btnDangNhap.ForeColor = Color.White
            btnDangNhap.Location = New Point(52, 334)
            btnDangNhap.Name = "btnDangNhap"
            btnDangNhap.Size = New Size(215, 40)
            btnDangNhap.TabIndex = 9
            btnDangNhap.Text = "ĐĂNG NHẬP"
            btnDangNhap.UseVisualStyleBackColor = False

            btnThoat.BackColor = Color.FromArgb(CByte(149), CByte(165), CByte(166))
            btnThoat.Cursor = Cursors.Hand
            btnThoat.FlatAppearance.BorderSize = 0
            btnThoat.FlatStyle = FlatStyle.Flat
            btnThoat.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            btnThoat.ForeColor = Color.White
            btnThoat.Location = New Point(277, 334)
            btnThoat.Name = "btnThoat"
            btnThoat.Size = New Size(135, 40)
            btnThoat.TabIndex = 10
            btnThoat.Text = "THOÁT"
            btnThoat.UseVisualStyleBackColor = False
        End Sub

        Private Sub BuildLayout()
            AcceptButton = btnDangNhap
            AutoScaleDimensions = New SizeF(7F, 15F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.White
            CancelButton = btnThoat
            ClientSize = New Size(464, 398)
            Controls.Add(btnThoat)
            Controls.Add(btnDangNhap)
            Controls.Add(lblThongBaoLoi)
            Controls.Add(chkHienMatKhau)
            Controls.Add(txtMatKhau)
            Controls.Add(lblMatKhau)
            Controls.Add(txtTenDangNhap)
            Controls.Add(lblTenDangNhap)
            Controls.Add(cboTaiKhoanMau)
            Controls.Add(lblChonTaiKhoan)
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
