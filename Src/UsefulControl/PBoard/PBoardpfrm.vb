Public Class PBoardpfrm
    Public pfile As String
    Public pst As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PBoardprms.Show()
    End Sub

    Private Sub PictureBox1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        If pst = 0 Then
            pst = 1
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            FlowLayoutPanel1.Visible = False
            'Me.Text = ""
        Else
            pst = 0
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
            FlowLayoutPanel1.Visible = True
            'Me.Text = "图片展示"
        End If
    End Sub

    Private Sub pfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pst = 0
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class