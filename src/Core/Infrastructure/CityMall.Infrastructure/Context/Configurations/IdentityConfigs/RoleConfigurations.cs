﻿namespace CityMall.Infrastructure.Context.Configurations.IdentityConfigs;
public sealed class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(Tables.Identity.Roles);
    }
}
