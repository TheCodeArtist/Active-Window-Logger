Option Explicit On
Imports System.Data
Imports System.Data.OleDb

Public Class frmMain

    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Integer

    Private Declare Function WTSRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr, ByVal THISSESS As Long) As Long
    Private Declare Function WTSUnRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr) As Long

    Private Const NOTIFY_FOR_ALL_SESSIONS As Integer = 1
    Private Const NOTIFY_FOR_THIS_SESSION As Integer = 0
    Private Const WM_WTSSESSION_CHANGE As Integer = &H2B1

    Private Enum WTS
        CONSOLE_CONNECT = 1
        CONSOLE_DISCONNECT = 2
        REMOTE_CONNECT = 3
        REMOTE_DISCONNECT = 4
        SESSION_LOGON = 5
        SESSION_LOGOFF = 6
        SESSION_LOCK = 7
        SESSION_UNLOCK = 8
        SESSION_REMOTE_CONTROL = 9
    End Enum

    ' Set during app launch.
    ' Used to track how long the app has been runnning. 
    Dim AppLaunchTime As New Date

    Private Sub tmrMinute_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMinute.Tick
        lblStatus.Text = lvEntries.Items.Count.ToString + " windows" + vbCrLf + "since last " + DateDiff(DateInterval.Minute, AppLaunchTime, DateTime.UtcNow).ToString + " minutes"
    End Sub

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick

        ' Get the Handle to the Current Foreground Window
        Dim hWnd As IntPtr = GetForegroundWindow()
        If hWnd = IntPtr.Zero Then Exit Sub

        ' Find the Length of the Window's Title
        Dim TitleLength As Integer
        TitleLength = GetWindowTextLength(hWnd)

        ' Find the Window's Title
        Dim WindowTitle As String = StrDup(TitleLength + 1, "*")
        GetWindowText(hWnd, WindowTitle, TitleLength + 1)

        ' Find the PID of the Application that Owns the Window
        Dim pid As Integer = 0
        GetWindowThreadProcessId(hWnd, pid)
        If pid = 0 Then Exit Sub

        ' Get the actual PROCESS from the PID
        Dim proc As Process = Process.GetProcessById(pid)
        If proc Is Nothing Then Exit Sub

        ' Populate the textboxes with current data
        txtPID.Text = pid.ToString
        txtProcessName.Text = proc.ProcessName
        txtMainWindowTitle.Text = proc.MainWindowTitle
        txtWindowTitle.Text = WindowTitle

        ' Ignore own Window
        If txtWindowTitle.Text.Equals(Me.Text) Then
            txtWindowStatus.Text = "Ignoring " + Me.Text
            Exit Sub
        End If

        ' If WindowsTitles of new entry and last entry match, skip/consolidate
        If lvEntries.Items.Count Then
            If txtWindowTitle.Text.Equals(lvEntries.Items(0).SubItems(3).Text) Then
                txtWindowStatus.Text = "Same window already active"
                Exit Sub
            End If
        End If

        ' Populate the listview with new entry of above current data
        Dim newEntry As ListViewItem
        newEntry = lvEntries.Items.Insert(0, txtPID.Text)
        newEntry.SubItems.Add(txtProcessName.Text)
        newEntry.SubItems.Add(txtMainWindowTitle.Text)
        newEntry.SubItems.Add(txtWindowTitle.Text)
        newEntry.SubItems.Add(Format(Now, "yyyy/MM/dd HH:mm:ss"))
        txtWindowStatus.Text = "Started tracking active window"

        lblStatus.Text = lvEntries.Items.Count.ToString + " windows" + vbCrLf + "since last " + DateDiff(DateInterval.Minute, AppLaunchTime, DateTime.UtcNow).ToString + " minutes"

    End Sub

    Private Sub chkStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStatus.CheckedChanged
        If chkStatus.Checked Then
            chkStatus.BackColor = Color.LimeGreen
            chkStatus.Text = vbCrLf + "Logging Active Windows" + vbCrLf + vbCrLf + "( click to pause )"
            tmrPoll.Enabled = True
        Else
            chkStatus.BackColor = Color.IndianRed
            chkStatus.Text = vbCrLf + "Paused" + vbCrLf + vbCrLf + "( click to resume logging )"
            tmrPoll.Enabled = False
        End If
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        WTSRegisterSessionNotification(Me.Handle, NOTIFY_FOR_ALL_SESSIONS)
        chkStatus.Checked = True
        AppLaunchTime = DateTime.UtcNow
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Dim newEntry As ListViewItem

        Select Case m.Msg
            Case WM_WTSSESSION_CHANGE
                Select Case m.WParam.ToInt32
                    Case WTS.CONSOLE_CONNECT
                        'Debug.Print("A session was connected to the console session.")
                    Case WTS.CONSOLE_DISCONNECT
                        'Debug.Print("A session was disconnected from the console session.")
                    Case WTS.REMOTE_CONNECT
                        'Debug.Print("A session was connected to the remote session.")
                    Case WTS.REMOTE_DISCONNECT
                        'Debug.Print("A session was disconnected from the remote session.")
                    Case WTS.SESSION_LOGON
                        'Debug.Print("A user has logged on to the session.")
                    Case WTS.SESSION_LOGOFF
                        'Debug.Print("A user has logged off the session.")
                    Case WTS.SESSION_LOCK
                        'Debug.Print("A session has been locked.")
                        ' Populate the listview with Windows locked entry
                        newEntry = lvEntries.Items.Insert(0, "-1")
                        newEntry.SubItems.Add("Microsoft")
                        newEntry.SubItems.Add("Windows")
                        newEntry.SubItems.Add("Locked")
                        newEntry.SubItems.Add(Format(Now, "yyyy/MM/dd HH:mm:ss"))
                    Case WTS.SESSION_UNLOCK
                        'Debug.Print("A session has been unlocked.")
                        ' Populate the listview with Windows locked entry
                        newEntry = lvEntries.Items.Insert(0, "-1")
                        newEntry.SubItems.Add("Microsoft")
                        newEntry.SubItems.Add("Windows")
                        newEntry.SubItems.Add("Unlocked")
                        newEntry.SubItems.Add(Format(Now, "yyyy/MM/dd HH:mm:ss"))
                    Case WTS.SESSION_REMOTE_CONTROL
                        'Debug.Print("A session has changed its remote controlled status. To determine the status, call GetSystemMetrics and check the SM_REMOTECONTROL metric.")
                End Select
        End Select

        MyBase.WndProc(m)

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        WTSUnRegisterSessionNotification(Me.Handle)
    End Sub

    Private Sub lvEntries_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEntries.ItemChecked
        If (lvEntries.Items.Count <> lvEntries.CheckedItems.Count) And (lvEntries.CheckedItems.Count > 0) Then
            chkSelect.CheckState = CheckState.Indeterminate
        ElseIf lvEntries.Items.Count = lvEntries.CheckedItems.Count Then
            chkSelect.CheckState = CheckState.Checked
        ElseIf lvEntries.CheckedItems.Count = 0 Then
            chkSelect.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub btnDeleteChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteChecked.Click
        For i = (lvEntries.Items.Count - 1) To 0 Step -1
            If lvEntries.Items(i).Checked = True Then
                lvEntries.Items.RemoveAt(i)
            End If
        Next
    End Sub

    Private Sub chkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelect.Click
        If chkSelect.CheckState = CheckState.Checked Then
            Dim item As ListViewItem
            For Each item In lvEntries.Items
                item.Checked = True
            Next
        ElseIf chkSelect.CheckState = CheckState.Unchecked Then
            Dim item As ListViewItem
            For Each item In lvEntries.CheckedItems
                item.Checked = False
            Next
        End If
    End Sub

    Private Sub btnExportSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSelected.Click

        ' Prompt to select location to export
        Dim sfd As New SaveFileDialog With { _
        .Title = "Choose file to save to", _
        .FileName = Format(Now, "dd-MMM-yyyy-hh-mm-tt") + "-activity.csv", _
        .Filter = "CSV (*.csv)|*.csv", _
        .FilterIndex = 0, _
        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}

        'show the dialog + display the results in a msgbox unless cancelled

        If sfd.ShowDialog = DialogResult.OK Then

            Dim headers = (From ch In lvEntries.Columns _
                     Let header = DirectCast(ch, ColumnHeader) _
                     Select header.Text).ToArray()

            Dim items() = (From item In lvEntries.CheckedItems _
                  Let lvi = DirectCast(item, ListViewItem) _
                  Select (From subitem In lvi.SubItems _
                      Let si = DirectCast(subitem, ListViewItem.ListViewSubItem) _
                      Select si.Text).ToArray()).ToArray()

            Dim table As String = String.Join(",", headers) & Environment.NewLine
            For Each a In items
                table &= String.Join(Chr(31) & ",", a) & Chr(30) & Environment.NewLine
            Next

            table = table.TrimEnd(CChar(vbCr), CChar(vbLf))

            ' Add retry/abort here in case file write fails (eg. if file open in other app)
            IO.File.WriteAllText(sfd.FileName, table)

        End If

    End Sub

    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        lvEntries.Width = Me.Width - 30
        lvEntries.Height = Me.Height - 230      ' form - ( menubar + top-frame + bottom buttons + spacings)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub
End Class