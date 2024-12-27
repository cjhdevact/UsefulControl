'****************************************************************************
'    UsefulControl
'    Copyright (C) 2023-2025  CJH
'
'    This program is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    This program is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <http://www.gnu.org/licenses/>.
'****************************************************************************
'/*****************************************************\
'*                                                     *
'*     UsefulControl - SeewoFakeShut.vb                *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Seewo Fake Shutdown UI.                         *
'*                                                     *
'\*****************************************************/
Public Class SeewoFakeShut
    Public ReTime As Integer
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub SeewoFakeShut_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ReTime = 10

        Label2.Text = "PC已关机 , 确认关闭整机？" & vbCrLf & "系统将在10秒后关闭"
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If ReTime = 1 Then
            Me.Close()
        Else
            ReTime = ReTime - 1
            Label2.Text = "PC已关机 , 确认关闭整机？" & vbCrLf & "系统将在" & ReTime & "秒后关闭"
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button1_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseMove
        Button1.BackgroundImage = My.Resources.seewodialog_btn_left_normal
        Button1.ForeColor = Color.Black
    End Sub
    Private Sub Button1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseDown
        Button1.BackgroundImage = My.Resources.seewodialog_btn_left_pressed
        Button1.ForeColor = Color.White
    End Sub
    Private Sub Button1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.MouseLeave
        Button1.BackgroundImage = My.Resources.seewodialog_btn_left_normal
        Button1.ForeColor = Color.Black
    End Sub
    Private Sub Button2_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseMove
        Button2.BackgroundImage = My.Resources.seewodialog_btn_right_normal
        Button2.ForeColor = Color.Black
    End Sub
    Private Sub Button2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseDown
        Button2.BackgroundImage = My.Resources.seewodialog_btn_right_pressed
        Button2.ForeColor = Color.White
    End Sub
    Private Sub Button2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.MouseLeave
        Button2.BackgroundImage = My.Resources.seewodialog_btn_right_normal
        Button2.ForeColor = Color.Black
    End Sub
End Class