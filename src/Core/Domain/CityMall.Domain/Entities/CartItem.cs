namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class CartItem : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string ProductId { get; set; }

    [Required]
    public int PaiedQty { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}
