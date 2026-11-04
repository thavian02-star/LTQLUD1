Imports System.Security.Cryptography
Imports System.Text

Namespace Core.Security
    ''' <summary>
    ''' Tiện ích băm mật khẩu MD5 đồng bộ với mật khẩu mẫu trong database/docker-mssql/seed-data.sql.
    ''' </summary>
    Public Class MaHoaMD5
        ''' <summary>
        ''' Băm một chuỗi văn bản thành chuỗi hex MD5 32 ký tự chữ thường.
        ''' Ví dụ: "123456" -> "e10adc3949ba59abbe56e057f20f883e"
        ''' </summary>
        Public Shared Function BamMD5(input As String) As String
            If String.IsNullOrEmpty(input) Then Return String.Empty

            Using md5 As MD5 = MD5.Create()
                Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
                Dim hashBytes As Byte() = md5.ComputeHash(inputBytes)

                Dim sb As New StringBuilder()
                For Each b As Byte In hashBytes
                    sb.Append(b.ToString("x2"))
                Next
                Return sb.ToString()
            End Using
        End Function
    End Class
End Namespace
