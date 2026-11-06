Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Quản lý Khu Vực Bàn Ăn (KhuVuc).
    ''' Kiểm tra ràng buộc hợp lệ, chống trùng tên, đồng bộ tên bàn tự động (Cascade Update),
    ''' bảo vệ khóa ngoại khi có bàn hoạt động (FK Protection) và khôi phục xóa mềm thông minh.
    ''' </summary>
    Public Class KhuVucBUS

        ''' <summary>
        ''' Lấy danh sách khu vực bàn ăn theo từ khóa tìm kiếm.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "") As List(Of KhuVucDTO)
            Return KhuVucDAO.LayDanhSach(tuKhoa)
        End Function

        ''' <summary>
        ''' Lấy thông tin chi tiết một khu vực theo mã định danh.
        ''' </summary>
        Public Shared Function LayTheoMa(ma As Integer) As KhuVucDTO
            If ma <= 0 Then Return Nothing
            Return KhuVucDAO.LayTheoMa(ma)
        End Function

        ''' <summary>
        ''' Kiểm tra tính hợp lệ của thông tin Khu vực bàn trước khi Thêm mới / Cập nhật.
        ''' </summary>
        Private Shared Function KiemTraHopLe(dto As KhuVucDTO, isUpdate As Boolean, ByRef thongBao As String) As Boolean
            If dto Is Nothing Then
                thongBao = "Dữ liệu khu vực bàn không hợp lệ!"
                Return False
            End If

            If isUpdate AndAlso dto.KV_Ma <= 0 Then
                thongBao = "Vui lòng chọn một khu vực từ danh sách bên phải trước khi cập nhật!"
                Return False
            End If

            Dim ten As String = If(dto.KV_Ten, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(ten) Then
                thongBao = "Tên khu vực không được để trống!"
                Return False
            End If

            If ten.Length > 50 Then
                thongBao = "Tên khu vực không được vượt quá 50 ký tự!"
                Return False
            End If

            Dim maLoaiTru As Integer = If(isUpdate, dto.KV_Ma, 0)
            If KhuVucDAO.KiemTraTrungTen(ten, maLoaiTru) Then
                thongBao = $"Tên khu vực ""{ten}"" đã tồn tại trong danh sách đang hoạt động!"
                Return False
            End If

            dto.KV_Ten = ten
            If dto.KV_MoTa IsNot Nothing Then
                dto.KV_MoTa = dto.KV_MoTa.Trim()
            End If

            Return True
        End Function

        ''' <summary>
        ''' Thêm mới khu vực bàn (Tự động khôi phục nếu trùng tên với khu vực đã xóa mềm trước đó).
        ''' </summary>
        Public Shared Function ThemKhuVuc(dto As KhuVucDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, False, thongBao) Then
                Return False
            End If

            Dim maDaXoa As Integer = KhuVucDAO.TimMaKhuVucDaXoaTheoTen(dto.KV_Ten)
            If maDaXoa > 0 Then
                If KhuVucDAO.KhoiPhucKhuVuc(maDaXoa, dto) Then
                    thongBao = $"Đã khôi phục và cập nhật khu vực ""{dto.KV_Ten}"" (Mã #{maDaXoa}) thành công!"
                    Return True
                Else
                    thongBao = "Không thể khôi phục khu vực đã xóa trước đó!"
                    Return False
                End If
            End If

            If KhuVucDAO.ThemKhuVuc(dto) Then
                thongBao = $"Đã thêm mới khu vực ""{dto.KV_Ten}"" (Mã #{dto.KV_Ma}) thành công!"
                Return True
            End If

            thongBao = "Lỗi khi thêm mới khu vực vào Cơ sở dữ liệu!"
            Return False
        End Function

        ''' <summary>
        ''' Cập nhật thông tin khu vực bàn và đồng bộ tự động tên khu vực cho các bàn trong bảng Ban (Cascade Update).
        ''' </summary>
        Public Shared Function CapNhatKhuVuc(dto As KhuVucDTO, tenCu As String, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, True, thongBao) Then
                Return False
            End If

            If KhuVucDAO.CapNhatKhuVuc(dto, tenCu) Then
                If Not String.IsNullOrWhiteSpace(tenCu) AndAlso Not tenCu.Trim().Equals(dto.KV_Ten.Trim(), StringComparison.OrdinalIgnoreCase) Then
                    thongBao = $"Đã cập nhật khu vực thành công! Đã tự động đồng bộ tên mới ""{dto.KV_Ten}"" cho các bàn thuộc khu vực ""{tenCu}""."
                Else
                    thongBao = $"Đã cập nhật thông tin khu vực ""{dto.KV_Ten}"" (Mã #{dto.KV_Ma}) thành công!"
                End If
                Return True
            End If

            thongBao = "Không thể cập nhật khu vực (bản ghi không tồn tại hoặc đã bị xóa)!"
            Return False
        End Function

        ''' <summary>
        ''' Xóa mềm khu vực bàn (KV_Xoa = 1). Chặn xóa nếu đang có bàn hoạt động (FK Protection).
        ''' </summary>
        Public Shared Function XoaKhuVuc(ma As Integer, tenKhuVuc As String, ByRef thongBao As String) As Boolean
            If ma <= 0 Then
                thongBao = "Vui lòng chọn một khu vực cần xóa!"
                Return False
            End If

            Dim soBan As Integer = KhuVucDAO.DemSoBanThuocKhuVuc(tenKhuVuc)
            If soBan > 0 Then
                thongBao = $"Không thể xóa khu vực ""{tenKhuVuc}"" vì đang có {soBan} bàn hoạt động! Vui lòng chuyển hoặc xóa các bàn trước khi xóa khu vực."
                Return False
            End If

            If KhuVucDAO.XoaMemKhuVuc(ma) Then
                thongBao = $"Đã xóa mềm khu vực ""{tenKhuVuc}"" (Mã #{ma}) thành công!"
                Return True
            End If

            thongBao = "Không thể xóa khu vực này!"
            Return False
        End Function

    End Class

End Namespace
