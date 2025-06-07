using KursProj.Dtos;
using KursProj.Entities;

namespace KursProj.IRepository
{
    public interface ITestRepository
    {
        Task<Guid?> CreateTestAsync(CreateTestDto dto, Guid courseId, Guid userId);
        Task<List<Test>> GetAvailableTestsForUserAsync(Guid userId, Guid courseId);
        Task<ShowTestDto> GetTestByCourseId(Guid courseId, Guid userId);
        Task<ShowTestDto?> GetTestByIdAsync(Guid testId);
        Task<ShowTestResultDto?> GetTestResultAsync(Guid userId, Guid testId);
        Task<bool> SubmitTestAsync(Guid userId, Guid testId, List<UserAnswerDto> userAnswers);
    }
}