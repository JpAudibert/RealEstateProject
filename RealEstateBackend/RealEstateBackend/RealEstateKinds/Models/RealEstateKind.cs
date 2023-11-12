namespace RealEstateBackend.RealEstateTypes.Models
{
    public class RealEstateKind
    {
        public Guid Id { get; }
        public string Name { get; set; } = string.Empty;

        public RealEstateKind() { }

        public RealEstateKind(string name)
        {
            Name = name;
        }
    }
}
