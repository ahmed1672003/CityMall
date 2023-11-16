namespace CityMall.Application.Features.Users.Commands;
public sealed record ResetPasswordCommand(ResetPasswordDto Dto) : IRequest<ResponseModel<string>>;
