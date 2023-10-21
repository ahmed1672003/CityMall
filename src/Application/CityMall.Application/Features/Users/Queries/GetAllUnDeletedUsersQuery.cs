namespace CityMall.Application.Features.Users.Queries;
public sealed record GetAllUnDeletedUsersQuery() : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;

