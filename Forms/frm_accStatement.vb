Imports System.Data
Imports System.Data.SqlClient

Public Class frm_accStatement
    Dim dt As DataTable
    Dim dr As SqlDataReader
    Public tableName As String
    Dim con_cls As New class_connectionString

    Private Sub cmd_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_show.Click
        If ((Not txt_date_from.Text = "") And (Not txt_date_to.Text = "")) Then
            '            TRANSACTION BY TYPE SEARCH
            '===================================================
            con_cls.connect()
            con_cls.cmd.CommandText = "SELECT date_rap,month,part_rec,pna_rec,off_rec,work_rec,nrc_rec,misc_rec,rem_rec,tot_rec,ob_rec,gt_rec," & _
            "part_pay,pna_pay,off_pay,work_pay,nrc_pay,misc_pay,chkndate_pay,rem_pay,tot_pay,cb_pay,gt_pay FROM CASHBOOK WHERE " & _
            "date_rap BETWEEN '" & DTP_from.Value & "' AND '" & DTP_to.Value & "'"
            Dim dt As New DataTable
            dt.Load(con_cls.cmd.ExecuteReader)
            dgv_tt.AutoGenerateColumns = True
            dgv_tt.DataSource = dt
            con_cls.disconnect()
            '===================================================
        Else
            MsgBox("Please select date range first", MsgBoxStyle.OkOnly, "Statement load error.")
        End If
    End Sub

    Private Sub cmd_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        If ((Not txt_date_from.Text = "") And (Not txt_date_to.Text = "")) Then
            frm_home.dateFrom = txt_date_from.Text
            frm_home.dateTo = txt_date_to.Text
            Try
                Dim form As New frm_cbStatPrint
                form.MdiParent = frm_home
                form.Show()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Open Child")
            End Try
        Else
            MsgBox("Please select date range first", MsgBoxStyle.OkOnly, "Statement load error.")
        End If
    End Sub

    Private Sub DTP_from_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_from.ValueChanged
        dgv_tt.DataSource = ""
        txt_date_from.Text = DTP_from.Value.Date
    End Sub

    Private Sub DTP_to_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_to.ValueChanged
        dgv_tt.DataSource = ""
        txt_date_to.Text = DTP_to.Value.Date
    End Sub

End Class