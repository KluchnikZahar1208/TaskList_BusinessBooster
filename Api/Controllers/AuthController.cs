using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList_BusinessBooster.Infrastructure;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Domain.Entities;
using TaskList_BusinessBooster.Domain.Entities.DTO;

namespace TaskList_BusinessBooster.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _userService;
        private readonly IJwtRepository _jwtService;

        public AuthController(IAuthRepository userService, IJwtRepository jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] UserDTO request)
        {
            var user = await _userService.LoginAsync(request);

            if (user == null)
            {
                return BadRequest("Invalid email or password");
            }

            var token = _jwtService.GenerateToken(user);

            return Ok(token);
        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.RegistrationAsync(request);

            if (result)
            {
                return Ok("Registration successful");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
