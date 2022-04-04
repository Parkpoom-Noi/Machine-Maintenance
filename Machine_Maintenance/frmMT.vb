Imports System.Globalization
Imports System.IO

Imports System.Net
Imports System.ComponentModel
Imports System.Text
Imports System.Threading
Imports Excel = Microsoft.Office.Interop.Excel
Imports BLL_Controller
Public Class frmMT
    Dim strUser As String
    Dim strID As String
    Dim BLL As BLL_Load = New BLL_Load
    Dim _t As Threading.Thread
    Dim _t2 As Threading.Thread
    Dim StatusRun As Boolean
    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Private Sub frmMT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_username As DataTable

        Dim sAdd1 As String = ""

        dt_username = BLL.GetUsernameMT(strUser)
        If dt_username.Rows.Count > 0 Then
            Me.lb_name.Text = dt_username.Rows(0)("user_name").ToString
            Me.tb_id.Text = Trim(dt_username.Rows(0)("user_id").ToString)
        End If
        GetMC()
        DGV_SEL(sAdd1)

        DGV_Edit_SEL(sAdd1)

        DGV_Complete_SEL()

        BLL.LockDataNew(Trim(strUser))
        BLL.LockDataOld(Trim(strUser))
        _t = New Threading.Thread(AddressOf Run)
        _t.IsBackground = True
        _t.Start()

    End Sub

