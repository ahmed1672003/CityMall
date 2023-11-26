using System.Reflection;

using CityMall.Application;
using CityMall.Dtos;
using CityMall.Infrastructure;
using CityMall.Services;
using CityMall.Specifications;

using MasaTour.TouristTripsManagement.Domain;

using Microsoft.AspNetCore.Authentication.Negotiate;

namespace CityMall.API;

/// <summary>
/// 
/// </summary>
public static class APIDependencies
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddAPIDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services
            .AddDomainDependencies()
            .AddInfrastructureDependencies(configuration)
            .AddSpecificationsDependencies()
            .AddDtoDependencies()
            .AddServicesDependencies(configuration)
            .AddApplicationDependencies()
            .AddControllers();

        services.AddEndpointsApiExplorer();

        services
           .AddAuthentication(NegotiateDefaults.AuthenticationScheme)
           .AddNegotiate();

        services.AddAuthorization(options =>
        {
            // By default, all incoming requests will be authorized according to the default policy.
            options.FallbackPolicy = options.DefaultPolicy;
        });
        services.AddCors(options =>
        {
            options.AddPolicy("CityMall", options =>
            {
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

        services.AddSwaggerGen(options =>
        {
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
            options.UseInlineDefinitionsForEnums();
            options.DescribeAllParametersInCamelCase();
            options.InferSecuritySchemes();
        });
        return services;
    }
}
