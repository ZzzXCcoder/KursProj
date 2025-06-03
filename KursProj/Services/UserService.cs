using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices;
using KursProj.IServices.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace KursProj.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepositoy _userRepositoy;
        private readonly IJWTProvider _jwtProvider;
        public UserService(IPasswordHasher passwordHasher, IUserRepositoy registerUserRepositoy, IJWTProvider jWTProvider)
        {
            _passwordHasher = passwordHasher;
            _userRepositoy = registerUserRepositoy;
            _jwtProvider = jWTProvider;
        }
        public async Task Register(RegisterUserRequestDto newUser)
        {
            var hashedPassword = _passwordHasher.Generate(newUser.Password);
            newUser.Password = hashedPassword;
            await _userRepositoy.AddUser(newUser);

        }
        public async Task RegisterAdmin(RegisterUserRequestDto newUser)
        {
            var hashedPassword = _passwordHasher.Generate(newUser.Password);
            newUser.Password = hashedPassword;
            await _userRepositoy.AddAdmin(newUser);

        }
        public async Task<string> Login(string email, string login, string password)
        {
            var user = await _userRepositoy.GetByEmailAsync(email);
            var result = _passwordHasher.Verify(password, user.Password);
            if (result == false)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }
            var tocken = _jwtProvider.GenerateToken(user);
            return tocken;
        }
    }
}
