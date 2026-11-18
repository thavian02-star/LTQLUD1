Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Lớp truy xuất dữ liệu (DAO) cho bảng Menu và bảng trung gian Menu_MonAn.
    ''' Sử dụng Parameterized Query chống SQL Injection, hỗ trợ lọc đa chiều và cập nhật giao dịch an toàn.
    ''' </summary>
    Public Class MenuDAO

        ''' <summary>
        ''' Lấy danh sách bảng Menu kinh doanh đang hoạt động (MN_Xoa = 0), hỗ trợ lọc theo loại thực đơn, trạng thái và từ khóa.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional loaiMenu As String = "",
                                           Optional trangThai As String = "") As List(Of MenuDTO)
            Dim danhSach As New List(Of MenuDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()
            Dim loai As String = If(loaiMenu, String.Empty).Trim()
            Dim status As String = If(trangThai, String.Empty).Trim()

            Try
                Dim sql As String = "
                    SELECT 
                        m.MN_Ma,
                        m.MN_Ten,
                        m.MN_LoaiMenu,
                        ISNULL(m.MN_MoTa, N'') AS MN_MoTa,
                        m.MN_TrangThai,
                        m.MN_Xoa,
                        COUNT(CASE WHEN mma.MMA_Xoa = 0 THEN mma.MMA_Ma END) AS SoLuongMon
                    FROM Menu m
                    LEFT JOIN Menu_MonAn mma ON mma.MMA_MaMenu = m.MN_Ma
                    WHERE m.MN_Xoa = 0
                      AND (@LoaiMenu = N'' OR @LoaiMenu = N'Tất cả loại thực đơn' OR m.MN_LoaiMenu = @LoaiMenu)
                      AND (@TrangThai = N'' OR @TrangThai = N'Tất cả trạng thái' OR m.MN_TrangThai = @TrangThai)
                      AND (@TuKhoa = N'' OR m.MN_Ten LIKE N'%' + @TuKhoa + N'%' OR ISNULL(m.MN_MoTa, N'') LIKE N'%' + @TuKhoa + N'%')
                    GROUP BY m.MN_Ma, m.MN_Ten, m.MN_LoaiMenu, m.MN_MoTa, m.MN_TrangThai, m.MN_Xoa
                    ORDER BY m.MN_Ma ASC;"

                Dim params As SqlParameter() = {
                    New SqlParameter("@LoaiMenu", SqlDbType.NVarChar, 50) With {.Value = loai},
                    New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = status},
                    New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = keyword}
                }

                Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, params)
                For Each row As DataRow In dt.Rows
                    Dim item As New MenuDTO() With {
                        .MaMenu = Convert.ToInt32(row("MN_Ma")),
                        .TenMenu = row("MN_Ten").ToString().Trim(),
                        .LoaiMenu = row("MN_LoaiMenu").ToString().Trim(),
                        .MoTa = row("MN_MoTa").ToString().Trim(),
                        .TrangThai = row("MN_TrangThai").ToString().Trim(),
                        .Xoa = Convert.ToBoolean(row("MN_Xoa")),
                        .SoLuongMon = Convert.ToInt32(row("SoLuongMon"))
                    }
                    danhSach.Add(item)
                Next
            Catch ex As Exception
                ' Ghi nhận hoặc trả về danh sách rỗng khi mất kết nối CSDL
            End Try

            Return danhSach
        End Function

        ''' <summary>
        ''' Lấy thông tin chi tiết một bảng Menu theo mã.
        ''' </summary>
        Public Shared Function LayMenuTheoMa(maMenu As Integer) As MenuDTO
            If maMenu <= 0 Then Return Nothing
            Try
                Dim sql As String = "
                    SELECT 
                        m.MN_Ma,
                        m.MN_Ten,
                        m.MN_LoaiMenu,
                        ISNULL(m.MN_MoTa, N'') AS MN_MoTa,
                        m.MN_TrangThai,
                        m.MN_Xoa,
                        (SELECT COUNT(*) FROM Menu_MonAn WHERE MMA_MaMenu = m.MN_Ma AND MMA_Xoa = 0) AS SoLuongMon
                    FROM Menu m
                    WHERE m.MN_Ma = @MaMenu AND m.MN_Xoa = 0;"

                Dim params As SqlParameter() = {
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu}
                }

                Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, params)
                If dt.Rows.Count > 0 Then
                    Dim row As DataRow = dt.Rows(0)
                    Return New MenuDTO() With {
                        .MaMenu = Convert.ToInt32(row("MN_Ma")),
                        .TenMenu = row("MN_Ten").ToString().Trim(),
                        .LoaiMenu = row("MN_LoaiMenu").ToString().Trim(),
                        .MoTa = row("MN_MoTa").ToString().Trim(),
                        .TrangThai = row("MN_TrangThai").ToString().Trim(),
                        .Xoa = Convert.ToBoolean(row("MN_Xoa")),
                        .SoLuongMon = Convert.ToInt32(row("SoLuongMon"))
                    }
                End If
            Catch ex As Exception
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' Lấy danh sách các món ăn đã được gán vào một Menu cụ thể (kèm giá và thứ tự hiển thị).
        ''' </summary>
        Public Shared Function LayDanhSachMonTheoMenu(maMenu As Integer) As List(Of MenuMonAnDTO)
            Dim danhSach As New List(Of MenuMonAnDTO)()
            If maMenu <= 0 Then Return danhSach

            Try
                Dim sql As String = "
                    SELECT 
                        mma.MMA_Ma,
                        mma.MMA_MaMenu,
                        mma.MMA_MaMonAn,
                        ma.MA_Ten,
                        ISNULL(dm.DM_Ten, N'Chưa phân loại') AS DM_Ten,
                        mma.MMA_DonGia,
                        mma.MMA_ThuTuHienThi,
                        ISNULL(mma.MMA_GhiChu, N'') AS MMA_GhiChu,
                        mma.MMA_Xoa
                    FROM Menu_MonAn mma
                    INNER JOIN MonAn ma ON ma.MA_Ma = mma.MMA_MaMonAn AND ma.MA_Xoa = 0
                    LEFT JOIN DanhMuc dm ON dm.DM_Ma = ma.MA_DanhMuc AND dm.DM_Xoa = 0
                    WHERE mma.MMA_MaMenu = @MaMenu
                      AND mma.MMA_Xoa = 0
                    ORDER BY mma.MMA_ThuTuHienThi ASC, ma.MA_Ten ASC;"

                Dim params As SqlParameter() = {
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu}
                }

                Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, params)
                For Each row As DataRow In dt.Rows
                    Dim item As New MenuMonAnDTO() With {
                        .MaMMA = Convert.ToInt32(row("MMA_Ma")),
                        .MaMenu = Convert.ToInt32(row("MMA_MaMenu")),
                        .MaMonAn = Convert.ToInt32(row("MMA_MaMonAn")),
                        .TenMonAn = row("MA_Ten").ToString().Trim(),
                        .TenDanhMuc = row("DM_Ten").ToString().Trim(),
                        .DonGia = Convert.ToDecimal(row("MMA_DonGia")),
                        .ThuTuHienThi = Convert.ToInt32(row("MMA_ThuTuHienThi")),
                        .GhiChu = row("MMA_GhiChu").ToString().Trim(),
                        .Xoa = Convert.ToBoolean(row("MMA_Xoa"))
                    }
                    danhSach.Add(item)
                Next
            Catch ex As Exception
            End Try

            Return danhSach
        End Function

        ''' <summary>
        ''' Lấy toàn bộ danh sách món ăn từ kho (MonAn) để nạp vào ComboBox chọn món.
        ''' </summary>
        Public Shared Function LayDanhSachMonAnKho() As List(Of MonAnDTO)
            Dim danhSach As New List(Of MonAnDTO)()
            Try
                Dim sql As String = "
                    SELECT 
                        ma.MA_Ma,
                        ma.MA_Ten,
                        ma.MA_DanhMuc,
                        ISNULL(dm.DM_Ten, N'Chưa phân loại') AS DM_Ten,
                        ma.MA_DonGia,
                        ma.MA_HetMon,
                        ISNULL(ma.MA_MoTa, N'') AS MA_MoTa,
                        ma.MA_Xoa
                    FROM MonAn ma
                    LEFT JOIN DanhMuc dm ON dm.DM_Ma = ma.MA_DanhMuc AND dm.DM_Xoa = 0
                    WHERE ma.MA_Xoa = 0
                    ORDER BY dm.DM_Ten ASC, ma.MA_Ten ASC;"

                Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)
                For Each row As DataRow In dt.Rows
                    danhSach.Add(New MonAnDTO() With {
                        .MaMonAn = Convert.ToInt32(row("MA_Ma")),
                        .TenMonAn = row("MA_Ten").ToString().Trim(),
                        .MaDanhMuc = If(IsDBNull(row("MA_DanhMuc")), 0, Convert.ToInt32(row("MA_DanhMuc"))),
                        .TenDanhMuc = row("DM_Ten").ToString().Trim(),
                        .DonGia = Convert.ToDecimal(row("MA_DonGia")),
                        .HetMon = Convert.ToBoolean(row("MA_HetMon")),
                        .MoTa = row("MA_MoTa").ToString().Trim(),
                        .Xoa = Convert.ToBoolean(row("MA_Xoa"))
                    })
                Next
            Catch ex As Exception
            End Try
            Return danhSach
        End Function

        ''' <summary>
        ''' Thêm mới một bảng Menu kinh doanh.
        ''' </summary>
        Public Shared Function Them(dto As MenuDTO) As Integer
            Try
                Dim sql As String = "
                    INSERT INTO Menu (MN_Ten, MN_LoaiMenu, MN_MoTa, MN_TrangThai, MN_Xoa)
                    VALUES (@Ten, @Loai, @MoTa, @TrangThai, 0);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"

                Dim params As SqlParameter() = {
                    New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenMenu.Trim()},
                    New SqlParameter("@Loai", SqlDbType.NVarChar, 50) With {.Value = dto.LoaiMenu.Trim()},
                    New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrEmpty(dto.MoTa), DBNull.Value, CObj(dto.MoTa.Trim()))},
                    New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()}
                }

                Dim result As Object = KetNoiCSDL.ExecuteScalar(sql, params)
                If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                    Return Convert.ToInt32(result)
                End If
            Catch ex As Exception
            End Try
            Return 0
        End Function

        ''' <summary>
        ''' Cập nhật thông tin bảng Menu kinh doanh.
        ''' </summary>
        Public Shared Function CapNhat(dto As MenuDTO) As Boolean
            Try
                Dim sql As String = "
                    UPDATE Menu
                    SET MN_Ten = @Ten,
                        MN_LoaiMenu = @Loai,
                        MN_MoTa = @MoTa,
                        MN_TrangThai = @TrangThai
                    WHERE MN_Ma = @MaMenu AND MN_Xoa = 0;"

                Dim params As SqlParameter() = {
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = dto.MaMenu},
                    New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = dto.TenMenu.Trim()},
                    New SqlParameter("@Loai", SqlDbType.NVarChar, 50) With {.Value = dto.LoaiMenu.Trim()},
                    New SqlParameter("@MoTa", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrEmpty(dto.MoTa), DBNull.Value, CObj(dto.MoTa.Trim()))},
                    New SqlParameter("@TrangThai", SqlDbType.NVarChar, 30) With {.Value = dto.TrangThai.Trim()}
                }

                Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Xóa mềm bảng Menu và các dòng gán món liên quan.
        ''' </summary>
        Public Shared Function Xoa(maMenu As Integer) As Boolean
            Try
                Dim sql As String = "
                    UPDATE Menu SET MN_Xoa = 1 WHERE MN_Ma = @MaMenu;
                    UPDATE Menu_MonAn SET MMA_Xoa = 1 WHERE MMA_MaMenu = @MaMenu;"

                Dim params As SqlParameter() = {
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu}
                }

                Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Gán một món ăn vào Menu với đơn giá và thứ tự tùy chỉnh.
        ''' Nếu món đã từng gán nhưng bị xóa mềm, hàm sẽ khôi phục lại và cập nhật giá mới.
        ''' </summary>
        Public Shared Function GanMonVaoMenu(maMenu As Integer,
                                             maMonAn As Integer,
                                             donGia As Decimal,
                                             thuTuHienThi As Integer,
                                             ghiChu As String) As Boolean
            Try
                ' Kiểm tra xem đã từng tồn tại trong Menu_MonAn chưa
                Dim sqlCheck As String = "SELECT COUNT(*) FROM Menu_MonAn WHERE MMA_MaMenu = @MaMenu AND MMA_MaMonAn = @MaMonAn;"
                Dim paramsCheck As SqlParameter() = {
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu},
                    New SqlParameter("@MaMonAn", SqlDbType.Int) With {.Value = maMonAn}
                }

                Dim countObj As Object = KetNoiCSDL.ExecuteScalar(sqlCheck, paramsCheck)
                Dim exists As Boolean = (countObj IsNot Nothing AndAlso Convert.ToInt32(countObj) > 0)

                If exists Then
                    Dim sqlUpdate As String = "
                        UPDATE Menu_MonAn
                        SET MMA_DonGia = @DonGia,
                            MMA_ThuTuHienThi = @ThuTu,
                            MMA_GhiChu = @GhiChu,
                            MMA_Xoa = 0
                        WHERE MMA_MaMenu = @MaMenu AND MMA_MaMonAn = @MaMonAn;"

                    Dim prms As SqlParameter() = {
                        New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu},
                        New SqlParameter("@MaMonAn", SqlDbType.Int) With {.Value = maMonAn},
                        New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Value = donGia},
                        New SqlParameter("@ThuTu", SqlDbType.Int) With {.Value = thuTuHienThi},
                        New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrEmpty(ghiChu), DBNull.Value, CObj(ghiChu.Trim()))}
                    }
                    Return KetNoiCSDL.ExecuteNonQuery(sqlUpdate, prms) > 0
                Else
                    Dim sqlInsert As String = "
                        INSERT INTO Menu_MonAn (MMA_MaMenu, MMA_MaMonAn, MMA_DonGia, MMA_ThuTuHienThi, MMA_GhiChu, MMA_Xoa)
                        VALUES (@MaMenu, @MaMonAn, @DonGia, @ThuTu, @GhiChu, 0);"

                    Dim prms As SqlParameter() = {
                        New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenu},
                        New SqlParameter("@MaMonAn", SqlDbType.Int) With {.Value = maMonAn},
                        New SqlParameter("@DonGia", SqlDbType.Decimal) With {.Value = donGia},
                        New SqlParameter("@ThuTu", SqlDbType.Int) With {.Value = thuTuHienThi},
                        New SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) With {.Value = If(String.IsNullOrEmpty(ghiChu), DBNull.Value, CObj(ghiChu.Trim()))}
                    }
                    Return KetNoiCSDL.ExecuteNonQuery(sqlInsert, prms) > 0
                End If
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Gỡ món khỏi bảng thực đơn (xóa mềm MMA_Xoa = 1).
        ''' </summary>
        Public Shared Function GoMonKhoiMenu(maMMA As Integer) As Boolean
            Try
                Dim sql As String = "UPDATE Menu_MonAn SET MMA_Xoa = 1 WHERE MMA_Ma = @MaMMA;"
                Dim params As SqlParameter() = {
                    New SqlParameter("@MaMMA", SqlDbType.Int) With {.Value = maMMA}
                }
                Return KetNoiCSDL.ExecuteNonQuery(sql, params) > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Kiểm tra trùng tên Menu đang hoạt động.
        ''' </summary>
        Public Shared Function KiemTraTrungTen(tenMenu As String, Optional maMenuBoQua As Integer = 0) As Boolean
            If String.IsNullOrWhiteSpace(tenMenu) Then Return False
            Try
                Dim sql As String = "
                    SELECT COUNT(*) 
                    FROM Menu 
                    WHERE MN_Xoa = 0 
                      AND MN_Ten = @Ten 
                      AND (@MaMenu = 0 OR MN_Ma <> @MaMenu);"

                Dim params As SqlParameter() = {
                    New SqlParameter("@Ten", SqlDbType.NVarChar, 100) With {.Value = tenMenu.Trim()},
                    New SqlParameter("@MaMenu", SqlDbType.Int) With {.Value = maMenuBoQua}
                }

                Dim countObj As Object = KetNoiCSDL.ExecuteScalar(sql, params)
                Return (countObj IsNot Nothing AndAlso Convert.ToInt32(countObj) > 0)
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Lấy các chỉ số thống kê phục vụ 4 thẻ KPI Header.
        ''' </summary>
        Public Shared Function LayThongKeKPI() As (TongMenu As Integer, DangApDung As Integer, TamNgung As Integer, TongMonGan As Integer)
            Dim tongMenu As Integer = 0
            Dim dangApDung As Integer = 0
            Dim tamNgung As Integer = 0
            Dim tongMonGan As Integer = 0

            Try
                Dim sql1 As String = "
                    SELECT 
                        COUNT(*) AS TongMenu,
                        SUM(CASE WHEN MN_TrangThai = N'Đang áp dụng' THEN 1 ELSE 0 END) AS DangApDung,
                        SUM(CASE WHEN MN_TrangThai <> N'Đang áp dụng' THEN 1 ELSE 0 END) AS TamNgung
                    FROM Menu
                    WHERE MN_Xoa = 0;"

                Dim dt1 As DataTable = KetNoiCSDL.ExecuteQuery(sql1)
                If dt1.Rows.Count > 0 Then
                    Dim r As DataRow = dt1.Rows(0)
                    tongMenu = If(IsDBNull(r("TongMenu")), 0, Convert.ToInt32(r("TongMenu")))
                    dangApDung = If(IsDBNull(r("DangApDung")), 0, Convert.ToInt32(r("DangApDung")))
                    tamNgung = If(IsDBNull(r("TamNgung")), 0, Convert.ToInt32(r("TamNgung")))
                End If

                Dim sql2 As String = "SELECT COUNT(*) FROM Menu_MonAn WHERE MMA_Xoa = 0;"
                Dim c2 As Object = KetNoiCSDL.ExecuteScalar(sql2)
                If c2 IsNot Nothing AndAlso Not IsDBNull(c2) Then
                    tongMonGan = Convert.ToInt32(c2)
                End If
            Catch ex As Exception
            End Try

            Return (tongMenu, dangApDung, tamNgung, tongMonGan)
        End Function

    End Class

End Namespace
