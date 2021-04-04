Imports System
Imports System.Text
Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class frm_home
    Dim con_cls As New class_connectionString
    Dim trans_querry As New class_transactionTasks
    Dim filename As String
    Dim backUpPath As String
    Public dateFrom, dateTo, preRestoreDate As Date
    Dim dr As SqlDataReader
    Public username, dbRestoreUser, dbRestorePath, password As String

    '===============================================================
    '                FORM EVENT(S) HANDLING
    '===============================================================

    Private Sub frm_home_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call con_cls.softwareValidity(Me)
        Call dbExistCheck()
        Call failsafe()
        Call scheduledBackup()
        Call checkDbRestore()
        Try
            Dim form As New frm_login
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    '================================================================
    '              MAIN MENU ITEM(S) CLICK EVENT HANDLING
    '================================================================

    Private Sub TSMI_KVKCB_CD_CDU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_KVKCB_CD_CDU.Click
        Try
            Dim form As New frm_KVKCB_CD_CDU
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_KVKCB_CD_CDE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_KVKCB_CD_CDE.Click
        Try
            Dim form As New frm_KVKCB_CD_CDE
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_KVKCB_CD_CDD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_KVKCB_CD_CDD.Click
        Try
            Dim form As New frm_KVKCB_CD_CDD
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_KVKCB_STAT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_KVKCB_STAT.Click
        Try
            Dim form As New frm_accStatement
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_CS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CS.Click
        Try
            Dim form As New frm_currentStatus
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_TRANS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_TRANS.Click
        Try
            Dim form As New frm_transactions
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_ST_DB_BDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ST_DB_BDB.Click
        ' DATABASE BACKUP
        '======================================================================================================================================
        FBD_dbBackUp.ShowDialog()
        If Not FBD_dbBackUp.SelectedPath = "" Then
            Try
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook.mdf", FBD_dbBackUp.SelectedPath & "\KVKDhalai_CashBook.mdf", True)
                My.Computer.FileSystem.CopyFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook_log.ldf", FBD_dbBackUp.SelectedPath & "\KVKDhalai_CashBook_log.ldf", True)
                trans_querry.update_trans_database(username, "Backup Database", "Successful (Path: " & FBD_dbBackUp.SelectedPath & ")")
                MsgBox("Backup Successful", MsgBoxStyle.OkOnly, "Backup Information")
            Catch ex As Exception
                trans_querry.update_trans_database(username, "Backup Database", "Unsuccessful (Path: " & FBD_dbBackUp.SelectedPath & ")")
                MsgBox("Backup unsuccessful", MsgBoxStyle.OkOnly, "Backup Information")
            End Try
        Else
            MsgBox("No path selected.", MsgBoxStyle.OkOnly, "Backup information")
        End If
    End Sub

    Private Sub TSMI_ST_DB_RDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ST_DB_RDB.Click
        ' DATABASE RESTORE
        '======================================================================================================================================
        MsgBox("Please save all unsaved information before continuing", MsgBoxStyle.OkOnly, "Database Restore Information")
        If MessageBox.Show("Do u want to continue with database restore now?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim file1, file2, filePath As String

            '   Database File KVKDhalai_CashBook.mdf Restore
            MsgBox("Select KVKDhalai_CashBook.mdf file.", MsgBoxStyle.OkOnly, "Database restore information")
            file1 = ""
            OFD_db.ShowDialog()
            filePath = OFD_db.FileName
            filename = My.Computer.FileSystem.GetName(OFD_db.FileName)
            If filename = "KVKDhalai_CashBook.mdf" Then
                Try
                    If Not My.Computer.FileSystem.DirectoryExists("D:\BACKUP\KVKCASH\DBRESTORE") Then
                        My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE")
                        My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy"))
                        My.Computer.FileSystem.CopyFile(OFD_db.FileName, "D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook.mdf", True)
                        file1 = "COPIED"
                    Else
                        If Not My.Computer.FileSystem.DirectoryExists("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy")) Then
                            My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy"))
                        End If
                        My.Computer.FileSystem.CopyFile(OFD_db.FileName, "D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook.mdf", True)
                        file1 = "COPIED"
                    End If
                Catch ex As Exception
                    Try
                        trans_querry.update_trans_database(username, "Restore Database", "Unsuccessful")
                        MsgBox("Database File KVKDhalai_CashBook.mdf Restore unsuccessful", MsgBoxStyle.OkOnly, "Database restore information")
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
                    Catch ex2 As Exception
                        MsgBox(ex2.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
                    End Try
                End Try
            Else
                MsgBox("Software database not found. Please browse correct database file.", MsgBoxStyle.OkOnly, "Database restore information")
                Exit Sub
            End If

            '   Database File KVKDhalai_CashBook_log.LDF Restore
            MsgBox("Select KVKDhalai_CashBook_log.ldf file.", MsgBoxStyle.OkOnly, "Database restore information")
            file2 = ""
            OFD_db.ShowDialog()
            filename = My.Computer.FileSystem.GetName(OFD_db.FileName)
            If filename = "KVKDhalai_CashBook_log.ldf" Then
                Try
                    If Not My.Computer.FileSystem.DirectoryExists("D:\BACKUP\KVKCASH\DBRESTORE") Then
                        My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE")
                        My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy"))
                        My.Computer.FileSystem.CopyFile(OFD_db.FileName, "D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook_log.ldf", True)
                        file2 = "COPIED"
                    Else
                        If Not My.Computer.FileSystem.DirectoryExists("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy")) Then
                            My.Computer.FileSystem.CreateDirectory("D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy"))
                        End If
                        My.Computer.FileSystem.CopyFile(OFD_db.FileName, "D:\BACKUP\KVKCASH\DBRESTORE\" & Date.Today.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook_log.ldf", True)
                        file2 = "COPIED"
                    End If
                Catch ex As Exception
                    Try
                        trans_querry.update_trans_database(username, "Restore Database", "Unsuccessful")
                        MsgBox("Database File KVKDhalai_CashBook_log.ldf Restore unsuccessful", MsgBoxStyle.OkOnly, "Database restore information")
                        MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
                    Catch ex2 As Exception
                        MsgBox(ex2.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
                    End Try
                End Try
            Else
                MsgBox("Software database not found. Please browse correct database file.", MsgBoxStyle.OkOnly, "Database restore information")
                Exit Sub
            End If

            '    Saving database restore successful information on database 
            If file1 = "COPIED" And file2 = "COPIED" Then
                Try
                    trans_querry.update_trans_database(username, filePath, "Partially Successful")
                    MsgBox("Please restart application IMMEDIATELY to continue.", MsgBoxStyle.OkOnly, "Database restore information")
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
                End Try
            End If
        End If

    End Sub

    Private Sub TSMI_ABT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_ABT.Click
        Try
            Dim form As New frm_about
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Open Child")
        End Try
    End Sub

    Private Sub TSMI_LO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_LO.Click
        Me.Enabled = False
        frm_login.Show()
    End Sub

    Private Sub TSMI_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_EXIT.Click
        If MessageBox.Show("Do u want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub


    '================================================================
    '          CONTEXT MENU ITEM(S) CLICK EVENT HANDLING
    '================================================================

    Private Sub TSMI_CAL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_CAL.Click
        Try
            System.Diagnostics.Process.Start("calc")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Information")
        End Try
    End Sub

    Private Sub TSMI_NOTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_NOTE.Click
        Try
            System.Diagnostics.Process.Start("notepad")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Information")
        End Try
    End Sub

    Private Sub TSMI_LOGOUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSMI_LOGOUT.Click
        Me.Enabled = False
        frm_login.Show()
    End Sub


    '================================================================
    '                  FORM ITEM(S) EVENT HANDLING
    '================================================================

    Private Sub Timer_Home_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_Home.Tick
        TSSL_homeClock.Text = My.Computer.Clock.LocalTime.ToString
    End Sub


    '=================================================================
    '                   USER DEFINED FUNCTIONS
    '=================================================================
    Public Sub dbExistCheck()

        ' DATABASE EXIST CHECK
        '======================================================================================================================================
        If Not My.Computer.FileSystem.FileExists(Application.StartupPath & "\DataItems\KVKDhalai_CashBook.mdf") Then
            MsgBox("Software database not found. Please browse database file.", MsgBoxStyle.OkOnly, "Database information")
            OFD_db.ShowDialog()
            filename = My.Computer.FileSystem.GetName(OFD_db.FileName)
            If filename = "KVKDhalai_CashBook.mdf" Then
                Try
                    My.Computer.FileSystem.CopyFile(OFD_db.FileName, Application.StartupPath & "\DataItems\" & filename, True)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Database information")
                End Try
            Else
                Call dbExistCheck()
            End If
        End If
        '======================================================================================================================================
    End Sub

    Public Sub failsafe()

        '  FAILSAFE DATABASE BACKUP TILL LAST USE
        '======================================================================================================================================
        Try
            con_cls.disconnect()
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Failsafe\KVKDhalai_CashBook.mdf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Failsafe\KVKDhalai_CashBook_log.ldf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            MsgBox("Failsafe process (delete) unsuccessful", MsgBoxStyle.OkOnly, "Failsafe information")
        End Try
        Try
            con_cls.disconnect()
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\DataItems\KVKDhalai_CashBook.mdf", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Failsafe\KVKDhalai_CashBook.mdf", True)
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\DataItems\KVKDhalai_CashBook_log.ldf", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\Failsafe\KVKDhalai_CashBook_log.ldf", True)
        Catch ex As Exception
            MsgBox("Failsafe process unsuccessful", MsgBoxStyle.OkOnly, "Failsafe information")
        End Try
        '======================================================================================================================================
    End Sub

    Public Sub scheduledBackup()

        '  DATABASE SCHEDULED BACKUP TILL LAST USE
        '======================================================================================================================================
        Try
            con_cls.disconnect()
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook.mdf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook_log.ldf", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
        Catch ex As Exception
            MsgBox("ScheduledBackup process (delete) unsuccessful", MsgBoxStyle.OkOnly, "ScheduledBackup information")
        End Try
        Try
            con_cls.disconnect()
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\DataItems\KVKDhalai_CashBook.mdf", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook.mdf", True)
            My.Computer.FileSystem.CopyFile(Application.StartupPath & "\DataItems\KVKDhalai_CashBook_log.ldf", My.Computer.FileSystem.SpecialDirectories.ProgramFiles & "\ScheduledBackup\KVKDhalai_CashBook_log.ldf", True)
        Catch ex As Exception
            MsgBox("ScheduledBackup process unsuccessful", MsgBoxStyle.OkOnly, "ScheduledBackup information")
        End Try
        '======================================================================================================================================
    End Sub

    Public Sub checkDbRestore()
        'CHECK DATABASE RESTORE STATUS
        '======================================================================================================================================
        Try
            'Read last successfull database restore date from database
            '======================================================================================================================================
            con_cls.connectFailsafe()
            con_cls.cmdFailsafe.CommandText = "SELECT MAX(doe) FROM TTABLEDATABASE WHERE rem='Partially Successful'"
            dr = con_cls.cmdFailsafe.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    preRestoreDate = dr.Item(0)
                Else
                    dr.Close()
                    con_cls.disconnectFailsafe()
                    Exit Sub
                End If
            End If
            dr.Close()
            con_cls.cmdFailsafe.CommandText = "SELECT userInfo FROM TTABLEDATABASE WHERE rem='Partially Successful'"
            dr = con_cls.cmdFailsafe.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    dbRestoreUser = dr.Item(0)
                End If
            End If
            dr.Close()
            con_cls.cmdFailsafe.CommandText = "SELECT type FROM TTABLEDATABASE WHERE rem='Partially Successful'"
            dr = con_cls.cmdFailsafe.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                If Not dr.IsDBNull(0) Then
                    dbRestorePath = dr.Item(0)
                End If
            End If
            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Information")
        End Try
        dr.Close()
        con_cls.disconnectFailsafe()
        '======================================================================================================================================

        'Database Auto Restore 
        '======================================================================================================================================
        Try
            My.Computer.FileSystem.CopyFile("D:\BACKUP\KVKCASH\DBRESTORE\" & preRestoreDate.Date.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook.mdf", Application.StartupPath & "\DataItems\KVKDhalai_CashBook.mdf", True)
            My.Computer.FileSystem.CopyFile("D:\BACKUP\KVKCASH\DBRESTORE\" & preRestoreDate.Date.ToString("MM.dd.yyyy") & "\KVKDhalai_CashBook_log.ldf", Application.StartupPath & "\DataItems\KVKDhalai_CashBook_log.ldf", True)
            Try
                trans_querry.update_trans_database(dbRestoreUser, "Restore Database", "Successful (Path: " & dbRestorePath & ")")
                MsgBox("Database restore successful.", MsgBoxStyle.OkOnly, "Database restore information")
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
            Try
                trans_querry.update_trans_database(dbRestoreUser, "Restore Database", "Unsuccessful (Path: " & dbRestorePath & ")")
                MsgBox("Database restore unsuccessful", MsgBoxStyle.OkOnly, "Database Restore information")
            Catch ex2 As Exception
                MsgBox(ex2.Message, MsgBoxStyle.OkOnly, "Connecting with class_querry error")
            End Try
        End Try
        '======================================================================================================================================
        
    End Sub

End Class