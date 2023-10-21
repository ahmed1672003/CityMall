namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class UserJWTConfigurations : IEntityTypeConfiguration<UserJWT>
{
    public void Configure(EntityTypeBuilder<UserJWT> builder)
    {
        builder.ToTable(Tables.Identity.UserJWTs);
    }
}
