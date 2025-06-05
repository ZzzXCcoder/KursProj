using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class TestResult
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TestId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public double? Score { get; set; } // Оценка (nullable, если тест не пройден)
        public DateTime DateCompleted { get; set; }
        public Test Test { get; set; }
        public User User { get; set; }
        public List<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}