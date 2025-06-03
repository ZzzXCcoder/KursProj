    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    namespace KursProj.Entities
    {
        public class Answer
        {
            [Key]
            public int ID { get; set; }
            [Required]
            [ForeignKey(nameof(Question))]
            public Guid QuestionID { get; set; }
            [Required]
            public string AnswerText { get; set; }
            public bool IsCorrect { get; set; }
            public Question Question { get; set; }
        }
    }