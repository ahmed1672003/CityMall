namespace CityMall.Application.Features.Users.Queries;
public sealed record SearchDeletedUsersQuery : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
