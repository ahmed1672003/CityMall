global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;

global using AutoMapper;

global using CityMall.Domain.Entities;
global using CityMall.Domain.Entities.Identity;
global using CityMall.Dtos.Dtos.Addresses;
global using CityMall.Dtos.Dtos.Emails;
global using CityMall.Infrastructure.Repositories.Contracts;
global using CityMall.Infrastructure.Settings;
global using CityMall.Services.Exceptions;
global using CityMall.Services.Services.Contracts;
global using CityMall.Specifications.Contracts;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
namespace MasaTour.TouristTripsManagement.Services;

