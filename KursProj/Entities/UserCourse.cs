using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserCourse
    {
        [Key]
        public Guid UserId { get; set; }
        [Key]
        public Guid CourseId { get; set; }
        public DateTime SubscriptionDate { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}