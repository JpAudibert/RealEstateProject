namespace RealEstateBackend.Infrastructure.Amenities.Models
{
    public class Amenity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public Amenity(string name)
        {
            Name = name;
        }

        public Amenity() { }
    }
}
