namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class RoleClaimConfigurations : IEntityTypeConfiguration<RoleClaim>
{
    public void Configure(EntityTypeBuilder<RoleClaim> builder)
    {
        builder.ToTable(Tables.Identity.RoleClaims);
    }
}
