﻿#Region "Microsoft.VisualBasic::07a3b566665113386142ba551526fcd5, ..\R.Bioconductor\RDotNET.Extensions.VisualBasic\API\as.vb"

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

Namespace API.as

    Public Module stats

        ''' <summary>
        ''' as.ts and is.ts coerce an object to a time-series and test whether an object is a time series.
        ''' </summary>
        ''' <param name="x">an arbitrary R object.</param>
        ''' <param name="additionals">arguments passed to methods (unused for the default method).</param>
        ''' <returns>as.ts is generic. Its default method will use the tsp attribute of the object if it has one to set the start and end times and frequency.</returns>
        Public Function ts(x As String, ParamArray additionals As String()) As String
            Dim out As String = App.NextTempName
            Call $"{out} <- as.ts({x}, {String.Join(",", additionals)})".__call
            Return out
        End Function
    End Module
End Namespace
