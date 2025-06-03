using KursProj.Entities;

namespace KursProj.IServices.Auth
{
    public interface IJWTProvider
    {
        string GenerateToken(User user);
    }
}