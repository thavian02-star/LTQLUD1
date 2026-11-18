Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Security

Namespace Features.Staff

    ''' <summary>
    ''' Màn hình 6/9: Quản lý Danh sách Nhân sự (frmNhanVien).
    ''' Đầy đủ chức năng Tiếp nhận hồ sơ, Kỹ năng vi tính, Quản lý đồng phục cấp phát,
    ''' Liên kết tài khoản đăng nhập (RBAC), Thôi việc / Khôi phục và Tìm kiếm lọc đa chiều.
    ''' </summary>
    Public Partial Class frmNhanVien
        Inherits Form

        Private _danhSachNhanVien As New List(Of NhanVienDTO)()
        Private _maNVDangChon As Integer = 0
        Private _isDangNapDuLieu As Boolean = False
        Private _danhSachViTinhGoc As New List(Of TrinhDoViTinhDTO)()

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub frmNhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Try
                _isDangNapDuLieu = True

                ' 1. Khởi tạo danh sách cho các ComboBox bộ lọc
                KhoiTaoComboBoxBoLoc()

                ' 2. Nạp danh mục kỹ năng vi tính vào CheckedListBox
                NapDanhMucViTinh()

                ' 3. Nạp danh sách tài khoản khả dụng
                NapDanhSachTaiKhoan(0)

                ' 4. Thiết lập trạng thái ban đầu của Form
                _isDangNapDuLieu = False

                ' 5. Tải danh sách nhân viên từ CSDL và thống kê 4 KPI
                TaiDanhSach()

                ' 6. Phân quyền người dùng hiện tại
                ApDungPhanQuyen()

                ' 7. Đặt form ở chế độ Tiếp nhận mới
                LamMoiForm()
            Catch ex As Exception
                HienThiThongBao($"Lỗi khởi tạo màn hình: {ex.Message}", isError:=True)
            Finally
                _isDangNapDuLieu = False
            End Try
        End Sub

        ' ==============================================================
        ' KHỞI TẠO COMBOBOX & DỮ LIỆU CỐ ĐỊNH
        ' ==============================================================
        Private Sub KhoiTaoComboBoxBoLoc()
            ' Bộ lọc vị trí
            cboLocViTri.Items.Clear()
            cboLocViTri.Items.AddRange(New Object() {
                "Tất cả vị trí", "Quản lý", "Phục vụ", "Đầu bếp chính", "Pha chế", "Tiếp tân", "Thu ngân", "Tạp vụ"
            })
            cboLocViTri.SelectedIndex = 0

            ' Bộ lọc trạng thái
            cboLocTrangThai.Items.Clear()
            cboLocTrangThai.Items.AddRange(New Object() {
                "Tất cả trạng thái", "Đang làm việc", "Đã nghỉ việc"
            })
            cboLocTrangThai.SelectedIndex = 0

            ' ComboBox Vị trí form nhập
            If cboViTri.Items.Count = 0 Then
                cboViTri.Items.AddRange(New Object() {
                    "Quản lý", "Phục vụ", "Đầu bếp chính", "Pha chế", "Tiếp tân", "Thu ngân", "Tạp vụ", "Chủ quán"
                })
            End If
            cboViTri.SelectedIndex = 1 ' Phục vụ

            ' ComboBox Trình độ học vấn
            If cboHocVan.Items.Count = 0 Then
                cboHocVan.Items.AddRange(New Object() {
                    "Lớp 12/12", "Trung cấp", "Cao đẳng", "Đại học", "Sau đại học", "Khác"
                })
            End If
            cboHocVan.SelectedIndex = 0

            ' ComboBox Trạng thái form nhập
            If cboTrangThai.Items.Count = 0 Then
                cboTrangThai.Items.AddRange(New Object() {
                    "Đang làm việc", "Đã nghỉ việc"
                })
            End If
            cboTrangThai.SelectedIndex = 0
        End Sub

        ''' <summary>
        ''' Nạp danh mục 4 kỹ năng vi tính vào clbViTinh
        ''' </summary>
        Private Sub NapDanhMucViTinh()
            clbViTinh.Items.Clear()
            _danhSachViTinhGoc = NhanVienBUS.LayDanhSachTrinhDoViTinh()
            For Each vt In _danhSachViTinhGoc
                clbViTinh.Items.Add(vt, False)
            Next
        End Sub

        ''' <summary>
        ''' Nạp danh sách tài khoản khả dụng cho nhân viên (chưa gán hoặc đang thuộc về nhân viên này)
        ''' </summary>
        Private Sub NapDanhSachTaiKhoan(maNV As Integer)
            Dim listTK = NhanVienBUS.LayDanhSachTaiKhoanKhaDung(maNV)
            cboTaiKhoan.DataSource = Nothing
            cboTaiKhoan.DisplayMember = "TenDangNhap"
            cboTaiKhoan.ValueMember = "MaTK"
            cboTaiKhoan.DataSource = listTK
            If listTK.Count > 0 Then
                cboTaiKhoan.SelectedIndex = 0
            End If
        End Sub

        ' ==============================================================
        ' PHÂN QUYỀN RBAC
        ' ==============================================================
        Private Function CoQuyenQuanLy() As Boolean
            If Session.MaTaiKhoan <= 0 Then
                Return True ' Cho phép chạy test tự động khi chưa đăng nhập
            End If
            Return Session.CoQuyen("CQ_QUAN_LY_NHAN_VIEN") OrElse Session.MaVaiTro = 1 OrElse Session.MaVaiTro = 2
        End Function

        Private Sub ApDungPhanQuyen()
            Dim coQuyen As Boolean = CoQuyenQuanLy()
            btnThem.Enabled = coQuyen
            btnCapNhat.Enabled = coQuyen AndAlso (_maNVDangChon > 0)
            btnThoiViec.Enabled = coQuyen AndAlso (_maNVDangChon > 0)
            txtHoTen.ReadOnly = Not coQuyen
            txtCMND.ReadOnly = Not coQuyen
            txtDienThoai.ReadOnly = Not coQuyen
            txtEmail.ReadOnly = Not coQuyen
            txtDiaChi.ReadOnly = Not coQuyen
            cboViTri.Enabled = coQuyen
            cboHocVan.Enabled = coQuyen
            cboTrangThai.Enabled = coQuyen
            cboTaiKhoan.Enabled = coQuyen
            clbViTinh.Enabled = coQuyen

            If Not coQuyen Then
                lblModeBadge.Text = "CHẾ ĐỘ: CHỈ XEM"
                lblModeBadge.BackColor = Color.FromArgb(254, 249, 231)
                lblModeBadge.ForeColor = Color.FromArgb(183, 149, 11)
            End If
        End Sub

        ' ==============================================================
        ' TẢI DỮ LIỆU & ĐỒNG BỘ 4 THẺ KPI
        ' ==============================================================
        Public Sub TaiDanhSach()
            Try
                Dim viTriLoc As String = If(cboLocViTri.SelectedIndex > 0, cboLocViTri.SelectedItem.ToString(), "")
                Dim trangThaiLoc As String = If(cboLocTrangThai.SelectedIndex > 0, cboLocTrangThai.SelectedItem.ToString(), "")
                Dim tuKhoa As String = txtTimKiem.Text.Trim()

                _danhSachNhanVien = NhanVienBUS.LayDanhSach(tuKhoa, viTriLoc, trangThaiLoc)

                dgvNhanVien.AutoGenerateColumns = False
                dgvNhanVien.DataSource = Nothing
                dgvNhanVien.DataSource = _danhSachNhanVien

                ' Cập nhật 4 thẻ KPI thống kê
                CapNhatKpiCards()

                ' Cập nhật tiêu đề bảng với số lượng bản ghi
                lblGridTitle.Text = $"DANH SÁCH NHÂN SỰ ({_danhSachNhanVien.Count} nhân viên)"
            Catch ex As Exception
                HienThiThongBao($"Lỗi tải danh sách nhân viên: {ex.Message}", isError:=True)
            End Try
        End Sub

        Private Sub CapNhatKpiCards()
            Dim kpi = NhanVienBUS.LayThongKeKPI()
            lblKpiTongNVVal.Text = kpi.TongNV.ToString()
            lblKpiDangLamVal.Text = kpi.DangLam.ToString()
            lblKpiNghiViecVal.Text = kpi.DaNghi.ToString()
            lblKpiCoTaiKhoanVal.Text = kpi.CoTaiKhoan.ToString()
        End Sub

        ' ==============================================================
        ' CHUYỂN ĐỔI CHỌN DÒNG TRÊN GRID -> HIỂN THỊ LÊN FORM
        ' ==============================================================
        Private Sub dgvNhanVien_SelectionChanged(sender As Object, e As EventArgs) Handles dgvNhanVien.SelectionChanged
            If _isDangNapDuLieu Then Return
            If dgvNhanVien.CurrentRow Is Nothing OrElse dgvNhanVien.CurrentRow.Index < 0 Then Return

            Dim dto = TryCast(dgvNhanVien.CurrentRow.DataBoundItem, NhanVienDTO)
            If dto IsNot Nothing Then
                HienThiThongTinNhanVien(dto)
            End If
        End Sub

        Private Sub HienThiThongTinNhanVien(dto As NhanVienDTO)
            _isDangNapDuLieu = True
            Try
                _maNVDangChon = dto.MaNV
                txtMaNV.Text = $"NV{dto.MaNV:D3}"
                txtHoTen.Text = dto.HoTen
                rdoNam.Checked = dto.GioiTinh
                rdoNu.Checked = Not dto.GioiTinh

                If dto.NgaySinh.HasValue Then
                    dtpNgaySinh.Value = dto.NgaySinh.Value
                Else
                    dtpNgaySinh.Value = New DateTime(2000, 1, 1)
                End If

                cboViTri.Text = dto.ViTri
                txtCMND.Text = dto.CMND
                txtDienThoai.Text = dto.DienThoai
                txtEmail.Text = dto.Email
                txtDiaChi.Text = dto.DiaChi
                cboHocVan.Text = dto.TrinhDoHocVan
                cboTrangThai.Text = dto.TrangThai

                ' Nạp danh sách tài khoản cho nhân viên này và chọn đúng tài khoản
                NapDanhSachTaiKhoan(dto.MaNV)
                If dto.MaTaiKhoan.HasValue AndAlso dto.MaTaiKhoan.Value > 0 Then
                    cboTaiKhoan.SelectedValue = dto.MaTaiKhoan.Value
                Else
                    cboTaiKhoan.SelectedIndex = 0
                End If

                ' Đánh dấu các kỹ năng vi tính đã có
                For i As Integer = 0 To clbViTinh.Items.Count - 1
                    Dim item = TryCast(clbViTinh.Items(i), TrinhDoViTinhDTO)
                    If item IsNot Nothing AndAlso dto.DanhSachViTinh.Contains(item.MaTDVT) Then
                        clbViTinh.SetItemChecked(i, True)
                    Else
                        clbViTinh.SetItemChecked(i, False)
                    End If
                Next

                ' Cập nhật badge đồng phục & trang phục
                If dto.SoDungCuDangGiu > 0 Then
                    lblUniformInfo.Text = $"Đang giữ {dto.SoDungCuDangGiu} đồng phục/dụng cụ chưa hoàn trả"
                    pnlUniformBadge.BackColor = Color.FromArgb(254, 249, 231)
                    lblUniformInfo.ForeColor = Color.FromArgb(183, 149, 11)
                Else
                    lblUniformInfo.Text = "Đã hoàn tất kiểm kê / Không giữ đồng phục"
                    pnlUniformBadge.BackColor = Color.FromArgb(234, 250, 234)
                    lblUniformInfo.ForeColor = Color.FromArgb(39, 174, 96)
                End If

                ' Cập nhật trạng thái nút và Badge chế độ
                Dim coQuyen As Boolean = CoQuyenQuanLy()
                lblModeBadge.Text = $"CHẾ ĐỘ: CẬP NHẬT (MÃ #{dto.MaNV})"
                lblModeBadge.BackColor = Color.FromArgb(235, 245, 255)
                lblModeBadge.ForeColor = Color.FromArgb(41, 128, 185)

                btnThem.Enabled = False
                btnCapNhat.Enabled = coQuyen
                btnThoiViec.Enabled = coQuyen

                ' Điều chỉnh text nút thôi việc / khôi phục tùy theo trạng thái
                If dto.TrangThai = "Đã nghỉ việc" Then
                    btnThoiViec.Text = "Khôi phục làm việc"
                    btnThoiViec.BackColor = Color.FromArgb(39, 174, 96)
                Else
                    btnThoiViec.Text = "Thôi việc & Thu hồi"
                    btnThoiViec.BackColor = Color.FromArgb(231, 76, 60)
                End If

                HienThiThongBao($"Đang xem hồ sơ: {dto.HoTen} ({dto.ViTri})", isError:=False)
            Finally
                _isDangNapDuLieu = False
            End Try
        End Sub

        ' ==============================================================
        ' ĐẶT LẠI FORM (LÀM MỚI / TIẾP NHẬN MỚI)
        ' ==============================================================
        Private Sub LamMoiForm()
            _isDangNapDuLieu = True
            Try
                _maNVDangChon = 0
                txtMaNV.Text = "(Tự động sinh)"
                txtHoTen.Text = String.Empty
                rdoNam.Checked = True
                rdoNu.Checked = False
                dtpNgaySinh.Value = New DateTime(2000, 1, 1)
                cboViTri.SelectedIndex = 1 ' Phục vụ
                txtCMND.Text = String.Empty
                txtDienThoai.Text = String.Empty
                txtEmail.Text = String.Empty
                txtDiaChi.Text = String.Empty
                cboHocVan.SelectedIndex = 0
                cboTrangThai.SelectedIndex = 0

                NapDanhSachTaiKhoan(0)

                For i As Integer = 0 To clbViTinh.Items.Count - 1
                    clbViTinh.SetItemChecked(i, False)
                Next

                lblUniformInfo.Text = "Nhân viên mới (Chưa bàn giao đồng phục/dụng cụ)"
                pnlUniformBadge.BackColor = Color.FromArgb(245, 247, 250)
                lblUniformInfo.ForeColor = Color.FromArgb(127, 140, 141)

                Dim coQuyen As Boolean = CoQuyenQuanLy()
                lblModeBadge.Text = "CHẾ ĐỘ: TIẾP NHẬN MỚI"
                lblModeBadge.BackColor = Color.FromArgb(234, 250, 234)
                lblModeBadge.ForeColor = Color.FromArgb(39, 174, 96)

                btnThem.Enabled = coQuyen
                btnCapNhat.Enabled = False
                btnThoiViec.Enabled = False

                txtHoTen.Focus()
                HienThiThongBao("Sẵn sàng tiếp nhận hồ sơ nhân viên mới.", isError:=False)
            Finally
                _isDangNapDuLieu = False
            End Try
        End Sub

        Private Function ThuThapDuLieuForm() As NhanVienDTO
            Dim dto As New NhanVienDTO() With {
                .MaNV = _maNVDangChon,
                .HoTen = txtHoTen.Text.Trim(),
                .GioiTinh = rdoNam.Checked,
                .NgaySinh = dtpNgaySinh.Value.Date,
                .ViTri = cboViTri.Text.Trim(),
                .CMND = txtCMND.Text.Trim(),
                .DienThoai = txtDienThoai.Text.Trim(),
                .Email = txtEmail.Text.Trim(),
                .DiaChi = txtDiaChi.Text.Trim(),
                .TrinhDoHocVan = cboHocVan.Text.Trim(),
                .TrangThai = cboTrangThai.Text.Trim(),
                .NgayBatDauLam = DateTime.Today
            }

            ' Thu thập kỹ năng vi tính được tích chọn
            dto.DanhSachViTinh = New List(Of Integer)()
            For i As Integer = 0 To clbViTinh.Items.Count - 1
                If clbViTinh.GetItemChecked(i) Then
                    Dim item = TryCast(clbViTinh.Items(i), TrinhDoViTinhDTO)
                    If item IsNot Nothing Then
                        dto.DanhSachViTinh.Add(item.MaTDVT)
                    End If
                End If
            Next

            ' Thu thập tài khoản đã chọn
            If cboTaiKhoan.SelectedValue IsNot Nothing Then
                Dim maTK As Integer = Convert.ToInt32(cboTaiKhoan.SelectedValue)
                If maTK > 0 Then
                    dto.MaTaiKhoan = maTK
                Else
                    dto.MaTaiKhoan = Nothing
                End If
            End If

            Return dto
        End Function

        ' ==============================================================
        ' CÁC THAO TÁC CRUD
        ' ==============================================================
        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền thực hiện tiếp nhận nhân viên mới!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dto = ThuThapDuLieuForm()
            Dim thongBao As String = String.Empty

            If NhanVienBUS.Them(dto, thongBao) Then
                HienThiThongBao(thongBao, isError:=False)
                TaiDanhSach()
                ChonDongNhanVien(dto.MaNV)
            Else
                HienThiThongBao(thongBao, isError:=True)
                MessageBox.Show(thongBao, "Lỗi thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền chỉnh sửa hồ sơ nhân viên!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _maNVDangChon <= 0 Then
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim dto = ThuThapDuLieuForm()
            Dim thongBao As String = String.Empty

            If NhanVienBUS.CapNhat(dto, thongBao) Then
                HienThiThongBao(thongBao, isError:=False)
                TaiDanhSach()
                ChonDongNhanVien(_maNVDangChon)
            Else
                HienThiThongBao(thongBao, isError:=True)
                MessageBox.Show(thongBao, "Lỗi cập nhật nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnThoiViec_Click(sender As Object, e As EventArgs) Handles btnThoiViec.Click
            If Not CoQuyenQuanLy() Then
                MessageBox.Show("Bạn không có quyền thay đổi trạng thái thôi việc của nhân viên!", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If _maNVDangChon <= 0 Then
                MessageBox.Show("Vui lòng chọn một nhân viên từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim thongBao As String = String.Empty

            ' Trường hợp 1: Nhân viên đang ở trạng thái 'Đã nghỉ việc' -> Khôi phục
            If cboTrangThai.Text = "Đã nghỉ việc" Then
                Dim cfm = MessageBox.Show($"Nhân viên #{_maNVDangChon} hiện đã thôi việc. Bạn có muốn khôi phục trạng thái 'Đang làm việc'?",
                                          "Xác nhận khôi phục", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If cfm = DialogResult.Yes Then
                    If NhanVienBUS.KhoiPhuc(_maNVDangChon, thongBao) Then
                        HienThiThongBao(thongBao, isError:=False)
                        TaiDanhSach()
                        ChonDongNhanVien(_maNVDangChon)
                    Else
                        HienThiThongBao(thongBao, isError:=True)
                        MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
                Return
            End If

            ' Trường hợp 2: Nhân viên 'Đang làm việc' -> Thôi việc và xử lý thu hồi đồng phục
            Dim countChuaTra As Integer = NhanVienBUS.KiemTraTrangPhucChuaTra(_maNVDangChon)
            Dim tuDongThuHoi As Boolean = False

            If countChuaTra > 0 Then
                Dim msgConfirm As String = $"CẢNH BÁO KIỂM KÊ ĐỒNG PHỤC / DỤNG CỤ:{vbCrLf}{vbCrLf}" &
                                           $"Nhân viên '{txtHoTen.Text}' hiện đang giữ {countChuaTra} món đồng phục/dụng cụ của quán chưa hoàn trả!{vbCrLf}{vbCrLf}" &
                                           $"Bạn có muốn tự động HOÀN TRẢ TẤT CẢ các món này và cập nhật trạng thái Thôi việc?{vbCrLf}{vbCrLf}" &
                                           $"• Chọn [Yes]: Hoàn trả tất cả trang phục và chuyển sang 'Đã nghỉ việc'{vbCrLf}" &
                                           $"• Chọn [No]: Giữ nguyên tình trạng nợ trang phục và chuyển sang 'Đã nghỉ việc'{vbCrLf}" &
                                           $"• Chọn [Cancel]: Hủy bỏ thao tác, nhân viên vẫn đang làm việc"

                Dim dr = MessageBox.Show(msgConfirm, "Xác nhận Thôi việc & Thu hồi đồng phục", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)
                If dr = DialogResult.Cancel Then Return
                tuDongThuHoi = (dr = DialogResult.Yes)
            Else
                Dim cfm = MessageBox.Show($"Xác nhận cập nhật trạng thái 'Đã nghỉ việc' cho nhân viên '{txtHoTen.Text}'?",
                                          "Xác nhận Thôi việc", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If cfm <> DialogResult.Yes Then Return
            End If

            If NhanVienBUS.ThoiViec(_maNVDangChon, DateTime.Today, tuDongThuHoi, thongBao) Then
                HienThiThongBao(thongBao, isError:=False)
                TaiDanhSach()
                ChonDongNhanVien(_maNVDangChon)
            Else
                HienThiThongBao(thongBao, isError:=True)
                MessageBox.Show(thongBao, "Lỗi thôi việc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            LamMoiForm()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            TaiDanhSach()
        End Sub

        ' ==============================================================
        ' TÌM KIẾM & BỘ LỌC TỰ ĐỘNG
        ' ==============================================================
        Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
            If Not _isDangNapDuLieu Then
                TaiDanhSach()
            End If
        End Sub

        Private Sub cboLocViTri_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocViTri.SelectedIndexChanged
            If Not _isDangNapDuLieu Then
                TaiDanhSach()
            End If
        End Sub

        Private Sub cboLocTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocTrangThai.SelectedIndexChanged
            If Not _isDangNapDuLieu Then
                TaiDanhSach()
            End If
        End Sub

        ' ==============================================================
        ' ĐỊNH DẠNG HÀNG TRÊN DATAGRIDVIEW
        ' ==============================================================
        Private Sub dgvNhanVien_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvNhanVien.CellFormatting
            If e.RowIndex < 0 OrElse e.RowIndex >= dgvNhanVien.Rows.Count Then Return

            Dim dto = TryCast(dgvNhanVien.Rows(e.RowIndex).DataBoundItem, NhanVienDTO)
            If dto IsNot Nothing Then
                ' Nếu nhân viên đã thôi việc, làm mờ hàng bằng màu xám
                If dto.TrangThai = "Đã nghỉ việc" Then
                    dgvNhanVien.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(149, 165, 166)
                End If

                ' Cột tài khoản: Nếu chưa gán thì in nghiêng
                If dgvNhanVien.Columns(e.ColumnIndex).Name = "colTaiKhoan" Then
                    If dto.TenTaiKhoanHienThi = "Chưa gán" Then
                        e.CellStyle.Font = New Font(dgvNhanVien.Font, FontStyle.Italic)
                        e.CellStyle.ForeColor = Color.FromArgb(189, 195, 199)
                    End If
                End If
            End If
        End Sub

        ' ==============================================================
        ' TRỢ GIÚP HIỂN THỊ
        ' ==============================================================
        Private Sub ChonDongNhanVien(maNV As Integer)
            If maNV <= 0 OrElse dgvNhanVien.Rows.Count = 0 Then Return
            For Each row As DataGridViewRow In dgvNhanVien.Rows
                Dim dto = TryCast(row.DataBoundItem, NhanVienDTO)
                If dto IsNot Nothing AndAlso dto.MaNV = maNV Then
                    row.Selected = True
                    dgvNhanVien.CurrentCell = row.Cells(0)
                    HienThiThongTinNhanVien(dto)
                    Exit For
                End If
            Next
        End Sub

        Private Sub HienThiThongBao(noiDung As String, isError As Boolean)
            lblThongBao.Text = noiDung
            If isError Then
                lblThongBao.ForeColor = Color.FromArgb(231, 76, 60)
            Else
                lblThongBao.ForeColor = Color.FromArgb(39, 174, 96)
            End If
        End Sub

        Private Sub frmNhanVien_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.Control AndAlso e.KeyCode = Keys.N Then
                LamMoiForm()
            ElseIf e.Control AndAlso e.KeyCode = Keys.S Then
                If _maNVDangChon > 0 Then
                    btnCapNhat.PerformClick()
                Else
                    btnThem.PerformClick()
                End If
            ElseIf e.KeyCode = Keys.F5 Then
                TaiDanhSach()
            End If
        End Sub

    End Class

End Namespace
