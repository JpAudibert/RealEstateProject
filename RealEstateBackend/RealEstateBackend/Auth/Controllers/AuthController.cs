using Microsoft.AspNetCore.Mvc;
using RealEstateBackend.Services.Auth.Services;
using RealEstateBackend.Services.Auth.Users.Models;

namespace RealEstateBackend.Auth.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth([FromBody] AuthRequest request)
        {
            if (request.Username == "admin" && request.Password == "admin")
            {
                var token = TokenServices.GenerateToken(new User());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}

public record AuthRequest(string Username, string Password);