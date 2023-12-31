﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RealEstateBackend.Infrastructure.EF;

#nullable disable

namespace RealEstateBackend.Migrations
{
    [DbContext(typeof(RealEstateContext))]
    partial class RealEstateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AmenityRealEstate", b =>
                {
                    b.Property<Guid>("AmenitiesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RealEstatesId")
                        .HasColumnType("uuid");

                    b.HasKey("AmenitiesId", "RealEstatesId");

                    b.HasIndex("RealEstatesId");

                    b.ToTable("realestatesamenities", (string)null);
                });

            modelBuilder.Entity("RealEstateBackend.Infrastructure.Amenities.Models.Amenity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.HasKey("Id");

                    b.ToTable("amenities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ac51cfd-b8b0-4dc9-ac4e-511f8cf8fba8"),
                            Name = "Piscina"
                        },
                        new
                        {
                            Id = new Guid("c85ddffa-756b-4723-8744-1444dc4a8bed"),
                            Name = "Churrasqueira"
                        },
                        new
                        {
                            Id = new Guid("41a63c90-8664-4b4c-aaa5-ac9ab957d5ca"),
                            Name = "Microondas"
                        },
                        new
                        {
                            Id = new Guid("57be2fe0-0754-4a6e-a5c8-31a00355e901"),
                            Name = "Mobília"
                        },
                        new
                        {
                            Id = new Guid("85b0e8bf-a464-41de-886b-bd244de84aac"),
                            Name = "Jardim"
                        });
                });

            modelBuilder.Entity("RealEstateBackend.Infrastructure.RealEstateKinds.Models.RealEstateKind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.HasKey("Id");

                    b.ToTable("realestatekinds", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1bda995f-4753-495e-a565-5e5bddc93535"),
                            Name = "Terreno"
                        },
                        new
                        {
                            Id = new Guid("4818dfb3-a5c8-4805-8d0e-eea07676ad5b"),
                            Name = "Casa"
                        },
                        new
                        {
                            Id = new Guid("185f4186-02ef-4816-b5a8-30cc492e742b"),
                            Name = "Apartamento"
                        },
                        new
                        {
                            Id = new Guid("b83b287a-329f-4b4e-8d1e-326e84cb030b"),
                            Name = "Área Rural"
                        },
                        new
                        {
                            Id = new Guid("2f4bd07c-c916-426f-9e01-338ba2c38d4f"),
                            Name = "Sala Comercial"
                        });
                });

            modelBuilder.Entity("RealEstateBackend.Infrastructure.RealEstates.Models.RealEstate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Bathrooms")
                        .HasColumnType("integer");

                    b.Property<int>("Bedrooms")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(70)");

                    b.Property<string>("ComercialType")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Garage")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<double>("PrivateSquareFoot")
                        .HasColumnType("double precision");

                    b.Property<Guid>("RealEstateKindId")
                        .HasColumnType("uuid");

                    b.Property<double>("RentValue")
                        .HasColumnType("double precision");

                    b.Property<double>("SellValue")
                        .HasColumnType("double precision");

                    b.Property<double>("SquareFoot")
                        .HasColumnType("double precision");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("Now()");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("RealEstateKindId");

                    b.ToTable("realestates", (string)null);
                });

            modelBuilder.Entity("AmenityRealEstate", b =>
                {
                    b.HasOne("RealEstateBackend.Infrastructure.Amenities.Models.Amenity", null)
                        .WithMany()
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstateBackend.Infrastructure.RealEstates.Models.RealEstate", null)
                        .WithMany()
                        .HasForeignKey("RealEstatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstateBackend.Infrastructure.RealEstates.Models.RealEstate", b =>
                {
                    b.HasOne("RealEstateBackend.Infrastructure.RealEstateKinds.Models.RealEstateKind", "RealEstateKind")
                        .WithMany("RealEstates")
                        .HasForeignKey("RealEstateKindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstateKind");
                });

            modelBuilder.Entity("RealEstateBackend.Infrastructure.RealEstateKinds.Models.RealEstateKind", b =>
                {
                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
