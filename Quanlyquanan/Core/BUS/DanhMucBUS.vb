Imports Quanlyquanan.Core.DAO
Imports Quanlyquanan.Core.DTO

Namespace Core.BUS
    ''' <summary>
    ''' Đối tượng trả về kết quả xử lý nghiệp vụ Danh mục thực đơn.
    ''' </summary>
    Public Class KetQuaDanhMuc
        Public Property ThanhCong As Boolean
        Public Property ThongBao As String = String.Empty
        Public Property MaDanhMuc As Integer = 0
    End Class

    ''' <summary>
    ''' Lớp nghiệp vụ (BUS) kiểm tra ràng buộc dữ liệu và điều phối thao tác trên bảng DanhMuc.
    ''' </summary>
    Public Class DanhMucBUS
        Private ReadOnly _dao As New DanhMucDAO()

        ''' <summary>
        ''' Lấy danh sách danh mục thực đơn theo từ khóa tìm kiếm.
        ''' </summary>
        Public Function LayDanhSachDanhMuc(Optional tuKhoa As String = "") As List(Of DanhMucDTO)
            Return _dao.LayDanhSach(tuKhoa)
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và thêm mới danh mục thực đơn.
        ''' Nếu trùng tên với danh mục đã xóa mềm thì tự động khôi phục lại.
        ''' </summary>
        Public Function ThemDanhMuc(tenDanhMuc As String, moTa As String) As KetQuaDanhMuc
            Dim tenChuan As String = If(tenDanhMuc, String.Empty).Trim()
            Dim moTaChuan As String = If(moTa, String.Empty).Trim()

            If String.IsNullOrWhiteSpace(tenChuan) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng nhập Tên danh mục thực đơn!"
                }
            End If

            If tenChuan.Length > 100 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên danh mục không được vượt quá 100 ký tự!"
                }
            End If

            If moTaChuan.Length > 255 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Mô tả danh mục không được vượt quá 255 ký tự!"
                }
            End If

            If _dao.KiemTraTrungTen(tenChuan, 0) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = $"Danh mục ""{tenChuan}"" đã tồn tại trong hệ thống!"
                }
            End If

            ' Nếu tên trùng với 1 danh mục đã xóa mềm trước đó -> Khôi phục lại
            Dim maDaXoa As Integer = _dao.TimMaDanhMucDaXoaTheoTen(tenChuan)
            If maDaXoa > 0 Then
                Dim okRestore As Boolean = _dao.KhoiPhucDanhMuc(maDaXoa, tenChuan, moTaChuan)
                If okRestore Then
                    Return New KetQuaDanhMuc() With {
                        .ThanhCong = True,
                        .MaDanhMuc = maDaXoa,
                        .ThongBao = $"Đã thêm danh mục ""#{maDaXoa} - {tenChuan}"" thành công!"
                    }
                End If
            End If

            Dim dto As New DanhMucDTO() With {
                .TenDanhMuc = tenChuan,
                .MoTa = moTaChuan
            }

            Dim maMoi As Integer = _dao.ThemDanhMuc(dto)
            If maMoi > 0 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = True,
                    .MaDanhMuc = maMoi,
                    .ThongBao = $"Đã thêm danh mục mới ""#{maMoi} - {tenChuan}"" thành công!"
                }
            End If

            Return New KetQuaDanhMuc() With {
                .ThanhCong = False,
                .ThongBao = "Không thể thêm danh mục vào cơ sở dữ liệu!"
            }
        End Function

        ''' <summary>
        ''' Kiểm tra hợp lệ và cập nhật thông tin danh mục thực đơn.
        ''' </summary>
        Public Function CapNhatDanhMuc(maDanhMuc As Integer, tenDanhMuc As String, moTa As String) As KetQuaDanhMuc
            If maDanhMuc <= 0 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn một danh mục trên bảng trước khi bấm Cập nhật!"
                }
            End If

            Dim tenChuan As String = If(tenDanhMuc, String.Empty).Trim()
            Dim moTaChuan As String = If(moTa, String.Empty).Trim()

            If String.IsNullOrWhiteSpace(tenChuan) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên danh mục thực đơn không được để trống!"
                }
            End If

            If tenChuan.Length > 100 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Tên danh mục không được vượt quá 100 ký tự!"
                }
            End If

            If moTaChuan.Length > 255 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Mô tả danh mục không được vượt quá 255 ký tự!"
                }
            End If

            If _dao.KiemTraTrungTen(tenChuan, maDanhMuc) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = $"Tên danh mục ""{tenChuan}"" bị trùng với một danh mục khác!"
                }
            End If

            Dim dto As New DanhMucDTO() With {
                .MaDanhMuc = maDanhMuc,
                .TenDanhMuc = tenChuan,
                .MoTa = moTaChuan
            }

            If _dao.CapNhatDanhMuc(dto) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = True,
                    .MaDanhMuc = maDanhMuc,
                    .ThongBao = $"Đã cập nhật danh mục ""#{maDanhMuc} - {tenChuan}"" thành công!"
                }
            End If

            Return New KetQuaDanhMuc() With {
                .ThanhCong = False,
                .ThongBao = "Không tìm thấy danh mục cần cập nhật hoặc dữ liệu không thay đổi!"
            }
        End Function

        ''' <summary>
        ''' Kiểm tra ràng buộc khóa ngoại (số lượng món ăn thuộc danh mục) và thực hiện xóa mềm (DM_Xoa = 1).
        ''' </summary>
        Public Function XoaDanhMuc(maDanhMuc As Integer, Optional tenHienThi As String = "") As KetQuaDanhMuc
            If maDanhMuc <= 0 Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = "Vui lòng chọn danh mục cần xóa trên bảng!"
                }
            End If

            Dim soMon As Integer = _dao.DemSoMonTrongDanhMuc(maDanhMuc)
            If soMon > 0 Then
                Dim ten As String = If(String.IsNullOrWhiteSpace(tenHienThi), $"#{maDanhMuc}", tenHienThi.Trim())
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = False,
                    .ThongBao = $"Không thể xóa danh mục ""{ten}"" vì đang có {soMon} món ăn thuộc danh mục này!"
                }
            End If

            If _dao.XoaMemDanhMuc(maDanhMuc) Then
                Return New KetQuaDanhMuc() With {
                    .ThanhCong = True,
                    .MaDanhMuc = maDanhMuc,
                    .ThongBao = $"Đã xóa danh mục ""{tenHienThi}"" thành công!"
                }
            End If

            Return New KetQuaDanhMuc() With {
                .ThanhCong = False,
                .ThongBao = "Không thể xóa danh mục đã chọn!"
            }
        End Function

    End Class
End Namespace
