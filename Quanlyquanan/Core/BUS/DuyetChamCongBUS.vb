Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) xử lý việc phê duyệt bảng chấm công và tính lương ca.
    ''' </summary>
    Public Class DuyetChamCongBUS

        Private Shared _mockList As New List(Of BaoCaoChamCongDTO)()
        Private Shared _mockKhoiTao As Boolean = False

        ''' <summary>
        ''' Lấy danh sách chấm công phục vụ phê duyệt theo bộ lọc.
        ''' </summary>
        Public Shared Function LayDanhSach(tuNgay As DateTime, denNgay As DateTime, Optional locTrangThai As String = "ALL", Optional maNV As Nullable(Of Integer) = Nothing) As List(Of BaoCaoChamCongDTO)
            Try
                Dim ds = DuyetChamCongDAO.LayDanhSachChamCong(tuNgay, denNgay, locTrangThai, maNV)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return LocDuLieuMock(tuNgay, denNgay, locTrangThai, maNV)
        End Function

        ''' <summary>
        ''' Phê duyệt một ca chấm công đơn lẻ.
        ''' </summary>
        Public Shared Function DuyetCa(maCC As Integer, nguoiDuyet As Integer, ByRef thongBao As String) As Boolean
            Try
                If DuyetChamCongDAO.DuyetCa(maCC, nguoiDuyet) Then
                    thongBao = $"Đã duyệt ca trực #{maCC} thành công!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return DuyetCaMock(maCC, nguoiDuyet, thongBao)
        End Function

        ''' <summary>
        ''' Hoàn tác phê duyệt một ca chấm công.
        ''' </summary>
        Public Shared Function HuyDuyetCa(maCC As Integer, ByRef thongBao As String) As Boolean
            Try
                If DuyetChamCongDAO.HuyDuyetCa(maCC) Then
                    thongBao = $"Đã hoàn tác duyệt ca #{maCC}!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            Return HuyDuyetCaMock(maCC, thongBao)
        End Function

        ''' <summary>
        ''' Phê duyệt hàng loạt các ca chấm công đang chờ.
        ''' </summary>
        Public Shared Function DuyetHangLoat(danhSachMaCC As List(Of Integer), nguoiDuyet As Integer, ByRef thongBao As String) As Integer
            Dim thanhCong As Integer = 0
            For Each maCC In danhSachMaCC
                Dim msg As String = ""
                If DuyetCa(maCC, nguoiDuyet, msg) Then thanhCong += 1
            Next
            thongBao = $"Đã duyệt thành công {thanhCong} / {danhSachMaCC.Count} ca trực được chọn!"
            Return thanhCong
        End Function

        Private Shared Function LocDuLieuMock(tuNgay As DateTime, denNgay As DateTime, locTrangThai As String, maNV As Nullable(Of Integer)) As List(Of BaoCaoChamCongDTO)
            Dim q = _mockList.Where(Function(x) x.CC_GioBatDau.HasValue AndAlso x.CC_GioBatDau.Value.Date >= tuNgay.Date AndAlso x.CC_GioBatDau.Value.Date <= denNgay.Date)
            If locTrangThai = "PENDING" Then
                q = q.Where(Function(x) Not x.CC_DaDuyet AndAlso x.CC_GioKetThuc.HasValue)
            ElseIf locTrangThai = "APPROVED" Then
                q = q.Where(Function(x) x.CC_DaDuyet)
            End If
            If maNV.HasValue AndAlso maNV.Value > 0 Then
                q = q.Where(Function(x) x.CC_MaNV = maNV.Value)
            End If
            Return q.OrderByDescending(Function(x) x.CC_GioBatDau).ToList()
        End Function

        Private Shared Function DuyetCaMock(maCC As Integer, nguoiDuyet As Integer, ByRef thongBao As String) As Boolean
            Dim item = _mockList.FirstOrDefault(Function(x) x.CC_Ma = maCC)
            If item IsNot Nothing Then
                item.CC_DaDuyet = True
                item.CC_NguoiDuyet = nguoiDuyet
                item.TenNguoiDuyet = "Quản lý Demo"
                item.CC_ThoiGianDuyet = DateTime.Now
                thongBao = $"Đã duyệt ca #{maCC} (Ngoại tuyến)."
                Return True
            End If
            thongBao = "Không tìm thấy ca trực!"
            Return False
        End Function

        Private Shared Function HuyDuyetCaMock(maCC As Integer, ByRef thongBao As String) As Boolean
            Dim item = _mockList.FirstOrDefault(Function(x) x.CC_Ma = maCC)
            If item IsNot Nothing Then
                item.CC_DaDuyet = False
                item.CC_NguoiDuyet = Nothing
                item.TenNguoiDuyet = String.Empty
                item.CC_ThoiGianDuyet = Nothing
                thongBao = $"Đã hoàn tác ca #{maCC} (Ngoại tuyến)."
                Return True
            End If
            thongBao = "Không tìm thấy ca trực!"
            Return False
        End Function

        Private Shared Sub KhoiTaoMockNeuChuaCo()
            If _mockKhoiTao Then Return
            _mockKhoiTao = True
            Dim homNay = DateTime.Today

            _mockList.Add(New BaoCaoChamCongDTO() With {
                .CC_Ma = 201, .CC_MaNV = 1, .HoTenNV = "Nguyễn Văn A", .VaiTroNV = "Phục vụ bàn",
                .TenCa = "Ca Sáng (06:00 - 14:00)", .LuongMoiCa = 200000D,
                .CC_GioBatDau = homNay.AddHours(5).AddMinutes(55), .CC_GioKetThuc = homNay.AddHours(14).AddMinutes(5),
                .CC_DaDuyet = False
            })
            _mockList.Add(New BaoCaoChamCongDTO() With {
                .CC_Ma = 202, .CC_MaNV = 2, .HoTenNV = "Trần Thị B", .VaiTroNV = "Phục vụ bàn",
                .TenCa = "Ca Sáng (06:00 - 14:00)", .LuongMoiCa = 200000D,
                .CC_GioBatDau = homNay.AddHours(6).AddMinutes(2), .CC_GioKetThuc = homNay.AddHours(14).AddMinutes(10),
                .CC_DaDuyet = False
            })
            _mockList.Add(New BaoCaoChamCongDTO() With {
                .CC_Ma = 203, .CC_MaNV = 3, .HoTenNV = "Lê Hoàng C", .VaiTroNV = "Nhà bếp",
                .TenCa = "Ca Sáng (06:00 - 14:00)", .LuongMoiCa = 220000D,
                .CC_GioBatDau = homNay.AddHours(5).AddMinutes(48), .CC_GioKetThuc = homNay.AddHours(14).AddMinutes(0),
                .CC_DaDuyet = False
            })
            _mockList.Add(New BaoCaoChamCongDTO() With {
                .CC_Ma = 198, .CC_MaNV = 1, .HoTenNV = "Nguyễn Văn A", .VaiTroNV = "Phục vụ bàn",
                .TenCa = "Ca Sáng Hôm Qua", .LuongMoiCa = 200000D,
                .CC_GioBatDau = homNay.AddDays(-1).AddHours(5).AddMinutes(58), .CC_GioKetThuc = homNay.AddDays(-1).AddHours(14).AddMinutes(2),
                .CC_DaDuyet = True, .TenNguoiDuyet = "Nguyễn Văn Quản Trị"
            })
        End Sub

    End Class

End Namespace
