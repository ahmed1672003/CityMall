using CityMall.Services.Services.Contracts;

namespace CityMall.Services.Services;
public sealed class UnitOfSevices : IUnitOfServices
{
    public UnitOfSevices(
        IAuthService authService,
        IEmailService emailService,
        IFileService fileService)
    {
        AuthService = authService;
        EmailService = emailService;
        FileService = fileService;
    }
    public IAuthService AuthService { get; }
    public IEmailService EmailService { get; }
    public IFileService FileService { get; }
}
