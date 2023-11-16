namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class SubCategory : BaseEntity, ICreateableTracker, IUpdateableTracker, IDeleteableTracker
{
    public string Id { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<Product> Products { get; set; }
    public SubCategory() => Products = new(0);
}
