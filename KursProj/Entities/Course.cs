using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursProj.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; } // online, offline
        [ForeignKey("Instructor")]
        public Guid? InstructorID { get; set; } // nullable, если курс без преподавателя
        public User Instructor { get; set; }
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<CourseImage> CourseImages { get; set; } = new List<CourseImage>();
        public List<UserCourse> UserCourses { get; set; } = new List<UserCourse> ();
        public List<CourseTestAvailability> CourseTestAvailabilities { get; set; } = new List<CourseTestAvailability>();


    }
}
