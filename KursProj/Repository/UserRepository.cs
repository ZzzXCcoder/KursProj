using KursProj.Data;
using KursProj.Entities;
using KursProj.IRepository;
using KursProj.Services;

namespace KursProj.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UploadFileService _uploadFileService;
        public UserRepository(ApplicationDbContext dbContext, UploadFileService uploadFileService)
        {
            _dbContext = dbContext;
            _uploadFileService = uploadFileService;
        }
        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _dbContext.Users.FindAsync(userId);
        }

        public async Task<bool> UpdateUserImage(Guid userId, IFormFile file)
        {
            string pathToFile = await _uploadFileService.Upload(file);
            var user = await _dbContext.Users.FindAsync(userId);
            user.ProfileImage = pathToFile;
            _dbContext.Users.Update(user);

            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
