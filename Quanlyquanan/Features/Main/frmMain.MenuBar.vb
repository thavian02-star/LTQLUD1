Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Main

    Partial Class frmMain

        Friend msMainMenu As MenuStrip
        Friend mnuHeThong As ToolStripMenuItem
        Friend mnuDanhMuc As ToolStripMenuItem
        Friend mnuBanHang As ToolStripMenuItem
        Friend mnuBaoCao As ToolStripMenuItem
        Friend mnuTroGiup As ToolStripMenuItem

        ''' <summary>
        ''' Khởi tạo thanh Menu ngang cấp cao (MenuStrip) chuẩn giáo trình đại học
        ''' </summary>
        Private Sub KhoiTaoThanhMenuBar()
            msMainMenu = New MenuStrip()
            msMainMenu.BackColor = Color.White
            msMainMenu.ForeColor = Color.FromArgb(44, 62, 80)
            msMainMenu.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
            msMainMenu.Dock = DockStyle.Top

            TaoMenuHeThong()
            TaoMenuDanhMucMaster()
            TaoMenuNghiepVuVaBaoCao()

            Me.MainMenuStrip = msMainMenu
            Me.Controls.Add(msMainMenu)
            msMainMenu.BringToFront()
            pnlHeader.BringToFront()
        End Sub

        Private Sub TaoMenuHeThong()
            mnuHeThong = New ToolStripMenuItem("⚙️ &Hệ Thống")
            Dim itemDoiMK As New ToolStripMenuItem("🔑 &Đổi Mật Khẩu", Nothing, AddressOf MenuDoiMatKhau_Click, Keys.Control Or Keys.P)
            Dim itemDangXuat As New ToolStripMenuItem("🚪 Đăng &Xuất", Nothing, AddressOf MenuDangXuat_Click, Keys.Alt Or Keys.F4)
            Dim itemThoat As New ToolStripMenuItem("❌ &Thoát Ứng Dụng", Nothing, Sub() Application.Exit())

            mnuHeThong.DropDownItems.Add(itemDoiMK)
            mnuHeThong.DropDownItems.Add(New ToolStripSeparator())
            mnuHeThong.DropDownItems.Add(itemDangXuat)
            mnuHeThong.DropDownItems.Add(itemThoat)
            msMainMenu.Items.Add(mnuHeThong)
        End Sub

        Private Sub TaoMenuDanhMucMaster()
            mnuDanhMuc = New ToolStripMenuItem("📋 &Danh Mục Nền Tảng (9/9)")
            mnuDanhMuc.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            mnuDanhMuc.ForeColor = Color.FromArgb(26, 82, 118)

            Dim items As (String, Keys, EventHandler)() = {
                ("👥 1. Quản lý Nhân Viên & Tài Khoản", Keys.Control Or Keys.D1, Sub() MoQuanLyNhanVien()),
                ("⏰ 2. Quản lý Ca Làm Việc & Lương", Keys.Control Or Keys.D2, Sub() MoQuanLyCaLamViec()),
                ("🍲 3. Quản lý Danh mục Món Ăn", Keys.Control Or Keys.D3, Sub() MoQuanLyMonAn()),
                ("📁 4. Quản lý Phân Loại Món Ăn", Keys.Control Or Keys.D4, Sub() MoQuanLyDanhMuc()),
                ("🏢 5. Quản lý Khu Vực Bàn Ăn", Keys.Control Or Keys.D5, Sub() MoQuanLyKhuVuc()),
                ("🪑 6. Quản lý Sơ Đồ Bàn Ăn", Keys.Control Or Keys.D6, Sub() MoQuanLyBan()),
                ("📋 7. Quản lý Bảng Thực Đơn Master", Keys.Control Or Keys.D7, Sub() MoQuanLyMenu()),
                ("🏬 8. Quản lý Chuỗi Cơ Sở Chi Nhánh", Keys.Control Or Keys.D8, Sub() MoQuanLyChiNhanh()),
                ("📑 9. Phân Bổ Thực Đơn Chi Nhánh", Keys.Control Or Keys.D9, Sub() MoQuanLyMenuChiNhanh())
            }

            For Each itm In items
                Dim menuItem As New ToolStripMenuItem(itm.Item1, Nothing, itm.Item3, itm.Item2)
                mnuDanhMuc.DropDownItems.Add(menuItem)
            Next
            msMainMenu.Items.Add(mnuDanhMuc)
        End Sub

        Private Sub TaoMenuNghiepVuVaBaoCao()
            mnuBanHang = New ToolStripMenuItem("🍽️ &Bán Hàng POS")
            mnuBanHang.DropDownItems.Add(New ToolStripMenuItem("🪑 Điểm Bán Hàng & Sơ Đồ Bàn POS", Nothing, Sub() MoSoDoBanPOS(), Keys.F2))
            mnuBanHang.DropDownItems.Add(New ToolStripMenuItem("🍳 Hàng Đợi Nhà Bếp (FIFO)", Nothing, Sub() MoHangDoiNhaBepKDS(), Keys.F3))
            msMainMenu.Items.Add(mnuBanHang)

            mnuBaoCao = New ToolStripMenuItem("📊 Báo &Cáo")
            mnuBaoCao.DropDownItems.Add(New ToolStripMenuItem("📈 Báo Cáo Doanh Thu & Năng Suất", Nothing, Sub() btnBaoCao.PerformClick(), Keys.F5))
            msMainMenu.Items.Add(mnuBaoCao)

            mnuTroGiup = New ToolStripMenuItem("❓ &Trợ Giúp")
            mnuTroGiup.DropDownItems.Add(New ToolStripMenuItem("🌐 Xem Bản Đồ Demo System (HTML)", Nothing, AddressOf MoDemoSystemHub, Keys.F1))
            mnuTroGiup.DropDownItems.Add(New ToolStripMenuItem("ℹ️ Thông Tin Phiên Bản v0.2.12", Nothing, AddressOf HienThiThongTinPhienBan))
            msMainMenu.Items.Add(mnuTroGiup)
        End Sub

        Private Sub MenuDoiMatKhau_Click(sender As Object, e As EventArgs)
            btnDoiMatKhau.PerformClick()
        End Sub

        Private Sub MenuDangXuat_Click(sender As Object, e As EventArgs)
            btnDangXuat.PerformClick()
        End Sub

        Private Sub MoDemoSystemHub(sender As Object, e As EventArgs)
            Try
                Dim path As String = System.IO.Path.Combine(Application.StartupPath, "..\..\..\docs\demo_system.html")
                If System.IO.File.Exists(path) Then
                    Process.Start(New ProcessStartInfo(System.IO.Path.GetFullPath(path)) With {.UseShellExecute = True})
                Else
                    MessageBox.Show("Mở file docs/demo_system.html trong thư mục dự án.", "Demo System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show("Không thể mở trình duyệt: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        End Sub

        Private Sub HienThiThongTinPhienBan(sender As Object, e As EventArgs)
            MessageBox.Show(
                "HỆ THỐNG QUẢN LÝ QUÁN ĂN & CHUỖI NHÀ HÀNG" & vbCrLf &
                "Phiên bản: v0.2.12 (Master Data Launchpad & Top MenuStrip)" & vbCrLf &
                "Trạng thái: 100% Hoàn Tất 9 Màn Hình Danh Mục Nền Tảng!" & vbCrLf &
                "Công nghệ: Visual Basic .NET (WinForms .NET 10) + MSSQL Docker",
                "Thông Tin Hệ Thống",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

    End Class

End Namespace
