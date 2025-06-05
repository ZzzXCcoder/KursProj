using KursProj.Dtos;

namespace KursProj.IServices.IUserServices
{
    public interface IUserCourseService
    {
        Task<List<CourseListItemDto>> GetPagedCoursesAsync(int page, int pageSize);
        Task<ShowCourceDto> ShowCourse(Guid courseId);
        Task<bool> SubscribeUserToCourse(Guid userId, Guid courseId);
    }
}