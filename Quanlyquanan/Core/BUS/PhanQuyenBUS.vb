Imports System.Linq
Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS

    ''' <summary>
    ''' Tầng Nghiệp Vụ (BUS) xử lý việc phân quyền và quản lý vai trò người dùng động.
    ''' </summary>
    Public Class PhanQuyenBUS

        Private Shared _mockVaiTro As New List(Of VaiTroDTO)()
        Private Shared _mockQuyen As New List(Of QuyenDTO)()
        Private Shared _mockMap As New Dictionary(Of Integer, List(Of Integer))()
        Private Shared _mockKhoiTao As Boolean = False

        ''' <summary>
        ''' Lấy danh sách các vai trò trong hệ thống.
        ''' </summary>
        Public Shared Function LayDanhSachVaiTro() As List(Of VaiTroDTO)
            Try
                Dim ds = PhanQuyenDAO.LayDanhSachVaiTro()
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Return _mockVaiTro
        End Function

        ''' <summary>
        ''' Lấy danh sách tất cả các quyền hệ thống kèm trạng thái cấp cho vai trò.
        ''' </summary>
        Public Shared Function LayDanhSachQuyen(maVaiTro As Integer) As List(Of QuyenDTO)
            Try
                Dim ds = PhanQuyenDAO.LayDanhSachQuyen(maVaiTro)
                If ds IsNot Nothing AndAlso ds.Count > 0 Then Return ds
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Dim dsCap = If(_mockMap.ContainsKey(maVaiTro), _mockMap(maVaiTro), New List(Of Integer)())
            Dim kq As New List(Of QuyenDTO)()
            For Each q In _mockQuyen
                kq.Add(New QuyenDTO() With {
                    .Q_Ma = q.Q_Ma, .Q_Ten = q.Q_Ten, .Q_MoTa = q.Q_MoTa,
                    .Q_Tag = q.Q_Tag, .Q_Nhom = q.Q_Nhom,
                    .DuocCap = (maVaiTro = 1 OrElse dsCap.Contains(q.Q_Ma))
                })
            Next
            Return kq
        End Function

        ''' <summary>
        ''' Lưu phân bổ danh sách quyền hạn cho vai trò.
        ''' </summary>
        Public Shared Function LuuPhanQuyen(maVaiTro As Integer, dsMaQuyen As List(Of Integer), ByRef thongBao As String) As Boolean
            If maVaiTro = 1 Then
                thongBao = "Vai trò Chủ quán luôn mặc định sở hữu toàn quyền hệ thống!"
                Return True
            End If

            Try
                If PhanQuyenDAO.LuuPhanQuyen(maVaiTro, dsMaQuyen) Then
                    thongBao = "Cập nhật phân quyền cho vai trò thành công!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            _mockMap(maVaiTro) = dsMaQuyen
            thongBao = "Cập nhật phân quyền cho vai trò thành công (Ngoại tuyến)!"
            Return True
        End Function

        ''' <summary>
        ''' Thêm một vai trò mới vào hệ thống.
        ''' </summary>
        Public Shared Function ThemVaiTro(ten As String, moTa As String, ByRef thongBao As String) As Boolean
            If String.IsNullOrWhiteSpace(ten) Then
                thongBao = "Tên vai trò không được để trống!"
                Return False
            End If

            Try
                If PhanQuyenDAO.ThemVaiTro(ten, moTa) > 0 Then
                    thongBao = $"Đã thêm vai trò '{ten}' thành công!"
                    Return True
                End If
            Catch ex As Exception
                ' Fallback offline mock
            End Try

            KhoiTaoMockNeuChuaCo()
            Dim newId = _mockVaiTro.Max(Function(x) x.VT_Ma) + 1
            _mockVaiTro.Add(New VaiTroDTO() With {.VT_Ma = newId, .VT_Ten = ten, .VT_MoTa = moTa, .SoLuongQuyen = 0})
            _mockMap(newId) = New List(Of Integer)()
            thongBao = $"Đã thêm vai trò '{ten}' thành công (Ngoại tuyến)!"
            Return True
        End Function

        Private Shared Sub KhoiTaoMockNeuChuaCo()
            If _mockKhoiTao Then Return
            _mockKhoiTao = True

            _mockVaiTro.Add(New VaiTroDTO() With {.VT_Ma = 1, .VT_Ten = "Chủ Quán / Giám Đốc", .VT_MoTa = "Toàn quyền quản trị hệ thống", .SoLuongQuyen = 18})
            _mockVaiTro.Add(New VaiTroDTO() With {.VT_Ma = 2, .VT_Ten = "Quản Lý Cơ Sở", .VT_MoTa = "Quản lý ca, duyệt công, báo cáo", .SoLuongQuyen = 14})
            _mockVaiTro.Add(New VaiTroDTO() With {.VT_Ma = 3, .VT_Ten = "Nhân Viên Phục Vụ", .VT_MoTa = "Xem bàn, mở bàn, gọi món", .SoLuongQuyen = 6})
            _mockVaiTro.Add(New VaiTroDTO() With {.VT_Ma = 4, .VT_Ten = "Nhân Viên Nhà Bếp", .VT_MoTa = "Tiếp nhận bếp KDS, báo xong món", .SoLuongQuyen = 4})

            ThemQuyenMock(1, "Xem Sơ Đồ Bàn POS", "POS_XEM_SO_DO_BAN", "🍽️ Bán Hàng POS")
            ThemQuyenMock(2, "Mở Bàn & Gọi Món", "POS_MO_BAN_GOI_MON", "🍽️ Bán Hàng POS")
            ThemQuyenMock(3, "Chuyển Bàn Phục Vụ", "POS_CHUYEN_BAN", "🍽️ Bán Hàng POS")
            ThemQuyenMock(4, "Thanh Toán Hóa Đơn", "POS_THANH_TOAN", "🍽️ Bán Hàng POS")
            ThemQuyenMock(5, "Xem Hàng Đợi Bếp KDS", "KDS_XEM_HANG_DOI", "🍳 Nhà Bếp KDS")
            ThemQuyenMock(6, "Báo Xong Món KDS", "KDS_BAO_XONG_MON", "🍳 Nhà Bếp KDS")
            ThemQuyenMock(7, "Chấm Công Cá Nhân", "STAFF_CHAM_CONG_CA_NHAN", "⏱️ Nhân Sự & Chấm Công")
            ThemQuyenMock(8, "Duyệt Chấm Công", "STAFF_DUYET_CHAM_CONG", "⏱️ Nhân Sự & Chấm Công")
            ThemQuyenMock(9, "Quản Lý Phân Ca Tuần", "STAFF_XEP_LICH_TUAN", "⏱️ Nhân Sự & Chấm Công")
            ThemQuyenMock(10, "Báo Cáo Doanh Thu", "RPT_DOANH_THU", "📊 Báo Cáo & Thống Kê")
            ThemQuyenMock(11, "Báo Cáo Món Bán Chạy", "RPT_MON_BAN_CHAY", "📊 Báo Cáo & Thống Kê")
            ThemQuyenMock(12, "Quản Lý Danh Mục Món", "MASTER_MON_AN", "📋 Danh Mục Nền Tảng")

            _mockMap(2) = New List(Of Integer) From {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}
            _mockMap(3) = New List(Of Integer) From {1, 2, 3, 4, 7}
            _mockMap(4) = New List(Of Integer) From {5, 6, 7}
        End Sub

        Private Shared Sub ThemQuyenMock(id As Integer, ten As String, tag As String, nhom As String)
            _mockQuyen.Add(New QuyenDTO() With {.Q_Ma = id, .Q_Ten = ten, .Q_Tag = tag, .Q_Nhom = nhom, .Q_MoTa = $"Chức năng {ten}"})
        End Sub

    End Class

End Namespace
