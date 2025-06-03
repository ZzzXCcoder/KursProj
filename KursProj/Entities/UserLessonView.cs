using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserLessonView
    {
        [Key]
        public Guid UserID { get; set; }
        [Key]
        public Guid LessonID { get; set; }
        public DateTime ViewDate { get; set; }

        public User User { get; set; }
        public Lesson Lesson { get; set; }
    }
}