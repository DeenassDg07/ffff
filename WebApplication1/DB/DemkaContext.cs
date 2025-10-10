using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebApplication1.DB;

public partial class DemkaContext : DbContext
{
    public DemkaContext()
    {
    }

    public DemkaContext(DbContextOptions<DemkaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CrossMaterialProduct> CrossMaterialProducts { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Metrika> Metrikas { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("userid=student;password=student;database=_demka;server=192.168.200.13", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.39-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CrossMaterialProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CrossMaterialProduct");

            entity.HasIndex(e => e.IdMaterial, "FK_CrossMaterialProduct_Material_id");

            entity.HasIndex(e => e.IdProduct, "FK_CrossMaterialProduct_Product_article");

            entity.Property(e => e.IdMaterial)
                .HasColumnType("int(11)")
                .HasColumnName("id_material");
            entity.Property(e => e.IdProduct)
                .HasColumnType("int(11)")
                .HasColumnName("id_product");
            entity.Property(e => e.MaterialCount).HasColumnName("material_count");

            entity.HasOne(d => d.IdMaterialNavigation).WithMany()
                .HasForeignKey(d => d.IdMaterial)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossMaterialProduct_Material_id");

            entity.HasOne(d => d.IdProductNavigation).WithMany()
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CrossMaterialProduct_Product_article");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Material");

            entity.HasIndex(e => e.MaterialTypeId, "FK_Material_Material_type_id");

            entity.HasIndex(e => e.MetricaId, "FK_Material_Metrika_id");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.MaterialTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("material_type_id");
            entity.Property(e => e.MetricaId)
                .HasColumnType("int(11)")
                .HasColumnName("metrica_id");
            entity.Property(e => e.MinCount).HasColumnName("min_count");
            entity.Property(e => e.PackCount).HasColumnName("pack_count");
            entity.Property(e => e.Price)
                .HasPrecision(19, 2)
                .HasColumnName("price");
            entity.Property(e => e.StorageCount).HasColumnName("storage_count");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.MaterialType).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MaterialTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material_Material_type_id");

            entity.HasOne(d => d.Metrica).WithMany(p => p.Materials)
                .HasForeignKey(d => d.MetricaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Material_Metrika_id");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Material_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.LosePercent).HasColumnName("lose_percent");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Metrika>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Metrika");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Article).HasName("PRIMARY");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ProductTypeId, "FK_Product_Product_type_id");

            entity.Property(e => e.Article)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("article");
            entity.Property(e => e.MinCost)
                .HasPrecision(10)
                .HasColumnName("min_cost");
            entity.Property(e => e.ProductTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("product_type_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Product_type_id");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Product_type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Coificient).HasColumnName("coificient");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
