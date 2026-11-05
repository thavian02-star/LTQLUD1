Namespace Features.Auth
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class frmDoiMatKhau
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
        Friend WithEvents lblHeaderIcon As System.Windows.Forms.Label
        Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
        Friend WithEvents lblHeaderSubtitle As System.Windows.Forms.Label
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents btnHuy As System.Windows.Forms.Button
        Friend WithEvents btnLuu As System.Windows.Forms.Button
        Friend WithEvents pnlBody As System.Windows.Forms.Panel
        Friend WithEvents pnlUserInfo As System.Windows.Forms.Panel
        Friend WithEvents lblCurrentAccount As System.Windows.Forms.Label
        Friend WithEvents lblCurrentRole As System.Windows.Forms.Label
        Friend WithEvents lblThongBaoLoi As System.Windows.Forms.Label
        Friend WithEvents lblMatKhauCu As System.Windows.Forms.Label
        Friend WithEvents txtMatKhauCu As System.Windows.Forms.TextBox
        Friend WithEvents lblMatKhauMoi As System.Windows.Forms.Label
        Friend WithEvents txtMatKhauMoi As System.Windows.Forms.TextBox
        Friend WithEvents lblXacNhanMoi As System.Windows.Forms.Label
        Friend WithEvents txtXacNhanMoi As System.Windows.Forms.TextBox
        Friend WithEvents chkHienMatKhau As System.Windows.Forms.CheckBox

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            pnlHeader = New Panel()
            lblHeaderSubtitle = New Label()
            lblHeaderTitle = New Label()
            lblHeaderIcon = New Label()
            pnlFooter = New Panel()
            btnHuy = New Button()
            btnLuu = New Button()
            pnlBody = New Panel()
            chkHienMatKhau = New CheckBox()
            txtXacNhanMoi = New TextBox()
            lblXacNhanMoi = New Label()
            txtMatKhauMoi = New TextBox()
            lblMatKhauMoi = New Label()
            txtMatKhauCu = New TextBox()
            lblMatKhauCu = New Label()
            lblThongBaoLoi = New Label()
            pnlUserInfo = New Panel()
            lblCurrentRole = New Label()
            lblCurrentAccount = New Label()
            pnlHeader.SuspendLayout()
            pnlFooter.SuspendLayout()
            pnlBody.SuspendLayout()
            pnlUserInfo.SuspendLayout()
            SuspendLayout()
            ' 
            ' pnlHeader
            ' 
            pnlHeader.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            pnlHeader.Controls.Add(lblHeaderSubtitle)
            pnlHeader.Controls.Add(lblHeaderTitle)
            pnlHeader.Controls.Add(lblHeaderIcon)
            pnlHeader.Dock = DockStyle.Top
            pnlHeader.Location = New Point(0, 0)
            pnlHeader.Name = "pnlHeader"
            pnlHeader.Size = New Size(480, 70)
            pnlHeader.TabIndex = 0
            ' 
            ' lblHeaderSubtitle
            ' 
            lblHeaderSubtitle.Font = New Font("Segoe UI", 8.5F)
            lblHeaderSubtitle.ForeColor = Color.FromArgb(CByte(214), CByte(234), CByte(248))
            lblHeaderSubtitle.Location = New Point(70, 40)
            lblHeaderSubtitle.Name = "lblHeaderSubtitle"
            lblHeaderSubtitle.Size = New Size(395, 20)
            lblHeaderSubtitle.TabIndex = 2
            lblHeaderSubtitle.Text = "Nhập mật khẩu hiện tại và tạo mật khẩu mới để bảo mật"
            lblHeaderSubtitle.TextAlign = ContentAlignment.MiddleLeft
            ' 
            ' lblHeaderTitle
            ' 
            lblHeaderTitle.Font = New Font("Segoe UI", 11.5F, FontStyle.Bold)
            lblHeaderTitle.ForeColor = Color.White
            lblHeaderTitle.Location = New Point(70, 14)
            lblHeaderTitle.Name = "lblHeaderTitle"
            lblHeaderTitle.Size = New Size(395, 24)
            lblHeaderTitle.TabIndex = 1
            lblHeaderTitle.Text = "ĐỔI MẬT KHẨU TÀI KHOẢN"
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleLeft
            ' 
            ' lblHeaderIcon
            ' 
            lblHeaderIcon.Font = New Font("Segoe UI", 20F)
            lblHeaderIcon.ForeColor = Color.White
            lblHeaderIcon.Location = New Point(16, 12)
            lblHeaderIcon.Name = "lblHeaderIcon"
            lblHeaderIcon.Size = New Size(46, 46)
            lblHeaderIcon.TabIndex = 0
            lblHeaderIcon.Text = "🔐"
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' pnlFooter
            ' 
            pnlFooter.BackColor = Color.FromArgb(CByte(248), CByte(250), CByte(252))
            pnlFooter.Controls.Add(btnHuy)
            pnlFooter.Controls.Add(btnLuu)
            pnlFooter.Dock = DockStyle.Bottom
            pnlFooter.Location = New Point(0, 364)
            pnlFooter.Name = "pnlFooter"
            pnlFooter.Size = New Size(480, 56)
            pnlFooter.TabIndex = 2
            ' 
            ' btnHuy
            ' 
            btnHuy.BackColor = Color.FromArgb(CByte(226), CByte(232), CByte(240))
            btnHuy.Cursor = Cursors.Hand
            btnHuy.FlatAppearance.BorderColor = Color.FromArgb(CByte(203), CByte(213), CByte(225))
            btnHuy.FlatStyle = FlatStyle.Flat
            btnHuy.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnHuy.ForeColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
            btnHuy.Location = New Point(234, 10)
            btnHuy.Name = "btnHuy"
            btnHuy.Size = New Size(110, 36)
            btnHuy.TabIndex = 5
            btnHuy.Text = "❌  Hủy Bỏ"
            btnHuy.UseVisualStyleBackColor = False
            ' 
            ' btnLuu
            ' 
            btnLuu.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            btnLuu.Cursor = Cursors.Hand
            btnLuu.FlatAppearance.BorderSize = 0
            btnLuu.FlatStyle = FlatStyle.Flat
            btnLuu.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            btnLuu.ForeColor = Color.White
            btnLuu.Location = New Point(354, 10)
            btnLuu.Name = "btnLuu"
            btnLuu.Size = New Size(110, 36)
            btnLuu.TabIndex = 4
            btnLuu.Text = "💾  Lưu Mới"
            btnLuu.UseVisualStyleBackColor = False
            ' 
            ' pnlBody
            ' 
            pnlBody.BackColor = Color.White
            pnlBody.Controls.Add(chkHienMatKhau)
            pnlBody.Controls.Add(txtXacNhanMoi)
            pnlBody.Controls.Add(lblXacNhanMoi)
            pnlBody.Controls.Add(txtMatKhauMoi)
            pnlBody.Controls.Add(lblMatKhauMoi)
            pnlBody.Controls.Add(txtMatKhauCu)
            pnlBody.Controls.Add(lblMatKhauCu)
            pnlBody.Controls.Add(lblThongBaoLoi)
            pnlBody.Controls.Add(pnlUserInfo)
            pnlBody.Dock = DockStyle.Fill
            pnlBody.Location = New Point(0, 70)
            pnlBody.Name = "pnlBody"
            pnlBody.Padding = New Padding(20, 10, 20, 10)
            pnlBody.Size = New Size(480, 294)
            pnlBody.TabIndex = 1
            ' 
            ' chkHienMatKhau
            ' 
            chkHienMatKhau.AutoSize = True
            chkHienMatKhau.Cursor = Cursors.Hand
            chkHienMatKhau.Font = New Font("Segoe UI", 8.5F)
            chkHienMatKhau.ForeColor = Color.FromArgb(CByte(71), CByte(85), CByte(105))
            chkHienMatKhau.Location = New Point(20, 256)
            chkHienMatKhau.Name = "chkHienMatKhau"
            chkHienMatKhau.Size = New Size(157, 19)
            chkHienMatKhau.TabIndex = 3
            chkHienMatKhau.Text = "Hiển thị tất cả mật khẩu"
            chkHienMatKhau.UseVisualStyleBackColor = True
            ' 
            ' txtXacNhanMoi
            ' 
            txtXacNhanMoi.BorderStyle = BorderStyle.FixedSingle
            txtXacNhanMoi.Font = New Font("Segoe UI", 9.5F)
            txtXacNhanMoi.Location = New Point(20, 222)
            txtXacNhanMoi.MaxLength = 50
            txtXacNhanMoi.Name = "txtXacNhanMoi"
            txtXacNhanMoi.Size = New Size(440, 24)
            txtXacNhanMoi.TabIndex = 2
            txtXacNhanMoi.UseSystemPasswordChar = True
            ' 
            ' lblXacNhanMoi
            ' 
            lblXacNhanMoi.AutoSize = True
            lblXacNhanMoi.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblXacNhanMoi.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
            lblXacNhanMoi.Location = New Point(20, 202)
            lblXacNhanMoi.Name = "lblXacNhanMoi"
            lblXacNhanMoi.Size = New Size(151, 15)
            lblXacNhanMoi.TabIndex = 6
            lblXacNhanMoi.Text = "Xác nhận mật khẩu mới *"
            ' 
            ' txtMatKhauMoi
            ' 
            txtMatKhauMoi.BorderStyle = BorderStyle.FixedSingle
            txtMatKhauMoi.Font = New Font("Segoe UI", 9.5F)
            txtMatKhauMoi.Location = New Point(20, 166)
            txtMatKhauMoi.MaxLength = 50
            txtMatKhauMoi.Name = "txtMatKhauMoi"
            txtMatKhauMoi.Size = New Size(440, 24)
            txtMatKhauMoi.TabIndex = 1
            txtMatKhauMoi.UseSystemPasswordChar = True
            ' 
            ' lblMatKhauMoi
            ' 
            lblMatKhauMoi.AutoSize = True
            lblMatKhauMoi.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblMatKhauMoi.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
            lblMatKhauMoi.Location = New Point(20, 146)
            lblMatKhauMoi.Name = "lblMatKhauMoi"
            lblMatKhauMoi.Size = New Size(183, 15)
            lblMatKhauMoi.TabIndex = 4
            lblMatKhauMoi.Text = "Mật khẩu mới * (ít nhất 6 ký tự)"
            ' 
            ' txtMatKhauCu
            ' 
            txtMatKhauCu.BorderStyle = BorderStyle.FixedSingle
            txtMatKhauCu.Font = New Font("Segoe UI", 9.5F)
            txtMatKhauCu.Location = New Point(20, 110)
            txtMatKhauCu.MaxLength = 50
            txtMatKhauCu.Name = "txtMatKhauCu"
            txtMatKhauCu.Size = New Size(440, 24)
            txtMatKhauCu.TabIndex = 0
            txtMatKhauCu.UseSystemPasswordChar = True
            ' 
            ' lblMatKhauCu
            ' 
            lblMatKhauCu.AutoSize = True
            lblMatKhauCu.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblMatKhauCu.ForeColor = Color.FromArgb(CByte(51), CByte(65), CByte(85))
            lblMatKhauCu.Location = New Point(20, 90)
            lblMatKhauCu.Name = "lblMatKhauCu"
            lblMatKhauCu.Size = New Size(147, 15)
            lblMatKhauCu.TabIndex = 2
            lblMatKhauCu.Text = "Mật khẩu cũ (hiện tại) *"
            ' 
            ' lblThongBaoLoi
            ' 
            lblThongBaoLoi.BackColor = Color.FromArgb(CByte(254), CByte(242), CByte(242))
            lblThongBaoLoi.Font = New Font("Segoe UI", 8.5F)
            lblThongBaoLoi.ForeColor = Color.FromArgb(CByte(153), CByte(27), CByte(27))
            lblThongBaoLoi.Location = New Point(20, 52)
            lblThongBaoLoi.Name = "lblThongBaoLoi"
            lblThongBaoLoi.Padding = New Padding(8, 0, 0, 0)
            lblThongBaoLoi.Size = New Size(440, 28)
            lblThongBaoLoi.TabIndex = 1
            lblThongBaoLoi.Text = "⚠️ Thông báo lỗi hiển thị tại đây"
            lblThongBaoLoi.TextAlign = ContentAlignment.MiddleLeft
            lblThongBaoLoi.Visible = False
            ' 
            ' pnlUserInfo
            ' 
            pnlUserInfo.BackColor = Color.FromArgb(CByte(241), CByte(245), CByte(249))
            pnlUserInfo.Controls.Add(lblCurrentRole)
            pnlUserInfo.Controls.Add(lblCurrentAccount)
            pnlUserInfo.Location = New Point(20, 10)
            pnlUserInfo.Name = "pnlUserInfo"
            pnlUserInfo.Size = New Size(440, 36)
            pnlUserInfo.TabIndex = 0
            ' 
            ' lblCurrentRole
            ' 
            lblCurrentRole.BackColor = Color.FromArgb(CByte(41), CByte(128), CByte(185))
            lblCurrentRole.Font = New Font("Segoe UI", 8F, FontStyle.Bold)
            lblCurrentRole.ForeColor = Color.White
            lblCurrentRole.Location = New Point(310, 6)
            lblCurrentRole.Name = "lblCurrentRole"
            lblCurrentRole.Size = New Size(120, 24)
            lblCurrentRole.TabIndex = 1
            lblCurrentRole.Text = "CHỦ QUÁN"
            lblCurrentRole.TextAlign = ContentAlignment.MiddleCenter
            ' 
            ' lblCurrentAccount
            ' 
            lblCurrentAccount.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
            lblCurrentAccount.ForeColor = Color.FromArgb(CByte(30), CByte(41), CByte(59))
            lblCurrentAccount.Location = New Point(10, 8)
            lblCurrentAccount.Name = "lblCurrentAccount"
            lblCurrentAccount.Size = New Size(290, 20)
            lblCurrentAccount.TabIndex = 0
            lblCurrentAccount.Text = "👤 chuquan (Nguyễn Hoàng Nam)"
            lblCurrentAccount.TextAlign = ContentAlignment.MiddleLeft
            ' 
            ' frmDoiMatKhau
            ' 
            AcceptButton = btnLuu
            AutoScaleDimensions = New SizeF(7F, 15F)
            AutoScaleMode = AutoScaleMode.Font
            BackColor = Color.White
            CancelButton = btnHuy
            ClientSize = New Size(480, 420)
            Controls.Add(pnlBody)
            Controls.Add(pnlFooter)
            Controls.Add(pnlHeader)
            Font = New Font("Segoe UI", 9F)
            FormBorderStyle = FormBorderStyle.FixedDialog
            MaximizeBox = False
            MinimizeBox = False
            Name = "frmDoiMatKhau"
            ShowInTaskbar = False
            StartPosition = FormStartPosition.CenterParent
            Text = "Đổi Mật Khẩu - Quản Lý Quán Ăn"
            pnlHeader.ResumeLayout(False)
            pnlFooter.ResumeLayout(False)
            pnlBody.ResumeLayout(False)
            pnlBody.PerformLayout()
            pnlUserInfo.ResumeLayout(False)
            ResumeLayout(False)
        End Sub
    End Class
End Namespace
