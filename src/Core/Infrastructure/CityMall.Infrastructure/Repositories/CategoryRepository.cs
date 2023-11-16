namespace CityMall.Infrastructure.Repositories;
public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(ICityMallDbContext context) : base(context)
    {
    }
}
