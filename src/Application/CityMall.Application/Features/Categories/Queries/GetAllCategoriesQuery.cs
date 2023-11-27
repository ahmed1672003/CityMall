using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Queries;
public sealed record GetAllCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
