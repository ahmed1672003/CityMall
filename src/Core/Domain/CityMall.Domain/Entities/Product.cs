namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Product : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string StockId { get; set; }

    [Required]
    [MaxLength(36)]
    public string SKU { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string Name { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public int QtyInStock { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(name: nameof(StockId))]
    public Stock Stock { get; set; }
    public List<ProductAttributeMapper> ProductAttributeMappers { get; set; }
    public Product() => ProductAttributeMappers = new(0);
}
