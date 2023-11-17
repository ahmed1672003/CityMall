
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class CartConfigurations : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.ToTable(Tables.Carts);
    }
}
