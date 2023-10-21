using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Auth;
public sealed class LoginUserDto
{
    [Required]
    [MaxLength(255)]
    public string EmailOrUserName { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(5)]
    public string Password { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(5)]
    [Compare(nameof(Password))]
    public string ConfirmationPassword { get; set; }
}
