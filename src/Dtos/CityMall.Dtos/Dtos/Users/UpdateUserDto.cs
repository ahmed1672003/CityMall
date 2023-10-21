using System.ComponentModel.DataAnnotations;

using CityMall.Domain.Enums;

namespace CityMall.Dtos.Dtos.Users;
public sealed class UpdateUserDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }

    [Required]
    [MaxLength(255)]
    public string PhoneNumber { get; set; }

    [Required]
    [MaxLength(255)]
    public string WhatsAppNumber { get; set; }

    [Required]
    public Gander Gander { get; set; }
}
