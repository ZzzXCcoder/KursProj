using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserCourse
    {
        [Key]
        public Guid UserID { get; set; }
        [Key]
        public Guid CourseID { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}