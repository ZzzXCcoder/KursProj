namespace KursProj.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate {  get; set; }

        public string ProfileImage {  get; set; }

        public string Role { get; set; }

        public List<Course> Courses { get; set; } = new List<Course>();
        public List<TestResult> TestResults { get; set; } = new List<TestResult>();
        public List<Notification> Notifications { get; set; } = new List<Notification>();

        public List<UserCourse> UserCourses { get; set; } = new List<UserCourse>();

        public List<UserLessonStatus> UserLessonStatuses { get; set; } = new List<UserLessonStatus>();

        public List<UserLessonView> UserLessonViews { get; set; } = new List<UserLessonView>();


    }
}
