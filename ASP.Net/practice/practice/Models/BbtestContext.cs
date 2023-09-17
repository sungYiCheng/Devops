using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practice.Models;

public partial class BbtestContext : DbContext
{
    public BbtestContext()
    {
    }

    public BbtestContext(DbContextOptions<BbtestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bbtable> Bbtables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bbtable>(entity =>
        {
            entity.HasKey(e => e.Aa).HasName("PRIMARY");

            entity.ToTable("BBTable");

            entity.Property(e => e.Aa)
                .HasColumnType("int(11)")
                .HasColumnName("AA");
            entity.Property(e => e.Bb)
                .HasColumnType("int(11)")
                .HasColumnName("BB");
            entity.Property(e => e.Cc)
                .HasColumnType("int(11)")
                .HasColumnName("CC");
            entity.Property(e => e.Dd)
                .HasColumnType("int(11)")
                .HasColumnName("DD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
