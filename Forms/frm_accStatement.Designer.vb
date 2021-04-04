<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_accStatement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_accStatement))
        Me.cmd_print = New System.Windows.Forms.Button
        Me.DTP_to = New System.Windows.Forms.DateTimePicker
        Me.DTP_from = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txt_date_to = New System.Windows.Forms.TextBox
        Me.txt_date_from = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv_tt = New System.Windows.Forms.DataGridView
        Me.cmd_show = New System.Windows.Forms.Button
        CType(Me.dgv_tt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmd_print
        '
        Me.cmd_print.Location = New System.Drawing.Point(765, 12)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(75, 23)
        Me.cmd_print.TabIndex = 33
        Me.cmd_print.Text = "&PRINT"
        Me.cmd_print.UseVisualStyleBackColor = True
        '
        'DTP_to
        '
        Me.DTP_to.Location = New System.Drawing.Point(638, 14)
        Me.DTP_to.Name = "DTP_to"
        Me.DTP_to.Size = New System.Drawing.Size(18, 20)
        Me.DTP_to.TabIndex = 25
        '
        'DTP_from
        '
        Me.DTP_from.Location = New System.Drawing.Point(364, 15)
        Me.DTP_from.Name = "DTP_from"
        Me.DTP_from.Size = New System.Drawing.Size(18, 20)
        Me.DTP_from.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(394, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 16)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "To"
        '
        'txt_date_to
        '
        Me.txt_date_to.Location = New System.Drawing.Point(432, 14)
        Me.txt_date_to.Name = "txt_date_to"
        Me.txt_date_to.ReadOnly = True
        Me.txt_date_to.Size = New System.Drawing.Size(200, 20)
        Me.txt_date_to.TabIndex = 31
        Me.txt_date_to.TabStop = False
        Me.txt_date_to.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txt_date_from
        '
        Me.txt_date_from.Location = New System.Drawing.Point(158, 15)
        Me.txt_date_from.Name = "txt_date_from"
        Me.txt_date_from.ReadOnly = True
        Me.txt_date_from.Size = New System.Drawing.Size(200, 20)
        Me.txt_date_from.TabIndex = 30
        Me.txt_date_from.TabStop = False
        Me.txt_date_from.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 16)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Select date range"
        '
        'dgv_tt
        '
        Me.dgv_tt.AllowUserToAddRows = False
        Me.dgv_tt.AllowUserToDeleteRows = False
        Me.dgv_tt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_tt.Location = New System.Drawing.Point(12, 50)
        Me.dgv_tt.Name = "dgv_tt"
        Me.dgv_tt.ReadOnly = True
        Me.dgv_tt.Size = New System.Drawing.Size(860, 450)
        Me.dgv_tt.TabIndex = 28
        '
        'cmd_show
        '
        Me.cmd_show.Location = New System.Drawing.Point(685, 12)
        Me.cmd_show.Name = "cmd_show"
        Me.cmd_show.Size = New System.Drawing.Size(75, 23)
        Me.cmd_show.TabIndex = 26
        Me.cmd_show.Text = "&SHOW"
        Me.cmd_show.UseVisualStyleBackColor = True
        '
        'frm_accStatement
        '
        Me.AcceptButton = Me.cmd_show
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 512)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.DTP_to)
        Me.Controls.Add(Me.DTP_from)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_date_to)
        Me.Controls.Add(Me.txt_date_from)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv_tt)
        Me.Controls.Add(Me.cmd_show)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(900, 550)
        Me.MinimumSize = New System.Drawing.Size(900, 550)
        Me.Name = "frm_accStatement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cash Book Statement"
        CType(Me.dgv_tt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents DTP_to As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTP_from As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txt_date_to As System.Windows.Forms.TextBox
    Friend WithEvents txt_date_from As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv_tt As System.Windows.Forms.DataGridView
    Friend WithEvents cmd_show As System.Windows.Forms.Button
End Class
