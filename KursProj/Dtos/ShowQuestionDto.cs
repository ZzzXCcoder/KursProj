namespace KursProj.Dtos
{
    public class ShowQuestionDto
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public string QuestionType { get; set; }
        public List<ShowAnswerDto> Answers { get; set; }
    }
}
