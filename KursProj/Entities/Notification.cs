using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class Notification
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Type { get; set; } // new_lesson, test_available, и т.д.
        [Required]
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsRead { get; set; }
        public User User { get; set; }
    }
}