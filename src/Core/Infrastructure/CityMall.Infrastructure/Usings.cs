global using System.Reflection;

global using CityMall.Domain.Abstracts;
global using CityMall.Domain.Constants;
global using CityMall.Domain.Entities;
global using CityMall.Domain.Entities.Identity;
global using CityMall.Infrastructure.Context;
global using CityMall.Infrastructure.Context.Interceptors;
global using CityMall.Infrastructure.Repositories;
global using CityMall.Infrastructure.Repositories.Contracts;
global using CityMall.Infrastructure.Repositories.Contracts.Identity;
global using CityMall.Infrastructure.Repositories.Identity;
global using CityMall.Infrastructure.Settings;

global using MasaTour.TouristTripsManagement.Infrastructure.Repositories;

global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Diagnostics;
global using Microsoft.EntityFrameworkCore.Infrastructure;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.EntityFrameworkCore.Storage;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
namespace CityMall.Infrastructure;