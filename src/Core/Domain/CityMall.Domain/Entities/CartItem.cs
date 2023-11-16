namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class CartItem : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public int PaiedQty { get; set; }
    public decimal UnitPrice { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
