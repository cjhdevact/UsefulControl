Public Class PBoardForm
    Public c As Integer '0=Dark 1=Light
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now(), "HH:mm:ss")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c = 1
        Call Button3_Click(sender, e)
        'Dim mw As Integer = SystemInformation.PrimaryMonitorSize.Width
        Timer1.Enabled = True
        'Dim a As New System.Drawing.Point
        'a.X = 0
        'a.Y = 0
        'Me.Location = a
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.ReadOnly = True
        Button1.Visible = False
    End Sub

    Private Sub TextBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.DoubleClick
        TextBox1.ReadOnly = False
        Button1.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Me.WindowState = FormWindowState.Maximized Then
            Me.ControlBox = True
            Me.WindowState = FormWindowState.Normal
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            Button2.Text = "全屏"
            Me.MaximizeBox = True
            Me.MinimizeBox = True
        Else
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.ControlBox = False
            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Button2.Text = "窗口"
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If c = 0 Then
            c = 1
            Button3.Text = "暗色"
            Me.ForeColor = Color.Black
            Me.BackColor = Color.White
            TextBox1.BackColor = Color.WhiteSmoke
            TextBox1.ForeColor = Color.Black
            TableLayoutPanel1.BackColor = Color.White
            TableLayoutPanel1.ForeColor = Color.Black
            FlowLayoutPanel1.BackColor = Color.White
            FlowLayoutPanel1.ForeColor = Color.Black
        ElseIf c = 1 Then
            c = 0
            Button3.Text = "浅色"
            Me.ForeColor = Color.White
            Me.BackColor = Color.Black
            TextBox1.BackColor = Color.Black
            TextBox1.ForeColor = Color.White
            TableLayoutPanel1.BackColor = Color.Black
            TableLayoutPanel1.ForeColor = Color.White
            FlowLayoutPanel1.BackColor = Color.Black
            FlowLayoutPanel1.ForeColor = Color.White
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        PBoardprms.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        dtext.Show()
    End Sub
End Class
