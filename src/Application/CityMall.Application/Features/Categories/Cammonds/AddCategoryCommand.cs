using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Cammonds;
public sealed record AddCategoryCommand(AddCategoryDto Dto) : IRequest<ResponseModel<string>>;


