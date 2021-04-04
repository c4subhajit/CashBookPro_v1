Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Public Class frm_KVKCB_CD_CDE

    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString
    Dim trans_querry As New class_transactionTasks
    Dim valid As New class_validationFunctions
    Dim t_id As Int64
    Public field_status_receipts, field_status_payments, field_status_main As String
    Public editClick As String
    Public total As Double
    Public lastDate As Date
    Public total_rec, total_pay As Double

    Private Sub frm_KVKCB_CD_CDE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadForm()
    End Sub

    '============================================================
    '       RECEIPTS SECTION COMMAND BUTTON CODES
    '============================================================
    Private Sub cmd_R_cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_R_cal.Click
        Call check_fields_receipts()
        If field_status_receipts = "OK" Then
            Call calculateReceipts()
        End If
    End Sub

    Private Sub cmd_R_nil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_R_nil.Click
        txt_part_rec.Text = "-- N.A. --"
        txt_PnA_rec.Text = "0.00"
        txt_off_rec.Text = "0.00"
        txt_work_rec.Text = "0.00"
        txt_nrc_rec.Text = "0.00"
        txt_misc_rec.Text = "0.00"
        txt_rem_rec.Text = "-- N.A. --"
        txt_tot_rec.Text = "0.00"
        Call check_fields_receipts()
        If field_status_receipts = "OK" Then
            Call calculateReceipts()
        End If
    End Sub

    '============================================================
    '       PAYMENTS SECTION COMMAND BUTTON CODES
    '============================================================
    Private Sub cmd_P_cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_P_cal.Click
        Call check_fields_payments()
        If field_status_payments = "OK" Then
            Call calculatePayments()
        End If
    End Sub

    Private Sub cmd_P_nil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_P_nil.Click
        txt_part_pay.Text = "-- N.A. --"
        txt_PnA_pay.Text = "0.00"
        txt_off_pay.Text = "0.00"
        txt_work_pay.Text = "0.00"
        txt_nrc_pay.Text = "0.00"
        txt_misc_pay.Text = "0.00"
        txt_chk_pay.Text = "-- N.A. --"
        txt_rem_pay.Text = "-- N.A. --"
        txt_tot_pay.Text = "0.00"
        Call check_fields_payments()
        If field_status_payments = "OK" Then
            Call calculatePayments()
        End If
    End Sub

    '============================================================
    '       GLOBAL COMMAND BUTTON CODES
    '============================================================
    Private Sub cmd_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_save.Click
        Call check_fields_receipts()
        If Not field_status_receipts = "OK" Then
            Exit Sub
        End If
        Call check_fields_payments()
        If Not field_status_payments = "OK" Then
            Exit Sub
        End If
        Call check_fields_main()
        If Not field_status_main = "OK" Then
            Exit Sub
        End If

        Try
            con_cls.connect()

            'Fetching unique transaction ID
            Try
                con_cls.cmd.CommandText = "SELECT MAX(tid_CB) FROM CASHBOOK"
                dr = con_cls.cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    If Not dr.IsDBNull(0) Then
                        t_id = CInt(dr.Item(0))
                    Else
                        t_id = 1
                    End If
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction ID retrieve Sqlquerry block error")
            End Try

            'Updating new cash details into cashbook table
            con_cls.cmd.CommandText = "UPDATE CASHBOOK SET tid_CB=" & t_id & ",rui='" & frm_home.username & " (" & System.DateTime.Now & ")'," & _
            "part_rec='" & txt_part_rec.Text & "',pna_rec=" & Round(CDbl(txt_PnA_rec.Text), 2) & ",off_rec=" & Round(CDbl(txt_off_rec.Text), 2) & _
            ",work_rec=" & Round(CDbl(txt_work_rec.Text), 2) & ",nrc_rec=" & Round(CDbl(txt_nrc_rec.Text), 2) & ",misc_rec=" & _
            Round(CDbl(txt_misc_rec.Text), 2) & ",rem_rec='" & txt_rem_rec.Text & "',tot_rec=" & Round(CDbl(txt_tot_rec.Text), 2) & _
            ",ob_rec=" & Round(CDbl(txt_ob_rec.Text), 2) & ",gt_rec=" & Round(CDbl(txt_gt_rec.Text), 2) & "," & _
            "part_pay='" & txt_part_pay.Text & "',pna_pay=" & Round(CDbl(txt_PnA_pay.Text), 2) & ",off_pay=" & Round(CDbl(txt_off_pay.Text), 2) & _
            ",work_pay=" & Round(CDbl(txt_work_pay.Text), 2) & ",nrc_pay=" & Round(CDbl(txt_nrc_pay.Text), 2) & ",misc_pay=" & Round(CDbl(txt_misc_pay.Text), 2) & _
            ",chkndate_pay='" & txt_chk_pay.Text & "',rem_pay='" & txt_rem_pay.Text & "',tot_pay=" & Round(CDbl(txt_tot_pay.Text), 2) & _
            ",cb_pay=" & Round(CDbl(txt_cb_pay.Text), 2) & ",gt_pay=" & Round(CDbl(txt_gt_pay.Text), 2) & " WHERE date_rap='" & CDate(txt_date_RAP.Text) & "'"
            con_cls.cmd.ExecuteNonQuery()

            'Updating successful data edit into transaction table
            trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Edit", "Successful (Unique ID:" & t_id & ")")
            MsgBox("Cashbook record edited successfully.", MsgBoxStyle.OkOnly, "Cashbook record information.")

            'Reset form data after succesful edit operation.
            Call loadForm()

        Catch ex As Exception
            trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Edit", "Unsuccessful")
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in Update Current Cash Detail Block.")
        End Try
    End Sub

    Private Sub cmd_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_reset.Click
        Call resetReceipts()
        Call resetPayments()
        Call loadForm()
    End Sub

    Private Sub cmd_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_edit.Click
        Call enableEdit()
    End Sub

    Private Sub cmd_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        If editClick = "TRUE" Then
            If MessageBox.Show("Current unsaved data will be lost, continue?", "Sure to cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    '=================================================================
    '                   USER DEFINED FUNCTIONS
    '=================================================================
    Public Sub resetReceipts()
        txt_part_rec.Clear()
        txt_PnA_rec.Clear()
        txt_off_rec.Clear()
        txt_work_rec.Clear()
        txt_nrc_rec.Clear()
        txt_misc_rec.Clear()
        txt_rem_rec.Clear()
        txt_tot_rec.Clear()
        txt_ob_rec.Clear()
        txt_gt_rec.Clear()
    End Sub

    Public Sub updateTotalReceipts()
        Try
            total_rec = 0.0
            If Not txt_PnA_rec.Text = "" Then
                Call calculateTotal_rec(txt_PnA_rec.Text)
            End If
            If Not txt_off_rec.Text = "" Then
                Call calculateTotal_rec(txt_off_rec.Text)
            End If
            If Not txt_work_rec.Text = "" Then
                Call calculateTotal_rec(txt_work_rec.Text)
            End If
            If Not txt_nrc_rec.Text = "" Then
                Call calculateTotal_rec(txt_nrc_rec.Text)
            End If
            If Not txt_misc_rec.Text = "" Then
                Call calculateTotal_rec(txt_misc_rec.Text)
            End If
            If total_rec = 0.0 Then
                If txt_tot_rec.Text = "" Then
                    txt_tot_rec.Text = Round(total_rec, 2)
                End If
            Else
                If txt_tot_rec.Text = "" Then
                    txt_tot_rec.Text = Round(total_rec, 2)
                Else
                    txt_tot_rec.Text = Round(total_rec, 2)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in updating total amount.")
        End Try

        Call check_fields_receipts()
        If field_status_receipts = "OK" Then
            Call calculateReceipts()
        End If

    End Sub

    Public Sub calculateReceipts()

        con_cls.connect()

        'BLOCK 1: Getting the max date from Table
        '------------------------------------------------------------------
        Dim maxDate As Date
        Try
            con_cls.cmd.CommandText = "SELECT MAX(date_rap) FROM CASHBOOK"
            dr = con_cls.cmd.ExecuteReader
            Try
                If dr.HasRows Then
                    dr.Read()
                    If Not dr.IsDBNull(0) Then
                        maxDate = CDate(dr.Item(0))
                    End If
                End If
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
            End Try
            dr.Close()
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
        End Try
        '------------------------------------------------------------------

        'BLOCK 2: Getting the opening and closing balance from table
        '------------------------------------------------------------------
        Dim ob, cb As Double
        Try
            con_cls.cmd.CommandText = "SELECT * FROM CASHBOOK WHERE date_rap='" & maxDate & "'"
            dr = con_cls.cmd.ExecuteReader
            ob = 0.0
            cb = 0.0
            Try
                If dr.HasRows Then
                    dr.Read()
                    If Not IsDBNull(11) Then
                        ob = CDbl(dr.Item("ob_rec"))
                    End If
                    If Not IsDBNull(22) Then
                        cb = CDbl(dr.Item("cb_pay"))
                    End If
                End If
                dr.Close()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
            End Try
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
        End Try
        '------------------------------------------------------------------

        'BLOCK 3: Updating global text fields
        '------------------------------------------------------------------
        Try
            txt_ob_rec.Text = Round(ob, 2)
            txt_gt_rec.Text = Round((CDbl(txt_tot_rec.Text) + CDbl(txt_ob_rec.Text)), 2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Updating Receipts fields error in Block 3.")
        End Try
        '------------------------------------------------------------------

        con_cls.disconnect()

    End Sub

    Public Sub resetPayments()
        txt_part_pay.Clear()
        txt_PnA_pay.Clear()
        txt_off_pay.Clear()
        txt_work_pay.Clear()
        txt_nrc_pay.Clear()
        txt_misc_pay.Clear()
        txt_chk_pay.Clear()
        txt_rem_pay.Clear()
        txt_tot_pay.Clear()
        txt_cb_pay.Clear()
        txt_gt_pay.Clear()
    End Sub

    Public Sub updateTotalPayments()
        Try
            total_pay = 0.0
            If Not txt_PnA_pay.Text = "" Then
                Call calculateTotal_pay(txt_PnA_pay.Text)
            End If
            If Not txt_off_pay.Text = "" Then
                Call calculateTotal_pay(txt_off_pay.Text)
            End If
            If Not txt_work_pay.Text = "" Then
                Call calculateTotal_pay(txt_work_pay.Text)
            End If
            If Not txt_nrc_pay.Text = "" Then
                Call calculateTotal_pay(txt_nrc_pay.Text)
            End If
            If Not txt_misc_pay.Text = "" Then
                Call calculateTotal_pay(txt_misc_pay.Text)
            End If
            If total_pay = 0.0 Then
                If txt_tot_pay.Text = "" Then
                    txt_tot_pay.Text = Round(total_pay, 2)
                End If
            Else
                If txt_tot_pay.Text = "" Then
                    txt_tot_pay.Text = Round(total_pay, 2)
                Else
                    txt_tot_pay.Text = Round(total_pay, 2)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in updating total amount.")
        End Try

        Call check_fields_payments()
        If field_status_payments = "OK" Then
            Call calculatePayments()
        End If

    End Sub

    Public Sub calculatePayments()

        con_cls.connect()

        'BLOCK 1: Getting the max date from Table
        '------------------------------------------------------------------
        Dim maxDate As Date
        Try
            con_cls.cmd.CommandText = "SELECT MAX(date_rap) FROM CASHBOOK"
            dr = con_cls.cmd.ExecuteReader
            Try
                If dr.HasRows Then
                    dr.Read()
                    If Not dr.IsDBNull(0) Then
                        maxDate = CDate(dr.Item(0))
                    End If
                End If
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
            End Try
            dr.Close()
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
        End Try
        '------------------------------------------------------------------

        'BLOCK 2: Getting the opening and closing balance from table
        '------------------------------------------------------------------
        Dim ob, cb As Double
        Try
            con_cls.cmd.CommandText = "SELECT * FROM CASHBOOK WHERE date_rap='" & maxDate & "'"
            dr = con_cls.cmd.ExecuteReader
            ob = 0.0
            cb = 0.0
            Try
                If dr.HasRows Then
                    dr.Read()
                    If Not IsDBNull(11) Then
                        ob = CDbl(dr.Item("ob_rec"))
                    End If
                    If Not IsDBNull(22) Then
                        cb = CDbl(dr.Item("cb_pay"))
                    End If
                End If
                dr.Close()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
            End Try
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
        End Try
        '------------------------------------------------------------------

        'BLOCK 3: Updating global text fields
        '------------------------------------------------------------------
        Try
            Call check_fields_receipts()
            Call updateTotalReceipts()
            Call calculateReceipts()
            txt_cb_pay.Text = Round((CDbl(txt_gt_rec.Text) - CDbl(txt_tot_pay.Text)), 2)
            txt_gt_pay.Text = Round((CDbl(txt_tot_pay.Text) + CDbl(txt_cb_pay.Text)), 2)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Updating Payments fields error in Block 3.")
        End Try
        '------------------------------------------------------------------

        con_cls.disconnect()

    End Sub

    Public Sub calculateTotal_rec(ByVal a As String)
        total_rec = total_rec + CDbl(a)
    End Sub

    Public Sub calculateTotal_pay(ByVal a As String)
        total_pay = total_pay + CDbl(a)
    End Sub

    Public Sub enableEdit()
        GB_receipts.Enabled = True
        GB_payments.Enabled = True
        cmd_edit.Enabled = False
        cmd_save.Enabled = True
        cmd_reset.Enabled = True
        editClick = "TRUE"
    End Sub

    Public Sub disableEdit()
        GB_receipts.Enabled = False
        GB_payments.Enabled = False
        cmd_edit.Enabled = True
        cmd_save.Enabled = False
        cmd_reset.Enabled = False
        editClick = ""
    End Sub

    Public Sub loadForm()
        con_cls.connect()

        'BLOCK 1: Getting the max date from Table
        '------------------------------------------------------------------
        Dim maxDate As Date
        Try
            con_cls.cmd.CommandText = "SELECT MAX(date_rap) FROM CASHBOOK"
            dr = con_cls.cmd.ExecuteReader
            Try
                If dr.HasRows Then
                    dr.Read()
                    If Not dr.IsDBNull(0) Then
                        maxDate = CDate(dr.Item(0))
                    Else
                        Exit Sub
                        Me.Close()
                    End If
                End If
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
            End Try
            dr.Close()
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
        End Try
        '------------------------------------------------------------------

        'BLOCK 2: Getting all values of the last entry from table
        '------------------------------------------------------------------
        Try
            con_cls.cmd.CommandText = "SELECT * FROM CASHBOOK WHERE date_rap='" & maxDate & "'"
            dr = con_cls.cmd.ExecuteReader
            Try
                If dr.HasRows Then
                    dr.Read()
                    txt_date_RAP.Text = dr.Item("date_rap")
                    txt_month_RAP.Text = dr.Item("month")
                    txt_part_rec.Text = dr.Item("part_rec")
                    txt_PnA_rec.Text = dr.Item("pna_rec")
                    txt_off_rec.Text = dr.Item("off_rec")
                    txt_work_rec.Text = dr.Item("work_rec")
                    txt_nrc_rec.Text = dr.Item("nrc_rec")
                    txt_misc_rec.Text = dr.Item("misc_rec")
                    txt_rem_rec.Text = dr.Item("rem_rec")
                    txt_tot_rec.Text = dr.Item("tot_rec")
                    txt_ob_rec.Text = dr.Item("ob_rec")
                    txt_gt_rec.Text = dr.Item("gt_rec")
                    txt_part_pay.Text = dr.Item("part_pay")
                    txt_PnA_pay.Text = dr.Item("pna_pay")
                    txt_off_pay.Text = dr.Item("off_pay")
                    txt_work_pay.Text = dr.Item("work_pay")
                    txt_nrc_pay.Text = dr.Item("nrc_pay")
                    txt_misc_pay.Text = dr.Item("misc_pay")
                    txt_chk_pay.Text = dr.Item("chkndate_pay")
                    txt_rem_pay.Text = dr.Item("rem_pay")
                    txt_tot_pay.Text = dr.Item("tot_pay")
                    txt_cb_pay.Text = dr.Item("cb_pay")
                    txt_gt_pay.Text = dr.Item("gt_pay")
                End If
                dr.Close()
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
            End Try
        Catch ex0 As Exception
            MsgBox(ex0.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 2.")
        End Try
        '------------------------------------------------------------------
        total = 0.0
        Call disableEdit()
    End Sub

    '=================================================================
    '                   EMPTY FIELD CHECK FUNCTIONS
    '=================================================================
    Public Sub check_fields_receipts()
        field_status_receipts = ""
        If txt_part_rec.Text = "" Then
            txt_part_rec.Text = "-- N.A. --"
            Call check_fields_receipts()
        ElseIf txt_PnA_rec.Text = "" Then
            txt_PnA_rec.Text = "0.0"
            Call check_fields_receipts()
        ElseIf txt_off_rec.Text = "" Then
            txt_off_rec.Text = "0.0"
            Call check_fields_receipts()
        ElseIf txt_work_rec.Text = "" Then
            txt_work_rec.Text = "0.0"
            Call check_fields_receipts()
        ElseIf txt_nrc_rec.Text = "" Then
            txt_nrc_rec.Text = "0.0"
            Call check_fields_receipts()
        ElseIf txt_misc_rec.Text = "" Then
            txt_misc_rec.Text = "0.0"
            Call check_fields_receipts()
        ElseIf txt_rem_rec.Text = "" Then
            txt_rem_rec.Text = "-- N.A. --"
            Call check_fields_receipts()
        ElseIf txt_tot_rec.Text = "" Then
            txt_tot_rec.Text = "0.0"
            Call check_fields_receipts()
        Else
            field_status_receipts = "OK"
        End If
    End Sub

    Public Sub check_fields_payments()
        field_status_payments = ""
        If txt_part_pay.Text = "" Then
            txt_part_pay.Text = "-- N.A. --"
            Call check_fields_payments()
        ElseIf txt_PnA_pay.Text = "" Then
            txt_PnA_pay.Text = "0.0"
            Call check_fields_payments()
        ElseIf txt_off_pay.Text = "" Then
            txt_off_pay.Text = "0.0"
            Call check_fields_payments()
        ElseIf txt_work_pay.Text = "" Then
            txt_work_pay.Text = "0.0"
            Call check_fields_payments()
        ElseIf txt_nrc_pay.Text = "" Then
            txt_nrc_pay.Text = "0.0"
            Call check_fields_payments()
        ElseIf txt_misc_pay.Text = "" Then
            txt_misc_pay.Text = "0.0"
            Call check_fields_payments()
        ElseIf txt_chk_pay.Text = "" Then
            txt_chk_pay.Text = "-- N.A. --"
            Call check_fields_payments()
        ElseIf txt_rem_pay.Text = "" Then
            txt_rem_pay.Text = "-- N.A. --"
            Call check_fields_payments()
        ElseIf txt_tot_pay.Text = "" Then
            txt_tot_pay.Text = "0.0"
            Call check_fields_payments()
        Else
            field_status_payments = "OK"
        End If
    End Sub

    Public Sub check_fields_main()
        field_status_main = ""
        If txt_ob_rec.Text = "" Then
            MsgBox("Please calculate opening balance before continue", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            Exit Sub
        ElseIf txt_gt_rec.Text = "" Then
            MsgBox("Please calculate grand total of receipt section before continue", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            Exit Sub
        ElseIf txt_cb_pay.Text = "" Then
            MsgBox("Please calculate closing balance before continue", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            Exit Sub
        ElseIf txt_gt_pay.Text = "" Then
            MsgBox("Please calculate grand total of payments section before continue", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            Exit Sub
        Else
            field_status_main = "OK"
        End If
    End Sub

    '=================================================================
    '                   TEXT VALIDATION OF DATA FIELDS
    '=================================================================

    '      RECEIPTS SECTION

    Private Sub txt_part_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_part_rec.Validating
        Try
            valid.txtField_validate(txt_part_rec.Text, txt_part_rec)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_PnA_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PnA_rec.Validating
        Try
            valid.amount_validate(txt_PnA_rec.Text, txt_PnA_rec)
            If valid.err_code = 0 Then
                Call updateTotalReceipts()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_off_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_off_rec.Validating
        Try
            valid.amount_validate(txt_off_rec.Text, txt_off_rec)
            If valid.err_code = 0 Then
                Call updateTotalReceipts()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_work_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_work_rec.Validating
        Try
            valid.amount_validate(txt_work_rec.Text, txt_work_rec)
            If valid.err_code = 0 Then
                Call updateTotalReceipts()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_nrc_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_nrc_rec.Validating
        Try
            valid.amount_validate(txt_nrc_rec.Text, txt_nrc_rec)
            If valid.err_code = 0 Then
                Call updateTotalReceipts()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_misc_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_misc_rec.Validating
        Try
            valid.amount_validate(txt_misc_rec.Text, txt_misc_rec)
            If valid.err_code = 0 Then
                Call updateTotalReceipts()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_rem_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_rem_rec.Validating
        Try
            valid.txtField_validate(txt_rem_rec.Text, txt_rem_rec)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_tot_rec_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_tot_rec.Validating
        Try
            valid.amount_validate(txt_tot_rec.Text, txt_tot_rec)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    '      PAYMENTS SECTION

    Private Sub txt_part_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_part_pay.Validating
        Try
            valid.txtField_validate(txt_part_pay.Text, txt_part_pay)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_PnA_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_PnA_pay.Validating
        Try
            valid.amount_validate(txt_PnA_pay.Text, txt_PnA_pay)
            If valid.err_code = 0 Then
                Call updateTotalPayments()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_off_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_off_pay.Validating
        Try
            valid.amount_validate(txt_off_pay.Text, txt_off_pay)
            If valid.err_code = 0 Then
                Call updateTotalPayments()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_work_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_work_pay.Validating
        Try
            valid.amount_validate(txt_work_pay.Text, txt_work_pay)
            If valid.err_code = 0 Then
                Call updateTotalPayments()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_nrc_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_nrc_pay.Validating
        Try
            valid.amount_validate(txt_nrc_pay.Text, txt_nrc_pay)
            If valid.err_code = 0 Then
                Call updateTotalPayments()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_misc_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_misc_pay.Validating
        Try
            valid.amount_validate(txt_misc_pay.Text, txt_misc_pay)
            If valid.err_code = 0 Then
                Call updateTotalPayments()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_chk_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_chk_pay.Validating
        Try
            valid.txtField_validate(txt_chk_pay.Text, txt_chk_pay)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_rem_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_rem_pay.Validating
        Try
            valid.txtField_validate(txt_rem_pay.Text, txt_rem_pay)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

    Private Sub txt_tot_pay_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txt_tot_pay.Validating
        Try
            valid.amount_validate(txt_tot_pay.Text, txt_tot_pay)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

End Class