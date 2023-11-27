using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Commands;
public sealed record UpdateStockCommand(UpdateStockDto Dto) : IRequest<ResponseModel<string>>;
