using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Queries;
public sealed record GetAllDeletedCategoriesQuery() : IRequest<ResponseModel<IEnumerable<GetCategoryDto>>>;
