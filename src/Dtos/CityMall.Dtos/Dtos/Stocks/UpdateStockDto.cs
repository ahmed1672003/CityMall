using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Stocks;
public sealed class UpdateStockDto
{

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Title { get; set; }


    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string SereetName { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string City { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Governorate { get; set; }
}
