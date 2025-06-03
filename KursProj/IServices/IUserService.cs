using KursProj.Dtos;

namespace KursProj.IServices
{
    public interface IUserService
    {
        public Task<string> Login(string email, string login, string password);

        public Task RegisterAdmin(RegisterUserRequestDto newUser);
        public Task Register(RegisterUserRequestDto newUser);
    }
}