Public Class LockTime2Form
    Public m As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = Format(Now(), "HH:mm:ss")
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
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        If m = 2 Then
            m = 0
            LockTime2Msg.ShowDialog()
        Else
            m = m + 1
        End If
    End Sub
    Public Sub cms()
        LockTime2Msg.Close()
        Me.Close()
    End Sub
End Class
