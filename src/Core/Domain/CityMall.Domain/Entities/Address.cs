namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Address : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string StreetName { get; set; }
    public string StreetNumber { get; set; }
    public string City { get; set; }
    public string Countery { get; set; }
    public string Governorate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
