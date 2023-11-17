namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ICityMallDbContext _context;
    public UnitOfWork(
        ICityMallDbContext context,
        IIdentityRepository identity,
        IRoleClaimRepository roleClaims,
        IRoleRepository roles,
        IUserClaimRepository userClaims,
        IUserJWTRepository userJWTs,
        IUserLoginRepository userLogins,
        IUserRoleMapperRepository userRoleMappers,
        IUserTokenRepository userTokens,
        IUserRepository users,
        IAddressRepository addresses,
        ICartItemRepository cartItems,
        ICartRepository carts,
        ICategoryRepository categories,
        ICustomerRepository customers,
        IOrderRepository orders,
        IOrderLineRepository ordersLines,
        IProductAttributeMapperRepository productAttributeMappers,
        IProductAttributeRepository productAttributes,
        IProductImageRepository productImages,
        IProductRepository products,
        IShipperRepository shippers,
        IStockRepository stocks,
        ISubCategoryRepository subCategories)
    {
        _context = context;
        Identity = identity;
        RoleClaims = roleClaims;
        Roles = roles;
        UserClaims = userClaims;
        UserJWTs = userJWTs;
        UserLogins = userLogins;
        UserRoleMappers = userRoleMappers;
        UserTokens = userTokens;
        Users = users;
        Addresses = addresses;
        CartItems = cartItems;
        Carts = carts;
        Categories = categories;
        Customers = customers;
        Orders = orders;
        OrdersLines = ordersLines;
        ProductAttributeMappers = productAttributeMappers;
        ProductAttributes = productAttributes;
        ProductImages = productImages;
        Products = products;
        Shippers = shippers;
        Stocks = stocks;
        SubCategories = subCategories;
    }

    public IIdentityRepository Identity { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserClaimRepository UserClaims { get; }
    public IUserJWTRepository UserJWTs { get; }
    public IUserLoginRepository UserLogins { get; }
    public IUserRoleMapperRepository UserRoleMappers { get; }
    public IUserTokenRepository UserTokens { get; }
    public IUserRepository Users { get; }
    public IAddressRepository Addresses { get; }
    public ICartItemRepository CartItems { get; }
    public ICartRepository Carts { get; }
    public ICategoryRepository Categories { get; }
    public ICustomerRepository Customers { get; }
    public IOrderRepository Orders { get; }
    public IOrderLineRepository OrdersLines { get; }
    public IProductAttributeMapperRepository ProductAttributeMappers { get; }
    public IProductAttributeRepository ProductAttributes { get; }
    public IProductImageRepository ProductImages { get; }
    public IProductRepository Products { get; }
    public IShipperRepository Shippers { get; }
    public IStockRepository Stocks { get; }
    public ISubCategoryRepository SubCategories { get; }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
         await _context.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
        await _context.Database.CommitTransactionAsync(cancellationToken);

    public async ValueTask DisposeAsync() =>
        await _context.DisposeAsync();

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) =>
        await _context.Database.RollbackTransactionAsync(cancellationToken);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
         await _context.SaveChangesAsync(cancellationToken);
}
