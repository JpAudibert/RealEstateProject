using System.ComponentModel.DataAnnotations;

namespace RealEstateBackend.RealEstateTypes.InputModels
{
    public class RealEstateKindsInputModel
    {
        [Required(ErrorMessage = "Amenities Name is required")]
        [MaxLength(50, ErrorMessage = "Maximum of 50 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
