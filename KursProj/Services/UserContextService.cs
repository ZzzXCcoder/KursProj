using KursProj.IServices;

namespace KursProj.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userIdClaim = user?.Claims.FirstOrDefault(c => c.Type == "userId");

            if (userIdClaim == null)
                throw new UnauthorizedAccessException("User ID not found in claims");

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
