Public Class LockTimeForm
    Public m As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now(), "HH:mm:ss")
        Label2.Text = Format(Now(), "yyyy年 M月 d日")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mw As Integer = SystemInformation.PrimaryMonitorSize.Width
        Timer1.Enabled = True
        m = 0
        Dim a As New System.Drawing.Point
        a.X = 0
        a.Y = 0
        Me.Location = a
    End Sub

    Private Sub ToolStrip1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles ToolStrip1.Paint
        If (TryCast(sender, ToolStrip).RenderMode = ToolStripRenderMode.System) Then
            Dim rect As New Rectangle(0, 0, (Me.ToolStrip1.Width - 1.7), (Me.ToolStrip1.Height - 1.7))
            e.Graphics.SetClip(rect)
        End If
    End Sub

    Private Sub exitb_Click(sender As System.Object, e As System.EventArgs) Handles exitb.Click
        If m <> 2 Then
            m = m + 1
        Else
            Me.Close()
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
        MessageBox.Show("时钟锁屏 版本：1.0.5.24021" & vbCrLf & vbCrLf & "版权所有 © 2023-2024 CJH。保留所有权利。", "关于时钟锁屏", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
