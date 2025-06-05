using KursProj.Dtos;
using KursProj.IServices.IAdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminCourseController : ControllerBase
    {
        IAdminCourseService _adminCourseService;
        public AdminCourseController(IAdminCourseService adminCourseService)
        {
            _adminCourseService = adminCourseService;      
        }

        [HttpPost("createcourse")]
        public async Task<IActionResult> CreateCourse([FromForm] CreateCourseRequest request)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = GetUserIdFromClaims();
            var result = await _adminCourseService.CreateCourse(request, userId);

            if (!result.IsSuccess)
                return BadRequest(result.Errors);

            return Ok("Курс успешно создан");
        }
        private Guid GetUserIdFromClaims()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID not found in claims");

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
