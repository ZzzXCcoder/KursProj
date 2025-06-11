using KursProj.Dtos;
using KursProj.IServices;
using KursProj.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KursProj.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserContextService _userContextService;    

        public UserController(IUserService userService, IUserContextService userContextService)
        {
            _userService = userService;
            _userContextService = userContextService;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            // Get the user's ID from the claims
            var userId = _userContextService.GetUserId();
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
        public async Task<IActionResult> UpdateProfilePicture([FromForm] IFormFile userprofileImage)
        {
            // Get the user's ID from the claims
            var userId = _userContextService.GetUserId();
            if (userId == null)
            {
                return Unauthorized(); // Or handle the case where the user is not authenticated properly
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.UpdateUserProfileImage(userprofileImage);

            if (!result)
            {
                return BadRequest("Failed to update profile picture.");
            }

            return Ok("Profile picture updated successfully.");
        }

    }
}

 