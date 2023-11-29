using CityMall.Dtos.Dtos.ProductImages;

namespace CityMall.Application.Features.ProductImages.Queries;
public sealed record GetAllImagesProductByProductIdQuery(string ProductId) : IRequest<ResponseModel<IEnumerable<GetProductImageDto>>>;
