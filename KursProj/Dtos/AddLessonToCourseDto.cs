using KursProj.Entities;
using System.ComponentModel.DataAnnotations;

namespace KursProj.Dtos
{
    public class AddLessonToCourseDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; } 
        public string ContentLink { get; set; }
        public string ContentType { get; set; } 
        public int LessonNumber { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}
