using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Queries;
public sealed record GetAllUnDeletedCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
