using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices.IAdminServices;
using KursProj.Repository;

namespace KursProj.Services.AdminServices
{
    public class AdminCourseService : IAdminCourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IAuthRepository _userRepositoy;

        public AdminCourseService(ICourseRepository courseRepository, IAuthRepository userRepositoy)
        {
            _courseRepository = courseRepository;
            _userRepositoy = userRepositoy;
        }
        public async Task<OperationResult> CreateCourse(CreateCourseRequest createCourseRequest, Guid instructorId)
        {
            var result = new OperationResult();
            var instructor = await _userRepositoy.GetById(instructorId);
            if (instructor == null)
            {
                result.Errors.Add("Instructor not found.");
                return result;
            }
            await _courseRepository.CreateCourse(createCourseRequest, instructor);
            result.IsSuccess = true;
            return result;

        }
    }
}
