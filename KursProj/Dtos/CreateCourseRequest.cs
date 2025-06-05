using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class CreateCourseRequest
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }

        public List<IFormFile> Images { get; set; }

    }
}
