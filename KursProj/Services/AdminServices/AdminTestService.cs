using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices;

namespace KursProj.Services.AdminServices
{
    public class AdminTestService : IAdminTestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserContextService _userContext;

        public AdminTestService(ITestRepository testRepository, IUserContextService userContext)
        {
            _testRepository = testRepository;
            _userContext = userContext;
        }

        public async Task<Guid?> CreateTestAsync(CreateTestDto dto, Guid courseId)
        {
            var userId = _userContext.GetUserId();

            return await _testRepository.CreateTestAsync(dto, courseId, userId);
        }
    }
}
