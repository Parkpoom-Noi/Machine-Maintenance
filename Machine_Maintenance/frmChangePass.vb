Imports BLL_Controller



Public Class frmChangePass
    Dim BLL As BLL_Load = New BLL_Load

    Dim strUser As String
    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim dt_username As DataTable
        Dim u_status As Integer
        Dim u_id As Integer
        Dim u_name As String
        dt_username = BLL.GetUsernameForChange(Trim(tb_username.Text), tb_password.Text)
        If dt_username.Rows.Count > 0 Then
            For i As Integer = 0 To dt_username.Rows.Count - 1
                u_id = dt_username.Rows(0)("user_id").ToString
                u_status = dt_username.Rows(0)("user_status").ToString
                u_name = dt_username.Rows(0)("user_name").ToString
            Next
            If tbNewpass.Text = tbConNewpass.Text Then
                Dim INS As Boolean = BLL.ChangePassword(tbNewpass.Text, tb_id.Text)
                If INS = True Then
                    MsgBox("Change Password Complete", MsgBoxStyle.OkOnly, "Complete")
                    Me.Hide()

                Else
                    MsgBox("Change Password not Complete please contact IT", MsgBoxStyle.OkOnly, "Not Complete")
                End If

            Else

                MessageBox.Show("Password Not match")
            End If


        Else
            MessageBox.Show("Old Password Incorrect")
        End If
    End Sub

    Private Sub frmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_username As DataTable


        dt_username = BLL.GetUsernameMT(strUser)
        If dt_username.Rows.Count > 0 Then
            Me.tb_username.Text = dt_username.Rows(0)("user_name").ToString
            Me.tb_id.Text = Trim(dt_username.Rows(0)("user_id").ToString)
        End If

    End Sub
End Class