Imports BLL_Controller
Imports System.Globalization
Imports System.IO

Imports System.Net
Imports System.ComponentModel
Imports System.Text
Imports System.Threading
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmMNG
    Dim strUser As String
    Dim BLL As BLL_Load = New BLL_Load

    Public Property _strUser() As String
        Get
            Return strUser
        End Get
        Set(ByVal value As String)
            strUser = value
        End Set
    End Property
    Private Sub frmMNG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dt_username As DataTable


        dt_username = BLL.GetUsernameMT(strUser)
        If dt_username.Rows.Count > 0 Then
            Me.lb_name.Text = dt_username.Rows(0)("user_name").ToString
            Me.tb_id.Text = Trim(dt_username.Rows(0)("user_id").ToString)
        End If
        Dim sAdd1 As String = ""
        DGV_SEL(sAdd1)
    End Sub
#Region "Global All"

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
        End If
        Return TagNO
    End Function

#End Region
#Region " All DATA TPM"
    Private Sub DGV_SEL(ByVal _sqlAdd As String)
        DGV.DataSource = BLL.GetDataSel(_sqlAdd)
    End Sub
    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Dim sAdd1 As String = ""
        DGV_SEL(sAdd1)
    End Sub


    Private Sub frmMNG_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        BLL.UnlockLogin(strUser)
        Application.Exit()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim apppath As String = ""
        Dim dialog As New FolderBrowserDialog()
        dialog.RootFolder = Environment.SpecialFolder.Desktop
        'dialog.SelectedPath = "C:\"
        dialog.Description = "Select Application Configeration Files Path"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            apppath = dialog.SelectedPath
        End If

        Dim LoadingScreen = New SplashScreen2()
        LoadingScreen.Show()

        Dim excelLocation As String = apppath.ToString & "\" & DateTime.Now.ToString("yyyy-MM-dd_HHmm") & ".xlsx"
        Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
        If xlApp Is Nothing Then

            LoadingScreen.Close()
            MessageBox.Show("Excel is not Install.")
            Return
        End If

        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")
        'Header Names
        Dim columnsCount As Integer = DGV.Columns.Count
        For Each column In DGV.Columns
            xlWorkSheet.Cells(1, column.Index + 1).Value = column.Name
        Next
        'Data
        For i As Integer = 0 To DGV.Rows.Count - 1
            Dim columnIndex As Integer = 0
            Do Until columnIndex = columnsCount
                xlWorkSheet.Cells(i + 2, columnIndex + 1).Value = DGV.Item(columnIndex, i).Value
                columnIndex += 1
            Loop
        Next

        xlWorkBook.SaveAs(excelLocation)
        xlWorkBook.Close()
        xlApp.Quit()

        LoadingScreen.Close()
        MessageBox.Show("Export to Excel Complete")
        System.Diagnostics.Process.Start(excelLocation)
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



    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        BLL.UnlockLogin(strUser)
        Application.Exit()
    End Sub

#End Region

End Class