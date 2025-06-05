using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserLessonStatus
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid LessonId { get; set; }
        [Required]
        public string Status { get; set; } // "locked", "unlocked", "completed"
        public DateTime? UnlockDate { get; set; } // Дата разблокировки (если разблокировка по времени)

        public User User { get; set; }
        public Lesson Lesson { get; set; }
    }
}