namespace CityMall.Application.Features.Users.Queries;
public sealed record SearchAllUnDeletedUsersQuery : IRequest<ResponseModel<IEnumerable<GetUserDto>>>;
