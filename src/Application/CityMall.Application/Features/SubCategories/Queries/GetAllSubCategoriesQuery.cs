using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Queries;
public sealed record GetAllSubCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;

