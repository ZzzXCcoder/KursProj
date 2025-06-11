using KursProj.Dtos;
using KursProj.Entities;

namespace KursProj.Services.UserService
{
    public interface IUserTestService
    {
        Task<List<Test>> GetAvailableTestsAsync(Guid courseId);
        Task<ShowTestResultDto?> GetResultAsync(Guid testId);
        Task<ShowTestDto> GetTestAsync(Guid courseId);
        Task<ShowTestDto> GetTestByIdAsync(Guid testId);
        Task<List<UserTestShortResultDto>> GetUserTestResultsAsync();
        Task<bool> SubmitTestAsync(Guid testId, List<UserAnswerDto> userAnswers);
    }
}