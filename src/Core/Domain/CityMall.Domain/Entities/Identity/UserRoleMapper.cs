namespace CityMall.Domain.Entities.Identity;

[PrimaryKey(nameof(UserId), nameof(RoleId))]
public sealed class UserRoleMapper : IdentityUserRole<string>
{
    [Required]
    [MaxLength(64)]
    public override string UserId { get; set; }

    [Required]
    [MaxLength(64)]
    public override string RoleId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }

    public UserRoleMapper()
    {
    }
}
