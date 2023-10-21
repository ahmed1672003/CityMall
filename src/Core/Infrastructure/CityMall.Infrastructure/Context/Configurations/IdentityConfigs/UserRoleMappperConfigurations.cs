namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class UserRoleMappperConfigurations : IEntityTypeConfiguration<UserRoleMapper>
{
    public void Configure(EntityTypeBuilder<UserRoleMapper> builder)
    {
        builder.ToTable(Tables.Identity.UserRolesMappers);
    }
}
