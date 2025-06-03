using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}