using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskList_BusinessBooster.Application.Commands;
using TaskList_BusinessBooster.Domain.Entities.DTO;
using TaskList_BusinessBooster.Domain.Interfaces;
using TaskList_BusinessBooster.Infrastructure;

namespace TaskList_BusinessBooster.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserByEmail()
        {
            var command = new GetUserByEmailCommand(User.FindFirst(ClaimTypes.Email)?.Value);
            var user = await _mediator.Send(command);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfile(UserDTO userDTO)
        {
            var command = new GetUserByEmailCommand(User.FindFirst(ClaimTypes.Email)?.Value);
            var user = await _mediator.Send(command);

            if (user == null)
            {
                return NotFound();
            }
            var commandUpdate = new UpdateUserProfileCommand
            {
                UserId = user.Id,
                NewEmail = userDTO.Email,
                NewName = userDTO.UserName,
                NewPassword = userDTO.Password
            };
            try
            {
                await _mediator.Send(commandUpdate);
                return Ok("Profile updated successfully.");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the profile.");
            }
        }
    }
}
