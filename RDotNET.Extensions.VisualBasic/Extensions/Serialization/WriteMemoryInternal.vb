﻿#Region "Microsoft.VisualBasic::af1cdedd7e0f488b57bc76b2290ca588, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\Extensions\Serialization\WriteMemoryInternal.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2016 GPL3 Licensed
    ' 
    ' 
    ' GNU GENERAL PUBLIC LICENSE (GPL3)
    ' 
    ' This program is free software: you can redistribute it and/or modify
    ' it under the terms of the GNU General Public License as published by
    ' the Free Software Foundation, either version 3 of the License, or
    ' (at your option) any later version.
    ' 
    ' This program is distributed in the hope that it will be useful,
    ' but WITHOUT ANY WARRANTY; without even the implied warranty of
    ' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    ' GNU General Public License for more details.
    ' 
    ' You should have received a copy of the GNU General Public License
    ' along with this program. If not, see <http://www.gnu.org/licenses/>.

#End Region

Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.ComponentModel.DataSourceModel
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder

Module WriteMemoryInternal

    ReadOnly numericWriter As MethodInfo = GetType(WriteMemoryInternal).GetMethod(NameOf(WriteNumeric), PublicShared)
    ReadOnly numericsWriter As MethodInfo = GetType(WriteMemoryInternal).GetMethod(NameOf(WriteNumerics), PublicShared)

    Public Sub WritePrimitive(var$, x As Object)
        If x Is Nothing Then
            Call var.WriteNothing
        Else
            Select Case x.GetType
                Case GetType(String)
                    Call WriteString(var, DirectCast(x, String))
                Case GetType(Boolean)
                    Call WriteLogical(var, DirectCast(x, Boolean))
                Case Else
                    Call numericWriter _
                        .MakeGenericMethod(x.GetType) _
                        .Invoke(Nothing, {var, x})
            End Select
        End If
    End Sub

    Public Sub WritePrimitive(var$, x As IEnumerable)
        If x Is Nothing Then
            Call var.WriteNothing
        Else
            Dim baseType As Type = x _
                .GetType _
                .GetTypeElement(strict:=False)

            Select Case baseType
                Case GetType(String)
                    Call WriteString(var, DirectCast(x, IEnumerable(Of String)))
                Case GetType(Boolean)
                    Call WriteLogical(var, DirectCast(x, IEnumerable(Of Boolean)))
                Case Else
                    Call numericsWriter _
                        .MakeGenericMethod(baseType) _
                        .Invoke(Nothing, {var, x})
            End Select
        End If
    End Sub

    ''' <summary>
    ''' 相当于进行变量申明
    ''' </summary>
    ''' <param name="var$"></param>
    <Extension> Public Sub WriteNothing(var$)
        SyncLock R
            With R
                .call = $"{var} <- NULL;"
            End With
        End SyncLock
    End Sub

    Public Sub WriteNumeric(Of T As IComparable(Of T))(var$, x As T)
        SyncLock R
            With R
                .call = $"{var} <- {x.ToString};"
            End With
        End SyncLock
    End Sub

    Public Sub WriteString(var$, s$)
        SyncLock R
            With R
                .call = $"{var} <- {Rstring(s)};"
            End With
        End SyncLock
    End Sub

    Public Sub WriteLogical(var$, b As Boolean)
        SyncLock R
            With R
                .call = $"{var} <- {b.ToString.ToUpper};"
            End With
        End SyncLock
    End Sub

    Public Sub WriteNumerics(Of T As IComparable(Of T))(var$, x As IEnumerable(Of T))
        SyncLock R
            With R
                .call = $"{var} <- c({x.JoinBy(", ")});"
            End With
        End SyncLock
    End Sub

    Public Sub WriteString(var$, s As IEnumerable(Of String))
        SyncLock R
            With R
                .call = $"{var} <- c({s.Select(AddressOf Rstring).JoinBy(", ")});"
            End With
        End SyncLock
    End Sub

    Public Sub WriteLogical(var$, b As IEnumerable(Of Boolean))
        SyncLock R
            With R
                .call = $"{var} <- c({b.Select(Function(f) f.ToString.ToUpper).JoinBy(", ")});"
            End With
        End SyncLock
    End Sub
End Module

