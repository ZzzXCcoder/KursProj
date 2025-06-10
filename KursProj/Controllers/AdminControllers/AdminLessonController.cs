using KursProj.Dtos;
using KursProj.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminLessonController : ControllerBase
    {
        private readonly IUserContextService _userContextService;
        private readonly IAdminLessonService _adminLessonService;
        public AdminLessonController(IUserContextService userContextService, IAdminLessonService adminLessonService)
        {
            _userContextService = userContextService;
            _adminLessonService = adminLessonService;
        }
        [HttpPost("AddLessonToCourse")]
        public async Task<IActionResult> CreateCourse([FromForm] AddLessonToCourseDto request, [FromQuery] Guid courseId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = _userContextService.GetUserId();
            var result = await _adminLessonService.AddLessonToCourse(request,userId ,courseId);
            if (result == true)
            {
                return Ok("Урок успешно добавлен к курсу");
            }
            return BadRequest("Не удалось добавить урок к курсу");
        }
    }
}
