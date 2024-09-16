'****************************************************************************
'    UsefulControl
'    Copyright (C) 2023-2024  CJH
'
'    This program is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <http://www.gnu.org/licenses/>.
'****************************************************************************
'/*****************************************************\
'*                                                     *
'*     UsefulControl - BootForm.vb                     *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Toolbar UI.                                     *
'*                                                     *
'\*****************************************************/

Imports Microsoft.Win32
Imports System.Runtime.InteropServices

Public Class BootForm
    <DllImport("dwmapi.dll")> _
    Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As DwmWindowAttribute, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
    End Function
    'Public Shared Function EnableDarkModeForWindow(ByVal hWnd As IntPtr, ByVal enable As Boolean) As Boolean
    '    Dim darkMode As Integer
    '    darkMode = enable
    '    Dim hr As Integer
    '    Dim i As Integer
    '    'hr = DwmSetWindowAttribute(hWnd, DwmWindowAttribute.UseImmersiveDarkMode, darkMode, sizeof(i))
    '    Return hr >= 0
    'End Function
    Public Shared Function EnableDarkModeForWindow(ByVal hWnd As IntPtr, ByVal enable As Boolean) As Boolean
        Dim attrValue As Integer = If(enable, 1, 0)
        Return (BootForm.DwmSetWindowAttribute(hWnd, DwmWindowAttribute.UseImmersiveDarkMode, attrValue, 4) >= 0)
    End Function

    Public Enum DwmWindowAttribute As UInt32
        NCRenderingEnabled = 1
        NCRenderingPolicy
        TransitionsForceDisabled
        AllowNCPaint
        CaptionButtonBounds
        NonClientRtlLayout
        ForceIconicRepresentation
        Flip3DPolicy
        ExtendedFrameBounds
        HasIconicBitmap
        DisallowPeek
        ExcludedFromPeek
        Cloak
        Cloaked
        FreezeRepresentation
        PassiveUpdateMode
        UseHostBackdropBrush
        UseImmersiveDarkMode = 20
        WindowCornerPreference = 33
        BorderColor
        CaptionColor
        TextColor
        VisibleFrameBorderThickness
        SystemBackdropType
        Last
    End Enum

    Public EnbClose As Integer
    Public a As New System.Drawing.Point
    Public crmd As Integer ' 0=Dark 1=Light
    Public appcolor As Integer ' 0= With System 1= Dark 2= Light
    Public MovedV As Integer
    Public UseMoveV As Integer
    Public b As Integer
    Public disi As System.Drawing.Graphics
    Public NavTargetNames(32) As String
    Public UnSupportDarkSys As Integer
    Public UnSaveData As Integer
    Public DisbFuState As Integer
    Public ShowModeTips As Integer

    Sub disbfu()
        DisbFuState = 1
        Form2.Label8.Text = "部分功能由于被管理员禁用而无法使用。"
        Form2.CheckBox1.Enabled = False
        Form2.CheckBox2.Enabled = False
        Form2.ComboBox2.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Form1.Show()
    End Sub

    Private Sub BootForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        '////////////////////////////////////////////////////////////////////////////////////
        '//
        '//  禁用功能策略注册表读取
        '//
        '////////////////////////////////////////////////////////////////////////////////////
        DisbFuState = 0
        UnSaveData = 0
        ShowModeTips = 1

        Dim cdisbfu As Integer = 0
        Dim cdisbfut As Integer = 0
        Dim unsavefut As Integer = 0
        Try

            Dim plkeycr As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\CJH\Policies\UsefulControl", True)

            Dim disfucrt As Integer = -1
            If (Not plkeycr Is Nothing) Then
                disfucrt = plkeycr.GetValue("DisableFeaturesTip", -1)
                If disfucrt = 1 Then
                    Form2.Label8.Visible = False
                    ShowModeTips = 0
                    cdisbfut = 1
                Else
                    Form2.Label8.Visible = True
                    ShowModeTips = 1
                    cdisbfut = 0
                End If
            End If

            Dim disfucr As Integer
            If (Not plkeycr Is Nothing) Then
                disfucr = plkeycr.GetValue("DisableFeatures", -1)
                If disfucr = 1 Then
                    Call disbfu()
                    cdisbfu = 1
                End If
            End If


            Dim unsavecfgcr As Integer
            If (Not plkeycr Is Nothing) Then
                unsavecfgcr = plkeycr.GetValue("NoSaveProfile", -1)
                If unsavecfgcr = 1 Then
                    UnSaveData = 1
                    If DisbFuState = 1 Then
                        Form2.Label8.Text = "由于策略设置，你的更改将不会被保存。部分功能已被禁用。"
                    Else
                        Form2.Label8.Text = "由于策略设置，你的更改将不会被保存。"
                    End If
                    unsavefut = 1
                End If
            End If

            If (Not plkeycr Is Nothing) Then
                plkeycr.Close()
            End If
        Catch ex As Exception
        End Try

        Try
            Dim plkey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\CJH\Policies\UsefulControl", True)
            Dim disfu As Integer

            If cdisbfut = 0 Then
                Dim disfut As Integer = -1
                If (Not plkey Is Nothing) Then
                    disfut = plkey.GetValue("DisableFeaturesTip", -1)
                    If disfut = 1 Then
                        Form2.Label8.Visible = False
                        ShowModeTips = 0
                    Else
                        Form2.Label8.Visible = True
                        ShowModeTips = 1
                    End If
                End If
            End If

            If cdisbfu = 0 Then
                If (Not plkey Is Nothing) Then
                    disfu = plkey.GetValue("DisableFeatures", -1)
                    If disfu = 1 Then
                        Call disbfu()
                    End If
                End If
            End If

            If unsavefut = 0 Then
                Dim unsavecfg As Integer
                If (Not plkey Is Nothing) Then
                    unsavecfg = plkey.GetValue("NoSaveProfile", -1)
                    If unsavecfg = 1 Then
                        UnSaveData = 1
                        If DisbFuState = 1 Then
                            Form2.Label8.Text = "由于策略设置，你的更改将不会被保存。部分功能已被禁用。"
                        Else
                            Form2.Label8.Text = "由于策略设置，你的更改将不会被保存。"
                        End If
                    End If
                End If
            End If


            If (Not plkey Is Nothing) Then
                plkey.Close()
            End If

        Catch ex As Exception
        End Try

        Try
            If Command().ToLower = "/nosaveprofile" Then
                If DisbFuState = 1 Then
                    Form2.Label8.Text = "当前你的更改将不会被保存。部分功能已被禁用。"
                Else
                    Form2.Label8.Text = "当前你的更改将不会被保存。"
                End If
                UnSaveData = 1
            End If
        Catch ex As Exception
        End Try

        If UnSaveData = 0 And DisbFuState = 0 Then
            Form2.Label8.Visible = False
            ShowModeTips = 0
        End If

        If Not (Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar") Then
            Form2.Button2.Enabled = False
            Form2.Button4.Enabled = False
            Form2.TextBox1.Enabled = False
            Form2.ComboBox1.Enabled = False
        End If

        Try
            AddKey("Software\CJH", "HKCU")
            AddKey("Software\CJH\UsefulControl", "HKCU")
            AddKey("Software\CJH\UsefulControl\Settings", "HKCU")
        Catch ex As Exception
        End Try
        Dim mykey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CJH\UsefulControl\Settings", True)
        Dim myv As Integer
        Try
            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  颜色主题注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            If (Not mykey Is Nothing) Then
                'If (If((regkey.GetValue("") Is Nothing), Nothing, regkey.GetValue("").ToString) <> "AppsUseLightTheme") Then
                'End If
                myv = mykey.GetValue("ColorMode", -1)
                If myv = 0 Then
                    appcolor = 0
                ElseIf myv = -1 Then
                    appcolor = 0

                    AddReg("Software\CJH\UsefulControl\Settings", "ColorMode", 0, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")


                ElseIf myv = 1 Then
                    appcolor = 1
                ElseIf myv = 2 Then
                    appcolor = 2
                End If
            Else
                appcolor = 0

                AddReg("Software\CJH\UsefulControl\Settings", "ColorMode", 0, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")
            End If
            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  系统颜色读取注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            Try
                'Get System Color
                Dim regkey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", True)
                Dim sysacr As Integer
                Try
                    If (Not regkey Is Nothing) Then
                        'If (If((regkey.GetValue("") Is Nothing), Nothing, regkey.GetValue("").ToString) <> "AppsUseLightTheme") Then
                        'End If
                        sysacr = regkey.GetValue("AppsUseLightTheme", -1)
                    Else
                        UnSupportDarkSys = 1
                    End If
                Catch ex As Exception
                    UnSupportDarkSys = 1
                End Try
                If appcolor = 0 Then
                    If (Not regkey Is Nothing) Then
                        'If (If((regkey.GetValue("") Is Nothing), Nothing, regkey.GetValue("").ToString) <> "AppsUseLightTheme") Then
                        'End If
                        If sysacr = 0 Then
                            UnSupportDarkSys = 0
                            crmd = 0
                        ElseIf sysacr = 1 Then
                            UnSupportDarkSys = 0
                            crmd = 1
                        Else
                            UnSupportDarkSys = 1
                            crmd = 1
                        End If
                    Else
                        UnSupportDarkSys = 1
                        crmd = 1
                    End If
                ElseIf appcolor = 1 Then
                    If (Not regkey Is Nothing) Then
                        If sysacr = 0 Then
                            UnSupportDarkSys = 0
                        ElseIf sysacr = 1 Then
                            UnSupportDarkSys = 0
                        Else
                            UnSupportDarkSys = 1
                        End If
                    Else
                        UnSupportDarkSys = 1
                    End If
                    crmd = 1 'Light
                ElseIf appcolor = 2 Then
                    If (Not regkey Is Nothing) Then
                        If sysacr = 0 Then
                            UnSupportDarkSys = 0
                        ElseIf sysacr = 1 Then
                            UnSupportDarkSys = 0
                        Else
                            UnSupportDarkSys = 1
                        End If
                    Else
                        UnSupportDarkSys = 1
                    End If
                    crmd = 0 'Dark
                End If

                regkey.Close()
            Catch ex As Exception
            End Try


            If UnSupportDarkSys = 1 Then
                If appcolor = 0 Then
                    appcolor = 1
                    AddReg("Software\CJH\UsefulControl\Settings", "ColorMode", 1, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")
                    Form2.ComboBox2.SelectedIndex = 0
                ElseIf appcolor = 1 Then
                    Form2.ComboBox2.SelectedIndex = 0
                ElseIf appcolor = 2 Then
                    Form2.ComboBox2.SelectedIndex = 1
                End If

                Form2.ComboBox2.Items.Clear()
                Form2.ComboBox2.Items.AddRange(New Object() {"浅色", "深色"})
            End If

            AddHandler SystemEvents.UserPreferenceChanged, AddressOf SystemEvents_UserPreferenceChanged

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  是否启用拖放注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////

            If (Not mykey Is Nothing) Then
                Me.UseMoveV = mykey.GetValue("EnableDrag", -1)
                If Me.UseMoveV = -1 Then
                    RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                    Me.UseMoveV = 1
                ElseIf Me.UseMoveV > 1 Then
                    RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                    Me.UseMoveV = 1
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                Me.UseMoveV = 1
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  顶置注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////

            Dim UseTop As Integer
            If (Not mykey Is Nothing) Then
                UseTop = mykey.GetValue("AllowTopMost", -1)
                If UseTop = -1 Then
                    RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "AllowTopMost", 1, RegistryValueKind.DWord, "HKCU")
                    Me.TopMost = True
                    Form1.TopMost = True
                ElseIf UseTop = 0 Then
                    Me.TopMost = False
                    Form1.TopMost = False
                ElseIf UseTop = 1 Then
                    Me.TopMost = True
                    Form1.TopMost = True
                ElseIf Me.UseMoveV > 1 Then
                    RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "AllowTopMost", 1, RegistryValueKind.DWord, "HKCU")
                    Me.TopMost = True
                    Form1.TopMost = True
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\UsefulControl\Settings", "AllowTopMost", 1, RegistryValueKind.DWord, "HKCU")
                Me.TopMost = True
                Form1.TopMost = True
            End If

        Catch ex As Exception
            MsgBox("读取注册表设置发生错误。" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "错误")
        End Try


        Call formatcolorcur()
        Call GPLForm.formatcolorcursetmsg()
        Call Form1.formatcolorcur()
        Call Form2.formatcolorcurset()

        NavTargetNames(0) = "TimeControl"
        NavTargetNames(1) = "PowerControl"
        NavTargetNames(2) = "TDocKiller"
        NavTargetNames(3) = "IBoard"
        NavTargetNames(4) = "LockTime"
        NavTargetNames(5) = "PBoard"
        NavTargetNames(6) = "LockTime2"
        NavTargetNames(7) = "PBoard2"
        NavTargetNames(8) = "TimeControl64"
        NavTargetNames(9) = "PowerControl64"
        NavTargetNames(10) = "TDocKiller64"
        NavTargetNames(11) = "IBoard64"
        NavTargetNames(12) = "LockTime64"
        NavTargetNames(13) = "PBoard64"
        NavTargetNames(14) = "LockTime264"
        NavTargetNames(15) = "PBoard264"
        NavTargetNames(30) = "CountDownControl"
        NavTargetNames(31) = "NetworkTestControl"
        NavTargetNames(32) = "LockTimeScr"

        NavTargetNames(16) = "PPTService"
        NavTargetNames(17) = "SeewoCore"
        NavTargetNames(18) = "SeewoFreezeUpdateAssist"
        NavTargetNames(19) = "proxyLayerService"
        NavTargetNames(20) = "ResidentSideBar.Defender"
        NavTargetNames(21) = "ResidentSideBar"
        NavTargetNames(22) = "LastContainer"
        NavTargetNames(23) = "LastContainerDaemon"
        NavTargetNames(24) = "EasiRecorder"
        NavTargetNames(25) = "seewoPincoTeacher"
        NavTargetNames(26) = "seewoPincoTeacherService"
        NavTargetNames(27) = "PincoMirror"
        NavTargetNames(28) = "SeewoService"
        NavTargetNames(29) = "SeewoLauncher"

        Dim Uif As Integer
        Uif = 0
        If Command().ToLower = "/blackscr" Then
            Me.WindowState = FormWindowState.Minimized
            BlackForm.TopMost = True
            BlackForm.ShowDialog()
            Uif = 1
            End
        ElseIf Command().ToLower = "/closescr" Then
            Me.WindowState = FormWindowState.Minimized
            Form1.ChangeMonitorState(Form1.MonitorMode.MonitorOff)
            Uif = 1
            BlackForm.TopMost = True
            BlackForm.ShowDialog()
            End
        ElseIf Command().ToLower = "/fakeshutdown" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False

            Try
                For Each TargetNamea As String In NavTargetNames
                    Shell("taskkill.exe /f /im " & TargetNamea & ".exe", AppWinStyle.Hide)
                    Shell("taskkill.exe /f /im " & TargetNamea & "*", AppWinStyle.Hide)
                Next

                For Each TargetName As String In NavTargetNames
                    'Dim TargetName As String = "fmp" '存储进程名为文本型，注：进程名不加扩展名
                    Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
                    Dim TargetPath As String '存储进程路径为文本型
                    If TargetKill.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
                        For i = 0 To TargetKill.Length - 1
                            TargetPath = TargetKill(i).MainModule.FileName
                            TargetKill(i).Kill()
                        Next
                        'ElseIf TargetKill.Length = 0 Then '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
                        '   Exit Sub
                    ElseIf TargetKill.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
                        TargetKill(0).Kill()
                    End If
                    'Me.Dispose(1) '关闭自身进程
                Next
            Catch ex As Exception
            End Try


            FakeShutdownForm.Timer1.Enabled = True
            Uif = 1
            FakeShutdownForm.FakeMode = 0
            FakeShutdownForm.ShowDialog()
            End
            'ElseIf Command().ToLower = "/fakeshutdownui" Then
            '    FakeShutdownForm.PictureBox1.Visible = True
            '    FakeShutdownForm.Label1.Visible = True
            '    Me.WindowState = FormWindowState.Minimized
            '    FakeShutdownForm.Timer1.Enabled = False
            '    FakeShutdownForm.ShowDialog()
            '    End
        ElseIf Command().ToLower = "/fakeshutdownlenovo" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False

            Try
                For Each TargetNamea As String In NavTargetNames
                    Shell("taskkill.exe /f /im " & TargetNamea & ".exe", AppWinStyle.Hide)
                    Shell("taskkill.exe /f /im " & TargetNamea & "*", AppWinStyle.Hide)
                Next

                For Each TargetName As String In NavTargetNames
                    'Dim TargetName As String = "fmp" '存储进程名为文本型，注：进程名不加扩展名
                    Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
                    Dim TargetPath As String '存储进程路径为文本型
                    If TargetKill.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
                        For i = 0 To TargetKill.Length - 1
                            TargetPath = TargetKill(i).MainModule.FileName
                            TargetKill(i).Kill()
                        Next
                        'ElseIf TargetKill.Length = 0 Then '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
                        '   Exit Sub
                    ElseIf TargetKill.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
                        TargetKill(0).Kill()
                    End If
                    'Me.Dispose(1) '关闭自身进程
                Next
            Catch ex As Exception
            End Try


            FakeShutdownForm.Timer1.Enabled = True
            Uif = 1
            FakeShutdownForm.FakeMode = 1
            FakeShutdownForm.ShowDialog()
            End
            'ElseIf Command().ToLower = "/fakeshutdownui" Then
            '    FakeShutdownForm.PictureBox1.Visible = True
            '    FakeShutdownForm.Label1.Visible = True
            '    Me.WindowState = FormWindowState.Minimized
            '    FakeShutdownForm.Timer1.Enabled = False
            '    FakeShutdownForm.ShowDialog()
            '    End
        ElseIf Command().ToLower = "/locktime" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            LockTimeForm.ShowDialog()
            End
        ElseIf Command().ToLower = "/locktime2" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            LockTime2Form.ShowDialog()
            End
        ElseIf Command().ToLower = "/pboard" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            PBoardForm.ShowDialog()
            End
        ElseIf Command().ToLower = "/pboard2" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            PBoard2Form.ShowDialog()
            End
        ElseIf Command().ToLower = "/iboard" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            IBoardpfrm.ShowDialog()
            End
        ElseIf Command().ToLower = "/volup" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            Call Form1.SendMessageW(Me.Handle, Form1.WM_APPCOMMAND, Me.Handle, New IntPtr(Form1.up))
            End
        ElseIf Command().ToLower = "/voldown" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            Call Form1.SendMessageW(Me.Handle, Form1.WM_APPCOMMAND, Me.Handle, New IntPtr(Form1.down))
            End
        ElseIf Command().ToLower = "/volmute" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            Call Form1.SendMessageW(Me.Handle, Form1.WM_APPCOMMAND, Me.Handle, New IntPtr(Form1.mute))
            End
        ElseIf Command().ToLower = "/blacku" Then
            Me.WindowState = FormWindowState.Minimized
            Me.Hide()
            Me.Visible = False
            Uif = 1
            Try
                For Each TargetNamea As String In NavTargetNames
                    Shell("taskkill.exe /f /im " & TargetNamea & ".exe", AppWinStyle.Hide)
                    Shell("taskkill.exe /f /im *" & TargetNamea & "*", AppWinStyle.Hide)
                Next

                For Each TargetName As String In NavTargetNames
                    'Dim TargetName As String = "fmp" '存储进程名为文本型，注：进程名不加扩展名
                    Dim TargetKill() As Process = Process.GetProcessesByName(TargetName) '从进程名获取进程
                    Dim TargetPath As String '存储进程路径为文本型
                    If TargetKill.Length > 1 Then '判断进程名的数量，如果同名进程数量在2个以上，用For循环关闭进程。
                        For i = 0 To TargetKill.Length - 1
                            TargetPath = TargetKill(i).MainModule.FileName
                            TargetKill(i).Kill()
                        Next
                        'ElseIf TargetKill.Length = 0 Then '判断进程名的数量，没有发现进程直接弹窗。不需要的，可直接删掉该If子句
                        '   Exit Sub
                    ElseIf TargetKill.Length = 1 Then '判断进程名的数量，如果只有一个，就不用For循环
                        TargetKill(0).Kill()
                    End If
                    'Me.Dispose(1) '关闭自身进程
                Next
            Catch ex As Exception
            End Try

            BlackForm.TopMost = False
            BlackForm.ShowDialog()
            End
        End If
        If Uif <> 1 Then
            If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
                Dim createdNew As Boolean
                Dim mutex As System.Threading.Mutex = New System.Threading.Mutex(True, "UsefulControl", createdNew)
                If createdNew = False Then
                    End
                End If
                mutex.ReleaseMutex()
            End If
        End If

        EnbClose = 0
        MovedV = 0
        disi = Me.CreateGraphics()
        Timer1.Enabled = True
        'Me.Height = 39
        'Me.Width = 184




        If Command() <> "" Then
            If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Then
                If disi.DpiX <= 96 Then
                    Me.Height = 29
                    Me.Width = 118
                Else
                    Me.Height = 29 * disi.DpiY * 0.01 '* 1.05
                    Me.Width = 118 * disi.DpiX * 0.01 '* 1.05
                End If
            ElseIf Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
                If disi.DpiX <= 96 Then
                    Me.Height = 118
                    Me.Width = 29
                Else
                    Me.Height = 118 * disi.DpiY * 0.01 '* 1.05
                    Me.Width = 29 * disi.DpiX * 0.01 '* 1.05
                End If
            Else
                If disi.DpiX <= 96 Then
                    Me.Height = 118
                    Me.Width = 29
                Else
                    Me.Height = 118 * disi.DpiY * 0.01 '* 1.05
                    Me.Width = 29 * disi.DpiX * 0.01 '* 1.05
                End If
            End If
        Else
            If disi.DpiX <= 96 Then
                Me.Height = 118
                Me.Width = 29
            Else
                Me.Height = 118 * disi.DpiY * 0.01 '* 1.05
                Me.Width = 29 * disi.DpiX * 0.01 '* 1.05
            End If
        End If


        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Then
            Me.Button1.Text = "小工具>..."
        Else
            Me.Button1.Text = "小工具"
        End If

        If Command().ToLower <> "" Then
            If Command().ToLower = "/leftbar" Then
                a.X = 3 * disi.DpiX * 0.01
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2 - 100 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/topbar" Then
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2
                a.Y = 5 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/bottombar" Then
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) - 45 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/lefttopbar" Then
                a.X = 3 * disi.DpiX * 0.01
                a.Y = 3 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/righttopbar" Then
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) - 3 * disi.DpiX * 0.01
                a.Y = 3 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/leftbottombar" Then
                a.X = 3 * disi.DpiX * 0.01
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) - 45 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/rightbottombar" Then
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) - 3 * disi.DpiX * 0.01
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) - 45 * disi.DpiX * 0.01
            ElseIf Command().ToLower = "/rightbar" Then
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) - 3 * disi.DpiX * 0.01
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2 - 100 * disi.DpiX * 0.01
            Else
                a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) - 3 * disi.DpiX * 0.01
                a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2 - 100 * disi.DpiX * 0.01
            End If
        Else
            a.X = 3 * disi.DpiX * 0.01
            a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2 - 100 * disi.DpiX * 0.01
        End If

        Me.Location = a

        If Not (Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar") Then
            'Me.Hide()
            'Me.WindowState = FormWindowState.Minimized
            Dim SysDpiX As Single = Me.CreateGraphics().DpiX / 96
            Dim SysDpiY As Single = Me.CreateGraphics().DpiY / 96
            Me.Location = New Point(-(Me.Width + 5 * SysDpiX), -(Me.Height + 5 * SysDpiY))
            Form1.Show()
        End If
    End Sub

    Sub formatcolorcur()
        If crmd = 0 Then
            Me.ContextMenuStrip1.BackColor = Color.FromArgb(32, 32, 32)
            Me.ContextMenuStrip1.ForeColor = Color.White
            Me.ContextMenuStrip2.BackColor = Color.FromArgb(32, 32, 32)
            Me.ContextMenuStrip2.ForeColor = Color.White
            Me.BackColor = Color.FromArgb(32, 32, 32)
            Me.ForeColor = Color.White
            Me.Button1.BackColor = Color.Black
            Me.Button1.ForeColor = Color.White
            Me.Button1.FlatAppearance.BorderColor = Color.Black
            Me.Button1.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)
            EnableDarkModeForWindow(Me.Handle, True)
        Else
            Me.Button1.BackColor = Color.White
            Me.Button1.ForeColor = Color.Black
            Me.Button1.FlatAppearance.BorderColor = Color.White
            Me.Button1.FlatAppearance.MouseDownBackColor = Color.LightGray
            Me.Button1.FlatAppearance.MouseOverBackColor = Color.Gainsboro
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.ContextMenuStrip1.BackColor = Color.White
            Me.ContextMenuStrip1.ForeColor = Color.Black
            Me.ContextMenuStrip2.BackColor = Color.White
            Me.ContextMenuStrip2.ForeColor = Color.Black
            EnableDarkModeForWindow(Me.Handle, False)
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MovedV <> 1 Then
            If Me.Location <> a Then
                Me.Location = a
            End If
        End If
    End Sub
    'API移动窗体
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Boolean
    Declare Function ReleaseCapture Lib "user32" Alias "ReleaseCapture" () As Boolean
    Const WM_SYSCOMMAND = &H112
    Const SC_MOVE = &HF010&
    Const HTCAPTION = 2
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If UseMoveV = 1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
            MovedV = 1
        End If
    End Sub
    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        If UseMoveV = 1 Then
            Dim a As New System.Drawing.Point
            a.X = Me.Location.X
            a.Y = Me.Location.Y
            ReleaseCapture()
            SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
            MovedV = 1
            If Me.Location.X = a.X And Me.Location.Y = a.Y Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Call Button1_Click(sender, e)
                End If
            End If
        End If
    End Sub

    Private Sub h30s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles h30s.Click
        Timer2.Interval = 30000
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(7000, "实用工具集合小工具", "实用工具集合小工具当前已隐藏到系统托盘，双击托盘图标或在设定的时间（30秒）之后重新显示。", ToolTipIcon.Info)
        Me.Hide()
        Timer2.Enabled = True
    End Sub

    Private Sub h1m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles h1m.Click
        Timer2.Interval = 60000
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(7000, "实用工具集合小工具", "实用工具集合小工具当前已隐藏到系统托盘，双击托盘图标或在设定的时间（1分钟）之后重新显示。", ToolTipIcon.Info)
        Me.Hide()
        Timer2.Enabled = True
    End Sub

    Private Sub h5m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles h5m.Click
        Timer2.Interval = 300000
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(7000, "实用工具集合小工具", "实用工具集合小工具当前已隐藏到系统托盘，双击托盘图标或在设定的时间（5分钟）之后重新显示。", ToolTipIcon.Info)
        Me.Hide()
        Timer2.Enabled = True
    End Sub

    Private Sub h10m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles h10m.Click
        Timer2.Interval = 600000
        NotifyIcon1.Visible = True
        NotifyIcon1.ShowBalloonTip(7000, "实用工具集合小工具", "实用工具集合小工具当前已隐藏到系统托盘，双击托盘图标或在设定的时间（10分钟）之后重新显示。", ToolTipIcon.Info)
        Me.Hide()
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Show()
        Timer2.Enabled = False
        NotifyIcon1.Visible = False
    End Sub

    Private Sub ext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ext.Click
        'If MessageBox.Show("确定要关闭时钟吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
        'End
        'End If
        Form2.ShowDialog()
    End Sub

    Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If EnbClose <> 1 Then
            'e.Cancel = True
            Select Case (e.CloseReason)
                '应用程序要求关闭窗口
                Case CloseReason.ApplicationExitCall
                    e.Cancel = False '不拦截，响应操作
                    '自身窗口上的关闭按钮
                Case CloseReason.FormOwnerClosing
                    e.Cancel = True '拦截，不响应操作
                    'MDI窗体关闭事件
                Case CloseReason.MdiFormClosing
                    e.Cancel = True '拦截，不响应操作
                    '不明原因的关闭
                Case CloseReason.None
                    e.Cancel = False
                    '任务管理器关闭进程
                Case CloseReason.TaskManagerClosing
                    e.Cancel = True '拦截，不响应操作
                    '用户通过UI关闭窗口或者通过Alt+F4关闭窗口
                Case CloseReason.UserClosing
                    e.Cancel = True '拦截，不响应操作
                    '操作系统准备关机()
                Case (CloseReason.WindowsShutDown)
                    e.Cancel = False '不拦截，响应操作
            End Select
        End If

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Show()
        Else
            Form1.Show()
        End If
        Timer2.Enabled = False
        NotifyIcon1.Visible = False
    End Sub

    Private Sub shtbar_Click(sender As System.Object, e As System.EventArgs) Handles shtbar.Click
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Show()
        Else
            Form1.Show()
        End If
        Timer2.Enabled = False
        NotifyIcon1.Visible = False
    End Sub

    Private Sub SystemEvents_UserPreferenceChanged(ByVal sender As Object, ByVal e As UserPreferenceChangedEventArgs)
        If e.Category = UserPreferenceCategory.General Then
            If appcolor = 0 Then
                'Get System Color
                Dim regkey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", True)
                Dim sysacr As Integer
                If (Not regkey Is Nothing) Then
                    'If (If((regkey.GetValue("") Is Nothing), Nothing, regkey.GetValue("").ToString) <> "AppsUseLightTheme") Then
                    'End If
                    sysacr = regkey.GetValue("AppsUseLightTheme", -1)
                    If sysacr = 0 Then
                        crmd = 0
                    ElseIf sysacr = 1 Then
                        crmd = 1
                    Else
                        crmd = 1
                    End If
                Else
                    crmd = 1
                End If
                regkey.Close()
                Call formatcolorcur()
                Call GPLForm.formatcolorcursetmsg()
                Call Form1.formatcolorcur()
                Call Form2.formatcolorcurset()
            End If
        End If
    End Sub
End Class