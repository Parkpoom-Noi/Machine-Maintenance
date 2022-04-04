Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.ComponentModel
Imports System.Text
Imports DB
Public Class BLL_Load
    Dim dbART As DB_ART = New DB_ART

#Region "Login"

    Public Function GetUsername(ByVal tb_username As String, ByVal tb_password As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("SELECT [user_id] ,[user_name]  ,[user_password] ,[user_status] ,[user_online] FROM  [ART_INTRA].[dbo].[mt_account] WHERE UPPER( [user_name]) = UPPER('" & tb_username & "') AND [user_password] = '" & tb_password & "'")
        Return dtTable
    End Function
    Public Function GetUsernameForChange(ByVal tb_username As String, ByVal tb_password As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("SELECT [user_id] ,[user_name]  ,[user_password] ,[user_status] FROM  [ART_INTRA].[dbo].[mt_account] WHERE UPPER( [user_name]) = UPPER('" & tb_username & "') AND [user_password] = '" & tb_password & "'")

        Return dtTable
    End Function

    Public Function ChangePassword(ByVal tbNewpass As String, ByVal tb_id As String) As Boolean
        If dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mt_account]
                                                 SET  [user_password] = '" & tbNewpass & "' 
                                                 WHERE  [user_id] = '" & tb_id & "'
                                               ") Then

            Return True
        Else
            Return False
        End If

    End Function

    Public Function LockLogin(ByVal uID As Integer) As Boolean
        If dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mt_account]
                                                   SET  [user_online] = 1
                                                 WHERE  user_id =  " & uID & "
                                               ") Then

            Return True
        Else
            Return False
        End If
    End Function


    Public Function GetUsername_ChangePassword(ByVal tb_id As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("SELECT [user_id] ,[user_name]  ,[user_password] ,[user_status] FROM  [ART_INTRA].[dbo].[mt_account] WHERE UPPER( [user_id]) = " & tb_id & " ")

        Return dtTable
    End Function


    Public Sub LockDataNew(ByVal strUser As String)
        Dim INS As Boolean = dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mc_maintenance]
                                                 SET  [mc_lock] = 1
                                                      ,[mc_lock_by] = '" & Trim(strUser) & "'
                                                      
                                                 WHERE  (mc_status_fix = 0 and mc_tag_no <> 0) AND ([mc_lock] <> 1)
                                               ")
    End Sub
    Public Sub LockDataOld(ByVal strUser As String)
        Dim INS As Boolean = dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mc_maintenance]
                                                 SET  [mc_lock] = 1
                                                      ,[mc_lock_by] = '" & Trim(strUser) & "'
                                                      
                                                 WHERE  (mc_status_fix <> 0  and mc_status_fix <> 1 and mc_tag_no <> 0)  AND ([mc_lock] <> 1)
                                               ")
    End Sub

    Public Sub UnlockData(ByVal strUser As String)
        Dim INS As Boolean = dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mc_maintenance]
                                                 SET  [mc_lock] = 0
                                                      ,[mc_lock_by] = ''
                                                      
                                                 WHERE [mc_lock] = 1 and [mc_lock_by] = '" & Trim(strUser) & "'
                                               ")
    End Sub

    Public Sub UnlockLogin(ByVal strUser As String)

        Dim INS As Boolean = dbART.ExecuteSQL("
                                                 UPDATE [dbo].[mt_account]
                                                   SET  [user_online] = 0
                                                 WHERE  user_id =  " & Trim(strUser) & "
                                               ")
    End Sub

#End Region

#Region "MT"
    Public Function GetUsernameMT(ByVal strUser As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("SELECT [user_id] ,[user_name]  ,[user_password] ,[user_status] FROM  [ART_INTRA].[dbo].[mt_account] WHERE [user_id] = '" & strUser & "'")
        Return dtTable
    End Function


    Public Function GetTag() As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("SELECT TOP 1 [mc_id] ,[mc_tag_no]  FROM [ART_INTRA].[dbo].[mc_maintenance] Where mc_tag_no is not null and mc_tag_no <>  ''  ORDER BY mc_id DESC")
        Return dtTable
    End Function

    Public Function GetDataSel(ByVal _sqlAdd As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                            SELECT [mc_tag_no] as 'Form Serial No.'
                                                  ,[mc_code] as 'Machine Code'
                                                  ,[mc_date_found] as 'Date Request'
                                                  ,[mc_found_by] as 'Request by'
                                                  ,CASE
                                                          WHEN mc_sign_type = 1 THEN 'Urgent เรื่องด่วน'
                                                          WHEN mc_sign_type = 2 THEN 'Important เรื่องสำคัญ'
                                                          ELSE 'General เรื่องทั่วไป'
                                                     END as 'Signification'
                                                  , [mc_type_txt] as 'Case type'
                                                  ,[mc_detail] as 'Description' 
                                              FROM [ART_INTRA].[dbo].[mc_maintenance] 
                                              WHERE mc_status_fix = 0 and mc_tag_no <> 0
                                              AND (( [mc_lock] = 0 AND [mc_lock_by] = '') OR ( [mc_lock] Is Null  AND [mc_lock_by] Is Null) " & _sqlAdd & ")
                                              ORDER BY mc_id DESC
                                          ")
        Return dtTable
    End Function


    Public Function GetDataEdit(ByVal _strUser As String) As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                            SELECT [mc_tag_no] as 'Form Serial No.'
                                                  ,[mc_code] as 'Machine Code'
                                                  ,[mc_date_found] as 'Date Request'
                                                  ,[mc_found_by] as 'Request by'
                                                  ,CASE
                                                          WHEN mc_sign_type = 1 THEN 'Urgent เรื่องด่วน'
                                                          WHEN mc_sign_type = 2 THEN 'Important เรื่องสำคัญ'
                                                          ELSE 'General เรื่องทั่วไป'
                                                     END as 'Signification'
                                                  , [mc_type_txt] as 'Case type'
                                                  ,[mc_detail] as 'Description'  
                                                  , CASE
                                                          WHEN mc_status_fix = 1 THEN 'Complete'
                                                          WHEN mc_status_fix = 2 THEN 'Temporary Fix'
                                                          WHEN mc_status_fix = 3 THEN 'Survalence'
                                                          ELSE '-'
                                                     END as 'Status Repair' 
                                                  ,
                                                     CASE
                                                          WHEN mc_fix_by = 1 THEN 'John (Puwadet)'
                                                          WHEN mc_fix_by = 2 THEN 'M (Udomsak)'
                                                          WHEN mc_fix_by = 3 THEN 'John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 4 THEN 'IT'
                                                          WHEN mc_fix_by = 5 THEN 'Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 6 THEN 'Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 7 THEN 'John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 8 THEN 'IT and John (Puwadet)'
                                                          WHEN mc_fix_by = 9 THEN 'IT and M (Udomsak)'
                                                          WHEN mc_fix_by = 10 THEN 'IT and Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 11 THEN 'IT and John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 12 THEN 'IT and John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 13 THEN 'IT and Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 14 THEN 'Maintenence and IT'
                                                          WHEN mc_fix_by = 15 THEN 'All Maintenence'
                                                          WHEN mc_fix_by = 16 THEN 'Jay (Wiroj)'
                                                          WHEN mc_fix_by = 17 THEN 'John (Puwadet) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 18 THEN 'M (Udomsak) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 19 THEN 'John and M And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 20 THEN 'IT And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 21 THEN 'Pond And Jay'
                                                          WHEN mc_fix_by = 22 THEN 'Pond and M And Jay'
                                                          WHEN mc_fix_by = 23 THEN 'John and Pond And Jay'
                                                          WHEN mc_fix_by = 24 THEN 'IT and John And Jay'
                                                          WHEN mc_fix_by = 25 THEN 'IT and M And Jay'
                                                          WHEN mc_fix_by = 26 THEN 'IT and Pond And Jay'
                                                          WHEN mc_fix_by = 27 THEN 'IT and John and M And Jay'
                                                          WHEN mc_fix_by = 28 THEN 'IT and John and Pond And Jay'
                                                          WHEN mc_fix_by = 29 THEN 'IT and Pond and M And Jay' 
                                                          ELSE '-'
                                                     END as 'Repair By' 
                                                  ,SUBSTRING( convert(varchar, [mc_time_fix],108),1,5)  as 'Total time Repair' 
                                                  ,[mc_note] as 'Maintenance Description' 
                                              FROM [ART_INTRA].[dbo].[mc_maintenance] 
                                              WHERE (mc_status_fix = 2 OR  mc_status_fix = 3 ) and mc_tag_no <> 0
                                              AND (( [mc_lock] = 0 AND [mc_lock_by] = '') OR ( [mc_lock] Is Null  AND [mc_lock_by] Is Null) OR ( [mc_lock] = 1 AND [mc_lock_by] = '" & _strUser & "') )

                                              ORDER BY mc_id DESC
                                          ")
        Return dtTable
    End Function


    Public Function GetDataFixed() As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                            SELECT [mc_tag_no] as 'Form Serial No.'
                                                  ,[mc_code] as 'Machine Code'
                                                  ,[mc_date_found] as 'Date Request'
                                                  ,[mc_found_by] as 'Request by'
                                                  ,CASE
                                                          WHEN mc_sign_type = 1 THEN 'Urgent เรื่องด่วน'
                                                          WHEN mc_sign_type = 2 THEN 'Important เรื่องสำคัญ'
                                                          ELSE 'General เรื่องทั่วไป'
                                                     END as 'Signification'
                                                  , [mc_type_txt] as 'Case type'
                                                  ,[mc_detail] as 'Description'  
                                                  , CASE
                                                          WHEN mc_status_fix = 1 THEN 'Complete'
                                                          WHEN mc_status_fix = 2 THEN 'Temporary Fix'
                                                          WHEN mc_status_fix = 3 THEN 'Survalence'
                                                          ELSE '-'
                                                     END as 'Status Repair' 
                                                  ,CASE
                                                          WHEN mc_fix_by = 1 THEN 'John (Puwadet)'
                                                          WHEN mc_fix_by = 2 THEN 'M (Udomsak)'
                                                          WHEN mc_fix_by = 3 THEN 'John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 4 THEN 'IT'
                                                          WHEN mc_fix_by = 5 THEN 'Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 6 THEN 'Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 7 THEN 'John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 8 THEN 'IT and John (Puwadet)'
                                                          WHEN mc_fix_by = 9 THEN 'IT and M (Udomsak)'
                                                          WHEN mc_fix_by = 10 THEN 'IT and Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 11 THEN 'IT and John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 12 THEN 'IT and John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 13 THEN 'IT and Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 14 THEN 'Maintenence and IT'
                                                          WHEN mc_fix_by = 15 THEN 'All Maintenence'
                                                          WHEN mc_fix_by = 16 THEN 'Jay (Wiroj)'
                                                          WHEN mc_fix_by = 17 THEN 'John (Puwadet) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 18 THEN 'M (Udomsak) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 19 THEN 'John and M And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 20 THEN 'IT And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 21 THEN 'Pond And Jay'
                                                          WHEN mc_fix_by = 22 THEN 'Pond and M And Jay'
                                                          WHEN mc_fix_by = 23 THEN 'John and Pond And Jay'
                                                          WHEN mc_fix_by = 24 THEN 'IT and John And Jay'
                                                          WHEN mc_fix_by = 25 THEN 'IT and M And Jay'
                                                          WHEN mc_fix_by = 26 THEN 'IT and Pond And Jay'
                                                          WHEN mc_fix_by = 27 THEN 'IT and John and M And Jay'
                                                          WHEN mc_fix_by = 28 THEN 'IT and John and Pond And Jay'
                                                          WHEN mc_fix_by = 29 THEN 'IT and Pond and M And Jay' 
                                                          ELSE '-'
                                                     END as 'Repair By' 
                                                  ,SUBSTRING( convert(varchar, [mc_time_fix_txt],108),1,5)  as 'Total time Repair' 
                                                  ,[mc_note] as 'Maintenance Description' 
                                              FROM [ART_INTRA].[dbo].[mc_maintenance] 
                                              WHERE  mc_status_fix = 1 and mc_tag_no <> 0  and (convert(varchar(10), mc_date_fix, 102) = convert(varchar(10), getdate(), 102))
                                              ORDER BY mc_id DESC
                                          ")
        Return dtTable
    End Function

    Public Function GetDataachine() As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                    SELECT [mc_no_id]
                                          ,[mc_no]
                                          ,[mc_area]
                                        FROM [ART_INTRA].[dbo].[mc_no]
                                  ")
        Return dtTable
    End Function

    Public Function InsFix(ByVal mt_tb_note As String, ByVal mt_tb_mcno As String, ByVal fix_type As String, ByVal mt_tb_hrs As String,
                           ByVal who_fix As String, ByVal GetIPAddress As String, ByVal lb_name As String, ByVal mt_tb_tag As String) As Boolean
        If dbART.ExecuteSQL("
                                                 UPDATE [ART_INTRA].[dbo].[mc_maintenance]
                                                 SET  [mc_note] = '" & mt_tb_note & "'
                                                      ,[mc_code] = '" & mt_tb_mcno & "'
                                                      ,[mc_status_fix] = " & fix_type & "
                                                      ,[mc_time_fix_txt] = '" & mt_tb_hrs & "'
                                                      ,[mc_fix_by] = " & who_fix & "
                                                      ,[mc_date_fix] = GETDATE()
                                                      ,[mc_log_ip_mt] = '" & GetIPAddress & "'
                                                      ,[mc_log_name] = '" & lb_name & "'
                                                 WHERE  [mc_tag_no] = '" & mt_tb_tag & "'
                                               ") Then

            Return True
        Else
            Return False
        End If
    End Function


#End Region
#Region "MT Manager"
    Public Function GetTotal() As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                              SELECT [mc_tag_no] as 'FORM SERIAL No.'
                                                  ,[mc_code] as 'Machine Code'
                                                  ,[mc_date_found] as 'Date Request'
                                                  ,[mc_found_by] as 'Request by'
                                                  ,
                                                     CASE
                                                          WHEN mc_sign_type = 1 THEN 'Urgent เรื่องด่วน'
                                                          WHEN mc_sign_type = 2 THEN 'Important เรื่องสำคัญ'
                                                          ELSE 'General เรื่องทั่วไป'
                                                     END as 'Signification'
                                                  ,[mc_type_txt] as 'Case type'
                                                  ,[mc_detail] as 'Description' 
                                                  ,[mc_note] as 'Maintenance notes' 
                                                  ,
                                                     CASE
                                                          WHEN mc_status_fix = 1 THEN 'Complete'
                                                          WHEN mc_status_fix = 2 THEN 'Temporary Fix'
                                                          WHEN mc_status_fix = 3 THEN 'Survalence'
                                                          ELSE '-'
                                                     END as 'Status Repair' 
                                                  ,
                                                     CASE
                                                          WHEN mc_fix_by = 1 THEN 'John (Puwadet)'
                                                          WHEN mc_fix_by = 2 THEN 'M (Udomsak)'
                                                          WHEN mc_fix_by = 3 THEN 'John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 4 THEN 'IT'
                                                          WHEN mc_fix_by = 5 THEN 'Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 6 THEN 'Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 7 THEN 'John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 8 THEN 'IT and John (Puwadet)'
                                                          WHEN mc_fix_by = 9 THEN 'IT and M (Udomsak)'
                                                          WHEN mc_fix_by = 10 THEN 'IT and Pond (Nutthapon)'
                                                          WHEN mc_fix_by = 11 THEN 'IT and John and M (Puwadet/Udomsak)'
                                                          WHEN mc_fix_by = 12 THEN 'IT and John and Pond (Puwadet/Nutthapon)'
                                                          WHEN mc_fix_by = 13 THEN 'IT and Pond and M (Nutthapon/Udomsak)'
                                                          WHEN mc_fix_by = 14 THEN 'Maintenence and IT'
                                                          WHEN mc_fix_by = 15 THEN 'All Maintenence'
                                                          WHEN mc_fix_by = 16 THEN 'Jay (Wiroj)'
                                                          WHEN mc_fix_by = 17 THEN 'John (Puwadet) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 18 THEN 'M (Udomsak) And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 19 THEN 'John and M And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 20 THEN 'IT And Jay (Wiroj)'
                                                          WHEN mc_fix_by = 21 THEN 'Pond And Jay'
                                                          WHEN mc_fix_by = 22 THEN 'Pond and M And Jay'
                                                          WHEN mc_fix_by = 23 THEN 'John and Pond And Jay'
                                                          WHEN mc_fix_by = 24 THEN 'IT and John And Jay'
                                                          WHEN mc_fix_by = 25 THEN 'IT and M And Jay'
                                                          WHEN mc_fix_by = 26 THEN 'IT and Pond And Jay'
                                                          WHEN mc_fix_by = 27 THEN 'IT and John and M And Jay'
                                                          WHEN mc_fix_by = 28 THEN 'IT and John and Pond And Jay'
                                                          WHEN mc_fix_by = 29 THEN 'IT and Pond and M And Jay' 
                                                          ELSE '-'
                                                     END as 'Repair By' 
                                                  ,SUBSTRING( convert(varchar, [mc_time_fix_txt],108),1,5)  as 'Total time Repair' 
                                                  ,[mc_date_fix]  as 'Date Repair'       
												  , CONVERT(VARCHAR, DATEDIFF(dd,  [mc_date_found] , [mc_date_fix])) + ':'
												   + CONVERT(VARCHAR, DATEDIFF(hh, [mc_date_found] , [mc_date_fix]) % 24) + ':'
												   + CONVERT(VARCHAR, DATEDIFF(mi,  [mc_date_found] , [mc_date_fix]) % 60) AS 'Machine down time  (dd:HH:mm)'
												  ,CONVERT(VARCHAR, (  (DATEDIFF(dd,  [mc_date_found] , [mc_date_fix]))
													  -(DATEDIFF(wk,  [mc_date_found] , [mc_date_fix]) * 2) 
													  -(CASE WHEN DATENAME(dw,  [mc_date_found]) = 'Sunday' THEN 1 ELSE 0 END)
													  -(CASE WHEN DATENAME(dw, [mc_date_fix]) = 'Saturday' THEN 1 ELSE 0 END))) + ':' 
												   + CONVERT(VARCHAR, DATEDIFF(hh, [mc_date_found] , [mc_date_fix]) % 24) + ':'
												   + CONVERT(VARCHAR, DATEDIFF(mi,  [mc_date_found] , [mc_date_fix]) % 60) AS 'Actual Working Days downtime (dd:HH:mm)'
                                              FROM [ART_INTRA].[dbo].[mc_maintenance] WHERE mc_tag_no <> 0 ORDER BY mc_tag_no DESC
                                          ")
        Return dtTable
    End Function



#End Region
#Region "PRD_Ins"
    Public Function GetNameEmp() As DataTable
        Dim dtTable As DataTable
        dtTable = dbART.SelectSQL("
                                    SELECT  
                                    convert (Varchar ,a.[FirstNameEng] +  ' ' + a.[LastNameEng] ) As NameEnglish
                                    ,b.[WorkingStatus]
                                    FROM [dbhrmi_air].[dbo].[hrPerEmpDetail] a , [dbhrmi_air].[dbo].[emEmployee] b
                                    Where a.[EmpID] = b.[EmpID] AND b.[WorkingStatus] = 'Working'
                                    order by NameEnglish

                                  ")
        Return dtTable
    End Function
    Public Function InsCase(ByVal tb_code As String, ByVal tb_found As String, ByVal Sign_type As String, ByVal R_cheq As String,
                           ByVal tb_detail As String, ByVal GetIPAddress As String, ByVal seq_serial As String) As Boolean
        If dbART.ExecuteSQL("
                                                INSERT INTO [dbo].[mc_maintenance]
                                                           ([mc_code]
                                                           ,[mc_date_found]
                                                           ,[mc_found_by]
                                                           ,[mc_sign_type]
                                                           ,[mc_type_txt]
                                                           ,[mc_detail]
                                                           ,[mc_log_date] 
                                                           ,[mc_log_ip]  
                                                           ,[mc_tag_no] 
                                                           ,[mc_status_fix])
                                                     VALUES
                                                           ('" & tb_code & "'
                                                           ,GETDATE()
                                                           ,'" & tb_found & "'
                                                           ," & Sign_type & "
                                                           ,'" & R_cheq.ToString & "'
                                                           ,'" & tb_detail & "'
                                                           ,GETDATE()
                                                           ,'" & GetIPAddress & "'
                                                           ,'" & seq_serial & "'
                                                           ,0) 
                                               ") Then

            Return True
        Else
            Return False
        End If
    End Function

#End Region
#Region "Other"


    Public Function WhoFix(ByVal who_fix As String)
        Dim WhoFix_txt As String = ""

        If who_fix.ToString = 1 Then
            WhoFix_txt = "John (Puwadet)"
        ElseIf who_fix.ToString = 2 Then
            WhoFix_txt = "M (Udomsak)"
        ElseIf who_fix.ToString = 3 Then
            WhoFix_txt = "John and M (Puwadet and Udomsak)"
        ElseIf who_fix.ToString = 4 Then
            WhoFix_txt = "IT"
        ElseIf who_fix.ToString = 5 Then
            WhoFix_txt = "Pond (Nutthapon)"
        ElseIf who_fix.ToString = 6 Then
            WhoFix_txt = "Pond and M (Nutthapon/Udomsak)"
        ElseIf who_fix.ToString = 7 Then
            WhoFix_txt = "John and Pond (Puwadet/Nutthapon)"
        ElseIf who_fix.ToString = 8 Then
            WhoFix_txt = "IT and John (Puwadet)"
        ElseIf who_fix.ToString = 9 Then
            WhoFix_txt = "IT and M (Udomsak)"
        ElseIf who_fix.ToString = 10 Then
            WhoFix_txt = "IT and Pond (Nutthapon)"
        ElseIf who_fix.ToString = 11 Then
            WhoFix_txt = "IT and John and M (Puwadet/Udomsak)"
        ElseIf who_fix.ToString = 12 Then
            WhoFix_txt = "IT and John and Pond (Puwadet/Nutthapon)"
        ElseIf who_fix.ToString = 13 Then
            WhoFix_txt = "IT and Pond and M (Nutthapon/Udomsak)"
        ElseIf who_fix.ToString = 14 Then
            WhoFix_txt = "Maintenence and IT"
        ElseIf who_fix.ToString = 15 Then
            WhoFix_txt = "All Maintenence"
            '*****************************************************'
        ElseIf who_fix.ToString = 16 Then
            WhoFix_txt = "Jay (Wiroj)"
        ElseIf who_fix.ToString = 17 Then
            WhoFix_txt = "John (Puwadet) And Jay (Wiroj)"
        ElseIf who_fix.ToString = 18 Then
            WhoFix_txt = "M (Udomsak) And Jay (Wiroj)"
        ElseIf who_fix.ToString = 19 Then
            WhoFix_txt = "John and M And Jay (Wiroj)"
        ElseIf who_fix.ToString = 20 Then
            WhoFix_txt = "IT And Jay (Wiroj)"
        ElseIf who_fix.ToString = 21 Then
            WhoFix_txt = "Pond And Jay"
        ElseIf who_fix.ToString = 22 Then
            WhoFix_txt = "Pond and M And Jay"
        ElseIf who_fix.ToString = 23 Then
            WhoFix_txt = "John and Pond And Jay"
        ElseIf who_fix.ToString = 24 Then
            WhoFix_txt = "IT and John And Jay"
        ElseIf who_fix.ToString = 25 Then
            WhoFix_txt = "IT and M And Jay"
        ElseIf who_fix.ToString = 26 Then
            WhoFix_txt = "IT and Pond And Jay"
        ElseIf who_fix.ToString = 27 Then
            WhoFix_txt = "IT and John and M And Jay"
        ElseIf who_fix.ToString = 28 Then
            WhoFix_txt = "IT and John and Pond And Jay"
        ElseIf who_fix.ToString = 29 Then
            WhoFix_txt = "IT and Pond and M And Jay"
        End If

        Return WhoFix_txt
    End Function


    Public Function WhoFixINT(ByVal cb_john As Boolean, ByVal cb_M As Boolean, ByVal cb_Pond As Boolean, ByVal cb_It As Boolean, ByVal cbJay As Boolean)

        Dim who_fix As Integer = 0
        If (cb_john = True And cb_M = False And cb_Pond = False And cb_It = False And cbJay = False) Then
            who_fix = 1
        ElseIf (cb_john = False And cb_M = True And cb_Pond = False And cb_It = False And cbJay = False) Then
            who_fix = 2
        ElseIf (cb_john = True And cb_M = True And cb_Pond = False And cb_It = False And cbJay = False) Then
            who_fix = 3
        ElseIf (cb_john = False And cb_M = False And cb_Pond = False And cb_It = True And cbJay = False) Then
            who_fix = 4
        ElseIf (cb_john = False And cb_M = False And cb_Pond = True And cb_It = False And cbJay = False) Then
            who_fix = 5
        ElseIf (cb_john = False And cb_M = True And cb_Pond = True And cb_It = False And cbJay = False) Then
            who_fix = 6
        ElseIf (cb_john = True And cb_M = False And cb_Pond = True And cb_It = False And cbJay = False) Then
            who_fix = 7
        ElseIf (cb_john = True And cb_M = False And cb_Pond = False And cb_It = True And cbJay = False) Then
            who_fix = 8
        ElseIf (cb_john = False And cb_M = True And cb_Pond = False And cb_It = True And cbJay = False) Then
            who_fix = 9
        ElseIf (cb_john = False And cb_M = False And cb_Pond = True And cb_It = True And cbJay = False) Then
            who_fix = 10
        ElseIf (cb_john = True And cb_M = True And cb_Pond = False And cb_It = True And cbJay = False) Then
            who_fix = 11
        ElseIf (cb_john = True And cb_M = False And cb_Pond = True And cb_It = True And cbJay = False) Then
            who_fix = 12
        ElseIf (cb_john = False And cb_M = True And cb_Pond = True And cb_It = True And cbJay = False) Then
            who_fix = 13
        ElseIf (cb_john = True And cb_M = True And cb_Pond = True And cb_It = True And cbJay = True) Then
            who_fix = 14
        ElseIf (cb_john = True And cb_M = True And cb_Pond = True And cb_It = False And cbJay = True) Then
            who_fix = 15
            '************************************ Add P Jay

        ElseIf (cb_john = False And cb_M = False And cb_Pond = False And cb_It = False And cbJay = True) Then
            who_fix = 16
        ElseIf (cb_john = True And cb_M = False And cb_Pond = False And cb_It = False And cbJay = True) Then
            who_fix = 17
        ElseIf (cb_john = False And cb_M = True And cb_Pond = False And cb_It = False And cbJay = True) Then
            who_fix = 18
        ElseIf (cb_john = True And cb_M = True And cb_Pond = False And cb_It = False And cbJay = True) Then
            who_fix = 19
        ElseIf (cb_john = False And cb_M = False And cb_Pond = False And cb_It = True And cbJay = True) Then
            who_fix = 20
        ElseIf (cb_john = False And cb_M = False And cb_Pond = True And cb_It = False And cbJay = True) Then
            who_fix = 21
        ElseIf (cb_john = False And cb_M = True And cb_Pond = True And cb_It = False And cbJay = True) Then
            who_fix = 22
        ElseIf (cb_john = True And cb_M = False And cb_Pond = True And cb_It = False And cbJay = True) Then
            who_fix = 23
        ElseIf (cb_john = True And cb_M = False And cb_Pond = False And cb_It = True And cbJay = True) Then
            who_fix = 24
        ElseIf (cb_john = False And cb_M = True And cb_Pond = False And cb_It = True And cbJay = True) Then
            who_fix = 25
        ElseIf (cb_john = False And cb_M = False And cb_Pond = True And cb_It = True And cbJay = True) Then
            who_fix = 26
        ElseIf (cb_john = True And cb_M = True And cb_Pond = False And cb_It = True And cbJay = True) Then
            who_fix = 27
        ElseIf (cb_john = True And cb_M = False And cb_Pond = True And cb_It = True And cbJay = True) Then
            who_fix = 28
        ElseIf (cb_john = False And cb_M = True And cb_Pond = True And cb_It = True And cbJay = True) Then
            who_fix = 29
        Else
            who_fix = 0
        End If


        Return who_fix

    End Function

    Public Function GetIPAddress()
        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()
        Return strIPAddress
    End Function


#End Region

End Class
