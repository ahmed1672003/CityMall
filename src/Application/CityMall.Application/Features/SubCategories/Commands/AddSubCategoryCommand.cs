using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Commands;
public sealed record AddSubCategoryCommand(AddSubCategoryDto Dto) : IRequest<ResponseModel<string>>;