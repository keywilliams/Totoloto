﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TotolotoRepository.Models;

public partial class SequenciaNumerosDoSorteioSorte
{
    public int NumeroDoSorteio { get; set; }

    public int NumeroDaSorte { get; set; }

    public int Quantidade { get; set; }

    public virtual NumerosDaSorte NumeroDaSorteNavigation { get; set; }

    public virtual NumerosDoSorteio NumeroDoSorteioNavigation { get; set; }
}