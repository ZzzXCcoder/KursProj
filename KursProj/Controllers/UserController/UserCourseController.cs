using Microsoft.AspNetCore.Mvc;

namespace KursProj.Controllers.UserController
{
    public class UserCourseController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
