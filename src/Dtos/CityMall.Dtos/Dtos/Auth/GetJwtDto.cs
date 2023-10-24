namespace CityMall.Dtos.Dtos.Auth;
public sealed class GetJwtDto
{
    public string JWT { get; set; }
    public DateTime JWTExpirationDate { get; set; }
}
