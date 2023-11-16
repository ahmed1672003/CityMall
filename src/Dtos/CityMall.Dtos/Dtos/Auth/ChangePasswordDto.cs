using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Auth;
public sealed class ChangePasswordDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string CurrentPassord { get; set; }

    [Required]
    public string NewPassword { get; set; }

    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmedNewPassword { get; set; }
}

