namespace KursProj.Services.UserService
{
    public class UserTestShortResultDto
    {
        public Guid TestId { get; set; }
        public string TestTitle { get; set; }
        public double? Score { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}