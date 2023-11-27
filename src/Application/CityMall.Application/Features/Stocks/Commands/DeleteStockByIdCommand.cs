namespace CityMall.Application.Features.Stocks.Commands;
public sealed record DeleteStockByIdCommand(string Id) : IRequest<ResponseModel<string>>;
