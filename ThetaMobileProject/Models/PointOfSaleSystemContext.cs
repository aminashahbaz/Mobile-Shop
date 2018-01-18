using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ThetaMobileProject.Models
{
    public partial class PointOfSaleSystemContext : DbContext
    {
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemCatagory> ItemCatagory { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public PointOfSaleSystemContext(DbContextOptions<PointOfSaleSystemContext> abc) : base(abc)
        {

        }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=AMNA\SQLSERVER;Database=PointOfSaleSystem;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                   .HasMaxLength(250)
                   .IsUnicode(false);

                entity.Property(e =>e.Tdate)
                   .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModelNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemCatagory>(entity =>
            {
                entity.HasKey(e => e.CatagoryCode);

                entity.Property(e => e.CatagoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.Tdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VendorCode);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasColumnName("CNIC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tdate).HasColumnType("datetime");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
