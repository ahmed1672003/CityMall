namespace CityMall.Application.Features.ProductImages.Commands;
public sealed record DeleteProductImagesByProductIdCommand(string ProductId) : IRequest<ResponseModel<string>>;
