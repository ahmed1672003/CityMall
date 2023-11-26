using System.ComponentModel.DataAnnotations;
namespace CityMall.Application.Features.Customers.Commands;
public sealed record DeleteCustomerCommand([Required][MaxLength(64)][MinLength(64)] string Id) : IRequest<ResponseModel<string>>;

