namespace CityMall.Infrastructure.Repositories;
public sealed class ProductAttributeRepository : Repository<ProductAttribute>, IProductAttributeRepository
{
    public ProductAttributeRepository(ICityMallDbContext context) : base(context)
    {
    }
}
