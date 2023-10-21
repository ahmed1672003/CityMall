namespace CityMall.Application.Features.Users.Queries;
public sealed record GetUserByIdQuery(string UserId) : IRequest<ResponseModel<GetUserDto>>;
