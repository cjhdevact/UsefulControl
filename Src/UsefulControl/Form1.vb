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
'*     UsefulControl - Form1.vb                        *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Main Form.                                      *
'*                                                     *
'\*****************************************************/
Imports System.Runtime.InteropServices

Public Class Form1
    <DllImport("user32.dll")> _
    Private Shared Function SendMessage(ByVal hWnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    Const SC_MONITORPOWER As Integer = &HF170
    Const WM_SYSCOMMAND As Integer = &H112
    Public Enum MonitorMode As Integer
        MonitorOn = -1
        MonitorStandby = 1
        MonitorOff = 2
    End Enum
    Public Sub ChangeMonitorState(ByVal mode As MonitorMode)
        SendMessage(-1, WM_SYSCOMMAND, SC_MONITORPOWER, CInt(mode))
    End Sub
    'Private Sub MonitorOff()
    '    ChangeMonitorState(MonitorMode.MonitorOff)
    'End Sub
    'Private Sub MonitorOn()
    '    ChangeMonitorState(MonitorMode.MonitorOn)
    'End Sub
    'Private Sub MonitorStandBy()
    '    ChangeMonitorState(MonitorMode.MonitorStandby)
    'End Sub

    Public mute As Integer = &H80000
    Public up As Integer = &HA0000
    Public down As Integer = &H90000
    Public WM_APPCOMMAND As Integer = &H319
    <DllImport("user32.dll")> _
    Public Shared Function SendMessageW(hWnd As IntPtr, Msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Sub formatcolorcur()
        If BootForm.crmd = 0 Then
            Me.BackColor = Color.FromArgb(32, 32, 32)
            Me.ForeColor = Color.White

            Me.Button1.BackColor = Color.Black
            Me.Button1.ForeColor = Color.White
            Me.Button1.FlatAppearance.BorderColor = Color.Black
            Me.Button1.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button2.BackColor = Color.Black
            Me.Button2.ForeColor = Color.White
            Me.Button2.FlatAppearance.BorderColor = Color.Black
            Me.Button2.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button3.BackColor = Color.Black
            Me.Button3.ForeColor = Color.White
            Me.Button3.FlatAppearance.BorderColor = Color.Black
            Me.Button3.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button4.BackColor = Color.Black
            Me.Button4.ForeColor = Color.White
            Me.Button4.FlatAppearance.BorderColor = Color.Black
            Me.Button4.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button4.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button5.BackColor = Color.Black
            Me.Button5.ForeColor = Color.White
            Me.Button5.FlatAppearance.BorderColor = Color.Black
            Me.Button5.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button5.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button6.BackColor = Color.Black
            Me.Button6.ForeColor = Color.White
            Me.Button6.FlatAppearance.BorderColor = Color.Black
            Me.Button6.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button6.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button7.BackColor = Color.Black
            Me.Button7.ForeColor = Color.White
            Me.Button7.FlatAppearance.BorderColor = Color.Black
            Me.Button7.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button7.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button8.BackColor = Color.Black
            Me.Button8.ForeColor = Color.White
            Me.Button8.FlatAppearance.BorderColor = Color.Black
            Me.Button8.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button8.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button9.BackColor = Color.Black
            Me.Button9.ForeColor = Color.White
            Me.Button9.FlatAppearance.BorderColor = Color.Black
            Me.Button9.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button9.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button10.BackColor = Color.Black
            Me.Button10.ForeColor = Color.White
            Me.Button10.FlatAppearance.BorderColor = Color.Black
            Me.Button10.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button10.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button11.BackColor = Color.Black
            Me.Button11.ForeColor = Color.White
            Me.Button11.FlatAppearance.BorderColor = Color.Black
            Me.Button11.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button11.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button12.BackColor = Color.Black
            Me.Button12.ForeColor = Color.White
            Me.Button12.FlatAppearance.BorderColor = Color.Black
            Me.Button12.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button12.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button13.BackColor = Color.Black
            Me.Button13.ForeColor = Color.White
            Me.Button13.FlatAppearance.BorderColor = Color.Black
            Me.Button13.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button13.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button14.BackColor = Color.Black
            Me.Button14.ForeColor = Color.White
            Me.Button14.FlatAppearance.BorderColor = Color.Black
            Me.Button14.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button14.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button15.BackColor = Color.Black
            Me.Button15.ForeColor = Color.White
            Me.Button15.FlatAppearance.BorderColor = Color.Black
            Me.Button15.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button15.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button16.BackColor = Color.Black
            Me.Button16.ForeColor = Color.White
            Me.Button16.FlatAppearance.BorderColor = Color.Black
            Me.Button16.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button16.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button17.BackColor = Color.Black
            Me.Button17.ForeColor = Color.White
            Me.Button17.FlatAppearance.BorderColor = Color.Black
            Me.Button17.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button17.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button18.BackColor = Color.Black
            Me.Button18.ForeColor = Color.White
            Me.Button18.FlatAppearance.BorderColor = Color.Black
            Me.Button18.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button18.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button19.BackColor = Color.Black
            Me.Button19.ForeColor = Color.White
            Me.Button19.FlatAppearance.BorderColor = Color.Black
            Me.Button19.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button19.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button20.BackColor = Color.Black
            Me.Button20.ForeColor = Color.White
            Me.Button20.FlatAppearance.BorderColor = Color.Black
            Me.Button20.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button20.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button21.BackColor = Color.Black
            Me.Button21.ForeColor = Color.White
            Me.Button21.FlatAppearance.BorderColor = Color.Black
            Me.Button21.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button21.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button22.BackColor = Color.Black
            Me.Button22.ForeColor = Color.White
            Me.Button22.FlatAppearance.BorderColor = Color.Black
            Me.Button22.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button22.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button23.BackColor = Color.Black
            Me.Button23.ForeColor = Color.White
            Me.Button23.FlatAppearance.BorderColor = Color.Black
            Me.Button23.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button23.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button24.BackColor = Color.Black
            Me.Button24.ForeColor = Color.White
            Me.Button24.FlatAppearance.BorderColor = Color.Black
            Me.Button24.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button24.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Button25.BackColor = Color.Black
            Me.Button25.ForeColor = Color.White
            Me.Button25.FlatAppearance.BorderColor = Color.Black
            Me.Button25.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button25.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64)

            Me.Opacity = 0.75

            BootForm.EnableDarkModeForWindow(Me.Handle, True)
        Else
            Me.Button1.BackColor = Color.Gainsboro
            Me.Button1.ForeColor = Color.Black
            Me.Button1.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button1.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button1.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button2.BackColor = Color.Gainsboro
            Me.Button2.ForeColor = Color.Black
            Me.Button2.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button2.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button2.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button3.BackColor = Color.Gainsboro
            Me.Button3.ForeColor = Color.Black
            Me.Button3.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button3.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button3.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button4.BackColor = Color.Gainsboro
            Me.Button4.ForeColor = Color.Black
            Me.Button4.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button4.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button4.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button5.BackColor = Color.Gainsboro
            Me.Button5.ForeColor = Color.Black
            Me.Button5.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button5.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button5.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button6.BackColor = Color.Gainsboro
            Me.Button6.ForeColor = Color.Black
            Me.Button6.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button6.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button6.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button7.BackColor = Color.Gainsboro
            Me.Button7.ForeColor = Color.Black
            Me.Button7.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button7.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button7.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button8.BackColor = Color.Gainsboro
            Me.Button8.ForeColor = Color.Black
            Me.Button8.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button8.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button8.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button9.BackColor = Color.Gainsboro
            Me.Button9.ForeColor = Color.Black
            Me.Button9.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button9.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button9.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button10.BackColor = Color.Gainsboro
            Me.Button10.ForeColor = Color.Black
            Me.Button10.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button10.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button10.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button11.BackColor = Color.Gainsboro
            Me.Button11.ForeColor = Color.Black
            Me.Button11.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button11.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button11.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button12.BackColor = Color.Gainsboro
            Me.Button12.ForeColor = Color.Black
            Me.Button12.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button12.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button12.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button13.BackColor = Color.Gainsboro
            Me.Button13.ForeColor = Color.Black
            Me.Button13.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button13.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button13.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button14.BackColor = Color.Gainsboro
            Me.Button14.ForeColor = Color.Black
            Me.Button14.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button14.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button14.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button15.BackColor = Color.Gainsboro
            Me.Button15.ForeColor = Color.Black
            Me.Button15.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button15.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button15.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button16.BackColor = Color.Gainsboro
            Me.Button16.ForeColor = Color.Black
            Me.Button16.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button16.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button16.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button17.BackColor = Color.Gainsboro
            Me.Button17.ForeColor = Color.Black
            Me.Button17.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button17.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button17.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button18.BackColor = Color.Gainsboro
            Me.Button18.ForeColor = Color.Black
            Me.Button18.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button18.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button18.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button19.BackColor = Color.Gainsboro
            Me.Button19.ForeColor = Color.Black
            Me.Button19.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button19.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button19.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button20.BackColor = Color.Gainsboro
            Me.Button20.ForeColor = Color.Black
            Me.Button20.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button20.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button20.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button21.BackColor = Color.Gainsboro
            Me.Button21.ForeColor = Color.Black
            Me.Button21.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button21.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button21.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button22.BackColor = Color.Gainsboro
            Me.Button22.ForeColor = Color.Black
            Me.Button22.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button22.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button22.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button23.BackColor = Color.Gainsboro
            Me.Button23.ForeColor = Color.Black
            Me.Button23.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button23.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button23.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button24.BackColor = Color.Gainsboro
            Me.Button24.ForeColor = Color.Black
            Me.Button24.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button24.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button24.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.Button25.BackColor = Color.Gainsboro
            Me.Button25.ForeColor = Color.Black
            Me.Button25.FlatAppearance.BorderColor = Color.Gainsboro
            Me.Button25.FlatAppearance.MouseDownBackColor = Color.Gray
            Me.Button25.FlatAppearance.MouseOverBackColor = Color.LightGray

            Me.BackColor = Color.White
            Me.Opacity = 0.8
            Me.ForeColor = Color.Black
            BootForm.EnableDarkModeForWindow(Me.Handle, False)
        End If
    End Sub

    'powershell (Add-Type '[DllImport(\"user32.dll\")]^public static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);' -Name a -Pas)::SendMessage(-1,0x0112,0xF170,2)
    Public a As New System.Drawing.Point
    Public ShutdownStateV As Integer
    Public RestartStateV As Integer
    Public RenS As Integer
    Public CurState As Integer
    Public MovedV As Integer
    Public UseMoveV As Integer
    Public NavTargetNames(30) As String
    Public DocTargetNames(96) As String

    Public CloseAppThread As New System.Threading.Thread(AddressOf CloseApp)
    Delegate Sub MyBut(ByVal StateText As String)
    'API移动窗体
    Declare Function ReleaseCapture Lib "user32" Alias "ReleaseCapture" () As Boolean
    Const SC_MOVE = &HF010&
    Const HTCAPTION = 2
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
    End Sub
    Private Sub Label1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call formatcolorcur()

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
        NavTargetNames(30) = "CountDownControl"

        DocTargetNames(0) = "WINWORD"
        DocTargetNames(1) = "EXCEL"
        DocTargetNames(2) = "POWERPNT"
        DocTargetNames(3) = "wps"
        DocTargetNames(4) = "et"
        DocTargetNames(5) = "wpp"
        DocTargetNames(6) = "wpspdf"
        DocTargetNames(7) = "wpsoffice"
        DocTargetNames(8) = "wpspic"
        DocTargetNames(9) = "Wechat"
        DocTargetNames(10) = "QQ"
        DocTargetNames(11) = "EasiNote"
        DocTargetNames(12) = "EasiCamera"
        DocTargetNames(13) = "NimoNavigator"
        DocTargetNames(14) = "CamShow"
        DocTargetNames(15) = "ScreenBoard"
        DocTargetNames(16) = "Nimo"
        DocTargetNames(17) = "HiteCamera"
        DocTargetNames(18) = "HitePai"
        DocTargetNames(19) = "Lenovo.Smart.BoardTools"
        DocTargetNames(20) = "Lenovo.Smart.SubjectTools"
        DocTargetNames(21) = "SmartClass"
        DocTargetNames(22) = "SmartClassPlayer"
        DocTargetNames(23) = "SmartClassService"
        DocTargetNames(24) = "SmartClassShell"
        DocTargetNames(25) = "SmartRecorder"
        DocTargetNames(26) = "BlackboardWriting"
        DocTargetNames(27) = "DesktopDraw"
        DocTargetNames(28) = "HTDCom"
        DocTargetNames(29) = "ScreenRecord"
        DocTargetNames(30) = "VSKY"
        DocTargetNames(31) = "db"
        DocTargetNames(32) = "msedge"
        DocTargetNames(33) = "chrome"
        DocTargetNames(34) = "firefox"
        DocTargetNames(35) = "360chrome"
        DocTargetNames(36) = "360se"
        DocTargetNames(37) = "theworld"
        DocTargetNames(38) = "liebao"
        DocTargetNames(39) = "qingniao"
        DocTargetNames(40) = "Twinkstar"
        DocTargetNames(41) = "UCBrowser"
        DocTargetNames(42) = "UCService"
        DocTargetNames(43) = "2345Explorer"
        DocTargetNames(44) = "quark"
        DocTargetNames(45) = "iexplore"
        DocTargetNames(46) = "QQBrowser"
        DocTargetNames(47) = "Chromium"
        DocTargetNames(48) = "SeewoBrowser"
        DocTargetNames(49) = "360chromex"
        DocTargetNames(50) = "360aibrowser"
        DocTargetNames(51) = "SLBrowser"
        DocTargetNames(52) = "SLB"
        DocTargetNames(53) = "SogouExplorer"
        DocTargetNames(54) = "MicrosoftEdge"
        DocTargetNames(55) = "PotPlayer"
        DocTargetNames(56) = "PotPlayerMini"
        DocTargetNames(57) = "PotPlayerMini64"
        DocTargetNames(58) = "Microsoft.Media.Player"
        DocTargetNames(59) = "Groove"
        DocTargetNames(60) = "wmplayer"
        DocTargetNames(61) = "Video.UI"
        DocTargetNames(62) = "QQPlayer"
        DocTargetNames(63) = "baofeng"
        DocTargetNames(64) = "Cbox"
        DocTargetNames(65) = "qyplayer"
        DocTargetNames(66) = "QQLive"
        DocTargetNames(67) = "kugou"
        DocTargetNames(68) = "kuwomusic"
        DocTargetNames(69) = "StormPlayer"
        DocTargetNames(70) = "YOUKU"
        DocTargetNames(71) = "YoukuNplayer"
        DocTargetNames(72) = "AlibabaProtectCon"
        DocTargetNames(73) = "cloudmusic"
        DocTargetNames(74) = "PhotosApp"
        DocTargetNames(75) = "PhotosService"
        DocTargetNames(76) = "Microsoft.Photos"
        DocTargetNames(77) = "rundll32"
        DocTargetNames(78) = "dllhost"
        DocTargetNames(79) = "WindowsCamera"
        DocTargetNames(80) = "SoundRec"
        DocTargetNames(81) = "SoundRecorder"
        DocTargetNames(82) = "CalculatorApp"
        DocTargetNames(83) = "calc"
        DocTargetNames(84) = "notepad"
        DocTargetNames(85) = "mspaint"
        DocTargetNames(86) = "SnippingTool"
        DocTargetNames(87) = "ScreenSketch"
        DocTargetNames(88) = "winrar"
        DocTargetNames(89) = "winzip"
        DocTargetNames(90) = "7z"
        DocTargetNames(91) = "7zFM"
        DocTargetNames(92) = "bandzip"
        DocTargetNames(93) = "nanazip"
        DocTargetNames(94) = "haozip"
        DocTargetNames(95) = "360zip"
        DocTargetNames(96) = "kuaizip"

        UseMoveV = 0
        MovedV = 0
        Dim disi As Graphics = Me.CreateGraphics()
        'Me.Height = 39
        'Me.Width = 184
        If disi.DpiX <= 96 Then
            Me.Height = 383
            Me.Width = 640
        Else
            Me.Height = 383 * disi.DpiY * 0.01 * 1.05
            Me.Width = 640 * disi.DpiX * 0.01 * 1.05
        End If
        'Me.Height = Label1.Height
        'Me.Width = Label1.Width
        'a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) - 3 * disi.DpiX * 0.01
        If System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width <> 0 Then
            a.X = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2
        Else
            a.X = 1
        End If
        If System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height <> 0 Then
            a.Y = (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2
        Else
            a.Y = 1
        End If
        Me.Location = a
        RestartStateV = 0
        ShutdownStateV = 0
        RenS = 0
        CurState = 0
        'ContextMenuStrip1.Font = New Font(ContextMenuStrip1.Font.Name, 8.25F * 96.0F / CreateGraphics().DpiX, ContextMenuStrip1.Font.Style, ContextMenuStrip1.Font.Unit, ContextMenuStrip1.Font.GdiCharSet, ContextMenuStrip1.Font.GdiVerticalFont)
        'Font = New Font(Font.Name, 8.25F * 96.0F / CreateGraphics().DpiX, Font.Style, Font.Unit, Font.GdiCharSet, Font.GdiVerticalFont)
    End Sub

    'Private Sub Me_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
    '    'e.Cancel = True
    '    Select Case (e.CloseReason)
    '        '应用程序要求关闭窗口
    '        Case CloseReason.ApplicationExitCall
    '            e.Cancel = False '不拦截，响应操作
    '            '自身窗口上的关闭按钮
    '        Case CloseReason.FormOwnerClosing
    '            e.Cancel = True '拦截，不响应操作
    '            'MDI窗体关闭事件
    '        Case CloseReason.MdiFormClosing
    '            e.Cancel = True '拦截，不响应操作
    '            '不明原因的关闭
    '        Case CloseReason.None
    '            e.Cancel = False
    '            '任务管理器关闭进程
    '        Case CloseReason.TaskManagerClosing
    '            e.Cancel = True '拦截，不响应操作
    '            '用户通过UI关闭窗口或者通过Alt+F4关闭窗口
    '        Case CloseReason.UserClosing
    '            e.Cancel = True '拦截，不响应操作
    '            '操作系统准备关机()
    '        Case (CloseReason.WindowsShutDown)
    '            e.Cancel = False '不拦截，响应操作
    '    End Select

    'End Sub

    'Private Sub Me_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
    'Me.Dispose()
    'End Sub

    '重启
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If RestartStateV = 0 Then
            RestartStateV = 1
            Button2.Enabled = False
            Form2.Button3.Enabled = False
            Timer3.Enabled = True
            CurState = 1
            RenS = 15
            Button1.Text = "取消(15s)"
        Else
            RestartStateV = 0
            Button2.Enabled = True
            Form2.Button3.Enabled = True
            Timer3.Enabled = False
            CurState = 0
            RenS = 0
            Button1.Text = "重启"
        End If
    End Sub
    '关机
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ShutdownStateV = 0 Then
            ShutdownStateV = 1
            Button1.Enabled = False
            Form2.Button3.Enabled = False
            Timer3.Enabled = True
            CurState = 2
            RenS = 15
            Button2.Text = "取消(15s)"
        Else
            ShutdownStateV = 0
            Button1.Enabled = True
            'Button1.Locked = False
            Form2.Button3.Enabled = True
            Timer3.Enabled = False
            CurState = 0
            RenS = 0
            Button2.Text = "关机"
        End If
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        If RenS = 0 Then
            RenS = RenS - 1
            If CurState = 1 Then 'Restart
                Shell("shutdown.exe /r /t 0 /f", AppWinStyle.Hide)
            ElseIf CurState = 2 Then 'Shutdown
                Shell("shutdown.exe /s /t 0 /f", AppWinStyle.Hide)
            End If
        Else
            RenS = RenS - 1
            If CurState = 1 Then 'Restart
                Button1.Text = "取消(" & RenS & "s)"
            ElseIf CurState = 2 Then 'Shutdown
                Button2.Text = "取消(" & RenS & "s)"
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Form2.Show()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        'SendMessage(-1, 422, 170560, 2)
        'Shell("powershell (Add-Type '[DllImport(\""user32.dll\"")]^public static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);' -Name a -Pas)::SendMessage(-1,0x0112,0xF170,2)", AppWinStyle.Hide, False)
        ChangeMonitorState(MonitorMode.MonitorOff)
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        'Shell("powershell ""[Void][System.Reflection.Assembly]::LoadWithPartialName('System.Windows.Forms');[System.Windows.Forms.Application]::SetSuspendState('Suspend', $false, $false);""", AppWinStyle.Hide)
        System.Windows.Forms.Application.SetSuspendState("Suspend", False, False)
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Shell("rundll32 user32.dll,LockWorkStation", AppWinStyle.Hide)
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If MessageBox.Show("你确定休眠吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            Shell("rundll32 powrProf.dll,SetSuspendState", AppWinStyle.Hide)
        End If
    End Sub
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        BlackForm.TopMost = True
        BlackForm.Show()
        ChangeMonitorState(MonitorMode.MonitorOff)
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        BlackForm.TopMost = True
        BlackForm.ShowDialog()
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        FakeShutdownForm.PictureBox1.Visible = True
        FakeShutdownForm.Label1.Visible = True
        FakeShutdownForm.Timer1.Enabled = False
        FakeShutdownForm.ShowDialog()
    End Sub

    Private Declare Function timeGetTime Lib "winmm.dll" () As Long
    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Me.Hide()
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

        FakeShutdownForm.Timer1.Enabled = True
        FakeShutdownForm.FakeMode = 0
        FakeShutdownForm.ShowDialog()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        If MessageBox.Show("确定进入希沃纯净模式吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

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

            Shell("taskkill.exe /f /im UsefulControl.exe", AppWinStyle.Hide)
            End
        End If

    End Sub

    Sub SetButText(ByVal StateText As String)
        Button14.Text = StateText
    End Sub

    Sub CloseApp()
        Me.Invoke(New MyBut(AddressOf SetButText), "正在关闭课件")
        'Button1.Enabled = True
        'MessageBox.Show("正在关闭课件，在按钮""正在关闭""文字变化之前，请不要再点击关闭按钮，以免重复关闭。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Try
            For Each TargetNamea As String In DocTargetNames
                Shell("taskkill.exe /im " & TargetNamea & ".exe", AppWinStyle.Hide)
                Shell("taskkill.exe /im " & TargetNamea & "*", AppWinStyle.Hide)
                Shell("taskkill.exe /f /im " & TargetNamea & ".exe", AppWinStyle.Hide)
                Shell("taskkill.exe /f /im " & TargetNamea & "*", AppWinStyle.Hide, True)
            Next

            For Each TargetName As String In DocTargetNames
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
        Me.Invoke(New MyBut(AddressOf SetButText), "一键关闭课件")
    End Sub

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        If Not Button14.Text = "正在关闭课件" Then
            If MessageBox.Show("确定关闭课件吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                CloseAppThread.Start()
            End If
        End If
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Me.Hide()
        LockTimeForm.Show()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        Me.Hide()
        LockTime2Form.Show()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Me.Hide()
        PBoardForm.Show()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        Me.Hide()
        PBoard2Form.Show()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Me.Hide()
        IBoardpfrm.Show()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Me.Hide()
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
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(up))
    End Sub

    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(down))
    End Sub

    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(mute))
    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        Me.Hide()
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

        FakeShutdownForm.Timer1.Enabled = True
        FakeShutdownForm.FakeMode = 1
        FakeShutdownForm.ShowDialog()
        If Command().ToLower = "/topbar" Or Command().ToLower = "/bottombar" Or Command().ToLower = "/lefttopbar" Or Command().ToLower = "/righttopbar" Or Command().ToLower = "/leftbottombar" Or Command().ToLower = "/rightbottombar" Or Command().ToLower = "/leftbar" Or Command().ToLower = "/rightbar" Then
            Me.Close()
            BootForm.WindowState = FormWindowState.Normal
            BootForm.Show()
        Else
            End
        End If
    End Sub
End Class
