using Microsoft.EntityFrameworkCore;
using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.Amenities.Types;
using RealEstateBackend.Infrastructure.RealEstateKinds.Models;
using RealEstateBackend.Infrastructure.RealEstateKinds.Types;
using RealEstateBackend.Infrastructure.RealEstates.Models;
using RealEstateBackend.Infrastructure.RealEstates.Types;

namespace RealEstateBackend.Infrastructure.EF
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

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity() { Name = "Piscina" },
                new Amenity() { Name = "Churrasqueira" },
                new Amenity() { Name = "Microondas" },
                new Amenity() { Name = "Mobília" },
                new Amenity() { Name = "Jardim" }
            );

            modelBuilder.Entity<RealEstateKind>().HasData(
                new RealEstateKind() { Name = "Terreno" },
                new RealEstateKind() { Name = "Casa" },
                new RealEstateKind() { Name = "Apartamento" },
                new RealEstateKind() { Name = "Área Rural" },
                new RealEstateKind() { Name = "Sala Comercial" }
            );
        }
    }
}
