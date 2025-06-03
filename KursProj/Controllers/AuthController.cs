using KursProj.Dtos;
using KursProj.IServices;
using KursProj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDto newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userService.Register(newUser);
                return Ok(new { message = "User registered successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var token = await _userService.Login(loginDto.Email, loginDto.Login, loginDto.Password);
                HttpContext.Response.Cookies.Append("RealCoockie", token);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected()
        {
            // Можно получить данные текущего пользователя
            var userName = User.Identity?.Name ?? "неизвестный пользователь";
            return Ok($"Вы авторизованы! Привет, {userName}");
        }
    }
}
