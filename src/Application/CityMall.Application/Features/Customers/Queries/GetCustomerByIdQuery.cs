using System.ComponentModel.DataAnnotations;

using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Queries;
public sealed record GetCustomerByIdQuery([Required][MaxLength(64)][MinLength(64)] string Id) : IRequest<ResponseModel<GetCustomerDto>>;