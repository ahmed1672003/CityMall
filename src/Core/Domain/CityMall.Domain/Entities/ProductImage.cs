namespace CityMall.Domain.Entities;
[PrimaryKey(nameof(Id))]
public sealed class ProductImage : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string FileName { get; set; }

    [Required]
    [MaxLength(1500)]
    [DataType(DataType.ImageUrl)]
    public string ImageUri { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string ContentType { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
