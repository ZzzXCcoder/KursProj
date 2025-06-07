using KursProj.Dtos;

namespace KursProj.IServices
{
    public interface IUserLessonService
    {
        Task<ShowLessonDto> GetLessonByCourseAndNumberAsync(Guid courseId, int lessonNumber);
        Task<ShowLessonDto> GetLessonByIdAsync(Guid lessonId);
        Task<bool> MarkLessonAsCompletedAsync(Guid lessonId);
    }
}