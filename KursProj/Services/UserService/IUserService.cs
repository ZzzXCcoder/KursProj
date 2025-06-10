using KursProj.Dtos;

namespace KursProj.Services.UserService
{
    public interface IUserService
    {
        Task<UserProfileDto?> GetUserProfileAsync();
        Task<bool> UpdateUserProfileImage(IFormFile userprofileImage);
    }
}