namespace CityMall.Dtos.Dtos.Auth;
public sealed class GetRefreshJwtDto
{
    public string RefreshJWT { get; set; }
    public DateTime RefreshJWTExpirationDate { get; set; }
}
