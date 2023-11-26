using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Commands;
public sealed record AddCustomerCommand(AddCustomerDto Dto) : IRequest<ResponseModel<string>>;