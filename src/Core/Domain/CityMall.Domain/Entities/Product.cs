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

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required] // سعر البيع
    public decimal SellingUnitPrice { get; set; }

    [Required] // سعر الشراء
    public decimal PurchasingUnitPrice { get; set; }

    [Required] // الضريبة المدفوعة بالنسبة المئوية
    public decimal Tax { get; set; }

    [NotMapped]
    public decimal ProfitPrice
    {
        get
        {
            // تكلفة الضريبة من العدد الكلي
            decimal totalTaxCost = ((PurchasingUnitPrice * QtyInStock) * Tax) / 100;
            // التكلفة الكلية
            decimal totalCost = (PurchasingUnitPrice * QtyInStock) + totalTaxCost;
            return ((SellingUnitPrice * QtyInStock) - totalCost);
        }
    }

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
    public List<CartItem> CartItems { get; set; }
    public Product()
    {
        ProductAttributeMappers = new(0);
        CartItems = new(0);
    }
}
