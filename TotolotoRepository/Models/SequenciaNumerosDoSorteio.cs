﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TotolotoRepository.Models;

public partial class SequenciaNumerosDoSorteio
{
    public int Numero { get; set; }

    public int NumeroMesmoJogo { get; set; }

    public int Quantidade { get; set; }

    public virtual NumerosDoSorteio NumeroMesmoJogoNavigation { get; set; }

    public virtual NumerosDoSorteio NumeroNavigation { get; set; }
}