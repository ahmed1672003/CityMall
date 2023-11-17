namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Shipper : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string CompanyName { get; set; }
    public string CompanyPhone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public Order Order { get; set; }
}
