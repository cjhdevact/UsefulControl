﻿'****************************************************************************
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
'*     UsefulControl - BlackForm.vb                    *
'*                                                     *
'*     Copyright (c) CJH.                              *
'*                                                     *
'*     Show a black screen.                            *
'*                                                     *
'\*****************************************************/
Public Class BlackForm
    Public a As Integer
    Private Sub BlackForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        a = 0
    End Sub
    Private Sub BlackForm_MouseDoubleClick(sender As System.Object, e As System.EventArgs) Handles MyBase.MouseDoubleClick
        If a = 5 Then
            Me.Close()
        Else
            a = a + 1
        End If
    End Sub
End Class