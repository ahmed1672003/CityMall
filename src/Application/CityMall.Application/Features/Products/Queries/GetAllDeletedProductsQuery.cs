using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Queries;
public sealed record GetAllDeletedProductsQuery() : IRequest<ResponseModel<IEnumerable<GetProductDto>>>;
