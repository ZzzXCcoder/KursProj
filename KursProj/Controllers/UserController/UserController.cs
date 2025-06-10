using KursProj.Dtos;
using KursProj.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KursProj.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            // Get the user's ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(); // Or handle the case where the user is not authenticated properly
            }

            var profile = await _userService.GetUserProfileAsync();

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        [HttpPost("profile/picture")]
        [Authorize]
        public async Task<IActionResult> UpdateProfilePicture([FromForm] IFormFile updateProfilePictureDto)
        {
            // Get the user's ID from the claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized(); // Or handle the case where the user is not authenticated properly
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.UpdateUserProfileImage(updateProfilePictureDto);

            if (!result)
            {
                return BadRequest("Failed to update profile picture.");
            }

            return Ok("Profile picture updated successfully.");
        }

    }
}

