
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class AddressConfigurations : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(Tables.Addresses);
        builder.HasQueryFilter(a => !a.IsDeleted);
    }
}
