using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Usp.Api.Data.Models;

public partial class UspContext : DbContext
{
    public UspContext()
    {
    }

    public UspContext(DbContextOptions<UspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SellingPoint> SellingPoints { get; set; }

    public virtual DbSet<SellingPointPrice> SellingPointPrices { get; set; }

    public virtual DbSet<SellingPointProperty> SellingPointProperties { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:ja-main.database.windows.net,1433;Initial Catalog=usp;Persist Security Info=False;User ID=ja-admin;Password=V@rious1202;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<SellingPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SellingPoints");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<SellingPointPrice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SellingPointPrices");

            entity.HasIndex(e => e.SellingPointId, "IX_SellingPointId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.SellingPoint).WithMany(p => p.SellingPointPrices)
                .HasForeignKey(d => d.SellingPointId)
                .HasConstraintName("FK_dbo.SellingPointPrices_dbo.SellingPoints_SellingPointId");
        });

        modelBuilder.Entity<SellingPointProperty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SellingPointProperties");

            entity.HasIndex(e => e.SellingPointId, "IX_SellingPointId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.SellingPoint).WithMany(p => p.SellingPointProperties)
                .HasForeignKey(d => d.SellingPointId)
                .HasConstraintName("FK_dbo.SellingPointProperties_dbo.SellingPoints_SellingPointId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
