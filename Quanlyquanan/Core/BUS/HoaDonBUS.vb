Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) xử lý luồng Bán hàng POS, mở bàn, gọi món, chuyển bàn và thanh toán.
    ''' </summary>
    Public Class HoaDonBUS

        ' Bộ nhớ đệm phục vụ Demo Offline khi chưa kết nối Database
        Private Shared ReadOnly _demoHoaDons As New Dictionary(Of Integer, HoaDonDTO)()
        Private Shared ReadOnly _demoChiTiets As New Dictionary(Of Integer, List(Of ChiTietHoaDonDTO))()
        Private Shared _demoNextHDMa As Integer = 1000
        Private Shared _demoNextCTHDMa As Integer = 5000

        ''' <summary>
        ''' Lấy thông tin hóa đơn hiện tại của bàn.
        ''' </summary>
        Public Shared Function LayHoaDonHienTai(maBan As Integer) As HoaDonDTO
            Try
                Dim hd As HoaDonDTO = HoaDonDAO.LayHoaDonHienTaiCuaBan(maBan)
                If hd IsNot Nothing Then Return hd
            Catch ex As Exception
                ' Fallback demo
            End Try

            If _demoHoaDons.ContainsKey(maBan) Then
                Return _demoHoaDons(maBan)
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Lấy danh sách món ăn trong hóa đơn.
        ''' </summary>
        Public Shared Function LayDanhSachMon(maHD As Integer) As List(Of ChiTietHoaDonDTO)
            Try
                Dim ds As List(Of ChiTietHoaDonDTO) = ChiTietHoaDonDAO.LayDanhSachTheoHoaDon(maHD)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback demo
            End Try

            If _demoChiTiets.ContainsKey(maHD) Then
                Return _demoChiTiets(maHD).Where(Function(x) x.CTHD_TrangThaiMon <> 3).ToList()
            End If
            Return New List(Of ChiTietHoaDonDTO)()
        End Function

        ''' <summary>
        ''' Mở bàn mới: Kiểm tra tính hợp lệ và tạo hóa đơn.
        ''' </summary>
        Public Shared Function MoBan(maBan As Integer, maNV As Integer, soKhach As Integer,
                                     Optional nguoiTao As Nullable(Of Integer) = Nothing,
                                     Optional maCa As Nullable(Of Integer) = Nothing) As HoaDonDTO
            If soKhach <= 0 Then
                Throw New ArgumentException("Số lượng khách phải lớn hơn 0!")
            End If

            Try
                Dim maHD As Integer = HoaDonDAO.MoBan(maBan, maNV, soKhach, nguoiTao, maCa)
                If maHD > 0 Then
                    Return HoaDonDAO.LayHoaDonHienTaiCuaBan(maBan)
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            ' Fallback Demo Memory
            _demoNextHDMa += 1
            Dim newHd As New HoaDonDTO() With {
                .HD_Ma = _demoNextHDMa,
                .HD_MaBan = maBan,
                .HD_MaNVPhucVu = maNV,
                .HD_SoLuongKhach = soKhach,
                .HD_ThoiGianVao = DateTime.Now,
                .HD_TrangThai = 0,
                .HD_TongTien = 0
            }
            _demoHoaDons(maBan) = newHd
            _demoChiTiets(newHd.HD_Ma) = New List(Of ChiTietHoaDonDTO)()
            Return newHd
        End Function

        ''' <summary>
        ''' Thêm món vào hóa đơn và tính lại tổng tiền.
        ''' </summary>
        Public Shared Function ThemMon(maHD As Integer, maMonAn As Integer, tenMon As String,
                                       soLuong As Integer, donGia As Decimal, ghiChu As String) As Boolean
            If soLuong <= 0 Then
                Throw New ArgumentException("Số lượng món gọi phải lớn hơn 0!")
            End If

            Dim thanhCong As Boolean = False
            Try
                Dim cthdMa As Integer = ChiTietHoaDonDAO.ThemMon(maHD, maMonAn, soLuong, donGia, ghiChu)
                If cthdMa > 0 Then
                    Dim dsMon As List(Of ChiTietHoaDonDTO) = ChiTietHoaDonDAO.LayDanhSachTheoHoaDon(maHD)
                    Dim tongTien As Decimal = dsMon.Sum(Function(x) x.ThanhTien)
                    HoaDonDAO.CapNhatTongTien(maHD, tongTien)
                    thanhCong = True
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            If Not thanhCong Then
                ThemMonDemo(maHD, maMonAn, tenMon, soLuong, donGia, ghiChu)
                thanhCong = True
            End If
            Return thanhCong
        End Function

        Private Shared Sub ThemMonDemo(maHD As Integer, maMonAn As Integer, tenMon As String,
                                      soLuong As Integer, donGia As Decimal, ghiChu As String)
            If Not _demoChiTiets.ContainsKey(maHD) Then
                _demoChiTiets(maHD) = New List(Of ChiTietHoaDonDTO)()
            End If

            _demoNextCTHDMa += 1
            Dim cthd As New ChiTietHoaDonDTO() With {
                .CTHD_Ma = _demoNextCTHDMa,
                .CTHD_MaHoaDon = maHD,
                .CTHD_MaMonAn = maMonAn,
                .TenMonAn = tenMon,
                .CTHD_SoLuong = soLuong,
                .CTHD_DonGia = donGia,
                .CTHD_GhiChu = ghiChu,
                .CTHD_ThoiGianGoi = DateTime.Now,
                .CTHD_TrangThaiMon = 0
            }
            _demoChiTiets(maHD).Add(cthd)

            ' Cập nhật tổng tiền demo
            For Each hd In _demoHoaDons.Values
                If hd.HD_Ma = maHD Then
                    hd.HD_TongTien = _demoChiTiets(maHD).Where(Function(x) x.CTHD_TrangThaiMon <> 3).Sum(Function(x) x.ThanhTien)
                    Exit For
                End If
            Next
        End Sub

        ''' <summary>
        ''' Hủy món ăn trong hóa đơn (chỉ khi món chưa nấu).
        ''' </summary>
        Public Shared Function HuyMon(maHD As Integer, maCTHD As Integer) As Boolean
            Try
                If ChiTietHoaDonDAO.HuyMon(maCTHD) Then
                    Dim dsMon As List(Of ChiTietHoaDonDTO) = ChiTietHoaDonDAO.LayDanhSachTheoHoaDon(maHD)
                    Dim tongTien As Decimal = dsMon.Sum(Function(x) x.ThanhTien)
                    HoaDonDAO.CapNhatTongTien(maHD, tongTien)
                    Return True
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            If _demoChiTiets.ContainsKey(maHD) Then
                For Each item In _demoChiTiets(maHD)
                    If item.CTHD_Ma = maCTHD AndAlso item.CTHD_TrangThaiMon = 0 Then
                        item.CTHD_TrangThaiMon = 3
                        Exit For
                    End If
                Next
                For Each hd In _demoHoaDons.Values
                    If hd.HD_Ma = maHD Then
                        hd.HD_TongTien = _demoChiTiets(maHD).Where(Function(x) x.CTHD_TrangThaiMon <> 3).Sum(Function(x) x.ThanhTien)
                        Exit For
                    End If
                Next
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        ''' Thanh toán hóa đơn và đóng bàn.
        ''' </summary>
        Public Shared Function ThanhToan(maHD As Integer, maBan As Integer, phuongThuc As String, tongTien As Decimal) As Boolean
            Try
                If HoaDonDAO.ThanhToan(maHD, maBan, phuongThuc, tongTien) Then
                    Return True
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            If _demoHoaDons.ContainsKey(maBan) Then
                Dim hd = _demoHoaDons(maBan)
                hd.HD_TrangThai = 1
                hd.HD_PhuongThucThanhToan = phuongThuc
                hd.HD_TongTien = tongTien
                hd.HD_ThoiGianThanhToan = DateTime.Now
                _demoHoaDons.Remove(maBan)
                Return True
            End If
            Return True
        End Function

        ''' <summary>
        ''' Chuyển hóa đơn sang bàn mới đang trống.
        ''' </summary>
        Public Shared Function ChuyenBan(maHD As Integer, maBanCu As Integer, maBanMoi As Integer) As Boolean
            Try
                If HoaDonDAO.ChuyenBan(maHD, maBanCu, maBanMoi) Then
                    Return True
                End If
            Catch ex As Exception
                ' Fallback demo
            End Try

            If _demoHoaDons.ContainsKey(maBanCu) Then
                Dim hd = _demoHoaDons(maBanCu)
                hd.HD_MaBan = maBanMoi
                _demoHoaDons.Remove(maBanCu)
                _demoHoaDons(maBanMoi) = hd
                Return True
            End If
            Return True
        End Function

    End Class

End Namespace
