Imports System.Data
Imports System.Data.SqlClient
Imports System.Math

Public Class frm_KVKCB_CD_CDU
    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString
    Dim trans_querry As New class_transactionTasks
    Dim valid As New class_validationFunctions
    Dim t_id As Int64
    Public saveStatus As String
    Public field_status_receipts, field_status_payments, field_status_main As String
    Public total_rec, total_pay As Double

    Private Sub frm_KVKCB_CD_CDU_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txt_date_RAP.Clear()
        txt_month_RAP.Clear()
        Call resetReceipts()
        Call resetPayments()
        total_rec = 0.0
        total_pay = 0.0
        DTP_RAP.Focus()
        saveStatus = "OK"
    End Sub

    Private Sub DTP_RAP_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_RAP.ValueChanged
        txt_date_RAP.Text = DTP_RAP.Value
        txt_month_RAP.Text = MonthName(Month(DTP_RAP.Value))
        saveStatus = ""
    End Sub

    '============================================================
    '       RECEIPTS SECTION COMMAND BUTTON CODES
    '============================================================
    Private Sub cmd_R_cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_R_cal.Click
        Call check_fields_receipts()
        If field_status_receipts = "OK" Then
            Call calculateReceipts()
        End If
        saveStatus = ""
    End Sub

    Private Sub cmd_R_nil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_R_nil.Click
        If txt_date_RAP.Text = "" Then
            MsgBox("Please select date to continue.", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            DTP_RAP.Focus()
            Exit Sub
        End If
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
        saveStatus = ""
    End Sub

    '============================================================
    '       PAYMENTS SECTION COMMAND BUTTON CODES
    '============================================================
    Private Sub cmd_P_cal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_P_cal.Click
        Call check_fields_payments()
        If field_status_payments = "OK" Then
            Call calculatePayments()
        End If
        saveStatus = ""
    End Sub

    Private Sub cmd_P_nil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_P_nil.Click
        If txt_date_RAP.Text = "" Then
            MsgBox("Please select date to continue.", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            DTP_RAP.Focus()
            Exit Sub
        End If
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
        saveStatus = ""
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
                        t_id += 1
                    Else
                        t_id = 1
                    End If
                End If
                dr.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Transaction ID retrieve Sqlquerry block error")
            End Try

            'Inserting new cash details into cashbook table
            con_cls.cmd.CommandText = "INSERT INTO CASHBOOK (tid_CB,date_rap,month,rui," & _
            "part_rec,pna_rec,off_rec,work_rec,nrc_rec,misc_rec,rem_rec,tot_rec,ob_rec,gt_rec," & _
            "part_pay,pna_pay,off_pay,work_pay,nrc_pay,misc_pay,chkndate_pay,rem_pay,tot_pay,cb_pay,gt_pay)" & _
            " VALUES " & _
            "(" & t_id & ",'" & CDate(txt_date_RAP.Text) & "','" & txt_month_RAP.Text & "','" & frm_home.username & " (" & System.DateTime.Now & ")'," & _
            "'" & txt_part_rec.Text & "'," & Round(CDbl(txt_PnA_rec.Text), 2) & "," & Round(CDbl(txt_off_rec.Text), 2) & "," & _
            Round(CDbl(txt_work_rec.Text), 2) & "," & Round(CDbl(txt_nrc_rec.Text), 2) & "," & Round(CDbl(txt_misc_rec.Text), 2) & "," & _
            "'" & txt_rem_rec.Text & "'," & Round(CDbl(txt_tot_rec.Text), 2) & "," & _
            Round(CDbl(txt_ob_rec.Text), 2) & "," & Round(CDbl(txt_gt_rec.Text), 2) & "," & _
            "'" & txt_part_pay.Text & "'," & Round(CDbl(txt_PnA_pay.Text), 2) & "," & Round(CDbl(txt_off_pay.Text), 2) & "," & _
            Round(CDbl(txt_work_pay.Text), 2) & "," & Round(CDbl(txt_nrc_pay.Text), 2) & "," & Round(CDbl(txt_misc_pay.Text), 2) & "," & _
            "'" & txt_chk_pay.Text & "','" & txt_rem_pay.Text & "'," & Round(CDbl(txt_tot_pay.Text), 2) & "," & _
            Round(CDbl(txt_cb_pay.Text), 2) & "," & Round(CDbl(txt_gt_pay.Text), 2) & ")"
            con_cls.cmd.ExecuteNonQuery()

            'Updating successful data insert into transaction table
            trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Update", "Successful (Unique ID:" & t_id & ")")
            MsgBox("Cashbook record updated successfully.", MsgBoxStyle.OkOnly, "Cashbook record information.")

            'Reset form data after succesful insert operation.
            DTP_RAP.Value = Now
            txt_date_RAP.Clear()
            txt_month_RAP.Clear()
            Call resetReceipts()
            Call resetPayments()
            saveStatus = "OK"

        Catch ex As Exception
            trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Update", "Unsuccessful")
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in Insert Current Cash Detail Block.")
        End Try

    End Sub

    Private Sub cmd_reset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_reset.Click
        DTP_RAP.Value = Now
        txt_date_RAP.Clear()
        txt_month_RAP.Clear()
        Call resetReceipts()
        Call resetPayments()
        saveStatus = "OK"
    End Sub

    Private Sub cmd_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        If saveStatus = "OK" Then
            Me.Close()
        Else
            If MessageBox.Show("Current unsaved data will be lost, continue?", "Sure to cancel?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Me.Close()
            End If
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

        'BLOCK 1
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

        'BLOCK 2
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

        'BLOCK 3
        '------------------------------------------------------------------
        Try
            txt_ob_rec.Text = Round(cb, 2)
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

        'BLOCK 1
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

        'BLOCK 2
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

        'BLOCK 3
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

    '=================================================================
    '                   EMPTY FIELD CHECK FUNCTIONS
    '=================================================================
    Public Sub check_fields_receipts()
        field_status_receipts = ""
        If txt_date_RAP.Text = "" Then
            MsgBox("Please select date to continue.", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            DTP_RAP.Focus()
            Exit Sub
        ElseIf txt_part_rec.Text = "" Then
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
        If txt_date_RAP.Text = "" Then
            MsgBox("Please select date to continue.", MsgBoxStyle.OkOnly, "Validation error (Empty field)")
            DTP_RAP.Focus()
            Exit Sub
        ElseIf txt_part_pay.Text = "" Then
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

    '      GLOBAL DATE

    Private Sub DTP_RAP_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DTP_RAP.Validating
        Try
            valid.cashDetailsDate_validate(DTP_RAP.Value, DTP_RAP)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Connecting with class_validaton_function error")
        End Try
    End Sub

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