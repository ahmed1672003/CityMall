namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Product : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string StockId { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public int Qty { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(name: nameof(StockId))]
    public Stock Stock { get; set; }
    public List<ProductAttributeMapper> ProductAttributeMappers { get; set; }
    public Product() => ProductAttributeMappers = new(0);
}
