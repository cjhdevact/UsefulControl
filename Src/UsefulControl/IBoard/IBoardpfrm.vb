'****************************************************************************
'    IBoard
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
'*     IBoard - pfrm.vb                                *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     The picture show form.                          *
'*                                                     *
'\*****************************************************/
Imports Microsoft.Win32

Public Class IBoardpfrm
    Public pfile As String
    Public pst As Integer
    Public Hsate As Integer
    Public ImgAutoLoad As Integer
    Public MyTitle As String
    Public UseMoveV As Integer
    Public LoadLastImage As Integer
    Public UnSaveData As Integer
    Public DisbFuState As Integer
    Public ShowModeTips As Integer

    Public scaleX As Single
    Public scaleY As Single
    'API移动窗体
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Boolean
    Declare Function ReleaseCapture Lib "user32" Alias "ReleaseCapture" () As Boolean
    Const WM_SYSCOMMAND = &H112
    Const SC_MOVE = &HF010&
    Const HTCAPTION = 2
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If UseMoveV = 1 Then
            ReleaseCapture()
            SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
        End If
    End Sub
    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        If UseMoveV = 1 Then
            Dim a As New System.Drawing.Point
            a.X = Me.Location.X
            a.Y = Me.Location.Y
            ReleaseCapture()
            SendMessage(Me.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0)
            If Me.Location.X = a.X And Me.Location.Y = a.Y Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    'Dim stopwatch As New Stopwatch()
                    'stopwatch.Start() ' 开始计时
                    'If e.Button = Windows.Forms.MouseButtons.Left Then
                    '    stopwatch.Stop()
                    '    Dim latency As Long = stopwatch.ElapsedMilliseconds
                    '    If latency < 1000 Then
                    '        Call PictureBox1_DoubleClick(sender, e)
                    '    End If
                    'End If
                    'stopwatch.Stop()
                    Call PictureBox1_DoubleClick(sender, e)
                End If
            End If
        End If
    End Sub

    'Public Sub ExitIBoard()
    '    IBoardprms.Close()
    '    Me.Close()
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        IBoardprms.ShowDialog()
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If pst = 0 Then
            pst = 1
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            FlowLayoutPanel1.Visible = False
            Me.Text = ""
        Else
            pst = 0
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            FlowLayoutPanel1.Visible = True
            Me.Text = "图片展示"
        End If
    End Sub

    Sub disbfu()
        DisbFuState = 1
        IBoardprms.Label11.Text = "部分功能由于被管理员禁用而无法使用。"
        IBoardprms.CheckBox1.Enabled = False
        IBoardprms.CheckBox2.Enabled = False
        IBoardprms.CheckBox3.Enabled = False
        IBoardprms.CheckBox4.Enabled = False
        IBoardprms.ComboBox2.Enabled = False
        IBoardprms.Button2.Enabled = False
        IBoardprms.Button8.Visible = False
    End Sub

    Private Sub PictureBox1_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragDrop
        LoadImage(e.Data.GetData(DataFormats.FileDrop)(0))
    End Sub
    Private Sub PictureBox1_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles PictureBox1.DragEnter
        e.Effect = DragDropEffects.Link ' 接受拖放数据，启用拖放效果
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

    Private Sub pfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' 获取当前窗体的 DPI
        Dim currentDpiX As Single = Me.CreateGraphics().DpiX
        Dim currentDpiY As Single = Me.CreateGraphics().DpiY

        'If currentDpiX <> 96 OrElse currentDpiY <> 96 Then
        'End If
        '计算缩放比例
        scaleX = currentDpiX / 96
        scaleY = currentDpiY / 96

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

            Dim plkeycr As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Policies\CJH\IBoard", True)

            Dim disfucrt As Integer = -1
            If (Not plkeycr Is Nothing) Then
                disfucrt = plkeycr.GetValue("DisableFeaturesTip", -1)
                If disfucrt = 1 Then
                    IBoardprms.Label11.Visible = False
                    ShowModeTips = 0
                    cdisbfut = 1
                ElseIf disfucrt = 0 Then
                    IBoardprms.Label11.Visible = True
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
                        IBoardprms.Label11.Text = "由于策略设置，你的更改将不会被保存。部分功能已被禁用。"
                    Else
                        IBoardprms.Label11.Text = "由于策略设置，你的更改将不会被保存。"
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
            Dim plkey As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Policies\CJH\IBoard", True)
            Dim disfu As Integer

            If cdisbfut = 0 Then
                Dim disfut As Integer = -1
                If (Not plkey Is Nothing) Then
                    disfut = plkey.GetValue("DisableFeaturesTip", -1)
                    If disfut = 1 Then
                        IBoardprms.Label11.Visible = False
                        ShowModeTips = 0
                    ElseIf disfut = 0 Then
                        IBoardprms.Label11.Visible = True
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
                            IBoardprms.Label11.Text = "由于策略设置，你的更改将不会被保存。部分功能已被禁用。"
                        Else
                            IBoardprms.Label11.Text = "由于策略设置，你的更改将不会被保存。"
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
                    IBoardprms.Label11.Text = "当前你的更改将不会被保存。部分功能已被禁用。"
                Else
                    IBoardprms.Label11.Text = "当前你的更改将不会被保存。"
                End If
                UnSaveData = 1
            End If
        Catch ex As Exception
        End Try

        If UnSaveData = 0 And DisbFuState = 0 Then
            IBoardprms.Label11.Visible = False
            ShowModeTips = 0
        End If

        Try
            AddKey("Software\CJH", "HKCU")
            AddKey("Software\CJH\IBoard", "HKCU")
            AddKey("Software\CJH\IBoard\Settings", "HKCU")
        Catch ex As Exception
        End Try
        Try
            Dim mykey As RegistryKey = Registry.CurrentUser.OpenSubKey("Software\CJH\IBoard\Settings", True)
            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  图片显示模式注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            Dim myv As Integer
            If (Not mykey Is Nothing) Then
                myv = mykey.GetValue("ImageMode", -1)
                If myv > 0 And myv <= 4 Then
                    IBoardprms.ComboBox2.SelectedIndex = myv
                    PictureBox1.SizeMode = myv
                Else
                    IBoardprms.ComboBox2.SelectedIndex = 1
                    PictureBox1.SizeMode = 1
                    AddReg("Software\CJH\IBoard\Settings", "ImageMode", 1, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")
                End If
            Else
                IBoardprms.ComboBox2.SelectedIndex = 1
                PictureBox1.SizeMode = 1
                AddReg("Software\CJH\IBoard\Settings", "ImageMode", 1, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  窗口顶置注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            Dim UseTop As Integer
            If (Not mykey Is Nothing) Then
                UseTop = mykey.GetValue("AllowTopMost", -1)
                If UseTop = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "AllowTopMost", 0, RegistryValueKind.DWord, "HKCU")
                    Me.TopMost = False
                    IBoardprms.TopMost = False
                ElseIf UseTop = 0 Then
                    Me.TopMost = False
                    IBoardprms.TopMost = False
                ElseIf UseTop = 1 Then
                    Me.TopMost = True
                    IBoardprms.TopMost = True
                ElseIf UseTop > 1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "AllowTopMost", 0, RegistryValueKind.DWord, "HKCU")
                    Me.TopMost = False
                    IBoardprms.TopMost = False
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "AllowTopMost", 0, RegistryValueKind.DWord, "HKCU")
                Me.TopMost = False
                IBoardprms.TopMost = False
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  是否启用图片移动注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////

            If (Not mykey Is Nothing) Then
                Me.UseMoveV = mykey.GetValue("EnableMove", -1)
                If Me.UseMoveV = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableMove", 0, RegistryValueKind.DWord, "HKCU")
                    Me.UseMoveV = 0
                ElseIf Me.UseMoveV > 1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableMove", 0, RegistryValueKind.DWord, "HKCU")
                    Me.UseMoveV = 0
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableMove", 0, RegistryValueKind.DWord, "HKCU")
                Me.UseMoveV = 0
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  是否启用图片拖放注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            Dim myb As Integer
            If (Not mykey Is Nothing) Then
                myb = mykey.GetValue("EnableDrag", -1)
                If myb = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                    PictureBox1.AllowDrop = True
                ElseIf myb = 0 Then
                    PictureBox1.AllowDrop = False
                ElseIf myb = 1 Then
                    PictureBox1.AllowDrop = True
                ElseIf Me.UseMoveV > 1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                    PictureBox1.AllowDrop = True
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
                PictureBox1.AllowDrop = True
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  背景颜色注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            Dim tfntcr As Integer
            If (Not mykey Is Nothing) Then
                tfntcr = mykey.GetValue("BkgColorR", -1)
                If tfntcr = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorR", Me.BackColor.R, RegistryValueKind.DWord, "HKCU")
                    tfntcr = Me.BackColor.R
                    If tfntcr > 255 Then
                        RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorR", Me.BackColor.R, RegistryValueKind.DWord, "HKCU")
                        tfntcr = Me.BackColor.R
                    End If
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorR", Me.BackColor.R, RegistryValueKind.DWord, "HKCU")
                tfntcr = Me.BackColor.R
            End If

            Dim tfntcg As Integer
            If (Not mykey Is Nothing) Then
                tfntcg = mykey.GetValue("BkgColorG", -1)
                If tfntcg = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorG", Me.BackColor.G, RegistryValueKind.DWord, "HKCU")
                    tfntcg = Me.BackColor.G
                    If tfntcg > 255 Then
                        RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorG", Me.BackColor.G, RegistryValueKind.DWord, "HKCU")
                        tfntcg = Me.BackColor.G
                    End If
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorG", Me.BackColor.G, RegistryValueKind.DWord, "HKCU")
                tfntcg = Me.BackColor.G
            End If

            Dim tfntcb As Integer
            If (Not mykey Is Nothing) Then
                tfntcb = mykey.GetValue("BkgColorB", -1)
                If tfntcb = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorB", Me.BackColor.B, RegistryValueKind.DWord, "HKCU")
                    tfntcb = Me.BackColor.B
                    If tfntcb > 255 Then
                        RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorB", Me.BackColor.B, RegistryValueKind.DWord, "HKCU")
                        tfntcb = Me.BackColor.B
                    End If
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorB", Me.BackColor.B, RegistryValueKind.DWord, "HKCU")
                tfntcb = Me.BackColor.B
            End If

            Me.BackColor = Color.FromArgb(tfntcr, tfntcg, tfntcb)
            IBoardprms.ColorDialog1.Color = Me.BackColor

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  是否加载上一次图片注册表读取
            '//
            '////////////////////////////////////////////////////////////////////////////////////

            If (Not mykey Is Nothing) Then
                Me.LoadLastImage = mykey.GetValue("LoadLastImage", -1)
                If Me.LoadLastImage = -1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "LoadLastImage", 0, RegistryValueKind.DWord, "HKCU")
                    Me.LoadLastImage = 1
                ElseIf Me.LoadLastImage > 1 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "LoadLastImage", 0, RegistryValueKind.DWord, "HKCU")
                    Me.LoadLastImage = 0
                End If
            Else
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "LoadLastImage", 0, RegistryValueKind.DWord, "HKCU")
                Me.LoadLastImage = 0
            End If

            '////////////////////////////////////////////////////////////////////////////////////
            '//
            '//  读取上一次打开图片的路径
            '//
            '////////////////////////////////////////////////////////////////////////////////////
            If Me.LoadLastImage = 1 Then
                If (Not mykey Is Nothing) Then
                    IBoardprms.TextBox1.Text = mykey.GetValue("ImagePath", "-1")
                    If System.IO.File.Exists(IBoardprms.TextBox1.Text) = False Then
                        RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", "", RegistryValueKind.String, "HKCU")
                        IBoardprms.TextBox1.Text = ""
                    End If
                    If IBoardprms.TextBox1.Text = "-1" Then
                        RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", "", RegistryValueKind.String, "HKCU")
                        IBoardprms.TextBox1.Text = ""
                    End If
                Else
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", "", RegistryValueKind.String, "HKCU")
                    IBoardprms.TextBox1.Text = ""
                End If
            Else
                IBoardprms.TextBox1.Text = ""
            End If
        Catch ex As Exception
        End Try



        '------------------------------------------------------------------------------
        pst = 0
        Hsate = 0
        ImgAutoLoad = 0
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.png") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.png")
            ElseIf System.IO.File.Exists(Application.StartupPath & "\ShowImage.jpg") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.jpg")
            ElseIf System.IO.File.Exists(Application.StartupPath & "\ShowImage.bmp") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.bmp")
            ElseIf System.IO.File.Exists(Application.StartupPath & "\ShowImage.tiff") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.tiff")
            ElseIf System.IO.File.Exists(Application.StartupPath & "\ShowImage.ico") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.ico")
            ElseIf System.IO.File.Exists(Application.StartupPath & "\ShowImage.gif") = True Then
                LoadImage(Application.StartupPath & "\ShowImage.gif")
            ElseIf LoadLastImage = 1 Then
                If System.IO.File.Exists(IBoardprms.TextBox1.Text) = True Then
                    LoadImage(IBoardprms.TextBox1.Text)
                End If
            End If
        End If
        If ImgAutoLoad = 1 Then
            pst = 1
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            FlowLayoutPanel1.Visible = False
            Me.Location = New Point(SystemInformation.PrimaryMonitorSize.Width - Me.Width - 15, 15)
        End If
    End Sub

    Sub LoadImage(ByVal pfile1 As String)
        If System.IO.File.Exists(pfile1) = True Then
            Try
                pfile = pfile1
                PictureBox1.Load(pfile)
                IBoardprms.TextBox1.Text = pfile1
                NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                CFileState.Text = "已打开文件：" & pfile
                ImgAutoLoad = 1
                If UnSaveData = 0 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", pfile, RegistryValueKind.String, "HKCU")
                End If
            Catch ex As Exception
                pfile = pfile1
                IBoardprms.TextBox1.Text = ""
                NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                CFileState.Text = "未打开文件。"
                ImgAutoLoad = 0
                MessageBox.Show("图片加载失败。", "图片展示小工具 - 错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        If ImgAutoLoad = 1 Then
            'Me.Text = ""

            'If PictureBox1.Image.Height <> 0 Then
            '    If PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
            '        Me.Height = PictureBox1.Image.Height
            '    ElseIf PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
            '        Me.Height = PictureBox1.Image.Height / 2
            '    End If
            'End If

            'If PictureBox1.Image.Width <> 0 Then
            '    If PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
            '        Me.Width = PictureBox1.Image.Width
            '    ElseIf PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
            '        Me.Width = PictureBox1.Image.Width / 2
            '    End If
            'End If
            If Me.PictureBox1.Image.Height <> 0 Or Me.PictureBox1.Image.Width <> 0 Then
                'If Me.PictureBox1.Image.Height <> 0 Or Me.PictureBox1.Image.Width <> 0 Then
                If Me.PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height And Me.PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    Me.Height = Me.PictureBox1.Image.Height
                    Me.Width = Me.PictureBox1.Image.Width
                    'ElseIf Me.PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Or Me.PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    '    Me.Height = Me.PictureBox1.Image.Height / 2
                    '    Me.Width = Me.PictureBox1.Image.Width / 2
                ElseIf Me.PictureBox1.Image.Height > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Or Me.PictureBox1.Image.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    Dim a As Integer
                    Dim b As Integer
                    a = Int(Me.PictureBox1.Image.Height / System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height)
                    b = Int(Me.PictureBox1.Image.Width / System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
                    If a > 1 And b <= 1 Then
                        If a > 0 Then
                            Me.Height = (Me.PictureBox1.Image.Height / a) * 0.5 '+ Me.FlowLayoutPanel1.Height
                            Me.Width = (Me.PictureBox1.Image.Width / a) * 0.5
                        Else
                            Me.Height = Me.PictureBox1.Image.Height * 0.5
                            Me.Width = Me.PictureBox1.Image.Width * 0.5
                        End If
                    ElseIf a <= 1 And b > 1 Then
                        If b > 0 Then
                            Me.Height = (Me.PictureBox1.Image.Height / b) * 0.5 '+ Me.FlowLayoutPanel1.Height
                            Me.Width = (Me.PictureBox1.Image.Width / b) * 0.5
                        Else
                            Me.Height = Me.PictureBox1.Image.Height * 0.5
                            Me.Width = Me.PictureBox1.Image.Width * 0.5
                        End If
                    ElseIf a > 1 And b > 1 Then
                        If a > b Then
                            If a > 0 Then
                                Me.Height = (Me.PictureBox1.Image.Height / b) * 0.5 '+ Me.FlowLayoutPanel1.Height
                                Me.Width = (Me.PictureBox1.Image.Width / b) * 0.5
                            Else
                                Me.Height = Me.PictureBox1.Image.Height * 0.5
                                Me.Width = Me.PictureBox1.Image.Width * 0.5
                            End If
                        Else
                            If b > 0 Then
                                Me.Height = (Me.PictureBox1.Image.Height / a) * 0.5 '+ Me.FlowLayoutPanel1.Height
                                Me.Width = (Me.PictureBox1.Image.Width / a) * 0.5
                            Else
                                Me.Height = Me.PictureBox1.Image.Height * 0.5
                                Me.Width = Me.PictureBox1.Image.Width * 0.5
                            End If
                        End If
                    Else
                        Me.Height = Me.PictureBox1.Image.Height * 0.5
                        Me.Width = Me.PictureBox1.Image.Width * 0.5
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub pfrm_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        NotifyIcon1.Visible = False
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Hsate = 0
        CHide.Text = "隐藏(&H)"
        Me.Show()
    End Sub

    Private Sub CHide_Click(sender As System.Object, e As System.EventArgs) Handles CHide.Click
        If Hsate = 0 Then
            Me.Hsate = 1
            CHide.Text = "显示(&S)"
            IBoardprms.Close()
            If pfile <> "" Then
                NotifyIcon1.ShowBalloonTip(7000, "图片展示小工具 - 隐藏到托盘", "当前打开图片：" & pfile & "。" & vbCrLf & "当前已隐藏到系统托盘，双击托盘图标重新显示。", ToolTipIcon.Info)
            Else
                NotifyIcon1.ShowBalloonTip(7000, "图片展示小工具 - 隐藏到托盘", "当前未打开图片。" & vbCrLf & "当前已隐藏到系统托盘，双击托盘图标重新显示。", ToolTipIcon.Info)
            End If
            Me.Hide()
        Else
            Me.Hsate = 0
            CHide.Text = "隐藏(&H)"
            Me.Show()
        End If
    End Sub
End Class