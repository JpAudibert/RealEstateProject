using RealEstateBackend.Infrastructure.Amenities.Models;
using RealEstateBackend.Infrastructure.RealEstateKinds.Models;

namespace RealEstateBackend.RealEstates.InputModels
{
    public class RealEstateInputModel
    {
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
        public Guid RealEstateKindId { get; set; } = Guid.Empty;
        public ICollection<Guid> Amenities { get; set; } = new List<Guid>() { Guid.Empty};
    }
}
