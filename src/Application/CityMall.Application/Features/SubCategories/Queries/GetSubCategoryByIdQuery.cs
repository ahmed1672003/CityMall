using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Queries;
public sealed record GetSubCategoryByIdQuery(string Id) : IRequest<ResponseModel<GetSubCategoryDto>>;
