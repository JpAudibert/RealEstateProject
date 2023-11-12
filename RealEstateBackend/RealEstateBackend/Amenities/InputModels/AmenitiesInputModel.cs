using System.ComponentModel.DataAnnotations;

namespace RealEstateBackend.Amenities.InputModels
{
    public class AmenitiesInputModel
    {
        [Required(ErrorMessage ="Amenities Name is required")]
        [MaxLength(50, ErrorMessage ="Maximum of 50 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
