namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class UserTokenConfigurations : IEntityTypeConfiguration<UserToken>
{
    public void Configure(EntityTypeBuilder<UserToken> builder)
    {
        builder.ToTable(Tables.Identity.UserTokens);
    }
}
