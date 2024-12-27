'****************************************************************************
'    UsefulControl
'    Copyright (C) 2023-2025  CJH.
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
'*     UsefulControl - GPLForm.vb                      *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     The GPL-3 License form.                         *
'*                                                     *
'\*****************************************************/
Imports System.Runtime.InteropServices
Public Class GPLForm
    <DllImport("dwmapi.dll")> _
    Public Shared Function DwmSetWindowAttribute(ByVal hwnd As IntPtr, ByVal attr As DwmWindowAttribute, ByRef attrValue As Integer, ByVal attrSize As Integer) As Integer
    End Function
    'Public Shared Function EnableDarkModeForWindow(ByVal hWnd As IntPtr, ByVal enable As Boolean) As Boolean
    '    Dim darkMode As Integer
    '    darkMode = enable
    '    Dim hr As Integer
    '    Dim i As Integer
    '    'hr = DwmSetWindowAttribute(hWnd, DwmWindowAttribute.UseImmersiveDarkMode, darkMode, sizeof(i))
    '    Return hr >= 0
    'End Function
    Public Shared Function EnableDarkModeForWindow(ByVal hWnd As IntPtr, ByVal enable As Boolean) As Boolean
        Dim attrValue As Integer = If(enable, 1, 0)
        Return (BootForm.DwmSetWindowAttribute(hWnd, DwmWindowAttribute.UseImmersiveDarkMode, attrValue, 4) >= 0)
    End Function

    Public Enum DwmWindowAttribute As UInt32
        NCRenderingEnabled = 1
        NCRenderingPolicy
        TransitionsForceDisabled
        AllowNCPaint
        CaptionButtonBounds
        NonClientRtlLayout
        ForceIconicRepresentation
        Flip3DPolicy
        ExtendedFrameBounds
        HasIconicBitmap
        DisallowPeek
        ExcludedFromPeek
        Cloak
        Cloaked
        FreezeRepresentation
        PassiveUpdateMode
        UseHostBackdropBrush
        UseImmersiveDarkMode = 20
        WindowCornerPreference = 33
        BorderColor
        CaptionColor
        TextColor
        VisibleFrameBorderThickness
        SystemBackdropType
        Last
    End Enum

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub GPLForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call formatcolorcursetmsg()
    End Sub
    Sub formatcolorcursetmsg()
        If BootForm.crmd = 0 Then
            EnableDarkModeForWindow(Me.Handle, True)
            Me.BackColor = Color.FromArgb(32, 32, 32)
            Me.ForeColor = Color.White
            Me.Button1.BackColor = Color.FromArgb(32, 32, 32)
            Me.Button1.ForeColor = Color.White
            Me.TextBox1.BackColor = Color.FromArgb(64, 64, 64)
            Me.TextBox1.ForeColor = Color.White
        Else
            EnableDarkModeForWindow(Me.Handle, False)
            Me.BackColor = Color.White
            Me.ForeColor = Color.Black
            Me.Button1.BackColor = Color.Transparent
            Me.Button1.ForeColor = Color.Black
            Me.TextBox1.BackColor = Color.White
            Me.TextBox1.ForeColor = Color.Black
        End If
    End Sub
End Class