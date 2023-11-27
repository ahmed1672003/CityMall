using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Queries;
public sealed record GetAllUnDeletedProductsQuery() : IRequest<ResponseModel<IEnumerable<GetProductDto>>>;
