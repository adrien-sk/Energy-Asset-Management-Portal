﻿// <auto-generated />
using System;
using EnergyPortal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnergyPortal.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250701213048_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnergyPortal.Domain.Assets.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InstallationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Assets");

                    b.HasDiscriminator<string>("AssetType").HasValue("Asset");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EnergyPortal.Domain.Sites.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("EnergyPortal.Domain.Assets.Battery", b =>
                {
                    b.HasBaseType("EnergyPortal.Domain.Assets.Asset");

                    b.Property<decimal>("ChargeCapacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CurrentCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CycleCount")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxChargeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("MaxDischargeRate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StateOfHealth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Battery");
                });

            modelBuilder.Entity("EnergyPortal.Domain.Assets.Inverter", b =>
                {
                    b.HasBaseType("EnergyPortal.Domain.Assets.Asset");

                    b.Property<decimal>("ACOutput")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ACVoltage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DCInput")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DCVoltage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Frequency")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Temperature")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Assets", t =>
                        {
                            t.Property("Temperature")
                                .HasColumnName("Inverter_Temperature");
                        });

                    b.HasDiscriminator().HasValue("Inverter");
                });

            modelBuilder.Entity("EnergyPortal.Domain.Assets.SolarPanel", b =>
                {
                    b.HasBaseType("EnergyPortal.Domain.Assets.Asset");

                    b.Property<decimal>("Azimuth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TiltAngle")
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("SolarPanel");
                });

            modelBuilder.Entity("EnergyPortal.Domain.Assets.Asset", b =>
                {
                    b.HasOne("EnergyPortal.Domain.Sites.Site", null)
                        .WithMany("Assets")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EnergyPortal.Domain.Common.ValueObjects.Capacity", "Capacity", b1 =>
                        {
                            b1.Property<Guid>("AssetId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Output")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Capacity_Output");

                            b1.Property<string>("Unit")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)")
                                .HasColumnName("Capacity_Unit");

                            b1.HasKey("AssetId");

                            b1.ToTable("Assets");

                            b1.WithOwner()
                                .HasForeignKey("AssetId");
                        });

                    b.Navigation("Capacity")
                        .IsRequired();
                });

            modelBuilder.Entity("EnergyPortal.Domain.Sites.Site", b =>
                {
                    b.OwnsOne("EnergyPortal.Domain.Sites.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Address");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("City");

                            b1.Property<decimal>("Latitude")
                                .HasPrecision(10, 7)
                                .HasColumnType("decimal(10,7)")
                                .HasColumnName("Latitude");

                            b1.Property<decimal>("Longitude")
                                .HasPrecision(10, 7)
                                .HasColumnType("decimal(10,7)")
                                .HasColumnName("Longitude");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasMaxLength(500)
                                .HasColumnType("nvarchar(500)")
                                .HasColumnName("Region");

                            b1.HasKey("SiteId");

                            b1.ToTable("Sites");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("EnergyPortal.Domain.Sites.Site", b =>
                {
                    b.Navigation("Assets");
                });
#pragma warning restore 612, 618
        }
    }
}
