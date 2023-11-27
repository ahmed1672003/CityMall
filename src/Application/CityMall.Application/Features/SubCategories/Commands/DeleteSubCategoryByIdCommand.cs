namespace CityMall.Application.Features.SubCategories.Commands;
public sealed record DeleteSubCategoryByIdCommand(string Id) : IRequest<ResponseModel<string>>;

