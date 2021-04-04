Imports System.Data
Imports System.Data.SqlClient

Public Class frm_KVKCB_CD_CDD

    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString
    Dim trans_querry As New class_transactionTasks
    Dim valid As New class_validationFunctions
    Dim t_id As Int64

    Private Sub frm_KVKCB_CD_CDD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadForm()
    End Sub

    Private Sub cmd_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_cancel.Click
        Me.Close()
    End Sub

    Private Sub cmd_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_delete.Click
        If MessageBox.Show("Are you sure to delete this record, continue?", "Sure to delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
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

                'Deleting cash details from cashbook table
                con_cls.cmd.CommandText = "DELETE FROM CASHBOOK WHERE date_rap='" & CDate(txt_date_RAP.Text) & "'"
                con_cls.cmd.ExecuteNonQuery()

                'Updating successful data delete into transaction table
                trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Delete", "Successful (Unique ID:" & t_id & ")")
                MsgBox("Cashbook record deleted successfully.", MsgBoxStyle.OkOnly, "Cashbook record information.")

                'Reset form data after succesful delete operation.
                Call loadForm()

            Catch ex As Exception
                trans_querry.update_trans_cashbook(frm_home.username, "Cash Detail Delete", "Unsuccessful")
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in Delete Current Cash Detail Block.")
            End Try
        End If
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
                        dr.Close()
                        MsgBox("No Cashbook record available for deletion.", MsgBoxStyle.OkOnly, "Cashbook record information.")
                        txt_date_RAP.Clear()
                        txt_month_RAP.Clear()
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
                        cmd_delete.Enabled = False
                        Exit Sub
                    End If
                    dr.Close()
                End If
            Catch ex1 As Exception
                MsgBox(ex1.Message, MsgBoxStyle.OkOnly, "Receipts Data read error in Block 1.")
            End Try
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
    End Sub

End Class