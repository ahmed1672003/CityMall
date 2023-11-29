namespace CityMall.Domain.Entities;
[PrimaryKey(nameof(Id))]
public sealed class ProductImage : BaseEntity, ICreateableTracker
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


    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
}
