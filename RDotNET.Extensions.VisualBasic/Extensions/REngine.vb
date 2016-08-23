﻿#Region "Microsoft.VisualBasic::672b05949dbb4bb1d56234b07f317e65, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\R.Extension\REngine.vb"

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

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Runtime.CompilerServices

Imports RDotNET.REngineExtension
Imports RDotNET.SymbolicExpressionExtension
Imports RDotNET

''' <summary>
''' Wrapper for R engine script invoke.
''' </summary>
Public Module RExtensionInvoke

    <Extension>
    Public Function AsBoolean(sym As SymbolicExpression) As Boolean
        Return sym.AsLogical.First
    End Function

    '''' <summary>
    '''' This function equals to the function &lt;library> in R system.
    '''' </summary>
    '''' <param name="packageName"></param>
    '''' <returns></returns>
    '<Extension> Public Function Library(REngine As REngine, packageName As String) As Boolean
    '    Dim Command As String = $"library(""{packageName}"");"
    '    Try
    '        Dim Result As String() = REngine.Evaluate(Command).AsCharacter().ToArray()
    '        Return True
    '    Catch ex As Exception
    '        Call App.LogException(ex)
    '        Return False
    '    End Try
    'End Function

    ''' <summary>
    ''' 获取来自于R服务器的输出，而不将结果打印于终端之上
    ''' </summary>
    ''' <param name="script"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function WriteLine(REngine As REngine, script As String) As String()
        Dim Result As SymbolicExpression = REngine.Evaluate(script)

        If Result Is Nothing Then
            Return {}
        Else
            If Result.Type = Internals.SymbolicExpressionType.Closure OrElse
                Result.Type = Internals.SymbolicExpressionType.Null Then
                Return New String() {}
            End If

            Dim array As String() = Result.AsCharacter().ToArray
            Return array
        End If
    End Function

    ''' <summary>
    ''' 获取来自于R服务器的输出，而不将结果打印于终端之上
    ''' </summary>
    ''' <param name="script"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Extension> Public Function WriteLine(REngine As REngine, script As IRProvider) As String()
        Return REngine.WriteLine(script.RScript)
    End Function

#If DEBUG Then
    ReadOnly __logs As StreamWriter = App.GetAppSysTempFile(".log").OpenWriter
#End If

    ''' <summary>
    ''' Evaluates a R statement in the given string.
    ''' </summary>
    ''' <param name="R"></param>
    ''' <returns></returns>
    <Extension>
    Public Function ζ(R As String) As SymbolicExpression
#If DEBUG Then
        Call __logs.WriteLine(R)
        Call __logs.Flush()
#End If
        Return RServer.Evaluate(R)
    End Function

    ''' <summary>
    ''' Evaluates a R statement in the given string.
    ''' </summary>
    ''' <param name="R"></param>
    ''' <returns></returns>
    <Extension>
    Public Function __call(R As IScriptProvider) As SymbolicExpression
#If DEBUG Then
        Call __logs.WriteLine(R.RScript)
        Call __logs.Flush()
#End If
        Return RServer.Evaluate(R.RScript)
    End Function

    ''' <summary>
    ''' Quite the R system.
    ''' </summary>
    <Extension> Public Sub q(REngine As REngine)
        Dim result = REngine.Evaluate("q()")
    End Sub
End Module
