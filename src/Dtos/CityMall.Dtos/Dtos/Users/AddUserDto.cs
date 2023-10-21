using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using CityMall.Domain.Enums;

using Microsoft.AspNetCore.Http;

namespace CityMall.Dtos.Dtos.Users;

public sealed class AddUserDto
{
    [Required]
    [MaxLength(255)]
    [MinLength(5)]
    [Description("UserName is unique")]
    public string UserName { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string LastName { get; set; }

    [Required]
    public Gander Gander { get; set; }

    [Required]
    [MaxLength(255)]
    [EmailAddress]
    [Description("Email is unique")]
    public string Email { get; set; }

    [Required]
    [MaxLength(255)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(255)]
    public string WhatsAppNumber { get; set; }

    public IFormFile? Image { get; set; }

    [Required]
    [MaxLength(255)]
    public string Password { get; set; }

    [Required]
    [MaxLength(255)]
    [Compare(nameof(Password))]
    public string ConfirmationPassword { get; set; }
}
