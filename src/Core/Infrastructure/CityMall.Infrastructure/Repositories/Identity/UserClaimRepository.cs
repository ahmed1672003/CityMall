namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(ICityMallDbContext context) : base(context)
    {
    }
}
