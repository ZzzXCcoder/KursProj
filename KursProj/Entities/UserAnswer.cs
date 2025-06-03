using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class UserAnswer
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Guid TestResultID { get; set; }
        [Required]
        public Guid QuestionID { get; set; }
        public string SelectedAnswer { get; set; } // Текст ответа (если free text) или ID выбранного варианта
        public TestResult TestResult { get; set; }
        public Question Question { get; set; }
    }
}