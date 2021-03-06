﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proconecta.Data.Contexts;

namespace Proconecta.Data.Migrations
{
    [DbContext(typeof(ProconectaContext))]
    partial class ProconectaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Proconecta.Data.Models.Category", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(8000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150) CHARACTER SET utf8mb4")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Proconecta.Data.Models.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(8000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Proconecta.Data.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(8000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Proconecta.Data.Models.Provider", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(8000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200) CHARACTER SET utf8mb4")
                        .HasMaxLength(200);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasMaxLength(255);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Proconecta.Data.Models.Review", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(8000);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProviderId")
                        .IsRequired()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("Proconecta.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36) CHARACTER SET utf8mb4")
                        .HasMaxLength(36);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PwdHashed")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Salt")
                        .HasColumnType("varchar(128) CHARACTER SET utf8mb4")
                        .HasMaxLength(128);

                    b.Property<string>("Type")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("Username")
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Proconecta.Data.Models.Product", b =>
                {
                    b.HasOne("Proconecta.Data.Models.Provider", "Provider")
                        .WithMany("Products")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proconecta.Data.Models.Project", b =>
                {
                    b.HasOne("Proconecta.Data.Models.User", "User")
                        .WithMany("Projects")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proconecta.Data.Models.Provider", b =>
                {
                    b.HasOne("Proconecta.Data.Models.User", "User")
                        .WithMany("Providers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proconecta.Data.Models.Review", b =>
                {
                    b.HasOne("Proconecta.Data.Models.Provider", "Provider")
                        .WithMany("Reviews")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
