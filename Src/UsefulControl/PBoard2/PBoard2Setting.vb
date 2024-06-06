Public Class PBoard2Setting

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        'If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'Form1.Label1.ForeColor = ColorDialog1.Color
        'End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FontDialog1.ShowDialog()
        'If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        'Form1.Label1.Font = FontDialog1.Font
        'End If
    End Sub

    Private Sub prms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ComboBox1.SelectedIndex = 0
        'ComboBox1.SelectedText = "秒"
    End Sub
    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        Dim strlimit As String
        strlimit = "0123456789"
        Dim keychar As Char = e.KeyChar
        If InStr(strlimit, keychar) <> 0 Or e.KeyChar = Microsoft.VisualBasic.ChrW(8) Then
            'If keychar = "." And InStr(TextBox1.Text, keychar) <> 0 Then
            'e.Handled = True
            'Else
            e.Handled = False
            'End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        PBoard2Form.Timer1.Enabled = True
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error GoTo errcode
        If TextBox6.Text = "" Then
            MsgBox("隐藏时间不能为空！", MsgBoxStyle.Critical, "错误")
        ElseIf TextBox6.Text = "0" Then
            MsgBox("隐藏时间不能为0！", MsgBoxStyle.Critical, "错误")
        Else
            If ComboBox1.SelectedIndex = 0 Then '秒
                PBoard2Form.Timer1.Interval = TextBox6.Text * 1000
                PBoard2Form.Timer1.Enabled = True
            ElseIf ComboBox1.SelectedIndex = 1 Then '分
                PBoard2Form.Timer1.Interval = TextBox6.Text * 1000 * 60
                PBoard2Form.Timer1.Enabled = True
            ElseIf ComboBox1.SelectedIndex = 2 Then '时
                PBoard2Form.Timer1.Interval = TextBox6.Text * 1000 * 60 * 60
                PBoard2Form.Timer1.Enabled = True
            End If
            PBoard2Form.Label1.Font = FontDialog1.Font
            PBoard2Form.Label1.ForeColor = ColorDialog1.Color
            PBoard2Form.sh0 = TextBox1.Text
            PBoard2Form.sh1 = TextBox2.Text
            PBoard2Form.sh2 = TextBox3.Text
            PBoard2Form.sh3 = TextBox4.Text
            PBoard2Form.sh4 = TextBox5.Text
            Me.Close()
        End If
        Exit Sub
errcode:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "错误")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MessageBox.Show("公告栏（Pboard2） １.０.０.２３０６１" & vbCrLf & vbCrLf & "作者：ＣＪＨ" & vbCrLf & "版权所有（Ｃ）ＣＪＨ。保留所有权利。" & vbCrLf & vbCrLf & "适用于Windows平台上的文字展示", "关于 公告栏（Pboard2）", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class