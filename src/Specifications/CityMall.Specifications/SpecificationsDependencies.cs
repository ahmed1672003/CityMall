using Microsoft.Extensions.DependencyInjection;

namespace CityMall.Specifications;
public static class SpecificationsDependencies
{
    public static IServiceCollection AddSpecificationsDependencies(this IServiceCollection services)
    {
        services
            .AddScoped<ISpecificationsFactory, SpecificationsFactory>()
            .AddScoped(typeof(ISpecification<>), typeof(Specification<>));
        return services;
    }
}
