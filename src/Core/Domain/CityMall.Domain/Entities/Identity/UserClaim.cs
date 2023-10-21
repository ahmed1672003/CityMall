namespace CityMall.Domain.Entities.Identity;

[PrimaryKey(nameof(Id))]
public sealed class UserClaim : IdentityUserClaim<string>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override int Id { get; set; }

    [Required]
    [MaxLength(64)]
    public override string UserId { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimType { get; set; }

    [Required]
    [MaxLength(255)]
    public override string ClaimValue { get; set; }

}
