using KursProj.Dtos;
using KursProj.IServices;
using KursProj.Services.AdminServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminTestController: ControllerBase
    {
        private readonly IAdminTestService _adminTestService;

        public AdminTestController(IAdminTestService adminTestService)
        {
            _adminTestService = adminTestService;
        }

        [HttpPost("{courseId}")]
        public async Task<IActionResult> CreateTest([FromQuery] Guid courseId, [FromBody] CreateTestDto dto)
        {
            var testId = await _adminTestService.CreateTestAsync(dto, courseId);

            if (testId == null)
                return Forbid(); // Пользователь не админ курса

            return Ok(new { TestId = testId });
        }
    }
}

