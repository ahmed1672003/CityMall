using CityMall.Dtos.Dtos.Auth;

namespace CityMall.Application.Features.Users.Commands;
public sealed record AddUserCommand(AddUserDto Dto) : IRequest<ResponseModel<AuthDto>>;