Public Class IBoardpfrm
    Public pfile As String
    Public pst As Integer
    Public Hsate As Integer
    Public ImgAutoLoad As Integer
    Public MyTitle As String
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

    Private Sub pfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pst = 0
        Hsate = 0
        ImgAutoLoad = 0
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.png") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.png"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.png"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.jpg") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.jpg"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.jpg"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.bmp") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.bmp"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.bmp"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.tiff") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.tiff"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.tiff"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.ico") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.ico"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.ico"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad <> 1 Then
            If System.IO.File.Exists(Application.StartupPath & "\ShowImage.gif") = True Then
                Try
                    pfile = Application.StartupPath & "\ShowImage.gif"
                    IBoardprms.TextBox1.Text = Application.StartupPath & "\ShowImage.gif"
                    NotifyIcon1.Text = "图片展示小工具 - 已打开图片"
                    CFileState.Text = "已打开文件：" & pfile
                    ImgAutoLoad = 1
                    PictureBox1.Load(pfile)
                Catch ex As Exception
                    pfile = ""
                    IBoardprms.TextBox1.Text = ""
                    NotifyIcon1.Text = "图片展示小工具 - 未打开图片"
                    CFileState.Text = "未打开文件。"
                    ImgAutoLoad = 0
                End Try
            End If
        End If
        If ImgAutoLoad = 1 Then
            pst = 1
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            FlowLayoutPanel1.Visible = False
            'Me.Text = ""

            If PictureBox1.Image.Height <> 0 Then
                If PictureBox1.Image.Height <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                    Me.Height = PictureBox1.Image.Height
                ElseIf PictureBox1.Image.Height / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height Then
                    Me.Height = PictureBox1.Image.Height / 2
                End If
            End If

            If PictureBox1.Image.Width <> 0 Then
                If PictureBox1.Image.Width <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    Me.Width = PictureBox1.Image.Width
                ElseIf PictureBox1.Image.Width / 2 <= System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width Then
                    Me.Width = PictureBox1.Image.Width / 2
                End If
            End If

            Me.Location = New Point(SystemInformation.PrimaryMonitorSize.Width - Me.Width - 15, 15)
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