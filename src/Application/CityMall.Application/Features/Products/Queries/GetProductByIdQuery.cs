using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Queries;
public sealed record GetProductByIdQuery(string Id) : IRequest<ResponseModel<GetProductDto>>;
