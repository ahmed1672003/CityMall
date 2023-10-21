namespace CityMall.Services.Services.Contracts;
public interface IEmailService
{
    Task<SendEmailDto> SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null);
}
