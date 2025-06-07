using KursProj.Dtos;

namespace KursProj.IRepository
{
    public interface ILessonRepository
    {
        Task<bool> AddLessonToCourse(AddLessonToCourseDto request, Guid instructorId, Guid courseId);
        Task<ShowLessonDto> GetLessonByCourseAndNumberAsync(Guid courseId, int lessonNumber);
        Task<ShowLessonDto> GetLessonByIdAsync(Guid lessonId);
        Task<bool> MarkLessonAsCompletedAsync(Guid userId, Guid lessonId);
    }
}