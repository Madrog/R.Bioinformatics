﻿#Region "Microsoft.VisualBasic::e27af0e85e20bad365a026e3dcbb6c30, ..\R.Bioconductor\RDotNET\R.NET\Internals\YesNoCancel.vb"

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

Namespace Internals
	''' <summary>
	''' User's decision.
	''' </summary>
	Public Enum YesNoCancel
		''' <summary>
		''' User agreed.
		''' </summary>
		Yes = 1

		''' <summary>
		''' User disagreed.
		''' </summary>
		No = -1

		''' <summary>
		''' User abandoned to answer.
		''' </summary>
		Cancel = 0
	End Enum
End Namespace
