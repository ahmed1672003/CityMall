using Microsoft.Extensions.Caching.Distributed;

namespace CityMall.Infrastructure.Repositories.Caching.Identity;
public sealed class CachedUserRepository
{
    private readonly IDistributedCache _cache;
    public CachedUserRepository()
    {

    }

}
