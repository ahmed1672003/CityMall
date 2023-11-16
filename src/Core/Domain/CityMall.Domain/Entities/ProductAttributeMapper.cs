namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(ProductId), nameof(ProductAttributeId))]
public sealed class ProductAttributeMapper : ICreateableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string ProductId { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string ProductAttributeId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(name: nameof(ProductAttributeId))]
    public ProductAttribute ProductAttribute { get; set; }

    [ForeignKey(name: nameof(ProductId))]
    public Product Product { get; set; }
}