Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Features.Main

Namespace Features.Menu
    ''' <summary>
    ''' Màn hình 1 (Checklist Ưu tiên): Quản lý Danh mục Thực đơn (Bảng DanhMuc).
    ''' Bước 3/5: Xử lý toàn bộ nghiệp vụ Thêm, Sửa, Xóa mềm (chặn FK khi có món), Tìm kiếm và Thống kê KPI.
    ''' </summary>
    Public Class frmDanhMuc

        Private ReadOnly _bus As New DanhMucBUS()
        Private _danhSachHienTai As New List(Of DanhMucDTO)()
        Private _maDangChon As Integer = 0
        Private _dangNapDuLieu As Boolean = False

        ''' <summary>
        ''' Cờ báo hiệu người dùng bấm nút "🍜 Mở Quản lý Món ăn ➔" để điều hướng sang Màn hình 2.
        ''' </summary>
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)>
        Public Property MoTiepManHinhMonAn As Boolean = False

        Private Sub frmDanhMuc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            CauHinhGiaoDienBang()
            TaiDanhSachDanhMuc()
        End Sub

        ''' <summary>
        ''' Định dạng màu sắc Header, dòng xen kẽ và căn lề cột trên dgvDanhMuc.
        ''' </summary>
        Private Sub CauHinhGiaoDienBang()
            With dgvDanhMuc
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

            colMaDM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaDM.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colMaDM.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colTenDM.DefaultCellStyle.Font = New Font("Segoe UI", 9.5F, FontStyle.Bold)

            colSoLuongMon.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoLuongMon.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            colSoLuongMon.DefaultCellStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        End Sub

        ''' <summary>
        ''' Tải danh sách danh mục từ CSDL, cập nhật 3 thẻ KPI và chọn dòng tương ứng.
        ''' </summary>
        Public Sub TaiDanhSachDanhMuc(Optional maUuTienChon As Integer = 0)
            Try
                _dangNapDuLieu = True
                Dim tuKhoa As String = txtTimKiem.Text.Trim()
                _danhSachHienTai = _bus.LayDanhSachDanhMuc(tuKhoa)

                dgvDanhMuc.DataSource = Nothing
                dgvDanhMuc.DataSource = _danhSachHienTai

                CapNhatThongKeKpi()
                _dangNapDuLieu = False

                If _danhSachHienTai.Count > 0 Then
                    Dim indexChon As Integer = 0
                    If maUuTienChon > 0 Then
                        For i As Integer = 0 To _danhSachHienTai.Count - 1
                            If _danhSachHienTai(i).MaDanhMuc = maUuTienChon Then
                                indexChon = i
                                Exit For
                            End If
                        Next
                    End If

                    dgvDanhMuc.ClearSelection()
                    dgvDanhMuc.Rows(indexChon).Selected = True
                    HienThiChiTiet(_danhSachHienTai(indexChon))
                Else
                    DatCheDoThemMoi(giuThongBao:=True)
                End If
            Catch ex As Exception
                _dangNapDuLieu = False
                HienThiThongBao("❌ Lỗi tải danh sách danh mục: " & ex.Message, isError:=True)
            End Try
        End Sub

        ''' <summary>
        ''' Cập nhật số liệu trên 3 thẻ KPI (Tổng số danh mục, Tổng số món, Danh mục trống).
        ''' </summary>
        Private Sub CapNhatThongKeKpi()
            Dim toanBo As List(Of DanhMucDTO) = If(String.IsNullOrWhiteSpace(txtTimKiem.Text),
                                                   _danhSachHienTai,
                                                   _bus.LayDanhSachDanhMuc(""))
            Dim tongDM As Integer = toanBo.Count
            Dim tongMon As Integer = toanBo.Sum(Function(x) x.SoLuongMon)
            Dim dmTrong As Integer = toanBo.Where(Function(x) x.SoLuongMon = 0).Count()

            lblKpiTongDMValue.Text = $"{tongDM} nhóm"
            lblKpiTongMonValue.Text = $"{tongMon} món"
            lblKpiDMTrongValue.Text = $"{dmTrong} nhóm"
        End Sub

        ''' <summary>
        ''' Đổ thông tin của 1 DanhMucDTO lên khung nhập liệu bên trái.
        ''' </summary>
        Private Sub HienThiChiTiet(item As DanhMucDTO)
            If item Is Nothing Then Return
            _maDangChon = item.MaDanhMuc
            txtMaDM.Text = item.MaDanhMuc.ToString()
            txtTenDM.Text = item.TenDanhMuc
            txtMoTa.Text = item.MoTa

            lblModeBadge.Text = $"Chế độ: Đang chọn #{item.MaDanhMuc}"
            lblModeBadge.BackColor = Color.FromArgb(239, 246, 255)
            lblModeBadge.ForeColor = Color.FromArgb(29, 78, 216)

            lblThongKeMon.Text = $"🔗 Số món ăn thuộc danh mục này: {item.SoLuongMon} món ăn"
            If item.SoLuongMon > 0 Then
                lblThongKeMon.ForeColor = Color.FromArgb(21, 128, 61)
            Else
                lblThongKeMon.ForeColor = Color.FromArgb(180, 83, 9)
            End If
        End Sub

        ''' <summary>
        ''' Đưa khung nhập liệu về trạng thái Thêm mới.
        ''' </summary>
        Public Sub DatCheDoThemMoi(Optional giuThongBao As Boolean = False)
            _maDangChon = 0
            txtMaDM.Text = "Tự động (IDENTITY)"
            txtTenDM.Clear()
            txtMoTa.Clear()

            lblModeBadge.Text = "Chế độ: Thêm mới"
            lblModeBadge.BackColor = Color.FromArgb(220, 252, 231)
            lblModeBadge.ForeColor = Color.FromArgb(21, 128, 61)

            lblThongKeMon.Text = "🔗 Số món ăn thuộc danh mục này: 0 món (Danh mục mới)"
            lblThongKeMon.ForeColor = Color.FromArgb(100, 116, 139)

            If dgvDanhMuc.Rows.Count > 0 Then
                _dangNapDuLieu = True
                dgvDanhMuc.ClearSelection()
                _dangNapDuLieu = False
            End If

            If Not giuThongBao Then
                HienThiThongBao("ℹ️ Đã làm mới ô nhập. Nhập Tên danh mục rồi bấm [➕ Thêm mới].", isError:=False, isInfo:=True)
            End If
            txtTenDM.Focus()
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
        ''' Định dạng hiển thị cột Mã DM (#1, #2) và cột Số món ("3 món") trên lưới.
        ''' </summary>
        Private Sub dgvDanhMuc_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDanhMuc.CellFormatting
            If e.RowIndex < 0 OrElse e.Value Is Nothing Then Return

            Dim colName As String = dgvDanhMuc.Columns(e.ColumnIndex).Name
            If colName = "colMaDM" Then
                e.Value = $"#{e.Value}"
                e.FormattingApplied = True
            ElseIf colName = "colSoLuongMon" Then
                Dim soMon As Integer = 0
                Integer.TryParse(e.Value.ToString(), soMon)
                e.Value = $"{soMon} món"
                If soMon > 0 Then
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61)
                Else
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9)
                End If
                e.FormattingApplied = True
            ElseIf colName = "colMoTa" Then
                If String.IsNullOrWhiteSpace(e.Value.ToString()) Then
                    e.Value = "—"
                    e.FormattingApplied = True
                End If
            End If
        End Sub

        Private Sub dgvDanhMuc_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDanhMuc.SelectionChanged
            If _dangNapDuLieu Then Return
            If dgvDanhMuc.CurrentRow IsNot Nothing AndAlso dgvDanhMuc.CurrentRow.Selected Then
                Dim item As DanhMucDTO = TryCast(dgvDanhMuc.CurrentRow.DataBoundItem, DanhMucDTO)
                If item IsNot Nothing Then
                    HienThiChiTiet(item)
                End If
            End If
        End Sub

        Private Sub dgvDanhMuc_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDanhMuc.CellClick
            If e.RowIndex < 0 Then Return
            Dim item As DanhMucDTO = TryCast(dgvDanhMuc.Rows(e.RowIndex).DataBoundItem, DanhMucDTO)
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
            Dim kq As KetQuaDanhMuc = _bus.ThemDanhMuc(txtTenDM.Text, txtMoTa.Text)
            If kq.ThanhCong Then
                TaiDanhSachDanhMuc(kq.MaDanhMuc)
                HienThiThongBao("✅ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa thêm danh mục thực đơn: {txtTenDM.Text.Trim()}")
            Else
                HienThiThongBao("❌ " & kq.ThongBao, isError:=True)
                txtTenDM.Focus()
            End If
        End Sub

        Private Sub btnCapNhat_Click(sender As Object, e As EventArgs) Handles btnCapNhat.Click
            Dim kq As KetQuaDanhMuc = _bus.CapNhatDanhMuc(_maDangChon, txtTenDM.Text, txtMoTa.Text)
            If kq.ThanhCong Then
                TaiDanhSachDanhMuc(_maDangChon)
                HienThiThongBao("✅ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa cập nhật danh mục #{_maDangChon}: {txtTenDM.Text.Trim()}")
            Else
                HienThiThongBao("❌ " & kq.ThongBao, isError:=True)
                txtTenDM.Focus()
            End If
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            If _maDangChon <= 0 Then
                HienThiThongBao("⚠️ Vui lòng chọn một danh mục trên bảng cần xóa!", isError:=True)
                Return
            End If

            Dim tenHienTai As String = txtTenDM.Text.Trim()
            Dim kq As KetQuaDanhMuc = _bus.XoaDanhMuc(_maDangChon, tenHienTai)
            If kq.ThanhCong Then
                TaiDanhSachDanhMuc()
                HienThiThongBao("🗑️ " & kq.ThongBao, isError:=False)
                GhiNhatKyLenMain($"Chủ quán vừa xóa danh mục thực đơn: {tenHienTai}")
            Else
                HienThiThongBao("🚫 " & kq.ThongBao, isError:=True)
            End If
        End Sub

        ' =========================================================
        ' SỰ KIỆN TÌM KIẾM & ĐIỀU HƯỚNG
        ' =========================================================

        Private Sub btnTimKiem_Click(sender As Object, e As EventArgs) Handles btnTimKiem.Click
            TaiDanhSachDanhMuc(_maDangChon)
        End Sub

        Private Sub txtTimKiem_TextChanged(sender As Object, e As EventArgs) Handles txtTimKiem.TextChanged
            TaiDanhSachDanhMuc(_maDangChon)
        End Sub

        Private Sub btnTaiLai_Click(sender As Object, e As EventArgs) Handles btnTaiLai.Click
            txtTimKiem.Clear()
            TaiDanhSachDanhMuc()
            HienThiThongBao("ℹ️ Đã tải lại toàn bộ danh sách danh mục thực đơn.", isInfo:=True)
        End Sub

        Private Sub btnMoMonAn_Click(sender As Object, e As EventArgs) Handles btnMoMonAn.Click
            MoTiepManHinhMonAn = True
            MessageBox.Show(
                "Đã lưu trạng thái Danh mục Thực đơn!" & Environment.NewLine &
                "Hệ thống sẵn sàng chuyển sang Màn hình 2: Quản lý Món ăn (frmMonAn).",
                "Điều hướng Thực đơn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmDanhMuc_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End Sub

        ''' <summary>
        ''' Đồng bộ sự kiện thao tác Danh mục vào bảng Hoạt Động Gần Đây của frmMain (nếu mở từ frmMain).
        ''' </summary>
        Private Sub GhiNhatKyLenMain(noiDung As String)
            Dim fMain As frmMain = TryCast(Me.Owner, frmMain)
            If fMain IsNot Nothing Then
                fMain.GhiNhatKyHoatDong(noiDung)
            End If
        End Sub

    End Class
End Namespace
