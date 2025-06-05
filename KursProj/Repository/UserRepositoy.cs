using KursProj.Data;
using KursProj.Dtos;
using KursProj.Entities;
using KursProj.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursProj.Repository
{
    public class UserRepositoy : IUserRepositoy
    {
        public ApplicationDbContext _dbContext;
        public UserRepositoy(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddUser(RegisterUserRequestDto registerUser)
        {
            if (registerUser != null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = registerUser.Name,
                    Surname = registerUser.Surname,
                    Email = registerUser.Email,
                    Login = registerUser.Login,
                    Password = registerUser.Password,
                    RegistrationDate = DateTime.UtcNow,
                    ProfileImage = "",
                    Role = "User"
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }

        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User?> GetById(Guid userId)
        {
            return await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
        public async Task AddAdmin(RegisterUserRequestDto registerUser)
        {
            if (registerUser != null)
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Name = registerUser.Name,
                    Surname = registerUser.Surname,
                    Email = registerUser.Email,
                    Login = registerUser.Login,
                    Password = registerUser.Password,
                    RegistrationDate = DateTime.UtcNow,
                    ProfileImage = "",
                    Role = "Admin"
                };
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }

        }


    }
}
