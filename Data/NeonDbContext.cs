using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using moco_backend.Models;

namespace moco_backend.Data;

public partial class NeonDbContext : DbContext
{
    public NeonDbContext()
    {
    }

    public NeonDbContext(DbContextOptions<NeonDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DummyTable> DummyTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DummyTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("DummyTable_pkey");

            entity.ToTable("DummyTable");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("jsonb")
                .HasColumnName("data");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
