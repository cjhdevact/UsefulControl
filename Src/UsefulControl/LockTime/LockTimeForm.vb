Public Class LockTimeForm
    Public m As Integer
    Public scaleX As Single
    Public scaleY As Single
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now(), "HH:mm:ss")
        Label2.Text = Format(Now(), "yyyy年 M月 d日")
    End Sub

    Private Sub LockTimeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mw As Integer = SystemInformation.PrimaryMonitorSize.Width
        ' 获取当前窗体的 DPI
        'Dim currentDpiX As Single = Me.CreateGraphics().DpiX
        'Dim currentDpiY As Single = Me.CreateGraphics().DpiY

        'If currentDpiX <> 96 OrElse currentDpiY <> 96 Then
        'End If
        '计算缩放比例
        'scaleX = currentDpiX / 96
        'scaleY = currentDpiY / 96

        'FlowLayoutPanel1.Height = FlowLayoutPanel1.Height * scaleY
        Timer1.Enabled = True
        m = 0
        'Dim a As New System.Drawing.Point
        'a.X = 0
        'a.Y = 0
        'Me.Location = a
    End Sub

    'Private Sub ToolStrip1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs)
    '    If (TryCast(sender, ToolStrip).RenderMode = ToolStripRenderMode.System) Then
    '        Dim rect As New Rectangle(0, 0, (Me.ToolStrip1.Width - 1.7), (Me.ToolStrip1.Height - 1.7))
    '        e.Graphics.SetClip(rect)
    '    End If
    'End Sub

    Private Sub exitb_Click(sender As System.Object, e As System.EventArgs) Handles exitb.Click
        If m <> 2 Then
            m = m + 1
        Else
            If MessageBox.Show("是否要退出时钟锁屏？", "时钟锁屏", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                'End
                Me.Close()
            End If
        End If
    End Sub

    Private Sub texttop_Click(sender As System.Object, e As System.EventArgs) Handles texttop.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 1)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
    End Sub

    Private Sub textbottom_Click(sender As System.Object, e As System.EventArgs) Handles textbottom.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 1)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 3)
    End Sub

    Private Sub textleft_Click(sender As System.Object, e As System.EventArgs) Handles textleft.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 1)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
    End Sub

    Private Sub textright_Click(sender As System.Object, e As System.EventArgs) Handles textright.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 1)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 1)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 2)
    End Sub

    Private Sub textfull_Click(sender As System.Object, e As System.EventArgs) Handles textfull.Click
        Me.TableLayoutPanel1.SetRowSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label1, 2)
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.TableLayoutPanel1.SetRowSpan(Me.Label2, 2)

        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 2)
    End Sub

    Private Sub aboutb_Click(sender As System.Object, e As System.EventArgs) Handles aboutb.Click
        MessageBox.Show("时钟锁屏 版本：" & My.Application.Info.Version.ToString & vbCrLf & vbCrLf & "版权所有 © 2023-2024 CJH。保留所有权利。", "关于时钟锁屏", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Winb_Click(sender As System.Object, e As System.EventArgs) Handles Winb.Click
        'If Me.WindowState = FormWindowState.Maximized Then
        '    Me.WindowState = FormWindowState.Normal
        '    Winb.Text = "全屏"
        '    Me.Text = "时间锁屏"
        '    Me.ShowIcon = True
        '    Me.ShowInTaskbar = True
        '    Me.ControlBox = True
        '    Me.MaximizeBox = True
        '    Me.MinimizeBox = True
        '    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        '    Me.Location = New Point((System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width - Me.Width) / 2, (System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height - Me.Height) / 2)
        'Else
        '    Me.WindowState = FormWindowState.Maximized
        '    Winb.Text = "窗口"
        '    Me.Text = ""
        '    Me.ShowIcon = False
        '    Me.ShowInTaskbar = False
        '    Me.ControlBox = True
        '    Me.MaximizeBox = False
        '    Me.MinimizeBox = False
        '    Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '    Me.Location = New Point(0, 0)
        'End If

        If Me.WindowState = FormWindowState.Maximized Then
            Me.ControlBox = True
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Winb.Text = "全屏"
            Me.MaximizeBox = True
            Me.MinimizeBox = True
        Else
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ControlBox = False
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Winb.Text = "窗口"
        End If
    End Sub
End Class
