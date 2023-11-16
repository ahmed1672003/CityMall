namespace CityMall.Infrastructure.Repositories;
public sealed class StockRepository : Repository<Stock>, IStockRepository
{
    public StockRepository(ICityMallDbContext context) : base(context)
    {
    }
}
