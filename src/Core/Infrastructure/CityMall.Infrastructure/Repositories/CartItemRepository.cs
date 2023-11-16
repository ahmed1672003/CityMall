namespace CityMall.Infrastructure.Repositories;
public sealed class CartItemRepository : Repository<CartItem>, ICartItemRepository
{
    public CartItemRepository(ICityMallDbContext context) : base(context)
    {
    }
}
