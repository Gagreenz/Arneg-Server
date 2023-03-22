using Arneg_Server.Models;
using Arneg_Server.Models.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Arneg_Server.Services.TokenService.Interfaces
{
    public interface ITokenService
    {
        public string GenerateAccessToken(User user);
        public RefreshToken GenerateRefreshToken(User user);
        public JwtSecurityToken GetJwt(string token);
        public bool VerifyRefreshToken(User user, string refreshToken);
    }
}
