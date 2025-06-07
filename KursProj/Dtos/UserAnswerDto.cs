namespace KursProj.Dtos
{
    public class UserAnswerDto
    {
        public Guid QuestionId { get; set; }
        public string SelectedAnswer { get; set; } // может быть текст или ID ответа
    }
}