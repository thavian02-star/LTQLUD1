Imports System.Drawing
Imports System.Windows.Forms
Imports Quanlyquanan.Core.Helpers
Imports Quanlyquanan.Core.Security

Namespace Features.Main
    ''' <summary>
    ''' Màn hình chính (Dashboard & App Shell) của hệ thống Quản lý Quán ăn.
    ''' Điều hướng các phân hệ nghiệp vụ, hiển thị thông tin phiên làm việc
    ''' và tự động áp dụng phân quyền (RBAC) theo vai trò người dùng.
    ''' </summary>
    Public Class frmMain

        ''' <summary>
        ''' Form nghiệp vụ con đang hiển thị hiện tại trong vùng làm việc trung tâm
        ''' </summary>
        Private currentChildForm As Form = Nothing

        ''' <summary>
        ''' Cờ đánh dấu người dùng chủ động nhấn nút Đăng Xuất (để phân biệt với nhấn nút [X] thoát ứng dụng)
        ''' </summary>
        Private isLoggingOut As Boolean = False

        Public Sub New()
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Sự kiện nạp Form chính: Nạp thông tin phiên, kích hoạt đồng hồ và áp dụng phân quyền tự động.
        ''' </summary>
        Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            ' 1. Nạp thông tin phiên đăng nhập lên thanh Header & Status Bar
            CapNhatThongTinNguoiDung()

            ' 2. Cập nhật đồng hồ thời gian thực lần đầu
            CapNhatDongHo()

            ' 3. Áp dụng phân quyền tự động theo vai trò (RBAC)
            ' Quét toàn bộ các control có gán thuộc tính Tag và so khớp với Session.DanhSachQuyen
            ' anControl = False: Làm mờ (Enabled = False) để thể hiện rõ quyền hạn
            PhanQuyenHelper.ApDungPhanQuyen(Me, anControl:=False)

            ' 4. Điều chỉnh hiển thị KPI Doanh thu: Chỉ Chủ quán có quyền xem
            pnlKpiDoanhThu.Visible = Session.CoQuyen("CQ_BAO_CAO_THONG_KE")

            ' 5. Bỏ chọn dòng mặc định trên danh sách Hoạt Động Gần Đây để tránh vệt xanh thừa
            lstActivity.ClearSelected()

            ' 6. Hiển thị Dashboard Home mặc định
            QuayLaiDashboardHome()
        End Sub

        ''' <summary>
        ''' Hiển thị tên, vai trò và Session ID của người dùng đang đăng nhập từ lớp Session toàn cục.
        ''' </summary>
        Private Sub CapNhatThongTinNguoiDung()
            If Not String.IsNullOrEmpty(Session.HoTenNhanVien) Then
                lblUserName.Text = Session.HoTenNhanVien
                lblWelcomeGreeting.Text = "Xin chào, " & Session.HoTenNhanVien & "! 👋"

                ' Lấy 2 ký tự viết tắt làm Avatar tròn
                Dim parts As String() = Session.HoTenNhanVien.Trim().Split(" "c)
                If parts.Length >= 2 Then
                    lblUserAvatar.Text = (parts(0)(0).ToString() & parts(parts.Length - 1)(0).ToString()).ToUpper()
                ElseIf parts.Length = 1 AndAlso parts(0).Length > 0 Then
                    lblUserAvatar.Text = parts(0).Substring(0, Math.Min(2, parts(0).Length)).ToUpper()
                Else
                    lblUserAvatar.Text = "U"
                End If
            Else
                lblUserName.Text = Session.TenDangNhap
                lblWelcomeGreeting.Text = "Xin chào, " & Session.TenDangNhap & "! 👋"
                lblUserAvatar.Text = "U"
            End If

            lblUserRole.Text = If(String.IsNullOrEmpty(Session.TenVaiTro), "NHÂN VIÊN", Session.TenVaiTro.ToUpper())
            lblStatusSession.Text = "Phiên: " & Session.TenDangNhap & " (" & Session.TenVaiTro & ")"

            ' Đổi màu Badge theo vai trò
            Select Case Session.MaVaiTro
                Case 1 ' Chủ quán
                    lblUserRole.BackColor = Color.FromArgb(243, 156, 18) ' Cam vàng
                Case 2 ' Quản lý
                    lblUserRole.BackColor = Color.FromArgb(155, 89, 182) ' Tím
                Case 3 ' Phục vụ
                    lblUserRole.BackColor = Color.FromArgb(46, 204, 113) ' Xanh lá
                Case 4 ' Nhà bếp / Pha chế
                    lblUserRole.BackColor = Color.FromArgb(230, 126, 34) ' Cam đậm
                Case Else
                    lblUserRole.BackColor = Color.FromArgb(52, 152, 219) ' Xanh dương
            End Select
        End Sub

        ''' <summary>
        ''' Cập nhật đồng hồ thời gian thực mỗi giây
        ''' </summary>
        Private Sub tmrClock_Tick(sender As Object, e As EventArgs) Handles tmrClock.Tick
            CapNhatDongHo()
        End Sub

        Private Sub CapNhatDongHo()
            Dim now As DateTime = DateTime.Now
            Dim thuTiengViet As String = LayThuTiengViet(now.DayOfWeek)
            lblClock.Text = "🕒 " & now.ToString("HH:mm:ss") & " - " & thuTiengViet & ", " & now.ToString("dd/MM/yyyy")
        End Sub

        Private Function LayThuTiengViet(dayOfWeek As DayOfWeek) As String
            Select Case dayOfWeek
                Case DayOfWeek.Monday : Return "Thứ Hai"
                Case DayOfWeek.Tuesday : Return "Thứ Ba"
                Case DayOfWeek.Wednesday : Return "Thứ Tư"
                Case DayOfWeek.Thursday : Return "Thứ Năm"
                Case DayOfWeek.Friday : Return "Thứ Sáu"
                Case DayOfWeek.Saturday : Return "Thứ Bảy"
                Case DayOfWeek.Sunday : Return "Chủ Nhật"
                Case Else : Return ""
            End Select
        End Function

        ''' <summary>
        ''' Phương thức nhúng Form con nghiệp vụ vào bên trong vùng làm việc pnlContent
        ''' Tự động giải phóng Form cũ và hiển thị Form mới toàn màn hình.
        ''' </summary>
        Public Sub MoFormCon(childForm As Form)
            If currentChildForm IsNot Nothing Then
                currentChildForm.Close()
                currentChildForm.Dispose()
            End If

            currentChildForm = childForm
            childForm.TopLevel = False
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill

            pnlContent.Controls.Clear()
            pnlContent.Controls.Add(childForm)
            pnlContent.Tag = childForm
            childForm.BringToFront()
            childForm.Show()
        End Sub

        ''' <summary>
        ''' Quay trở lại màn hình Dashboard Tổng quan ban đầu
        ''' </summary>
        Public Sub QuayLaiDashboardHome()
            If currentChildForm IsNot Nothing Then
                currentChildForm.Close()
                currentChildForm.Dispose()
                currentChildForm = Nothing
            End If

            pnlContent.Controls.Clear()
            pnlContent.Controls.Add(pnlDashboardHome)
            pnlDashboardHome.BringToFront()
            CapNhatButtonActive(Nothing)
        End Sub

        ''' <summary>
        ''' Đổi trạng thái hiển thị của nút menu đang được chọn (Active)
        ''' </summary>
        Private Sub CapNhatButtonActive(btnActive As Button)
            Dim sidebarButtons As Button() = {
                btnSoDoBan, btnNhaBep, btnDuyetChamCong,
                btnQuanLyNhanSu, btnQuanLyThucDon, btnBaoCao,
                btnChamCongCaNhan, btnDoiMatKhau
            }

            For Each btn As Button In sidebarButtons
                If btn Is btnActive Then
                    btn.BackColor = Color.FromArgb(26, 82, 118) ' Màu xanh đậm đang chọn
                    btn.Font = New Font(btn.Font, FontStyle.Bold)
                Else
                    btn.BackColor = Color.Transparent
                    btn.Font = New Font(btn.Font, FontStyle.Regular)
                End If
            Next
        End Sub

        ' ==============================================================
        ' CÁC SỰ KIỆN ĐIỀU HƯỚNG MENU SIDEBAR & QUICK ACTIONS
        ' ==============================================================

        ''' <summary>
        ''' Click vào Logo / Tiêu đề thương hiệu trên Header để quay lại Dashboard
        ''' </summary>
        Private Sub pnlBrand_Click(sender As Object, e As EventArgs) Handles pnlBrand.Click, lblBrandTitle.Click, lblBrandIcon.Click, lblBrandSubtitle.Click
            QuayLaiDashboardHome()
        End Sub

        Private Sub btnSoDoBan_Click(sender As Object, e As EventArgs) Handles btnSoDoBan.Click, btnQuickDatBan.Click, btnQuickOpenSoDoBan.Click
            CapNhatButtonActive(btnSoDoBan)
            MessageBox.Show(
                "Phân hệ [Sơ Đồ Bàn Ăn & Gọi Món] (Features/BanAn_GoiMon) đang sẵn sàng để triển khai ở Sprint tiếp theo!" & vbCrLf &
                "- Hiển thị trạng thái các bàn: Trống, Có khách, Chờ món, Món đã xong." & vbCrLf &
                "- Gọi món, chuyển bàn, gộp bàn và in hóa đơn thanh toán.",
                "Thông Báo Phân Hệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnNhaBep_Click(sender As Object, e As EventArgs) Handles btnNhaBep.Click, btnQuickNhaBep.Click
            CapNhatButtonActive(btnNhaBep)
            MessageBox.Show(
                "Phân hệ [Hàng Đợi Nhà Bếp & Pha Chế] (Features/NhaBep)!" & vbCrLf &
                "- Hiển thị danh sách món cần nấu theo thứ tự thời gian thực (FIFO)." & vbCrLf &
                "- Đầu bếp bấm xác nhận món đã nấu xong để phục vụ bưng lên bàn.",
                "Thông Báo Phân Hệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnDuyetChamCong_Click(sender As Object, e As EventArgs) Handles btnDuyetChamCong.Click, btnQuickDuyetCong.Click
            CapNhatButtonActive(btnDuyetChamCong)
            Using fCa As New Features.Shift.frmCaLamViec()
                fCa.ShowDialog(Me)
            End Using
            CapNhatButtonActive(Nothing)
        End Sub

        Private Sub btnQuanLyNhanSu_Click(sender As Object, e As EventArgs) Handles btnQuanLyNhanSu.Click
            CapNhatButtonActive(btnQuanLyNhanSu)
            MessageBox.Show(
                "Phân hệ [Quản Lý Nhân Sự, Trình Độ Vi Tính & Cấp Phát Trang Phục] (Features/NhanSu)!" & vbCrLf &
                "- Tiếp nhận hồ sơ nhân viên, chọn nhiều kỹ năng vi tính (Word, Excel, Cài phần mềm)." & vbCrLf &
                "- Cấp phát dụng cụ, trang phục và thu hồi khi nhân viên thôi việc.",
                "Thông Báo Phân Hệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnQuanLyThucDon_Click(sender As Object, e As EventArgs) Handles btnQuanLyThucDon.Click, btnQuickThucDon.Click
            CapNhatButtonActive(btnQuanLyThucDon)
            Using fMonAn As New Features.Menu.frmMonAn()
                fMonAn.ShowDialog(Me)
            End Using
            CapNhatButtonActive(Nothing)
        End Sub

        Private Sub btnBaoCao_Click(sender As Object, e As EventArgs) Handles btnBaoCao.Click, btnQuickBaoCao.Click
            CapNhatButtonActive(btnBaoCao)
            MessageBox.Show(
                "Phân hệ [Báo Cáo Doanh Thu, Số Khách & Món Ăn Bán Chạy] (Features/BaoCao)!" & vbCrLf &
                "- Thống kê doanh thu theo ngày, tháng, quý, năm." & vbCrLf &
                "- Thống kê năng suất phục vụ của từng nhân viên.",
                "Thông Báo Phân Hệ",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        Private Sub btnChamCongCaNhan_Click(sender As Object, e As EventArgs) Handles btnChamCongCaNhan.Click, btnQuickChamCong.Click
            CapNhatButtonActive(btnChamCongCaNhan)
            MessageBox.Show(
                "Chức năng [Chấm Công Cá Nhân]:" & vbCrLf &
                "- Cho phép nhân viên check-in vào ca và check-out kết thúc ca làm." & vbCrLf &
                "- Xem lịch làm việc phân công trong tuần.",
                "Thông Báo Cá Nhân",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        End Sub

        ''' <summary>
        ''' Mở hộp thoại Đổi Mật Khẩu (Modal Dialog) cho tài khoản đang đăng nhập.
        ''' Nếu đổi mật khẩu thành công (DialogResult.OK), tự động ghi nhận vào Hoạt Động Gần Đây.
        ''' </summary>
        Private Sub btnDoiMatKhau_Click(sender As Object, e As EventArgs) Handles btnDoiMatKhau.Click
            CapNhatButtonActive(btnDoiMatKhau)
            Using fDoiMK As New Features.Auth.frmDoiMatKhau()
                If fDoiMK.ShowDialog(Me) = DialogResult.OK Then
                    GhiNhatKyHoatDong($"Tài khoản '{Session.TenDangNhap}' đã cập nhật mật khẩu mới")
                End If
            End Using
        End Sub

        ''' <summary>
        ''' Ghi thêm một dòng sự kiện mới lên đầu danh sách "Hoạt Động Gần Đây" (lstActivity).
        ''' </summary>
        Public Sub GhiNhatKyHoatDong(noiDung As String)
            If String.IsNullOrWhiteSpace(noiDung) Then Return
            Dim mocThoiGian As String = DateTime.Now.ToString("HH:mm")
            lstActivity.Items.Insert(0, $"• [{mocThoiGian}] {noiDung.Trim()}")
            lstActivity.ClearSelected()
        End Sub

        ' ==============================================================
        ' XỬ LÝ ĐĂNG XUẤT & ĐÓNG FORM
        ' ==============================================================

        ''' <summary>
        ''' Xử lý khi nhấn nút Đăng Xuất trên Header: Hỏi xác nhận -> Xóa Session -> Đóng Form để quay về Đăng Nhập
        ''' </summary>
        Private Sub btnDangXuat_Click(sender As Object, e As EventArgs) Handles btnDangXuat.Click
            Dim xacNhan As DialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất khỏi phiên làm việc hiện tại?",
                "Xác Nhận Đăng Xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            )

            If xacNhan = DialogResult.Yes Then
                isLoggingOut = True
                ' Xóa sạch phiên đăng nhập
                Session.Clear()

                ' Đóng Form chính với DialogResult.OK để báo cho luồng khởi động biết là đăng xuất
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If
        End Sub

        ''' <summary>
        ''' Xử lý sự kiện đóng Form: Nếu người dùng bấm nút [X] của cửa sổ, hỏi xác nhận thoát toàn bộ ứng dụng.
        ''' </summary>
        Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            ' Dừng Timer giải phóng tài nguyên
            tmrClock.Stop()

            ' Nếu không phải là chủ động bấm Đăng xuất mà người dùng bấm nút [X] trên thanh tiêu đề Windows
            If Not isLoggingOut AndAlso e.CloseReason = CloseReason.UserClosing Then
                Dim xacNhanThoat As DialogResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát khỏi Hệ Thống Quản Lý Quán Ăn?",
                    "Xác Nhận Thoát Ứng Dụng",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                )

                If xacNhanThoat = DialogResult.No Then
                    e.Cancel = True
                    tmrClock.Start()
                    Return
                End If

                ' Người dùng xác nhận thoát app
                Me.DialogResult = DialogResult.Cancel
            End If
        End Sub
    End Class
End Namespace
