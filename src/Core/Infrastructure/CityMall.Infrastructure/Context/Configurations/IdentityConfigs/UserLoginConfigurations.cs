namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class UserLoginConfigurations : IEntityTypeConfiguration<UserLogin>
{
    public void Configure(EntityTypeBuilder<UserLogin> builder)
    {
        builder.ToTable(Tables.Identity.UserLogins);
    }
}
