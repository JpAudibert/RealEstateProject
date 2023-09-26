using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RealEstateBackend.RealEstates.Models;

namespace RealEstateBackend.RealEstates.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealEstateController : Controller
    {
        [HttpGet]
        public ActionResult<RealEstate> GetRealEstates() {
            return Ok();
        }
    }
}
