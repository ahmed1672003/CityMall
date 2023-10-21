namespace CityMall.Application.Features.Users.Queries.Handler;
public sealed class UserQueriesHandler
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly IUnitOfServices _services;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    #endregion

    #region Ctor
    public UserQueriesHandler(IUnitOfWork context, IUnitOfServices services, ISpecificationsFactory specificationsFactory, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _services = services;
        _specificationsFactory = specificationsFactory;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
}
