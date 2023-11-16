namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Category : BaseEntity, IDeleteableTracker, ICreateableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string Name { get; set; }
    public bool IsDeleted { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<SubCategory> SubCatories { get; set; }
    public Category() =>
        SubCatories = new(0);
}
