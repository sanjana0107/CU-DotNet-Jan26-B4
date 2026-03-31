using IdentityServices.Models;
using IdentityServices.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using IdentityServices.DTOs;

namespace IdentityServices.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _manager;
        private readonly TokenService _service;

        public AuthController(UserManager<ApplicationUser> manager, TokenService service)
        {
            _manager = manager;
            _service = service;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Resgister(RegisterDto registerDto)
        {
            var user = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FullName = registerDto.FullName
            };

            var result = await _manager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _manager.AddToRoleAsync(user, registerDto.Role);

            return Ok(new { message = "user registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _manager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _manager.CheckPasswordAsync(user, loginDto.Password))
                return Unauthorized("Invalid Credentials");

            var roles = await _manager.GetRolesAsync(user);

            var token = _service.CreateToken(user, roles);

            return Ok(new { token });

        }
    }
}
