namespace CityMall.Application.Features.Users.Commands;
public sealed record SendResetPasswordTokenCommand(SendResetPasswordTokenDto Dto) : IRequest<ResponseModel<SendEmailDto>>;