using KursProj.Dtos;

namespace KursProj.IServices
{
    public interface IUserService
    {
        Task<string> Login(string email, string login, string password);
        Task Register(RegisterUserRequestDto newUser);
    }
}