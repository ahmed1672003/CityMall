using CityMall.Dtos.Dtos.Categories;

namespace CityMall.Application.Features.Categories.Queries;
public sealed record GetCategoryByIdQuery(string Id) : IRequest<ResponseModel<GetCategoryDto>>;
