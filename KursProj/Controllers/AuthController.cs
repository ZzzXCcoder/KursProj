using KursProj.Dtos;
using KursProj.IServices.Auth;
using KursProj.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _userService;
        
        public AuthController(IAuthService userService)
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
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserRequestDto newUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _userService.RegisterAdmin(newUser);
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

                
                HttpContext.Response.Cookies.Append("RealCoockie", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,           
                    SameSite = SameSiteMode.None,
                    Path = "/"
                });

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
            
            var userName = User.Identity?.Name ?? "неизвестный пользователь";
            return Ok($"Вы авторизованы! Привет, {userName}");
        }
      
    }
}
