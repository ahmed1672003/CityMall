using CityMall.Dtos.Dtos.Stocks;

namespace CityMall.Application.Features.Stocks.Queries;
public sealed record GetAllStocksQuery() : IRequest<ResponseModel<IEnumerable<GetStockDto>>>;
