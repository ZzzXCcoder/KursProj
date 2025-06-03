using KursProj.Entities;
using KursProj.IServices.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KursProj.Services.Auth
{
    public class JWTProvider(IOptions<JwtOptions> options) : IJWTProvider
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateToken(User user)
        {
            Claim[] claims =
            [
                new("userId", user.Id.ToString()),
                new(ClaimTypes.Role, user.Role)
            ];
            var signingCredentails = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var tocken = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentails,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours)
                );
            var tokenValue = new JwtSecurityTokenHandler().WriteToken(tocken);

            return tokenValue;
        }
    }
}
