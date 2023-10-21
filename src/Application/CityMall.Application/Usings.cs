global using System.Data.Common;
global using System.Net;
global using System.Text.Json;

global using AutoMapper;

global using CityMall.Application.Helpers;
global using CityMall.Application.Response;
global using CityMall.Domain.Entities.Identity;
global using CityMall.Dtos.Dtos.Auth;
global using CityMall.Dtos.Dtos.Emails;
global using CityMall.Dtos.Dtos.Files;
global using CityMall.Dtos.Dtos.Users;
global using CityMall.Dtos.Enums;
global using CityMall.Infrastructure.Constants;
global using CityMall.Infrastructure.Repositories.Contracts;
global using CityMall.Services.Services.Contracts;
global using CityMall.Specifications.Contracts;
global using CityMall.Specifications.Specifications.Users;

global using MediatR;

global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.WebUtilities;
global using Microsoft.EntityFrameworkCore;

namespace CityMall.Application;

