using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Commands;
public sealed record UpdateCustommerCommand(UpdateCustomerDto Dto) : IRequest<ResponseModel<string>>;
