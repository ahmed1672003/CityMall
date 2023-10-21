namespace CityMall.Dtos.Dtos.Users.Auth;
public sealed class RefreshJwtDto
{
    public string RefreshJWT { get; set; }
    public DateTime RefreshJWTExpirationDate { get; set; }
}
