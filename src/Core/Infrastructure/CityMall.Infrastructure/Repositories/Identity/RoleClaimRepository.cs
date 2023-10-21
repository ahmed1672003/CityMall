namespace CityMall.Infrastructure.Repositories.Identity;
public sealed class RoleClaimRepository : Repository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(ICityMallDbContext context) : base(context) { }
}
