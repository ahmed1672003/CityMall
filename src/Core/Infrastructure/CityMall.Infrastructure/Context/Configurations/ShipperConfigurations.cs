
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class ShipperConfigurations : IEntityTypeConfiguration<Shipper>
{
    public void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.ToTable(Tables.Shippers);
    }
}
