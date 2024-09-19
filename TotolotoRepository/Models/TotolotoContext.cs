﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TotolotoRepository.Models;

public partial class TotolotoContext : DbContext
{
    public TotolotoContext(DbContextOptions<TotolotoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coluna> Colunas { get; set; }

    public virtual DbSet<Configuration> Configurations { get; set; }

    public virtual DbSet<EstatisticasColuna> EstatisticasColunas { get; set; }

    public virtual DbSet<EstatisticasLinha> EstatisticasLinhas { get; set; }

    public virtual DbSet<EstatisticasNumerosDaSorte> EstatisticasNumerosDaSortes { get; set; }

    public virtual DbSet<EstatisticasNumerosDoSorteio> EstatisticasNumerosDoSorteios { get; set; }

    public virtual DbSet<EstatisticasNumerosUltimaDatum> EstatisticasNumerosUltimaData { get; set; }

    public virtual DbSet<EstatisticasParImpar> EstatisticasParImpars { get; set; }

    public virtual DbSet<Jogo> Jogos { get; set; }

    public virtual DbSet<Linha> Linhas { get; set; }

    public virtual DbSet<NumerosDaSorte> NumerosDaSortes { get; set; }

    public virtual DbSet<NumerosDoSorteio> NumerosDoSorteios { get; set; }

    public virtual DbSet<SequenciaNumerosDaSorte> SequenciaNumerosDaSortes { get; set; }

    public virtual DbSet<SequenciaNumerosDoSorteio> SequenciaNumerosDoSorteios { get; set; }

    public virtual DbSet<SequenciaNumerosDoSorteioSorte> SequenciaNumerosDoSorteioSortes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coluna>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK_Colunas_1");

            entity.Property(e => e.Numero).ValueGeneratedNever();

            entity.HasOne(d => d.NumeroNavigation).WithOne(p => p.ColunaNavigation)
                .HasForeignKey<Coluna>(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Colunas_Colunas");
        });

