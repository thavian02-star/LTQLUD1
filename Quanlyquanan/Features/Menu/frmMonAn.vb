Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Features.Main

Namespace Features.Menu
    ''' <summary>
    ''' Màn hình 2 (Checklist Ưu tiên): Quản lý Món ăn &amp; Thức uống (Bảng MonAn kết nối DanhMuc).
    ''' Bước 3/5: Xử lý toàn bộ nghiệp vụ Thêm, Sửa, Báo hết món nhanh, Xóa mềm (chặn xóa khi món đang phục vụ tại bàn),
    ''' Bộ lọc đa chiều (Danh mục + Trạng thái + Từ khóa) và Thống kê 3 thẻ KPI.
    ''' </summary>
    Public Class frmMonAn

        Private ReadOnly _bus As New MonAnBUS()
        Private ReadOnly _danhMucBus As New DanhMucBUS()
        Private _danhSachHienTai As New List(Of MonAnDTO)()
        Private _maDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        Private Sub frmMonAn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            NapDanhSachBoLocVaComboBox()
            TaiDanhSachMonAn()
        End Sub

        ''' <summary>
        ''' Định dạng màu sắc Header, dòng xen kẽ và căn lề các cột trên dgvMonAn.
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            With dgvMonAn
                .AutoGenerateColumns = False
                .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59)
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
                .ColumnHeadersDefaultCellStyle.Padding = New Padding(6, 0, 6, 0)

                .DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Regular)
                .DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59)
                .DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254)
                .DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42)
                .DefaultCellStyle.Padding = New Padding(6, 0, 6, 0)

                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252)
            End With

            colMaMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaMon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colTenMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colDonGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            colDonGia.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            colDonGia.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)
            colDonGia.DefaultCellStyle.ForeColor = Color.FromArgb(29, 78, 216)

            colTrangThai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colTrangThai.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colTrangThai.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        End Sub

        ''' <summary>
        ''' Nạp danh sách DanhMuc vào cboDanhMuc (Form nhập) và cboLocDanhMuc + cboLocTrangThai (Thanh lọc).
        ''' </summary>
        Public Sub NapDanhSachBoLocVaComboBox(Optional giuMaLocDM As Integer = 0, Optional giuMaFormDM As Integer = 0)
            Try
                _dangNapDuLieu = True
                Dim dsDanhMuc As List(Of DanhMucDTO) = _danhMucBus.LayDanhSachDanhMuc("")

                ' 1. Nạp cboDanhMuc (trên khung nhập liệu bên trái)
                cboDanhMuc.DataSource = Nothing
                cboDanhMuc.DisplayMember = "TenDanhMuc"
                cboDanhMuc.ValueMember = "MaDanhMuc"
                cboDanhMuc.DataSource = New List(Of DanhMucDTO)(dsDanhMuc)
                If giuMaFormDM > 0 AndAlso dsDanhMuc.Any(Function(d) d.MaDanhMuc = giuMaFormDM) Then
                    cboDanhMuc.SelectedValue = giuMaFormDM
                ElseIf cboDanhMuc.Items.Count > 0 Then
                    cboDanhMuc.SelectedIndex = 0
                End If

                ' 2. Nạp cboLocDanhMuc (trên thanh bộ lọc bên phải)
                Dim dsLocDM As New List(Of DanhMucDTO)()
                dsLocDM.Add(New DanhMucDTO() With {
                    .MaDanhMuc = 0,
                    .TenDanhMuc = $"-- Tất cả danh mục ({dsDanhMuc.Count} nhóm) --"
                })
                dsLocDM.AddRange(dsDanhMuc)

                cboLocDanhMuc.DataSource = Nothing
                cboLocDanhMuc.DisplayMember = "TenDanhMuc"
                cboLocDanhMuc.ValueMember = "MaDanhMuc"
                cboLocDanhMuc.DataSource = dsLocDM
                If giuMaLocDM > 0 AndAlso dsLocDM.Any(Function(d) d.MaDanhMuc = giuMaLocDM) Then
                    cboLocDanhMuc.SelectedValue = giuMaLocDM
                Else
                    cboLocDanhMuc.SelectedIndex = 0
                End If

                ' 3. Nạp cboLocTrangThai nếu chưa có
                If cboLocTrangThai.Items.Count = 0 Then
                    cboLocTrangThai.Items.Add("-- Tất cả trạng thái --")
                    cboLocTrangThai.Items.Add("🟢 Còn món (Đang bán)")
                    cboLocTrangThai.Items.Add("🔴 Tạm hết món")
                    cboLocTrangThai.SelectedIndex = 0
                End If

                _dangNapDuLieu = False
            Catch ex As Exception
                _dangNapDuLieu = False
                HienThiThongBao("❌ Lỗi nạp danh mục: " & ex.Message, isError:=True)
            End Try
        End Sub

        ''' <summary>
        ''' Lấy giá trị mã danh mục đang chọn trên bộ lọc (0 = Tất cả).
        ''' </summary>
        Private Function LayMaDanhMucLoc() As Integer
            If cboLocDanhMuc.SelectedValue IsNot Nothing Then
                Dim val As Integer = 0
                If Integer.TryParse(cboLocDanhMuc.SelectedValue.ToString(), val) Then
                    Return val
                End If
            End If
            Dim item As DanhMucDTO = TryCast(cboLocDanhMuc.SelectedItem, DanhMucDTO)
            If item IsNot Nothing Then Return item.MaDanhMuc
            Return 0
        End Function

        ''' <summary>
        ''' Lấy giá trị trạng thái hết món đang chọn trên bộ lọc (-1 = Tất cả, 0 = Còn món, 1 = Hết món).
        ''' </summary>
        Private Function LayTrangThaiLoc() As Integer
            Select Case cboLocTrangThai.SelectedIndex
                Case 1 : Return 0 ' Còn món
                Case 2 : Return 1 ' Hết món
                Case Else : Return -1 ' Tất cả
            End Select
        End Function

        ''' <summary>
        ''' Lấy mã danh mục đang chọn trên Form nhập liệu bên trái.
        ''' </summary>
        Private Function LayMaDanhMucForm() As Integer
            If cboDanhMuc.SelectedValue IsNot Nothing Then
                Dim val As Integer = 0
                If Integer.TryParse(cboDanhMuc.SelectedValue.ToString(), val) Then
                    Return val
                End If
            End If
            Dim item As DanhMucDTO = TryCast(cboDanhMuc.SelectedItem, DanhMucDTO)
            If item IsNot Nothing Then Return item.MaDanhMuc
            Return 0
        End Function

        ''' <summary>
        ''' Tải danh sách món ăn theo bộ lọc hiện tại, cập nhật 3 thẻ KPI và chọn dòng tương ứng.
        ''' </summary>
        Public Sub TaiDanhSachMonAn(Optional maUuTienChon As Integer = 0)
            Try
                _dangNapDuLieu = True
                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                Dim maDMLoc As Integer = LayMaDanhMucLoc()
                Dim trangThaiLoc As Integer = LayTrangThaiLoc()

                _danhSachHienTai = _bus.LayDanhSachMonAn(tuKhoa, maDMLoc, trangThaiLoc)

                dgvMonAn.DataSource = Nothing
                dgvMonAn.DataSource = _danhSachHienTai

                CapNhatThongKeKpi()
                _dangNapDuLieu = False

                If _danhSachHienTai.Count > 0 Then
                    Dim indexChon As Integer = 0
                    If maUuTienChon > 0 Then
                        For i As Integer = 0 To _danhSachHienTai.Count - 1
                            If _danhSachHienTai(i).MaMonAn = maUuTienChon Then
                                indexChon = i
                                Exit For
                            End If
                        Next
                    End If

                    dgvMonAn.ClearSelection()
                    dgvMonAn.Rows(indexChon).Selected = True
                    HienThiChiTiet(_danhSachHienTai(indexChon))
                Else
                    DatCheDoThemMoi(giuThongBao:=True)
                End If
            Catch ex As Exception
                _dangNapDuLieu = False
                HienThiThongBao("❌ Lỗi tải danh sách món ăn: " & ex.Message, isError:=True)
            End Try
        End Sub

        ''' <summary>
        ''' Cập nhật số liệu trên 3 thẻ KPI (Tổng số món, Đang phục vụ - Còn món, Tạm hết món) và tiêu đề bảng.
        ''' </summary>
        Private Sub CapNhatThongKeKpi()
            Dim coLoc As Boolean = (Not String.IsNullOrWhiteSpace(txtTimKiem.Text)) OrElse
                                   (LayMaDanhMucLoc() > 0) OrElse
                                   (LayTrangThaiLoc() <> -1)

            Dim toanBo As List(Of MonAnDTO) = If(coLoc,
                                                 _bus.LayDanhSachMonAn("", 0, -1),
                                                 _danhSachHienTai)

            Dim tongMon As Integer = toanBo.Count
            Dim conMon As Integer = toanBo.Where(Function(x) Not x.HetMon).Count()
            Dim hetMon As Integer = toanBo.Where(Function(x) x.HetMon).Count()

            lblKpiTongMonValue.Text = $"{tongMon} món"
            lblKpiConMonValue.Text = $"{conMon} món"
            lblKpiHetMonValue.Text = $"{hetMon} món"
            lblGridTitle.Text = $"📋 Danh sách Thực đơn Món ăn & Thức uống (Hiển thị {_danhSachHienTai.Count}/{tongMon} món)"
        End Sub

        ''' <summary>
        ''' Đổ thông tin của 1 MonAnDTO lên khung nhập liệu bên trái.
        ''' </summary>
        Private Sub HienThiChiTiet(item As MonAnDTO)
            If item Is Nothing Then Return
            _maDangChon = item.MaMonAn
            txtMaMon.Text = $"#{item.MaMonAn}"
            txtTenMon.Text = item.TenMonAn

            If cboDanhMuc.Items.Count > 0 Then
                cboDanhMuc.SelectedValue = item.MaDanhMuc
            End If

            Dim giaHopLe As Decimal = Math.Max(nudDonGia.Minimum, Math.Min(nudDonGia.Maximum, item.DonGia))
            nudDonGia.Value = giaHopLe
            chkHetMon.Checked = item.HetMon
            txtMoTa.Text = item.MoTa

            lblModeBadge.Text = $"Chế độ: Đang chọn #{item.MaMonAn}"
            lblModeBadge.BackColor = Color.FromArgb(239, 246, 255)
            lblModeBadge.ForeColor = Color.FromArgb(29, 78, 216)
        End Sub

        ''' <summary>
        ''' Đưa khung nhập liệu về trạng thái Thêm mới.
        ''' </summary>
        Public Sub DatCheDoThemMoi(Optional giuThongBao As Boolean = False)
            _maDangChon = 0
            txtMaMon.Text = "Tự động"
            txtTenMon.Clear()
            nudDonGia.Value = 45000D
            chkHetMon.Checked = False
            txtMoTa.Clear()

            If cboDanhMuc.Items.Count > 0 AndAlso cboDanhMuc.SelectedIndex < 0 Then
                cboDanhMuc.SelectedIndex = 0
            End If

            lblModeBadge.Text = "Chế độ: Thêm mới"
            lblModeBadge.BackColor = Color.FromArgb(220, 252, 231)
            lblModeBadge.ForeColor = Color.FromArgb(21, 128, 61)

            If dgvMonAn.Rows.Count > 0 Then
                _dangNapDuLieu = True
                dgvMonAn.ClearSelection()
                _dangNapDuLieu = False
            End If

            If Not giuThongBao Then
                HienThiThongBao("ℹ️ Đã làm mới ô nhập. Chọn Danh mục, nhập Tên món & Đơn giá rồi bấm [➕ Thêm món mới].", isError:=False, isInfo:=True)
            End If
            txtTenMon.Focus()
        End Sub

        ''' <summary>
        ''' Hiển thị thông báo trạng thái trực quan trên lblThongBao.
        ''' </summary>
        Private Sub HienThiThongBao(noiDung As String, Optional isError As Boolean = False, Optional isInfo As Boolean = False)
            lblThongBao.Text = noiDung
            If isError Then
                lblThongBao.BackColor = Color.FromArgb(254, 226, 226)
                lblThongBao.ForeColor = Color.FromArgb(153, 27, 27)
            ElseIf isInfo Then
                lblThongBao.BackColor = Color.FromArgb(219, 234, 254)
                lblThongBao.ForeColor = Color.FromArgb(30, 64, 175)
            Else
                lblThongBao.BackColor = Color.FromArgb(220, 252, 231)
                lblThongBao.ForeColor = Color.FromArgb(22, 101, 52)
            End If
        End Sub

        ''' <summary>
        ''' Định dạng hiển thị cột Mã (#1, #2), Đơn giá ("45,000 đ") và màu sắc cột Trạng thái trên lưới.
        ''' </summary>
        Private Sub dgvMonAn_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMonAn.CellFormatting
            If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return

            Dim colName As String = dgvMonAn.Columns(e.ColumnIndex).Name
            If colName = "colMaMon" Then
                e.Value = $"#{e.Value}"
                e.FormattingApplied = True
            ElseIf colName = "colDonGia" Then
                Dim gia As Decimal = 0D
                If Decimal.TryParse(e.Value.ToString(), gia) Then
                    e.Value = $"{gia:#,##0} đ"
                    e.FormattingApplied = True
                End If
            ElseIf colName = "colTrangThai" Then
                Dim textVal As String = e.Value.ToString()
                If textVal.Contains("Hết món") Then
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28)
                    e.CellStyle.BackColor = Color.FromArgb(254, 242, 242)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61)
                End If
            End If
        End Sub

        Private Sub dgvMonAn_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMonAn.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvMonAn.CurrentRow IsNot Nothing AndAlso dgvMonAn.CurrentRow.Selected Then
                Dim item As MonAnDTO = TryCast(dgvMonAn.CurrentRow.DataBoundItem, MonAnDTO)
                If item IsNot Nothing Then
                    HienThiChiTiet(item)
                End If
            End If
        End Sub

        Private Sub dgvMonAn_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMonAn.CellClick
            If e.RowIndex < 0 Then Return
            Dim item As MonAnDTO = TryCast(dgvMonAn.Rows(e.RowIndex).DataBoundItem, MonAnDTO)
            If item IsNot Nothing Then
                HienThiChiTiet(item)
            End If
        End Sub

        ' =========================================================
        ' SỰ KIỆN 4 NÚT NGHIỆP VỤ: THÊM - CẬP NHẬT - XÓA - LÀM MỚI
        ' =========================================================

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            DatCheDoThemMoi()
        End Sub

        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            Dim maDM As Integer = LayMaDanhMucForm()
            Dim kq As KetQuaMonAn = _bus.ThemMonAn(txtTenMon.Text, maDM, nudDonGia.Value, chkHetMon.Checked, txtMoTa.Text)
            If kq.ThanhCong Then
                TaiDanhSachMonAn(kq.MaMonAn)
                HienThiThongBao("✅ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa thêm món ăn mới: {txtTenMon.Text.Trim()} ({nudDonGia.Value:#,##0} đ)")
            Else
                HienThiThongBao("❌ " & kq.ThongBao, isError:=True)
                txtTenMon.Focus()
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            Dim maDM As Integer = LayMaDanhMucForm()
            Dim kq As KetQuaMonAn = _bus.CapNhatMonAn(_maDangChon, txtTenMon.Text, maDM, nudDonGia.Value, chkHetMon.Checked, txtMoTa.Text)
            If kq.ThanhCong Then
                TaiDanhSachMonAn(_maDangChon)
                HienThiThongBao("✅ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa cập nhật món #{_maDangChon}: {txtTenMon.Text.Trim()}")
            Else
                HienThiThongBao("❌ " & kq.ThongBao, isError:=True)
                txtTenMon.Focus()
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If _maDangChon <= 0 Then
                HienThiThongBao("⚠️ Vui lòng chọn một món ăn trên bảng cần xóa!", isError:=True)
                Return
            End If

            Dim tenHienTai As String = txtTenMon.Text.Trim()
            Dim kq As KetQuaMonAn = _bus.XoaMonAn(_maDangChon, tenHienTai)
            If kq.ThanhCong Then
                TaiDanhSachMonAn()
                HienThiThongBao("🗑️ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa xóa món ăn: {tenHienTai}")
            Else
                HienThiThongBao("🚫 " & kq.ThongBao, isError:=True)
            End If
        End Sub

        ' =========================================================
        ' SỰ KIỆN BỘ LỌC ĐA CHIỀU & ĐIỀU HƯỚNG LIÊN HOÀN
        ' =========================================================

        Private Sub cboLocDanhMuc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocDanhMuc.SelectedIndexChanged
            If _dangNapDuLieu Then Return
            TaiDanhSachMonAn(_maDangChon)
        End Sub

        Private Sub cboLocTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocTrangThai.SelectedIndexChanged
            If _dangNapDuLieu Then Return
            TaiDanhSachMonAn(_maDangChon)
        End Sub

        Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
            If _dangNapDuLieu Then Return
            TaiDanhSachMonAn(_maDangChon)
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            _dangNapDuLieu = True
            If cboLocDanhMuc.Items.Count > 0 Then cboLocDanhMuc.SelectedIndex = 0
            If cboLocTrangThai.Items.Count > 0 Then cboLocTrangThai.SelectedIndex = 0
            txtTimKiem.Clear()
            _dangNapDuLieu = False

            TaiDanhSachMonAn()
            HienThiThongBao("ℹ️ Đã đặt lại bộ lọc và tải toàn bộ danh sách món ăn.", isInfo:=True)
        End Sub

        ''' <summary>
        ''' Mở nhanh màn hình Quản lý Danh mục (frmDanhMuc) và tự động làm mới lại ComboBox Danh mục sau khi đóng.
        ''' </summary>
        Private Sub btnMoDanhMuc_Click(sender As Object, e As EventArgs) Handles btnMoDanhMuc.Click
            Dim maLocDMHienTai As Integer = LayMaDanhMucLoc()
            Dim maFormDMHienTai As Integer = LayMaDanhMucForm()

            Using fDM As New frmDanhMuc()
                fDM.ShowDialog(Me)
            End Using

            NapDanhSachBoLocVaComboBox(maLocDMHienTai, maFormDMHienTai)
            TaiDanhSachMonAn(_maDangChon)
            HienThiThongBao("ℹ️ Đã đồng bộ danh sách Danh mục thực đơn mới nhất.", isInfo:=True)
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmMonAn_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

        ''' <summary>
        ''' Đồng bộ sự kiện thao tác Thực đơn vào bảng Hoạt Động Gần Đây của frmMain (nếu mở từ frmMain).
        ''' </summary>
        Private Sub GhiNhatKyLenMain(noiDung As String)
            Dim fMain As frmMain = TryCast(Me.Owner, frmMain)
            If fMain IsNot Nothing Then
                fMain.GhiNhatKyHoatDong(noiDung)
            End If
        End Sub

    End Class
End Namespace
