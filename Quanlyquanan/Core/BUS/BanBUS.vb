Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Quản lý Bàn Ăn (Ban).
    ''' Kiểm tra số thứ tự, sức chứa, chống trùng STT, bảo vệ phiên phục vụ và khôi phục xóa mềm.
    ''' </summary>
    Public Class BanBUS

        ''' <summary>
        ''' Lấy danh sách bàn ăn theo từ khóa, khu vực và trạng thái.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional khuVuc As String = "",
                                           Optional trangThai As Integer = -1) As List(Of BanDTO)
            Return BanDAO.LayDanhSach(tuKhoa, khuVuc, trangThai)
        End Function

        ''' <summary>
        ''' Lấy danh sách tất cả các khu vực bàn hiện có trong hệ thống.
        ''' </summary>
        Public Shared Function LayDanhSachKhuVuc() As List(Of String)
            Return BanDAO.LayDanhSachKhuVuc()
        End Function

        ''' <summary>
        ''' Kiểm tra tính hợp lệ của dữ liệu bàn trước khi Thêm / Cập nhật.
        ''' </summary>
        Private Shared Function KiemTraHopLe(dto As BanDTO, isUpdate As Boolean, ByRef thongBao As String) As Boolean
            If dto Is Nothing Then
                thongBao = "Dữ liệu bàn ăn không hợp lệ!"
                Return False
            End If

            If isUpdate AndAlso dto.MaBan <= 0 Then
                thongBao = "Vui lòng chọn một bàn từ danh sách bên phải trước khi cập nhật!"
                Return False
            End If

            If dto.SoThuTu <= 0 Then
                thongBao = "Số thứ tự bàn phải là số nguyên dương lớn hơn 0!"
                Return False
            End If

            Dim ten As String = If(dto.TenBan, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(ten) Then
                thongBao = "Tên bàn ăn không được để trống!"
                Return False
            End If

            If ten.Length > 50 Then
                thongBao = "Tên bàn ăn không được vượt quá 50 ký tự!"
                Return False
            End If

            Dim kv As String = If(dto.KhuVuc, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(kv) Then
                thongBao = "Vui lòng chọn hoặc nhập khu vực cho bàn ăn!"
                Return False
            End If

            If kv.Length > 50 Then
                thongBao = "Tên khu vực không được vượt quá 50 ký tự!"
                Return False
            End If

            If dto.SoNguoiToiDa <= 0 Then
                thongBao = "Sức chứa tối đa của bàn phải lớn hơn 0 người!"
                Return False
            End If

            If dto.TrangThai < 0 OrElse dto.TrangThai > 3 Then
                thongBao = "Trạng thái bàn không hợp lệ (Chỉ chấp nhận từ 0 đến 3)!"
                Return False
            End If

            Dim maLoaiTru As Integer = If(isUpdate, dto.MaBan, 0)
            If BanDAO.KiemTraTrungSoThuTu(dto.SoThuTu, maLoaiTru) Then
                thongBao = $"Số thứ tự bàn [{dto.SoThuTu}] đã tồn tại trong danh sách bàn đang hoạt động!"
                Return False
            End If

            dto.TenBan = ten
            dto.KhuVuc = kv
            Return True
        End Function

        ''' <summary>
        ''' Thêm mới một bàn ăn (Hỗ trợ khôi phục nếu số thứ tự trùng với bàn đã xóa mềm).
        ''' </summary>
        Public Shared Function ThemBan(dto As BanDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, False, thongBao) Then
                Return False
            End If

            ' Kiểm tra nếu STT này từng bị xóa mềm -> Khôi phục lại
            Dim maBanDaXoa As Integer = BanDAO.TimMaBanDaXoaTheoSTT(dto.SoThuTu)
            If maBanDaXoa > 0 Then
                If BanDAO.KhoiPhucBan(maBanDaXoa, dto) Then
                    thongBao = $"Đã khôi phục và cập nhật bàn ""{dto.TenBan}"" (STT {dto.SoThuTu}, Khu vực {dto.KhuVuc}) thành công!"
                    Return True
                Else
                    thongBao = "Lỗi khi khôi phục bản ghi bàn ăn đã xóa mềm trước đó!"
                    Return False
                End If
            End If

            If BanDAO.ThemBan(dto) Then
                thongBao = $"Đã thêm mới bàn ""{dto.TenBan}"" (STT {dto.SoThuTu}, Khu vực {dto.KhuVuc}, {dto.SoNguoiToiDa} chỗ) thành công!"
                Return True
            End If

            thongBao = "Lỗi khi thêm mới bàn ăn vào Cơ sở dữ liệu!"
            Return False
        End Function

        ''' <summary>
        ''' Cập nhật thông tin bàn ăn đang hoạt động.
        ''' </summary>
        Public Shared Function CapNhatBan(dto As BanDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, True, thongBao) Then
                Return False
            End If

            If BanDAO.CapNhatBan(dto) Then
                thongBao = $"Đã cập nhật bàn ""{dto.TenBan}"" (STT {dto.SoThuTu}, Khu vực {dto.KhuVuc}, {dto.SoNguoiToiDa} chỗ) thành công!"
                Return True
            End If

            thongBao = "Không thể cập nhật bàn ăn (bản ghi không tồn tại hoặc đã bị xóa)!"
            Return False
        End Function

        ''' <summary>
        ''' Xóa mềm bàn ăn (B_Xoa = 1). Chặn xóa nếu bàn đang có khách hoặc có hóa đơn mở.
        ''' </summary>
        Public Shared Function XoaBan(maBan As Integer, tenBan As String, ByRef thongBao As String) As Boolean
            If maBan <= 0 Then
                thongBao = "Vui lòng chọn một bàn ăn cần xóa!"
                Return False
            End If

            Dim lyDo As String = String.Empty
            If BanDAO.KiemTraBanDangPhucVu(maBan, lyDo) Then
                thongBao = $"Không thể xóa bàn ""{tenBan}"": {lyDo} Vui lòng chỉ xóa khi bàn đã thanh toán và trở về trạng thái Trống."
                Return False
            End If

            If BanDAO.XoaMemBan(maBan) Then
                thongBao = $"Đã xóa bàn ăn ""{tenBan}"" (Mã #{maBan}) thành công!"
                Return True
            End If

            thongBao = "Không thể xóa bàn ăn này!"
            Return False
        End Function

    End Class

End Namespace
