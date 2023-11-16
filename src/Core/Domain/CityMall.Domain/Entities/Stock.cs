namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Stock : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Product> Products { get; set; }
    public Stock() => Products = new(0);
}