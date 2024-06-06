Public Class IBoardprms
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        IBoardpfrm.NotifyIcon1.Visible = False
        IBoardpfrm.Close()
        Me.Close()

    End Sub

    Private Sub prms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenFileDialog1.Filter = "所有支持的文件 (*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff;*.ico)|*.png;*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.dib;*.gif;*.tif;*.tiff;*.ico|" _
                              & "PNG 图像 (*.png)|*.png|JPEG 文件 (*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" _
                              & "BMP 文件 (*.bmp;*.dib)|*.bmp;*.dib|GIF 图像 (*.gif)|*.gif|TIFF 文件 (*.tif;*.tiff)|*.tif;*.tiff|图标文件(*.ico)|*.ico|所有文件 (*.*)|*.*"
        Dim ver1 As String
        Dim ver2 As String
        ver1 = My.Application.Info.Version.Major.ToString & "." & My.Application.Info.Version.Minor.ToString & "." & My.Application.Info.Version.Build.ToString
        ver2 = My.Application.Info.Version.Revision.ToString
        Me.Label6.Text = "图片展示小工具 版本：1.0.1" & ver1 & vbCrLf & "（内部构建版本：Build 24011）" & vbCrLf & "版权所有 © 2023-2024 CJH。保留所有权利。"
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
                If IBoardpfrm.PictureBox1.Image.Height <> 0 Then
                    If IBoardpfrm.PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                        IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height
                    ElseIf IBoardpfrm.PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                        IBoardpfrm.Height = IBoardpfrm.PictureBox1.Image.Height / 2
                    End If
                End If

                If IBoardpfrm.PictureBox1.Image.Width <> 0 Then
                    If IBoardpfrm.PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                        IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width
                    ElseIf IBoardpfrm.PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                        IBoardpfrm.Width = IBoardpfrm.PictureBox1.Image.Width / 2
                    End If
                End If
            Catch ex As Exception
                TextBox1.Text = ""
                IBoardpfrm.CFileState.Text = "未打开文件。"
                IBoardpfrm.pfile = ""
                IBoardpfrm.NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                IBoardpfrm.Height = 343
                IBoardpfrm.Width = 342
            End Try
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            IBoardpfrm.TopMost = True
        Else
            IBoardpfrm.TopMost = False
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            IBoardpfrm.BackColor = Me.ColorDialog1.Color
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
End Class