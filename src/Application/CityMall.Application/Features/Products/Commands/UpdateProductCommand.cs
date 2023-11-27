using CityMall.Dtos.Dtos.Products;

namespace CityMall.Application.Features.Products.Commands;

public sealed record UpdateProductCommand(UpdateProductDto Dto) : IRequest<ResponseModel<string>>;
