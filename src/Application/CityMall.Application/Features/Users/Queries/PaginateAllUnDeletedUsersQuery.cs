namespace CityMall.Application.Features.Users.Queries;
public sealed record PaginateAllUnDeletedUsersQuery(int PageNumber, int PageSize, string KeyWords, UserOrderBy OrderBy) : IRequest<PaginationResponseModel<IEnumerable<GetUserDto>>>;
