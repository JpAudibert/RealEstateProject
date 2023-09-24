using Microsoft.AspNetCore.Mvc;

namespace RealEstateBackend.Amenities.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenitiesController : Controller
    {
        [HttpGet("v1")]
        public IActionResult GetAmenities()
        {
            return Ok();
        }
    }
}
