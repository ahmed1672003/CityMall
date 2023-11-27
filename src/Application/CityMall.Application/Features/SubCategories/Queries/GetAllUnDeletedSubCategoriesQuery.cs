using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Queries;
public sealed record GetAllUnDeletedSubCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;
