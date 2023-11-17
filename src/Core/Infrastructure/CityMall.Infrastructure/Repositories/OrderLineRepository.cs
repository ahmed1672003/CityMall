
namespace CityMall.Infrastructure.Repositories;
public sealed class OrderLineRepository : Repository<OrderLine>, IOrderLineRepository
{
    public OrderLineRepository(ICityMallDbContext context) : base(context) { }
}
