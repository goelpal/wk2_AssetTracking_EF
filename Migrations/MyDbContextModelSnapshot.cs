﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wk2_AssetTracking_EF;

#nullable disable

namespace wk2_AssetTracking_EF.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("wk2_AssetTracking_EF.Asset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AssetTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<double>("PriceInUSD")
                        .HasColumnType("float");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssetTypeId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Assets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssetTypeId = 1,
                            Brand = "iPhone",
                            Model = "8",
                            OfficeId = 1,
                            PriceInUSD = 1000.4,
                            PurchaseDate = new DateTime(2018, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AssetTypeId = 2,
                            Brand = "HP",
                            Model = "Elitebook",
                            OfficeId = 1,
                            PriceInUSD = 2000.0,
                            PurchaseDate = new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AssetTypeId = 1,
                            Brand = "iPhone",
                            Model = "11",
                            OfficeId = 1,
                            PriceInUSD = 30000.0,
                            PurchaseDate = new DateTime(2020, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            AssetTypeId = 1,
                            Brand = "Motorola",
                            Model = "Razor",
                            OfficeId = 3,
                            PriceInUSD = 600.55999999999995,
                            PurchaseDate = new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("wk2_AssetTracking_EF.AssetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssetTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Phone"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Computer"
                        });
                });

            modelBuilder.Entity("wk2_AssetTracking_EF.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Offices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 3,
                            Name = "USA"
                        });
                });

            modelBuilder.Entity("wk2_AssetTracking_EF.Asset", b =>
                {
                    b.HasOne("wk2_AssetTracking_EF.AssetType", "AssetType")
                        .WithMany("TypeAssetList")
                        .HasForeignKey("AssetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("wk2_AssetTracking_EF.Office", "Office")
                        .WithMany("OfficeAssetList")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetType");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("wk2_AssetTracking_EF.AssetType", b =>
                {
                    b.Navigation("TypeAssetList");
                });

            modelBuilder.Entity("wk2_AssetTracking_EF.Office", b =>
                {
                    b.Navigation("OfficeAssetList");
                });
#pragma warning restore 612, 618
        }
    }
}
