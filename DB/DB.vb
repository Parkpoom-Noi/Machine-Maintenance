Imports System.Data.SqlClient

Public Class DB_ART
    Public Function SelectSQL(ByVal _SQL As String) As DataTable
        Dim conDb As String = "packet size=4096;user id=sa;data source=10.50.0.8\SQLEXPRESS; persist security info=True;initial catalog=ART_INTRA;password=PasswordSQL17"
        Dim conn As New SqlConnection(conDb)
        Dim cmd As New SqlCommand(_SQL, conn)
        cmd.CommandTimeout = 600
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function

    Public Function ExecuteSQL(ByVal _SQL As String) As Boolean
        Try
            Dim conDb As String = "packet size=4096;user id=sa;data source=10.50.0.8\SQLEXPRESS; persist security info=True;initial catalog=ART_INTRA;password=PasswordSQL17"
            Dim conn As New SqlConnection(conDb)
            Dim cmd As New SqlCommand(_SQL, conn)
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd.ExecuteNonQuery()
            conn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
