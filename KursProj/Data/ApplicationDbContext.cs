using KursProj.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseImage> CourseImages { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonImage> LessonImages { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserLessonStatus> UserLessonStatuses { get; set; }
        public DbSet<CourseTestAvailability> CourseTestAvailabilities { get; set; }
        public DbSet<UserLessonView> UserLessonViews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCourse>()
           .HasKey(uc => new { uc.UserID, uc.CourseID });

            modelBuilder.Entity<UserLessonStatus>()
                .HasKey(uls => new { uls.UserID, uls.LessonID });

            modelBuilder.Entity<CourseTestAvailability>()
                .HasKey(cta => new { cta.CourseID, cta.TestID });

            modelBuilder.Entity<UserLessonView>()
                .HasKey(ulv => new { ulv.UserID, ulv.LessonID });
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    
}
