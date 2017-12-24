﻿#Region "Microsoft.VisualBasic::bb6bbdff3586e9b47da7c8512638ec94, ..\R.Bioconductor\Test\Module1.vb"

    ' Author:
    ' 
    '       asuka (amethyst.asuka@gcmodeller.org)
    '       xieguigang (xie.guigang@live.com)
    '       xie (genetics@smrucc.org)
    ' 
    ' Copyright (c) 2018 GPL3 Licensed
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

Imports RDotNET.Extensions.Bioinformatics
Imports RDotNET.Extensions.VisualBasic.API
Imports RDotNET.Extensions.VisualBasic

Module Module1

    Sub Main()

        require("polysat")

        Dim oooo = polysat.calcFst(polysat.myfreq)

        Dim nn = RDotNET.Extensions.Bioinformatics.adegenet.genind.nancycats

        Dim nnx As var = 44

        nnx = {1, 2, 3, 4, 5}


        Pause()
    End Sub

End Module
