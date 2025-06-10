using KursProj.Dtos;
using KursProj.IRepository;
using KursProj.IServices;
using KursProj.Repository;

namespace KursProj.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserContextService _userContextService;
        public UserService(IUserRepository userRepository, IUserContextService userContextService)
        {
            _userRepository = userRepository;
            _userContextService = userContextService;

        }
        public async Task<UserProfileDto?> GetUserProfileAsync()
        {
            var userId = _userContextService.GetUserId();
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return new UserProfileDto
            {
                Id = user.Id,
                UserName = user.Name,
                Email = user.Email,
                ProfilePictureUrl = user.ProfileImage
            };
        }
        public async Task<bool> UpdateUserProfileImage(IFormFile userprofileImage)
        {
            var userId = _userContextService.GetUserId();
            return await _userRepository.UpdateUserImage(userId, userprofileImage);
        }
    }
}
