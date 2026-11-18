Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Menu

    Public Class frmMenu

        Private _danhSachMenu As New List(Of MenuDTO)()
        Private _danhSachMonKho As New List(Of MonAnDTO)()
        Private _danhSachMonTrongMenu As New List(Of MenuMonAnDTO)()
        Private _maMenuDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                _dangNapDuLieu = True

                KhoiTaoCacComboBox()
                ApDungPhanQuyen()
                NapDanhSachMonKho()
                TaiDuLieuMenu()

                _dangNapDuLieu = False

                If dgvMenu.Rows.Count > 0 Then
                    dgvMenu.Rows(0).Selected = True
                    ChonDongMenu(0)
                Else
                    ChuyenCheDoThemMoi()
                End If
            Catch ex As Exception
                HienThiThongBao("Lỗi khởi tạo màn hình: " & ex.Message, True)
            Finally
                _dangNapDuLieu = False
            End Try
        End Sub

        ' ==============================================================
        ' 1. KHỞI TẠO COMBOBOX & PHÂN QUYỀN RBAC
        ' ==============================================================
        Private Sub KhoiTaoCacComboBox()
            ' Cbo Loại Menu biểu mẫu
            cboLoaiMenu.Items.Clear()
            cboLoaiMenu.Items.AddRange(New Object() {"Alacarte", "Buffet", "SetMenu", "SuKien"})
            cboLoaiMenu.SelectedIndex = 0

            ' Cbo Trạng thái biểu mẫu
            cboTrangThai.Items.Clear()
            cboTrangThai.Items.AddRange(New Object() {"Đang áp dụng", "Tạm ngưng", "Dự thảo"})
            cboTrangThai.SelectedIndex = 0

            ' Cbo Lọc Loại Menu
            cboLocLoaiMenu.Items.Clear()
            cboLocLoaiMenu.Items.AddRange(New Object() {"Tất cả loại thực đơn", "Alacarte", "Buffet", "SetMenu", "SuKien"})
            cboLocLoaiMenu.SelectedIndex = 0

            ' Cbo Lọc Trạng thái
            cboLocTrangThai.Items.Clear()
            cboLocTrangThai.Items.AddRange(New Object() {"Tất cả trạng thái", "Đang áp dụng", "Tạm ngưng", "Dự thảo"})
            cboLocTrangThai.SelectedIndex = 0
        End Sub

        Private Function CoQuyenQuanLy() As Boolean
            ' Nếu chưa đăng nhập (môi trường dev/test) cho phép toàn quyền
            If Session.MaTaiKhoan <= 0 Then
                Return True
            End If
            ' Quyền Quản lý thực đơn hoặc vai trò Chủ quán (1) / Quản lý (2)
            Return Session.CoQuyen("CQ_QUAN_LY_THUC_DON") OrElse Session.MaVaiTro = 1 OrElse Session.MaVaiTro = 2
        End Function

        Private Sub ApDungPhanQuyen()
            Dim coQuyen As Boolean = CoQuyenQuanLy()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen AndAlso (_maMenuDangChon > 0)
            btnXoa.Enabled = coQuyen AndAlso (_maMenuDangChon > 0)
            btnGanMon.Enabled = coQuyen AndAlso (_maMenuDangChon > 0)
            btnGoMon.Enabled = coQuyen

            txtTenMenu.ReadOnly = Not coQuyen
            cboLoaiMenu.Enabled = coQuyen
            cboTrangThai.Enabled = coQuyen
            txtMoTa.ReadOnly = Not coQuyen
            grpGanMon.Enabled = coQuyen

            If Not coQuyen Then
                HienThiThongBao("Chế độ chỉ xem: Bạn không có quyền chỉnh sửa Bảng thực đơn.", True)
            End If
        End Sub

        ' ==============================================================
        ' 2. NẠP DỮ LIỆU TỪ BUS / DAO
        ' ==============================================================
        Private Sub NapDanhSachMonKho()
            Try
                _danhSachMonKho = MenuBUS.LayDanhSachMonAnKho()
                cboChonMon.DataSource = Nothing

                If _danhSachMonKho.Count > 0 Then
                    ' Chuẩn bị danh sách hiển thị kèm tên danh mục
                    Dim items As New List(Of Object)()
                    For Each m In _danhSachMonKho
                        items.Add(New With {
                            .MaMonAn = m.MaMonAn,
                            .TenHienThi = $"{m.TenMonAn} ({m.TenDanhMuc}) - {m.DonGia:N0} đ",
                            .DonGia = m.DonGia
                        })
                    Next
                    cboChonMon.DisplayMember = "TenHienThi"
                    cboChonMon.ValueMember = "MaMonAn"
                    cboChonMon.DataSource = items
                    cboChonMon.SelectedIndex = 0
                End If
            Catch ex As Exception
                HienThiThongBao("Không thể tải kho món ăn: " & ex.Message, True)
            End Try
        End Sub

        Private Sub TaiDuLieuMenu()
            Try
                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                Dim loaiLoc As String = If(cboLocLoaiMenu.SelectedIndex > 0, cboLocLoaiMenu.SelectedItem.ToString(), "")
                Dim ttLoc As String = If(cboLocTrangThai.SelectedIndex > 0, cboLocTrangThai.SelectedItem.ToString(), "")

                _danhSachMenu = MenuBUS.LayDanhSach(tuKhoa, loaiLoc, ttLoc)
                dgvMenu.AutoGenerateColumns = False
                dgvMenu.DataSource = Nothing
                dgvMenu.DataSource = _danhSachMenu

                CapNhatThongKeKPI()
            Catch ex As Exception
                HienThiThongBao("Lỗi nạp danh sách menu: " & ex.Message, True)
            End Try
        End Sub

        Private Sub CapNhatThongKeKPI()
            Try
                Dim kpi = MenuBUS.LayThongKeKPI()
                lblKpiTongMenuVal.Text = $"{kpi.TongMenu} bảng menu"
                lblKpiDangApDungVal.Text = $"{kpi.DangApDung} bảng menu"
                lblKpiTamNgungVal.Text = $"{kpi.TamNgung} bảng menu"
                lblKpiTongMonGanVal.Text = $"{kpi.TongMonGan} lượt món"
            Catch ex As Exception
            End Try
        End Sub

        Private Sub TaiDanhSachMonTrongMenu(maMenu As Integer)
            Try
                If maMenu <= 0 Then
                    _danhSachMonTrongMenu.Clear()
                    dgvMenuMonAn.DataSource = Nothing
                    lblChiTietMenuInfo.Text = "Món trong thực đơn: (Chưa chọn bảng menu)"
                    Return
                End If

                _danhSachMonTrongMenu = MenuBUS.LayDanhSachMonTheoMenu(maMenu)
                dgvMenuMonAn.AutoGenerateColumns = False
                dgvMenuMonAn.DataSource = Nothing
                dgvMenuMonAn.DataSource = _danhSachMonTrongMenu

                Dim menuHienTai = _danhSachMenu.Find(Function(m) m.MaMenu = maMenu)
                Dim tenMenu As String = If(menuHienTai IsNot Nothing, menuHienTai.TenMenu, $"#{maMenu}")
                lblChiTietMenuInfo.Text = $"Món trong thực đơn: {tenMenu} ({_danhSachMonTrongMenu.Count} món)"
            Catch ex As Exception
                HienThiThongBao("Lỗi tải món theo menu: " & ex.Message, True)
            End Try
        End Sub

        ' ==============================================================
        ' 3. ĐIỀU HƯỚNG VÀ CHỌN DÒNG TRÊN DATA GRID VIEW
        ' ==============================================================
        Private Sub ChonDongMenu(rowIndex As Integer)
            If rowIndex < 0 OrElse rowIndex >= _danhSachMenu.Count Then Return

            Dim dto = _danhSachMenu(rowIndex)
            _maMenuDangChon = dto.MaMenu

            txtMaMenu.Text = dto.MaMenu.ToString()
            txtTenMenu.Text = dto.TenMenu
            cboLoaiMenu.SelectedItem = dto.LoaiMenu
            cboTrangThai.SelectedItem = dto.TrangThai
            txtMoTa.Text = dto.MoTa

            lblModeBadge.Text = $"Chế độ: Đang chọn (#{dto.MaMenu})"
            lblModeBadge.BackColor = Color.FromArgb(234, 250, 234)
            lblModeBadge.ForeColor = Color.FromArgb(39, 174, 96)

            TaiDanhSachMonTrongMenu(dto.MaMenu)
            ApDungPhanQuyen()
            HienThiThongBao($"Đã chọn Bảng thực đơn: {dto.TenMenu}", False)
        End Sub

        Private Sub ChuyenCheDoThemMoi()
            _maMenuDangChon = 0
            txtMaMenu.Clear()
            txtTenMenu.Clear()
            cboLoaiMenu.SelectedIndex = 0
            cboTrangThai.SelectedIndex = 0
            txtMoTa.Clear()

            lblModeBadge.Text = "Chế độ: Tạo mới"
            lblModeBadge.BackColor = Color.FromArgb(254, 243, 199)
            lblModeBadge.ForeColor = Color.FromArgb(217, 119, 6)

            TaiDanhSachMonTrongMenu(0)
            ApDungPhanQuyen()
            txtTenMenu.Focus()
            HienThiThongBao("Mời nhập thông tin để tạo Bảng thực đơn mới.", False)
        End Sub

        Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvMenu.SelectedRows.Count > 0 Then
                ChonDongMenu(dgvMenu.SelectedRows(0).Index)
            End If
        End Sub

        Private Sub cboChonMon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboChonMon.SelectedIndexChanged
            If cboChonMon.SelectedItem IsNot Nothing Then
                Try
                    ' Lấy đơn giá gốc từ kho món
                    Dim item = cboChonMon.SelectedItem
                    Dim donGia As Decimal = Convert.ToDecimal(item.GetType().GetProperty("DonGia").GetValue(item, Nothing))

                    ' Nếu là Buffet thì mặc định đơn giá theo món là 0đ
                    If cboLoaiMenu.SelectedItem IsNot Nothing AndAlso cboLoaiMenu.SelectedItem.ToString() = "Buffet" Then
                        nudDonGiaMenu.Value = 0D
                    Else
                        nudDonGiaMenu.Value = Math.Min(donGia, nudDonGiaMenu.Maximum)
                    End If

                    ' Tự động tăng thứ tự gợi ý
                    nudThuTu.Value = Math.Max(1, _danhSachMonTrongMenu.Count + 1)
                Catch ex As Exception
                End Try
            End If
        End Sub

        ' ==============================================================
        ' 4. XỬ LÝ SỰ KIỆN NÚT THAO TÁC (CRUD & GÁN MÓN)
        ' ==============================================================
        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền thêm Bảng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dto As New MenuDTO() With {
                .TenMenu = txtTenMenu.Text.Trim(),
                .LoaiMenu = If(cboLoaiMenu.SelectedItem IsNot Nothing, cboLoaiMenu.SelectedItem.ToString(), "Alacarte"),
                .TrangThai = If(cboTrangThai.SelectedItem IsNot Nothing, cboTrangThai.SelectedItem.ToString(), "Đang áp dụng"),
                .MoTa = txtMoTa.Text.Trim()
            }

            Dim kq = MenuBUS.ThemMenu(dto)
            If kq.ThanhCong Then
                HienThiThongBao(kq.ThongBao, False)
                MessageBox.Show(kq.ThongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDuLieuMenu()

                ' Chọn dòng vừa thêm
                Dim idx = _danhSachMenu.FindIndex(Function(m) m.MaMenu = kq.MaMenu)
                If idx >= 0 Then
                    dgvMenu.Rows(idx).Selected = True
                    ChonDongMenu(idx)
                End If
            Else
                HienThiThongBao(kq.ThongBao, True)
                MessageBox.Show(kq.ThongBao, "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền sửa Bảng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _maMenuDangChon <= 0 Then
                MessageBox.Show("Vui lòng chọn bảng thực đơn cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dto As New MenuDTO() With {
                .MaMenu = _maMenuDangChon,
                .TenMenu = txtTenMenu.Text.Trim(),
                .LoaiMenu = If(cboLoaiMenu.SelectedItem IsNot Nothing, cboLoaiMenu.SelectedItem.ToString(), "Alacarte"),
                .TrangThai = If(cboTrangThai.SelectedItem IsNot Nothing, cboTrangThai.SelectedItem.ToString(), "Đang áp dụng"),
                .MoTa = txtMoTa.Text.Trim()
            }

            Dim kq = MenuBUS.CapNhatMenu(dto)
            If kq.ThanhCong Then
                HienThiThongBao(kq.ThongBao, False)
                MessageBox.Show(kq.ThongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDuLieuMenu()

                Dim idx = _danhSachMenu.FindIndex(Function(m) m.MaMenu = _maMenuDangChon)
                If idx >= 0 Then
                    dgvMenu.Rows(idx).Selected = True
                    ChonDongMenu(idx)
                End If
            Else
                HienThiThongBao(kq.ThongBao, True)
                MessageBox.Show(kq.ThongBao, "Lỗi kiểm tra", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền xóa Bảng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _maMenuDangChon <= 0 Then
                MessageBox.Show("Vui lòng chọn bảng thực đơn cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa Bảng thực đơn '{txtTenMenu.Text}' (Mã: {_maMenuDangChon}) không?{Environment.NewLine}Các món đang gán vào thực đơn này cũng sẽ bị ngưng áp dụng.",
                                          "Xác nhận xóa thực đơn",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question)

            If xacNhan = DialogResult.Yes Then
                Dim kq = MenuBUS.XoaMenu(_maMenuDangChon)
                If kq.ThanhCong Then
                    HienThiThongBao(kq.ThongBao, False)
                    MessageBox.Show(kq.ThongBao, "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    TaiDuLieuMenu()
                    ChuyenCheDoThemMoi()
                Else
                    HienThiThongBao(kq.ThongBao, True)
                    MessageBox.Show(kq.ThongBao, "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            ChuyenCheDoThemMoi()
        End Sub

        Private Sub btnGanMon_Click(sender As Object, e As EventArgs) Handles btnGanMon.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền gán món vào Bảng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _maMenuDangChon <= 0 Then
                MessageBox.Show("Vui lòng chọn Bảng thực đơn cần gán món trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If cboChonMon.SelectedItem Is Nothing Then
                MessageBox.Show("Vui lòng chọn Món ăn cần gán từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim maMon As Integer = Convert.ToInt32(cboChonMon.SelectedValue)
            Dim donGia As Decimal = nudDonGiaMenu.Value
            Dim thuTu As Integer = Convert.ToInt32(nudThuTu.Value)
            Dim ghiChu As String = txtGhiChuMon.Text.Trim()

            Dim kq = MenuBUS.GanMonVaoMenu(_maMenuDangChon, maMon, donGia, thuTu, ghiChu)
            If kq.ThanhCong Then
                HienThiThongBao(kq.ThongBao, False)
                ' Tự động chuyển qua Tab chi tiết món để người dùng thấy ngay
                tabMenuData.SelectedTab = tabChiTietMon
                TaiDanhSachMonTrongMenu(_maMenuDangChon)
                TaiDuLieuMenu()

                ' Giữ chọn dòng Menu hiện tại
                Dim idx = _danhSachMenu.FindIndex(Function(m) m.MaMenu = _maMenuDangChon)
                If idx >= 0 Then
                    dgvMenu.Rows(idx).Selected = True
                End If
            Else
                HienThiThongBao(kq.ThongBao, True)
                MessageBox.Show(kq.ThongBao, "Lỗi gán món", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnGoMon_Click(sender As Object, e As EventArgs) Handles btnGoMon.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền gỡ món khỏi Bảng thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If dgvMenuMonAn.SelectedRows.Count = 0 Then
                MessageBox.Show("Vui lòng chọn món cần gỡ khỏi thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim maMMA As Integer = Convert.ToInt32(dgvMenuMonAn.SelectedRows(0).Cells("colMMA_Ma").Value)
            Dim tenMon As String = dgvMenuMonAn.SelectedRows(0).Cells("colMMA_TenMonAn").Value.ToString()

            Dim xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn gỡ món '{tenMon}' ra khỏi Bảng thực đơn này?",
                                          "Xác nhận gỡ món",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question)

            If xacNhan = DialogResult.Yes Then
                Dim kq = MenuBUS.GoMonKhoiMenu(maMMA)
                If kq.ThanhCong Then
                    HienThiThongBao(kq.ThongBao, False)
                    TaiDanhSachMonTrongMenu(_maMenuDangChon)
                    TaiDuLieuMenu()

                    Dim idx = _danhSachMenu.FindIndex(Function(m) m.MaMenu = _maMenuDangChon)
                    If idx >= 0 Then
                        dgvMenu.Rows(idx).Selected = True
                    End If
                Else
                    HienThiThongBao(kq.ThongBao, True)
                    MessageBox.Show(kq.ThongBao, "Lỗi thao tác", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Sub

        ' ==============================================================
        ' 5. TÌM KIẾM, LỌC & ĐIỀU HƯỚNG
        ' ==============================================================
        Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
            If Not _dangNapDuLieu Then TaiDuLieuMenu()
        End Sub

        Private Sub cboLocLoaiMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocLoaiMenu.SelectedIndexChanged
            If Not _dangNapDuLieu Then TaiDuLieuMenu()
        End Sub

        Private Sub cboLocTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocTrangThai.SelectedIndexChanged
            If Not _dangNapDuLieu Then TaiDuLieuMenu()
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            NapDanhSachMonKho()
            TaiDuLieuMenu()
            If _maMenuDangChon > 0 Then
                TaiDanhSachMonTrongMenu(_maMenuDangChon)
            End If
            HienThiThongBao("Đã tải lại toàn bộ dữ liệu Bảng thực đơn & Kho món.", False)
        End Sub

        Private Sub btnMoMonAn_Click(sender As Object, e As EventArgs) Handles btnMoMonAn.Click
            Try
                Dim fMonAn As New frmMonAn()
                fMonAn.ShowDialog(Me)
                ' Sau khi đóng frmMonAn, tải lại kho món ăn
                NapDanhSachMonKho()
            Catch ex As Exception
                MessageBox.Show("Không thể mở màn hình Món ăn: " & ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub HienThiThongBao(noiDung As String, laLoi As Boolean)
            lblThongBao.Text = noiDung
            lblThongBao.ForeColor = If(laLoi, Color.FromArgb(192, 57, 43), Color.FromArgb(39, 174, 96))
        End Sub

    End Class

End Namespace
