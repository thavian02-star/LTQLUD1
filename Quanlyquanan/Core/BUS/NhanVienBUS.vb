Imports System.Text.RegularExpressions
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Quản lý Danh sách Nhân sự (NhanVien).
    ''' Kiểm tra dữ liệu đầu vào (CCCD, SĐT, Email, Tuổi), phân quyền thao tác và kiểm soát thu hồi đồng phục.
    ''' </summary>
    Public Class NhanVienBUS

        ''' <summary>
        ''' Lấy danh sách nhân viên theo từ khóa tìm kiếm, vị trí và trạng thái.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional viTri As String = "",
                                           Optional trangThai As String = "") As List(Of NhanVienDTO)
            Return NhanVienDAO.LayDanhSach(tuKhoa, viTri, trangThai)
        End Function

        ''' <summary>
        ''' Lấy danh mục 4 kỹ năng vi tính chuẩn.
        ''' </summary>
        Public Shared Function LayDanhSachTrinhDoViTinh() As List(Of TrinhDoViTinhDTO)
            Return NhanVienDAO.LayDanhSachTrinhDoViTinh()
        End Function

        ''' <summary>
        ''' Lấy danh sách tài khoản khả dụng cho nhân viên hiện tại.
        ''' </summary>
        Public Shared Function LayDanhSachTaiKhoanKhaDung(Optional maNVDangChon As Integer = 0) As List(Of TaiKhoanItemDTO)
            Return NhanVienDAO.LayDanhSachTaiKhoanKhaDung(maNVDangChon)
        End Function

        ''' <summary>
        ''' Lấy các số liệu KPI phục vụ hiển thị trên bảng điều khiển.
        ''' </summary>
        Public Shared Function LayThongKeKPI() As (TongNV As Integer, DangLam As Integer, DaNghi As Integer, CoTaiKhoan As Integer)
            Return NhanVienDAO.LayThongKeKPI()
        End Function

        ''' <summary>
        ''' Kiểm tra số lượng đồng phục/dụng cụ nhân viên đang giữ chưa hoàn trả.
        ''' </summary>
        Public Shared Function KiemTraTrangPhucChuaTra(maNV As Integer) As Integer
            If maNV <= 0 Then Return 0
            Return NhanVienDAO.KiemTraTrangPhucChuaTra(maNV)
        End Function

        ''' <summary>
        ''' Kiểm tra tính hợp lệ nghiệp vụ của dữ liệu nhân viên.
        ''' </summary>
        Public Shared Function KiemTraHopLe(dto As NhanVienDTO, isUpdate As Boolean, ByRef thongBao As String) As Boolean
            If dto Is Nothing Then
                thongBao = "Dữ liệu hồ sơ nhân viên không hợp lệ!"
                Return False
            End If

            If isUpdate AndAlso dto.MaNV <= 0 Then
                thongBao = "Vui lòng chọn một nhân viên từ danh sách bên phải trước khi cập nhật!"
                Return False
            End If

            ' 1. Kiểm tra Họ và Tên
            Dim hoTen As String = If(dto.HoTen, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(hoTen) Then
                thongBao = "Họ và tên nhân viên không được để trống!"
                Return False
            End If

            If hoTen.Length < 2 OrElse hoTen.Length > 100 Then
                thongBao = "Họ và tên nhân viên phải có độ dài từ 2 đến 100 ký tự!"
                Return False
            End If

            ' 2. Kiểm tra Vị trí công tác
            Dim viTri As String = If(dto.ViTri, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(viTri) Then
                thongBao = "Vui lòng chọn hoặc nhập vị trí công tác của nhân viên!"
                Return False
            End If

            ' 3. Kiểm tra CCCD / CMND (Bắt buộc theo quy định hồ sơ lao động)
            Dim cmnd As String = If(dto.CMND, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(cmnd) Then
                thongBao = "Số Căn cước công dân (CCCD/CMND) không được để trống!"
                Return False
            End If

            If Not Regex.IsMatch(cmnd, "^\d{9}$|^\d{12}$") Then
                thongBao = "Số CCCD/CMND phải là dãy số gồm 9 hoặc 12 chữ số hợp lệ!"
                Return False
            End If

            ' Kiểm tra trùng CCCD trong CSDL
            If NhanVienDAO.KiemTraTrungCMND(cmnd, If(isUpdate, dto.MaNV, 0)) Then
                thongBao = $"Số CCCD/CMND '{cmnd}' đã tồn tại ở một hồ sơ nhân viên khác trong hệ thống!"
                Return False
            End If

            ' 4. Kiểm tra Số điện thoại (nếu có nhập)
            Dim sdt As String = If(dto.DienThoai, String.Empty).Trim()
            If Not String.IsNullOrWhiteSpace(sdt) Then
                If Not Regex.IsMatch(sdt, "^0\d{9,10}$") Then
                    thongBao = "Số điện thoại không hợp lệ (phải bắt đầu bằng số 0 và có 10-11 chữ số)!"
                    Return False
                End If
            End If

            ' 5. Kiểm tra Email (nếu có nhập)
            Dim email As String = If(dto.Email, String.Empty).Trim()
            If Not String.IsNullOrWhiteSpace(email) Then
                If Not Regex.IsMatch(email, "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$") Then
                    thongBao = "Địa chỉ Email không đúng định dạng chuẩn!"
                    Return False
                End If
            End If

            ' 6. Kiểm tra Ngày sinh (Độ tuổi lao động từ 15 tuổi trở lên theo luật)
            If dto.NgaySinh.HasValue Then
                Dim ngaySinh As DateTime = dto.NgaySinh.Value.Date
                Dim today As DateTime = DateTime.Today

                If ngaySinh > today Then
                    thongBao = "Ngày sinh không thể nằm ở tương lai!"
                    Return False
                End If

                Dim tuoi As Integer = today.Year - ngaySinh.Year
                If ngaySinh > today.AddYears(-tuoi) Then tuoi -= 1

                If tuoi < 15 Then
                    thongBao = $"Nhân viên chưa đủ độ tuổi lao động tối thiểu (15 tuổi)! (Hiện tại: {tuoi} tuổi)"
                    Return False
                End If

                If tuoi > 80 Then
                    thongBao = $"Độ tuổi nhân viên ({tuoi} tuổi) vượt quá ngưỡng cho phép!"
                    Return False
                End If
            End If

            ' 7. Kiểm tra Ngày bắt đầu làm việc
            If dto.NgayBatDauLam < New DateTime(2000, 1, 1) Then
                thongBao = "Ngày bắt đầu làm việc không hợp lệ (trước năm 2000)!"
                Return False
            End If

            If dto.NgayBatDauLam > DateTime.Today.AddDays(60) Then
                thongBao = "Ngày bắt đầu làm việc không được vượt quá 60 ngày tới!"
                Return False
            End If

            thongBao = "Dữ liệu hợp lệ."
            Return True
        End Function

        ''' <summary>
        ''' Thêm mới hồ sơ nhân viên vào hệ thống.
        ''' </summary>
        Public Shared Function Them(dto As NhanVienDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, isUpdate:=False, thongBao:=thongBao) Then
                Return False
            End If

            Try
                Dim newId As Integer = NhanVienDAO.Them(dto)
                If newId > 0 Then
                    thongBao = $"Thêm mới nhân viên '{dto.HoTen}' (Mã #{newId}) thành công!"
                    Return True
                Else
                    thongBao = "Thêm mới nhân viên thất bại do lỗi không xác định!"
                    Return False
                End If
            Catch ex As Exception
                thongBao = $"Lỗi khi thêm nhân viên: {ex.Message}"
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Cập nhật thông tin hồ sơ nhân viên.
        ''' </summary>
        Public Shared Function CapNhat(dto As NhanVienDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, isUpdate:=True, thongBao:=thongBao) Then
                Return False
            End If

            Try
                Dim result As Boolean = NhanVienDAO.CapNhat(dto)
                If result Then
                    thongBao = $"Cập nhật hồ sơ nhân viên '{dto.HoTen}' thành công!"
                    Return True
                Else
                    thongBao = "Cập nhật hồ sơ thất bại. Nhân viên có thể đã bị xóa hoặc không tồn tại!"
                    Return False
                End If
            Catch ex As Exception
                thongBao = $"Lỗi khi cập nhật nhân viên: {ex.Message}"
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Xóa mềm nhân viên khỏi danh sách hiển thị.
        ''' </summary>
        Public Shared Function Xoa(maNV As Integer, ByRef thongBao As String) As Boolean
            If maNV <= 0 Then
                thongBao = "Vui lòng chọn một nhân viên để xóa!"
                Return False
            End If

            Try
                Dim nv = NhanVienDAO.LayTheoMa(maNV)
                If nv Is Nothing Then
                    thongBao = "Nhân viên không tồn tại hoặc đã bị xóa trước đó!"
                    Return False
                End If

                Dim result As Boolean = NhanVienDAO.XoaMem(maNV)
                If result Then
                    thongBao = $"Xóa nhân viên '{nv.HoTen}' (Mã #{maNV}) thành công!"
                    Return True
                Else
                    thongBao = "Không thể xóa nhân viên!"
                    Return False
                End If
            Catch ex As Exception
                thongBao = $"Lỗi khi xóa nhân viên: {ex.Message}"
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Cập nhật trạng thái thôi việc cho nhân viên, tự động thu hồi đồng phục nếu được yêu cầu.
        ''' </summary>
        Public Shared Function ThoiViec(maNV As Integer, ngayThoiViec As DateTime, tuDongThuHoiTrangPhuc As Boolean, ByRef thongBao As String) As Boolean
            If maNV <= 0 Then
                thongBao = "Vui lòng chọn một nhân viên để thực hiện thôi việc!"
                Return False
            End If

            Try
                Dim result As Boolean = NhanVienDAO.CapNhatNghiViec(maNV, ngayThoiViec, tuDongThuHoiTrangPhuc)
                If result Then
                    Dim msgThuHoi As String = If(tuDongThuHoiTrangPhuc, " và đã tự động hoàn tất thu hồi trang phục.", ".")
                    thongBao = $"Đã cập nhật trạng thái thôi việc cho nhân viên #{maNV}{msgThuHoi}"
                    Return True
                Else
                    thongBao = "Cập nhật trạng thái thôi việc thất bại!"
                    Return False
                End If
            Catch ex As Exception
                thongBao = $"Lỗi khi xử lý thôi việc: {ex.Message}"
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Khôi phục trạng thái làm việc cho nhân viên đã nghỉ.
        ''' </summary>
        Public Shared Function KhoiPhuc(maNV As Integer, ByRef thongBao As String) As Boolean
            If maNV <= 0 Then
                thongBao = "Vui lòng chọn một nhân viên để khôi phục!"
                Return False
            End If

            Try
                Dim result As Boolean = NhanVienDAO.KhoiPhucLamViec(maNV)
                If result Then
                    thongBao = $"Đã khôi phục trạng thái đang làm việc cho nhân viên #{maNV}!"
                    Return True
                Else
                    thongBao = "Khôi phục trạng thái làm việc thất bại!"
                    Return False
                End If
            Catch ex As Exception
                thongBao = $"Lỗi khi khôi phục nhân viên: {ex.Message}"
                Return False
            End Try
        End Function

    End Class

End Namespace
