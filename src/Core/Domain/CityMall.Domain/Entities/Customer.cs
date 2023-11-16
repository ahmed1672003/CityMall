namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class Customer : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    [MaxLength(64)]
    [MinLength(64)]
    public string Id { get; set; }

    [Required]
    [MaxLength(25)]
    public string FirstPhone { get; set; }

    [AllowNull]
    [MaxLength(25)]
    public string? SecondPhone { get; set; }
    public List<Address> Addresses { get; set; }
    public Cart Cart { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public Customer() =>
        Addresses = new(0);
}
