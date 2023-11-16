namespace CityMall.Domain.Entities;
[PrimaryKey(nameof(Id))]
public sealed class ProductImage : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string FileName { get; set; }
    public string ImageUri { get; set; }
    public string ContentType { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
