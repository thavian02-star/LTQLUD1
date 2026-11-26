Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Features.Main

    Partial Class frmMain

        ''' <summary>
        ''' Nâng cấp và cấu hình Lưới 9 Card Master Data Launchpad trực quan trên Dashboard
        ''' </summary>
        Private Sub KhoiTaoMasterDataLaunchpad()
            lblQuickHeader.Text = "🏆 TRUNG TÂM 9 DANH MỤC NỀN TẢNG (MASTER DATA - 100% HOÀN THÀNH)"
            lblQuickHeader.Font = New Font("Segoe UI", 10.5F, FontStyle.Bold)
            lblQuickHeader.ForeColor = Color.FromArgb(26, 82, 118)

            tlpQuickButtons.SuspendLayout()
            tlpQuickButtons.Controls.Clear()
            tlpQuickButtons.ColumnCount = 3
            tlpQuickButtons.RowCount = 3

            ThietLapTyLeLuoiLaunchpad()
            Nap9TheCardVaoLuoi()
            tlpQuickButtons.ResumeLayout(True)
        End Sub

        Private Sub ThietLapTyLeLuoiLaunchpad()
            tlpQuickButtons.ColumnStyles.Clear()
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.33F))
            tlpQuickButtons.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.34F))

            tlpQuickButtons.RowStyles.Clear()
            tlpQuickButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33F))
            tlpQuickButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33F))
            tlpQuickButtons.RowStyles.Add(New RowStyle(SizeType.Percent, 33.34F))
        End Sub

        Private Sub Nap9TheCardVaoLuoi()
            Dim cardData As (String, String, String, EventHandler, Integer, Integer)() = {
                ("👥 1. Nhân Viên & Tài Khoản", "15 Nhân sự • 4 Vai trò", "CQ_QUAN_LY_NHAN_SU", Sub() MoQuanLyNhanVien(), 0, 0),
                ("⏰ 2. Ca Làm Việc & Lương", "4 Ca làm • Mức lương ca", "CQ_XEP_LICH_LAM_VIEC", Sub() MoQuanLyCaLamViec(), 1, 0),
                ("🍲 3. Danh Mục Món Ăn", "100+ Món • Giá niêm yết", "CQ_QUAN_LY_THUC_DON", Sub() MoQuanLyMonAn(), 2, 0),
                ("📁 4. Phân Loại Nhóm Món", "6 Nhóm thực đơn ẩm thực", "CQ_QUAN_LY_THUC_DON", Sub() MoQuanLyDanhMuc(), 0, 1),
                ("🏢 5. Khu Vực Bàn Ăn", "4 Khu vực sảnh/phòng VIP", "CQ_QUAN_LY_BAN", Sub() MoQuanLyKhuVuc(), 1, 1),
                ("🪑 6. Sơ Đồ Bàn Ăn", "12 Bàn ăn • 72 Chỗ ngồi", "CQ_QUAN_LY_BAN", Sub() MoQuanLyBan(), 2, 1),
                ("📋 7. Bảng Thực Đơn Master", "5 Menu Alacarte/Buffet/Set", "CQ_QUAN_LY_THUC_DON", Sub() MoQuanLyMenu(), 0, 2),
                ("🏬 8. Chuỗi Cơ Sở Chi Nhánh", "4 Chi nhánh toàn chuỗi", "CQ_QUAN_LY_CHI_NHANH", Sub() MoQuanLyChiNhanh(), 1, 2),
                ("📑 9. Phân Bổ Menu Chi Nhánh", "9 Liên kết thực đơn cơ sở", "CQ_QUAN_LY_THUC_DON", Sub() MoQuanLyMenuChiNhanh(), 2, 2)
            }

            For Each item In cardData
                Dim btnCard As Button = TaoButtonCard(item.Item1, item.Item2, item.Item3, item.Item4)
                tlpQuickButtons.Controls.Add(btnCard, item.Item5, item.Item6)
            Next
        End Sub

        Private Function TaoButtonCard(title As String, subtitle As String, tagQuyen As String, onClick As EventHandler) As Button
            Dim btn As New Button()
            btn.Text = title & vbCrLf & "• " & subtitle & " •"
            btn.Dock = DockStyle.Fill
            btn.Margin = New Padding(4)
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225)
            btn.FlatAppearance.BorderSize = 1
            btn.BackColor = Color.FromArgb(248, 250, 252)
            btn.ForeColor = Color.FromArgb(30, 41, 59)
            btn.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            btn.Cursor = Cursors.Hand
            btn.TextAlign = ContentAlignment.MiddleCenter
            btn.Tag = tagQuyen

            AddHandler btn.Click, onClick
            ThemHieuUngHover(btn)
            Return btn
        End Function

        Private Sub ThemHieuUngHover(btn As Button)
            AddHandler btn.MouseEnter, Sub()
                                           btn.BackColor = Color.FromArgb(224, 242, 254)
                                           btn.FlatAppearance.BorderColor = Color.FromArgb(56, 189, 248)
                                           btn.ForeColor = Color.FromArgb(3, 105, 161)
                                       End Sub
            AddHandler btn.MouseLeave, Sub()
                                           btn.BackColor = Color.FromArgb(248, 250, 252)
                                           btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225)
                                           btn.ForeColor = Color.FromArgb(30, 41, 59)
                                       End Sub
        End Sub

    End Class

End Namespace
