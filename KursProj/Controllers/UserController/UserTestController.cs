using KursProj.Dtos;
using KursProj.Services;
using KursProj.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers
{
    [ApiController]
    [Route("api/user/tests")]
    [Authorize] // Только авторизованные пользователи
    public class UserTestController : ControllerBase
    {
        private readonly IUserTestService _userTestService;

        public UserTestController(IUserTestService userTestService)
        {
            _userTestService = userTestService;
        }

        // Получить список доступных тестов по курсу
        [HttpGet("available/{courseId}")]
        public async Task<IActionResult> GetAvailableTests(Guid courseId)
        {
            var tests = await _userTestService.GetAvailableTestsAsync(courseId);
            return Ok(tests);
        }

        // Получить тест для прохождения (если доступен)
        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetTest(Guid courseId)
        {
            var test = await _userTestService.GetTestAsync(courseId);

            if (test == null)
                return NotFound("Test not available or already submitted");

            return Ok(test);
        }

        // Отправить тест
        [HttpPost("submit/{testId}")]
        public async Task<IActionResult> SubmitTest(Guid testId, [FromBody] List<UserAnswerDto> userAnswers)
        {
            var success = await _userTestService.SubmitTestAsync(testId, userAnswers);

            if (!success)
                return BadRequest("Submission failed or test already completed");

            return Ok("Test submitted successfully");
        }

        // Получить результаты
        [HttpGet("result/{testId}")]
        public async Task<IActionResult> GetResult(Guid testId)
        {
            var result = await _userTestService.GetResultAsync(testId);

            if (result == null)
                return NotFound("Result not found");

            return Ok(result);
        }
        [HttpGet("byId/{testId}")]
        public async Task<IActionResult> GetTestById(Guid testId)
        {
            

            var testDto = await _userTestService.GetTestByIdAsync(testId);

            if (testDto == null)
                return NotFound();

            return Ok(testDto);
        }
    }
}
