namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(ProductId), nameof(ProductAttributeId))]
public sealed class ProductAttributeMapper : ICreateableTracker, IUpdateableTracker
{
    public string ProductId { get; set; }
    public string ProductAttributeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(name: nameof(ProductAttributeId))]
    public ProductAttribute ProductAttribute { get; set; }

    [ForeignKey(name: nameof(ProductId))]
    public Product Product { get; set; }
}