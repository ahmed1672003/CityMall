
namespace CityMall.Infrastructure.Context;
public sealed class CityMallDbContext :
    IdentityDbContext<User, Role, string, UserClaim, UserRoleMapper, UserLogin, RoleClaim, UserToken>, ICityMallDbContext
{
    public CityMallDbContext(DbContextOptions<CityMallDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<RoleClaim> RoleClaims => Set<RoleClaim>();
    public DbSet<UserClaim> UserClaims => Set<UserClaim>();
    public DbSet<UserLogin> UserLogins => Set<UserLogin>();
    public DbSet<UserRoleMapper> UserRoles => Set<UserRoleMapper>();
    public DbSet<UserToken> UserTokens => Set<UserToken>();
    public DbSet<UserJWT> UserJWTs => Set<UserJWT>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderLine> OrderLines => Set<OrderLine>();
    public DbSet<ProductAttribute> ProductAttributes => Set<ProductAttribute>();
    public DbSet<ProductAttributeMapper> ProductAttributeMappers => Set<ProductAttributeMapper>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Shipper> Shippers => Set<Shipper>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<SubCategory> SubCategories => Set<SubCategory>();
}
