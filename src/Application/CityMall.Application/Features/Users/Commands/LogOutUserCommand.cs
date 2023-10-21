namespace CityMall.Application.Features.Users.Commands;
public sealed record LogOutUserCommand(LogOutUserDto Dto) : IRequest<ResponseModel<string>>;