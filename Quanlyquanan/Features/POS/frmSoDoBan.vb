Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.POS

    ''' <summary>
    ''' Màn hình Điểm Bán Hàng & Sơ Đồ Bàn POS (frmSoDoBan).
    ''' </summary>
    Public Class frmSoDoBan

        Private _danhSachBan As List(Of BanDTO)
        Private _selectedBan As BanDTO
        Private _currentHoaDon As HoaDonDTO
        Private _currentKhuVuc As String = "all"

        Private Sub frmSoDoBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KetNoiSuKien()
            TaiDanhSachBan()
        End Sub

        Private Sub KetNoiSuKien()
            AddHandler btnDong.Click, Sub(s, ev) Me.Close()
            AddHandler btnAreaAll.Click, Sub(s, ev) ChonKhuVuc("all", btnAreaAll)
            AddHandler btnAreaTang1.Click, Sub(s, ev) ChonKhuVuc("Sảnh Tầng 1", btnAreaTang1)
            AddHandler btnAreaTang2.Click, Sub(s, ev) ChonKhuVuc("Sân Vườn Tầng 2", btnAreaTang2)
            AddHandler btnAreaVip.Click, Sub(s, ev) ChonKhuVuc("Phòng VIP Máy Lạnh", btnAreaVip)

            AddHandler btnMoBan.Click, AddressOf XuLyMoBan
            AddHandler btnGoiMon.Click, AddressOf XuLyGoiMon
            AddHandler btnHuyMon.Click, AddressOf XuLyHuyMon
            AddHandler btnThanhToan.Click, AddressOf XuLyThanhToan
            AddHandler btnChuyenBan.Click, AddressOf XuLyChuyenBan
        End Sub

        Private Sub ChonKhuVuc(kv As String, btnActive As Button)
            _currentKhuVuc = kv
            Dim sidebarButtons = {btnAreaAll, btnAreaTang1, btnAreaTang2, btnAreaVip}
            For Each btn In sidebarButtons
                btn.BackColor = Color.White
                btn.ForeColor = Color.FromArgb(30, 41, 59)
                btn.Font = New Font("Segoe UI", 9.0F, FontStyle.Regular)
            Next
            btnActive.BackColor = Color.FromArgb(254, 243, 199)
            btnActive.ForeColor = Color.FromArgb(180, 83, 9)
            btnActive.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
            VeLaiSoDoBan()
        End Sub

        Public Sub TaiDanhSachBan()
            Try
                _danhSachBan = BanBUS.LayDanhSach()
            Catch ex As Exception
                _danhSachBan = New List(Of BanDTO)()
            End Try

            If _danhSachBan Is Nothing OrElse _danhSachBan.Count = 0 Then
                TaoDanhSachBanDemo()
            End If
            VeLaiSoDoBan()
        End Sub

        Private Sub TaoDanhSachBanDemo()
            _danhSachBan = New List(Of BanDTO) From {
                New BanDTO With {.MaBan = 1, .SoThuTu = 1, .TenBan = "Bàn 01", .KhuVuc = "Sảnh Tầng 1", .SoNguoiToiDa = 4, .TrangThai = 0},
                New BanDTO With {.MaBan = 2, .SoThuTu = 2, .TenBan = "Bàn 02", .KhuVuc = "Sảnh Tầng 1", .SoNguoiToiDa = 4, .TrangThai = 1},
                New BanDTO With {.MaBan = 3, .SoThuTu = 3, .TenBan = "Bàn 03", .KhuVuc = "Sảnh Tầng 1", .SoNguoiToiDa = 6, .TrangThai = 0},
                New BanDTO With {.MaBan = 4, .SoThuTu = 4, .TenBan = "Bàn 04", .KhuVuc = "Sảnh Tầng 1", .SoNguoiToiDa = 4, .TrangThai = 1},
                New BanDTO With {.MaBan = 5, .SoThuTu = 5, .TenBan = "Bàn 05", .KhuVuc = "Sân Vườn Tầng 2", .SoNguoiToiDa = 6, .TrangThai = 0},
                New BanDTO With {.MaBan = 6, .SoThuTu = 6, .TenBan = "Bàn 06", .KhuVuc = "Sân Vườn Tầng 2", .SoNguoiToiDa = 8, .TrangThai = 0},
                New BanDTO With {.MaBan = 7, .SoThuTu = 7, .TenBan = "Phòng VIP 1", .KhuVuc = "Phòng VIP Máy Lạnh", .SoNguoiToiDa = 10, .TrangThai = 2},
                New BanDTO With {.MaBan = 8, .SoThuTu = 8, .TenBan = "Phòng VIP 2", .KhuVuc = "Phòng VIP Máy Lạnh", .SoNguoiToiDa = 12, .TrangThai = 0}
            }
        End Sub

        Private Sub VeLaiSoDoBan()
            flpTables.SuspendLayout()
            flpTables.Controls.Clear()

            For Each ban In _danhSachBan
                If _currentKhuVuc = "all" OrElse ban.KhuVuc.Contains(_currentKhuVuc) OrElse _currentKhuVuc.Contains(ban.KhuVuc) Then
                    Dim pnlCard As Panel = TaoCardBan(ban)
                    flpTables.Controls.Add(pnlCard)
                End If
            Next

            flpTables.ResumeLayout()
        End Sub

        Private Function TaoCardBan(ban As BanDTO) As Panel
            Dim pnl As New Panel() With {
                .Size = New Size(150, 110),
                .BackColor = Color.White,
                .Margin = New Padding(8),
                .Cursor = Cursors.Hand,
                .Tag = ban
            }
            Dim isSelected As Boolean = (_selectedBan IsNot Nothing AndAlso _selectedBan.MaBan = ban.MaBan)
            pnl.BorderStyle = If(isSelected, BorderStyle.Fixed3D, BorderStyle.FixedSingle)

            Dim pnlColorStrip As New Panel() With {.Dock = DockStyle.Top, .Height = 6}
            pnlColorStrip.BackColor = LayMauTrangThai(ban.TrangThai)

            Dim lblName As New Label() With {
                .Text = ban.TenBan,
                .Font = New Font("Segoe UI", 10.5F, FontStyle.Bold),
                .ForeColor = Color.FromArgb(15, 23, 42),
                .Dock = DockStyle.Top, .Height = 26, .TextAlign = ContentAlignment.MiddleCenter
            }
            Dim lblInfo As New Label() With {
                .Text = $"{ban.SoNguoiToiDa} Chỗ • {LayTenTrangThai(ban.TrangThai)}",
                .Font = New Font("Segoe UI", 8.0F),
                .ForeColor = Color.FromArgb(100, 116, 139),
                .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleCenter
            }

            pnl.Controls.AddRange({lblInfo, lblName, pnlColorStrip})
            AddHandler pnl.Click, Sub(s, ev) ChonBan(ban)
            AddHandler lblName.Click, Sub(s, ev) ChonBan(ban)
            AddHandler lblInfo.Click, Sub(s, ev) ChonBan(ban)
            Return pnl
        End Function

        Private Function LayMauTrangThai(trangThai As Integer) As Color
            Select Case trangThai
                Case 1 : Return Color.FromArgb(239, 68, 68) ' Đang phục vụ
                Case 2 : Return Color.FromArgb(245, 158, 11) ' Đã đặt trước
                Case Else : Return Color.FromArgb(34, 197, 94) ' Bàn trống
            End Select
        End Function

        Private Function LayTenTrangThai(trangThai As Integer) As String
            Select Case trangThai
                Case 1 : Return "Có Khách"
                Case 2 : Return "Đã Đặt"
                Case Else : Return "Bàn Trống"
            End Select
        End Function

        Private Sub ChonBan(ban As BanDTO)
            _selectedBan = ban
            lblBillTableName.Text = $"{ban.TenBan} ({ban.KhuVuc})"

            If ban.TrangThai = 1 Then
                _currentHoaDon = HoaDonBUS.LayHoaDonHienTai(ban.MaBan)
                If _currentHoaDon IsNot Nothing Then
                    lblBillTableInfo.Text = $"Hóa đơn: #HD{_currentHoaDon.HD_Ma} • Khách: {_currentHoaDon.HD_SoLuongKhach} người"
                Else
                    lblBillTableInfo.Text = "Hóa đơn: Đang phục vụ • Khách: 2 người"
                End If
            Else
                _currentHoaDon = Nothing
                lblBillTableInfo.Text = $"Bàn trống • Sức chứa tối đa: {ban.SoNguoiToiDa} người"
            End If

            CapNhatTrangThaiNut(ban.TrangThai)
            TaiChiTietHoaDon()
            VeLaiSoDoBan()
        End Sub

        Private Sub CapNhatTrangThaiNut(trangThai As Integer)
            btnMoBan.Enabled = (trangThai = 0)
            btnGoiMon.Enabled = (trangThai = 1)
            btnHuyMon.Enabled = (trangThai = 1)
            btnChuyenBan.Enabled = (trangThai = 1)
            btnThanhToan.Enabled = (trangThai = 1)
        End Sub

        Private Sub TaiChiTietHoaDon()
            dgvOrderItems.DataSource = Nothing
            If _currentHoaDon IsNot Nothing Then
                Dim dsMon = HoaDonBUS.LayDanhSachMon(_currentHoaDon.HD_Ma)
                dgvOrderItems.AutoGenerateColumns = False
                dgvOrderItems.DataSource = dsMon
                Dim tongTien = dsMon.Sum(Function(x) x.ThanhTien)
                lblTongTienVal.Text = $"{tongTien:N0} đ"
            Else
                lblTongTienVal.Text = "0 đ"
            End If
        End Sub

        Private Sub XuLyMoBan(sender As Object, e As EventArgs)
            If _selectedBan Is Nothing Then Return
            Dim maNV = If(Session.MaNhanVien > 0, Session.MaNhanVien, 1)
            _currentHoaDon = HoaDonBUS.MoBan(_selectedBan.MaBan, maNV, 2)
            _selectedBan.TrangThai = 1
            ChonBan(_selectedBan)
            MessageBox.Show($"Đã mở bàn {_selectedBan.TenBan} thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub XuLyGoiMon(sender As Object, e As EventArgs)
            If _currentHoaDon Is Nothing Then Return
            ' Demo gọi món nhanh vào hóa đơn
            Dim danhSachMonMau = {
                Tuple.Create(1, "Phở Bò Tái Nạm", 65000D),
                Tuple.Create(2, "Cơm Tấm Sườn Bì", 55000D),
                Tuple.Create(4, "Trà Đào Cam Sả", 35000D)
            }
            Dim rndIndex = New Random().Next(0, danhSachMonMau.Length)
            Dim mon = danhSachMonMau(rndIndex)

            HoaDonBUS.ThemMon(_currentHoaDon.HD_Ma, mon.Item1, mon.Item2, 1, mon.Item3, "Gọi tại bàn")
            TaiChiTietHoaDon()
        End Sub

        Private Sub XuLyHuyMon(sender As Object, e As EventArgs)
            If dgvOrderItems.CurrentRow Is Nothing Then Return
            Dim item = TryCast(dgvOrderItems.CurrentRow.DataBoundItem, ChiTietHoaDonDTO)
            If item IsNot Nothing Then
                If MessageBox.Show($"Xác nhận hủy món [{item.TenMonAn}]?", "Xác Nhận Hủy Món", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    HoaDonBUS.HuyMon(_currentHoaDon.HD_Ma, item.CTHD_Ma)
                    TaiChiTietHoaDon()
                End If
            End If
        End Sub

        Private Sub XuLyThanhToan(sender As Object, e As EventArgs)
            If _selectedBan Is Nothing OrElse _currentHoaDon Is Nothing Then Return
            Dim tongTien = Convert.ToDecimal(lblTongTienVal.Text.Replace(" đ", "").Replace(",", "").Trim())
            If MessageBox.Show($"Xác nhận thanh toán bàn [{_selectedBan.TenBan}] với tổng tiền: {lblTongTienVal.Text}?", "Thanh Toán & Đóng Bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                HoaDonBUS.ThanhToan(_currentHoaDon.HD_Ma, _selectedBan.MaBan, "Tiền mặt", tongTien)
                _selectedBan.TrangThai = 0
                ChonBan(_selectedBan)
                MessageBox.Show("Thanh toán thành công! Bàn đã được đưa về trạng thái trống.", "Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub XuLyChuyenBan(sender As Object, e As EventArgs)
            If _selectedBan Is Nothing OrElse _currentHoaDon Is Nothing Then Return
            Dim banTrong = _danhSachBan.FirstOrDefault(Function(b) b.TrangThai = 0)
            If banTrong Is Nothing Then
                MessageBox.Show("Không còn bàn nào trống để chuyển!", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If MessageBox.Show($"Xác nhận chuyển từ [{_selectedBan.TenBan}] sang [{banTrong.TenBan}]?", "Chuyển Bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                HoaDonBUS.ChuyenBan(_currentHoaDon.HD_Ma, _selectedBan.MaBan, banTrong.MaBan)
                _selectedBan.TrangThai = 0
                banTrong.TrangThai = 1
                ChonBan(banTrong)
                MessageBox.Show($"Đã chuyển sang {banTrong.TenBan} thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

    End Class

End Namespace
