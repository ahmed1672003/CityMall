namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserJWTRepository : Repository<UserJWT>, IUserJWTRepository
{
    public UserJWTRepository(ICityMallDbContext context) : base(context) { }
}
