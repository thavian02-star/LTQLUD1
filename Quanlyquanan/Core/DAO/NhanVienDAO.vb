Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Quanlyquanan.Core.Database
Imports Quanlyquanan.Core.DTO

Namespace Core.DAO

    ''' <summary>
    ''' Tầng Truy cập Dữ liệu (DAO) cho bảng NhanVien, NhanVien_ViTinh, TrinhDoViTinh và DungCuTrangPhuc.
    ''' Đảm bảo xử lý giao dịch an toàn (Transaction), Parameterized SQL chống SQL Injection.
    ''' </summary>
    Public Class NhanVienDAO

        ''' <summary>
        ''' Lấy danh sách nhân viên đang hoạt động (NV_Xoa = 0), hỗ trợ tìm kiếm từ khóa, lọc theo vị trí và trạng thái.
        ''' </summary>
        Public Shared Function LayDanhSach(Optional tuKhoa As String = "",
                                           Optional viTri As String = "",
                                           Optional trangThai As String = "") As List(Of NhanVienDTO)
            Dim ds As New List(Of NhanVienDTO)()
            Dim keyword As String = If(tuKhoa, String.Empty).Trim()
            Dim pos As String = If(viTri, String.Empty).Trim()
            Dim status As String = If(trangThai, String.Empty).Trim()

            Dim sql As String = "
                SELECT 
                    nv.NV_Ma,
                    nv.NV_HoTen,
                    nv.NV_GioiTinh,
                    nv.NV_NgaySinh,
                    nv.NV_ViTri,
                    nv.NV_CMND,
                    nv.NV_DienThoai,
                    nv.NV_Email,
                    nv.NV_DiaChi,
                    nv.NV_TrinhDoHocVan,
                    nv.NV_NgoaiNgu,
                    nv.NV_NgayBatDauLam,
                    nv.NV_NgayThoiViec,
                    nv.NV_MaTaiKhoan,
                    nv.NV_TrangThai,
                    nv.NV_Xoa,
                    tk.TK_TenDangNhap,
                    ISNULL(dcSummary.SoChuaTra, 0) AS SoDungCuChuaTra
                FROM NhanVien nv
                LEFT JOIN TaiKhoan tk ON tk.TK_Ma = nv.NV_MaTaiKhoan AND tk.TK_Xoa = 0
                LEFT JOIN (
                    SELECT NV_Ma, COUNT(*) AS SoChuaTra
                    FROM NhanVien_DungCu
                    WHERE DaTra = 0
                    GROUP BY NV_Ma
                ) dcSummary ON dcSummary.NV_Ma = nv.NV_Ma
                WHERE nv.NV_Xoa = 0
                  AND (@ViTri = N'' OR nv.NV_ViTri = @ViTri)
                  AND (@TrangThai = N'' OR nv.NV_TrangThai = @TrangThai)
                  AND (@TuKhoa = N'' OR nv.NV_HoTen LIKE N'%' + @TuKhoa + N'%'
                                    OR nv.NV_CMND LIKE N'%' + @TuKhoa + N'%'
                                    OR nv.NV_DienThoai LIKE N'%' + @TuKhoa + N'%'
                                    OR nv.NV_Email LIKE N'%' + @TuKhoa + N'%'
                                    OR tk.TK_TenDangNhap LIKE N'%' + @TuKhoa + N'%')
                ORDER BY nv.NV_Ma ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@ViTri", SqlDbType.NVarChar, 50) With {.Value = pos},
                New SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) With {.Value = status},
                New SqlParameter("@TuKhoa", SqlDbType.NVarChar, 100) With {.Value = keyword}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)

            ' Lấy toàn bộ kỹ năng vi tính của nhân viên để map
            Dim dictViTinh As Dictionary(Of Integer, List(Of Integer)) = LayTatCaNhanVienViTinh()
            Dim dictTenViTinh As Dictionary(Of Integer, String) = LayTuDienTrinhDoViTinh()

            For Each row As DataRow In dt.Rows
                Dim dto As New NhanVienDTO() With {
                    .MaNV = Convert.ToInt32(row("NV_Ma")),
                    .HoTen = Convert.ToString(row("NV_HoTen")).Trim(),
                    .GioiTinh = If(IsDBNull(row("NV_GioiTinh")), True, Convert.ToBoolean(row("NV_GioiTinh"))),
                    .NgaySinh = If(IsDBNull(row("NV_NgaySinh")), CType(Nothing, DateTime?), Convert.ToDateTime(row("NV_NgaySinh"))),
                    .ViTri = If(IsDBNull(row("NV_ViTri")), "Phục vụ", Convert.ToString(row("NV_ViTri")).Trim()),
                    .CMND = If(IsDBNull(row("NV_CMND")), String.Empty, Convert.ToString(row("NV_CMND")).Trim()),
                    .DienThoai = If(IsDBNull(row("NV_DienThoai")), String.Empty, Convert.ToString(row("NV_DienThoai")).Trim()),
                    .Email = If(IsDBNull(row("NV_Email")), String.Empty, Convert.ToString(row("NV_Email")).Trim()),
                    .DiaChi = If(IsDBNull(row("NV_DiaChi")), String.Empty, Convert.ToString(row("NV_DiaChi")).Trim()),
                    .TrinhDoHocVan = If(IsDBNull(row("NV_TrinhDoHocVan")), String.Empty, Convert.ToString(row("NV_TrinhDoHocVan")).Trim()),
                    .NgoaiNgu = If(IsDBNull(row("NV_NgoaiNgu")), String.Empty, Convert.ToString(row("NV_NgoaiNgu")).Trim()),
                    .NgayBatDauLam = If(IsDBNull(row("NV_NgayBatDauLam")), DateTime.Today, Convert.ToDateTime(row("NV_NgayBatDauLam"))),
                    .NgayThoiViec = If(IsDBNull(row("NV_NgayThoiViec")), CType(Nothing, DateTime?), Convert.ToDateTime(row("NV_NgayThoiViec"))),
                    .MaTaiKhoan = If(IsDBNull(row("NV_MaTaiKhoan")), CType(Nothing, Integer?), Convert.ToInt32(row("NV_MaTaiKhoan"))),
                    .TenTaiKhoanHienThi = If(IsDBNull(row("TK_TenDangNhap")), "Chưa gán", Convert.ToString(row("TK_TenDangNhap")).Trim()),
                    .TrangThai = If(IsDBNull(row("NV_TrangThai")), "Đang làm việc", Convert.ToString(row("NV_TrangThai")).Trim()),
                    .Xoa = If(IsDBNull(row("NV_Xoa")), False, Convert.ToBoolean(row("NV_Xoa"))),
                    .SoDungCuDangGiu = Convert.ToInt32(row("SoDungCuChuaTra"))
                }

                ' Map kỹ năng vi tính
                If dictViTinh.ContainsKey(dto.MaNV) Then
                    dto.DanhSachViTinh = dictViTinh(dto.MaNV)
                    Dim listTen As New List(Of String)()
                    For Each vtMa In dto.DanhSachViTinh
                        If dictTenViTinh.ContainsKey(vtMa) Then
                            listTen.Add(dictTenViTinh(vtMa))
                        End If
                    Next
                    dto.KyNangViTinhHienThi = String.Join(", ", listTen)
                Else
                    dto.DanhSachViTinh = New List(Of Integer)()
                    dto.KyNangViTinhHienThi = "Không"
                End If

                ' Chuỗi hiển thị dụng cụ trang phục
                If dto.SoDungCuDangGiu > 0 Then
                    dto.ThongTinTrangPhucHienThi = $"Đang giữ {dto.SoDungCuDangGiu} món"
                Else
                    dto.ThongTinTrangPhucHienThi = "Đã hoàn tất"
                End If

                ds.Add(dto)
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Lấy thông tin chi tiết một nhân viên theo mã.
        ''' </summary>
        Public Shared Function LayTheoMa(maNV As Integer) As NhanVienDTO
            Dim ds = LayDanhSach(tuKhoa:="", viTri:="", trangThai:="")
            Return ds.FirstOrDefault(Function(n) n.MaNV = maNV)
        End Function

        ''' <summary>
        ''' Lấy danh mục 4 kỹ năng vi tính chuẩn trong cơ sở dữ liệu.
        ''' </summary>
        Public Shared Function LayDanhSachTrinhDoViTinh() As List(Of TrinhDoViTinhDTO)
            Dim ds As New List(Of TrinhDoViTinhDTO)()
            Dim sql As String = "SELECT TDVT_Ma, TDVT_Ten, TDVT_Xoa FROM TrinhDoViTinh WHERE TDVT_Xoa = 0 ORDER BY TDVT_Ma ASC;"
            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)

            For Each row As DataRow In dt.Rows
                ds.Add(New TrinhDoViTinhDTO() With {
                    .MaTDVT = Convert.ToInt32(row("TDVT_Ma")),
                    .TenTDVT = Convert.ToString(row("TDVT_Ten")).Trim(),
                    .Xoa = Convert.ToBoolean(row("TDVT_Xoa"))
                })
            Next

            Return ds
        End Function

        Private Shared Function LayTuDienTrinhDoViTinh() As Dictionary(Of Integer, String)
            Dim dict As New Dictionary(Of Integer, String)()
            Dim list = LayDanhSachTrinhDoViTinh()
            For Each item In list
                dict(item.MaTDVT) = item.TenTDVT
            Next
            Return dict
        End Function

        ''' <summary>
        ''' Lấy toàn bộ quan hệ NhanVien_ViTinh đưa vào Dictionary để tối ưu tốc độ map.
        ''' </summary>
        Private Shared Function LayTatCaNhanVienViTinh() As Dictionary(Of Integer, List(Of Integer))
            Dim dict As New Dictionary(Of Integer, List(Of Integer))()
            Dim sql As String = "SELECT NV_Ma, TDVT_Ma FROM NhanVien_ViTinh ORDER BY NV_Ma, TDVT_Ma;"
            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)

            For Each row As DataRow In dt.Rows
                Dim nvMa As Integer = Convert.ToInt32(row("NV_Ma"))
                Dim tdvtMa As Integer = Convert.ToInt32(row("TDVT_Ma"))
                If Not dict.ContainsKey(nvMa) Then
                    dict(nvMa) = New List(Of Integer)()
                End If
                dict(nvMa).Add(tdvtMa)
            Next

            Return dict
        End Function

        ''' <summary>
        ''' Lấy danh sách tài khoản khả dụng để gán cho nhân viên:
        ''' Gồm các tài khoản chưa ai dùng HOẶC tài khoản đang thuộc về nhân viên hiện tại.
        ''' </summary>
        Public Shared Function LayDanhSachTaiKhoanKhaDung(Optional maNVDangChon As Integer = 0) As List(Of TaiKhoanItemDTO)
            Dim ds As New List(Of TaiKhoanItemDTO)()

            ' Thêm lựa chọn không gán tài khoản
            ds.Add(New TaiKhoanItemDTO() With {.MaTK = 0, .TenDangNhap = "-- Không gán tài khoản --"})

            Dim sql As String = "
                SELECT tk.TK_Ma, tk.TK_TenDangNhap
                FROM TaiKhoan tk
                WHERE tk.TK_Xoa = 0
                  AND (
                      tk.TK_Ma NOT IN (
                          SELECT ISNULL(NV_MaTaiKhoan, 0)
                          FROM NhanVien
                          WHERE NV_Xoa = 0 AND NV_MaTaiKhoan IS NOT NULL AND (@MaNV = 0 OR NV_Ma <> @MaNV)
                      )
                      OR tk.TK_Ma IN (
                          SELECT ISNULL(NV_MaTaiKhoan, 0)
                          FROM NhanVien
                          WHERE NV_Ma = @MaNV
                      )
                  )
                ORDER BY tk.TK_TenDangNhap ASC;"

            Dim prms As SqlParameter() = {
                New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNVDangChon}
            }

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql, prms)
            For Each row As DataRow In dt.Rows
                ds.Add(New TaiKhoanItemDTO() With {
                    .MaTK = Convert.ToInt32(row("TK_Ma")),
                    .TenDangNhap = Convert.ToString(row("TK_TenDangNhap")).Trim()
                })
            Next

            Return ds
        End Function

        ''' <summary>
        ''' Kiểm tra CCCD / CMND có bị trùng với nhân viên khác đang hoạt động không.
        ''' </summary>
        Public Shared Function KiemTraTrungCMND(cmnd As String, Optional maNVHienTai As Integer = 0) As Boolean
            If String.IsNullOrWhiteSpace(cmnd) Then Return False
            Try
                Dim sql As String = "
                    SELECT COUNT(*) 
                    FROM NhanVien 
                    WHERE NV_Xoa = 0 
                      AND NV_CMND = @CMND 
                      AND (@MaNV = 0 OR NV_Ma <> @MaNV);"

                Dim prms As SqlParameter() = {
                    New SqlParameter("@CMND", SqlDbType.NVarChar, 20) With {.Value = cmnd.Trim()},
                    New SqlParameter("@MaNV", SqlDbType.Int) With {.Value = maNVHienTai}
                }

                Dim count As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
                Return (count IsNot Nothing AndAlso Convert.ToInt32(count) > 0)
            Catch ex As Exception
                ' Tránh văng ngoại lệ khi mất kết nối CSDL
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Thêm mới một nhân viên cùng các kỹ năng vi tính liên quan (sử dụng SqlTransaction).
        ''' </summary>
        Public Shared Function Them(dto As NhanVienDTO) As Integer
            Using conn As SqlConnection = KetNoiCSDL.GetConnection()
                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sqlNV As String = "
                            INSERT INTO NhanVien (
                                NV_HoTen, NV_GioiTinh, NV_NgaySinh, NV_ViTri,
                                NV_CMND, NV_DienThoai, NV_Email, NV_DiaChi,
                                NV_TrinhDoHocVan, NV_NgoaiNgu, NV_NgayBatDauLam,
                                NV_NgayThoiViec, NV_MaTaiKhoan, NV_TrangThai, NV_Xoa
                            ) VALUES (
                                @HoTen, @GioiTinh, @NgaySinh, @ViTri,
                                @CMND, @DienThoai, @Email, @DiaChi,
                                @TrinhDoHocVan, @NgoaiNgu, @NgayBatDauLam,
                                @NgayThoiViec, @MaTaiKhoan, @TrangThai, 0
                            );
                            SELECT CAST(SCOPE_IDENTITY() AS INT);"

                        Using cmdNV As New SqlCommand(sqlNV, conn, trans)
                            cmdNV.Parameters.AddWithValue("@HoTen", dto.HoTen.Trim())
                            cmdNV.Parameters.AddWithValue("@GioiTinh", dto.GioiTinh)
                            cmdNV.Parameters.AddWithValue("@NgaySinh", If(dto.NgaySinh.HasValue, CObj(dto.NgaySinh.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@ViTri", dto.ViTri.Trim())
                            cmdNV.Parameters.AddWithValue("@CMND", If(String.IsNullOrWhiteSpace(dto.CMND), DBNull.Value, CObj(dto.CMND.Trim())))
                            cmdNV.Parameters.AddWithValue("@DienThoai", If(String.IsNullOrWhiteSpace(dto.DienThoai), DBNull.Value, CObj(dto.DienThoai.Trim())))
                            cmdNV.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(dto.Email), DBNull.Value, CObj(dto.Email.Trim())))
                            cmdNV.Parameters.AddWithValue("@DiaChi", If(String.IsNullOrWhiteSpace(dto.DiaChi), DBNull.Value, CObj(dto.DiaChi.Trim())))
                            cmdNV.Parameters.AddWithValue("@TrinhDoHocVan", If(String.IsNullOrWhiteSpace(dto.TrinhDoHocVan), DBNull.Value, CObj(dto.TrinhDoHocVan.Trim())))
                            cmdNV.Parameters.AddWithValue("@NgoaiNgu", If(String.IsNullOrWhiteSpace(dto.NgoaiNgu), DBNull.Value, CObj(dto.NgoaiNgu.Trim())))
                            cmdNV.Parameters.AddWithValue("@NgayBatDauLam", dto.NgayBatDauLam)
                            cmdNV.Parameters.AddWithValue("@NgayThoiViec", If(dto.NgayThoiViec.HasValue, CObj(dto.NgayThoiViec.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@MaTaiKhoan", If(dto.MaTaiKhoan.HasValue AndAlso dto.MaTaiKhoan.Value > 0, CObj(dto.MaTaiKhoan.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@TrangThai", dto.TrangThai.Trim())

                            Dim newId As Integer = Convert.ToInt32(cmdNV.ExecuteScalar())
                            dto.MaNV = newId

                            ' Thêm các kỹ năng vi tính đã chọn
                            If dto.DanhSachViTinh IsNot Nothing AndAlso dto.DanhSachViTinh.Count > 0 Then
                                For Each tdvtMa In dto.DanhSachViTinh
                                    Dim sqlVT As String = "INSERT INTO NhanVien_ViTinh (NV_Ma, TDVT_Ma) VALUES (@NV_Ma, @TDVT_Ma);"
                                    Using cmdVT As New SqlCommand(sqlVT, conn, trans)
                                        cmdVT.Parameters.AddWithValue("@NV_Ma", newId)
                                        cmdVT.Parameters.AddWithValue("@TDVT_Ma", tdvtMa)
                                        cmdVT.ExecuteNonQuery()
                                    End Using
                                Next
                            End If

                            trans.Commit()
                            Return newId
                        End Using
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Cập nhật thông tin hồ sơ nhân viên và đồng bộ kỹ năng vi tính.
        ''' </summary>
        Public Shared Function CapNhat(dto As NhanVienDTO) As Boolean
            Using conn As SqlConnection = KetNoiCSDL.GetConnection()
                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sqlNV As String = "
                            UPDATE NhanVien SET
                                NV_HoTen = @HoTen,
                                NV_GioiTinh = @GioiTinh,
                                NV_NgaySinh = @NgaySinh,
                                NV_ViTri = @ViTri,
                                NV_CMND = @CMND,
                                NV_DienThoai = @DienThoai,
                                NV_Email = @Email,
                                NV_DiaChi = @DiaChi,
                                NV_TrinhDoHocVan = @TrinhDoHocVan,
                                NV_NgoaiNgu = @NgoaiNgu,
                                NV_NgayBatDauLam = @NgayBatDauLam,
                                NV_NgayThoiViec = @NgayThoiViec,
                                NV_MaTaiKhoan = @MaTaiKhoan,
                                NV_TrangThai = @TrangThai
                            WHERE NV_Ma = @NV_Ma AND NV_Xoa = 0;"

                        Using cmdNV As New SqlCommand(sqlNV, conn, trans)
                            cmdNV.Parameters.AddWithValue("@NV_Ma", dto.MaNV)
                            cmdNV.Parameters.AddWithValue("@HoTen", dto.HoTen.Trim())
                            cmdNV.Parameters.AddWithValue("@GioiTinh", dto.GioiTinh)
                            cmdNV.Parameters.AddWithValue("@NgaySinh", If(dto.NgaySinh.HasValue, CObj(dto.NgaySinh.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@ViTri", dto.ViTri.Trim())
                            cmdNV.Parameters.AddWithValue("@CMND", If(String.IsNullOrWhiteSpace(dto.CMND), DBNull.Value, CObj(dto.CMND.Trim())))
                            cmdNV.Parameters.AddWithValue("@DienThoai", If(String.IsNullOrWhiteSpace(dto.DienThoai), DBNull.Value, CObj(dto.DienThoai.Trim())))
                            cmdNV.Parameters.AddWithValue("@Email", If(String.IsNullOrWhiteSpace(dto.Email), DBNull.Value, CObj(dto.Email.Trim())))
                            cmdNV.Parameters.AddWithValue("@DiaChi", If(String.IsNullOrWhiteSpace(dto.DiaChi), DBNull.Value, CObj(dto.DiaChi.Trim())))
                            cmdNV.Parameters.AddWithValue("@TrinhDoHocVan", If(String.IsNullOrWhiteSpace(dto.TrinhDoHocVan), DBNull.Value, CObj(dto.TrinhDoHocVan.Trim())))
                            cmdNV.Parameters.AddWithValue("@NgoaiNgu", If(String.IsNullOrWhiteSpace(dto.NgoaiNgu), DBNull.Value, CObj(dto.NgoaiNgu.Trim())))
                            cmdNV.Parameters.AddWithValue("@NgayBatDauLam", dto.NgayBatDauLam)
                            cmdNV.Parameters.AddWithValue("@NgayThoiViec", If(dto.NgayThoiViec.HasValue, CObj(dto.NgayThoiViec.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@MaTaiKhoan", If(dto.MaTaiKhoan.HasValue AndAlso dto.MaTaiKhoan.Value > 0, CObj(dto.MaTaiKhoan.Value), DBNull.Value))
                            cmdNV.Parameters.AddWithValue("@TrangThai", dto.TrangThai.Trim())

                            Dim rowsAffected As Integer = cmdNV.ExecuteNonQuery()
                            If rowsAffected <= 0 Then
                                trans.Rollback()
                                Return False
                            End If
                        End Using

                        ' Đồng bộ kỹ năng vi tính: Xóa cũ, thêm mới
                        Dim sqlDelVT As String = "DELETE FROM NhanVien_ViTinh WHERE NV_Ma = @NV_Ma;"
                        Using cmdDel As New SqlCommand(sqlDelVT, conn, trans)
                            cmdDel.Parameters.AddWithValue("@NV_Ma", dto.MaNV)
                            cmdDel.ExecuteNonQuery()
                        End Using

                        If dto.DanhSachViTinh IsNot Nothing AndAlso dto.DanhSachViTinh.Count > 0 Then
                            For Each tdvtMa In dto.DanhSachViTinh
                                Dim sqlInsVT As String = "INSERT INTO NhanVien_ViTinh (NV_Ma, TDVT_Ma) VALUES (@NV_Ma, @TDVT_Ma);"
                                Using cmdIns As New SqlCommand(sqlInsVT, conn, trans)
                                    cmdIns.Parameters.AddWithValue("@NV_Ma", dto.MaNV)
                                    cmdIns.Parameters.AddWithValue("@TDVT_Ma", tdvtMa)
                                    cmdIns.ExecuteNonQuery()
                                End Using
                            Next
                        End If

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Xóa mềm nhân viên (NV_Xoa = 1). Không xóa vật lý để bảo toàn lịch sử hóa đơn và chấm công.
        ''' </summary>
        Public Shared Function XoaMem(maNV As Integer) As Boolean
            Dim sql As String = "UPDATE NhanVien SET NV_Xoa = 1 WHERE NV_Ma = @NV_Ma;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@NV_Ma", SqlDbType.Int) With {.Value = maNV}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Đếm số lượng trang phục/dụng cụ nhân viên đang giữ chưa hoàn trả.
        ''' </summary>
        Public Shared Function KiemTraTrangPhucChuaTra(maNV As Integer) As Integer
            Dim sql As String = "SELECT COUNT(*) FROM NhanVien_DungCu WHERE NV_Ma = @NV_Ma AND DaTra = 0;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@NV_Ma", SqlDbType.Int) With {.Value = maNV}
            }
            Dim count As Object = KetNoiCSDL.ExecuteScalar(sql, prms)
            Return If(count IsNot Nothing, Convert.ToInt32(count), 0)
        End Function

        ''' <summary>
        ''' Cập nhật trạng thái thôi việc cho nhân viên, hỗ trợ tự động thu hồi đồng phục.
        ''' </summary>
        Public Shared Function CapNhatNghiViec(maNV As Integer, ngayThoiViec As DateTime, tuDongThuHoiTrangPhuc As Boolean) As Boolean
            Using conn As SqlConnection = KetNoiCSDL.GetConnection()
                Using trans As SqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sqlNV As String = "
                            UPDATE NhanVien 
                            SET NV_TrangThai = N'Đã nghỉ việc', NV_NgayThoiViec = @NgayThoiViec
                            WHERE NV_Ma = @NV_Ma;"

                        Using cmdNV As New SqlCommand(sqlNV, conn, trans)
                            cmdNV.Parameters.AddWithValue("@NV_Ma", maNV)
                            cmdNV.Parameters.AddWithValue("@NgayThoiViec", ngayThoiViec)
                            cmdNV.ExecuteNonQuery()
                        End Using

                        If tuDongThuHoiTrangPhuc Then
                            Dim sqlDC As String = "
                                UPDATE NhanVien_DungCu 
                                SET DaTra = 1, NgayTra = @NgayTra, GhiChu = ISNULL(GhiChu, N'') + N' (Tự động thu hồi khi thôi việc)'
                                WHERE NV_Ma = @NV_Ma AND DaTra = 0;"
                            Using cmdDC As New SqlCommand(sqlDC, conn, trans)
                                cmdDC.Parameters.AddWithValue("@NV_Ma", maNV)
                                cmdDC.Parameters.AddWithValue("@NgayTra", ngayThoiViec)
                                cmdDC.ExecuteNonQuery()
                            End Using
                        End If

                        trans.Commit()
                        Return True
                    Catch ex As Exception
                        trans.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Khôi phục trạng thái làm việc cho nhân viên (đổi từ 'Đã nghỉ việc' sang 'Đang làm việc').
        ''' </summary>
        Public Shared Function KhoiPhucLamViec(maNV As Integer) As Boolean
            Dim sql As String = "UPDATE NhanVien SET NV_TrangThai = N'Đang làm việc', NV_NgayThoiViec = NULL WHERE NV_Ma = @NV_Ma;"
            Dim prms As SqlParameter() = {
                New SqlParameter("@NV_Ma", SqlDbType.Int) With {.Value = maNV}
            }
            Return KetNoiCSDL.ExecuteNonQuery(sql, prms) > 0
        End Function

        ''' <summary>
        ''' Lấy các số liệu thống kê nhanh cho 4 thẻ KPI trên Header của giao diện.
        ''' </summary>
        Public Shared Function LayThongKeKPI() As (TongNV As Integer, DangLam As Integer, DaNghi As Integer, CoTaiKhoan As Integer)
            Dim sql As String = "
                SELECT 
                    COUNT(*) AS TongNV,
                    SUM(CASE WHEN NV_TrangThai = N'Đang làm việc' THEN 1 ELSE 0 END) AS DangLam,
                    SUM(CASE WHEN NV_TrangThai = N'Đã nghỉ việc' THEN 1 ELSE 0 END) AS DaNghi,
                    SUM(CASE WHEN NV_MaTaiKhoan IS NOT NULL AND NV_MaTaiKhoan > 0 THEN 1 ELSE 0 END) AS CoTaiKhoan
                FROM NhanVien
                WHERE NV_Xoa = 0;"

            Dim dt As DataTable = KetNoiCSDL.ExecuteQuery(sql)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Return (
                    TongNV:=If(IsDBNull(r("TongNV")), 0, Convert.ToInt32(r("TongNV"))),
                    DangLam:=If(IsDBNull(r("DangLam")), 0, Convert.ToInt32(r("DangLam"))),
                    DaNghi:=If(IsDBNull(r("DaNghi")), 0, Convert.ToInt32(r("DaNghi"))),
                    CoTaiKhoan:=If(IsDBNull(r("CoTaiKhoan")), 0, Convert.ToInt32(r("CoTaiKhoan")))
                )
            End If

            Return (TongNV:=0, DangLam:=0, DaNghi:=0, CoTaiKhoan:=0)
        End Function

    End Class

End Namespace
