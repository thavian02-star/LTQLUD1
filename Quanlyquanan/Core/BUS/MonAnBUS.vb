Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS
    ''' <summary>
    ''' Đối tượng trả về kết quả xử lý nghiệp vụ Món ăn &amp; Thức uống.
    ''' </summary>
    Public Class KetQuaMonAn
        Public Property ThanhCong As Boolean
        Public Property ThongBao As String = String.Empty
        Public Property MaMonAn As Integer = 0
    End Class

    ''' <summary>
    ''' Lớp nghiệp vụ (BUS) kiểm tra ràng buộc dữ liệu và điều phối thao tác trên bảng MonAn.
    ''' </summary>
    Public Class MonAnBUS
        Private ReadOnly _dao As New MonAnDAO()

        ''' <summary>
        ''' Lấy danh sách món ăn theo bộ lọc đa chiều (Từ khóa + Mã danh mục + Trạng thái Còn/Hết món).
        ''' </summary>
        Public Function LayDanhSachMonAn(Optional tuKhoa As String = "",
                                         Optional maDanhMuc As Integer = 0,
                                         Optional trangThaiHetMon As Integer = -1) As List(Of MonAnDTO)
            Return _dao.LayDanhSach(tuKhoa, maDanhMuc, trangThaiHetMon)
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và thêm mới món ăn vào thực đơn.
        ''' Nếu trùng tên với món đã xóa mềm trước đó thì tự động khôi phục lại.
        ''' </summary>
        Public Function ThemMonAn(tenMonAn As String,
                                  maDanhMuc As Integer,
                                  donGia As Decimal,
                                  hetMon As Boolean,
                                  moTa As String) As KetQuaMonAn
            Dim tenChuan As String = If(tenMonAn, String.Empty).Trim()
            Dim moTaChuan As String = If(moTa, String.Empty).Trim()

            If String.IsNullOrWhiteSpace(tenChuan) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng nhập Tên món ăn / thức uống!"
                }
            End If

            If tenChuan.Length > 100 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên món ăn không được vượt quá 100 ký tự!"
                }
            End If

            If maDanhMuc <= 0 OrElse Not _dao.KiemTraDanhMucHopLe(maDanhMuc) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn một Danh mục thực đơn hợp lệ!"
                }
            End If

            If donGia < 0D Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Đơn giá bán không được nhỏ hơn 0 đ!"
                }
            End If

            If moTaChuan.Length > 255 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Mô tả món ăn không được vượt quá 255 ký tự!"
                }
            End If

            If _dao.KiemTraTrungTen(tenChuan, 0) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = $"Món ăn ""{tenChuan}"" đã tồn tại trong thực đơn!"
                }
            End If

            Dim dto As New MonAnDTO() With {
                .TenMonAn = tenChuan,
                .MaDanhMuc = maDanhMuc,
                .DonGia = donGia,
                .HetMon = hetMon,
                .MoTa = moTaChuan
            }

            ' Nếu tên trùng với 1 món đã xóa mềm trước đó -> Khôi phục lại
            Dim maDaXoa As Integer = _dao.TimMaMonDaXoaTheoTen(tenChuan)
            If maDaXoa > 0 Then
                If _dao.KhoiPhucMonAn(maDaXoa, dto) Then
                    Return New KetQuaMonAn() With {
                        .ThanhCong = True,
                        .MaMonAn = maDaXoa,
                        .ThongBao = $"Đã thêm món ""#{maDaXoa} - {tenChuan}"" ({donGia:#,##0} đ) thành công!"
                    }
                End If
            End If

            Dim maMoi As Integer = _dao.ThemMonAn(dto)
            If maMoi > 0 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = True,
                    .MaMonAn = maMoi,
                    .ThongBao = $"Đã thêm món mới ""#{maMoi} - {tenChuan}"" ({donGia:#,##0} đ) thành công!"
                }
            End If

            Return New KetQuaMonAn() With {
                .ThanhCong = False,
                .ThongBao = "Không thể thêm món ăn vào cơ sở dữ liệu!"
            }
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và cập nhật thông tin món ăn.
        ''' </summary>
        Public Function CapNhatMonAn(maMonAn As Integer,
                                     tenMonAn As String,
                                     maDanhMuc As Integer,
                                     donGia As Decimal,
                                     hetMon As Boolean,
                                     moTa As String) As KetQuaMonAn
            If maMonAn <= 0 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn một món ăn trên bảng trước khi bấm Lưu cập nhật!"
                }
            End If

            Dim tenChuan As String = If(tenMonAn, String.Empty).Trim()
            Dim moTaChuan As String = If(moTa, String.Empty).Trim()

            If String.IsNullOrWhiteSpace(tenChuan) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên món ăn / thức uống không được để trống!"
                }
            End If

            If tenChuan.Length > 100 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên món ăn không được vượt quá 100 ký tự!"
                }
            End If

            If maDanhMuc <= 0 OrElse Not _dao.KiemTraDanhMucHopLe(maDanhMuc) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn một Danh mục thực đơn hợp lệ!"
                }
            End If

            If donGia < 0D Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Đơn giá bán không được nhỏ hơn 0 đ!"
                }
            End If

            If moTaChuan.Length > 255 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Mô tả món ăn không được vượt quá 255 ký tự!"
                }
            End If

            If _dao.KiemTraTrungTen(tenChuan, maMonAn) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = $"Tên món ""{tenChuan}"" bị trùng với một món khác trong thực đơn!"
                }
            End If

            Dim dto As New MonAnDTO() With {
                .MaMonAn = maMonAn,
                .TenMonAn = tenChuan,
                .MaDanhMuc = maDanhMuc,
                .DonGia = donGia,
                .HetMon = hetMon,
                .MoTa = moTaChuan
            }

            If _dao.CapNhatMonAn(dto) Then
                Dim trangThai As String = If(hetMon, "Tạm hết món", "Còn món")
                Return New KetQuaMonAn() With {
                    .ThanhCong = True,
                    .MaMonAn = maMonAn,
                    .ThongBao = $"Đã cập nhật món ""#{maMonAn} - {tenChuan}"" ({donGia:#,##0} đ — {trangThai}) thành công!"
                }
            End If

            Return New KetQuaMonAn() With {
                .ThanhCong = False,
                .ThongBao = "Không tìm thấy món ăn cần cập nhật!"
            }
        End Function

        ''' <summary>
        ''' Kiểm tra ràng buộc hóa đơn đang phục vụ (HD_TrangThai = 0) và thực hiện xóa mềm (MA_Xoa = 1).
        ''' </summary>
        Public Function XoaMonAn(maMonAn As Integer, Optional tenHienThi As String = "") As KetQuaMonAn
            If maMonAn <= 0 Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn món ăn cần xóa trên bảng!"
                }
            End If

            Dim soLuotDangPhucVu As Integer = _dao.DemSoLuotDangPhucVu(maMonAn)
            If soLuotDangPhucVu > 0 Then
                Dim ten As String = If(String.IsNullOrWhiteSpace(tenHienThi), $"#{maMonAn}", tenHienThi.Trim())
                Return New KetQuaMonAn() With {
                    .ThanhCong = False,
                    .ThongBao = $"Không thể xóa món ""{ten}"" vì đang có {soLuotDangPhucVu} lượt gọi tại các bàn đang phục vụ! Bạn có thể tích [Báo tạm hết món] để ngừng nhận thêm order."
                }
            End If

            If _dao.XoaMemMonAn(maMonAn) Then
                Return New KetQuaMonAn() With {
                    .ThanhCong = True,
                    .MaMonAn = maMonAn,
                    .ThongBao = $"Đã xóa món ""{tenHienThi}"" khỏi thực đơn thành công!"
                }
            End If

            Return New KetQuaMonAn() With {
                .ThanhCong = False,
                .ThongBao = "Không thể xóa món ăn đã chọn!"
            }
        End Function

    End Class
End Namespace
