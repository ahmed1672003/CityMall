using CityMall.Dtos.Dtos.ProductImages;

namespace CityMall.Services.Services;
public sealed record AddProductImagesCommand(AddProductImagesDto Dto) : IRequest<ResponseModel<string>>;
