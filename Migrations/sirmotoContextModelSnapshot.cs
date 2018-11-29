﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sirmoto;

namespace sirmoto.Migrations
{
    [DbContext(typeof(sirmotoContext))]
    partial class sirmotoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("sirmoto.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId")
                        .HasName("IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("sirmoto.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("aspnetroles");
                });

            modelBuilder.Entity("sirmoto.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserClaims_UserId");

                    b.ToTable("aspnetuserclaims");
                });

            modelBuilder.Entity("sirmoto.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId")
                        .HasName("IX_AspNetUserLogins_UserId");

                    b.ToTable("aspnetuserlogins");
                });

            modelBuilder.Entity("sirmoto.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId")
                        .HasName("IX_AspNetUserRoles_RoleId");

                    b.ToTable("aspnetuserroles");
                });

            modelBuilder.Entity("sirmoto.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int(11)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Birthdate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("'0001-01-01 00:00:00.000000'");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<DateTime?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("aspnetusers");
                });

            modelBuilder.Entity("sirmoto.AspNetUsersTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("aspnetusertokens");
                });

            modelBuilder.Entity("sirmoto.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(95)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId");

                    b.ToTable("__efmigrationshistory");
                });

            modelBuilder.Entity("sirmoto.SirmotoDevices", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("UserIDFK");

                    b.ToTable("sirmotodevices");
                });

            modelBuilder.Entity("sirmoto.AspNetRoleClaims", b =>
                {
                    b.HasOne("sirmoto.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sirmoto.AspNetUserClaims", b =>
                {
                    b.HasOne("sirmoto.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sirmoto.AspNetUserLogins", b =>
                {
                    b.HasOne("sirmoto.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sirmoto.AspNetUserRoles", b =>
                {
                    b.HasOne("sirmoto.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("sirmoto.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sirmoto.AspNetUsersTokens", b =>
                {
                    b.HasOne("sirmoto.AspNetUsers", "User")
                        .WithMany("AspNetUsersTokens")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sirmoto.SirmotoDevices", b =>
                {
                    b.HasOne("sirmoto.AspNetUsers", "User")
                        .WithMany("SirmotoDevices")
                        .HasForeignKey("UserId")
                        .HasConstraintName("UserIDFK");
                });
#pragma warning restore 612, 618
        }
    }
}