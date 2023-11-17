
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class OrderLineConfigurations : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.ToTable(Tables.OrderLines);
    }
}
