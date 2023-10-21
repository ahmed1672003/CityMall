namespace CityMall.Infrastructure.Helpers;
public static class CacheKeysCreator
{
    public static Func<string, string> GetUserKey = (id) => $"users-{id}";
}
