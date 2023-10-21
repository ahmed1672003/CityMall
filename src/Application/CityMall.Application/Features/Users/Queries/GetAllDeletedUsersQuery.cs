namespace CityMall.Application.Features.Users.Queries;
public sealed record GetAllDeletedUsersQuery() : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
