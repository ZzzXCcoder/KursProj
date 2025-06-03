using KursProj.Entities;
using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class RegisterUserRequestDto
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
