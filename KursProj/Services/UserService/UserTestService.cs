using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.IServices;

namespace KursProj.Services.UserService
{
    public class UserTestService : IUserTestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserContextService _userContext;

        public UserTestService(ITestRepository testRepository, IUserContextService userContext)
        {
            _testRepository = testRepository;
            _userContext = userContext;
        }

        public async Task<List<Test>> GetAvailableTestsAsync(Guid courseId)
        {
            var userId = _userContext.GetUserId();
            return await _testRepository.GetAvailableTestsForUserAsync(userId, courseId);
        }

        public async Task<ShowTestDto> GetTestAsync(Guid courseId)
        {
            var userId = _userContext.GetUserId();
            return await _testRepository.GetTestByCourseId(courseId, userId);
        }

        public async Task<bool> SubmitTestAsync(Guid testId, List<UserAnswerDto> userAnswers)
        {
            var userId = _userContext.GetUserId();
            return await _testRepository.SubmitTestAsync(userId, testId, userAnswers);
        }

        public async Task<ShowTestResultDto?> GetResultAsync(Guid testId)
        {
            var userId = _userContext.GetUserId();
            return await _testRepository.GetTestResultAsync(userId, testId);
        }
        public async Task<ShowTestDto> GetTestByIdAsync(Guid testId)
        {
            return await _testRepository.GetTestByIdAsync(testId);
        }
        public async Task<List<UserTestShortResultDto>> GetUserTestResultsAsync()
        {
            var userId = _userContext.GetUserId();
            var results = await _testRepository.GetTestResultsForUserAsync(userId);
            return results.Select(r => new UserTestShortResultDto
            {
                TestId = r.TestId,
                TestTitle = r.Test.Title,
                Score = r.Score,
                DateCompleted = r.DateCompleted
            }).ToList();
        }


    }
}
