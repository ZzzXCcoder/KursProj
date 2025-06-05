using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class CourseTestAvailability
    {
        [Key]
        public Guid CourseId { get; set; }
        [Key]
        public Guid TestId { get; set; }
        public int LessonsRequired { get; set; }

        public Course Course { get; set; }
        public Test Test { get; set; }
    }
}