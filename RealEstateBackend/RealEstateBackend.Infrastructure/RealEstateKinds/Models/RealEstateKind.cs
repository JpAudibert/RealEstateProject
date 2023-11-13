using RealEstateBackend.Infrastructure.RealEstates.Models;

namespace RealEstateBackend.Infrastructure.RealEstateKinds.Models
{
    public class RealEstateKind
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ICollection<RealEstate> RealEstates { get; set; } = new List<RealEstate>();

        public RealEstateKind() { }

        public RealEstateKind(string name)
        {
            Name = name;
        }
    }
}
