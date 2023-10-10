using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Projeto1.Models;

public partial class TrevoContext : DbContext
{
    public TrevoContext()
    {
    }

    public TrevoContext(DbContextOptions<TrevoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Jogadores> Jogadores { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Jogadores>(entity =>
        {
            entity.Property(e => e.Matricula).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}