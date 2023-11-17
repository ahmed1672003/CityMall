namespace CityMall.Infrastructure.Context;
public interface ICityMallDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    DbSet<User> Users { get; }
    DbSet<Role> Roles { get; }
    DbSet<RoleClaim> RoleClaims { get; }
    DbSet<UserClaim> UserClaims { get; }
    DbSet<UserLogin> UserLogins { get; }
    DbSet<UserRoleMapper> UserRoles { get; }
    DbSet<UserToken> UserTokens { get; }
    DbSet<UserJWT> UserJWTs { get; }

    DbSet<Address> Addresses { get; }
    DbSet<Cart> Carts { get; }
    DbSet<CartItem> CartItems { get; }
    DbSet<Category> Categories { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Order> Orders { get; }
    DbSet<OrderLine> OrderLines { get; }
    DbSet<ProductAttribute> ProductAttributes { get; }
    DbSet<ProductAttributeMapper> ProductAttributeMappers { get; }
    DbSet<Product> Products { get; }
    DbSet<ProductImage> ProductImages { get; }
    DbSet<Shipper> Shippers { get; }
    DbSet<Stock> Stocks { get; }
    DbSet<SubCategory> SubCategories { get; }

    ValueTask DisposeAsync();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DatabaseFacade Database { get; }
}
