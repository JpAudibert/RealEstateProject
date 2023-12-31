﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateBackend.Infrastructure.RealEstates.Models;

namespace RealEstateBackend.Infrastructure.RealEstates.Types
{
    public class RealEstateType : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder.ToTable("realestates");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IsActive).IsRequired().HasColumnType("boolean");
            builder.Property(x => x.ComercialType).IsRequired().HasColumnType("varchar(50)"); // may change
            builder.Property(x => x.Title).IsRequired().HasColumnType("varchar(60)");
            builder.Property(x => x.Description).IsRequired().HasColumnType("varchar(500)");
            builder.Property(x => x.Address).IsRequired().HasColumnType("varchar(150)");
            builder.Property(x => x.Number).IsRequired().HasColumnType("int");
            builder.Property(x => x.City).IsRequired().HasColumnType("varchar(70)");
            builder.Property(x => x.State).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.ZipCode).IsRequired().HasColumnType("varchar(10)");
            builder.Property(x => x.SquareFoot).IsRequired().HasColumnType("double precision");
            builder.Property(x => x.PrivateSquareFoot).IsRequired().HasColumnType("double precision");
            builder.Property(x => x.SellValue).IsRequired().HasColumnType("double precision");
            builder.Property(x => x.RentValue).IsRequired().HasColumnType("double precision");
            builder.HasOne(x => x.RealEstateKind)
                .WithMany(x => x.RealEstates)
                .HasForeignKey(x => x.RealEstateKindId)
                .HasPrincipalKey(x => x.Id);

            builder.HasMany(x => x.Amenities)
                .WithMany(x => x.RealEstates)
                .UsingEntity(x => x.ToTable("realestatesamenities"));

            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("Now()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("Now()");
        }
    }
}
