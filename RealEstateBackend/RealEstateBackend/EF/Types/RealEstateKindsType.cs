using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateBackend.RealEstateTypes.Models;

namespace RealEstateBackend.EF.Types
{
    public class RealEstateKindsType : IEntityTypeConfiguration<RealEstateKind>
    {
        public void Configure(EntityTypeBuilder<RealEstateKind> builder)
        {
            builder.ToTable("realestatekinds");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property<DateTime>("CreatedAt").ValueGeneratedOnAdd().HasDefaultValueSql("Now()");
            builder.Property<DateTime>("UpdatedAt").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("Now()");
        }
    }
}
