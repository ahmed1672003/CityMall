using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Stocks;
public sealed class GetStockDto
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


    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
