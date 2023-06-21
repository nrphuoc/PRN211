using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace ShopFlower.Models
{
    public partial class ShopFlowerContext : DbContext
    {
        public ShopFlowerContext()
        {
        }

        public ShopFlowerContext(DbContextOptions<ShopFlowerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillItem> BillItems { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conf = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conf.GetConnectionString("DbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Bill__0809337D7889ADF1");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("orderID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedAt)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("created_at");

                entity.Property(e => e.CusId).HasColumnName("cusID");

                entity.Property(e => e.StaffId).HasColumnName("staffID");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.HasOne(d => d.Cus)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.CusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bill__cusID__34C8D9D1");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Bills_Staffs");
            });

            modelBuilder.Entity<BillItem>(entity =>
            {
                entity.HasKey(e => new { e.ProId, e.OrderId })
                    .HasName("PK__BillItem__9B3B7DE2B11FEBA1");

                entity.Property(e => e.ProId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("proID");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("orderID");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.BillItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillDetai__order__35BCFE0A");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.BillItems)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BillItems__proID__35BCFE0A");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CusId)
                    .HasName("PK__Customer__BA9897D3DBF43C3A");

                entity.HasIndex(e => e.Username, "UQ__Customer__F3DBC572C2AD0D81")
                    .IsUnique();

                entity.Property(e => e.CusId).HasColumnName("cusID");

                entity.Property(e => e.CusAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cusAddress");

                entity.Property(e => e.CusName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cusName");

                entity.Property(e => e.CusPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("cusPhone");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProId)
                    .HasName("PK__Products__5BBBEED503C12899");

                entity.Property(e => e.ProId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("proID");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("image");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("proName");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Admin__F3DBC572DF7554DE")
                    .IsUnique();

                entity.Property(e => e.StaffId)
                    .ValueGeneratedNever()
                    .HasColumnName("staffID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ManagerId).HasColumnName("managerID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("storeID");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_Staffs_Staffs");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Staffs__storeID__6EF57B66");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("PK__Stocks__AC761B27A52F0162");

                entity.Property(e => e.StoreId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("storeID");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stocks__productI__3A81B327");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Stocks__storeID__5EBF139D");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("storeID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Storename)
                    .HasMaxLength(50)
                    .HasColumnName("storename");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
