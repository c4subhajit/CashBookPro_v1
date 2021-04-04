Imports System.Data
Imports System.Data.SqlClient

Public Class frm_loginModify
    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString
    Dim trans_querry As New class_transactionTasks
    Dim valid As New class_validationFunctions
    Dim username As String

    Private Sub frm_loginModify_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call resetLoginModify()
    End Sub

    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        con_cls.connect()
        If txt_oldPass.Text = "" Then
            MsgBox("Please enter old password")
        ElseIf txt_pass.Text = "" Then
            MsgBox("Please enter new password")
        ElseIf txt_confirmPass.Text = "" Then
            MsgBox("Please confirm new password")
        Else
            Try
                '                   CHECK OLD PASSWORD
                '==================================================================================
                con_cls.cmd.CommandText = "SELECT pass FROM USERACCOUNTS WHERE userid='" & username & "'"
                dr = con_cls.cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    If dr.Item("pass") = txt_oldPass.Text Then
                        dr.Close()
                        '================================================================================================
                        '  CHANGE PASSWORD
                        Try
                            con_cls.cmd.CommandText = "UPDATE USERACCOUNTS SET pass='" & txt_pass.Text & "' WHERE userid='" & username & "'"
                            con_cls.cmd.ExecuteNonQuery()
                            MsgBox("Password updated successfully", MsgBoxStyle.OkOnly, "Update password information.")
                            trans_querry.update_trans_login(frm_home.username, "Password Change", "Password change successful")
                            Me.Close()
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Update password error.")
                            trans_querry.update_trans_login(frm_home.username, "Password Change", "Password change unsuccessful")
                            Exit Sub
                        End Try
                        '=======================================================================================
                    Else
                        MsgBox("Incorrect old password", MsgBoxStyle.OkOnly, "Password verification.")
                        trans_querry.update_trans_login(frm_home.username, "Password Change", "Password change unsuccessful")
                        dr.Close()
                        con_cls.disconnect()
                    End If
                Else
                    MsgBox("Incorrect username or password", MsgBoxStyle.OkOnly, "Login error")
                    trans_querry.update_trans_login(frm_home.username, "Password Change", "Password change unsuccessful")
                    dr.Close()
                    con_cls.disconnect()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Information")
            End Try
        End If
    End Sub

    Private Sub cmd_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        Me.Close()
    End Sub

    '=================================================================
    '                   USER DEFINED FUNCTIONS
    '=================================================================
    Public Sub resetLoginModify()
        txt_oldPass.Clear()
        txt_pass.Clear()
        txt_confirmPass.Clear()
        username = frm_home.username
    End Sub

    '=================================================================
    '                   TEXT VALIDATION OF DATA FIELDS
    '=================================================================

    Private Sub txt_pass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_pass.Validating
        Try
            valid.pass_validate(txt_pass.Text, txt_confirmPass.Text, txt_pass)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_confirmPass_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_confirmPass.Validating
        Try
            valid.pass_validate(txt_pass.Text, txt_confirmPass.Text, txt_pass)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub
End Class