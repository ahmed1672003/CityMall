using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Commands;
public sealed record AddStockCommand(AddStockDto Dto) : IRequest<ResponseModel<string>>;
