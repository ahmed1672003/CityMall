using CityMall.Dtos.Dtos.Customers;

namespace CityMall.Application.Features.Customers.Queries;
public sealed record GetAllUnDeletedCustomersQuery() : IRequest<ResponseModel<IEnumerable<GetCustomerDto>>>;
