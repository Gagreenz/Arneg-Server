using Arneg_Server.Dtos.User;
using Arneg_Server.Models;
using Arneg_Server.Models.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Arneg_Server.Services.AccountService.Interfaces
{
    public interface IUserRepository
    {
        Task<ServiceResponse<User>> Register(UserRegisterDto userRegisterDto);
        Task<ServiceResponse<User>> Login(UserLoginDto userLoginDto);
        Task<ServiceResponse<User>> GetUserById(Guid id);
        Task SetRefreshToken(RefreshToken refreshToken);
        Task<bool> DeleteRefreshToken(JwtSecurityToken refreshToken);
        Task<bool> IsUserExist(string login);

    }
}