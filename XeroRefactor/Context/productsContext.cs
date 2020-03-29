using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace XeroRefactor
{
    public partial class productsContext : DbContext
    {
        public productsContext()
        {
        }

        public productsContext(DbContextOptions<productsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProductOptions> ProductOptions { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=App_Data/products.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOptions>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.Id).HasName("PK_ProductOptions");

                entity.Property(e => e.Description).HasColumnType("varchar(23)");

                entity.Property(e => e.Id).HasColumnType("varchar(36)");

                entity.Property(e => e.Name).HasColumnType("varchar(9)");

                entity.Property(e => e.ProductId).HasColumnType("varchar(36)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                //entity.HasNoKey();
                entity.HasKey(e => e.Id).HasName("PK_Products");

                entity.Property(e => e.DeliveryPrice).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Description).HasColumnType("varchar(35)");

                entity.Property(e => e.Id).HasColumnType("varchar(36)");

                entity.Property(e => e.Name).HasColumnType("varchar(17)");

                entity.Property(e => e.Price).HasColumnType("decimal(6,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
