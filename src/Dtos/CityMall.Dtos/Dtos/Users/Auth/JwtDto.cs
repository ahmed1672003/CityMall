namespace CityMall.Dtos.Dtos.Users.Auth;
public sealed class JwtDto
{
    public string JWT { get; set; }
    public DateTime JWTExpirationDate { get; set; }
}
