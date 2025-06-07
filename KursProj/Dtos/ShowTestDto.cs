namespace KursProj.Dtos
{
    public class ShowTestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<ShowQuestionDto> Questions { get; set; }
    }
}
