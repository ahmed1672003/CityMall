using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.ProductImages;
public sealed class GetProductImageDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string FileName { get; set; }

    [DataType(DataType.ImageUrl)]
    public string ImageUri { get; set; }
    public string ContentType { get; set; }
    public DateTime CreatedAt { get; set; }
}
