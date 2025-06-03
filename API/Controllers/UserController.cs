using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using moco_backend.Application.DTOs;
using moco_backend.Domain.Entities;
using moco_backend.Infrastructure.Data;
using moco_backend.Infrastructure.Services.UserServices;

namespace moco_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserIfNotExists([FromBody] UserDto userDto)
        {
            if (string.IsNullOrWhiteSpace(userDto.Email))
            {
                return BadRequest("Email is required.");
            }

            var resultMessage = await _userService.CreateUserIfNotExistsAsync(userDto);
            return Ok(new { message = resultMessage });
        }
    }
}
