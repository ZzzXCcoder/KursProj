using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.Services;

namespace KursProj.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UploadFileService _uploadFileService;
        public LessonRepository(ApplicationDbContext dbContext, UploadFileService uploadFileService)
        {
            _dbContext = dbContext;
            _uploadFileService = uploadFileService;
        }
        public async Task<bool> AddLessonToCourse(AddLessonToCourseDto request, Guid instructorId, Guid courseId)
        {
            var course = await _dbContext.Courses.FindAsync(courseId);
            if (course.InstructorId != instructorId)
            {
                return false;
            }
            var newLessson = new Lesson()
            {
                Id = Guid.NewGuid(),
                CourseId = courseId,
                Title = request.Title,
                Course = course,
                ContentLink = request.ContentLink,
                Type = request.Type,
                ContentType = request.ContentType,
                Description = request.Description,
                LessonNumber = request.LessonNumber,

            };
            List<LessonImage> lessonImages = new List<LessonImage>();
            int imageOrder = 0;
            foreach (var item in request.Images)
            {
                var path = await _uploadFileService.Upload(item);
                var lessonImage = new LessonImage()
                {
                    Id = Guid.NewGuid(),
                    ImageOrder = imageOrder++,
                    ImageUrl = path,
                    Lesson = newLessson,
                    LessonId = newLessson.Id
                };
                lessonImages.Add(lessonImage);
            }
            newLessson.LessonImages = lessonImages;
            course.Lessons.Add(newLessson);
            await _dbContext.Lessons.AddAsync(newLessson);  
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
