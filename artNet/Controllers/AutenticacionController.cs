using artNet.Domain.Entities;
using artNet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static artNet.Models.AutenticacionViewModels;
namespace artNet.Controllers
{
    public class AutenticacionController
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAutenticacionService _autenticacionService;

            public AuthController(IAutenticacionService autenticacionService)
            {
                _autenticacionService = autenticacionService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterRequest request)
            {
                var token = await _autenticacionService.RegisterAsync(request);
                return Ok(new { Token = token });
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginRequest request)
            {
                var token = await _autenticacionService.LoginAsync(request);
                return Ok(new { Token = token });
            }

            [Authorize]
            [HttpGet("me")]
            public async Task<IActionResult> GetProfile()
            {
                var username = User.Identity!.Name!;
                var user = await _autenticacionService.GetUserByUsernameAsync(username);

                if (user == null)
                    return NotFound();

                return Ok(new { user.Id, user.Username, user.Email });
            }
        }

    }
}
