Module loggingModule

    '****************************************************************
    ' window monitoring 
    '****************************************************************
    Private Declare Function GetForegroundWindow Lib "user32.dll" () As IntPtr
    Private Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hWnd As IntPtr, ByVal WinTitle As String, ByVal MaxLength As Integer) As Integer
    Private Declare Function GetWindowTextLength Lib "user32.dll" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Integer

    Public Sub logStatus()
        frmMain.lblStatus.Text = frmMain.lvEntries.Items.Count.ToString + " windows" + vbCrLf + "since last " + DateDiff(DateInterval.Minute, AppLaunchTime, DateTime.UtcNow).ToString + " minutes"
    End Sub

    Public Sub logActiveWindow()

        With frmMain

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
            .txtPID.Text = pid.ToString
            .txtProcessName.Text = proc.ProcessName
            .txtMainWindowTitle.Text = proc.MainWindowTitle
            .txtWindowTitle.Text = WindowTitle

            '****************************************************************
            ' Ignore own app windows
            '****************************************************************
            If .txtWindowTitle.Text.Equals(frmMain.Text) Then
                .txtWindowStatus.Text = "Ignoring " + frmMain.Text
                Exit Sub
            End If

            If .txtWindowTitle.Text.Equals(frmAbout.Text) Then
                .txtWindowStatus.Text = "Ignoring " + frmAbout.Text
                Exit Sub
            End If

            '****************************************************************
            ' Consolidate windowsTitles of new and last entries match.
            '****************************************************************
            If .lvEntries.Items.Count Then
                If .txtWindowTitle.Text.Equals(.lvEntries.Items(0).SubItems(3).Text) Then
                    .txtWindowStatus.Text = "Same window already active"
                    Exit Sub
                End If
            End If

            '****************************************************************
            ' Populate listview with the new entry of current active window
            '****************************************************************
            Dim newEntry As ListViewItem
            newEntry = .lvEntries.Items.Insert(0, .txtPID.Text)
            newEntry.SubItems.Add(.txtProcessName.Text)
            newEntry.SubItems.Add(.txtMainWindowTitle.Text)
            newEntry.SubItems.Add(.txtWindowTitle.Text)
            newEntry.SubItems.Add(Format(Now, "yyyy/MM/dd HH:mm:ss"))
            .txtWindowStatus.Text = "Started tracking active window"

        End With

    End Sub

    '****************************************************************
    ' system lock/unlock monitoring
    '****************************************************************
    Public Declare Function WTSRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr, ByVal THISSESS As Long) As Long
    Public Declare Function WTSUnRegisterSessionNotification Lib "Wtsapi32" (ByVal hWnd As IntPtr) As Long

    Public Const NOTIFY_FOR_ALL_SESSIONS As Integer = 1
    Public Const NOTIFY_FOR_THIS_SESSION As Integer = 0
    Public Const WM_WTSSESSION_CHANGE As Integer = &H2B1

    Public Enum WTS
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

    '****************************************************************
    ' Used to track how long the app has been runnning. 
    '****************************************************************
    Dim AppLaunchTime As New Date

    Public Sub initAppLaunchTime()
        AppLaunchTime = DateTime.UtcNow
    End Sub

End Module
