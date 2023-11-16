namespace CityMall.Infrastructure.Repositories;
public sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(ICityMallDbContext context) : base(context)
    {
    }
}
