﻿#Region "Microsoft.VisualBasic::dacf9f1627c564ddf89e43a3e979c124, ..\R.Bioconductor\Bioconductor\Bioconductor\biocPkgs\WGCNA\App\WGCNA.vb"

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


Imports RDotNET.Extensions.VisualBasic
Imports RDotNET.Extensions.VisualBasic.SymbolBuilder.Abstract

Namespace WGCNA.App

    ''' <summary>
    ''' WGCNA脚本对象的基本结构类型
    ''' </summary>
    Public MustInherit Class WGCNA : Inherits IRScript

        Sub New()
            Requires = {"WGCNA"}
        End Sub
    End Class
End Namespace
