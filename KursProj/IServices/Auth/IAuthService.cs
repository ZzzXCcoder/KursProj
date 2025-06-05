using KursProj.Dtos;

namespace KursProj.IServices.Auth
{
    public interface IAuthService
    {
        public Task<string> Login(string email, string login, string password);

        public Task RegisterAdmin(RegisterUserRequestDto newUser);
        public Task Register(RegisterUserRequestDto newUser);
    }
}