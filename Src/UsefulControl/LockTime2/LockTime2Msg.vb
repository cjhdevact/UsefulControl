Public Class LockTime2Msg
    Public t As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If t <> 3 Then
            t = t + 1
        Else
            Call LockTime2Form.cms()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub extapp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        t = 0
    End Sub
End Class