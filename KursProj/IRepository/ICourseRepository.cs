using KursProj.Dtos;
using KursProj.Entities;

namespace KursProj.IRepository
{
    public interface ICourseRepository
    {
        Task<bool> CreateCourse(CreateCourseRequest createCourseRequest, User instructor);
        Task<Course?> GetByIdAsync(Guid id);
        Task<List<CourseListItemDto>> GetPagedCoursesAsync(int page, int pageSize);
        Task<ShowCourceDto> ShowCourse(Guid courseId);
        Task<bool> SubscribeUserToCourse(Guid userId, Guid courseId);
        Task UpdateDescriptionAsync(Course course, string newDescription);
    }
}