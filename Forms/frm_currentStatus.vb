Imports System.Data
Imports System.Data.SqlClient

Public Class frm_currentStatus
    Dim dr As SqlDataReader
    Dim con_cls As New class_connectionString

    Private Sub frm_currentStatus_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    End Sub

End Class