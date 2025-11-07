using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testmvc.Models;

public partial class ndtDbContext : DbContext
{
    public ndtDbContext()
    {
    }

    public ndtDbContext(DbContextOptions<ndtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NdtCatalog> NdtCatalogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=NguyenDucThach_231230898_de02;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NdtCatalog>(entity =>
        {
            entity.HasKey(e => e.NdtId).HasName("PK__ndtCatal__3322C3829778D5BC");

            entity.ToTable("ndtCatalog");

            entity.Property(e => e.NdtId).HasColumnName("ndtId");
            entity.Property(e => e.NdtCateActive).HasColumnName("ndtCateActive");
            entity.Property(e => e.NdtCateName)
                .HasMaxLength(100)
                .HasColumnName("ndtCateName");
            entity.Property(e => e.NdtCatePrice).HasColumnName("ndtCatePrice");
            entity.Property(e => e.NdtCateQty).HasColumnName("ndtCateQty");
            entity.Property(e => e.NdtPicture)
                .HasMaxLength(255)
                .HasColumnName("ndtPicture");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
