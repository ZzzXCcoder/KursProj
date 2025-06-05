using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices.IUserServices;

namespace KursProj.Services.UserService
{
    public class UserCourseService : IUserCourseService
    {
        private readonly ICourseRepository _courseRepository;
        public UserCourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<ShowCourceDto> ShowCourse(Guid courseId)
        {
            return await _courseRepository.ShowCourse(courseId);
        }
        public async Task<List<CourseListItemDto>> GetPagedCoursesAsync(int page, int pageSize)
        {
            return await _courseRepository.GetPagedCoursesAsync(page, pageSize);
        }
        public async Task<bool> SubscribeUserToCourse(Guid userId, Guid courseId)
        {
            return await _courseRepository.SubscribeUserToCourse(userId, courseId);
        }
    }
}
