namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Order : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string CustomerId { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string ShipperId { get; set; }

    [Required]
    public OrderStatus OrderStatus { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<OrderLine> OrderLines { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }

    [ForeignKey(nameof(ShipperId))]
    public Shipper Shipper { get; set; }
    public Order()
    {
        OrderLines = new(0);
    }
}
