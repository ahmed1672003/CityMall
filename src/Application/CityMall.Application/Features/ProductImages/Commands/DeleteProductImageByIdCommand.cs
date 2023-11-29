namespace CityMall.Application.Features.ProductImages.Commands;
public sealed record DeleteProductImageByIdCommand(string Id) : IRequest<ResponseModel<string>>;
