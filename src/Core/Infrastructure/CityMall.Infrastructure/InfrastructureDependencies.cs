namespace CityMall.Infrastructure;
public static class InfrastructureDependencies
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        #region Register DbContext Options
        services.AddDbContext<ICityMallDbContext, CityMallDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CityMall_Database"));
            options.AddInterceptors(new DeleteableTrackerInterceptor());
            options.AddInterceptors(new UpdateableTrackerInterceptor());
            options.AddInterceptors(new CreateableTrackerInterceptors());
        }, ServiceLifetime.Scoped);
        #endregion

        #region Register Identity 
        services.AddIdentity<User, Role>(options =>
        {
            #region Email Options
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedAccount = false;
            #endregion

            #region Stores Options
            //options.Stores.ProtectPersonalData = true;
            #endregion

            #region Password Options
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 3;
            #endregion

            #region User Options
            options.User.RequireUniqueEmail = true;
            #endregion

            #region Lock Out Options
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
            #endregion

        }).AddEntityFrameworkStores<CityMallDbContext>().AddDefaultTokenProviders().AddDefaultUI();
        #endregion

        #region Redis Configurations
        services.AddStackExchangeRedisCache(redisOptions =>
        {
            string redisConnection = configuration.GetConnectionString("Redis");
            redisOptions.Configuration = "";
        });

        #endregion

        #region Register Contracts
        services
               .AddScoped<UserManager<User>>()
               .AddScoped<SignInManager<User>>()
               .AddScoped<RoleManager<Role>>()
               .AddScoped<IUnitOfWork, UnitOfWork>()
               .AddScoped<IIdentityRepository, IdentityRepository>()
               .AddScoped<IRoleRepository, RoleRepository>()
               .AddScoped<IRoleClaimRepository, RoleClaimRepository>()
               .AddScoped<IUserClaimRepository, UserClaimRepository>()
               .AddScoped<IUserJWTRepository, UserJWTRepository>()
               .AddScoped<IUserLoginRepository, UserLoginRepository>()
               .AddScoped<IUserRepository, UserRepository>()
               .AddScoped<IUserRoleMapperRepository, UserRoleMapperRepository>()
               .AddScoped<IUserTokenRepository, UserTokenRepository>()
               .AddScoped(typeof(IRepository<>), typeof(Repository<>));
        #endregion

        #region Seed Data

        #endregion

        #region Configurations
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        #endregion

        return services;
    }
}
