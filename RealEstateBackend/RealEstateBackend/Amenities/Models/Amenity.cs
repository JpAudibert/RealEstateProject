namespace RealEstateBackend.Amenities.Models
{
    public class Amenity
    {
        public Guid Id { get; }
        public string Name { get; set; } = string.Empty;

        public Amenity(string name)
        {
            Name = name;
        }

        public Amenity() { }
    }
}
