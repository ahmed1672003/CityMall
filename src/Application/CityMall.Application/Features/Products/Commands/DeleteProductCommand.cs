namespace CityMall.Application.Features.Products.Commands;

public sealed record DeleteProductCommand(string Id) : IRequest<ResponseModel<string>>;
