using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Addresses;
public sealed class AddAddressDto
{
    [Required]
    [StringLength(64)]
    public string CustomerId { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string StreetName { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string StreetNumber { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string City { get; set; }


    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string Governorate { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(255)]
    public string Country { get; set; }
}
