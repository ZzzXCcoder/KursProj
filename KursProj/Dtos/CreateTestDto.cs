namespace KursProj.Dtos
{
    public class CreateTestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<CreateQuestionDto> Questions { get; set; }
        public int LessonsRequired { get; set; }
    }
}
