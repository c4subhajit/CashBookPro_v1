<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_login))
        Me.chk_change = New System.Windows.Forms.CheckBox
        Me.cmd_exit = New System.Windows.Forms.Button
        Me.cmd_reset = New System.Windows.Forms.Button
        Me.cmd_login = New System.Windows.Forms.Button
        Me.txt_pass = New System.Windows.Forms.TextBox
        Me.txt_user = New System.Windows.Forms.TextBox
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chk_change
        '
        Me.chk_change.AutoSize = True
        Me.chk_change.Location = New System.Drawing.Point(232, 117)
        Me.chk_change.Name = "chk_change"
        Me.chk_change.Size = New System.Drawing.Size(121, 17)
        Me.chk_change.TabIndex = 27
        Me.chk_change.Text = "Change login details"
        Me.chk_change.UseVisualStyleBackColor = True
        '
        'cmd_exit
        '
        Me.cmd_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_exit.Location = New System.Drawing.Point(326, 143)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(52, 22)
        Me.cmd_exit.TabIndex = 26
        Me.cmd_exit.Text = "&Exit"
        '
        'cmd_reset
        '
        Me.cmd_reset.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_reset.Location = New System.Drawing.Point(268, 143)
        Me.cmd_reset.Name = "cmd_reset"
        Me.cmd_reset.Size = New System.Drawing.Size(52, 22)
        Me.cmd_reset.TabIndex = 25
        Me.cmd_reset.Text = "&Reset"
        '
        'cmd_login
        '
        Me.cmd_login.Location = New System.Drawing.Point(210, 143)
        Me.cmd_login.Name = "cmd_login"
        Me.cmd_login.Size = New System.Drawing.Size(52, 22)
        Me.cmd_login.TabIndex = 24
        Me.cmd_login.Text = "&Login"
        '
        'txt_pass
        '
        Me.txt_pass.Location = New System.Drawing.Point(208, 88)
        Me.txt_pass.MaxLength = 20
        Me.txt_pass.Name = "txt_pass"
        Me.txt_pass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_pass.Size = New System.Drawing.Size(170, 20)
        Me.txt_pass.TabIndex = 23
        '
        'txt_user
        '
        Me.txt_user.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_user.Location = New System.Drawing.Point(208, 47)
        Me.txt_user.MaxLength = 20
        Me.txt_user.Name = "txt_user"
        Me.txt_user.Size = New System.Drawing.Size(170, 20)
        Me.txt_user.TabIndex = 21
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Location = New System.Drawing.Point(208, 67)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(170, 18)
        Me.PasswordLabel.TabIndex = 22
        Me.PasswordLabel.Text = "&Password"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Location = New System.Drawing.Point(208, 23)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(170, 21)
        Me.UsernameLabel.TabIndex = 19
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Image = Global.CashBookPro_v1.My.Resources.Resources.Logo_KVK_190x190
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 1)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(190, 190)
        Me.LogoPictureBox.TabIndex = 20
        Me.LogoPictureBox.TabStop = False
        '
        'frm_login
        '
        Me.AcceptButton = Me.cmd_login
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_exit
        Me.ClientSize = New System.Drawing.Size(394, 192)
        Me.ControlBox = False
        Me.Controls.Add(Me.chk_change)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.cmd_reset)
        Me.Controls.Add(Me.cmd_login)
        Me.Controls.Add(Me.txt_pass)
        Me.Controls.Add(Me.txt_user)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(410, 230)
        Me.MinimumSize = New System.Drawing.Size(410, 230)
        Me.Name = "frm_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login to CashBook Pro"
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chk_change As System.Windows.Forms.CheckBox
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents cmd_reset As System.Windows.Forms.Button
    Friend WithEvents cmd_login As System.Windows.Forms.Button
    Friend WithEvents txt_pass As System.Windows.Forms.TextBox
    Friend WithEvents txt_user As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
End Class