        modelBuilder.Entity<Configuration>(entity =>
        {
            entity.Property(e => e.ConfigurationKey)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ConfigurationValue).IsRequired();
        });

        modelBuilder.Entity<EstatisticasColuna>(entity =>
        {
            entity.Property(e => e.Coluna)
                .IsRequired()
                .HasMaxLength(7);
        });

        modelBuilder.Entity<EstatisticasLinha>(entity =>
        {
            entity.Property(e => e.Linha)
                .IsRequired()
                .HasMaxLength(7);
        });

        modelBuilder.Entity<EstatisticasNumerosDaSorte>(entity =>
        {
            entity.HasKey(e => e.Numero);

            entity.ToTable("EstatisticasNumerosDaSorte");

            entity.Property(e => e.Numero).ValueGeneratedNever();

            entity.HasOne(d => d.NumeroNavigation).WithOne(p => p.EstatisticasNumerosDaSorte)
                .HasForeignKey<EstatisticasNumerosDaSorte>(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstatisticasNumerosDaSorte_NumerosDaSorte");
        });

        modelBuilder.Entity<EstatisticasNumerosDoSorteio>(entity =>
        {
            entity.HasKey(e => e.Numero);

            entity.ToTable("EstatisticasNumerosDoSorteio");

            entity.Property(e => e.Numero).ValueGeneratedNever();

            entity.HasOne(d => d.NumeroNavigation).WithOne(p => p.EstatisticasNumerosDoSorteio)
                .HasForeignKey<EstatisticasNumerosDoSorteio>(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EstatisticasNumerosDoSorteio_NumerosDoSorteio");
        });

        modelBuilder.Entity<EstatisticasNumerosUltimaDatum>(entity =>
        {
            entity.HasKey(e => e.Tabela).HasName("PK_EstatisticasNumerosUltimaData_1");

            entity.Property(e => e.Tabela)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Data).HasColumnType("datetime");
        });

        modelBuilder.Entity<EstatisticasParImpar>(entity =>
        {
            entity.ToTable("EstatisticasParImpar");

            entity.Property(e => e.ParImpar)
                .IsRequired()
                .HasMaxLength(5);
        });

        modelBuilder.Entity<Jogo>(entity =>
        {
            entity.HasKey(e => e.IdJogo);

            entity.Property(e => e.Data).HasColumnType("datetime");

            entity.HasOne(d => d.Numero1Navigation).WithMany(p => p.JogoNumero1Navigations)
                .HasForeignKey(d => d.Numero1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_Numeros1");

            entity.HasOne(d => d.Numero2Navigation).WithMany(p => p.JogoNumero2Navigations)
                .HasForeignKey(d => d.Numero2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_Numeros2");

            entity.HasOne(d => d.Numero3Navigation).WithMany(p => p.JogoNumero3Navigations)
                .HasForeignKey(d => d.Numero3)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_Numeros3");

            entity.HasOne(d => d.Numero4Navigation).WithMany(p => p.JogoNumero4Navigations)
                .HasForeignKey(d => d.Numero4)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_Numeros4");

            entity.HasOne(d => d.Numero5Navigation).WithMany(p => p.JogoNumero5Navigations)
                .HasForeignKey(d => d.Numero5)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_Numeros5");

            entity.HasOne(d => d.NumeroSorteNavigation).WithMany(p => p.Jogos)
                .HasForeignKey(d => d.NumeroSorte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Jogos_NumerosDaSorte");
        });

        modelBuilder.Entity<Linha>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK_Linhas_1");

            entity.Property(e => e.Numero).ValueGeneratedNever();

            entity.HasOne(d => d.NumeroNavigation).WithOne(p => p.LinhaNavigation)
                .HasForeignKey<Linha>(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Linhas_Numeros");
        });

        modelBuilder.Entity<NumerosDaSorte>(entity =>
        {
            entity.HasKey(e => e.Numero);

            entity.ToTable("NumerosDaSorte");

            entity.Property(e => e.Numero).ValueGeneratedNever();
        });

        modelBuilder.Entity<NumerosDoSorteio>(entity =>
        {
            entity.HasKey(e => e.Numero).HasName("PK_Numeros");

            entity.ToTable("NumerosDoSorteio");

            entity.Property(e => e.Numero).ValueGeneratedNever();
        });

        modelBuilder.Entity<SequenciaNumerosDaSorte>(entity =>
        {
            entity.HasKey(e => new { e.Numero, e.NumeroAnterior });

            entity.ToTable("SequenciaNumerosDaSorte");

            entity.HasOne(d => d.NumeroNavigation).WithMany(p => p.SequenciaNumerosDaSorteNumeroNavigations)
                .HasForeignKey(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDaSorte_NumerosDaSorte");

            entity.HasOne(d => d.NumeroAnteriorNavigation).WithMany(p => p.SequenciaNumerosDaSorteNumeroAnteriorNavigations)
                .HasForeignKey(d => d.NumeroAnterior)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDaSorte_NumerosDaSorte1");
        });

        modelBuilder.Entity<SequenciaNumerosDoSorteio>(entity =>
        {
            entity.HasKey(e => new { e.Numero, e.NumeroMesmoJogo });

            entity.ToTable("SequenciaNumerosDoSorteio");

            entity.HasOne(d => d.NumeroNavigation).WithMany(p => p.SequenciaNumerosDoSorteioNumeroNavigations)
                .HasForeignKey(d => d.Numero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDoSorteio_NumerosDoSorteio");

            entity.HasOne(d => d.NumeroMesmoJogoNavigation).WithMany(p => p.SequenciaNumerosDoSorteioNumeroMesmoJogoNavigations)
                .HasForeignKey(d => d.NumeroMesmoJogo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDoSorteio_NumerosDoSorteio1");
        });

        modelBuilder.Entity<SequenciaNumerosDoSorteioSorte>(entity =>
        {
            entity.HasKey(e => new { e.NumeroDoSorteio, e.NumeroDaSorte });

            entity.ToTable("SequenciaNumerosDoSorteioSorte");

            entity.HasOne(d => d.NumeroDaSorteNavigation).WithMany(p => p.SequenciaNumerosDoSorteioSortes)
                .HasForeignKey(d => d.NumeroDaSorte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDoSorteioSorte_NumerosDaSorte");

            entity.HasOne(d => d.NumeroDoSorteioNavigation).WithMany(p => p.SequenciaNumerosDoSorteioSortes)
                .HasForeignKey(d => d.NumeroDoSorteio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SequenciaNumerosDoSorteioSorte_NumerosDoSorteio");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingGeneratedFunctions(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}