using KursProj.Dtos;
using KursProj.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserLessonController : ControllerBase
    {
        private readonly IUserLessonService _userLessonService;
        public UserLessonController(IUserLessonService userLessonService)
        {
            _userLessonService = userLessonService; 
        }
        [HttpGet("GetLessonById")]
        public async Task<IActionResult> GetLessonById(Guid lessonId)
        {
            var lesson = await _userLessonService.GetLessonByIdAsync(lessonId);
            if (lesson == null)
            {
                return BadRequest();
            }
            return Ok(lesson);

        }
        [HttpGet("by-course-and-number")]
        public async Task<IActionResult> GetLessonByCourseAndNumber([FromQuery] Guid courseId, [FromQuery] int lessonNumber)
        {
            var lesson = await _userLessonService.GetLessonByCourseAndNumberAsync(courseId, lessonNumber);
            if (lesson == null)
                return NotFound("Урок с таким номером в курсе не найден");

            return Ok(lesson);
        }
        [HttpPost("{lessonId}/complete")]
        public async Task<IActionResult> CompleteLesson(Guid lessonId)
        {
            var success = await _userLessonService.MarkLessonAsCompletedAsync(lessonId);
            if (!success)
                return BadRequest("Lesson not found or user unauthorized.");

            return Ok(new { message = "Lesson marked as completed and next lesson unlocked if exists." });
        }

    }
}
