namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Category : BaseEntity, IDeleteableTracker, ICreateableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<SubCategory> SubCatories { get; set; }
    public Category() =>
        SubCatories = new(0);
}
