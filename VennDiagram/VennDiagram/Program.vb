﻿#Region "Microsoft.VisualBasic::dd196ee20656625fab1766a836293145, ..\R.Bioconductor\VennDiagram\VennDiagram\Program.vb"

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

Imports Microsoft.VisualBasic.DocumentFormat.Csv

Module Program

    Sub New()
        Dim template As String = App.HOME & "/Templates/venn.csv"
        If Not template.FileExists Then
            Dim example As New DocumentStream.File

            example += {"objA", "objB", "objC", "objD", "objE"}
            example += {"1", "1", "1", "1", "1"}
            example += {"1", "", "", "", "1"}
            example += {"", "", "1", "", "1"}
            example += {"", "1", "", "", "1"}
            example += {"1", "", "", "1", ""}

            Call example.Save(template, Encodings.ASCII)
        End If
    End Sub

    Public Function Main() As Integer
        Return GetType(CLI).RunCLI(App.CommandLine, AddressOf CLI.DrawFile)
    End Function
End Module
