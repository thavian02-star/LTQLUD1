Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Quản lý Ca Làm Việc (CaLamViec).
    ''' Kiểm tra ràng buộc khung giờ, định mức lương, chống trùng tên, bảo vệ khóa ngoại và khôi phục xóa mềm.
    ''' </summary>
    Public Class CaLamViecBUS

        ''' <summary>
        ''' Lấy danh sách ca làm việc theo từ khóa tìm kiếm.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "") As List(Of CaLamViecDTO)
            Return CaLamViecDAO.LayDanhSach(tuKhoa)
        End Function

        ''' <summary>
        ''' Kiểm tra tính hợp lệ của thông tin Ca làm việc trước khi Thêm mới / Cập nhật.
        ''' </summary>
        Private Shared Function KiemTraHopLe(dto As CaLamViecDTO, isUpdate As Boolean, ByRef thongBao As String) As Boolean
            If dto Is Nothing Then
                thongBao = "Dữ liệu ca làm việc không hợp lệ!"
                Return False
            End If

            If isUpdate AndAlso dto.MaCa <= 0 Then
                thongBao = "Vui lòng chọn một ca làm việc từ danh sách bên phải trước khi cập nhật!"
                Return False
            End If

            Dim ten As String = If(dto.TenCa, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(ten) Then
                thongBao = "Tên ca làm việc không được để trống!"
                Return False
            End If

            If ten.Length > 50 Then
                thongBao = "Tên ca làm việc không được vượt quá 50 ký tự!"
                Return False
            End If

            Dim soPhut As Double = (dto.GioKetThuc - dto.GioBatDau).TotalMinutes
            If soPhut < 30 Then
                thongBao = $"Khung giờ ca không hợp lệ: Giờ kết thúc ({dto.GioKetThuc:hh\:mm}) phải lớn hơn Giờ bắt đầu ({dto.GioBatDau:hh\:mm}) ít nhất 30 phút!"
                Return False
            End If

            If dto.LuongMoiCa < 0D Then
                thongBao = "Định mức lương mỗi ca không được nhỏ hơn 0 VNĐ!"
                Return False
            End If

            Dim maLoaiTru As Integer = If(isUpdate, dto.MaCa, 0)
            If CaLamViecDAO.KiemTraTrungTen(ten, maLoaiTru) Then
                thongBao = $"Tên ca làm việc ""{ten}"" đã tồn tại trong danh sách đang hoạt động!"
                Return False
            End If

            dto.TenCa = ten
            Return True
        End Function

        ''' <summary>
        ''' Thêm mới ca làm việc (Tự động khôi phục nếu trùng tên với ca đã xóa mềm trước đó).
        ''' </summary>
        Public Shared Function ThemCaLamViec(dto As CaLamViecDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, False, thongBao) Then
                Return False
            End If

            Dim maCaDaXoa As Integer = CaLamViecDAO.TimMaCaDaXoaTheoTen(dto.TenCa)
            If maCaDaXoa > 0 Then
                If CaLamViecDAO.KhoiPhucCaLamViec(maCaDaXoa, dto) Then
                    thongBao = $"Đã khôi phục và cập nhật ca làm việc ""{dto.TenCa}"" ({dto.KhungGioText}, lương {dto.LuongMoiCa:#,##0} đ) thành công!"
                    Return True
                Else
                    thongBao = "Không thể khôi phục ca làm việc đã xóa trước đó!"
                    Return False
                End If
            End If

            If CaLamViecDAO.ThemCaLamViec(dto) Then
                thongBao = $"Đã thêm mới ca làm việc ""{dto.TenCa}"" ({dto.KhungGioText}, thời lượng {dto.SoGioLam:0.0} giờ, lương {dto.LuongMoiCa:#,##0} đ) thành công!"
                Return True
            End If

            thongBao = "Lỗi khi thêm mới ca làm việc vào Cơ sở dữ liệu!"
            Return False
        End Function

        ''' <summary>
        ''' Cập nhật thông tin ca làm việc đang hoạt động.
        ''' </summary>
        Public Shared Function CapNhatCaLamViec(dto As CaLamViecDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, True, thongBao) Then
                Return False
            End If

            If CaLamViecDAO.CapNhatCaLamViec(dto) Then
                thongBao = $"Đã cập nhật thông tin ca ""{dto.TenCa}"" ({dto.KhungGioText}, lương {dto.LuongMoiCa:#,##0} đ) thành công!"
                Return True
            End If

            thongBao = "Không thể cập nhật ca làm việc (bản ghi không tồn tại hoặc đã bị xóa)!"
            Return False
        End Function

        ''' <summary>
        ''' Xóa mềm ca làm việc (CA_Xoa = 1). Chặn xóa nếu đang có lịch làm việc hoặc hóa đơn tham chiếu.
        ''' </summary>
        Public Shared Function XoaCaLamViec(maCa As Integer, tenCa As String, ByRef thongBao As String) As Boolean
            If maCa <= 0 Then
                thongBao = "Vui lòng chọn một ca làm việc cần xóa!"
                Return False
            End If

            Dim soLich As Integer = CaLamViecDAO.DemSoLichPhanCong(maCa)
            Dim soHoaDon As Integer = CaLamViecDAO.DemSoHoaDonTheoCa(maCa)

            If soLich > 0 OrElse soHoaDon > 0 Then
                thongBao = $"Không thể xóa ca ""{tenCa}"" vì đang có {soLich} lượt xếp lịch làm việc và {soHoaDon} hóa đơn tham chiếu! Vui lòng giữ nguyên ca hoặc cập nhật thông tin."
                Return False
            End If

            If CaLamViecDAO.XoaMemCaLamViec(maCa) Then
                thongBao = $"Đã xóa mềm ca làm việc ""{tenCa}"" (Mã #{maCa}) thành công!"
                Return True
            End If

            thongBao = "Không thể xóa ca làm việc này!"
            Return False
        End Function

    End Class

End Namespace
