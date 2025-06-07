using KursProj.Dtos;

namespace KursProj.IServices
{
    public interface IAdminTestService
    {
        Task<Guid?> CreateTestAsync(CreateTestDto dto, Guid courseId);
    }
}