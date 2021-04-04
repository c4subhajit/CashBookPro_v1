Public Class frm_cbStatPrint

    Private Sub frm_cbStatPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'KVKDhalai_CashBookDataSet.CASHBOOK' table. You can move, or remove it, as needed.
        Me.CASHBOOKTableAdapter.Fill(Me.KVKDhalai_CashBookDataSet.CASHBOOK, frm_home.dateFrom, frm_home.dateTo)
        Me.ReportViewer_CBStat.RefreshReport()
    End Sub
End Class