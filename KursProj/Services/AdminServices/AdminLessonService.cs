using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices;
using KursProj.Repository;

namespace KursProj.Services.AdminServices
{
    public class AdminLessonService : IAdminLessonService
    {
        private readonly ILessonRepository _lessonRepository;
        public AdminLessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public async Task<bool> AddLessonToCourse(AddLessonToCourseDto request, Guid instructorId, Guid courseId)
        {
            return await _lessonRepository.AddLessonToCourse(request, instructorId, courseId);
        }

    }
}
