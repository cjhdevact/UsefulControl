'****************************************************************************
'    UsefulControl
'    Copyright (C) 2023-2024  CJH
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
'*     UsefulControl - FakeShutdownForm.vb             *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Windows Fake Shutdown UI.                       *
'*                                                     *
'\*****************************************************/
Imports System.Runtime.InteropServices

Public Class FakeShutdownForm

    Private mute As Integer = &H80000
    Private up As Integer = &HA0000
    Private down As Integer = &H90000
    Private WM_APPCOMMAND As Integer = &H319
    <DllImport("user32.dll")> _
    Public Shared Function SendMessageW(hWnd As IntPtr, Msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
    End Function

    Public a As Integer
    Public FakeMode As Integer
    Private Sub FakeShutdownForm_MouseDoubleClick(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseDoubleClick
        If a = 5 Then
            Me.Close()
        Else
            a = a + 1
        End If
    End Sub
    Private Sub FakeShutdownForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        a = 0
        '加大
        'SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(up))
        '减小
        'SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(down))
        '静音
        'SendMessageW(Me.Handle, WM_APPCOMMAND, Me.Handle, New IntPtr(mute))
        For i As Integer = 1 To 50
            SendMessageW(Me.Handle, &H319, Me.Handle, New IntPtr(down))
        Next
        Me.TableLayoutPanel1.BackgroundImage = Nothing

    End Sub
    Private Sub TableLayoutPanel1_MouseDoubleClick(sender As System.Object, e As System.EventArgs) Handles TableLayoutPanel1.MouseDoubleClick
        If a = 5 Then
            Me.Close()
        Else
            a = a + 1
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Me.PictureBox1.Visible = False
        Me.Label1.Visible = False
        If FakeMode = 1 Then
            Me.TableLayoutPanel1.BackgroundImage = My.Resources.lenovoshut
        Else
            SeewoFakeShut.Show()
        End If
        'Form1.ChangeMonitorState(Form1.MonitorMode.MonitorOff)
        Timer1.Enabled = False
    End Sub
End Class