using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Cammonds;
public sealed record UpdateCategoryCommand(UpdateCategoryDto Dto) : IRequest<ResponseModel<string>>;
