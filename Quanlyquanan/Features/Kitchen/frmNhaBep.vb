Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO

Namespace Features.Kitchen

    ''' <summary>
    ''' Màn hình Điều Phối Chế Biến Nhà Bếp KDS (frmNhaBep).
    ''' </summary>
    Public Class frmNhaBep

        Private _currentFilter As String = "all"
        Private _danhSachCho As List(Of ChiTietHoaDonDTO)

        Private Sub frmNhaBep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KetNoiSuKien()
            TaiDanhSachCheBien()
            CapNhatDongHo()
        End Sub

        Private Sub KetNoiSuKien()
            AddHandler btnDong.Click, Sub(s, ev) Me.Close()
            AddHandler btnFilterAll.Click, Sub(s, ev) ChonFilter("all", btnFilterAll)
            AddHandler btnFilterHot.Click, Sub(s, ev) ChonFilter("hot", btnFilterHot)
            AddHandler btnFilterCold.Click, Sub(s, ev) ChonFilter("cold", btnFilterCold)
            AddHandler btnFilterBar.Click, Sub(s, ev) ChonFilter("bar", btnFilterBar)
            AddHandler btnRefresh.Click, Sub(s, ev) TaiDanhSachCheBien()
            AddHandler tmrAutoRefresh.Tick, Sub(s, ev) TaiDanhSachCheBien()
            AddHandler tmrClock.Tick, Sub(s, ev) CapNhatDongHo()
        End Sub

        Private Sub ChonFilter(filter As String, btnActive As Button)
            _currentFilter = filter
            Dim btns = {btnFilterAll, btnFilterHot, btnFilterCold, btnFilterBar}
            For Each btn In btns
                btn.BackColor = Color.Transparent
                btn.ForeColor = Color.FromArgb(203, 213, 225)
                btn.Font = New Font("Segoe UI", 8.5F, FontStyle.Regular)
            Next
            btnActive.BackColor = Color.FromArgb(234, 88, 12)
            btnActive.ForeColor = Color.White
            btnActive.Font = New Font("Segoe UI", 8.5F, FontStyle.Bold)
            TaiDanhSachCheBien()
        End Sub

        Private Sub CapNhatDongHo()
            lblClock.Text = DateTime.Now.ToString("HH:mm:ss")
        End Sub

        Public Sub TaiDanhSachCheBien()
            _danhSachCho = NhaBepBUS.LayHangDoiCheBien(_currentFilter)
            CapNhatKpis()
            VeLaiKdsBoard()
        End Sub

        Private Sub CapNhatKpis()
            Dim tongCho = NhaBepBUS.DemMonDangCho()
            Dim choTre = NhaBepBUS.DemMonChoTre()
            lblKpiPending.Text = $"🍳 Chờ nấu: {tongCho} món"
            lblKpiUrgent.Text = $"⚠️ Quá 15p: {choTre} món"
        End Sub

        Private Sub VeLaiKdsBoard()
            flpTickets.SuspendLayout()
            flpTickets.Controls.Clear()

            For Each item In _danhSachCho
                Dim ticket = TaoTicketCard(item)
                flpTickets.Controls.Add(ticket)
            Next

            flpTickets.ResumeLayout()
        End Sub

        Private Function TaoTicketCard(item As ChiTietHoaDonDTO) As Panel
            Dim pnl As New Panel() With {
                .Size = New Size(280, 210),
                .BackColor = Color.FromArgb(30, 41, 59),
                .Margin = New Padding(10),
                .BorderStyle = If(item.SoPhutCho >= 15, BorderStyle.Fixed3D, BorderStyle.FixedSingle),
                .Tag = item
            }

            Dim pnlTop = TaoTicketTop(item)
            Dim pnlBody = TaoTicketBody(item)
            Dim pnlFoot = TaoTicketFoot(item)

            pnl.Controls.AddRange({pnlFoot, pnlBody, pnlTop})
            Return pnl
        End Function

        Private Function TaoTicketTop(item As ChiTietHoaDonDTO) As Panel
            Dim pnl As New Panel() With {
                .Dock = DockStyle.Top, .Height = 36,
                .BackColor = If(item.SoPhutCho >= 15, Color.FromArgb(127, 29, 29), Color.FromArgb(15, 23, 42)),
                .Padding = New Padding(8, 4, 8, 4)
            }
            Dim lblBan As New Label() With {
                .Text = $"🪑 {item.TenBan}", .Font = New Font("Segoe UI", 10.0F, FontStyle.Bold),
                .ForeColor = Color.White, .Dock = DockStyle.Left, .AutoSize = True
            }
            Dim lblTimer As New Label() With {
                .Text = $"⏱️ {item.SoPhutCho}p trước", .Font = New Font("Consolas", 9.5F, FontStyle.Bold),
                .ForeColor = If(item.SoPhutCho >= 15, Color.FromArgb(248, 113, 113), Color.FromArgb(251, 191, 36)),
                .Dock = DockStyle.Right, .AutoSize = True
            }
            pnl.Controls.AddRange({lblBan, lblTimer})
            Return pnl
        End Function

        Private Function TaoTicketBody(item As ChiTietHoaDonDTO) As Panel
            Dim pnl As New Panel() With {.Dock = DockStyle.Fill, .Padding = New Padding(10)}

            Dim lblCate As New Label() With {
                .Text = item.TenDanhMuc, .Font = New Font("Segoe UI", 8.0F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(148, 163, 184), .Dock = DockStyle.Top, .Height = 18
            }
            Dim lblName As New Label() With {
                .Text = $"{item.TenMonAn}  x{item.CTHD_SoLuong}", .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
                .ForeColor = Color.White, .Dock = DockStyle.Top, .Height = 48
            }
            pnl.Controls.AddRange({lblName, lblCate})

            If Not String.IsNullOrEmpty(item.CTHD_GhiChu) Then
                Dim lblNote As New Label() With {
                    .Text = $"📝 {item.CTHD_GhiChu}", .Font = New Font("Segoe UI", 8.5F, FontStyle.Italic),
                    .ForeColor = Color.FromArgb(254, 240, 138), .BackColor = Color.FromArgb(45, 55, 72),
                    .Dock = DockStyle.Bottom, .Height = 32, .Padding = New Padding(4)
                }
                pnl.Controls.Add(lblNote)
            End If
            Return pnl
        End Function

        Private Function TaoTicketFoot(item As ChiTietHoaDonDTO) As Panel
            Dim pnl As New Panel() With {.Dock = DockStyle.Bottom, .Height = 44, .Padding = New Padding(6)}
            Dim btnDone As New Button() With {
                .Text = "✓ BÁO ĐÃ NẤU XONG", .Dock = DockStyle.Fill,
                .BackColor = Color.FromArgb(16, 185, 129), .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat, .Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            }
            AddHandler btnDone.Click, Sub(s, ev) XuLyHoanThanhMon(item)
            pnl.Controls.Add(btnDone)
            Return pnl
        End Function

        Private Sub XuLyHoanThanhMon(item As ChiTietHoaDonDTO)
            Dim msg = $"Xác nhận đã nấu xong món [{item.TenMonAn} x{item.CTHD_SoLuong}] cho [{item.TenBan}]?"
            If MessageBox.Show(msg, "Xác Nhận Nấu Xong", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                NhaBepBUS.HoanThanhMon(item.CTHD_Ma)
                TaiDanhSachCheBien()
                MessageBox.Show($"Đã thông báo món [{item.TenMonAn}] lên quầy phục vụ thành công!", "Bếp Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

    End Class

End Namespace
