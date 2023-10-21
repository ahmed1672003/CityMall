
namespace CityMall.Application.Features.Users.Queries;
public sealed record PaginateAllDeletedUsersQuery(int PageNumber, int PageSize, string KeyWords, UserOrderBy OrderBy) : IRequest<PaginationResponseModel<IEnumerable<GetUserDto>>>;
