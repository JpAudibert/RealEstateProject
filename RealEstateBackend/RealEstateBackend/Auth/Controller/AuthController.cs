using Microsoft.AspNetCore.Mvc;
using RealEstateBackend.Services;

namespace RealEstateBackend.Auth.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                var token = TokenServices.GenerateToken(new Users.Models.User());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}
