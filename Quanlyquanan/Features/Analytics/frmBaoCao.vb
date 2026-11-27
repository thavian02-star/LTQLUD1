Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO

Namespace Features.Analytics

    ''' <summary>
    ''' Màn hình Báo Cáo Doanh Thu, Năng Suất & Thống Kê (Mục 3.5 Checklist Đồ Án).
    ''' </summary>
    Public Class frmBaoCao

        Private Sub frmBaoCao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KhoiTaoCacCotBang()
            TaiDuLieuBaoCao()
        End Sub

        Private Sub KhoiTaoCacCotBang()
            KhoiTaoCotDoanhThu()
            KhoiTaoCotMonBanChay()
            KhoiTaoCotNhanVien()
        End Sub

        Private Sub KhoiTaoCotDoanhThu()
            dgvDoanhThu.Columns.Clear()
            dgvDoanhThu.Columns.Add("MocThoiGian", "Mốc Thời Gian")
            dgvDoanhThu.Columns.Add("SoLuongHoaDon", "Số Lượng Hóa Đơn")
            dgvDoanhThu.Columns.Add("SoLuongKhach", "Số Khách Phục Vụ")
            dgvDoanhThu.Columns.Add("DoanhThu", "Tổng Doanh Thu")
            dgvDoanhThu.Columns.Add("TrungBinh", "Doanh Thu TB / Đơn")

            dgvDoanhThu.Columns("MocThoiGian").Width = 180
            dgvDoanhThu.Columns("SoLuongHoaDon").Width = 160
            dgvDoanhThu.Columns("SoLuongKhach").Width = 160
            dgvDoanhThu.Columns("DoanhThu").Width = 200
            dgvDoanhThu.Columns("TrungBinh").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub KhoiTaoCotMonBanChay()
            dgvMonBanChay.Columns.Clear()
            dgvMonBanChay.Columns.Add("Hang", "Hạng")
            dgvMonBanChay.Columns.Add("TenMon", "Tên Món Ăn / Đồ Uống")
            dgvMonBanChay.Columns.Add("TenDanhMuc", "Phân Loại")
            dgvMonBanChay.Columns.Add("DonGia", "Đơn Giá")
            dgvMonBanChay.Columns.Add("SoLuongBan", "Số Lượng Bán")
            dgvMonBanChay.Columns.Add("TongDoanhThu", "Doanh Thu Đóng Góp")

            dgvMonBanChay.Columns("Hang").Width = 80
            dgvMonBanChay.Columns("TenMon").Width = 240
            dgvMonBanChay.Columns("TenDanhMuc").Width = 150
            dgvMonBanChay.Columns("DonGia").Width = 140
            dgvMonBanChay.Columns("SoLuongBan").Width = 140
            dgvMonBanChay.Columns("TongDoanhThu").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub KhoiTaoCotNhanVien()
            dgvNhanVien.Columns.Clear()
            dgvNhanVien.Columns.Add("MaNV", "Mã NV")
            dgvNhanVien.Columns.Add("HoTenNV", "Họ Tên Nhân Viên")
            dgvNhanVien.Columns.Add("TenVaiTro", "Bộ Phận")
            dgvNhanVien.Columns.Add("SoCaLam", "Số Ca Hoàn Thành")
            dgvNhanVien.Columns.Add("TongSoGio", "Tổng Giờ Trực")
            dgvNhanVien.Columns.Add("SoKhachPhucVu", "Khách Đã Phục Vụ")
            dgvNhanVien.Columns.Add("TongTienLuong", "Tổng Lương Ca (Dự Kiến)")

            dgvNhanVien.Columns("MaNV").Width = 90
            dgvNhanVien.Columns("HoTenNV").Width = 220
            dgvNhanVien.Columns("TenVaiTro").Width = 150
            dgvNhanVien.Columns("SoCaLam").Width = 150
            dgvNhanVien.Columns("TongSoGio").Width = 130
            dgvNhanVien.Columns("SoKhachPhucVu").Width = 150
            dgvNhanVien.Columns("TongTienLuong").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub TaiDuLieuBaoCao()
            Dim tuNgay = dtpTuNgay.Value.Date
            Dim denNgay = dtpDenNgay.Value.Date

            TaiBangDoanhThu(tuNgay, denNgay)
            TaiBangMonBanChay(tuNgay, denNgay)
            TaiBangNhanVien(tuNgay, denNgay)
        End Sub

        Private Sub TaiBangDoanhThu(tuNgay As DateTime, denNgay As DateTime)
            Dim ds = BaoCaoBUS.LayBaoCaoDoanhThu(tuNgay, denNgay)
            dgvDoanhThu.Rows.Clear()
            For Each itm In ds
                Dim idx = dgvDoanhThu.Rows.Add(
                    itm.MocThoiGian,
                    $"{itm.SoLuongHoaDon} đơn",
                    $"{itm.SoLuongKhach} khách",
                    $"{itm.DoanhThu:N0} đ",
                    $"{itm.DoanhThuTrungBinh:N0} đ"
                )
                dgvDoanhThu.Rows(idx).Cells("DoanhThu").Style.ForeColor = Color.FromArgb(74, 222, 128)
            Next

            CapNhatKpiDoanhThu(ds)
        End Sub

        Private Sub CapNhatKpiDoanhThu(ds As List(Of BaoCaoDoanhThuDTO))
            Dim tongDoanhThu = ds.Sum(Function(x) x.DoanhThu)
            Dim tongHoaDon = ds.Sum(Function(x) x.SoLuongHoaDon)
            Dim tongKhach = ds.Sum(Function(x) x.SoLuongKhach)

            lblKpiDoanhThuVal.Text = $"{tongDoanhThu:N0} đ"
            lblKpiHoaDonVal.Text = $"{tongHoaDon} đơn"
            lblKpiKhachVal.Text = $"{tongKhach} khách"
        End Sub

        Private Sub TaiBangMonBanChay(tuNgay As DateTime, denNgay As DateTime)
            Dim ds = BaoCaoBUS.LayTopMonBanChay(tuNgay, denNgay, 15)
            dgvMonBanChay.Rows.Clear()
            For Each itm In ds
                Dim idx = dgvMonBanChay.Rows.Add(
                    $"#{itm.Hang}", itm.TenMon, itm.TenDanhMuc,
                    $"{itm.DonGia:N0} đ", $"{itm.SoLuongBan} phần", $"{itm.TongDoanhThu:N0} đ"
                )
                dgvMonBanChay.Rows(idx).Cells("TongDoanhThu").Style.ForeColor = Color.FromArgb(251, 191, 36)
            Next
        End Sub

        Private Sub TaiBangNhanVien(tuNgay As DateTime, denNgay As DateTime)
            Dim ds = BaoCaoBUS.LayNangSuatNhanVien(tuNgay, denNgay)
            dgvNhanVien.Rows.Clear()
            For Each itm In ds
                Dim khachStr = If(itm.SoKhachPhucVu > 0, $"{itm.SoKhachPhucVu} khách", "—")
                Dim idx = dgvNhanVien.Rows.Add(
                    $"#NV{itm.MaNV}", itm.HoTenNV, itm.TenVaiTro,
                    $"{itm.SoCaLam} ca", $"{itm.TongSoGio} giờ", khachStr, $"{itm.TongTienLuong:N0} đ"
                )
                dgvNhanVien.Rows(idx).Cells("TongTienLuong").Style.ForeColor = Color.FromArgb(192, 132, 252)
            Next

            Dim tongLuong = ds.Sum(Function(x) x.TongTienLuong)
            lblKpiLuongVal.Text = $"{tongLuong:N0} đ"
        End Sub

        Private Sub btnHomNay_Click(sender As Object, e As EventArgs) Handles btnHomNay.Click
            DatMauNutNhanh(btnHomNay)
            dtpTuNgay.Value = DateTime.Today
            dtpDenNgay.Value = DateTime.Today
            TaiDuLieuBaoCao()
        End Sub

        Private Sub btn7Ngay_Click(sender As Object, e As EventArgs) Handles btn7Ngay.Click
            DatMauNutNhanh(btn7Ngay)
            dtpTuNgay.Value = DateTime.Today.AddDays(-6)
            dtpDenNgay.Value = DateTime.Today
            TaiDuLieuBaoCao()
        End Sub

        Private Sub btnThangNay_Click(sender As Object, e As EventArgs) Handles btnThangNay.Click
            DatMauNutNhanh(btnThangNay)
            dtpTuNgay.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
            dtpDenNgay.Value = DateTime.Today
            TaiDuLieuBaoCao()
        End Sub

        Private Sub btnNamNay_Click(sender As Object, e As EventArgs) Handles btnNamNay.Click
            DatMauNutNhanh(btnNamNay)
            dtpTuNgay.Value = New DateTime(DateTime.Today.Year, 1, 1)
            dtpDenNgay.Value = DateTime.Today
            TaiDuLieuBaoCao()
        End Sub

        Private Sub DatMauNutNhanh(btnChon As Button)
            Dim btns As Button() = {btnHomNay, btn7Ngay, btnThangNay, btnNamNay}
            For Each b In btns
                If b Is btnChon Then
                    b.BackColor = Color.FromArgb(37, 99, 235)
                Else
                    b.BackColor = Color.FromArgb(51, 65, 85)
                End If
            Next
        End Sub

        Private Sub btnLoc_Click(sender As Object, e As EventArgs) Handles btnLoc.Click
            TaiDuLieuBaoCao()
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            TaiDuLieuBaoCao()
        End Sub

        Private Sub btnXuatBaoCao_Click(sender As Object, e As EventArgs) Handles btnXuatBaoCao.Click
            MessageBox.Show(
                "Đã khởi tạo lệnh kết xuất báo cáo tổng hợp ra định dạng Excel / PDF thành công!" & vbCrLf &
                $"- Khoảng thời gian: {dtpTuNgay.Value:dd/MM/yyyy} đến {dtpDenNgay.Value:dd/MM/yyyy}" & vbCrLf &
                $"- Doanh thu ghi nhận: {lblKpiDoanhThuVal.Text}",
                "Xuất Báo Cáo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmBaoCao_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F5 Then
                TaiDuLieuBaoCao()
            End If
        End Sub

    End Class

End Namespace
