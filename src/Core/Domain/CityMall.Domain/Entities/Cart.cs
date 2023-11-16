using CityMall.Domain.Entities.Identity;

namespace CityMall.Domain.Entities;

[PrimaryKey(nameof(Id))]
public sealed class Cart : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    public List<CartItem> CartItems { get; set; }
    public Cart() => CartItems = new(0);
}
