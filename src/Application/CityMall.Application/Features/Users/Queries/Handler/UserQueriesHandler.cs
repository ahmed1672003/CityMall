using System.Linq.Expressions;

using CityMall.Dtos.Dtos.Users.Profiles;

namespace CityMall.Application.Features.Users.Queries.Handler;
public sealed class UserQueriesHandler :
    IRequestHandler<GetAllUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<GetAllUnDeletedUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<GetAllDeletedUsersQuery, ResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<PaginateAllDeletedUsersQuery, PaginationResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<PaginateAllUnDeletedUsersQuery, PaginationResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<PaginateAllUsersQuery, PaginationResponseModel<IEnumerable<GetUserDto>>>,
    IRequestHandler<GetUserByIdQuery, ResponseModel<GetUserDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Ctor
    public UserQueriesHandler(
        IUnitOfWork context,
        ISpecificationsFactory specificationsFactory,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
    public async Task<ResponseModel<IEnumerable<GetUserDto>>>
            Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetAllUsersSpec =
                    _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingGetAllUsersSpecification));
            IQueryable<User> users = await _context.Users.RetrieveAllAsync(asNoTrackingGetAllUsersSpec, cancellationToken);

            return ResponseResult.Success(users.Mapp());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetUserDto>>>
            Handle(GetAllUnDeletedUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetAllUnDeletedUsersSpec =
                     _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingGetAllUnDeletedUsersSpecification));

            IQueryable<User> users = await _context.Users.RetrieveAllAsync(
                                asNoTrackingGetAllUnDeletedUsersSpec, cancellationToken);

            return ResponseResult.Success(users.Mapp());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<IEnumerable<GetUserDto>>>
            Handle(GetAllDeletedUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetAllDeletedUsersSpec =
                        _specificationsFactory.CreateUserSpecifications(
                                typeof(AsNoTrackingGetAllDeletedUsersSpecification));

            IQueryable<User> users = await _context.Users.RetrieveAllAsync(
                            asNoTrackingGetAllDeletedUsersSpec, cancellationToken);

            return ResponseResult.Success(users.Mapp());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }

    public async Task<ResponseModel<GetUserDto>>
            Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<User> asNoTrackingGetUserByIdSpec =
                        _specificationsFactory.CreateUserSpecifications(
                                        typeof(AsNoTrackingGetUserByIdSpecification), request.UserId);

            if (!await _context.Users.AnyAsync(asNoTrackingGetUserByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetUserDto>();

            User user = await _context.Users.RetrieveAsync(
                                            asNoTrackingGetUserByIdSpec, cancellationToken);

            return ResponseResult.Success(user.Mapp());
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetUserDto>(errors: ex.Message);
        }
    }

    public async Task<PaginationResponseModel<IEnumerable<GetUserDto>>>
            Handle(PaginateAllDeletedUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<User, object>> orderBy = user => new object();
            switch (request.OrderBy)
            {
                case UserOrderBy.Id:
                    orderBy = user => user.Id;
                    break;
                case UserOrderBy.UserName:
                    orderBy = user => user.UserName;
                    break;
                case UserOrderBy.FirstName:
                    orderBy = user => user.FirstName;
                    break;
                case UserOrderBy.LastName:
                    orderBy = user => user.LastName;
                    break;
                default:
                    orderBy = user => user.CreatedAt;
                    break;
            }
            ISpecification<User> asNoTrackingPaginateAllDeletedUsersSpec =
                                _specificationsFactory.CreateUserSpecifications(
                                    typeof(AsNoTrackingPaginateAllDeletedUsersSpecifications),
                                    request.PageNumber, request.PageSize, request.KeyWords, orderBy);

            IQueryable<User> users = await _context.Users.RetrieveAllAsync(
                                                asNoTrackingPaginateAllDeletedUsersSpec, cancellationToken);

            ISpecification<User> asNoTrackingGetAllDeletedUsersSpec =
                        _specificationsFactory.CreateUserSpecifications(
                                    typeof(AsNoTrackingGetAllDeletedUsersSpecification));

            return PaginationResponseResult.Success(
                users.Mapp(),
                pageSize: request.PageSize,
                currentPage: request.PageNumber,
                count: await _context.Users.CountAsync(asNoTrackingGetAllDeletedUsersSpec, cancellationToken)
                );
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }

    public async Task<PaginationResponseModel<IEnumerable<GetUserDto>>>
            Handle(PaginateAllUnDeletedUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<User, object>> orderBy = user => new object();
            switch (request.OrderBy)
            {
                case UserOrderBy.Id:
                    orderBy = user => user.Id;
                    break;
                case UserOrderBy.UserName:
                    orderBy = user => user.UserName;
                    break;
                case UserOrderBy.FirstName:
                    orderBy = user => user.FirstName;
                    break;
                case UserOrderBy.LastName:
                    orderBy = user => user.LastName;
                    break;
                default:
                    orderBy = user => user.CreatedAt;
                    break;
            }
            ISpecification<User> asNoTrackingPaginateAllUnDeletedUsersSpec =
                        _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingPaginateAllUnDeletedUsersSpecification),
                            request.PageNumber, request.PageSize, request.KeyWords, orderBy);

            IQueryable<User> users = await _context.Users.RetrieveAllAsync(
                                                    asNoTrackingPaginateAllUnDeletedUsersSpec, cancellationToken);

            ISpecification<User> asNoTrackingGetAllUnDeletedUsersSpec =
                        _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingGetAllUnDeletedUsersSpecification));

            return PaginationResponseResult.Success(
                users.Mapp(),
                pageSize: request.PageSize,
                currentPage: request.PageNumber,
                count: await _context.Users.CountAsync(asNoTrackingGetAllUnDeletedUsersSpec, cancellationToken)
                );
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }

    public async Task<PaginationResponseModel<IEnumerable<GetUserDto>>>
            Handle(PaginateAllUsersQuery request, CancellationToken cancellationToken)
    {
        try
        {
            Expression<Func<User, object>> orderBy = user => new object();
            switch (request.OrderBy)
            {
                case UserOrderBy.Id:
                    orderBy = user => user.Id;
                    break;
                case UserOrderBy.UserName:
                    orderBy = user => user.UserName;
                    break;
                case UserOrderBy.FirstName:
                    orderBy = user => user.FirstName;
                    break;
                case UserOrderBy.LastName:
                    orderBy = user => user.LastName;
                    break;
                default:
                    orderBy = user => user.CreatedAt;
                    break;
            }
            ISpecification<User> asNoTrackingPaginateAllUsersSpec =
                        _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingPaginateAllUsersSpecification),
                            request.PageNumber, request.PageSize, request.KeyWords, orderBy);

            IQueryable<User> users = await _context.Users.RetrieveAllAsync(
                                                    asNoTrackingPaginateAllUsersSpec, cancellationToken);

            ISpecification<User> asNoTrackingGetAllUsersSpecific =
                        _specificationsFactory.CreateUserSpecifications(
                            typeof(AsNoTrackingGetAllUsersSpecification));

            return PaginationResponseResult.Success(
                users.Mapp(),
                pageSize: request.PageSize,
                currentPage: request.PageNumber,
                count: await _context.Users.CountAsync(asNoTrackingGetAllUsersSpecific, cancellationToken)
                );
        }
        catch (Exception ex)
        {
            return PaginationResponseResult.InternalServerError<IEnumerable<GetUserDto>>(errors: ex.Message);
        }
    }
}