using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Queries;
public sealed class GetAllProductsQuery() : IRequest<ResponseModel<IEnumerable<GetProductDto>>>;

