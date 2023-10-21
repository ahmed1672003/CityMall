namespace CityMall.Services.Services.Contracts;
public interface IUnitOfServices
{
    IAuthService AuthService { get; }
    IEmailService EmailService { get; }
    IFileService FileService { get; }
}
