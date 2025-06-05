using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserLessonView
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid LessonId { get; set; }
        public DateTime ViewDate { get; set; }

        public User User { get; set; }
        public Lesson Lesson { get; set; }
    }
}