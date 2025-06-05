using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserAnswer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TestResultId { get; set; }
        [Required]
        public Guid QuestionId { get; set; }
        public string SelectedAnswer { get; set; } // Текст ответа (если free text) или ID выбранного варианта
        public TestResult TestResult { get; set; }
        public Question Question { get; set; }
    }
}