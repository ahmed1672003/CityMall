namespace CityMall.Application.Features.Users.Commands;
public sealed record UndoDeleteUserByIdCommand(string UserId) : IRequest<ResponseModel<GetUserDto>>;
