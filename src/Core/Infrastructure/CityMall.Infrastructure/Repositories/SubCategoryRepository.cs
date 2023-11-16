namespace CityMall.Infrastructure.Repositories;
public sealed class SubCategoryRepository : Repository<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(ICityMallDbContext context) : base(context)
    {
    }
}
