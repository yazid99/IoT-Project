﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sirmoto
{
    public partial class sirmotodevelContext : DbContext
    {
        public sirmotodevelContext()
        {
        }

        public sirmotodevelContext(DbContextOptions<sirmotodevelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<EfmigrationsHistory> EfmigrationsHistory { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Layanans> Layanans { get; set; }
        public virtual DbSet<PickedUpEmployees> PickedUpEmployees { get; set; }
        public virtual DbSet<PickedUpProducts> PickedUpProducts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsPictures> ProductsPictures { get; set; }
        public virtual DbSet<SirmotoDevices> SirmotoDevices { get; set; }
        public virtual DbSet<SirmotoDeviceSchedule> SirmotoDeviceSchedule { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=sigismund;Password=HolyRomanEmpire;Database=sirmotodevel");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Name).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType).HasColumnType("longtext");

                entity.Property(e => e.ClaimValue).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderKey).HasColumnType("varchar(255)");

                entity.Property(e => e.ProviderDisplayName).HasColumnType("longtext");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.RoleId).HasColumnType("varchar(255)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("varchar(255)");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.Address).HasColumnType("longtext");

                entity.Property(e => e.Birthdate).HasDefaultValueSql("'0001-01-01 00:00:00.000000'");

                entity.Property(e => e.ConcurrencyStamp).HasColumnType("longtext");

                entity.Property(e => e.Email).HasColumnType("varchar(256)");

                entity.Property(e => e.EmailConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.LockoutEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.NormalizedEmail).HasColumnType("varchar(256)");

                entity.Property(e => e.NormalizedUserName).HasColumnType("varchar(256)");

                entity.Property(e => e.PasswordHash).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumber).HasColumnType("longtext");

                entity.Property(e => e.PhoneNumberConfirmed).HasColumnType("bit(1)");

                entity.Property(e => e.SecurityStamp).HasColumnType("longtext");

                entity.Property(e => e.TwoFactorEnabled).HasColumnType("bit(1)");

                entity.Property(e => e.UserName).HasColumnType("varchar(256)");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.UserId).HasColumnType("varchar(255)");

                entity.Property(e => e.LoginProvider).HasColumnType("varchar(255)");

                entity.Property(e => e.Name).HasColumnType("varchar(255)");

                entity.Property(e => e.Value).HasColumnType("longtext");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("UserId")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PicturePath)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Companies)
                    .HasForeignKey<Companies>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CompanyBelongsToUser_fk");
            });

            modelBuilder.Entity<EfmigrationsHistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__EFMigrationsHistory");

                entity.Property(e => e.MigrationId).HasColumnType("varchar(95)");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("WorksInCompany");

                entity.HasIndex(e => e.UserId)
                    .HasName("OwnedByUser");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PicturePath).HasColumnType("varchar(255)");

                entity.Property(e => e.Rating).HasColumnType("decimal(10,0)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WorksInCompany");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OwnedByUser");
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Items)
                    .HasForeignKey<Items>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Product");
            });

            modelBuilder.Entity<Layanans>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Hit).HasColumnType("int(11)");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Layanans)
                    .HasForeignKey<Layanans>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Service_Products");
            });

            modelBuilder.Entity<PickedUpEmployees>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId)
                    .HasName("PointsToEmployee");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("BelongsToTransaction1");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.EmployeeId).HasColumnType("int(11)");

                entity.Property(e => e.TransactionId).HasColumnType("int(11)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PickedUpEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PointsToEmployee");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PickedUpEmployees)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BelongsToTransaction1");
            });

            modelBuilder.Entity<PickedUpProducts>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("ProductId_FK");

                entity.HasIndex(e => e.TransactionId)
                    .HasName("BelongsToTransaction");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.Property(e => e.TransactionId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PickedUpProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PointsToProduct");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PickedUpProducts)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("BelongsToTransaction");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descriptions)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<ProductsPictures>(entity =>
            {
                entity.HasIndex(e => e.ProductId)
                    .HasName("PicturesBelongToProduct");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProductId).HasColumnType("int(11)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductsPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PicturesBelongToProduct");
            });

            modelBuilder.Entity<SirmotoDevices>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("Owner_FK");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DeviceInfo)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.DeviceState)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SirmotoDevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Owner_FK");
            });

            modelBuilder.Entity<SirmotoDeviceSchedule>(entity =>
            {
                entity.HasIndex(e => e.DeviceId)
                    .HasName("belongstodevice_fk");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DeviceId).HasColumnType("int(11)");

                entity.Property(e => e.Duration).HasColumnType("time");

                entity.Property(e => e.Time).HasColumnType("time");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.SirmotoDeviceSchedule)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("belongstodevice_fk");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasIndex(e => e.CompanyId)
                    .HasName("OwnedByCompany1");

                entity.HasIndex(e => e.UserId)
                    .HasName("TransactionOwnedByUser");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OwnedByCompany1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TransactionOwnedByUser");
            });
        }
    }
}
