namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserRoleMapperRepository : Repository<UserRoleMapper>, IUserRoleMapperRepository
{
    public UserRoleMapperRepository(ICityMallDbContext context) : base(context)
    {
    }
}
