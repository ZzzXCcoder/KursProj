using KursProj.Dtos;
using KursProj.Entities;

namespace KursProj.IRepository
{
    public interface IAuthRepository
    {
        public Task AddUser(RegisterUserRequestDto registerUser);
        public Task<User?> GetByEmailAsync(string email);
        public Task AddAdmin(RegisterUserRequestDto registerUser);
        public Task<User?> GetById(Guid userId);
    }
}