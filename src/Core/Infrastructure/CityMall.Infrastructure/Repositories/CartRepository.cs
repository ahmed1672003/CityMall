namespace CityMall.Infrastructure.Repositories;
public sealed class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(ICityMallDbContext context) : base(context)
    {
    }
}
