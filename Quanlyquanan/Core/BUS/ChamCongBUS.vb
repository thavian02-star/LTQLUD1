Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) quản lý việc điểm danh, chấm công và lịch trực của nhân viên.
    ''' </summary>
    Public Class ChamCongBUS

        Private Shared _mockChamCongList As New List(Of ChamCongDTO)()
        Private Shared _mockLichList As New List(Of LichLamViecDTO)()
        Private Shared _mockKhoiTao As Boolean = False

        ''' <summary>
        ''' Lấy thông tin phiên chấm công gần nhất trong ngày của nhân viên.
        ''' </summary>
        Public Shared Function LayChamCongHomNay(maNV As Integer) As ChamCongDTO
            Try
                Dim cc = ChamCongDAO.LayChamCongHomNay(maNV)
                If cc IsNot Nothing Then Return cc
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return _mockChamCongList.Where(Function(x) x.CC_MaNV = maNV AndAlso x.CC_Xoa = False AndAlso x.CC_GioBatDau.HasValue AndAlso x.CC_GioBatDau.Value.Date = DateTime.Today).OrderByDescending(Function(x) x.CC_GioBatDau).FirstOrDefault()
        End Function

        ''' <summary>
        ''' Điểm danh vào ca làm việc (Check-in).
        ''' </summary>
        Public Shared Function VaoCa(maNV As Integer, maLich As Nullable(Of Integer), ByRef thongBao As String) As ChamCongDTO
            Dim ccHienTai = LayChamCongHomNay(maNV)
            If ccHienTai IsNot Nothing AndAlso Not ccHienTai.CC_GioKetThuc.HasValue Then
                thongBao = "Bạn đang trong ca trực! Vui lòng kết thúc ca hiện tại trước khi vào ca mới."
                Return Nothing
            End If

            Try
                Dim maCC = ChamCongDAO.VaoCa(maNV, maLich)
                If maCC > 0 Then
                    thongBao = "Điểm danh VÀO CA thành công. Chúc bạn một ngày làm việc hiệu quả!"
                    Return ChamCongDAO.LayChamCongHomNay(maNV)
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return VaoCaMock(maNV, maLich, thongBao)
        End Function

        ''' <summary>
        ''' Điểm danh kết thúc ca làm việc (Check-out).
        ''' </summary>
        Public Shared Function RaCa(maCC As Integer, ByRef thongBao As String) As Boolean
            Try
                If ChamCongDAO.RaCa(maCC) Then
                    thongBao = "Ghi nhận HẾT CA thành công! Cảm ơn bạn vì một ca làm việc tận tụy."
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return RaCaMock(maCC, thongBao)
        End Function

        ''' <summary>
        ''' Lấy danh sách lịch phân ca trong tuần chứa ngày được chọn (Thứ 2 đến CN).
        ''' </summary>
        Public Shared Function LayLichTuan(maNV As Integer, Optional mocNgay As Nullable(Of DateTime) = Nothing) As List(Of LichLamViecDTO)
            Dim ngay = If(mocNgay.HasValue, mocNgay.Value, DateTime.Today)
            Dim delta = DayOfWeek.Monday - ngay.DayOfWeek
            If delta > 0 Then delta -= 7
            Dim thuHai = ngay.AddDays(delta).Date
            Dim chuNhat = thuHai.AddDays(6).Date

            Try
                Dim ds = ChamCongDAO.LayLichTuanCuaNhanVien(maNV, thuHai, chuNhat)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return _mockLichList.Where(Function(x) x.LLV_MaNV = maNV AndAlso x.LLV_NgayLam >= thuHai AndAlso x.LLV_NgayLam <= chuNhat).OrderBy(Function(x) x.LLV_NgayLam).ToList()
        End Function

        ''' <summary>
        ''' Lấy lịch sử các lần chấm công gần nhất của nhân viên.
        ''' </summary>
        Public Shared Function LayLichSu(maNV As Integer, Optional limit As Integer = 10) As List(Of ChamCongDTO)
            Try
                Dim ds = ChamCongDAO.LayLichSuChamCong(maNV, limit)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return _mockChamCongList.Where(Function(x) x.CC_MaNV = maNV AndAlso x.CC_Xoa = False).OrderByDescending(Function(x) x.CC_GioBatDau).Take(limit).ToList()
        End Function

        Private Shared Function VaoCaMock(maNV As Integer, maLich As Nullable(Of Integer), ByRef thongBao As String) As ChamCongDTO
            KhoiTaoMockNeuChuaCo()
            Dim newId = If(_mockChamCongList.Count > 0, _mockChamCongList.Max(Function(x) x.CC_Ma) + 1, 1)
            Dim item As New ChamCongDTO() With {
                .CC_Ma = newId,
                .CC_MaNV = maNV,
                .CC_MaLich = maLich,
                .CC_GioBatDau = DateTime.Now,
                .CC_DaDuyet = False,
                .TenCa = "Ca Sáng (06:00 - 14:00)",
                .TenNV = "Nhân Viên Hiện Tại",
                .NgayLam = DateTime.Today
            }
            _mockChamCongList.Insert(0, item)
            thongBao = "Điểm danh VÀO CA thành công (Chế độ Ngoại tuyến)."
            Return item
        End Function

        Private Shared Function RaCaMock(maCC As Integer, ByRef thongBao As String) As Boolean
            KhoiTaoMockNeuChuaCo()
            Dim item = _mockChamCongList.FirstOrDefault(Function(x) x.CC_Ma = maCC)
            If item IsNot Nothing Then
                item.CC_GioKetThuc = DateTime.Now
                thongBao = "Ghi nhận HẾT CA thành công (Chế độ Ngoại tuyến)."
                Return True
            End If
            thongBao = "Không tìm thấy phiên làm việc!"
            Return False
        End Function

        Private Shared Sub KhoiTaoMockNeuChuaCo()
            If _mockKhoiTao Then Return
            _mockKhoiTao = True

            Dim homNay = DateTime.Today
            Dim delta = DayOfWeek.Monday - homNay.DayOfWeek
            If delta > 0 Then delta -= 7
            Dim thuHai = homNay.AddDays(delta).Date

            ' Giả lập 4 ca trong tuần cho nhân viên
            _mockLichList.Add(New LichLamViecDTO() With {.LLV_Ma = 1, .LLV_MaNV = 1, .LLV_MaCa = 1, .LLV_NgayLam = thuHai, .TenCa = "Ca Sáng", .GioBatDau = New TimeSpan(6, 0, 0), .GioKetThuc = New TimeSpan(14, 0, 0)})
            _mockLichList.Add(New LichLamViecDTO() With {.LLV_Ma = 2, .LLV_MaNV = 1, .LLV_MaCa = 2, .LLV_NgayLam = thuHai.AddDays(1), .TenCa = "Ca Chiều", .GioBatDau = New TimeSpan(14, 0, 0), .GioKetThuc = New TimeSpan(22, 0, 0)})
            _mockLichList.Add(New LichLamViecDTO() With {.LLV_Ma = 3, .LLV_MaNV = 1, .LLV_MaCa = 1, .LLV_NgayLam = homNay, .TenCa = "Ca Sáng", .GioBatDau = New TimeSpan(6, 0, 0), .GioKetThuc = New TimeSpan(14, 0, 0)})
            _mockLichList.Add(New LichLamViecDTO() With {.LLV_Ma = 4, .LLV_MaNV = 1, .LLV_MaCa = 2, .LLV_NgayLam = thuHai.AddDays(5), .TenCa = "Ca Chiều", .GioBatDau = New TimeSpan(14, 0, 0), .GioKetThuc = New TimeSpan(22, 0, 0)})

            ' Giả lập lịch sử chấm công
            _mockChamCongList.Add(New ChamCongDTO() With {
                .CC_Ma = 101, .CC_MaNV = 1, .CC_MaLich = 1,
                .CC_GioBatDau = thuHai.AddHours(5).AddMinutes(55),
                .CC_GioKetThuc = thuHai.AddHours(14).AddMinutes(5),
                .CC_DaDuyet = True, .TenCa = "Ca Sáng", .NgayLam = thuHai
            })
            _mockChamCongList.Add(New ChamCongDTO() With {
                .CC_Ma = 102, .CC_MaNV = 1, .CC_MaLich = 2,
                .CC_GioBatDau = thuHai.AddDays(1).AddHours(13).AddMinutes(50),
                .CC_GioKetThuc = thuHai.AddDays(1).AddHours(22).AddMinutes(10),
                .CC_DaDuyet = True, .TenCa = "Ca Chiều", .NgayLam = thuHai.AddDays(1)
            })
        End Sub

    End Class

End Namespace
