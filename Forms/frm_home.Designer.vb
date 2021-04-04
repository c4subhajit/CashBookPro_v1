<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_home))
        Me.MenuStrip_home = New System.Windows.Forms.MenuStrip
        Me.START_TSMI = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB_CD = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB_CD_CDU = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB_CD_CDE = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB_CD_CDD = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_KVKCB_STAT = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_CS = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_TRANS = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_ST = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_ST_DB = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_ST_DB_BDB = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_ST_DB_RDB = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_ABT = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_LO = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_EXIT = New System.Windows.Forms.ToolStripMenuItem
        Me.OFD_db = New System.Windows.Forms.OpenFileDialog
        Me.ContextMenuStrip_home = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TSMI_CAL = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_NOTE = New System.Windows.Forms.ToolStripMenuItem
        Me.TSMI_LOGOUT = New System.Windows.Forms.ToolStripMenuItem
        Me.FBD_dbBackUp = New System.Windows.Forms.FolderBrowserDialog
        Me.Timer_Home = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip_home = New System.Windows.Forms.StatusStrip
        Me.TSSL_homeClock = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip_home.SuspendLayout()
        Me.ContextMenuStrip_home.SuspendLayout()
        Me.StatusStrip_home.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip_home
        '
        Me.MenuStrip_home.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MenuStrip_home.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.START_TSMI})
        Me.MenuStrip_home.Location = New System.Drawing.Point(0, 637)
        Me.MenuStrip_home.Name = "MenuStrip_home"
        Me.MenuStrip_home.Size = New System.Drawing.Size(984, 25)
        Me.MenuStrip_home.TabIndex = 6
        Me.MenuStrip_home.Text = "MenuStrip1"
        '
        'START_TSMI
        '
        Me.START_TSMI.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_KVKCB, Me.TSMI_CS, Me.TSMI_TRANS, Me.TSMI_ST, Me.TSMI_ABT, Me.TSMI_LO, Me.TSMI_EXIT})
        Me.START_TSMI.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.START_TSMI.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.START_TSMI.Name = "START_TSMI"
        Me.START_TSMI.Size = New System.Drawing.Size(60, 21)
        Me.START_TSMI.Text = "&START"
        '
        'TSMI_KVKCB
        '
        Me.TSMI_KVKCB.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_KVKCB_CD, Me.TSMI_KVKCB_STAT})
        Me.TSMI_KVKCB.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSMI_KVKCB.Name = "TSMI_KVKCB"
        Me.TSMI_KVKCB.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_KVKCB.Text = "&KVK Cashbook"
        '
        'TSMI_KVKCB_CD
        '
        Me.TSMI_KVKCB_CD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_KVKCB_CD_CDU, Me.TSMI_KVKCB_CD_CDE, Me.TSMI_KVKCB_CD_CDD})
        Me.TSMI_KVKCB_CD.Name = "TSMI_KVKCB_CD"
        Me.TSMI_KVKCB_CD.Size = New System.Drawing.Size(184, 22)
        Me.TSMI_KVKCB_CD.Text = "Cash &Details"
        '
        'TSMI_KVKCB_CD_CDU
        '
        Me.TSMI_KVKCB_CD_CDU.Name = "TSMI_KVKCB_CD_CDU"
        Me.TSMI_KVKCB_CD_CDU.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_KVKCB_CD_CDU.Text = "Cash Detail &Update"
        '
        'TSMI_KVKCB_CD_CDE
        '
        Me.TSMI_KVKCB_CD_CDE.Name = "TSMI_KVKCB_CD_CDE"
        Me.TSMI_KVKCB_CD_CDE.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_KVKCB_CD_CDE.Text = "Cash Detail &Edit"
        '
        'TSMI_KVKCB_CD_CDD
        '
        Me.TSMI_KVKCB_CD_CDD.Name = "TSMI_KVKCB_CD_CDD"
        Me.TSMI_KVKCB_CD_CDD.Size = New System.Drawing.Size(174, 22)
        Me.TSMI_KVKCB_CD_CDD.Text = "Cash Detail &Delete"
        '
        'TSMI_KVKCB_STAT
        '
        Me.TSMI_KVKCB_STAT.Name = "TSMI_KVKCB_STAT"
        Me.TSMI_KVKCB_STAT.Size = New System.Drawing.Size(184, 22)
        Me.TSMI_KVKCB_STAT.Text = "Cashbook &Statement"
        '
        'TSMI_CS
        '
        Me.TSMI_CS.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSMI_CS.Name = "TSMI_CS"
        Me.TSMI_CS.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_CS.Text = "&Current Status"
        '
        'TSMI_TRANS
        '
        Me.TSMI_TRANS.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TSMI_TRANS.Name = "TSMI_TRANS"
        Me.TSMI_TRANS.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_TRANS.Text = "&Transactions"
        '
        'TSMI_ST
        '
        Me.TSMI_ST.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_ST_DB})
        Me.TSMI_ST.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSMI_ST.Name = "TSMI_ST"
        Me.TSMI_ST.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_ST.Text = "&System Tools"
        '
        'TSMI_ST_DB
        '
        Me.TSMI_ST_DB.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_ST_DB_BDB, Me.TSMI_ST_DB_RDB})
        Me.TSMI_ST_DB.Name = "TSMI_ST_DB"
        Me.TSMI_ST_DB.Size = New System.Drawing.Size(154, 22)
        Me.TSMI_ST_DB.Text = "&Database Tasks"
        '
        'TSMI_ST_DB_BDB
        '
        Me.TSMI_ST_DB_BDB.Name = "TSMI_ST_DB_BDB"
        Me.TSMI_ST_DB_BDB.Size = New System.Drawing.Size(164, 22)
        Me.TSMI_ST_DB_BDB.Text = "&Backup Database"
        '
        'TSMI_ST_DB_RDB
        '
        Me.TSMI_ST_DB_RDB.Name = "TSMI_ST_DB_RDB"
        Me.TSMI_ST_DB_RDB.Size = New System.Drawing.Size(164, 22)
        Me.TSMI_ST_DB_RDB.Text = "&Restore Database"
        '
        'TSMI_ABT
        '
        Me.TSMI_ABT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TSMI_ABT.Name = "TSMI_ABT"
        Me.TSMI_ABT.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_ABT.Text = "&About"
        '
        'TSMI_LO
        '
        Me.TSMI_LO.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TSMI_LO.Name = "TSMI_LO"
        Me.TSMI_LO.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_LO.Text = "&Logout"
        '
        'TSMI_EXIT
        '
        Me.TSMI_EXIT.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TSMI_EXIT.Name = "TSMI_EXIT"
        Me.TSMI_EXIT.Size = New System.Drawing.Size(152, 22)
        Me.TSMI_EXIT.Text = "&Exit"
        '
        'ContextMenuStrip_home
        '
        Me.ContextMenuStrip_home.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSMI_CAL, Me.TSMI_NOTE, Me.TSMI_LOGOUT})
        Me.ContextMenuStrip_home.Name = "ContextMenuStrip_home"
        Me.ContextMenuStrip_home.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ContextMenuStrip_home.Size = New System.Drawing.Size(129, 70)
        '
        'TSMI_CAL
        '
        Me.TSMI_CAL.Name = "TSMI_CAL"
        Me.TSMI_CAL.Size = New System.Drawing.Size(128, 22)
        Me.TSMI_CAL.Text = "&Calculator"
        '
        'TSMI_NOTE
        '
        Me.TSMI_NOTE.Name = "TSMI_NOTE"
        Me.TSMI_NOTE.Size = New System.Drawing.Size(128, 22)
        Me.TSMI_NOTE.Text = "&Notepad"
        '
        'TSMI_LOGOUT
        '
        Me.TSMI_LOGOUT.Name = "TSMI_LOGOUT"
        Me.TSMI_LOGOUT.Size = New System.Drawing.Size(128, 22)
        Me.TSMI_LOGOUT.Text = "&Logout"
        '
        'FBD_dbBackUp
        '
        Me.FBD_dbBackUp.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Timer_Home
        '
        Me.Timer_Home.Enabled = True
        Me.Timer_Home.Interval = 1000
        '
        'StatusStrip_home
        '
        Me.StatusStrip_home.Dock = System.Windows.Forms.DockStyle.Top
        Me.StatusStrip_home.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSSL_homeClock})
        Me.StatusStrip_home.Location = New System.Drawing.Point(0, 0)
        Me.StatusStrip_home.Name = "StatusStrip_home"
        Me.StatusStrip_home.Size = New System.Drawing.Size(984, 22)
        Me.StatusStrip_home.TabIndex = 7
        '
        'TSSL_homeClock
        '
        Me.TSSL_homeClock.AutoSize = False
        Me.TSSL_homeClock.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSSL_homeClock.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.TSSL_homeClock.Name = "TSSL_homeClock"
        Me.TSSL_homeClock.Size = New System.Drawing.Size(191, 17)
        '
        'frm_home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CashBookPro_v1.My.Resources.Resources.Logo_KVK
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(984, 662)
        Me.ContextMenuStrip = Me.ContextMenuStrip_home
        Me.Controls.Add(Me.MenuStrip_home)
        Me.Controls.Add(Me.StatusStrip_home)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip_home
        Me.MinimumSize = New System.Drawing.Size(1000, 700)
        Me.Name = "frm_home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CashBook Pro v1.0"
        Me.MenuStrip_home.ResumeLayout(False)
        Me.MenuStrip_home.PerformLayout()
        Me.ContextMenuStrip_home.ResumeLayout(False)
        Me.StatusStrip_home.ResumeLayout(False)
        Me.StatusStrip_home.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip_home As System.Windows.Forms.MenuStrip
    Friend WithEvents START_TSMI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB_CD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB_CD_CDU As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB_CD_CDE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB_CD_CDD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_KVKCB_STAT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_CS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_TRANS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ST As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ST_DB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ST_DB_BDB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_ABT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_LO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_EXIT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OFD_db As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuStrip_home As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TSMI_CAL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_NOTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSMI_LOGOUT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FBD_dbBackUp As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Timer_Home As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip_home As System.Windows.Forms.StatusStrip
    Friend WithEvents TSSL_homeClock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TSMI_ST_DB_RDB As System.Windows.Forms.ToolStripMenuItem
End Class
