using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateBackend.Infrastructure.Amenities.Models;

namespace RealEstateBackend.Infrastructure.Amenities.Types
{
    public class AmenitiesType : IEntityTypeConfiguration<Amenity>
    {
        public void Configure(EntityTypeBuilder<Amenity> builder)
        {
            builder.ToTable("amenities");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("Now()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("Now()");
        }
    }
}
