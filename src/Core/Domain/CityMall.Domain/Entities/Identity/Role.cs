namespace CityMall.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public sealed class Role : IdentityRole<string>
{
    [MaxLength(64)]
    public override string Id { get; set; }

    [Required]
    [MaxLength(255)]
    public override string Name { get; set; }

    [AllowNull]
    public List<RoleClaim> RoleClaims { get; set; }

    [AllowNull]
    [InverseProperty(nameof(UserRoleMapper.Role))]
    public List<UserRoleMapper> UserRoleMappers { get; set; }
    public Role()
    {
        Id = $"{Guid.NewGuid()}{Guid.NewGuid()}".Replace("-", string.Empty);
        RoleClaims = new List<RoleClaim>();
        UserRoleMappers = new List<UserRoleMapper>();
    }
}
