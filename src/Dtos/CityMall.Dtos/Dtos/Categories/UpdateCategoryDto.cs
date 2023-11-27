using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Categories;

public sealed class UpdateCategoryDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string Name { get; set; }
}