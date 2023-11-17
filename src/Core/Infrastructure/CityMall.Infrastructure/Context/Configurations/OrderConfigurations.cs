namespace CityMall.Infrastructure.Context.Configurations;
public sealed class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(Tables.Orders);
    }
}
