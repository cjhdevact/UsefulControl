Public Class dtext
    Public wst As Integer
    Private Sub TextBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.DoubleClick
        If wst = 0 Then
            wst = 1
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            'Me.Text = ""
        Else
            wst = 0
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            'Me.Text = "图片展示"
        End If
    End Sub

End Class