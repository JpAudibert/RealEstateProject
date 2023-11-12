using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateBackend.RealEstates.Models;

namespace RealEstateBackend.EF.Types
{
    public class RealEstateType : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            throw new NotImplementedException(); 
        }
    }
}
