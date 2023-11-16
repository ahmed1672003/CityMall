using CityMall.Dtos.Dtos.Auth;

namespace CityMall.Services.Services.Contracts;
public interface IAuthService
{
    Func<string, JwtSecurityToken, Task<bool>> IsJWTValid { get; }
    Task<AuthDto> GetJWTAsync(User user);
    Task<JwtSecurityToken> ReadJWTAsync(string jwt);
    Task<AuthDto> RefreshJWTAsync(UserJWT userjWT);
    Task<bool> RevokeJWTAsync(UserJWT user);
}
