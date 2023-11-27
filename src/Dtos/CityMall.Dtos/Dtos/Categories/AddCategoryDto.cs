using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Categories;

public sealed class AddCategoryDto
{

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Name { get; set; }
}
