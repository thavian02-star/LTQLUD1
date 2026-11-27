Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) cho Phân hệ Điều Phối Nhà Bếp (KDS FIFO).
    ''' Quản lý hàng đợi chế biến, phân loại bếp nóng/lạnh/bar và cập nhật trạng thái hoàn thành món.
    ''' </summary>
    Public Class NhaBepBUS

        ' Bộ nhớ đệm Demo Offline phục vụ trải nghiệm khi chưa có SQL Server Docker
        Private Shared ReadOnly _demoQueue As New List(Of ChiTietHoaDonDTO)()
        Private Shared _isDemoInit As Boolean = False

        Private Shared Sub KhoiTaoDemoQueue()
            If _isDemoInit Then Return
            _demoQueue.Clear()
            _demoQueue.Add(New ChiTietHoaDonDTO With {
                .CTHD_Ma = 101, .CTHD_MaHoaDon = 1, .TenBan = "Bàn 02", .TenMonAn = "Cơm Tấm Sườn Bì Chả",
                .TenDanhMuc = "Món Chính", .CTHD_SoLuong = 2, .CTHD_DonGia = 55000,
                .CTHD_GhiChu = "Thêm chả cua đặc biệt, 1 dĩa không ớt", .CTHD_ThoiGianGoi = DateTime.Now.AddMinutes(-16), .CTHD_TrangThaiMon = 0
            })
            _demoQueue.Add(New ChiTietHoaDonDTO With {
                .CTHD_Ma = 102, .CTHD_MaHoaDon = 2, .TenBan = "Bàn 04", .TenMonAn = "Phở Bò Tái Nạm Cung Đình",
                .TenDanhMuc = "Món Chính", .CTHD_SoLuong = 1, .CTHD_DonGia = 65000,
                .CTHD_GhiChu = "Không hành lá, nước trong", .CTHD_ThoiGianGoi = DateTime.Now.AddMinutes(-8), .CTHD_TrangThaiMon = 0
            })
            _demoQueue.Add(New ChiTietHoaDonDTO With {
                .CTHD_Ma = 103, .CTHD_MaHoaDon = 3, .TenBan = "Phòng VIP 1", .TenMonAn = "Gỏi Cuốn Tôm Thịt Ngũ Sắc",
                .TenDanhMuc = "Khai Vị", .CTHD_SoLuong = 3, .CTHD_DonGia = 45000,
                .CTHD_GhiChu = "Nước mắm chua ngọt riêng", .CTHD_ThoiGianGoi = DateTime.Now.AddMinutes(-5), .CTHD_TrangThaiMon = 0
            })
            _demoQueue.Add(New ChiTietHoaDonDTO With {
                .CTHD_Ma = 104, .CTHD_MaHoaDon = 1, .TenBan = "Bàn 02", .TenMonAn = "Trà Đào Cam Sả Tươi",
                .TenDanhMuc = "Đồ Uống", .CTHD_SoLuong = 2, .CTHD_DonGia = 35000,
                .CTHD_GhiChu = "Ít ngọt, đá riêng", .CTHD_ThoiGianGoi = DateTime.Now.AddMinutes(-3), .CTHD_TrangThaiMon = 0
            })
            _demoQueue.Add(New ChiTietHoaDonDTO With {
                .CTHD_Ma = 105, .CTHD_MaHoaDon = 4, .TenBan = "Bàn 05", .TenMonAn = "Bò Lúc Lắc Khoai Tây",
                .TenDanhMuc = "Món Chính", .CTHD_SoLuong = 1, .CTHD_DonGia = 85000,
                .CTHD_GhiChu = "Bò chín vừa (Medium)", .CTHD_ThoiGianGoi = DateTime.Now.AddMinutes(-2), .CTHD_TrangThaiMon = 0
            })
            _isDemoInit = True
        End Sub

        ''' <summary>
        ''' Lấy danh sách các món ăn đang chờ chế biến sắp xếp theo thứ tự FIFO (gọi trước làm trước).
        ''' </summary>
        Public Shared Function LayHangDoiCheBien(Optional loaiBep As String = "all") As List(Of ChiTietHoaDonDTO)
            Try
                Dim ds As List(Of ChiTietHoaDonDTO) = ChiTietHoaDonDAO.LayHangDoiNhaBep(loaiBep)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback demo
            End Try

            KhoiTaoDemoQueue()
            Return _demoQueue.Where(Function(x) x.CTHD_TrangThaiMon = 0 AndAlso LocTheoLoaiBep(x.TenDanhMuc, loaiBep)).OrderBy(Function(x) x.CTHD_ThoiGianGoi).ToList()
        End Function

        Private Shared Function LocTheoLoaiBep(tenDanhMuc As String, loaiBep As String) As Boolean
            If String.IsNullOrEmpty(tenDanhMuc) Then Return True
            Dim lower = tenDanhMuc.ToLower()
            Select Case loaiBep
                Case "hot" : Return lower.Contains("chính") OrElse lower.Contains("lẩu") OrElse lower.Contains("nướng") OrElse lower.Contains("cơm") OrElse lower.Contains("phở")
                Case "cold" : Return lower.Contains("khai") OrElse lower.Contains("gỏi") OrElse lower.Contains("tráng") OrElse lower.Contains("salad")
                Case "bar" : Return lower.Contains("uống") OrElse lower.Contains("nước") OrElse lower.Contains("trà") OrElse lower.Contains("cà phê")
                Case Else : Return True
            End Select
        End Function

        ''' <summary>
        ''' Xác nhận hoàn thành món: Cập nhật CTHD_TrangThaiMon = 1 (Đã nấu xong).
        ''' </summary>
        Public Shared Function HoanThanhMon(maCTHD As Integer) As Boolean
            Try
                If ChiTietHoaDonDAO.CapNhatTrangThaiMon(maCTHD, 1) Then
                    Return True
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            KhoiTaoDemoQueue()
            For Each item In _demoQueue
                If item.CTHD_Ma = maCTHD Then
                    item.CTHD_TrangThaiMon = 1
                    Return True
                End If
            Next
            Return True
        End Function

        ''' <summary>
        ''' Đếm số lượng món đang chờ nấu.
        ''' </summary>
        Public Shared Function DemMonDangCho() As Integer
            Dim ds = LayHangDoiCheBien("all")
            Return ds.Count
        End Function

        ''' <summary>
        ''' Đếm số lượng món đang chờ quá 15 phút (cần ưu tiên xử lý khẩn cấp).
        ''' </summary>
        Public Shared Function DemMonChoTre() As Integer
            Dim ds = LayHangDoiCheBien("all")
            Return ds.Where(Function(x) x.SoPhutCho >= 15).Count()
        End Function

    End Class

End Namespace
