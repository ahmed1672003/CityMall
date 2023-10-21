namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserLoginRepository : Repository<UserLogin>, IUserLoginRepository
{
    public UserLoginRepository(ICityMallDbContext context) : base(context)
    {
    }
}
