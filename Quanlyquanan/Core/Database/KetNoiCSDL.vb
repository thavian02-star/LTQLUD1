Imports System.Data
Imports Microsoft.Data.SqlClient

Namespace Core.Database
    ''' <summary>
    ''' Lớp quản lý kết nối và thực thi truy vấn tới Microsoft SQL Server 2022 (Docker).
    ''' Áp dụng cơ chế Using tự động đóng kết nối và Parameterized Query chống SQL Injection.
    ''' </summary>
    Public Class KetNoiCSDL
        ''' <summary>
        ''' Chuỗi kết nối mặc định tới SQL Server 2022 Express chạy trên Docker (Host Gateway: 192.168.247.1).
        ''' </summary>
        Public Shared Property ConnectionString As String =
            "Server=192.168.247.1,1433;Database=QuanLyQuanAnDB;User Id=sa;Password=password123!;TrustServerCertificate=True;Connect Timeout=15;"

        ''' <summary>
        ''' Tạo và mở đối tượng SqlConnection mới.
        ''' </summary>
        Public Shared Function GetConnection() As SqlConnection
            Dim conn As New SqlConnection(ConnectionString)
            conn.Open()
            Return conn
        End Function

        ''' <summary>
        ''' Kiểm tra nhanh trạng thái kết nối tới Database.
        ''' </summary>
        Public Shared Function KiemTraKetNoi() As Boolean
            Try
                Using conn As New SqlConnection(ConnectionString)
                    conn.Open()
                    Return conn.State = ConnectionState.Open
                End Using
            Catch ex As Exception
                Return False
            End Try
        End Function

        ''' <summary>
        ''' Thực thi câu truy vấn SELECT và trả về DataTable.
        ''' </summary>
        Public Shared Function ExecuteQuery(sql As String, Optional parameters As SqlParameter() = Nothing) As DataTable
            Dim dt As New DataTable()
            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                End Using
            End Using
            Return dt
        End Function

        ''' <summary>
        ''' Thực thi lệnh INSERT, UPDATE, DELETE và trả về số dòng bị ảnh hưởng.
        ''' </summary>
        Public Shared Function ExecuteNonQuery(sql As String, Optional parameters As SqlParameter() = Nothing) As Integer
            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    conn.Open()
                    Return cmd.ExecuteNonQuery()
                End Using
            End Using
        End Function

        ''' <summary>
        ''' Thực thi truy vấn trả về một giá trị đơn lẻ (COUNT, MAX, SUM, SCOPE_IDENTITY).
        ''' </summary>
        Public Shared Function ExecuteScalar(sql As String, Optional parameters As SqlParameter() = Nothing) As Object
            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand(sql, conn)
                    If parameters IsNot Nothing AndAlso parameters.Length > 0 Then
                        cmd.Parameters.AddRange(parameters)
                    End If
                    conn.Open()
                    Return cmd.ExecuteScalar()
                End Using
            End Using
        End Function
    End Class
End Namespace
