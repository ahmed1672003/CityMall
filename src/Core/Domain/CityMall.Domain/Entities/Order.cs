namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Order : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
{
    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}
