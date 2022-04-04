Imports BLL_Controller
Public Class frmLogin
    Dim BLL As BLL_Load = New BLL_Load
    Dim uID As Integer
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Login()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub tb_password_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_password.KeyDown
        If e.KeyCode = Keys.Enter Then
            Login()
        End If
    End Sub
    Private Sub Login()
        Dim dt_username As DataTable
        Dim u_status As Integer
        Dim u_id As Integer
        Dim u_name As String
        Dim u_online As Integer
        dt_username = BLL.GetUsername(tb_username.Text, tb_password.Text)
        If dt_username.Rows.Count > 0 Then
            For i As Integer = 0 To dt_username.Rows.Count - 1
                u_id = dt_username.Rows(0)("user_id").ToString
                u_status = dt_username.Rows(0)("user_status").ToString
                u_name = dt_username.Rows(0)("user_name").ToString
                u_online = dt_username.Rows(0)("user_online").ToString
                uID = dt_username.Rows(0)("user_id")
            Next
            If u_online = 0 Then
                If u_status = 2 Then
                    frmMT._strUser = u_id.ToString
                    frmMT.Show()
                    Me.Hide()
                    frmPRD.Hide()
                ElseIf u_status = 3 Then
                    frmMNG._strUser = u_id.ToString
                    frmMNG.Show()
                    Me.Hide()
                    frmPRD.Hide()

                ElseIf u_status = 4 Then
                    frmMT_MGR._strUser = u_id.ToString
                    frmMT_MGR.Show()
                    Me.Hide()
                    frmPRD.Hide()
                End If
                BLL.LockLogin(uID)

            Else

                MessageBox.Show("Now this user is logged in.")

            End If


        Else
            MessageBox.Show("Username or Password Incorrect")
        End If

    End Sub


    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class