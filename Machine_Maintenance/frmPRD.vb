Imports BLL_Controller
Imports System.Globalization
Imports System.IO

Imports System.Net
Imports System.ComponentModel
Imports System.Text
Imports System.Threading
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmPRD
    Dim BLL As BLL_Load = New BLL_Load
    Dim _t As Threading.Thread
    Dim StatusRun As Boolean

#Region "Global All"
    Public Function SendLinePRD(ByVal tb_found As String, ByVal tb_tag As String, ByVal tb_code As String, ByVal tb_detail As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            System.Net.ServicePointManager.Expect100Continue = False
            Dim request = DirectCast(WebRequest.Create(“https://notify-api.line.me/api/notify”), HttpWebRequest)
            Dim postData = String.Format(“message={0}”, "New case Maintenance Request FORM " & vbCrLf & " Serial No. : " & tb_tag & vbCrLf & "Request by :" & tb_found & vbCrLf & "Machine No. : " & tb_code & vbCrLf & "Description : " & tb_detail & " ")
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

    Private Sub frmPRD_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dt As Date = DateTime.UtcNow
        tb_date.Text = Now()
        GetName()
        GetMC()

        _t = New Threading.Thread(AddressOf Run)
        _t.IsBackground = True
        _t.Start()

    End Sub

    Private Function GetIPAddress()
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function

    Public Function GetSEQ() As Integer
        Dim TagNO As Integer = Nothing
        Dim dt_TAG As DataTable
        dt_TAG = BLL.GetTag()
        If dt_TAG.Rows.Count > 0 Then
            For i As Integer = 0 To dt_TAG.Rows.Count - 1
                TagNO = Integer.Parse(dt_TAG.Rows(0)("mc_tag_no").ToString) + 1
            Next
        Else
            TagNO = "000001"
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
                    btnStatus.BackColor = Color.White
                Else
                    btnStatus.BackColor = Color.Red
                End If

                Threading.Thread.Sleep(1000)
                btnStatus.BackColor = Color.White
            Catch ex As Exception

            End Try

        End While
    End Sub

#End Region


#Region "For Production"
    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click

        If tb_code.Text <> "" And tb_found.Text <> "" And tb_detail.Text <> "" Then
            If MsgBox("ยืนยันข้อมูล ?  Confirm data ?", MsgBoxStyle.YesNo, "ยืนยันข้อมูล Confirm data") = MsgBoxResult.Yes Then
                '*****************************************************'
                Dim Sign_type As Integer = 0
                If rb_urgent.Checked = True Then
                    Sign_type = 1
                ElseIf rb_important.Checked = True Then
                    Sign_type = 2
                ElseIf rb_general.Checked = True Then
                    Sign_type = 3
                Else
                    Sign_type = 0
                End If

                '*****************************************************'
                'Dim Case_type As Integer = 0
                'If rb_safety.Checked = True Then
                '    Case_type = 1
                'ElseIf rd_mantain.Checked = True Then
                '    Case_type = 2
                'ElseIf rd_linestop.Checked = True Then
                '    Case_type = 3
                'ElseIf rd_elec.Checked = True Then
                '    Case_type = 4
                'ElseIf rd_other.Checked = True Then
                '    Case_type = 5
                'Else
                '    Case_type = 0
                'End If

                Dim cheq As New System.Text.StringBuilder
                For Each item In clbType.CheckedItems
                    cheq.Append(item)
                    cheq.Append(", ")
                Next
                Dim strCheq As String = cheq.ToString
                Dim R_cheq = strCheq.Substring(0, strCheq.Length - 2)
                '*****************************************************'
                Dim seq_serial = Format(GetSEQ(), "000000")
                '*****************************************************'

                Dim INS As Boolean = BLL.InsCase(tb_code.Text, tb_found.Text, Sign_type, R_cheq.ToString, tb_detail.Text, GetIPAddress(), seq_serial)
                If INS = True Then
                    MsgBox("Send DATA Complete Serial No. is " & seq_serial.ToString, MsgBoxStyle.OkOnly, "Complete")
                    If SendLinePRD(tb_found.Text, seq_serial, tb_code.Text, tb_detail.Text) <> True Then
                        MessageBox.Show("Send DATA to line not Complete please contact IT", “Error”, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                    tb_code.Text = ""
                    tb_found.Text = ""
                    tb_detail.Text = ""
                    tb_tag.Text = ""
                    Sign_type = Nothing
                    cheq = Nothing
                    R_cheq = Nothing

                    rb_urgent.Checked = False
                    rb_important.Checked = False
                    rb_general.Checked = False

                Else

                    MsgBox("Send DATA not Complete please contact IT", MsgBoxStyle.OkOnly, "Not Complete")
                End If

            End If

        Else
            MsgBox("กรุณากรอกข้อมูลให้ครบ", MsgBoxStyle.Critical, "กรอกข้อมูลไม่ครบ!!!")

        End If

    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        frmLogin.Show()
    End Sub



    Private Sub tb_code_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_code.KeyPress

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tb_found_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_found.KeyPress

        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "acdekmnoprstuvwy"
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Public Sub GetName()
        Dim dt_Name As DataTable
        Dim col As New AutoCompleteStringCollection
        dt_Name = BLL.GetNameEmp()
        For i As Integer = 0 To dt_Name.Rows.Count - 1
            col.Add(dt_Name.Rows(i)("NameEnglish").ToString())
        Next


        tb_found.AutoCompleteSource = AutoCompleteSource.CustomSource
        tb_found.AutoCompleteCustomSource = col
        tb_found.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub


    Public Sub GetMC()
        Dim TagNO As Integer = Nothing
        Dim dt_Name As DataTable
        Dim col As New AutoCompleteStringCollection
        dt_Name = BLL.GetDataachine()
        For i As Integer = 0 To dt_Name.Rows.Count - 1
            col.Add(dt_Name.Rows(i)("mc_no").ToString())
        Next

        tb_code.AutoCompleteSource = AutoCompleteSource.CustomSource
        tb_code.AutoCompleteCustomSource = col
        tb_code.AutoCompleteMode = AutoCompleteMode.Suggest
    End Sub


End Class
