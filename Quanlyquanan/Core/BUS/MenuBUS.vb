Imports System
Imports System.Collections.Generic
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Đối tượng trả về kết quả nghiệp vụ Bảng Thực Đơn (Menu).
    ''' </summary>
    Public Class KetQuaMenu
        Public Property ThanhCong As Boolean = False
        Public Property ThongBao As String = String.Empty
        Public Property MaMenu As Integer = 0
        Public Property MaMMA As Integer = 0
    End Class

    ''' <summary>
    ''' Tầng Nghiệp vụ (BUS) cho Bảng Thực Đơn Kinh Doanh (Menu) và Gán món vào Menu (Menu_MonAn).
    ''' Đảm bảo kiểm tra tính hợp lệ dữ liệu, chống trùng tên, và kiểm soát ràng buộc đơn giá.
    ''' </summary>
    Public Class MenuBUS

        ''' <summary>
        ''' Lấy danh sách bảng Menu theo các tiêu chí tìm kiếm và bộ lọc.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional loaiMenu As String = "",
                                           Optional trangThai As String = "") As List(Of MenuDTO)
            Return MenuDAO.LayDanhSach(tuKhoa, loaiMenu, trangThai)
        End Function

        ''' <summary>
        ''' Lấy thông tin Menu theo mã.
        ''' </summary>
        Public Shared Function LayMenuTheoMa(maMenu As Integer) As MenuDTO
            Return MenuDAO.LayMenuTheoMa(maMenu)
        End Function

        ''' <summary>
        ''' Lấy danh sách món ăn đã gán vào một Menu cụ thể.
        ''' </summary>
        Public Shared Function LayDanhSachMonTheoMenu(maMenu As Integer) As List(Of MenuMonAnDTO)
            Return MenuDAO.LayDanhSachMonTheoMenu(maMenu)
        End Function

        ''' <summary>
        ''' Lấy toàn bộ danh sách món ăn từ kho món (MonAn) để người dùng chọn gán.
        ''' </summary>
        Public Shared Function LayDanhSachMonAnKho() As List(Of MonAnDTO)
            Return MenuDAO.LayDanhSachMonAnKho()
        End Function

        ''' <summary>
        ''' Lấy các số liệu KPI phục vụ hiển thị trên bảng điều khiển.
        ''' </summary>
        Public Shared Function LayThongKeKPI() As (TongMenu As Integer, DangApDung As Integer, TamNgung As Integer, TongMonGan As Integer)
            Return MenuDAO.LayThongKeKPI()
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và thêm mới một Bảng Thực Đơn.
        ''' </summary>
        Public Shared Function ThemMenu(dto As MenuDTO) As KetQuaMenu
            If dto Is Nothing Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Dữ liệu bảng thực đơn không hợp lệ!"}
            End If

            Dim ten As String = If(dto.TenMenu, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(ten) Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng nhập Tên bảng thực đơn!"}
            End If

            If ten.Length > 100 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Tên bảng thực đơn không được vượt quá 100 ký tự!"}
            End If

            If MenuDAO.KiemTraTrungTen(ten, 0) Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = $"Tên thực đơn '{ten}' đã tồn tại trong hệ thống! Vui lòng đặt tên khác."}
            End If

            Dim newId As Integer = MenuDAO.Them(dto)
            If newId > 0 Then
                Return New KetQuaMenu() With {
                    .ThanhCong = True,
                    .ThongBao = $"Đã thêm thành công Bảng thực đơn '{ten}' (Mã: {newId})!",
                    .MaMenu = newId
                }
            Else
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Thêm bảng thực đơn thất bại! Vui lòng kiểm tra kết nối CSDL."}
            End If
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và cập nhật thông tin Bảng Thực Đơn.
        ''' </summary>
        Public Shared Function CapNhatMenu(dto As MenuDTO) As KetQuaMenu
            If dto Is Nothing OrElse dto.MaMenu <= 0 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng chọn một bảng thực đơn hợp lệ để cập nhật!"}
            End If

            Dim ten As String = If(dto.TenMenu, String.Empty).Trim()
            If String.IsNullOrWhiteSpace(ten) Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng nhập Tên bảng thực đơn!"}
            End If

            If ten.Length > 100 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Tên bảng thực đơn không được vượt quá 100 ký tự!"}
            End If

            If MenuDAO.KiemTraTrungTen(ten, dto.MaMenu) Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = $"Tên thực đơn '{ten}' đã được sử dụng bởi bảng thực đơn khác!"}
            End If

            If MenuDAO.CapNhat(dto) Then
                Return New KetQuaMenu() With {
                    .ThanhCong = True,
                    .ThongBao = $"Cập nhật thành công Bảng thực đơn '{ten}' (Mã: {dto.MaMenu})!",
                    .MaMenu = dto.MaMenu
                }
            Else
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Cập nhật bảng thực đơn thất bại! Vui lòng kiểm tra lại."}
            End If
        End Function

        ''' <summary>
        ''' Xóa một Bảng Thực Đơn và các liên kết món ăn liên quan.
        ''' </summary>
        Public Shared Function XoaMenu(maMenu As Integer) As KetQuaMenu
            If maMenu <= 0 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng chọn một bảng thực đơn hợp lệ để xóa!"}
            End If

            If MenuDAO.Xoa(maMenu) Then
                Return New KetQuaMenu() With {
                    .ThanhCong = True,
                    .ThongBao = $"Đã xóa thành công bảng thực đơn (Mã: {maMenu}) và ngưng áp dụng toàn bộ món trong menu này!",
                    .MaMenu = maMenu
                }
            Else
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Xóa bảng thực đơn thất bại! Vui lòng thử lại."}
            End If
        End Function

        ''' <summary>
        ''' Gán một món ăn từ kho vào Bảng Thực Đơn đang chọn.
        ''' </summary>
        Public Shared Function GanMonVaoMenu(maMenu As Integer,
                                             maMonAn As Integer,
                                             donGia As Decimal,
                                             thuTuHienThi As Integer,
                                             ghiChu As String) As KetQuaMenu
            If maMenu <= 0 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng chọn Bảng thực đơn trước khi gán món!"}
            End If

            If maMonAn <= 0 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng chọn Món ăn cần gán từ kho món!"}
            End If

            If donGia < 0D Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Đơn giá món trong thực đơn không thể là số âm!"}
            End If

            If thuTuHienThi < 1 Then
                thuTuHienThi = 1
            End If

            If MenuDAO.GanMonVaoMenu(maMenu, maMonAn, donGia, thuTuHienThi, ghiChu) Then
                Return New KetQuaMenu() With {
                    .ThanhCong = True,
                    .ThongBao = "Đã gán món ăn vào Bảng thực đơn thành công!",
                    .MaMenu = maMenu
                }
            Else
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Gán món vào thực đơn thất bại! Vui lòng thử lại."}
            End If
        End Function

        ''' <summary>
        ''' Gỡ một món ăn ra khỏi Bảng Thực Đơn.
        ''' </summary>
        Public Shared Function GoMonKhoiMenu(maMMA As Integer) As KetQuaMenu
            If maMMA <= 0 Then
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Vui lòng chọn món cần gỡ khỏi thực đơn!"}
            End If

            If MenuDAO.GoMonKhoiMenu(maMMA) Then
                Return New KetQuaMenu() With {
                    .ThanhCong = True,
                    .ThongBao = "Đã gỡ món ăn ra khỏi Bảng thực đơn thành công!",
                    .MaMMA = maMMA
                }
            Else
                Return New KetQuaMenu() With {.ThanhCong = False, .ThongBao = "Gỡ món khỏi thực đơn thất bại! Vui lòng thử lại."}
            End If
        End Function

    End Class

End Namespace
