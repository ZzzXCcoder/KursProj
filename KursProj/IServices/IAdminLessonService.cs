using KursProj.Dtos;

namespace KursProj.IServices
{
    public interface IAdminLessonService
    {
        Task<bool> AddLessonToCourse(AddLessonToCourseDto request, Guid instructorId, Guid courseId);
    }
}