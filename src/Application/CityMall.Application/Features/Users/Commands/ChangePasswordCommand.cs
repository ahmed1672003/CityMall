namespace CityMall.Application.Features.Users.Commands;
public sealed record ChangePasswordCommand(ChangePasswordDto Dto) : IRequest<ResponseModel<string>>;
