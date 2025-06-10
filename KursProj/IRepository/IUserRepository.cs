using KursProj.Entities;

namespace KursProj.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(Guid userId);
        Task<bool> UpdateUserImage(Guid userId, IFormFile file);
    }
}