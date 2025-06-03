using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class Lesson
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid CourseID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonNumber { get; set; }
        [Required]
        public string Type { get; set; } // video, text, image
        public string ContentLink { get; set; }
        public string ContentType { get; set; } // text, url, html и т.д.
        public Course Course { get; set; }
        public List<LessonImage> LessonImages { get; set; }
        public List<UserLessonStatus> UserLessonStatuses { get; set; } = new List<UserLessonStatus>();  
        public List<UserLessonView> UserLessonViews { get; set; } = new List<UserLessonView>();

    }
}
