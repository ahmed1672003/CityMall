namespace CityMall.Application.Features.Users.Commands;
public sealed record DeleteUserByIdCoammnd(string UserId) : IRequest<ResponseModel<GetUserDto>>;

