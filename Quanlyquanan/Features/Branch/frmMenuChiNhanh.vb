Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Helpers

Namespace Features.Branch

    Public Class frmMenuChiNhanh

        Private _dsMenuChiNhanh As New List(Of ChiNhanhMenuDTO)()
        Private _dsChiNhanh As New List(Of ChiNhanhDTO)()
        Private _dangLoad As Boolean = True

        Private Sub frmMenuChiNhanh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ApDungPhanQuyen()
            NapDanhSachChiNhanh()
            NapDanhSachMenuMaster()
            _dangLoad = False
            If cboMainBranch.Items.Count > 0 Then
                cboMainBranch.SelectedIndex = 0
            End If
            NapDuLieuLuoi()
        End Sub

        Private Sub ApDungPhanQuyen()
            Me.Tag = "CQ_QUAN_LY_THUC_DON"
            btnGanMoi.Tag = "CQ_QUAN_LY_THUC_DON"
            btnLuu.Tag = "CQ_QUAN_LY_THUC_DON"
            btnGo.Tag = "CQ_QUAN_LY_THUC_DON"
            PhanQuyenHelper.ApDungPhanQuyen(Me)
        End Sub

        Private Sub NapDanhSachChiNhanh()
            Try
                _dsChiNhanh = ChiNhanhBUS.LayDanhSach()
                cboMainBranch.DataSource = _dsChiNhanh
                cboMainBranch.DisplayMember = "DisplayText"
                cboMainBranch.ValueMember = "MaCN"
            Catch ex As Exception
                tslStatus.Text = "Lỗi nạp danh sách chi nhánh: " & ex.Message
            End Try
        End Sub

        Private Sub NapDanhSachMenuMaster()
            Try
                Dim dt As DataTable = ChiNhanhMenuBUS.LayDanhSachMenuMaster()
                cboMenuPool.DataSource = dt
                cboMenuPool.DisplayMember = "MN_Ten"
                cboMenuPool.ValueMember = "MN_Ma"
                cboMenuPool.SelectedIndex = -1
            Catch ex As Exception
                tslStatus.Text = "Lỗi nạp danh mục thực đơn: " & ex.Message
            End Try
        End Sub

        Private Function LayMaChiNhanhDangChon() As Integer
            If cboMainBranch.SelectedValue IsNot Nothing AndAlso TypeOf cboMainBranch.SelectedValue Is Integer Then
                Return Convert.ToInt32(cboMainBranch.SelectedValue)
            ElseIf cboMainBranch.SelectedItem IsNot Nothing AndAlso TypeOf cboMainBranch.SelectedItem Is ChiNhanhDTO Then
                Return DirectCast(cboMainBranch.SelectedItem, ChiNhanhDTO).MaCN
            End If
            Return 0
        End Function

        Private Sub NapDuLieuLuoi()
            If _dangLoad Then Return
            Try
                Dim maCN As Integer = LayMaChiNhanhDangChon()
                Dim kw As String = txtSearch.Text.Trim()
                Dim st As String = String.Empty
                If cboFilterTrangThai.SelectedIndex > 0 Then
                    st = cboFilterTrangThai.SelectedItem.ToString()
                End If

                _dsMenuChiNhanh = ChiNhanhMenuBUS.LayDanhSachTheoChiNhanh(maCN, kw, st)
                dgvMenuChiNhanh.DataSource = Nothing
                dgvMenuChiNhanh.DataSource = _dsMenuChiNhanh
                DinhDangCotLuoi()
                tslStatus.Text = $"Chi nhánh đang chọn: {_dsMenuChiNhanh.Count} thực đơn phân bổ | Tổng số chi nhánh: {_dsChiNhanh.Count}"
            Catch ex As Exception
                tslStatus.Text = "Lỗi nạp dữ liệu phân bổ: " & ex.Message
            End Try
        End Sub

        Private Sub DinhDangCotLuoi()
            If dgvMenuChiNhanh.Columns.Count = 0 Then Return
            With dgvMenuChiNhanh
                .Columns("MaCNM").HeaderText = "Mã"
                .Columns("MaCNM").Width = 60
                .Columns("TenMenu").HeaderText = "Tên thực đơn (Menu)"
                .Columns("TenMenu").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("LoaiMenu").HeaderText = "Loại Menu"
                .Columns("LoaiMenu").Width = 110
                .Columns("SoMonAn").HeaderText = "Số món"
                .Columns("SoMonAn").Width = 80
                .Columns("NgayBatDau").HeaderText = "Bắt đầu"
                .Columns("NgayBatDau").DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns("NgayBatDau").Width = 100
                .Columns("NgayKetThucText").HeaderText = "Kết thúc"
                .Columns("NgayKetThucText").Width = 110
                .Columns("TrangThaiText").HeaderText = "Trạng thái"
                .Columns("TrangThaiText").Width = 130

                .Columns("MaChiNhanh").Visible = False
                .Columns("TenChiNhanh").Visible = False
                .Columns("MaMenu").Visible = False
                .Columns("NgayKetThuc").Visible = False
                .Columns("GhiChu").Visible = False
                .Columns("TrangThai").Visible = False
                .Columns("Xoa").Visible = False
                .Columns("DisplayText").Visible = False
            End With
        End Sub

        Private Sub cboMainBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMainBranch.SelectedIndexChanged
            If _dangLoad Then Return
            CapNhatThongTinChiNhanh()
            NapDuLieuLuoi()
            ResetFormNhapLieu()
        End Sub

        Private Sub CapNhatThongTinChiNhanh()
            Dim cn As ChiNhanhDTO = TryCast(cboMainBranch.SelectedItem, ChiNhanhDTO)
            If cn IsNot Nothing Then
                lblBranchDetail.Text = $"📍 {cn.DiaChi} | ☎️ {cn.SoDienThoai} | Sức chứa: {cn.SucChua} chỗ | {cn.TrangThaiText}"
            Else
                lblBranchDetail.Text = "📍 Vui lòng chọn cơ sở chi nhánh để xem thực đơn áp dụng"
            End If
        End Sub

        Private Sub dgvMenuChiNhanh_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenuChiNhanh.SelectionChanged
            If dgvMenuChiNhanh.CurrentRow Is Nothing Then Return
            Dim item As ChiNhanhMenuDTO = TryCast(dgvMenuChiNhanh.CurrentRow.DataBoundItem, ChiNhanhMenuDTO)
            If item IsNot Nothing Then
                HienThiChiTiet(item)
            End If
        End Sub

        Private Sub HienThiChiTiet(item As ChiNhanhMenuDTO)
            txtMaCNM.Text = item.MaCNM.ToString()
            cboMenuPool.SelectedValue = item.MaMenu
            dtpNgayBD.Value = item.NgayBatDau
            If item.NgayKetThuc.HasValue Then
                chkCoNgayKT.Checked = True
                dtpNgayKT.Value = item.NgayKetThuc.Value
                dtpNgayKT.Enabled = True
            Else
                chkCoNgayKT.Checked = False
                dtpNgayKT.Value = Date.Today.AddMonths(1)
                dtpNgayKT.Enabled = False
            End If
            cboTrangThai.SelectedItem = item.TrangThai
            txtGhiChu.Text = item.GhiChu
        End Sub

        Private Sub chkCoNgayKT_CheckedChanged(sender As Object, e As EventArgs) Handles chkCoNgayKT.CheckedChanged
            dtpNgayKT.Enabled = chkCoNgayKT.Checked
        End Sub

        Private Sub btnGanMoi_Click(sender As Object, e As EventArgs) Handles btnGanMoi.Click
            Dim dto As New ChiNhanhMenuDTO()
            ThuThapDuLieuForm(dto)
            Dim thongBao As String = String.Empty

            If ChiNhanhMenuBUS.GanMenu(dto, thongBao) Then
                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NapDuLieuLuoi()
                ChonDongTrenLuoi(dto.MaCNM)
            Else
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
            If String.IsNullOrWhiteSpace(txtMaCNM.Text) Then
                MessageBox.Show("Vui lòng chọn một thực đơn đã phân bổ để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim dto As New ChiNhanhMenuDTO()
            dto.MaCNM = Convert.ToInt32(txtMaCNM.Text)
            ThuThapDuLieuForm(dto)
            Dim thongBao As String = String.Empty

            If ChiNhanhMenuBUS.CapNhat(dto, thongBao) Then
                MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                NapDuLieuLuoi()
                ChonDongTrenLuoi(dto.MaCNM)
            Else
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub ThuThapDuLieuForm(dto As ChiNhanhMenuDTO)
            dto.MaChiNhanh = LayMaChiNhanhDangChon()
            If cboMenuPool.SelectedValue IsNot Nothing Then
                dto.MaMenu = Convert.ToInt32(cboMenuPool.SelectedValue)
            End If
            dto.NgayBatDau = dtpNgayBD.Value.Date
            If chkCoNgayKT.Checked Then
                dto.NgayKetThuc = dtpNgayKT.Value.Date
            Else
                dto.NgayKetThuc = Nothing
            End If
            dto.TrangThai = If(cboTrangThai.SelectedItem IsNot Nothing, cboTrangThai.SelectedItem.ToString(), "Đang áp dụng")
            dto.GhiChu = txtGhiChu.Text.Trim()
        End Sub

        Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click
            If String.IsNullOrWhiteSpace(txtMaCNM.Text) Then
                MessageBox.Show("Vui lòng chọn thực đơn cần gỡ khỏi chi nhánh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim maCNM As Integer = Convert.ToInt32(txtMaCNM.Text)
            Dim hoi As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn gỡ thực đơn này khỏi chi nhánh không?", "Xác nhận gỡ", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If hoi = DialogResult.Yes Then
                Dim thongBao As String = String.Empty
                If ChiNhanhMenuBUS.GoMenu(maCNM, thongBao) Then
                    MessageBox.Show(thongBao, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    NapDuLieuLuoi()
                    ResetFormNhapLieu()
                Else
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            ResetFormNhapLieu()
        End Sub

        Private Sub ResetFormNhapLieu()
            txtMaCNM.Text = String.Empty
            cboMenuPool.SelectedIndex = -1
            dtpNgayBD.Value = Date.Today
            chkCoNgayKT.Checked = False
            dtpNgayKT.Value = Date.Today.AddMonths(1)
            dtpNgayKT.Enabled = False
            cboTrangThai.SelectedIndex = 0
            txtGhiChu.Text = String.Empty
        End Sub

        Private Sub ChonDongTrenLuoi(maCNM As Integer)
            For Each row As DataGridViewRow In dgvMenuChiNhanh.Rows
                Dim item As ChiNhanhMenuDTO = TryCast(row.DataBoundItem, ChiNhanhMenuDTO)
                If item IsNot Nothing AndAlso item.MaCNM = maCNM Then
                    row.Selected = True
                    dgvMenuChiNhanh.CurrentCell = row.Cells(0)
                    Exit For
                End If
            Next
        End Sub

        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
            NapDuLieuLuoi()
        End Sub

        Private Sub cboFilterTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterTrangThai.SelectedIndexChanged
            If _dangLoad Then Return
            NapDuLieuLuoi()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

    End Class

End Namespace
