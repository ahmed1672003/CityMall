using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.SubCategories;

public sealed class UpdateSubCategoryDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string CategoryId { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Name { get; set; }
}
