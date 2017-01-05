﻿#Region "Microsoft.VisualBasic::5c6d2b2ed235cf6c0f3b51fbf35c8a2c, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\ScriptBuilder\ScriptBuilder.vb"

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

Imports System.Text
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder.Abstract

Namespace SymbolBuilder

    Public Class ScriptBuilder

        Public ReadOnly Property Script As StringBuilder

        Sub New(sb As StringBuilder)
            Script = sb
        End Sub

        Sub New(capacity As Integer)
            Script = New StringBuilder(capacity)
        End Sub

        Sub New()
        End Sub

        Public Overrides Function ToString() As String
            Return Script.ToString
        End Function

        Public Shared Narrowing Operator CType(sb As ScriptBuilder) As String
            Return sb.Script.ToString
        End Operator

        ''' <summary>
        ''' Append
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Shared Operator &(sb As ScriptBuilder, s As String) As ScriptBuilder
            Call sb.Script.Append(s)
            Return sb
        End Operator

        ''' <summary>
        ''' AppendLine
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Shared Operator +(sb As ScriptBuilder, s As String) As ScriptBuilder
            Call sb.Script.AppendLine(s)
            Return sb
        End Operator

        ''' <summary>
        ''' AppendLine
        ''' </summary>
        ''' <param name="sb"></param>
        ''' <param name="s"></param>
        ''' <returns></returns>
        Public Shared Operator +(sb As ScriptBuilder, s As IRToken) As ScriptBuilder
            Call sb.Script.AppendLine(s.RScript)
            Return sb
        End Operator
    End Class
End Namespace
