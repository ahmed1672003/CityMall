namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(ICityMallDbContext context) : base(context)
    {
    }
}
