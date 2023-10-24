using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Auth;
public sealed class AuthDto
{
    public GetJwtDto JwtDto { get; set; }
    public GetRefreshJwtDto RefreshJwtDto { get; set; }
}

public sealed class UpdateRefreshTokenDto
{
    [Required]
    public string JWT { get; set; }

    [Required]
    public string RefreshToken { get; set; }
}