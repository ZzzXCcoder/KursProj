using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.Services;
using Microsoft.EntityFrameworkCore;

namespace KursProj.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UploadFileService _uploadFileService;
        private readonly IAuthRepository _userRepository;

        public CourseRepository(ApplicationDbContext dbContext, IAuthRepository userRepository, UploadFileService uploadFileService)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _uploadFileService = uploadFileService;

        }
        public async Task<bool> CreateCourse(CreateCourseRequest createCourseRequest, User instructor)
        {
            _dbContext.Users.Attach(instructor);
            var newCourse = new Course
            {
                Id = Guid.NewGuid(),
                InstructorId = instructor.Id,
                Instructor = instructor,
                Description = createCourseRequest.Description,
                Name = createCourseRequest.Name,
                Type = createCourseRequest.Type
            };

            var newFiles = createCourseRequest.Images ?? new List<IFormFile>();
            int order = 0;

            foreach (var file in newFiles)
            {
                var path = await _uploadFileService.Upload(file);
                newCourse.CourseImages.Add(new CourseImage
                {
                    Id = Guid.NewGuid(),
                    CourseId = newCourse.Id,
                    ImageOrder = order++,
                    ImageUrl = path
                });
            }

            await _dbContext.Courses.AddAsync(newCourse);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<ShowCourceDto> ShowCourse(Guid courseId)
        {
            var course = await _dbContext.Courses
                                         .Include(c => c.CourseImages.OrderBy(ci => ci.ImageOrder))
                                         .Include(l => l.Lessons)
                                         .FirstOrDefaultAsync(c => c.Id == courseId);
            if (course == null) return null;

            var courseToShow = new ShowCourceDto()
            {
                Name = course.Name,
                Type = course.Type,
                Description = course.Description,
                ImageUrl = course.CourseImages
                                 .Select(ci => ci.ImageUrl)
                                 .ToList(),
                courseLessons = course.Lessons
                                    .Select(lesson => new ShowCourseLessonsDto
                                    {
                                        Id = lesson.Id,
                                        Name = lesson.Title,
                                        Description = lesson.Description,
                                        Order = lesson.LessonNumber,
                                    })
                                    .ToList()

            };
            return courseToShow;
        }
        public async Task<List<CourseListItemDto>> GetPagedCoursesAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;

            var courses = await _dbContext.Courses
                .Include(c => c.CourseImages)
                .OrderBy(c => c.Name)  
                .Skip(skip)
                .Take(pageSize)
                .Select(c => new CourseListItemDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Type = c.Type,
                    ImageUrl = c.CourseImages
                        .OrderBy(ci => ci.ImageOrder)
                        .Select(ci => ci.ImageUrl)
                        .FirstOrDefault() ?? string.Empty
                })
                .ToListAsync();

            return courses;
        }
        public async Task<bool> DeleteCourse(Guid courseId)
        {
            var course = await _dbContext.Courses
                .Include(c => c.CourseImages)
                .FirstOrDefaultAsync(c => c.Id == courseId);

            if (course == null)
                return false;

           
            _dbContext.CourseImages.RemoveRange(course.CourseImages);

            _dbContext.Courses.Remove(course);

            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> SubscribeUserToCourse(Guid userId, Guid courseId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            var course = await _dbContext.Courses.FindAsync(courseId);

            if (user == null || course == null)
                return false;

            var alreadySubscribed = await _dbContext.UserCourses
                .AnyAsync(uc => uc.UserId == userId && uc.CourseId == courseId);

            if (alreadySubscribed)
                return false;

            var userCourse = new UserCourse
            {
                UserId = userId,
                CourseId = courseId,
                SubscriptionDate = DateTime.UtcNow
            };

            await _dbContext.UserCourses.AddAsync(userCourse);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<Course?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Courses.FindAsync(id);
        }

        public async Task UpdateDescriptionAsync(Course course, string newDescription)
        {
            course.Description = newDescription;
            _dbContext.Courses.Update(course); // Явно указываем, что курс нужно обновить
            await _dbContext.SaveChangesAsync();
        }



    }
}
