namespace CityMall.Application.Features.Categories.Cammonds;
public sealed record DeleteCategoryByIdCommand(string Id) : IRequest<ResponseModel<string>>;
