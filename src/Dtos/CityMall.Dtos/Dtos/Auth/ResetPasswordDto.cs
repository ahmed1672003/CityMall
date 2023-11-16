using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Auth;
public sealed class ResetPasswordDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string UserId { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Token { get; set; }

    [Required]
    public string NewPassword { get; set; }
}