#Region "Global All"
    Public Function SendLineMT(ByVal tb_found As String, ByVal tb_tag As String, ByVal tb_code As String, ByVal tb_detail As String, ByVal who_fix As String, ByVal Status As String, ByVal mt_note As String) As Boolean
        '*****************************************************'
        Dim mt_wo As String
        mt_wo = BLL.WhoFix(who_fix.ToString)
        '*****************************************************'
        Dim fix_typee As String
        If Status.ToString = 1 Then
            fix_typee = "Complete"
        ElseIf Status.ToString = 2 Then
            fix_typee = "Temporary Fix"
        ElseIf Status.ToString = 3 Then
            fix_typee = "Survalence"
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            System.Net.ServicePointManager.Expect100Continue = False
            Dim request = DirectCast(WebRequest.Create(“https://notify-api.line.me/api/notify”), HttpWebRequest)
            Dim postData = String.Format(“message={0}”, "Case Maintenance Request FORM" & vbCrLf & "Serial No. : " & tb_tag & vbCrLf & "Request by : " & tb_found & vbCrLf & "Machine No. : " & tb_code & vbCrLf & "Description : " & tb_detail & vbCrLf & "Has been fixed by : " & mt_wo & vbCrLf & " Status is : " & fix_typee & vbCrLf & " Note is : " & mt_note)
            Dim data = Encoding.UTF8.GetBytes(postData)
            request.Method = “POST”
            request.ContentType = “application/x-www-form-urlencoded”
            request.ContentLength = data.Length
            request.Headers.Add(“Authorization”, “Bearer YourToken”)
            request.AllowWriteStreamBuffering = True
            request.KeepAlive = False
            request.Credentials = CredentialCache.DefaultCredentials
            Using stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
            Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
            Return True
        Catch ex As Exception
            Return False
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function


    Public Function GetSEQ() As Integer
        Dim TagNO As Integer = Nothing
        Dim dt_TAG As DataTable
        dt_TAG = BLL.GetTag()
        If dt_TAG.Rows.Count > 0 Then
            For i As Integer = 0 To dt_TAG.Rows.Count - 1
                TagNO = Integer.Parse(dt_TAG.Rows(0)("mc_tag_no").ToString) + 1
            Next
        End If
        Return TagNO
    End Function


    Private Sub Run()
        While _t.IsAlive
            Try
                If My.Computer.Network.IsAvailable Then
                    If My.Computer.Network.Ping("10.50.0.8") Then
                        btnStatus.BackColor = Color.Green
                    Else
                        btnStatus.BackColor = Color.Red
                    End If

                    Threading.Thread.Sleep(1000)
                    btnStatus.BackColor = Color.Gainsboro
                Else
                    btnStatus.BackColor = Color.Red
                End If

                Threading.Thread.Sleep(1000)
                btnStatus.BackColor = Color.Gainsboro
            Catch ex As Exception

            End Try


        End While
    End Sub

#End Region
#Region "For Maintenance"
    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        Dim sAdd1 As String = ""
        DGV_SEL(sAdd1)
        DGV_Edit_SEL(sAdd1)
        DGV_Complete_SEL()
        BLL.LockDataNew(Trim(strUser))
        BLL.LockDataOld(Trim(strUser))
    End Sub
    Public Sub DGV_SEL(ByVal _sqlAdd As String)
        DGV_MA.DataSource = BLL.GetDataSel(_sqlAdd)
    End Sub

    Public Sub DGV_Edit_SEL(ByVal _sqlAdd As String)
        dgv_Edit.DataSource = BLL.GetDataEdit(_sqlAdd)
    End Sub


    Private Sub mt_btn_save_Click(sender As Object, e As EventArgs) Handles mt_btn_save.Click

        '*****************************************************'
        Dim who_fix As Integer = 0
        who_fix = BLL.WhoFixINT(cb_john.Checked, cb_M.Checked, cb_Pond.Checked, cb_It.Checked, cbJay.Checked)

        If who_fix = 0 Then
            MsgBox("Please check select Maintenance by again!", MsgBoxStyle.Critical)
            who_fix = 0
            Exit Sub
        End If

        '*****************************************************'
        Dim fix_type As Integer = 0
        If mt_rd_complete.Checked = True Then
            fix_type = 1
        ElseIf mt_rd_temporary.Checked = True Then
            fix_type = 2
        ElseIf mt_rd_suvalence.Checked = True Then
            fix_type = 3
        Else
            fix_type = 0
        End If
        Dim a = mt_tb_hrs.Text
        '*****************************************************'          
        If mt_tb_hrs.Text <> "" And mt_tb_note.Text <> "" And fix_type <> 0 And who_fix <> 0 Then


            Dim INS As Boolean = BLL.InsFix(mt_tb_note.Text, mt_tb_mcno.Text, fix_type, mt_tb_hrs.Text, who_fix, BLL.GetIPAddress(), lb_name.Text, mt_tb_tag.Text)
            If INS = True Then
                MsgBox("Save DATA Complete", MsgBoxStyle.OkOnly, "Complete")
                If SendLineMT(Trim(mt_tbfound.Text), Trim(mt_tb_tag.Text), Trim(mt_tb_mcno.Text), Trim(mt_tb_detail.Text), who_fix, fix_type, mt_tb_note.Text) <> True Then
                    MessageBox.Show("Send DATA to line not Complete please contact IT", “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False

                mt_rd_complete.Checked = False
                mt_rd_temporary.Checked = False
                mt_rd_suvalence.Checked = False
                mt_tb_tag.Text = ""
                mt_tb_mcno.Text = ""
                mt_tb_date.Text = ""
                mt_tbfound.Text = ""
                mt_tb_sign.Text = ""
                mt_tb_problem.Text = ""
                mt_tb_detail.Text = ""
                mt_tb_note.Text = ""
                mt_tb_hrs.Text = ""
                fix_type = Nothing
                who_fix = Nothing

                Dim sAdd1 As String = "" '" OR ( [mc_lock] = 1 AND [mc_lock_by] = '" & _strUser & "')"
                DGV_SEL(sAdd1)
                DGV_Edit_SEL(sAdd1)
                DGV_Complete_SEL()
            Else
                MsgBox("Save DATA not Complete please contact IT", MsgBoxStyle.OkOnly, "Not Complete")
            End If

        Else
            MsgBox("กรุณากรอกข้อมูลให้ครบ", MsgBoxStyle.Critical, "กรอกข้อมูลไม่ครบ!!!")
        End If


    End Sub

    Private Sub frmMT_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        BLL.UnlockData(Trim(strUser))
        BLL.UnlockLogin(Trim(strUser))
        Application.Exit()
    End Sub

    Private Sub DGV_MA_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGV_MA.CellMouseClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then

            cb_john.Checked = False
            cb_M.Checked = False
            cb_Pond.Checked = False
            cb_It.Checked = False

            mt_rd_complete.Checked = False
            mt_rd_temporary.Checked = False
            mt_rd_suvalence.Checked = False
            mt_tb_tag.Text = ""
            mt_tb_mcno.Text = ""
            mt_tb_date.Text = ""
            mt_tbfound.Text = ""
            mt_tb_sign.Text = ""
            mt_tb_problem.Text = ""
            mt_tb_detail.Text = ""
            mt_tb_note.Text = ""
            mt_tb_hrs.Text = ""

            mt_tb_tag.Text = DGV_MA.Rows(e.RowIndex).Cells(0).Value
            mt_tb_mcno.Text = DGV_MA.Rows(e.RowIndex).Cells(1).Value
            mt_tb_date.Text = DGV_MA.Rows(e.RowIndex).Cells(2).Value
            mt_tbfound.Text = DGV_MA.Rows(e.RowIndex).Cells(3).Value
            mt_tb_sign.Text = DGV_MA.Rows(e.RowIndex).Cells(4).Value
            mt_tb_problem.Text = DGV_MA.Rows(e.RowIndex).Cells(5).Value
            mt_tb_detail.Text = DGV_MA.Rows(e.RowIndex).Cells(6).Value

        End If
    End Sub

    Private Sub mt_tb_hrs_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgv_Edit_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Edit.CellMouseClick

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then

            cb_john.Checked = False
            cb_M.Checked = False
            cb_Pond.Checked = False
            cb_It.Checked = False

            mt_rd_complete.Checked = False
            mt_rd_temporary.Checked = False
            mt_rd_suvalence.Checked = False
            mt_tb_tag.Text = ""
            mt_tb_mcno.Text = ""
            mt_tb_date.Text = ""
            mt_tbfound.Text = ""
            mt_tb_sign.Text = ""
            mt_tb_problem.Text = ""
            mt_tb_detail.Text = ""
            mt_tb_note.Text = ""
            mt_tb_hrs.Text = ""

            mt_tb_tag.Text = dgv_Edit.Rows(e.RowIndex).Cells(0).Value
            mt_tb_mcno.Text = dgv_Edit.Rows(e.RowIndex).Cells(1).Value
            mt_tb_date.Text = dgv_Edit.Rows(e.RowIndex).Cells(2).Value
            mt_tbfound.Text = dgv_Edit.Rows(e.RowIndex).Cells(3).Value
            mt_tb_sign.Text = dgv_Edit.Rows(e.RowIndex).Cells(4).Value
            mt_tb_problem.Text = dgv_Edit.Rows(e.RowIndex).Cells(5).Value
            mt_tb_detail.Text = dgv_Edit.Rows(e.RowIndex).Cells(6).Value


            If dgv_Edit.Rows(e.RowIndex).Cells(7).Value = "Complete" Then
                mt_rd_complete.Checked = True
                mt_rd_temporary.Checked = False
                mt_rd_suvalence.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(7).Value = "Temporary Fix" Then
                mt_rd_complete.Checked = False
                mt_rd_temporary.Checked = True
                mt_rd_suvalence.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(7).Value = "Survalence" Then
                mt_rd_complete.Checked = False
                mt_rd_temporary.Checked = False
                mt_rd_suvalence.Checked = True
            End If



            If dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John (Puwadet)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "M (Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John and M (Puwadet/Udomsak)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Pond (Nutthapon)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Pond and M (Nutthapon/Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John and Pond (Puwadet/Nutthapon)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John (Puwadet)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and M (Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and Pond (Nutthapon)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John and M (Puwadet/Udomsak)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John and Pond (Puwadet/Nutthapon)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and Pond and M (Nutthapon/Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Maintenence and IT" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "All Maintenence" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
                '-------**********************************
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John (Puwadet) And Jay (Wiroj)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "M (Udomsak) And Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John and M And Jay (Wiroj)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT And Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Pond And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "Pond and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "John and Pond And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and Pond And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John and M And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and John and Pond And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Edit.Rows(e.RowIndex).Cells(8).Value = "IT and Pond and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            End If

            mt_tb_hrs.Text = dgv_Edit.Rows(e.RowIndex).Cells(9).Value
            mt_tb_note.Text = dgv_Edit.Rows(e.RowIndex).Cells(10).Value

        End If
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        cb_john.Checked = False
        cb_M.Checked = False
        cb_Pond.Checked = False
        cb_It.Checked = False
        mt_rd_complete.Checked = False
        mt_rd_temporary.Checked = False
        mt_rd_suvalence.Checked = False
        mt_tb_tag.Text = ""
        mt_tb_mcno.Text = ""
        mt_tb_date.Text = ""
        mt_tbfound.Text = ""
        mt_tb_sign.Text = ""
        mt_tb_problem.Text = ""
        mt_tb_detail.Text = ""
        mt_tb_note.Text = ""
        mt_tb_hrs.Text = ""
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim dt_username As DataTable
        Dim u_status As Integer
        Dim u_id As Integer
        Dim u_name As String
        dt_username = BLL.GetUsername_ChangePassword(tb_id.Text)
        For i As Integer = 0 To dt_username.Rows.Count - 1
            u_id = dt_username.Rows(0)("user_id").ToString
            u_status = dt_username.Rows(0)("user_status").ToString
            u_name = dt_username.Rows(0)("user_name").ToString
        Next
        frmChangePass._strUser = u_id.ToString
        frmChangePass.Show()
    End Sub

    Private Sub dgv_Complete_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv_Complete.CellMouseClick

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 Then
            cb_john.Checked = False
            cb_M.Checked = False
            cb_Pond.Checked = False
            cb_It.Checked = False
            mt_rd_complete.Checked = False
            mt_rd_temporary.Checked = False
            mt_rd_suvalence.Checked = False
            mt_tb_tag.Text = ""
            mt_tb_mcno.Text = ""
            mt_tb_date.Text = ""
            mt_tbfound.Text = ""
            mt_tb_sign.Text = ""
            mt_tb_problem.Text = ""
            mt_tb_detail.Text = ""
            mt_tb_note.Text = ""
            mt_tb_hrs.Text = ""

            mt_tb_tag.Text = dgv_Complete.Rows(e.RowIndex).Cells(0).Value
            mt_tb_mcno.Text = dgv_Complete.Rows(e.RowIndex).Cells(1).Value
            mt_tb_date.Text = dgv_Complete.Rows(e.RowIndex).Cells(2).Value
            mt_tbfound.Text = dgv_Complete.Rows(e.RowIndex).Cells(3).Value
            mt_tb_sign.Text = dgv_Complete.Rows(e.RowIndex).Cells(4).Value
            mt_tb_problem.Text = dgv_Complete.Rows(e.RowIndex).Cells(5).Value
            mt_tb_detail.Text = dgv_Complete.Rows(e.RowIndex).Cells(6).Value


            If dgv_Complete.Rows(e.RowIndex).Cells(7).Value = "Complete" Then
                mt_rd_complete.Checked = True
                mt_rd_temporary.Checked = False
                mt_rd_suvalence.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(7).Value = "Temporary Fix" Then
                mt_rd_complete.Checked = False
                mt_rd_temporary.Checked = True
                mt_rd_suvalence.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(7).Value = "Survalence" Then
                mt_rd_complete.Checked = False
                mt_rd_temporary.Checked = False
                mt_rd_suvalence.Checked = True
            End If



            If dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John (Puwadet)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "M (Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John and M (Puwadet/Udomsak)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Pond (Nutthapon)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Pond and M (Nutthapon/Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John and Pond (Puwadet/Nutthapon)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John (Puwadet)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and M (Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and Pond (Nutthapon)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John and M (Puwadet/Udomsak)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John and Pond (Puwadet/Nutthapon)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and Pond and M (Nutthapon/Udomsak)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = False
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Maintenence and IT" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "All Maintenence" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
                '-------**********************************
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John (Puwadet) And Jay (Wiroj)" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "M (Udomsak) And Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John and M And Jay (Wiroj)" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT And Jay (Wiroj)" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Pond And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "Pond and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "John and Pond And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = False
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and Pond And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John and M And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = True
                cb_Pond.Checked = False
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and John and Pond And Jay" Then
                cb_john.Checked = True
                cb_M.Checked = False
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            ElseIf dgv_Complete.Rows(e.RowIndex).Cells(8).Value = "IT and Pond and M And Jay" Then
                cb_john.Checked = False
                cb_M.Checked = True
                cb_Pond.Checked = True
                cb_It.Checked = True
                cbJay.Checked = True
            End If

            mt_tb_hrs.Text = dgv_Complete.Rows(e.RowIndex).Cells(9).Value
            mt_tb_note.Text = dgv_Complete.Rows(e.RowIndex).Cells(10).Value

        End If
    End Sub

    Public Sub DGV_Complete_SEL()
        dgv_Complete.DataSource = BLL.GetDataFixed()
    End Sub

#End Region
#Region "Lock and Unlock"


    Private Sub btnRefesh_Click(sender As Object, e As EventArgs) Handles btnRefesh.Click
        Dim sAdd1 As String = " OR ( [mc_lock] = 1 AND [mc_lock_by] = '" & _strUser & "')"

        DGV_SEL(sAdd1)
        DGV_Edit_SEL(sAdd1)
        DGV_Complete_SEL()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        BLL.UnlockData(Trim(strUser))
        BLL.UnlockLogin(Trim(strUser))
        Application.Exit()
    End Sub

    Private Sub mt_tb_mcno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mt_tb_mcno.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub mt_tbfound_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mt_tbfound.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "acdekmnoprstuvwy"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub


    Public Sub GetMC()
        Dim TagNO As Integer = Nothing
        Dim dt_Name As DataTable
        Dim col As New AutoCompleteStringCollection
        dt_Name = BLL.GetDataachine()
        For i As Integer = 0 To dt_Name.Rows.Count - 1
            col.Add(dt_Name.Rows(i)("mc_no").ToString())
        Next

        mt_tb_mcno.AutoCompleteSource = AutoCompleteSource.CustomSource
        mt_tb_mcno.AutoCompleteCustomSource = col
        mt_tb_mcno.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub
#End Region
End Class