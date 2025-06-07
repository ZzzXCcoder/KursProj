using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices;
using KursProj.Repository;

namespace KursProj.Services.UserService
{
    public class UserLessonService : IUserLessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IUserContextService _userContext;
        public UserLessonService(ILessonRepository lessonRepository, IUserContextService userContextService)
        {
            _lessonRepository = lessonRepository;
            _userContext = userContextService;
        }
        public async Task<ShowLessonDto> GetLessonByIdAsync(Guid lessonId)
        {
            return await _lessonRepository.GetLessonByIdAsync(lessonId);
        }
        public async Task<ShowLessonDto> GetLessonByCourseAndNumberAsync(Guid courseId, int lessonNumber)
        {
            return await _lessonRepository.GetLessonByCourseAndNumberAsync(courseId, lessonNumber);
        }
        public async Task<bool> MarkLessonAsCompletedAsync(Guid lessonId)
        {
            var userId = _userContext.GetUserId();
            return await _lessonRepository.MarkLessonAsCompletedAsync(userId, lessonId);
        }


    }
}
