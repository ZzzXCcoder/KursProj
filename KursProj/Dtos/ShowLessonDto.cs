namespace KursProj.Dtos
{
    public class ShowLessonDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LessonNumber { get; set; }
        public string Type { get; set; }
        public string ContentLink { get; set; }
        public string ContentType { get; set; }
        public List<string> LessonImages { get; set; }
    }
}