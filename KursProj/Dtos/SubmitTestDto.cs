namespace KursProj.Dtos
{
    public class SubmitTestDto
    {
        public Guid TestId { get; set; }
        public List<UserAnswerDto> Answers { get; set; }
    }
}
