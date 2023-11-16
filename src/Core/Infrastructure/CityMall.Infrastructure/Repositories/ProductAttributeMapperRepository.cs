namespace CityMall.Infrastructure.Repositories;
public sealed class ProductAttributeMapperRepository : Repository<ProductAttributeMapper>, IProductAttributeMapperRepository
{
    public ProductAttributeMapperRepository(ICityMallDbContext context) : base(context)
    {
    }
}
