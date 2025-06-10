using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.Services;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ShowLessonDto> GetLessonByIdAsync(Guid lessonId)
        {
            var lesson = await _dbContext.Lessons
                .Include(l => l.LessonImages)
                .FirstOrDefaultAsync(l => l.Id == lessonId);

            if (lesson == null) return null;

            return new ShowLessonDto
            {
                Id = lesson.Id,
                Title = lesson.Title,
                Description = lesson.Description,
                LessonNumber = lesson.LessonNumber,
                Type = lesson.Type,
                ContentLink = lesson.ContentLink,
                ContentType = lesson.ContentType,
                LessonImages = lesson.LessonImages
		    .OrderBy(i => i.ImageOrder)
                    ?.Select(i => i.ImageUrl)
                    .ToList() ?? new()
            };
        }
        public async Task<ShowLessonDto> GetLessonByCourseAndNumberAsync(Guid courseId, int lessonNumber)
        {
            var lesson = await _dbContext.Lessons
                .Include(l => l.LessonImages)
                .Where(l => l.CourseId == courseId && l.LessonNumber == lessonNumber)
                .FirstOrDefaultAsync();

            if (lesson == null) return null;

            return new ShowLessonDto
            {
                Id = lesson.Id,
                Title = lesson.Title,
                Description = lesson.Description,
                LessonNumber = lesson.LessonNumber,
                Type = lesson.Type,
                ContentLink = lesson.ContentLink,
                ContentType = lesson.ContentType,
                LessonImages = lesson.LessonImages?
		    .OrderBy(i => i.ImageOrder)
                    .Select(img => img.ImageUrl)
                    .ToList() ?? new()
            };
        }
        public async Task<bool> MarkLessonAsCompletedAsync(Guid userId, Guid lessonId)
        {
            var lesson = await _dbContext.Lessons.FindAsync(lessonId);
            if (lesson == null) return false;

            var existingStatus = await _dbContext.UserLessonStatuses
                .FirstOrDefaultAsync(s => s.UserId == userId && s.LessonId == lessonId);

            if (existingStatus != null)
            {
                if (existingStatus.Status == "completed")
                    return true;

                existingStatus.Status = "completed";
            }
            else
            {
                var status = new UserLessonStatus
                {
                    UserId = userId,
                    LessonId = lessonId,
                    Status = "completed"
                };
                await _dbContext.UserLessonStatuses.AddAsync(status);
            }

            await _dbContext.SaveChangesAsync();
            return true;
        }

    }


}
