namespace CityMall.Application.Features.Users.Queries;
public sealed record SearchAllUsersQuery : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
