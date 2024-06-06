Public Class PBoard2Form
    Public c As Integer
    Public st As Integer
    Public sh0 As String
    Public sh1 As String
    Public sh2 As String
    Public sh3 As String
    Public sh4 As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c = 0

        sh0 = "请在右下角""设置""输入显示内容"
        sh1 = ""
        sh2 = ""
        sh3 = ""
        sh4 = ""
        Me.Label1.Text = sh0
        st = 0
        'Dim mw As Integer = SystemInformation.PrimaryMonitorSize.Width
        'Dim a As New System.Drawing.Point
        'a.X = 0
        'a.Y = 0
        'Me.Location = a
        Timer1.Enabled = True
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'If Timer1.Interval < 600000 Then
        PBoard2Setting.TextBox6.Text = Timer1.Interval / 1000
        PBoard2Setting.ComboBox1.SelectedIndex = 0
        PBoard2Setting.ComboBox1.SelectedText = "秒"
        PBoard2Setting.TextBox1.Text = sh0
        PBoard2Setting.TextBox2.Text = sh1
        PBoard2Setting.TextBox3.Text = sh2
        PBoard2Setting.TextBox4.Text = sh3
        PBoard2Setting.TextBox5.Text = sh4
        'ElseIf Timer1.Interval < 36000000 Then
        'prms.TextBox6.Text = Timer1.Interval / 60000
        'prms.ComboBox1.SelectedIndex = 1
        'prms.ComboBox1.SelectedText = "分"
        'Else
        'prms.TextBox6.Text = Timer1.Interval / 3600000
        'prms.ComboBox1.SelectedIndex = 2
        'prms.ComboBox1.SelectedText = "小时"
        'End If
        Timer1.Enabled = False
        PBoard2Setting.ShowDialog()
    End Sub

    Private Sub Label1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.DoubleClick
        If c = 0 Then
            Button2.Visible = False
            Button4.Visible = False
            c = 1
        Else
            Button2.Visible = True
            Button4.Visible = True
            c = 0
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If st = 0 Then
            If sh0 <> "" Then
                Me.Label1.Text = sh0
            End If
            st = 1
        ElseIf st = 1 Then
            If sh1 <> "" Then
                Me.Label1.Text = sh1
            End If
            st = 2
        ElseIf st = 2 Then
            If sh2 <> "" Then
                Me.Label1.Text = sh2
            End If
            st = 3
        ElseIf st = 3 Then
            If sh3 <> "" Then
                Me.Label1.Text = sh3
            End If
            st = 4
        ElseIf st = 4 Then
            If sh4 <> "" Then
                Me.Label1.Text = sh4
            End If
            st = 0
        End If
    End Sub
End Class
