using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Amenities.Models;
using RealEstateBackend.EF.Types;
using RealEstateBackend.RealEstates.Models;
using RealEstateBackend.RealEstateTypes.Models;

namespace RealEstateBackend.EF
{
    public class RealEstateContext : DbContext
    {
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RealEstateKind> RealEstateKinds { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }

        public RealEstateContext(DbContextOptions options) : base(options)
        {
        }

        protected RealEstateContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .ApplyConfiguration(new AmenitiesType())
                .ApplyConfiguration(new RealEstateKindsType())
                .ApplyConfiguration(new RealEstateType());
        }
    }
}
