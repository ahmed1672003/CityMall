namespace CityMall.Dtos.Dtos.Auth;
public sealed class JwtDto
{
    public string JWT { get; set; }
    public DateTime JWTExpirationDate { get; set; }
}
