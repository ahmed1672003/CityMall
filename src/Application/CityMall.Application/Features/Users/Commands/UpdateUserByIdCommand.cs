namespace CityMall.Application.Features.Users.Commands;
public sealed record UpdateUserByIdCommand(UpdateUserDto Dto) : IRequest<ResponseModel<GetUserDto>>;