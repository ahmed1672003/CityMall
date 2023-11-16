using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Auth;
public sealed class SendResetPasswordTokenDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string UserId { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
