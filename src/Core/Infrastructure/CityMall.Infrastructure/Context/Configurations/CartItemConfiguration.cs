
namespace CityMall.Infrastructure.Context.Configurations;
public sealed class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable(Tables.CartItems);
    }
}
