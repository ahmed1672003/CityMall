namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class SubCategory : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(3)]
    public string Name { get; set; }

    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string CategoryId { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Product> Products { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
    public SubCategory() => Products = new(0);
}