using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("panel")]
        public IActionResult AdminPanel()
        {
            var adminId = User.FindFirst("userId")?.Value;
            return Ok($"Панель администратора. Ваш ID: {adminId}");
        }
    }
}
