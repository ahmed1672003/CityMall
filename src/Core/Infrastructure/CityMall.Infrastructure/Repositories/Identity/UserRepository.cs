namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ICityMallDbContext context) : base(context) { }
}
