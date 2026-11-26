Imports System
Imports System.Data
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Phân bổ Thực đơn Chi nhánh (ChiNhanh_Menu).
    ''' Kiểm tra ràng buộc hợp lệ, phân bổ và gỡ menu khỏi chi nhánh.
    ''' </summary>
    Public Class ChiNhanhMenuBUS

        Public Shared Function LayDanhSachTheoChiNhanh(maChiNhanh As Integer, Optional tuKhoa As String = "", Optional trangThai As String = "") As List(Of ChiNhanhMenuDTO)
            Return ChiNhanhMenuDAO.LayDanhSachTheoChiNhanh(maChiNhanh, tuKhoa, trangThai)
        End Function

        Public Shared Function LayTheoMa(maCNM As Integer) As ChiNhanhMenuDTO
            If maCNM <= 0 Then Return Nothing
            Return ChiNhanhMenuDAO.LayTheoMa(maCNM)
        End Function

        Public Shared Function KiemTraHopLe(dto As ChiNhanhMenuDTO, ByRef thongBaoLoi As String) As Boolean
            If dto Is Nothing Then
                thongBaoLoi = "Dữ liệu phân bổ không hợp lệ."
                Return False
            End If
            If dto.MaChiNhanh <= 0 Then
                thongBaoLoi = "Vui lòng chọn cơ sở chi nhánh."
                Return False
            End If
            If dto.MaMenu <= 0 Then
                thongBaoLoi = "Vui lòng chọn thực đơn (Menu) cần phân bổ."
                Return False
            End If
            If dto.NgayKetThuc.HasValue AndAlso dto.NgayKetThuc.Value < dto.NgayBatDau Then
                thongBaoLoi = "Ngày kết thúc áp dụng không thể trước ngày bắt đầu."
                Return False
            End If
            If ChiNhanhMenuDAO.KiemTraMenuDaGan(dto.MaChiNhanh, dto.MaMenu, dto.MaCNM) Then
                thongBaoLoi = "Thực đơn này đã được phân bổ cho chi nhánh trước đó."
                Return False
            End If
            thongBaoLoi = String.Empty
            Return True
        End Function

        Public Shared Function GanMenu(dto As ChiNhanhMenuDTO, ByRef thongBao As String) As Boolean
            If Not KiemTraHopLe(dto, thongBao) Then
                Return False
            End If
            Dim idMoi As Integer = ChiNhanhMenuDAO.GanMenu(dto)
            If idMoi > 0 Then
                dto.MaCNM = idMoi
                thongBao = "Phân bổ thực đơn cho chi nhánh thành công!"
                Return True
            End If
            thongBao = "Không thể phân bổ thực đơn vào chi nhánh. Vui lòng thử lại!"
            Return False
        End Function

        Public Shared Function CapNhat(dto As ChiNhanhMenuDTO, ByRef thongBao As String) As Boolean
            If dto Is Nothing OrElse dto.MaCNM <= 0 Then
                thongBao = "Vui lòng chọn thực đơn chi nhánh cần cập nhật."
                Return False
            End If
            If Not KiemTraHopLe(dto, thongBao) Then
                Return False
            End If
            If ChiNhanhMenuDAO.CapNhat(dto) Then
                thongBao = "Cập nhật phân bổ thực đơn thành công!"
                Return True
            End If
            thongBao = "Cập nhật thất bại. Vui lòng kiểm tra lại!"
            Return False
        End Function

        Public Shared Function GoMenu(maCNM As Integer, ByRef thongBao As String) As Boolean
            If maCNM <= 0 Then
                thongBao = "Vui lòng chọn thực đơn cần gỡ khỏi chi nhánh."
                Return False
            End If
            If ChiNhanhMenuDAO.GoMenu(maCNM) Then
                thongBao = "Đã gỡ thực đơn khỏi chi nhánh thành công!"
                Return True
            End If
            thongBao = "Không thể gỡ thực đơn. Vui lòng kiểm tra lại!"
            Return False
        End Function

        Public Shared Function LayDanhSachMenuMaster() As DataTable
            Return ChiNhanhMenuDAO.LayDanhSachMenuMaster()
        End Function

    End Class

End Namespace
