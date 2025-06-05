using System.ComponentModel.DataAnnotations;

namespace KursProj.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid TestId { get; set; }
        [Required]
        public string QuestionText { get; set; }
        public string QuestionType { get; set; } // multiple choice, text input и т.д.
        public Test Test { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public List<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}