global using System.Collections.Concurrent;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;

global using CityMall.Domain.Entities.Identity;
global using CityMall.Dtos.Dtos.Emails;
global using CityMall.Dtos.Dtos.Users.Auth;
global using CityMall.Infrastructure.Settings;
global using CityMall.Services.Services.Contracts;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;

global using Newtonsoft.Json;
namespace MasaTour.TouristTripsManagement.Services;

