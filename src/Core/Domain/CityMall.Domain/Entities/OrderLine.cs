namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class OrderLine : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string OrderId { get; set; }
    public string ProductSKU { get; set; }
    public int QtyInOrder { get; set; }
    public int UnitPrice { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; }
}
