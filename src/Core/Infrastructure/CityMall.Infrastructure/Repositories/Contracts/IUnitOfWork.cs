namespace CityMall.Infrastructure.Repositories.Contracts;
public interface IUnitOfWork : IAsyncDisposable
{
    IIdentityRepository Identity { get; }
    IUserRepository Users { get; }
    IRoleClaimRepository RoleClaims { get; }
    IRoleRepository Roles { get; }
    IUserClaimRepository UserClaims { get; }
    IUserJWTRepository UserJWTs { get; }
    IUserLoginRepository UserLogins { get; }
    IUserRoleMapperRepository UserRoleMappers { get; }
    IUserTokenRepository UserTokens { get; }
    IAddressRepository Addresses { get; }
    ICartItemRepository CartItems { get; }
    ICartRepository Carts { get; }
    ICategoryRepository Categories { get; }
    ICustomerRepository Customers { get; }
    IOrderRepository Orders { get; }
    IOrderLineRepository OrdersLines { get; }
    IProductAttributeMapperRepository ProductAttributeMappers { get; }
    IProductAttributeRepository ProductAttributes { get; }
    IProductImageRepository ProductImages { get; }
    IProductRepository Products { get; }
    IShipperRepository Shippers { get; }
    IStockRepository Stocks { get; }
    ISubCategoryRepository SubCategories { get; }
    void UndoDeleted<T>(ref T entity) where T : IDeleteableTracker
    {
        entity.IsDeleted = false;
        entity.DeletedAt = null;
    }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
