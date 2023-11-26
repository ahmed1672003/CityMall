using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Queries;
public sealed record GetAllCustomersQuery() : IRequest<ResponseModel<IEnumerable<GetCustomerDto>>>;