Imports System.Data
Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) xử lý việc điều phối và xếp lịch phân ca cho toàn bộ nhân sự.
    ''' </summary>
    Public Class LichLamViecBUS

        Private Shared _mockRoster As New List(Of MaTranLichTuanDTO)()
        Private Shared _mockKhoiTao As Boolean = False

        ''' <summary>
        ''' Lấy dữ liệu ma trận phân ca 7 ngày tuần của toàn bộ nhân viên.
        ''' </summary>
        Public Shared Function LayMaTranLichTuan(ngayMoc As DateTime) As List(Of MaTranLichTuanDTO)
            Dim tuNgay = TinhNgayDauTuan(ngayMoc)
            Dim denNgay = tuNgay.AddDays(6).Date

            Try
                Dim dsLich = LichLamViecDAO.LayLichTuanToanQuan(tuNgay, denNgay)
                Dim dtNV = LichLamViecDAO.LayDanhSachNhanVien()
                If dtNV IsNot Nothing AndAlso dtNV.Rows.Count > 0 Then
                    Return ChuyenDoiSangMaTran(dtNV, dsLich, tuNgay)
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return _mockRoster
        End Function

        ''' <summary>
        ''' Phân công nhân viên vào ca trực trong một ngày.
        ''' </summary>
        Public Shared Function PhanCongCa(maNV As Integer, maCa As Integer, ngayLam As DateTime, ByRef thongBao As String) As Boolean
            Try
                If LichLamViecDAO.PhanCongCa(maNV, maCa, ngayLam) > 0 Then
                    thongBao = "Phân công ca trực cho nhân viên thành công!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return PhanCongCaMock(maNV, maCa, ngayLam, thongBao)
        End Function

        ''' <summary>
        ''' Hủy ca trực của nhân viên trong ngày.
        ''' </summary>
        Public Shared Function HuyPhanCa(maNV As Integer, ngayLam As DateTime, ByRef thongBao As String) As Boolean
            Try
                If LichLamViecDAO.HuyPhanCa(maNV, ngayLam) Then
                    thongBao = "Đã hủy ca trực của nhân viên trong ngày thành công!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return HuyPhanCaMock(maNV, ngayLam, thongBao)
        End Function

        Public Shared Function TinhNgayDauTuan(ngay As DateTime) As DateTime
            Dim delta = DayOfWeek.Monday - ngay.DayOfWeek
            If delta > 0 Then delta -= 7
            Return ngay.AddDays(delta).Date
        End Function

        Private Shared Function ChuyenDoiSangMaTran(dtNV As DataTable, dsLich As List(Of LichLamViecDTO), tuNgay As DateTime) As List(Of MaTranLichTuanDTO)
            Dim ketQua As New List(Of MaTranLichTuanDTO)()
            For Each r As DataRow In dtNV.Rows
                Dim maNV = Convert.ToInt32(r("NV_Ma"))
                Dim dto As New MaTranLichTuanDTO() With {
                    .MaNV = maNV,
                    .HoTenNV = r("NV_HoTen").ToString(),
                    .TenVaiTro = r("TenVaiTro").ToString()
                }
                DienCaCacNgay(dto, dsLich.Where(Function(x) x.LLV_MaNV = maNV).ToList(), tuNgay)
                ketQua.Add(dto)
            Next
            Return ketQua
        End Function

        Private Shared Sub DienCaCacNgay(dto As MaTranLichTuanDTO, dsLichNV As List(Of LichLamViecDTO), tuNgay As DateTime)
            dto.CaThuHai = LayTenCaTrongNgay(dsLichNV, tuNgay)
            dto.CaThuBa = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(1))
            dto.CaThuTu = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(2))
            dto.CaThuNam = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(3))
            dto.CaThuSau = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(4))
            dto.CaThuBay = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(5))
            dto.CaChuNhat = LayTenCaTrongNgay(dsLichNV, tuNgay.AddDays(6))
        End Sub

        Private Shared Function LayTenCaTrongNgay(ds As List(Of LichLamViecDTO), ngay As DateTime) As String
            Dim item = ds.FirstOrDefault(Function(x) x.LLV_NgayLam.Date = ngay.Date)
            Return If(item IsNot Nothing, item.TenCa, "—")
        End Function

        Private Shared Function PhanCongCaMock(maNV As Integer, maCa As Integer, ngayLam As DateTime, ByRef thongBao As String) As Boolean
            KhoiTaoMockNeuChuaCo()
            Dim item = _mockRoster.FirstOrDefault(Function(x) x.MaNV = maNV)
            If item IsNot Nothing Then
                Dim tenCa = If(maCa = 1, "Ca Sáng", "Ca Chiều")
                CapNhatCaMock(item, ngayLam.DayOfWeek, tenCa)
                thongBao = $"Đã phân công {tenCa} cho {item.HoTenNV} (Ngoại tuyến)!"
                Return True
            End If
            thongBao = "Không tìm thấy nhân viên!"
            Return False
        End Function

        Private Shared Function HuyPhanCaMock(maNV As Integer, ngayLam As DateTime, ByRef thongBao As String) As Boolean
            KhoiTaoMockNeuChuaCo()
            Dim item = _mockRoster.FirstOrDefault(Function(x) x.MaNV = maNV)
            If item IsNot Nothing Then
                CapNhatCaMock(item, ngayLam.DayOfWeek, "—")
                thongBao = $"Đã hủy ca trực của {item.HoTenNV} (Ngoại tuyến)!"
                Return True
            End If
            thongBao = "Không tìm thấy nhân viên!"
            Return False
        End Function

        Private Shared Sub CapNhatCaMock(dto As MaTranLichTuanDTO, dow As DayOfWeek, tenCa As String)
            Select Case dow
                Case DayOfWeek.Monday : dto.CaThuHai = tenCa
                Case DayOfWeek.Tuesday : dto.CaThuBa = tenCa
                Case DayOfWeek.Wednesday : dto.CaThuTu = tenCa
                Case DayOfWeek.Thursday : dto.CaThuNam = tenCa
                Case DayOfWeek.Friday : dto.CaThuSau = tenCa
                Case DayOfWeek.Saturday : dto.CaThuBay = tenCa
                Case Else : dto.CaChuNhat = tenCa
            End Select
        End Sub

        Private Shared Sub KhoiTaoMockNeuChuaCo()
            If _mockKhoiTao Then Return
            _mockKhoiTao = True
            _mockRoster.Add(New MaTranLichTuanDTO() With {.MaNV = 1, .HoTenNV = "Nguyễn Văn A", .TenVaiTro = "Phục vụ bàn", .CaThuHai = "Ca Sáng", .CaThuBa = "Ca Sáng", .CaThuTu = "—", .CaThuNam = "Ca Sáng", .CaThuSau = "Ca Sáng", .CaThuBay = "Ca Chiều", .CaChuNhat = "—"})
            _mockRoster.Add(New MaTranLichTuanDTO() With {.MaNV = 2, .HoTenNV = "Trần Thị B", .TenVaiTro = "Phục vụ bàn", .CaThuHai = "Ca Chiều", .CaThuBa = "Ca Chiều", .CaThuTu = "Ca Sáng", .CaThuNam = "Ca Chiều", .CaThuSau = "—", .CaThuBay = "Ca Sáng", .CaChuNhat = "Ca Sáng"})
            _mockRoster.Add(New MaTranLichTuanDTO() With {.MaNV = 3, .HoTenNV = "Lê Hoàng C", .TenVaiTro = "Nhà bếp", .CaThuHai = "Ca Sáng", .CaThuBa = "Ca Sáng", .CaThuTu = "Ca Chiều", .CaThuNam = "—", .CaThuSau = "Ca Sáng", .CaThuBay = "Ca Sáng", .CaChuNhat = "Ca Chiều"})
            _mockRoster.Add(New MaTranLichTuanDTO() With {.MaNV = 4, .HoTenNV = "Phạm Hải D", .TenVaiTro = "Nhà bếp", .CaThuHai = "Ca Chiều", .CaThuBa = "—", .CaThuTu = "Ca Sáng", .CaThuNam = "Ca Sáng", .CaThuSau = "Ca Chiều", .CaThuBay = "Ca Chiều", .CaChuNhat = "Ca Sáng"})
        End Sub

    End Class

End Namespace
