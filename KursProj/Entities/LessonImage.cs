using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class LessonImage
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid LessonID { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public Guid? ImageOrder { get; set; } // Порядок отображения (null, если не важен)
        public Lesson Lesson { get; set; }
    }
}