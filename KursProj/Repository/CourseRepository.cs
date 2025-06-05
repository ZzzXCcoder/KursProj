using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.Services;

namespace KursProj.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UploadFileService _uploadFileService;
        private readonly IUserRepositoy _userRepository;

        public CourseRepository(ApplicationDbContext dbContext, IUserRepositoy userRepository, UploadFileService uploadFileService)
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
                InstructorID = instructor.Id,
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
                    ID = Guid.NewGuid(),
                    CourseID = newCourse.Id,
                    ImageOrder = order++,
                    ImageUrl = path
                });
            }

            await _dbContext.Courses.AddAsync(newCourse);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<>



    }
}
