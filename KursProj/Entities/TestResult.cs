using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class TestResult
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid TestID { get; set; }
        [Required]
        public Guid UserID { get; set; }
        public double? Score { get; set; } // Оценка (nullable, если тест не пройден)
        public DateTime DateCompleted { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }
        public List<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}