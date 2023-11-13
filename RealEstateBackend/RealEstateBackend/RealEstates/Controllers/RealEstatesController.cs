using Microsoft.AspNetCore.Mvc;
using RealEstateBackend.Infrastructure.RealEstates.Models;

namespace RealEstateBackend.RealEstates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstatesController : Controller
    {
        [HttpGet]
        public ActionResult<RealEstate> GetRealEstates() {
            return Ok();
        }
    }
}
