namespace CityMall.Infrastructure.Repositories;
public sealed class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ICityMallDbContext context) : base(context) { }
}
