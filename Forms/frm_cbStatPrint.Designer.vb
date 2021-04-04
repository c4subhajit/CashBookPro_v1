<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_cbStatPrint
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_cbStatPrint))
        Me.CASHBOOKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.KVKDhalai_CashBookDataSet = New CashBookPro_v1.KVKDhalai_CashBookDataSet
        Me.ReportViewer_CBStat = New Microsoft.Reporting.WinForms.ReportViewer
        Me.CASHBOOKTableAdapter = New CashBookPro_v1.KVKDhalai_CashBookDataSetTableAdapters.CASHBOOKTableAdapter
        CType(Me.CASHBOOKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KVKDhalai_CashBookDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CASHBOOKBindingSource
        '
        Me.CASHBOOKBindingSource.DataMember = "CASHBOOK"
        Me.CASHBOOKBindingSource.DataSource = Me.KVKDhalai_CashBookDataSet
        '
        'KVKDhalai_CashBookDataSet
        '
        Me.KVKDhalai_CashBookDataSet.DataSetName = "KVKDhalai_CashBookDataSet"
        Me.KVKDhalai_CashBookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer_CBStat
        '
        Me.ReportViewer_CBStat.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "KVKDhalai_CashBookDataSet_CASHBOOK"
        ReportDataSource1.Value = Me.CASHBOOKBindingSource
        Me.ReportViewer_CBStat.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer_CBStat.LocalReport.ReportEmbeddedResource = "CashBookPro_v1.Report_CBStat.rdlc"
        Me.ReportViewer_CBStat.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer_CBStat.Name = "ReportViewer_CBStat"
        Me.ReportViewer_CBStat.Size = New System.Drawing.Size(884, 512)
        Me.ReportViewer_CBStat.TabIndex = 0
        '
        'CASHBOOKTableAdapter
        '
        Me.CASHBOOKTableAdapter.ClearBeforeFill = True
        '
        'frm_cbStatPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 512)
        Me.Controls.Add(Me.ReportViewer_CBStat)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(900, 550)
        Me.Name = "frm_cbStatPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cash Book Statement"
        CType(Me.CASHBOOKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KVKDhalai_CashBookDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer_CBStat As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents CASHBOOKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents KVKDhalai_CashBookDataSet As CashBookPro_v1.KVKDhalai_CashBookDataSet
    Friend WithEvents CASHBOOKTableAdapter As CashBookPro_v1.KVKDhalai_CashBookDataSetTableAdapters.CASHBOOKTableAdapter
End Class
