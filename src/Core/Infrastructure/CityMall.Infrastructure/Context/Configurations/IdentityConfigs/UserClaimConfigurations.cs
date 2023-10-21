namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class UserClaimConfigurations : IEntityTypeConfiguration<UserClaim>
{
    public void Configure(EntityTypeBuilder<UserClaim> builder)
    {
        builder.ToTable(Tables.Identity.UserClaims);
    }
}
