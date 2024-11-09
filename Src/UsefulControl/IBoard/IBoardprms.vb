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
'*     IBoard - prms.vb                                *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     The picture settings form.                      *
'*                                                     *
'\*****************************************************/
Imports Microsoft.Win32

Public Class IBoardprms
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If MessageBox.Show("确定关闭图片展示小工具吗？", "图片展示小工具 - 提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            IBoardpfrm.NotifyIcon1.Visible = False
            IBoardpfrm.Close()
            Me.Close()
        End If
    End Sub

    Private Sub prms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenFileDialog1.Filter = "所有支持的文件 (*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff;*.ico)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff;*.ico|" _
                              & "PNG 图像 (*.png)|*.png|JPEG 文件 (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" _
                              & "BMP 文件 (*.bmp;*.dib)|*.bmp;*.dib|GIF 图像 (*.gif)|*.gif|TIFF 文件 (*.tif;*.tiff)|*.tif;*.tiff|图标文件(*.ico)|*.ico|所有文件 (*.*)|*.*"
        'Dim ver1 As String
        'Dim ver2 As String
        'ver1 = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Build.ToString
        'ver2 = My.Application.Info.Version.Revision.ToString
        Me.Label6.Text = "图片展示小工具 版本：1.0.2.24101" & vbCrLf & "版权所有 © 2023-2024 CJH。保留所有权利。"
        If IBoardpfrm.TopMost = True Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        If IBoardpfrm.UseMoveV = 1 Then
            Me.CheckBox2.Checked = True
        Else
            Me.CheckBox2.Checked = False
        End If
        If IBoardpfrm.LoadLastImage = 1 Then
            Me.CheckBox3.Checked = True
        Else
            Me.CheckBox3.Checked = False
        End If
        If IBoardpfrm.PictureBox1.AllowDrop = True Then
            Me.CheckBox4.Checked = True
        Else
            Me.CheckBox4.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            IBoardpfrm.pfile = OpenFileDialog1.FileName
            TextBox1.Text = OpenFileDialog1.FileName
            IBoardpfrm.NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
            IBoardpfrm.CFileState.Text = "已打开文件：" & IBoardpfrm.pfile
            IBoardpfrm.ImgAutoLoad = 0
            Try
                IBoardpfrm.PictureBox1.Load(IBoardpfrm.pfile)
                If IBoardpfrm.PictureBox1.Image.Height <> 0 Or IBoardpfrm.PictureBox1.Image.Width <> 0 Then
                    '    If pfrm.PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                    '        pfrm.Height = pfrm.PictureBox1.Image.Height
                    '    ElseIf pfrm.PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                    '        pfrm.Height = pfrm.PictureBox1.Image.Height / 2
                    '    End If
                    'End If

                    'If pfrm.PictureBox1.Image.Width <> 0 Then
                    '    If pfrm.PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    '        pfrm.Width = pfrm.PictureBox1.Image.Width
                    '    ElseIf pfrm.PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    '        pfrm.Width = pfrm.PictureBox1.Image.Width / 2
                    '    End If
                    'End If
                    'If pfrm.PictureBox1.Image.Height <> 0 Or pfrm.PictureBox1.Image.Width <> 0 Then
                    If IBoardpfrm.PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height And IBoardpfrm.PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                        IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height
                        IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width
                        'ElseIf pfrm.PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Or pfrm.PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                        '    Me.Height = pfrm.PictureBox1.Image.Height / 2
                        '    Me.Width = pfrm.PictureBox1.Image.Width / 2
                    ElseIf IBoardpfrm.PictureBox1.Image.Height > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Or IBoardpfrm.PictureBox1.Image.Width > System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                        Dim a As Integer
                        Dim b As Integer
                        a = Int(IBoardpfrm.PictureBox1.Image.Height / System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height)
                        b = Int(IBoardpfrm.PictureBox1.Image.Width / System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width)
                        If a > 1 And b <= 1 Then
                            If a > 0 Then
                                IBoardpfrm.Height = (IBoardpfrm.PictureBox1.Image.Height / a) * 0.5 '+ pfrm.FlowLayoutPanel1.Height
                                IBoardpfrm.Width = (IBoardpfrm.PictureBox1.Image.Width / a) * 0.5
                            Else
                                IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height * 0.5
                                IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width * 0.5
                            End If
                        ElseIf a <= 1 And b > 1 Then
                            If b > 0 Then
                                IBoardpfrm.Height = (IBoardpfrm.PictureBox1.Image.Height / b) * 0.5 '+ pfrm.FlowLayoutPanel1.Height
                                IBoardpfrm.Width = (IBoardpfrm.PictureBox1.Image.Width / b) * 0.5
                            Else
                                IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height * 0.5
                                IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width * 0.5
                            End If
                        ElseIf a > 1 And b > 1 Then
                            If a > b Then
                                If a > 0 Then
                                    IBoardpfrm.Height = (IBoardpfrm.PictureBox1.Image.Height / b) * 0.5 '+ pfrm.FlowLayoutPanel1.Height
                                    IBoardpfrm.Width = (IBoardpfrm.PictureBox1.Image.Width / b) * 0.5
                                Else
                                    IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height * 0.5
                                    IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width * 0.5
                                End If
                            Else
                                If b > 0 Then
                                    IBoardpfrm.Height = (IBoardpfrm.PictureBox1.Image.Height / a) * 0.5 '+ pfrm.FlowLayoutPanel1.Height
                                    IBoardpfrm.Width = (IBoardpfrm.PictureBox1.Image.Width / a) * 0.5
                                Else
                                    IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height * 0.5
                                    IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width * 0.5
                                End If
                            End If
                        Else
                            IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height * 0.5
                            IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width * 0.5
                        End If
                    End If
                End If
                If IBoardpfrm.UnSaveData = 0 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", IBoardpfrm.pfile, RegistryValueKind.String, "HKCU")
                End If
            Catch ex As Exception
                IBoardpfrm.PictureBox1.Image = Nothing
                TextBox1.Text = ""
                IBoardpfrm.CFileState.Text = "未打开文件。"
                IBoardpfrm.pfile = ""
                IBoardpfrm.NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                IBoardpfrm.Height = 343 * IBoardpfrm.scaleY
                IBoardpfrm.Width = 342 * IBoardpfrm.scaleX
                If IBoardpfrm.UnSaveData = 0 Then
                    RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", IBoardpfrm.pfile, RegistryValueKind.String, "HKCU")
                End If
                MessageBox.Show("图片加载失败。", "图片展示小工具 - 错误", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            IBoardpfrm.TopMost = True
            Me.TopMost = True
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "AllowTopMost", 1, RegistryValueKind.DWord, "HKCU")
            End If
        Else
            IBoardpfrm.TopMost = False
            Me.TopMost = False
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "AllowTopMost", 0, RegistryValueKind.DWord, "HKCU")
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            IBoardpfrm.BackColor = Me.ColorDialog1.Color
            If IBoardpfrm.UnSaveData = 0 Then
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorR", IBoardpfrm.BackColor.R, RegistryValueKind.DWord, "HKCU")
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorG", IBoardpfrm.BackColor.G, RegistryValueKind.DWord, "HKCU")
                RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "BkgColorB", IBoardpfrm.BackColor.B, RegistryValueKind.DWord, "HKCU")
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If IBoardpfrm.pfile <> "" Then
            IBoardpfrm.Hide()
            IBoardpfrm.Hsate = 1
            IBoardpfrm.CHide.Text = "显示(&S)"
            IBoardpfrm.NotifyIcon1.ShowBalloonTip(7000, "图片展示小工具 - 隐藏到托盘", "当前打开图片：" & IBoardpfrm.pfile & "。" & vbCrLf & "当前已隐藏到系统托盘，双击托盘图标重新显示。", ToolTipIcon.Info)
            Me.Close()
        Else
            IBoardpfrm.Hide()
            IBoardpfrm.Hsate = 1
            IBoardpfrm.CHide.Text = "显示(&S)"
            IBoardpfrm.NotifyIcon1.ShowBalloonTip(7000, "图片展示小工具 - 隐藏到托盘", "当前未打开图片。" & vbCrLf & "当前已隐藏到系统托盘，双击托盘图标重新显示。", ToolTipIcon.Info)
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.SelectedIndex = 0 Then
            IBoardpfrm.PictureBox1.SizeMode = PictureBoxSizeMode.Normal
        ElseIf ComboBox2.SelectedIndex = 1 Then
            IBoardpfrm.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        ElseIf ComboBox2.SelectedIndex = 2 Then
            IBoardpfrm.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        ElseIf ComboBox2.SelectedIndex = 3 Then
            IBoardpfrm.PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        ElseIf ComboBox2.SelectedIndex = 4 Then
            IBoardpfrm.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        End If
        If IBoardpfrm.UnSaveData = 0 Then
            AddReg("Software\CJH\IBoard\Settings", "ImageMode", ComboBox2.SelectedIndex, Microsoft.Win32.RegistryValueKind.DWord, "HKCU")
        End If

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        If (MessageBox.Show("确定重启图片展示小工具吗？", "图片展示小工具", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes) Then
            System.Diagnostics.Process.Start(Application.ExecutablePath, "/iboard")
            IBoardpfrm.Close()
            End
        End If
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        IBoardpfrm.PictureBox1.Image = Nothing
        TextBox1.Text = ""
        IBoardpfrm.CFileState.Text = "未打开文件。"
        IBoardpfrm.pfile = ""
        IBoardpfrm.NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
        IBoardpfrm.Height = 343 * IBoardpfrm.scaleY
        IBoardpfrm.Width = 342 * IBoardpfrm.scaleX
        If IBoardpfrm.UnSaveData = 0 Then
            RegKeyModule.AddReg("Software\CJH\IBoard\Settings", "ImagePath", IBoardpfrm.pfile, RegistryValueKind.String, "HKCU")
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = False Then
            'CheckBox2.Checked = False
            IBoardpfrm.UseMoveV = 0
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "EnableMove", 0, RegistryValueKind.DWord, "HKCU")
            End If
        Else
            'CheckBox2.Checked = True
            IBoardpfrm.UseMoveV = 1
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "EnableMove", 1, RegistryValueKind.DWord, "HKCU")
            End If
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = False Then
            IBoardpfrm.LoadLastImage = 0
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "LoadLastImage", 0, RegistryValueKind.DWord, "HKCU")
            End If

        Else
            IBoardpfrm.LoadLastImage = 1
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "LoadLastImage", 1, RegistryValueKind.DWord, "HKCU")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/cjhdevact/IBoard")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/cjhdevact/IBoard/issues")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        'GPLForm.TextBox1.ScrollBars = ScrollBars.Both
        IBoardGPLForm.TextBox1.Text = My.Resources.GPL3
        'GPLForm.TextBox1.WordWrap = False
        'GPLForm.TextBox1.Font = New System.Drawing.Font("宋体", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        IBoardGPLForm.Text = "GNU General Public License 3"
        IBoardGPLForm.ShowDialog()
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        'GPLForm.TextBox1.ScrollBars = ScrollBars.Vertical
        IBoardGPLForm.TextBox1.Text = My.Resources.IBoardDocText
        'GPLForm.TextBox1.WordWrap = True
        'GPLForm.TextBox1.Font = New System.Drawing.Font("微软雅黑", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        IBoardGPLForm.Text = "帮助"
        IBoardGPLForm.ShowDialog()
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = False Then
            IBoardpfrm.PictureBox1.AllowDrop = False
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "EnableDrag", 0, RegistryValueKind.DWord, "HKCU")
            End If
        Else
            IBoardpfrm.PictureBox1.AllowDrop = True
            If IBoardpfrm.UnSaveData = 0 Then
                AddReg("Software\CJH\IBoard\Settings", "EnableDrag", 1, RegistryValueKind.DWord, "HKCU")
            End If
        End If
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        If MessageBox.Show("确定要恢复默认设置吗？" & vbCrLf & "执行该操作会删除本机图片展示小工具的自定义设置，此操作无法撤销。" & vbCrLf & vbCrLf & "你确定要继续吗？", "图片展示小工具 - 恢复默认设置警告", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
            If IBoardpfrm.UnSaveData = 0 Then
                RegKeyModule.DelKey("Software\CJH\IBoard", True, "HKCU")
            End If
            System.Diagnostics.Process.Start(Application.ExecutablePath, "/iboard")
            End
        End If
    End Sub
End Class