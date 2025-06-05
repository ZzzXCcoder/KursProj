using KursProj.IServices;
using KursProj.IServices.IUserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserCourseController : ControllerBase
    {
        private readonly IUserCourseService _userCourseService;
        private readonly IUserContextService _userContextService;
        public UserCourseController(IUserCourseService courseService, IUserContextService userContextService)
        {
            _userCourseService = courseService;
            _userContextService = userContextService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedCourses([FromQuery] int page = 1, [FromQuery] int size = 10)
        {
            var courses = await _userCourseService.GetPagedCoursesAsync(page, size);
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ShowCourse(Guid id)
        {
            var course = await _userCourseService.ShowCourse(id);
            if (course == null)
                return NotFound("Курс не найден");

            return Ok(course);
        }
        [HttpPost("subscribe/{courseId}")]
        public async Task<IActionResult> SubscribeUserToCourse([FromRoute] Guid courseId)
        {
            if (courseId == Guid.Empty)
                return BadRequest("Некорректный идентификатор курса.");

            var userId = _userContextService.GetUserId();
            var result = await _userCourseService.SubscribeUserToCourse(userId, courseId);
            if (!result)
                return BadRequest("Не удалось подписать пользователя на курс.");

            return Ok("Пользователь успешно подписан на курс.");
        }
    }
}
