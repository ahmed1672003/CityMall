using System.Reflection;

using CityMall.Application;
using CityMall.Dtos;
using CityMall.Infrastructure;
using CityMall.Services;
using CityMall.Specifications;

using MasaTour.TouristTripsManagement.Domain;

using Microsoft.AspNetCore.Authentication.Negotiate;

namespace CityMall.API;

public static class APIDependencies
{
    public static IServiceCollection AddAPIDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
           .AddNegotiate();
        services.AddAuthorization(options =>
        {
            // By default, all incoming requests will be authorized according to the default policy.
            options.FallbackPolicy = options.DefaultPolicy;
        });

        services
            .AddDomainDependencies()
            .AddInfrastructureDependencies(configuration)
            .AddSpecificationsDependencies()
            .AddDtoDependencies()
            .AddServicesDependencies(configuration)
            .AddApplicationDependencies();

        services.AddSwaggerGen(options =>
        {
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
