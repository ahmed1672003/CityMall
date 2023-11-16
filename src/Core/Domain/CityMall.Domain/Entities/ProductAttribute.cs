namespace CityMall.Domain.Entities;
public sealed class ProductAttribute : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(255)]
    [MinLength(255)]
    public string Name { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<ProductAttributeMapper> ProductAttributeMappers { get; set; }
    public ProductAttribute() => ProductAttributeMappers = new(0);
}
