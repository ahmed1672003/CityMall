namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class Customer : BaseEntity
{
    public string Id { get; set; }
    public List<Address> Addresses { get; set; }
    public Cart Cart { get; set; }
    public Customer() =>
        Addresses = new(0);
}
