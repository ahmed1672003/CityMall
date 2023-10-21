namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
{
    public UserTokenRepository(ICityMallDbContext context) : base(context)
    {
    }
}
