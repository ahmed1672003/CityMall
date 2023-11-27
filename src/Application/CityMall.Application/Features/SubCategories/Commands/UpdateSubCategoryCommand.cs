using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Commands;
public sealed record UpdateSubCategoryCommand(UpdateSubCategoryDto Dto) : IRequest<ResponseModel<string>>;
