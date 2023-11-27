using System.ComponentModel.DataAnnotations;

namespace CityMall.Dtos.Dtos.Products;
public sealed class GetProductDto
{
    public string Id { get; set; }
    public string SubCategoryId { get; set; }
    public string StockId { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public string UnitName { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }
    public decimal SellingUnitPrice { get; set; } // سعر البيع
    public decimal PurchasingUnitPrice { get; set; } // سعر الشراء
    public decimal Tax { get; set; } // الضريبة المدفوعة بالنسبة المئوية
    public int QtyInStock { get; set; }
    public decimal ProfitPrice { get; set; } // المكسب 
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
