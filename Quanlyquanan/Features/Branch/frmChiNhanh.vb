Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO
Imports Quanlyquanan.Core.Helpers

Namespace Features.Branch

    Public Class frmChiNhanh

        Private _dsChiNhanh As New List(Of ChiNhanhDTO)()
        Private _dangChonMoi As Boolean = False

        Private Sub frmChiNhanh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ApDungPhanQuyen()
            NapDanhSachQuanLy()
            NapDanhSachChiNhanh()
        End Sub

        Private Sub ApDungPhanQuyen()
            Me.Tag = "CQ_QUAN_LY_CHI_NHANH"
            btnThem.Tag = "CQ_QUAN_LY_CHI_NHANH"
            btnLuu.Tag = "CQ_QUAN_LY_CHI_NHANH"
            btnXoa.Tag = "CQ_QUAN_LY_CHI_NHANH"
            PhanQuyenHelper.ApDungPhanQuyen(Me)
        End Sub

        Private Sub NapDanhSachQuanLy()
            Try
                Dim dt As DataTable = ChiNhanhBUS.LayDanhSachQuanLy()
                cboQuanLy.DataSource = dt
                cboQuanLy.DisplayMember = "DisplayText"
                cboQuanLy.ValueMember = "NV_Ma"
                cboQuanLy.SelectedIndex = -1
            Catch ex As Exception
                tslStatus.Text = "Lỗi nạp danh sách quản lý: " & ex.Message
            End Try
        End Sub

        Private Sub NapDanhSachChiNhanh()
            Try
                Dim kw As String = txtSearch.Text.Trim()
                Dim st As String = String.Empty
                If cboFilterTrangThai.SelectedIndex > 0 Then
                    st = cboFilterTrangThai.SelectedItem.ToString()
                End If

                _dsChiNhanh = ChiNhanhBUS.LayDanhSach(kw, st)
                dgvChiNhanh.DataSource = Nothing
                dgvChiNhanh.DataSource = _dsChiNhanh
                DinhDangCotGrid()
                CapNhatThanhTrangThai()
            Catch ex As Exception
                tslStatus.Text = "Lỗi nạp chi nhánh: " & ex.Message
            End Try
        End Sub

        Private Sub DinhDangCotGrid()
            If dgvChiNhanh.Columns.Count = 0 Then Return

            AnCacCotKhongCanThiet()
            DatTieuDeCot()
        End Sub

        Private Sub AnCacCotKhongCanThiet()
            Dim hideCols As String() = {"NguoiQuanLy", "MoTa", "Xoa", "DisplayText", "SoBanHienCo", "TrangThai"}
            For Each col In hideCols
                If dgvChiNhanh.Columns.Contains(col) Then
                    dgvChiNhanh.Columns(col).Visible = False
                End If
            Next
        End Sub

        Private Sub DatTieuDeCot()
            If dgvChiNhanh.Columns.Contains("MaCN") Then
                dgvChiNhanh.Columns("MaCN").HeaderText = "Mã"
                dgvChiNhanh.Columns("MaCN").Width = 45
            End If
            If dgvChiNhanh.Columns.Contains("TenCN") Then
                dgvChiNhanh.Columns("TenCN").HeaderText = "Tên Chi Nhánh"
                dgvChiNhanh.Columns("TenCN").Width = 190
            End If
            If dgvChiNhanh.Columns.Contains("DiaChi") Then
                dgvChiNhanh.Columns("DiaChi").HeaderText = "Địa Chỉ"
                dgvChiNhanh.Columns("DiaChi").Width = 240
            End If
            If dgvChiNhanh.Columns.Contains("SoDienThoai") Then
                dgvChiNhanh.Columns("SoDienThoai").HeaderText = "Hotline"
                dgvChiNhanh.Columns("SoDienThoai").Width = 100
            End If
            If dgvChiNhanh.Columns.Contains("TenNguoiQuanLy") Then
                dgvChiNhanh.Columns("TenNguoiQuanLy").HeaderText = "Quản Lý Cơ Sở"
                dgvChiNhanh.Columns("TenNguoiQuanLy").Width = 140
            End If
            If dgvChiNhanh.Columns.Contains("SucChua") Then
                dgvChiNhanh.Columns("SucChua").HeaderText = "Chỗ"
                dgvChiNhanh.Columns("SucChua").Width = 55
            End If
            If dgvChiNhanh.Columns.Contains("GioMoCua") Then
                dgvChiNhanh.Columns("GioMoCua").HeaderText = "Giờ Mở Cửa"
                dgvChiNhanh.Columns("GioMoCua").Width = 110
            End If
            If dgvChiNhanh.Columns.Contains("TrangThaiText") Then
                dgvChiNhanh.Columns("TrangThaiText").HeaderText = "Trạng Thái"
                dgvChiNhanh.Columns("TrangThaiText").Width = 120
            End If
        End Sub

        Private Sub CapNhatThanhTrangThai()
            tslStatus.Text = $"Đang hiển thị {_dsChiNhanh.Count} cơ sở / chi nhánh trực thuộc chuỗi nhà hàng."
        End Sub

        Private Sub dgvChiNhanh_SelectionChanged(sender As Object, e As EventArgs) Handles dgvChiNhanh.SelectionChanged
            If _dangChonMoi Then Return
            If dgvChiNhanh.CurrentRow IsNot Nothing AndAlso dgvChiNhanh.CurrentRow.DataBoundItem IsNot Nothing Then
                Dim dto As ChiNhanhDTO = TryCast(dgvChiNhanh.CurrentRow.DataBoundItem, ChiNhanhDTO)
                If dto IsNot Nothing Then
                    HienThiChiTiet(dto)
                End If
            End If
        End Sub

        Private Sub HienThiChiTiet(dto As ChiNhanhDTO)
            txtMaCN.Text = dto.MaCN.ToString()
            txtTenCN.Text = dto.TenCN
            txtDiaChi.Text = dto.DiaChi
            txtSDT.Text = dto.SoDienThoai
            If dto.NguoiQuanLy.HasValue Then
                cboQuanLy.SelectedValue = dto.NguoiQuanLy.Value
            Else
                cboQuanLy.SelectedIndex = -1
            End If
            nudSucChua.Value = Math.Max(nudSucChua.Minimum, dto.SucChua)
            txtGioMoCua.Text = dto.GioMoCua
            cboTrangThai.SelectedItem = dto.TrangThai
            txtMoTa.Text = dto.MoTa
            lblFormTitle.Text = $"📝 CHI TIẾT CHI NHÁNH #{dto.MaCN}"
        End Sub

        Private Sub btnThem_Click(sender As Object, e As EventArgs) Handles btnThem.Click
            _dangChonMoi = True
            txtMaCN.Text = "(Tự động)"
            txtTenCN.Text = String.Empty
            txtDiaChi.Text = String.Empty
            txtSDT.Text = String.Empty
            cboQuanLy.SelectedIndex = -1
            nudSucChua.Value = 50
            txtGioMoCua.Text = "07:00 - 22:00"
            cboTrangThai.SelectedItem = "Đang mở cửa"
            txtMoTa.Text = String.Empty
            lblFormTitle.Text = "➕ THÊM CHI NHÁNH MỚI"
            txtTenCN.Focus()
        End Sub

        Private Sub btnLuu_Click(sender As Object, e As EventArgs) Handles btnLuu.Click
            Dim dto As New ChiNhanhDTO()
            DocThongTinTuForm(dto)

            Dim thongBao As String = String.Empty
            Dim thanhCong As Boolean = False

            If _dangChonMoi OrElse dto.MaCN = 0 Then
                thanhCong = ChiNhanhBUS.Them(dto, thongBao)
            Else
                thanhCong = ChiNhanhBUS.CapNhat(dto, thongBao)
            End If

            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, If(thanhCong, MessageBoxIcon.Information, MessageBoxIcon.Warning))
            If thanhCong Then
                _dangChonMoi = False
                NapDanhSachChiNhanh()
            End If
        End Sub

        Private Sub DocThongTinTuForm(dto As ChiNhanhDTO)
            Dim ma As Integer = 0
            Integer.TryParse(txtMaCN.Text, ma)
            dto.MaCN = ma
            dto.TenCN = txtTenCN.Text.Trim()
            dto.DiaChi = txtDiaChi.Text.Trim()
            dto.SoDienThoai = txtSDT.Text.Trim()
            If cboQuanLy.SelectedIndex >= 0 AndAlso cboQuanLy.SelectedValue IsNot Nothing Then
                dto.NguoiQuanLy = Convert.ToInt32(cboQuanLy.SelectedValue)
            Else
                dto.NguoiQuanLy = Nothing
            End If
            dto.SucChua = Convert.ToInt32(nudSucChua.Value)
            dto.GioMoCua = txtGioMoCua.Text.Trim()
            dto.TrangThai = If(cboTrangThai.SelectedItem IsNot Nothing, cboTrangThai.SelectedItem.ToString(), "Đang mở cửa")
            dto.MoTa = txtMoTa.Text.Trim()
        End Sub

        Private Sub btnXoa_Click(sender As Object, e As EventArgs) Handles btnXoa.Click
            Dim ma As Integer = 0
            If Not Integer.TryParse(txtMaCN.Text, ma) OrElse ma <= 0 Then
                MessageBox.Show("Vui lòng chọn một chi nhánh trong danh sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim xacNhan = MessageBox.Show($"Bạn có chắc chắn muốn xóa chi nhánh '{txtTenCN.Text}'?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If xacNhan = DialogResult.Yes Then
                Dim thongBao As String = String.Empty
                Dim thanhCong As Boolean = ChiNhanhBUS.Xoa(ma, thongBao)
                MessageBox.Show(thongBao, "Kết quả", MessageBoxButtons.OK, If(thanhCong, MessageBoxIcon.Information, MessageBoxIcon.Warning))
                If thanhCong Then
                    btnThem_Click(Nothing, Nothing)
                    NapDanhSachChiNhanh()
                End If
            End If
        End Sub

        Private Sub btnLamMoi_Click(sender As Object, e As EventArgs) Handles btnLamMoi.Click
            _dangChonMoi = False
            txtSearch.Text = String.Empty
            cboFilterTrangThai.SelectedIndex = 0
            NapDanhSachChiNhanh()
        End Sub

        Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
            NapDanhSachChiNhanh()
        End Sub

        Private Sub cboFilterTrangThai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilterTrangThai.SelectedIndexChanged
            NapDanhSachChiNhanh()
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

    End Class

End Namespace
