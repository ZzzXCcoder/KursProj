using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class LessonImage
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public int? ImageOrder { get; set; } 
        public Lesson Lesson { get; set; }
    }
}