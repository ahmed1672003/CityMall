namespace CityMall.Infrastructure.Repositories;
public sealed class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
{
    public ProductImageRepository(ICityMallDbContext context) : base(context)
    {
    }
}
