namespace CityMall.Services.Services;
public sealed class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(
        IAuthService authService,
        IEmailService emailService,
        IFileService fileService,
        ICacheService cacheService)
    {
        AuthService = authService;
        EmailService = emailService;
        FileService = fileService;
        CacheService = cacheService;
    }
    public IAuthService AuthService { get; }
    public IEmailService EmailService { get; }
    public IFileService FileService { get; }
    public ICacheService CacheService { get; }
}
