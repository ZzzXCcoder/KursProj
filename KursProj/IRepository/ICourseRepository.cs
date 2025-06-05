using KursProj.Dtos;
using KursProj.Entities;

namespace KursProj.IRepository
{
    public interface ICourseRepository
    {
        Task<bool> CreateCourse(CreateCourseRequest createCourseRequest, User instructor);
    }
}