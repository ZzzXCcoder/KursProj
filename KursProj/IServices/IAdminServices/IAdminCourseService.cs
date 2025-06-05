using KursProj.Dtos;

namespace KursProj.IServices.IAdminServices
{
    public interface IAdminCourseService
    {
        Task<OperationResult> CreateCourse(CreateCourseRequest createCourseRequest, Guid instructorId);
    }
}