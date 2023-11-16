namespace CityMall.Application.Features.Email.Queries;
public sealed record SendEmailsQuery(string Subject, string Body, IEnumerable<IFormFile> Files = null) : IRequest<ResponseModel<string>>;
