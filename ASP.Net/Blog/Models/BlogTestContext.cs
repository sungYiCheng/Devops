using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models;

public partial class BlogTestContext : DbContext
{
    public BlogTestContext()
    {
    }

    public BlogTestContext(DbContextOptions<BlogTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Auth> Auths { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Article");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.Content).HasMaxLength(200);
            entity.Property(e => e.Ctime).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Auth>(entity =>
        {
            entity.HasKey(e => e.Account).HasName("PRIMARY");

            entity.ToTable("Auth");

            entity.Property(e => e.Account).HasMaxLength(30);
            entity.Property(e => e.Pwd).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
