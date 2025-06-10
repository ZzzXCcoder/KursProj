using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class UpdateProfilePictureDto
    {
        [Required]
        public IFormFile ProfilePicture { get; set; }
    }
}
