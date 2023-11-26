using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Queries;
public sealed record GetAllDeletedCustomersQuery() : IRequest<ResponseModel<IEnumerable<GetCustomerDto>>>;
