using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class CourseTestAvailability
    {
        [Key]
        public Guid CourseID { get; set; }
        [Key]
        public Guid TestID { get; set; }
        public int LessonsRequired { get; set; }

        public Course Course { get; set; }
        public Test Test { get; set; }
    }
}