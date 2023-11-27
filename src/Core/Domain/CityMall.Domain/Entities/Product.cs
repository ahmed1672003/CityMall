namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
[Index(nameof(SKU), IsUnique = true)]
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
    [MaxLength(64)]
    [MinLength(64)]
    public string SubCategoryId { get; set; }

    [Required]
    [MaxLength(36)]
    public string SKU { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(1)]
    public string UnitName { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required] // سعر البيع
    public decimal SellingUnitPrice { get; set; }

    [Required] // سعر الشراء
    public decimal PurchasingUnitPrice { get; set; }

    [Required] // الضريبة المدفوعة بالنسبة المئوية
    public decimal Tax { get; set; }

    [Required]
    public int QtyInStock { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [NotMapped]
    public decimal ProfitPrice //المكسب
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
    [ForeignKey(name: nameof(StockId))]
    public Stock Stock { get; set; }

    [ForeignKey(nameof(SubCategoryId))]
    public SubCategory SubCategory { get; set; }
    public List<ProductAttributeMapper> ProductAttributeMappers { get; set; }
    public List<CartItem> CartItems { get; set; }
    public List<ProductImage> ProductImages { get; set; }
    public Product()
    {
        ProductAttributeMappers = new(0);
        CartItems = new(0);
        ProductImages = new(0);
    }
}
