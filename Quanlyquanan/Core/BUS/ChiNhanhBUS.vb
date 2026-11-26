Imports System
Imports System.Text.RegularExpressions
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Xử lý Quy tắc Nghiệp vụ (BUS) cho phân hệ Chi Nhánh Chuỗi Nhà Hàng.
    ''' </summary>
    Public Class ChiNhanhBUS

        Public Shared Function KiemTraHopLe(dto As ChiNhanhDTO, ByRef thongBaoLoi As String) As Boolean
            If dto Is Nothing Then
                thongBaoLoi = "Dữ liệu chi nhánh không hợp lệ."
                Return False
            End If

            If String.IsNullOrWhiteSpace(dto.TenCN) Then
                thongBaoLoi = "Tên chi nhánh không được để trống."
                Return False
            End If

            If String.IsNullOrWhiteSpace(dto.DiaChi) Then
                thongBaoLoi = "Địa chỉ chi nhánh không được để trống."
                Return False
            End If

            If dto.SucChua <= 0 Then
                thongBaoLoi = "Sức chứa khách phải là số nguyên dương lớn hơn 0."
                Return False
            End If

            If Not String.IsNullOrWhiteSpace(dto.SoDienThoai) Then
                Dim sdtClean As String = dto.SoDienThoai.Trim()
                If Not Regex.IsMatch(sdtClean, "^(0[3|5|7|8|9])[0-9]{8}$") AndAlso Not Regex.IsMatch(sdtClean, "^02[0-9]{8,9}$") Then
                    thongBaoLoi = "Số điện thoại hotline không đúng định dạng Việt Nam."
                    Return False
                End If
            End If

            If ChiNhanhDAO.KiemTraTrungTen(dto.TenCN, dto.MaCN) Then
                thongBaoLoi = $"Tên chi nhánh '{dto.TenCN.Trim()}' đã tồn tại trong hệ thống."
                Return False
            End If

            thongBaoLoi = String.Empty
            Return True
        End Function

        Public Shared Function LayDanhSach(Optional tuKhoa As String = "", Optional trangThai As String = "") As List(Of ChiNhanhDTO)
            Return ChiNhanhDAO.LayDanhSach(tuKhoa, trangThai)
        End Function

        Public Shared Function Them(dto As ChiNhanhDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, thongBao) Then
                Return False
            End If

            Dim idMoi As Integer = ChiNhanhDAO.Them(dto)
            If idMoi > 0 Then
                dto.MaCN = idMoi
                thongBao = $"Thêm chi nhánh '{dto.TenCN}' thành công (Mã: {idMoi})."
                Return True
            End If

            thongBao = "Không thể thêm chi nhánh vào cơ sở dữ liệu."
            Return False
        End Function

        Public Shared Function CapNhat(dto As ChiNhanhDTO, ByRef thongBao As String) As Boolean
            If dto.MaCN <= 0 Then
                thongBao = "Mã chi nhánh không hợp lệ để cập nhật."
                Return False
            End If

            If Not KiemTraHopLe(dto, thongBao) Then
                Return False
            End If

            If ChiNhanhDAO.CapNhat(dto) Then
                thongBao = $"Cập nhật thông tin chi nhánh '{dto.TenCN}' thành công."
                Return True
            End If

            thongBao = "Không thể cập nhật chi nhánh trong cơ sở dữ liệu."
            Return False
        End Function

        Public Shared Function Xoa(maCN As Integer, ByRef thongBao As String) As Boolean
            If maCN <= 0 Then
                thongBao = "Mã chi nhánh không hợp lệ để xóa."
                Return False
            End If

            Dim cnHienTai As ChiNhanhDTO = ChiNhanhDAO.LayTheoMa(maCN)
            If cnHienTai Is Nothing Then
                thongBao = "Chi nhánh không tồn tại hoặc đã bị xóa trước đó."
                Return False
            End If

            If ChiNhanhDAO.Xoa(maCN) Then
                thongBao = $"Đã xóa chi nhánh '{cnHienTai.TenCN}' thành công."
                Return True
            End If

            thongBao = "Không thể xóa chi nhánh trong cơ sở dữ liệu."
            Return False
        End Function

        Public Shared Function LayDanhSachQuanLy() As DataTable
            Return ChiNhanhDAO.LayDanhSachQuanLy()
        End Function

    End Class

End Namespace
