using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Commands;
public sealed record AddProductCommand(AddProductDto Dto) : IRequest<ResponseModel<string>>;
