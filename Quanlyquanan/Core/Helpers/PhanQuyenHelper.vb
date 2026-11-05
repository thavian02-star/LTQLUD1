Imports System.Windows.Forms
Imports Quanlyquanan.Core.Security

Namespace Core.Helpers
    ''' <summary>
    ''' Tiện ích tự động duyệt và áp dụng quyền lên toàn bộ Control và Menu của Form dựa trên thuộc tính Tag.
    ''' </summary>
    Public Class PhanQuyenHelper
        ''' <summary>
        ''' Phương thức tương đương hoặc bí danh gọi ApDungPhanQuyen.
        ''' </summary>
        Public Shared Sub PhanQuyenForm(targetForm As Form, Optional anControl As Boolean = False)
            ApDungPhanQuyen(targetForm, anControl)
        End Sub

        ''' <summary>
        ''' Quét toàn bộ Control trên Form, nếu Tag là mã quyền và user không có quyền, tự động vô hiệu hóa hoặc ẩn.
        ''' </summary>
        ''' <param name="targetForm">Form cần phân quyền</param>
        ''' <param name="anControl">True: Ẩn hẳn (Visible = False), False: Chỉ làm mờ (Enabled = False)</param>
        Public Shared Sub ApDungPhanQuyen(targetForm As Form, Optional anControl As Boolean = False)
            If targetForm Is Nothing Then Return
            ' Chủ quán có toàn quyền, không cần ẩn/mờ bất cứ nút nào
            If Session.MaVaiTro = 1 Then Return

            ' 1. Duyệt controls thông thường
            DuyetControls(targetForm.Controls, anControl)

            ' 2. Duyệt MenuStrip nếu có
            If targetForm.MainMenuStrip IsNot Nothing Then
                DuyetMenuItems(targetForm.MainMenuStrip.Items, anControl)
            End If
        End Sub

        ''' <summary>
        ''' Kiểm tra xem chuỗi Tag có phải là một mã định danh quyền RBAC hay không.
        ''' </summary>
        Private Shared Function LaTagPhanQuyen(tagStr As String) As Boolean
            If String.IsNullOrWhiteSpace(tagStr) Then Return False
            Dim tagUpper As String = tagStr.Trim().ToUpper()
            Return tagUpper.StartsWith("Q_") OrElse
                   tagUpper.StartsWith("POS_") OrElse
                   tagUpper.StartsWith("BEP_") OrElse
                   tagUpper.StartsWith("B_") OrElse
                   tagUpper.StartsWith("QL_") OrElse
                   tagUpper.StartsWith("CQ_") OrElse
                   tagUpper.StartsWith("CA_NHAN_") OrElse
                   tagUpper.StartsWith("CHUNG_")
        End Function

        Private Shared Sub DuyetControls(controls As Control.ControlCollection, anControl As Boolean)
            For Each c As Control In controls
                Dim tagStr As String = TryCast(c.Tag, String)
                If Not String.IsNullOrWhiteSpace(tagStr) AndAlso LaTagPhanQuyen(tagStr) Then
                    Dim duocPhep As Boolean = Session.CoQuyen(tagStr)
                    If Not duocPhep Then
                        If anControl Then
                            c.Visible = False
                        Else
                            c.Enabled = False
                        End If
                    End If
                End If

                If c.HasChildren Then
                    DuyetControls(c.Controls, anControl)
                End If
            Next
        End Sub

        Private Shared Sub DuyetMenuItems(items As ToolStripItemCollection, anControl As Boolean)
            For Each item As ToolStripItem In items
                Dim tagStr As String = TryCast(item.Tag, String)
                If Not String.IsNullOrWhiteSpace(tagStr) AndAlso LaTagPhanQuyen(tagStr) Then
                    Dim duocPhep As Boolean = Session.CoQuyen(tagStr)
                    If Not duocPhep Then
                        If anControl Then
                            item.Visible = False
                        Else
                            item.Enabled = False
                        End If
                    End If
                End If

                Dim dropDownItem As ToolStripDropDownItem = TryCast(item, ToolStripDropDownItem)
                If dropDownItem IsNot Nothing AndAlso dropDownItem.HasDropDownItems Then
                    DuyetMenuItems(dropDownItem.DropDownItems, anControl)
                End If
            Next
        End Sub
    End Class
End Namespace
