Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms
Imports Quanlyquanan.Core.BUS
Imports Quanlyquanan.Core.DTO

Namespace Features.Security

    ''' <summary>
    ''' Màn hình Quản Lý Vai Trò & Phân Quyền Người Dùng Động (Mục 3.6 Checklist Đồ Án).
    ''' </summary>
    Public Class frmPhanQuyen

        Private _danhSachVaiTro As New List(Of VaiTroDTO)()
        Private _danhSachQuyen As New List(Of QuyenDTO)()
        Private _maVaiTroHienTai As Integer = 2

        Private Sub frmPhanQuyen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KhoiTaoCotBangVaiTro()
            KhoiTaoCotBangQuyen()
            TaiDanhSachVaiTro()
        End Sub

        Private Sub KhoiTaoCotBangVaiTro()
            dgvVaiTro.Columns.Clear()
            dgvVaiTro.Columns.Add("VT_Ma", "Mã")
            dgvVaiTro.Columns.Add("VT_Ten", "Tên Vai Trò")
            dgvVaiTro.Columns.Add("SoLuongQuyen", "Số Quyền")

            dgvVaiTro.Columns("VT_Ma").Width = 60
            dgvVaiTro.Columns("VT_Ten").Width = 200
            dgvVaiTro.Columns("SoLuongQuyen").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End Sub

        Private Sub KhoiTaoCotBangQuyen()
            dgvQuyen.Columns.Clear()
            Dim colCheck As New DataGridViewCheckBoxColumn() With {
                .Name = "DuocCap", .HeaderText = "Cấp", .Width = 50
            }
            dgvQuyen.Columns.Add(colCheck)
            dgvQuyen.Columns.Add("Q_Nhom", "Phân Hệ / Nhóm")
            dgvQuyen.Columns.Add("Q_Ten", "Tên Chức Năng")
            dgvQuyen.Columns.Add("Q_Tag", "Mã Tag")
            dgvQuyen.Columns.Add("Q_MoTa", "Mô Tả Chi Tiết")

            dgvQuyen.Columns("Q_Nhom").Width = 180
            dgvQuyen.Columns("Q_Ten").Width = 220
            dgvQuyen.Columns("Q_Tag").Width = 160
            dgvQuyen.Columns("Q_MoTa").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

            For Each col As DataGridViewColumn In dgvQuyen.Columns
                If col.Name <> "DuocCap" Then col.ReadOnly = True
            Next
        End Sub

        Private Sub TaiDanhSachVaiTro()
            _danhSachVaiTro = PhanQuyenBUS.LayDanhSachVaiTro()
            dgvVaiTro.Rows.Clear()
            For Each vt In _danhSachVaiTro
                dgvVaiTro.Rows.Add(vt.VT_Ma, vt.VT_Ten, $"{vt.SoLuongQuyen} quyền")
            Next

            If dgvVaiTro.Rows.Count > 0 Then
                dgvVaiTro.Rows(0).Selected = True
                _maVaiTroHienTai = _danhSachVaiTro(0).VT_Ma
                TaiDanhSachQuyen(_maVaiTroHienTai)
            End If
        End Sub

        Private Sub dgvVaiTro_SelectionChanged(sender As Object, e As EventArgs) Handles dgvVaiTro.SelectionChanged
            If dgvVaiTro.CurrentRow Is Nothing Then Return
            _maVaiTroHienTai = Convert.ToInt32(dgvVaiTro.CurrentRow.Cells("VT_Ma").Value)
            Dim tenVT = dgvVaiTro.CurrentRow.Cells("VT_Ten").Value.ToString()
            lblCurrentRole.Text = $"Đang cấu hình: {tenVT} (#VT{_maVaiTroHienTai})"
            TaiDanhSachQuyen(_maVaiTroHienTai)
        End Sub

        Private Sub TaiDanhSachQuyen(maVT As Integer)
            _danhSachQuyen = PhanQuyenBUS.LayDanhSachQuyen(maVT)
            dgvQuyen.Rows.Clear()
            For Each q In _danhSachQuyen
                Dim idx = dgvQuyen.Rows.Add(q.DuocCap, q.Q_Nhom, q.Q_Ten, q.Q_Tag, q.Q_MoTa)
                If q.DuocCap Then
                    dgvQuyen.Rows(idx).Cells("Q_Ten").Style.ForeColor = Color.FromArgb(74, 222, 128)
                    dgvQuyen.Rows(idx).Cells("Q_Ten").Style.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
                End If
            Next
        End Sub

        Private Sub btnChonTatCa_Click(sender As Object, e As EventArgs) Handles btnChonTatCa.Click
            DatTrangThaiToanBoQuyen(True)
        End Sub

        Private Sub btnBoChonTatCa_Click(sender As Object, e As EventArgs) Handles btnBoChonTatCa.Click
            DatTrangThaiToanBoQuyen(False)
        End Sub

        Private Sub DatTrangThaiToanBoQuyen(trangThai As Boolean)
            For Each row As DataGridViewRow In dgvQuyen.Rows
                row.Cells("DuocCap").Value = trangThai
            Next
        End Sub

        Private Sub btnLuuPhanQuyen_Click(sender As Object, e As EventArgs) Handles btnLuuPhanQuyen.Click
            Dim dsChon As New List(Of Integer)()
            For i As Integer = 0 To dgvQuyen.Rows.Count - 1
                Dim dc = Convert.ToBoolean(dgvQuyen.Rows(i).Cells("DuocCap").Value)
                If dc AndAlso i < _danhSachQuyen.Count Then
                    dsChon.Add(_danhSachQuyen(i).Q_Ma)
                End If
            Next

            Dim msg As String = ""
            If PhanQuyenBUS.LuuPhanQuyen(_maVaiTroHienTai, dsChon, msg) Then
                MessageBox.Show(msg, "Phân Quyền Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaiDanhSachVaiTro()
            Else
                MessageBox.Show(msg, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Sub

        Private Sub btnThemVaiTro_Click(sender As Object, e As EventArgs) Handles btnThemVaiTro.Click
            Dim ten = txtTenVT.Text.Trim()
            Dim moTa = txtMoTaVT.Text.Trim()
            Dim msg As String = ""
            If PhanQuyenBUS.ThemVaiTro(ten, moTa, msg) Then
                MessageBox.Show(msg, "Thêm Vai Trò", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtTenVT.Clear()
                txtMoTaVT.Clear()
                TaiDanhSachVaiTro()
            Else
                MessageBox.Show(msg, "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End Sub

        Private Sub btnDong_Click(sender As Object, e As EventArgs) Handles btnDong.Click
            Me.Close()
        End Sub

        Private Sub frmPhanQuyen_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            ElseIf e.KeyCode = Keys.F2 Then
                btnLuuPhanQuyen.PerformClick()
            ElseIf e.KeyCode = Keys.F3 Then
                txtTenVT.Focus()
            End If
        End Sub

    End Class

End Namespace
