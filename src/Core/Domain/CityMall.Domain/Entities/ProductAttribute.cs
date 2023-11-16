namespace CityMall.Domain.Entities;
public sealed class ProductAttribute : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string Name { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ProductAttributeMapper> ProductAttributeMappers { get; set; }
    public ProductAttribute() => ProductAttributeMappers = new(0);
}
