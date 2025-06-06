using KursProj.Dtos;

namespace KursProj.IRepository
{
    public interface ILessonRepository
    {
        Task<bool> AddLessonToCourse(AddLessonToCourseDto request, Guid instructorId, Guid courseId);
    }
}