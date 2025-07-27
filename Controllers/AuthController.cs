using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Services;
using StreetSupply.ViewModels.Auth;
using System.Threading.Tasks;

namespace StreetSupply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _authService.LoginAsync(request);
            if (response.IsSuccess)
                return Ok(response);
            else
                return Unauthorized(response);
        }
    }
}
