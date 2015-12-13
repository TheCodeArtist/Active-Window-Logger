<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.txtPID = New System.Windows.Forms.TextBox()
        Me.txtProcessName = New System.Windows.Forms.TextBox()
        Me.txtMainWindowTitle = New System.Windows.Forms.TextBox()
        Me.txtWindowTitle = New System.Windows.Forms.TextBox()
        Me.txtWindowStatus = New System.Windows.Forms.TextBox()
        Me.chkStatus = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.tmrMinute = New System.Windows.Forms.Timer(Me.components)
        Me.btnExportSelected = New System.Windows.Forms.Button()
        Me.chkSelect = New System.Windows.Forms.CheckBox()
        Me.btnDeleteChecked = New System.Windows.Forms.Button()
        Me.lvEntries = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tmrPoll
        '
        Me.tmrPoll.Enabled = True
        Me.tmrPoll.Interval = 200
        '
        'txtPID
        '
        Me.txtPID.BackColor = System.Drawing.SystemColors.Control
        Me.txtPID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPID.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtPID.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPID.ForeColor = System.Drawing.Color.Black
        Me.txtPID.Location = New System.Drawing.Point(5, 17)
        Me.txtPID.MinimumSize = New System.Drawing.Size(250, 18)
        Me.txtPID.Name = "txtPID"
        Me.txtPID.ReadOnly = True
        Me.txtPID.ShortcutsEnabled = False
        Me.txtPID.Size = New System.Drawing.Size(250, 15)
        Me.txtPID.TabIndex = 1
        Me.txtPID.TabStop = False
        Me.txtPID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPID.WordWrap = False
        '
        'txtProcessName
        '
        Me.txtProcessName.BackColor = System.Drawing.SystemColors.Control
        Me.txtProcessName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProcessName.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtProcessName.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcessName.ForeColor = System.Drawing.Color.Black
        Me.txtProcessName.Location = New System.Drawing.Point(5, 38)
        Me.txtProcessName.MinimumSize = New System.Drawing.Size(250, 18)
        Me.txtProcessName.Name = "txtProcessName"
        Me.txtProcessName.ReadOnly = True
        Me.txtProcessName.ShortcutsEnabled = False
        Me.txtProcessName.Size = New System.Drawing.Size(250, 15)
        Me.txtProcessName.TabIndex = 2
        Me.txtProcessName.TabStop = False
        Me.txtProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtProcessName.WordWrap = False
        '
        'txtMainWindowTitle
        '
        Me.txtMainWindowTitle.BackColor = System.Drawing.SystemColors.Control
        Me.txtMainWindowTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMainWindowTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtMainWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMainWindowTitle.ForeColor = System.Drawing.Color.Black
        Me.txtMainWindowTitle.Location = New System.Drawing.Point(5, 59)
        Me.txtMainWindowTitle.MinimumSize = New System.Drawing.Size(250, 18)
        Me.txtMainWindowTitle.Name = "txtMainWindowTitle"
        Me.txtMainWindowTitle.ReadOnly = True
        Me.txtMainWindowTitle.ShortcutsEnabled = False
        Me.txtMainWindowTitle.Size = New System.Drawing.Size(250, 15)
        Me.txtMainWindowTitle.TabIndex = 3
        Me.txtMainWindowTitle.TabStop = False
        Me.txtMainWindowTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtMainWindowTitle.WordWrap = False
        '
        'txtWindowTitle
        '
        Me.txtWindowTitle.BackColor = System.Drawing.SystemColors.Control
        Me.txtWindowTitle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWindowTitle.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtWindowTitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowTitle.ForeColor = System.Drawing.Color.Black
        Me.txtWindowTitle.Location = New System.Drawing.Point(5, 80)
        Me.txtWindowTitle.MinimumSize = New System.Drawing.Size(250, 18)
        Me.txtWindowTitle.Name = "txtWindowTitle"
        Me.txtWindowTitle.ReadOnly = True
        Me.txtWindowTitle.ShortcutsEnabled = False
        Me.txtWindowTitle.Size = New System.Drawing.Size(250, 15)
        Me.txtWindowTitle.TabIndex = 4
        Me.txtWindowTitle.TabStop = False
        Me.txtWindowTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtWindowTitle.WordWrap = False
        '
        'txtWindowStatus
        '
        Me.txtWindowStatus.BackColor = System.Drawing.SystemColors.Control
        Me.txtWindowStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtWindowStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtWindowStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowStatus.Location = New System.Drawing.Point(5, 101)
        Me.txtWindowStatus.MinimumSize = New System.Drawing.Size(250, 18)
        Me.txtWindowStatus.Name = "txtWindowStatus"
        Me.txtWindowStatus.ReadOnly = True
        Me.txtWindowStatus.ShortcutsEnabled = False
        Me.txtWindowStatus.Size = New System.Drawing.Size(250, 15)
        Me.txtWindowStatus.TabIndex = 5
        Me.txtWindowStatus.TabStop = False
        Me.txtWindowStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtWindowStatus.WordWrap = False
        '
        'chkStatus
        '
        Me.chkStatus.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkStatus.BackColor = System.Drawing.Color.IndianRed
        Me.chkStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkStatus.ForeColor = System.Drawing.Color.Snow
        Me.chkStatus.Location = New System.Drawing.Point(12, 38)
        Me.chkStatus.Name = "chkStatus"
        Me.chkStatus.Size = New System.Drawing.Size(160, 120)
        Me.chkStatus.TabIndex = 7
        Me.chkStatus.TabStop = False
        Me.chkStatus.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "STOPPED" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkStatus.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPID)
        Me.GroupBox1.Controls.Add(Me.txtProcessName)
        Me.GroupBox1.Controls.Add(Me.txtMainWindowTitle)
        Me.GroupBox1.Controls.Add(Me.txtWindowStatus)
        Me.GroupBox1.Controls.Add(Me.txtWindowTitle)
        Me.GroupBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.GroupBox1.Location = New System.Drawing.Point(178, 33)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 125)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Current Window Details"
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.LemonChiffon
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(18, 121)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(148, 30)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "0 windows" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "since last 0 minutes"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tmrMinute
        '
        Me.tmrMinute.Enabled = True
        Me.tmrMinute.Interval = 60000
        '
        'btnExportSelected
        '
        Me.btnExportSelected.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportSelected.Enabled = False
        Me.btnExportSelected.Location = New System.Drawing.Point(482, 297)
        Me.btnExportSelected.Name = "btnExportSelected"
        Me.btnExportSelected.Size = New System.Drawing.Size(140, 26)
        Me.btnExportSelected.TabIndex = 18
        Me.btnExportSelected.Text = "Export Selected Entries"
        Me.btnExportSelected.UseVisualStyleBackColor = True
        '
        'chkSelect
        '
        Me.chkSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkSelect.Location = New System.Drawing.Point(12, 302)
        Me.chkSelect.Name = "chkSelect"
        Me.chkSelect.Size = New System.Drawing.Size(91, 18)
        Me.chkSelect.TabIndex = 17
        Me.chkSelect.Text = "Select Entries"
        Me.chkSelect.UseVisualStyleBackColor = True
        '
        'btnDeleteChecked
        '
        Me.btnDeleteChecked.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteChecked.Enabled = False
        Me.btnDeleteChecked.Location = New System.Drawing.Point(336, 297)
        Me.btnDeleteChecked.Name = "btnDeleteChecked"
        Me.btnDeleteChecked.Size = New System.Drawing.Size(140, 26)
        Me.btnDeleteChecked.TabIndex = 16
        Me.btnDeleteChecked.Text = "Delete Selected Entries"
        Me.btnDeleteChecked.UseVisualStyleBackColor = True
        '
        'lvEntries
        '
        Me.lvEntries.CheckBoxes = True
        Me.lvEntries.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvEntries.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvEntries.Location = New System.Drawing.Point(12, 164)
        Me.lvEntries.Name = "lvEntries"
        Me.lvEntries.Size = New System.Drawing.Size(610, 127)
        Me.lvEntries.TabIndex = 15
        Me.lvEntries.UseCompatibleStateImageBehavior = False
        Me.lvEntries.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "PID"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Process Name"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Main Window Title"
        Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader3.Width = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Window Title"
        Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader4.Width = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "TimeStamp"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 115
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(462, 33)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(160, 125)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(634, 24)
        Me.MenuStrip1.TabIndex = 20
        Me.MenuStrip1.Text = "MainMenuStrip"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 335)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnExportSelected)
        Me.Controls.Add(Me.chkSelect)
        Me.Controls.Add(Me.btnDeleteChecked)
        Me.Controls.Add(Me.lvEntries)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.chkStatus)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(640, 360)
        Me.Name = "frmMain"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Active Window Logger"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer
    Friend WithEvents txtPID As System.Windows.Forms.TextBox
    Friend WithEvents txtProcessName As System.Windows.Forms.TextBox
    Friend WithEvents txtMainWindowTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtWindowTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtWindowStatus As System.Windows.Forms.TextBox
    Friend WithEvents chkStatus As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Private WithEvents tmrMinute As System.Windows.Forms.Timer
    Friend WithEvents btnExportSelected As System.Windows.Forms.Button
    Friend WithEvents chkSelect As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeleteChecked As System.Windows.Forms.Button
    Friend WithEvents lvEntries As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
