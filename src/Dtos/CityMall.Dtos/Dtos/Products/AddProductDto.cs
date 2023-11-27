using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Products;
public sealed class AddProductDto
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string SubCategoryId { get; set; }
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string StockId { get; set; }

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
}
