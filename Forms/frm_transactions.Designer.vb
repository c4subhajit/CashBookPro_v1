<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_transactions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_transactions))
        Me.dgv_tt = New System.Windows.Forms.DataGridView
        Me.cmd_show = New System.Windows.Forms.Button
        Me.cmb_type = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgv_tt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_tt
        '
        Me.dgv_tt.AllowUserToAddRows = False
        Me.dgv_tt.AllowUserToDeleteRows = False
        Me.dgv_tt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_tt.Location = New System.Drawing.Point(12, 50)
        Me.dgv_tt.Name = "dgv_tt"
        Me.dgv_tt.ReadOnly = True
        Me.dgv_tt.Size = New System.Drawing.Size(860, 449)
        Me.dgv_tt.TabIndex = 16
        '
        'cmd_show
        '
        Me.cmd_show.Location = New System.Drawing.Point(567, 13)
        Me.cmd_show.Name = "cmd_show"
        Me.cmd_show.Size = New System.Drawing.Size(75, 23)
        Me.cmd_show.TabIndex = 15
        Me.cmd_show.Text = "&SHOW"
        Me.cmd_show.UseVisualStyleBackColor = True
        '
        'cmb_type
        '
        Me.cmb_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_type.FormattingEnabled = True
        Me.cmb_type.Items.AddRange(New Object() {"", "Login Status", "Password Change", "Backup Database", "Restore Database", "Scheduled Backup", "Cash Detail Update", "Cash Detail Edit", "Cash Detail Delete"})
        Me.cmb_type.Location = New System.Drawing.Point(329, 14)
        Me.cmb_type.Name = "cmb_type"
        Me.cmb_type.Size = New System.Drawing.Size(220, 21)
        Me.cmb_type.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select tansaction type"
        '
        'frm_transactions
        '
        Me.AcceptButton = Me.cmd_show
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 512)
        Me.Controls.Add(Me.dgv_tt)
        Me.Controls.Add(Me.cmd_show)
        Me.Controls.Add(Me.cmb_type)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(900, 550)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(900, 550)
        Me.Name = "frm_transactions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Transactions"
        CType(Me.dgv_tt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_tt As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_show As System.Windows.Forms.Button
    Friend WithEvents cmb_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
