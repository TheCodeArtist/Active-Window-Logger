Option Explicit On

Public Class frmMain

    Private Sub tmrMinute_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMinute.Tick
        logStatus()
    End Sub

    Private Sub tmrPoll_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPoll.Tick
        logActiveWindow()
        logStatus()
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
        initAppLaunchTime()
    End Sub


    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        WTSUnRegisterSessionNotification(Me.Handle)
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

    Private Sub lvEntries_ItemChecked(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvEntries.ItemChecked

        ' Keep the list and "Select All" checkbox in sync.
        If (lvEntries.Items.Count <> lvEntries.CheckedItems.Count) And (lvEntries.CheckedItems.Count > 0) Then
            chkSelect.CheckState = CheckState.Indeterminate
        ElseIf lvEntries.Items.Count = lvEntries.CheckedItems.Count Then
            chkSelect.CheckState = CheckState.Checked
        ElseIf lvEntries.CheckedItems.Count = 0 Then
            chkSelect.CheckState = CheckState.Unchecked
        End If

        ' Depending upon whther any items in the list are checked,
        ' Enable/Disable the delete and export buttons.
        If lvEntries.CheckedItems.Count > 0 Then
            btnDeleteChecked.Enabled = True
            btnExportSelected.Enabled = True
        Else
            btnDeleteChecked.Enabled = False
            btnExportSelected.Enabled = False
        End If

    End Sub

    Private Sub btnDeleteChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteChecked.Click
        Dim prompt As String

        ' Prepare prompt string with appropriate plularity of entry/entries.
        If lvEntries.CheckedItems.Count = 1 Then
            prompt = "1 entry will be deleted from the list."
        Else
            prompt = Str(lvEntries.CheckedItems.Count) + " entries will be deleted from the list."
        End If

        ' Prompt user for confirmation and if user cancels, exit without doing anything further.
        Dim UserChoice As MsgBoxResult = MsgBox(prompt + " Continue?...",
                                                MsgBoxStyle.Exclamation + MsgBoxStyle.ApplicationModal + MsgBoxStyle.OkCancel,
                                                "Delete Selected Entries")
        If UserChoice = vbCancel Then
            Exit Sub
        End If

        ' Make one pass through the list and delete each list entry that is checked
        For i = (lvEntries.Items.Count - 1) To 0 Step -1
            If lvEntries.Items(i).Checked = True Then
                lvEntries.Items.RemoveAt(i)
            End If
        Next

    End Sub

    Private Sub chkSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkSelect.Click

        Me.Cursor = Cursors.WaitCursor

        If chkSelect.CheckState = CheckState.Checked Then
            Dim item As ListViewItem
            For Each item In lvEntries.Items
                My.Application.DoEvents()
                item.Checked = True
            Next
        ElseIf chkSelect.CheckState = CheckState.Unchecked Then
            Dim item As ListViewItem
            For Each item In lvEntries.CheckedItems
                My.Application.DoEvents()
                item.Checked = False
            Next
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnExportSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSelected.Click

        ' Prompt to select location to export
        Dim sfd As New SaveFileDialog With { _
        .Title = "Choose file to save to", _
        .FileName = Format(Now, "dd-MMM-yyyy-hh-mm-tt") + "-activity.csv", _
        .Filter = "CSV (*.csv)|*.csv", _
        .FilterIndex = 0, _
        .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}

        '****************************************************************
        ' show the dialog + export window log unless cancelled
        '****************************************************************
        If sfd.ShowDialog = DialogResult.OK Then

            Dim headers = (From ch In lvEntries.Columns _
                     Let header = DirectCast(ch, ColumnHeader) _
                     Select header.Text).ToArray()

            Dim items() = (From item In lvEntries.CheckedItems _
                  Let lvi = DirectCast(item, ListViewItem) _
                  Select (From subitem In lvi.SubItems _
                      Let si = DirectCast(subitem, ListViewItem.ListViewSubItem) _
                      Select si.Text).ToArray()).ToArray()

            Dim table As String = String.Join(Chr(31) & ",", headers) & Chr(30) & Environment.NewLine
            For Each a In items
                table &= String.Join(Chr(31) & ",", a) & Chr(30) & Environment.NewLine
            Next

            table = table.TrimEnd(CChar(vbCr), CChar(vbLf))

            ' TODO: Issue#11: Add retry/abort here in case file write fails (eg. if file open in other app)
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