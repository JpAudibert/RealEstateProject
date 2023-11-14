using RealEstateBackend.Infrastructure.RealEstates.Models;

namespace RealEstateBackend.Infrastructure.Amenities.Models
{
    public class Amenity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ICollection<RealEstate> RealEstates { get; set; } = new List<RealEstate>();

        public Amenity(string name)
        {
            Name = name;
        }

        public Amenity() { }
    }
}
