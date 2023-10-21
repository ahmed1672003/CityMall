namespace CityMall.Application.Features.Users.Commands;
public sealed record LoginUserCommand(LoginUserDto Dto) : IRequest<ResponseModel<AuthDto>>;