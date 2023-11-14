using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.RealEstateKinds.Models;

namespace RealEstateBackend.Infrastructure.RealEstates.Models
{
    public sealed class RealEstate
    {
        public Guid Id { get; } = Guid.NewGuid();
        public bool IsActive { get; set; } = true;
        public string ComercialType { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Number { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public double SquareFoot { get; set; }
        public double PrivateSquareFoot { get; set; }
        public double SellValue { get; set; }
        public double RentValue { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int Garage { get; set; }
        public RealEstateKind RealEstateKind { get; set; } = new();
        public Guid RealEstateKindId { get; set; }
        public ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
    }
}
