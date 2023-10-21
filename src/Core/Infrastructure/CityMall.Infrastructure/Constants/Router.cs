namespace CityMall.Infrastructure.Constants;
public static class Router
{
    private const string Api = "api/";
    private const string ApiVersion = "v1/";
    private const string ApiPrefix = Api + ApiVersion;
    public static class User
    {
        public const string ConfirmeEmail = ApiPrefix + "confirme-email";
    }
}
