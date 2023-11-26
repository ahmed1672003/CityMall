using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CityMall.Dtos.Dtos.Customers;
public sealed class AddCustomerDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string UserId { get; set; }
    [Required]
    [MaxLength(25)]
    public string FirstPhone { get; set; }

    [AllowNull]
    [MaxLength(25)]
    public string? SecondPhone { get; set; }
}
