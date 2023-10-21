namespace CityMall.Dtos.Dtos.Users.Auth;
public sealed class AuthDto
{
    public JwtDto JwtDto { get; set; }
    public RefreshJwtDto RefreshJwtDto { get; set; }
}
