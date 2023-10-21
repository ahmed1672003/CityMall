using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

namespace CityMall.Dtos;
public static class DtoDependencies
{
    public static IServiceCollection AddDtoDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
