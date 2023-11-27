using CityMall.Dtos.Dtos.SubCategories;

namespace CityMall.Application.Features.SubCategories.Queries;
public sealed record GetAllDeletedSubCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetSubCategoryDto>>>;
