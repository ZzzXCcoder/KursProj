using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class Test
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<TestResult> TestResults { get; set; } = new List<TestResult>();
        public List<CourseTestAvailability> CourseTestAvailabilities { get; set; } = new List<CourseTestAvailability>();
    }
}
