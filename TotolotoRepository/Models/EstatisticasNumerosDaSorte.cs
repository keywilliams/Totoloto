﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace TotolotoRepository.Models;

public partial class EstatisticasNumerosDaSorte
{
    public int Numero { get; set; }

    public int Sorteado { get; set; }

    public int AtrasoMaximo { get; set; }

    public int AtrasoAtual { get; set; }

    public int MaiorSequencia { get; set; }

    public int SequenciaAtual { get; set; }

    public virtual NumerosDaSorte NumeroNavigation { get; set; }
}