using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Projeto1.Models;

namespace Projeto1.Data;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ElencoMasculino> Jogadores { get; set; }
    public virtual DbSet<ElencoFeminino> Feminino { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ElencoMasculino>(entity =>
        {
            entity.Property(e => e.Matricula).ValueGeneratedNever();
        });

        modelBuilder.Entity<ElencoFeminino>(entity =>
        {
            entity.Property(e => e.Matricula).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}