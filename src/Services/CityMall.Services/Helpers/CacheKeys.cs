namespace CityMall.Services.Helpers;
public static class CacheKeys
{
    public static class User
    {
        public const string Prefix = "users";
        public static Func<string, string> GetUserKey = (id) => $"{Prefix}-{id}";
    }
    public static class Jwt
    {
        public const string Prefix = "jwts";
        public static Func<string, string> GetJwtKey = (id) => $"{Prefix}-{id}";

    }
}
