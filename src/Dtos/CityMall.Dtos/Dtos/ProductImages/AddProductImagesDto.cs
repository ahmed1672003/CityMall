using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Http;

namespace CityMall.Dtos.Dtos.ProductImages;
public sealed class AddProductImagesDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string ProductId { get; set; }

    [Required]
    public List<IFormFile> Images { get; set; }
}